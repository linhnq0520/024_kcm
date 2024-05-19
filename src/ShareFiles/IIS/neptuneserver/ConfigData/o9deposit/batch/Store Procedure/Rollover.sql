use o9deposit;
GO

IF OBJECT_ID('[Rollover]', 'P') IS NOT NULL
BEGIN
    -- The procedure exists
    DROP PROCEDURE Rollover;
END;
GO

CREATE PROCEDURE [dbo].[Rollover] (@AccountNumber NVARCHAR(100), @CatalogCode NVARCHAR(30), @WorkingDate DATE)
AS
BEGIN
    DECLARE @Sql NVARCHAR(3000) = '';
    DECLARE @DepositType NVARCHAR(30) = '';
    DECLARE @DepositStatus NVARCHAR(30) = '';
    DECLARE @MultipleDepositAllow NVARCHAR(30) = '';
    DECLARE @Rollover NVARCHAR(30) = '';
    DECLARE @DepositGroup NVARCHAR(30) = '';
    DECLARE @ListColumn TABLE (
    Id INT identity(1, 1),
    ColumnName NVARCHAR(500));
    
    INSERT INTO @ListColumn(ColumnName)
    SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'DepositCatalog' AND 
            COLUMN_NAME IN (SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'DepositAccount') AND COLUMN_NAME <> 'Id';
    
    SELECT @DepositGroup = DepositGroup, @Rollover = Rollover FROM dbo.DepositAccount WHERE AccountNumber = @AccountNumber;
        
    DECLARE @rows INT = ( SELECT COUNT(*) FROM @ListColumn);
    
    -- PRINT @rows;

    IF (@rows = 0)
            RETURN;
    DECLARE @row INT = 0;
    WHILE (@row < @rows)
        BEGIN
            SET @row = @row + 1;
            
            DECLARE @ColumnName NVARCHAR(500);

            SELECT @ColumnName = ColumnName
            FROM @ListColumn
            WHERE Id = @row;
            
            -- PRINT @ColumnName;
            SET @Sql = 'UPDATE dbo.DepositAccount SET '+@ColumnName+' = (SELECT '+@ColumnName+' FROM dbo.DepositCatalog WHERE CatalogCode = '''+@CatalogCode+''') WHERE AccountNumber = '''+@AccountNumber+''';';      
            
            --PRINT @Sql;
            EXEC (@Sql);
        END;
    
    UPDATE dbo.DepositAccount SET MonthAverageBalance = 0, 
                                QuarterAverageBalance = 0,
                                SemiAnnualAverageBalance=0,
                                YearAverageBalance=0,
                                WeekDebit = 0,
                                WeekCredit = 0,
                                MonthDebit=0,
                                MonthCredit=0,
                                QuarterDebit=0,
                                QuarterCredit=0,
                                SemiAnnualDebit=0,
                                SemiAnnualCredit=0,
                                YearDebit=0,
                                YearCredit=0
                                WHERE AccountNumber = @AccountNumber
    
    -- Fixed
    UPDATE dbo.DepositAccount
    SET BeginOfTenor = CAST(@WorkingDate AS DATE),
        EndOfTenor = dbo.NextMaturityDate(Tenor, TenorUnit, @WorkingDate),
        -- DepositStatus = CASE WHEN DepositStatus <> 'B' THEN (CASE WHEN MultipleDepositAllow = 'N' THEN 'A' ELSE 'N' END) ELSE DepositStatus END,
        DepositStatus = CASE WHEN DepositStatus <> 'B' THEN 'N' ELSE DepositStatus END,
        Psts = CASE WHEN LEN(Psts) < 499 THEN Psts + '|' + DepositStatus ELSE SUBSTRING(Psts, 2, LEN(Psts)) + '|' + DepositStatus END
    WHERE AccountNumber = @AccountNumber AND DepositType = 'T';
    
    -- Currrent, Saving
    UPDATE dbo.DepositAccount
    SET CloseDate = NULL
    WHERE AccountNumber = @AccountNumber AND DepositType IN ('C', 'S');

    -- Rollover IFC
    
    --1. Disable un-used IFC
    UPDATE  dbo.IfcBalance
    SET     IfcBalanceStatus = 'D', LastDatetime = @WorkingDate
    FROM    dbo.IfcBalance B
    WHERE   AccountNumber = @AccountNumber AND
               NOT EXISTS (SELECT  I.IfcCode
                           FROM    dbo.DepositIFCDefinition I
                           INNER JOIN dbo.DepositCatalogIFCs  T ON I.IfcCode = T.IfcCode
                           INNER JOIN dbo.DepositCatalog C ON T.CatalogCode = C.CatalogCode
                           WHERE I.IfcStatus = 'N' AND I.IfcCode = B.IfcCode AND C.CatalogCode = @CatalogCode
                           );

      --2. Insert new IFC
      INSERT INTO dbo.IfcBalance (AccountNumber, IfcCode, IfcValue , LastDatetime)
      SELECT @AccountNumber AccountNumber, I.IfcCode,I.IfcValue, @WorkingDate LastDatetime
      FROM    dbo.DepositCatalog C
      INNER JOIN dbo.DepositCatalogIFCs T ON C.CatalogCode = T.CatalogCode 
      INNER JOIN dbo.DepositIFCDefinition I    ON T.IfcCode = I.IfcCode
      WHERE   C.CatalogCode = @CatalogCode AND I.IfcStatus = 'N' AND 
               NOT EXISTS(SELECT   B.IfcCode
                        FROM     dbo.IfcBalance B
                        WHERE    AccountNumber  =  @AccountNumber AND B.IfcCode = I.IfcCode
                        );
      
      MERGE dbo.IfcBalance a
            USING (SELECT i.*
                     FROM dbo.DepositCatalog c
                        INNER JOIN dbo.DepositCatalogIFCs t ON c.CatalogCode  = t.CatalogCode
                        INNER JOIN dbo.DepositIFCDefinition i ON t.IfcCode = i.IfcCode
                  WHERE c.CatalogCode = @CatalogCode) ifc
               ON (a.IfcCode = ifc.IfcCode)
      WHEN MATCHED AND a.AccountNumber = @AccountNumber
      THEN UPDATE SET a.MarginValue = CASE WHEN a.ValueBase = 'I' THEN ifc.MarginValue ELSE a.MarginValue END, a.IfcValue = ifc.IfcValue;
    
END;
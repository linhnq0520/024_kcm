USE o9deposit;
GO

IF OBJECT_ID('[IfcRate]', 'FN') IS NOT NULL
BEGIN
    Drop FUNCTION [IfcRate];
END;
GO

CREATE FUNCTION dbo.IfcRate (@IfcCode INT)        
    RETURNS decimal(24,17)
BEGIN
     DECLARE @tenorUnit NVARCHAR(10) = 'D';
     DECLARE @ifcValue decimal(24,5) = 1;
     DECLARE @ifcTenor INT;
     DECLARE @ifcTenorUnit NVARCHAR(10);
 
    SELECT @ifcTenor = IfcTenor, @ifcTenorUnit = IfcTenorUnit FROM dbo.DepositIFCDefinition WHERE IfcCode = @IfcCode;
 
    IF (@ifcTenor = 0) RETURN 0;

    DECLARE @Wom INT = 4; -- Week OF Month
    DECLARE @Dom INT = 30; -- Day OF Month
    DECLARE @Woy INT = 7; -- Week OF Year
    DECLARE @Doy INT = 30; -- Day OF Year
    DECLARE @Woh INT = 7; -- Week OF HalfYear
    DECLARE @Doh INT = 30; -- Day OF HalfYear
    DECLARE @Woq INT = 7; -- Week OF Quarter
    DECLARE @Doq INT = 30; -- Day OF Quarter
    DECLARE @Dow INT = 30; -- Day OF Week

    SELECT @Wom = s.Value FROM dbo.Setting s WHERE s.Name = 'DepositSettings.Wom';
    SELECT @Dom = s.Value FROM dbo.Setting s WHERE s.Name = 'DepositSettings.Dom';
    SELECT @Woy = s.Value FROM dbo.Setting s WHERE s.Name = 'DepositSettings.Woy';
    SELECT @Doy = s.Value FROM dbo.Setting s WHERE s.Name = 'DepositSettings.Doy';
    SELECT @Woh = s.Value FROM dbo.Setting s WHERE s.Name = 'DepositSettings.Woh';
    SELECT @Doh = s.Value FROM dbo.Setting s WHERE s.Name = 'DepositSettings.Doh';
    SELECT @Woq = s.Value FROM dbo.Setting s WHERE s.Name = 'DepositSettings.Woq';
    SELECT @Doq = s.Value FROM dbo.Setting s WHERE s.Name = 'DepositSettings.Doq';
    SELECT @Dow = s.Value FROM dbo.Setting s WHERE s.Name = 'DepositSettings.Dow';
    
    DECLARE @value decimal(24,17) = @ifcValue / @ifcTenor;
    
    IF (@tenorUnit = 'M')
        SET @value = CASE
            WHEN @ifcTenorUnit = 'Y' THEN @value / 12
            WHEN @ifcTenorUnit = 'H' THEN @value / 6
            WHEN @ifcTenorUnit = 'Q' THEN @value / 3
            WHEN @ifcTenorUnit = 'W' THEN @value * @Wom
            WHEN @ifcTenorUnit = 'D' THEN @value * @Dom
            ELSE @value
        END;

    IF (@tenorUnit = 'Y')
        SET @value = CASE
            WHEN @ifcTenorUnit = 'M' THEN @value * 12
            WHEN @ifcTenorUnit = 'H' THEN @value * 2
            WHEN @ifcTenorUnit = 'Q' THEN @value * 4
            WHEN @ifcTenorUnit = 'W' THEN @value * @Woy
            WHEN @ifcTenorUnit = 'D' THEN @value * @Doy
            ELSE @value
        END;

    IF (@tenorUnit = 'H')
        SET @value = CASE
            WHEN @ifcTenorUnit = 'M' THEN @value * 6
            WHEN @ifcTenorUnit = 'Y' THEN @value / 2
            WHEN @ifcTenorUnit = 'Q' THEN @value * 2
            WHEN @ifcTenorUnit = 'W' THEN @value * @Woh
            WHEN @ifcTenorUnit = 'D' THEN @value * @Doh
            ELSE @value
        END;

    IF (@tenorUnit = 'Q')
        SET @value = CASE
            WHEN @ifcTenorUnit = 'M' THEN @value * 3
            WHEN @ifcTenorUnit = 'Y' THEN @value / 4
            WHEN @ifcTenorUnit = 'H' THEN @value / 2
            WHEN @ifcTenorUnit = 'W' THEN @value * @Woq
            WHEN @ifcTenorUnit = 'D' THEN @value * @Doq
            ELSE @value
        END;

    IF (@tenorUnit = 'W')
        SET @value = CASE
            WHEN @ifcTenorUnit = 'M' THEN @value / @Dom
            WHEN @ifcTenorUnit = 'Y' THEN @value / @Doy
            WHEN @ifcTenorUnit = 'H' THEN @value / @Doh
            WHEN @ifcTenorUnit = 'Q' THEN @value / @Doq
            WHEN @ifcTenorUnit = 'D' THEN @value * @Dow
            ELSE @value
        END;

    DECLARE @totalDay INT = 0;
    DECLARE @WorkingDate DATE;

   	SELECT TOP 1 @WorkingDate = CAST(ValueDate AS DATE)  FROM dbo.[Transaction] ORDER BY id DESC ;
   
   	SELECT @totalDay = dbo.GET_ACTUAL_DAYS_OF_CURRENT_YEAR(@WorkingDate);
    IF (@tenorUnit = 'D')
        SET @value = CASE
            WHEN @ifcTenorUnit = 'M' THEN @value / @Dom
            WHEN @ifcTenorUnit = 'Y' THEN @value / @totalDay --@Doy
            WHEN @ifcTenorUnit = 'P' THEN @value / @totalDay
            WHEN @ifcTenorUnit = 'H' THEN @value / @Doh
            WHEN @ifcTenorUnit = 'Q' THEN @value / @Doq
         WHEN @ifcTenorUnit = 'W' THEN @value / @Dow
            ELSE @value
        END;

    
    RETURN @value / 100;
END
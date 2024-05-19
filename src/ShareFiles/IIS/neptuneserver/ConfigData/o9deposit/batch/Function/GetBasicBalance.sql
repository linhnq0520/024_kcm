USE o9deposit;
GO

IF OBJECT_ID('[GetBasicBalance]', 'FN') IS NOT NULL
BEGIN
    Drop FUNCTION [GetBasicBalance];
END;
GO

CREATE FUNCTION [dbo].GetBasicBalance (@AccountNumber NVARCHAR(100),@IfcCode INT, @WorkingDate DATE)        
    RETURNS DECIMAL(24,6)
BEGIN 
    DECLARE @Balance DECIMAL(24,5) = 0;
    DECLARE @ValueBasic NVARCHAR(100);
    DECLARE @BasicBalance DECIMAL(24,6) = 0;
    DECLARE @CurrentBalance DECIMAL(24,6) = 0;
    DECLARE @OpenDate DATE;
    DECLARE @FirstDay DATE = DATEFROMPARTS(YEAR(@WorkingDate), MONTH(@WorkingDate), 1);


    SELECT @CurrentBalance = CurrentBalance, @OpenDate = OpenDate FROM dbo.DepositAccount WHERE AccountNumber = @AccountNumber;
    SELECT @BasicBalance = BasicBalance FROM dbo.IFCBalance WHERE IfcCode = @IfcCode AND AccountNumber = @AccountNumber;
    SELECT @ValueBasic = ValueBasic FROM dbo.DepositIFCDefinition WHERE IfcCode = @IfcCode;

    SET @Balance = @BasicBalance;
    
    IF (@ValueBasic LIKE '%GetMinBalance%')
    BEGIN
        DECLARE @StringInput NVARCHAR(500) = @ValueBasic;
        DECLARE @integerPart INT
        SET @integerPart = PATINDEX('%[^0-9]%', @StringInput)
        BEGIN
            WHILE @integerPart > 0
            BEGIN
                SET @StringInput = STUFF(@StringInput, @integerPart, 1, '' )
                SET @integerPart = PATINDEX('%[^0-9]%', @StringInput )
            END
        END
        
        DECLARE @ParamDay INT = CAST(@StringInput AS int);
    
        IF(DAY(@WorkingDate) = @ParamDay AND CAST(@WorkingDate AS DATE) >= CAST(@OpenDate AS DATE))
            SET @Balance = @CurrentBalance;
        
        IF ( CAST(@OpenDate AS Date) <= CAST(@WorkingDate AS Date) AND DAY(@WorkingDate) >= @ParamDay)
        BEGIN
            IF(DAY(@OpenDate) > @ParamDay AND MONTH(@OpenDate) = MONTH(@WorkingDate) AND YEAR(@OpenDate) = YEAR(@WorkingDate) )
            SET @Balance = 0
            ELSE
            SELECT @Balance = LEAST(@Balance, @CurrentBalance);
        END;

    END;

    IF (@ValueBasic LIKE '%GetAverageBalance%')
    BEGIN
        SET @Balance = @BasicBalance;
        IF (CAST(@WorkingDate AS DATE) = CAST(@OpenDate AS DATE) OR (DAY(@WorkingDate) = 1 AND CAST(@WorkingDate AS DATE) > CAST(@OpenDate AS DATE)))
            SET @Balance = @CurrentBalance;
        
        IF ( CAST(@WorkingDate AS DATE) > CAST(@OpenDate AS DATE))
        BEGIN
            DECLARE @BeginDate DATE = @FirstDay;
            IF YEAR(@WorkingDate) = YEAR(@OpenDate) AND MONTH(@WorkingDate) = MONTH(@OpenDate)
                SET @BeginDate = @OpenDate;
            
            DECLARE @Index INT = DATEDIFF(DAY, @BeginDate,@WorkingDate) + 1; 
            SET @Balance = (@Balance * (@Index - 1) + @CurrentBalance) / @Index;
        END;
    END;
    
    RETURN @Balance;
END
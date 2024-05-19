USE o9deposit;
GO

IF OBJECT_ID('[TotalDayOfMonth]', 'FN') IS NOT NULL
BEGIN
    Drop FUNCTION [TotalDayOfMonth];
END;
GO

CREATE FUNCTION [dbo].[TotalDayOfMonth] (@accountNumber NVARCHAR(100), @WorkingDate DATE)         
    RETURNS  INT
    BEGIN 
        DECLARE @OpenDate DATE;
        SELECT @OpenDate = OpenDate FROM dbo.DepositAccount WHERE AccountNumber = @accountNumber;
        
        -- Thang mo tai khoan
        IF YEAR(@WorkingDate) = YEAR(@OpenDate) AND MONTH(@WorkingDate) = MONTH(@OpenDate)
            RETURN DATEDIFF(DAY, @OpenDate,@WorkingDate) + 1;
        
        RETURN DAY(@WorkingDate)
END
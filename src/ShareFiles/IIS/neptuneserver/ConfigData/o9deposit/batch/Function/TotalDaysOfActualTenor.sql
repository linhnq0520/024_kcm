USE o9deposit;
GO

IF OBJECT_ID('[TotalDaysOfActualTenor]', 'FN') IS NOT NULL
BEGIN
    Drop FUNCTION [TotalDaysOfActualTenor];
END;
GO

CREATE FUNCTION dbo.TotalDaysOfActualTenor (@accountNumber NVARCHAR(100), @IfcCode INT)
    RETURNS INT
BEGIN 
      DECLARE @tenor INT = 0;

DECLARE @totalDay INT = 0;

DECLARE @beginOfTenor DATE;

DECLARE @date DATE;

SELECT @beginOfTenor = BeginOfTenor
FROM DepositAccount da
WHERE da.AccountNumber = @accountNumber;

IF (@beginOfTenor IS NOT NULL)
BEGIN
    SELECT @tenor = IfcTenor FROM DepositIFCDefinition WHERE IfcCode = @IfcCode;

    SET @date = DATEADD(MONTH , @tenor, @beginOfTenor) ;
    
    SET @totalDay = DATEDIFF(DAY, @beginOfTenor,@date);
END
    
    RETURN @totalDay;
END
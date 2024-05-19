USE o9deposit;
GO

IF OBJECT_ID('[ActualTenor]', 'FN') IS NOT NULL
BEGIN
    Drop FUNCTION [ActualTenor];
END;
GO

CREATE FUNCTION ActualTenor (@accountNumber NVARCHAR(100), @WorkingDate DATE)         
    RETURNS  INT
    BEGIN 
      DECLARE @tenor INT = 0;
      DECLARE @isExist INT;
      DECLARE @BeginOfTenor DATE;
  
  
    SELECT @isExist=  count(*), @BeginOfTenor = da.BeginOfTenor from DepositAccount da WHERE da.AccountNumber = @accountNumber GROUP BY da.BeginOfTenor;
    
    IF (@isExist = 0)
        RETURN 0;
       
      IF (@BeginOfTenor IS NOT NULL)
       BEGIN
       SET  @tenor = DATEDIFF(MONTH, @BeginOfTenor, @WorkingDate);
        IF (DAY(@WorkingDate) < DAY(@BeginOfTenor))
         SET @tenor = @tenor -1;
        END;
       
  
        RETURN @tenor;
  END 
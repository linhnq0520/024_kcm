USE o9deposit;
GO

IF OBJECT_ID('[GetAverageBalance]', 'FN') IS NOT NULL
BEGIN
    Drop FUNCTION [GetAverageBalance];
END;
GO

CREATE FUNCTION GetAverageBalance (@ifcCode INT, @accountNumber NVARCHAR(100))         
    RETURNS  decimal(24,5)
    BEGIN 
      DECLARE @balance decimal(24,5) = 0;
     
  
    SELECT @balance = BasicBalance FROM IFCBalance i WHERE i.AccountNumber = @accountNumber AND i.IfcCode = @ifcCode;
    
    RETURN @balance;
  END 
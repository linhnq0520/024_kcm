USE o9deposit;
GO

IF OBJECT_ID('[GetMinBalance]', 'FN') IS NOT NULL
BEGIN
    Drop FUNCTION [GetMinBalance];
END;
GO

CREATE FUNCTION GetMinBalance (@ifcCode INT, @accountNumber NVARCHAR(100), @fromDay INT)         
    RETURNS  decimal(24,5)
    BEGIN 
      DECLARE @balance decimal(24,5) = 0;
     
  
    SELECT @balance = BasicBalance FROM IFCBalance i WHERE i.AccountNumber = @accountNumber AND i.IfcCode = @ifcCode;
    
    RETURN @balance;
  END 
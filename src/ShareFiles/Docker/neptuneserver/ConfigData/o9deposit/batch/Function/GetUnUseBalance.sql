USE o9deposit;
GO

IF OBJECT_ID('[GetUnUseBalance]', 'FN') IS NOT NULL
BEGIN
  Drop FUNCTION [GetUnUseBalance];
END;
GO

CREATE FUNCTION dbo.GetUnUseBalance (@accountNumber NVARCHAR(100))         
    RETURNS  decimal(24,5)
    BEGIN
  DECLARE @value decimal(24,5) = 0;
  DECLARE @overDraftBalance decimal(24,5) = 0;
  DECLARE @isExist INT;
  DECLARE @odLimit decimal(24,5) = 0;

  -- ContractStatus = 0  <-> Normal
  -- ContractStatus = 1  <-> Closed
  -- ContractStatus = 2  <-> Block

  SELECT @isExist =  count(*), @odLimit = oc.OdLimit
  FROM dbo.OverdraftContract oc
  WHERE oc.AccountNumber  = @accountNumber AND (oc.ContractStatus = 0 or oc.ContractStatus = 2 or oc.ContractStatus = 7)
  GROUP  BY oc.OdLimit;

  IF (@isExist = 0)
                RETURN 0;

  SELECT @overDraftBalance = dbo.GetOverDraftBalance(@accountNumber)
  SELECT @value = MAX(Value)
  FROM (            SELECT 0 AS Value
    UNION
      SELECT @odLimit - @overDraftBalance AS Value) AS Tmp;

  RETURN @value;
END 
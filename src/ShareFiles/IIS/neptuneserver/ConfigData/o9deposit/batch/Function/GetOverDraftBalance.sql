USE o9deposit;
GO

IF OBJECT_ID('[GetOverDraftBalance]', 'FN') IS NOT NULL
BEGIN
      Drop FUNCTION [GetOverDraftBalance];
END;
GO

CREATE FUNCTION dbo.GetOverDraftBalance (@accountNumber NVARCHAR(100))         
    RETURNS  decimal(24,5)
    BEGIN
      DECLARE @value decimal(24,5) = 0;
      DECLARE @isExist INT;
      DECLARE @includedMinimumBalance NVARCHAR(10);
      DECLARE @minimumDepositAmount decimal(24,5) = 0;
      DECLARE @currentBalance decimal(24,5) = 0;


      SELECT @isExist=  count(*), @minimumDepositAmount = da.MinimumDepositAmount, @currentBalance = da.CurrentBalance
      from DepositAccount da
      WHERE da.AccountNumber = @accountNumber
      GROUP  BY da.MinimumDepositAmount, da.CurrentBalance;

      IF (@isExist = 0)
        RETURN 0;

      -- ContractStatus = 0  <-> Normal
      -- ContractStatus = 1  <-> Closed
      -- ContractStatus = 2  <-> Block

      SELECT @isExist =  count(*), @includedMinimumBalance = oc.IncludedMinimumBalance
      FROM dbo.OverdraftContract oc
      WHERE oc.AccountNumber  = @accountNumber AND (oc.ContractStatus = 0 or oc.ContractStatus = 2 or oc.ContractStatus = 7)
      GROUP  BY oc.IncludedMinimumBalance;

      IF (@isExist = 0)
        RETURN 0;

      IF (@includedMinimumBalance = 'Y' AND (@minimumDepositAmount - @currentBalance > 0))
        SET @value = @minimumDepositAmount - @currentBalance;

      IF (@includedMinimumBalance = 'N' AND (@currentBalance <= 0))
        SET @value = Abs(@currentBalance);

      RETURN @value;
END 
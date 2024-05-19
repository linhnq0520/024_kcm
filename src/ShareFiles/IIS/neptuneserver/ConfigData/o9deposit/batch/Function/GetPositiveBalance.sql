USE o9deposit;
GO

IF OBJECT_ID('[GetPositiveBalance]', 'FN') IS NOT NULL
BEGIN
    Drop FUNCTION [GetPositiveBalance];
END;
GO

CREATE FUNCTION dbo.GetPositiveBalance (@AccountNumber NVARCHAR(200))        
    RETURNS DECIMAL(24,5)
BEGIN
    DECLARE @PositiveAmount DECIMAL(24,5);

    -- Select @PositiveAmount = case when b.IncludedMinimumBalance = 'N' then a.CurrentBalance when  b.IncludedMinimumBalance = 'Y' then a.CurrentBalance - a.MinimumDepositAmount end
    Select @PositiveAmount = a.CurrentBalance - a.MinimumDepositAmount - a.EarmarkBookAmount
    FROM dbo.DepositAccount a
        INNER JOIN dbo.OverDraftContract b on a.AccountNumber = b.AccountNumber
    where a.AccountNumber = @AccountNumber
        AND (b.ContractStatus = 0 or b.ContractStatus = 2);

    RETURN case when @PositiveAmount >= 0 then @PositiveAmount when @PositiveAmount <= 0 then 0 end;
END
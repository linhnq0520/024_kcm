use o9deposit;
GO

IF OBJECT_ID('[B_DPT_ACOD]', 'P') IS NOT NULL
BEGIN
    -- The procedure exists
    DROP PROCEDURE B_DPT_ACOD
;
END;
GO

CREATE PROCEDURE dbo.[B_DPT_ACOD]
    (
    @TransactionNumber VARCHAR(36),
    @WorkingDate DATE,
    @UserCode NVARCHAR(50),
    @UserName NVARCHAR(250),
    @BatchDate DATETIME,
    @StepName NVARCHAR(200),
    @ReferenceId NVARCHAR(200) = NULL,
    @RefId NVARCHAR(200) = NULL,
    @ReferenceCode NVARCHAR(200) = NULL,
    @TranId NVARCHAR(200) = NULL,
    @Description NVARCHAR(200) = NULL,
    @BusinessCode NVARCHAR(200) = NULL,
    @ChannelID NVARCHAR(200) = NULL
)
AS
BEGIN TRY

BEGIN TRANSACTION;

-- Create transaction
    EXEC CREATE_TRANSACTION @TransactionNumber = @TransactionNumber,
        @WorkingDate = @WorkingDate,
        @UserCode = @UserCode,
        @UserName = @UserName,
        @BatchDate = @BatchDate,
        @StepName = @StepName,
        @ReferenceId = @ReferenceId,
        @RefId = @RefId,
        @ReferenceCode = @ReferenceCode,
        @TranId = @TranId,
        @Description = @Description,
        @BusinessCode = @BusinessCode,
        @ChannelID = @ChannelID;

	 EXEC o9mortgage.dbo.CREATE_TRANSACTION @TransactionNumber = @TransactionNumber,
        @WorkingDate = @WorkingDate,
        @UserCode = @UserCode,
        @UserName = @UserName,
        @BatchDate = @BatchDate,
        @StepName = @StepName,
        @ReferenceId = @ReferenceId,
        @RefId = @RefId,
        @ReferenceCode = @ReferenceCode,
        @TranId = @TranId,
        @Description = @Description,
        @BusinessCode = @BusinessCode,
        @ChannelID = @ChannelID;

-- Main processing code here
-- Select temp table for Mortgage Account secure Amount for OD contract can be closed auto
IF OBJECT_ID('tempdb..#MortgageAccountTemp') IS NOT NULL DROP TABLE #MortgageAccountTemp;
SELECT mortgageAccount.AccountNumber, MortgageReference, ModuleCode, Amount, ClearAmount, ModuleAmount, ModuleClearAmount
INTO #MortgageAccountTemp
from o9mortgage.dbo.MortgageAccount mortgageAccount
    inner join
    (select AccountNumber, MortgageReference, ModuleCode, Amount, ClearAmount, ModuleAmount, ModuleClearAmount
    from o9mortgage.dbo.MortgageBalance
    where MortgageReference in
	(select contract.ContractNumber ContractNumber
    FROM dbo.OverdraftContract contract
        inner join (select sum(Round(Amount, 2)) Amount, count(ContractNumber) Count, ContractNumber
        from ODContractIFCBalance
        group by ContractNumber) ifcbal on contract.ContractNumber  = ifcbal.ContractNumber
    where (contract.ContractStatus = 0) -- Normal
        and contract.ToDate <= @WorkingDate -- over due date
        and dbo.GetOverDraftBalance(contract.AccountNumber) = 0 -- dont have overdraft balance
        and ifcbal.Amount = 0
        and contract.SecureAmount > 0)) mortgageBalance on mortgageAccount.AccountNumber = mortgageBalance.AccountNumber
where mortgageAccount.CollateralAccountStatus ='N' and Amount - ClearAmount >0;

-- Update MortgageAccount
Update o9mortgage.dbo.MortgageAccount
set ReleasedCollateralAmount = ReleasedCollateralAmount + ReleaseAmountInMortgageCurrency
from o9mortgage.dbo.MortgageAccount mortgageAccount
    inner join (select sum(Amount - ClearAmount) ReleaseAmountInMortgageCurrency, AccountNumber
    from #MortgageAccountTemp
    group by AccountNumber) temp on mortgageAccount.AccountNumber = temp.AccountNumber;

-- Update MortgageBalance
Update o9mortgage.dbo.MortgageBalance
set ClearAmount = mortgageBalance.Amount, ModuleClearAmount = mortgageBalance.ModuleAmount
from o9mortgage.dbo.MortgageBalance mortgageBalance
    inner join #MortgageAccountTemp temp on mortgageBalance.AccountNumber = temp.AccountNumber and mortgageBalance.MortgageReference = temp.MortgageReference

-- Insert Mortgage history
INSERT INTO o9mortgage.dbo.MortgageHistory
    ([AccountNumber], [TransactionDate], [ReferenceId], [ValueDate], [TransactionCode], [Amount], [Dorc], [Description], [UserCode])
select
    AccountNumber -- [AccountNumber]
	, CONVERT(DATE,  GETDATE()) -- [TransactionDate]
	, @RefId -- [RefId]
	, @WorkingDate -- [ValueDate]
	, @StepName -- [TransactionCode]
	, Amount - ClearAmount -- [Amount]
	, 'D' -- [Dorc]
	, @StepName + ': Auto Release mortgage from OD contract [' + MortgageReference + '] - mortgage account [' + AccountNumber + ']' -- [Description]
	, @UserCode
from #MortgageAccountTemp;

-- Insert Mortgage transaction
INSERT INTO o9mortgage.dbo.MortgageTransaction
    ([AccountNumber], [TransactionDate], [ReferenceId], [TransactionCode], [Amount], [DirAmount], [TransactionStatus])
select
    AccountNumber -- [AccountNumber]
	, @WorkingDate -- [TransactionDate]
	, @RefId -- [[ReferenceId]]
	, @StepName -- [TransactionCode]
	, Amount - ClearAmount -- [Amount]
	, 0 -- [DirAmount]
	, 'N'
-- [TransactionStatus]
from #MortgageAccountTemp;
DROP TABLE #MortgageAccountTemp;

-- Select OD contract can be close into temp table
IF OBJECT_ID('tempdb..#OverdraftContractTemp') IS NOT NULL DROP TABLE #OverdraftContractTemp;
SELECT contract.ContractNumber,
    contract.AccountNumber, mtgBalance.SecureAmount
INTO #OverdraftContractTemp
FROM dbo.OverdraftContract contract
    inner join (select sum(Round(Amount, 2)) Amount, count(ContractNumber) Count, ContractNumber
    from ODContractIFCBalance
    group by ContractNumber) ifcbal on contract.ContractNumber  = ifcbal.ContractNumber
    left join (select MortgageReference, sum(case when ModuleClearAmount is null then ModuleAmount else ModuleAmount - ModuleClearAmount end) SecureAmount
    from o9mortgage.dbo.MortgageBalance
    group by MortgageReference) mtgBalance on  mtgBalance.MortgageReference = contract.ContractNumber
where (contract.ContractStatus = 0) -- Normal
    and contract.ToDate <= @WorkingDate -- over due date
    and dbo.GetOverDraftBalance(contract.AccountNumber) = 0 -- dont have overdraft balance
    and ifcbal.Amount = 0 -- dont have fee or interest

-- Update Contract status
UPDATE OverdraftContract
SET ContractStatus = 1, CloseDate = @WorkingDate, SecureAmount = case when (temp.SecureAmount = 0 or temp.SecureAmount is null) then 0 else temp.SecureAmount end 
FROM OverdraftContract contract
    inner join #OverdraftContractTemp temp on temp.ContractNumber = contract.ContractNumber

-- Update ODContractIFCBalance
UPDATE ODContractIFCBalance
SET IfcBalanceStatus = 'D'
FROM ODContractIFCBalance ifcbal
    inner join #OverdraftContractTemp temp on temp.ContractNumber = ifcbal.ContractNumber
where temp.SecureAmount = 0 or temp.SecureAmount is null
-- Insert into Deposit History
INSERT INTO DepositHistory
    ([AccountNumber], [ValueDate], [RefId], [TransactionDate], [TransactionCode], [Amount], [Dorc], [Description], [UsrCode], [Oder], [DepositHistoryStatus], [Stcode], [Usrid], [ChannelId])
Select

    AccountNumber -- [AccountNumber]
		, @WorkingDate -- [ValueDate]
		, @RefId -- [RefId]
		, CONVERT(DATE,  GETDATE()) -- [TransactionDate]
		, @StepName -- [TransactionCode]
		, 0 -- [Amount]
		, 'D' -- [Dorc]
		, @StepName + ': Auto close OD contract for account [' + AccountNumber + ']' -- [Description]
		, @UserCode -- [UsrCode]
		, 1 -- [Oder]
		, 'N' -- [DepositHistoryStatus] 
		, '-' -- [Stcode]
		, 0 --[Usrid]
		, @ChannelID
-- [ChannelId]
from #OverdraftContractTemp 

-- drop temp table
DROP TABLE #OverdraftContractTemp;

COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    throw;
END CATCH;
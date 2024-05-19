use o9credit;
GO 
IF OBJECT_ID('[B_CRD_ACOD_EXEC]', 'P') IS NOT NULL BEGIN -- The procedure exists
	DROP PROCEDURE B_CRD_ACOD_EXEC;
END;
GO 
CREATE PROCEDURE [dbo].[B_CRD_ACOD_EXEC] (
		@TransactionNumber VARCHAR(36),
		@WorkingDate DATE,
		@UserCode NVARCHAR(5),
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
	) AS BEGIN TRY BEGIN TRANSACTION;

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

-- 3. Reverse & Post Provisioning
DELETE FROM dbo.ProvisioningTrans WHERE TransactionNumber = @TransactionNumber;

INSERT INTO dbo.ProvisioningTrans (
		[TransactionNumber],
		[TransId],
		[CreditAccount],
		[TransCode],
		[Amount],
		[CurrentClassificationStatus],
		[TransactionStatus],
		[GLPopulated]
	)
SELECT @TransactionNumber,
	NewID(),
	b.[AccountNumber], -- [CreditAccount]
	'REVERSE_PROVISIONING', --[TransCode]
	b.[ProvisionOfOther], --[Amount]: previous provisioning keep amount in field [ProvisionOfOther]
	b.[ClassificationStatus], --[ClassificationStatus]
	'N', --[TransactionStatus]
	0 --[GLPopulated]
FROM o9credit.dbo.CreditAccount b
	inner join (
		select sum(Round(Amount, 2)) Amount,
			AccountNumber
		from o9credit.dbo.CreditIFCBalance
		group by AccountNumber
	) ifcbal on b.AccountNumber = ifcbal.AccountNumber
where b.Crdsts in (0, 2) -- Normal, block
	and b.ToDate <= @WorkingDate -- over due date
	and b.Balance = 0 -- dont have balance
	and ifcbal.Amount <= 0
	and b.ProvisionOfOther <> 0;

----2. Update available product and sub product

UPDATE o9credit.dbo.CreditSubProductLimit
SET AvailableAmount += a.DisbursementAmount
FROM o9credit.dbo.CreditAccount a
	inner join (
		select sum(Round(Amount, 2)) Amount,
			AccountNumber
		from o9credit.dbo.CreditIFCBalance
		group by AccountNumber
	) ifcbal on a.AccountNumber = ifcbal.AccountNumber
	inner join CreditSubProductLimit s on s.SubProductLimitCode = a.SubProductLimitCode
	inner join CreditProductLimit P on p.ProductLimitCode = s.ProductLimitCode
where a.Crdsts in (0, 2) -- Normal, block
	and a.ToDate <= @WorkingDate
	and a.Balance = 0
	and ifcbal.Amount <= 0;

UPDATE o9credit.dbo.CreditProductLimit
SET AvailableAmount += a.DisbursementAmount -- Các giao dịch giải ngân đang trừ DisbursementAmount
FROM o9credit.dbo.CreditAccount a
	inner join (
		select sum(Round(Amount, 2)) Amount,
			AccountNumber
		from o9credit.dbo.CreditIFCBalance
		group by AccountNumber
	) ifcbal on a.AccountNumber = ifcbal.AccountNumber
	inner join CreditSubProductLimit s on s.SubProductLimitCode = a.SubProductLimitCode
	inner join CreditProductLimit P on p.ProductLimitCode = s.ProductLimitCode
where a.Crdsts in (0, 2) -- Normal, block
	and a.ToDate <= @WorkingDate
	and a.Balance = 0
	and ifcbal.Amount <= 0;

---- 3 Create CreditHistory
DELETE FROM CreditHistory
WHERE TransactionRefId = @TransactionNumber;
INSERT INTO CreditHistory (
		[AccountNumber],
		[TransactionDate],
		[TransactionRefId],
		[TransactionNumber],
		[ValueDate],
		[TransactionCode],
		[Amount],
		[Dorc],
		[Description],
		[UserCreated],
		[STATUS],
		[UserApprove],
		[ChannelId]
	)
SELECT account.AccountNumber, --DefAccountNumber
	CONVERT(DATE,  GETDATE()), --TransactionDate
	@RefId, --TransactionRefId
	@TransactionNumber, --[TransactionNumber]
	@WorkingDate, --ValueDate
	'B_CRD_ACOD_EXEC', --TransactionCode
	account.Balance, --Amount
	'N', --Dorc
	@StepName +' Auto close credit account [' +  account.AccountNumber+ ']', --Description
	@UserCode, --@UserCode: UserCreated
	'N', --Status
	NULL, --@UserCode: UserApprove
	'C'
FROM o9credit.dbo.CreditAccount account
	inner join (
		select sum(Round(Amount, 2)) Amount,
			AccountNumber
		from o9credit.dbo.CreditIFCBalance
		group by AccountNumber
	) ifcbal on account.AccountNumber = ifcbal.AccountNumber
where account.Crdsts in (0, 2) -- Normal, block
	and account.ToDate <= @WorkingDate -- over due date
	and account.Balance = 0 -- dont have balance
	and ifcbal.Amount <= 0;

-- Select temp table Mortgage account (For auto release secure balance)
IF OBJECT_ID('tempdb..#MortgageAccountTemp') IS NOT NULL DROP TABLE #MortgageAccountTemp;
SELECT mortgageAccount.AccountNumber, MortgageReference, ModuleCode, Amount, ClearAmount, ModuleAmount, ModuleClearAmount
INTO #MortgageAccountTemp
from o9mortgage.dbo.MortgageAccount mortgageAccount
    inner join
    (select AccountNumber, MortgageReference, ModuleCode, Amount, ClearAmount, ModuleAmount, ModuleClearAmount
    from o9mortgage.dbo.MortgageBalance
    where MortgageReference in
	(select a.AccountNumber FROM o9credit.dbo.CreditAccount a
		inner join ( select sum(Round(Amount, 2)) Amount, AccountNumber from o9credit.dbo.CreditIFCBalance group by AccountNumber ) ifcbal on a.AccountNumber = ifcbal.AccountNumber
		inner join CreditSubProductLimit s on s.SubProductLimitCode = a.SubProductLimitCode
		inner join CreditProductLimit P on p.ProductLimitCode = s.ProductLimitCode
	where a.Crdsts in (0, 2) -- Normal, block
		and a.ToDate <= @WorkingDate
		and a.Balance = 0
		and ifcbal.Amount <= 0)) mortgageBalance on mortgageAccount.AccountNumber = mortgageBalance.AccountNumber and ModuleCode = 'CRD'
where mortgageAccount.CollateralAccountStatus ='N' and Amount - ClearAmount > 0;

-- 1 Update credit account
UPDATE o9credit.dbo.CreditAccount
SET Crdsts = 1,
	CreditStatus = 1,
	CloseDate = @WorkingDate,
	ProvisionOfOther = 0,
	ProvisionPrincipal = 0,
	SecuredAmount = 0
FROM o9credit.dbo.CreditAccount account
	inner join (
		select sum(Round(Amount, 2)) Amount,
			AccountNumber
		from o9credit.dbo.CreditIFCBalance
		group by AccountNumber
	) ifcbal on account.AccountNumber = ifcbal.AccountNumber
where account.Crdsts in (0, 2) -- Normal, block
	and account.ToDate <= @WorkingDate -- over due date
	and account.Balance = 0 -- dont have balance
	and ifcbal.Amount <= 0;
exec dbo.GenerateGLEntriesFromProvisioningTrans @TransactionNumber = @TransactionNumber;

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
	, @StepName + ': Auto Release mortgage from credit account [' + MortgageReference + '] - mortgage account [' + AccountNumber + ']' -- [Description]
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

COMMIT TRANSACTION;
END TRY BEGIN CATCH ROLLBACK TRANSACTION;
throw;
END CATCH;
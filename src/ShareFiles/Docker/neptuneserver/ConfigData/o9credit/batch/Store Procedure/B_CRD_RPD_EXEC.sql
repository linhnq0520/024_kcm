use o9credit;
GO

IF OBJECT_ID('[B_CRD_RPD_EXEC]', 'P') IS NOT NULL
BEGIN
    -- The procedure exists
    DROP PROCEDURE B_CRD_RPD_EXEC;
END;
GO

CREATE PROCEDURE [dbo].[B_CRD_RPD_EXEC]
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

DECLARE @current_working_date DATE = @WorkingDate;

DECLARE @SubProductLimitAmount DECIMAL(24, 9) = 0;
DECLARE @ProductLimitAmount DECIMAL(24, 9) = 0;

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

-- Main processing code here (Master Trans)

-- Get list Repayment
IF OBJECT_ID('tempdb..#ListRepayment') IS NOT NULL DROP TABLE #ListRepayment;
CREATE TABLE #ListRepayment (CurrentBalance DECIMAL(24, 2)
							, DepositAccountNumber NVARCHAR(50)
							, CreditAccountNumber NVARCHAR(50)
							, ToTalPrincipalAmount DECIMAL(24, 2)
							, RemainingProvisionAmount DECIMAL(24, 2)
							, ClassificationStatus NVARCHAR(50)
							, CreditCurrencyCode NVARCHAR(50)
							, CreditBranchCode NVARCHAR(50)
							, DepositCurrencyCode NVARCHAR(50)
							, DepositBranchCode NVARCHAR(50));

Insert into #ListRepayment
Select dptAcc.AvailableBalance as CurrentBalance
	, dptAcc.AccountNumber as DepositAccountNumber
	, crdAcc.AccountNumber as CreditAccountNumber 
	, 0 as ToTalPrincipalAmount 
	, crdAcc.ProvisionPrincipal as  RemainingProvisionAmount
	, crdAcc.ClassificationStatus as ClassificationStatus
	, crdAcc.CurrencyCode as CreditCurrencyCode
	, crdAcc.BranchCode as CreditBranchCode
	, dptAcc.CurrencyCode as DepositCurrencyCode
	, dptAcc.BranchCode as DepositBranchCode
from (select * from dbo.CreditAccount where Crdsts in (0, 2, 3) and DueAmount > 0) crdAcc
    inner join (select * from o9deposit.dbo.AccountLinkage where LinkageType = 'C' and LinkageClass ='A') dptLinkage on dptLinkage.MasterAccountNumber = crdAcc.AccountNumber
    inner join (select *, o9deposit.dbo.GetAvailableBalance(AccountNumber, @WorkingDate, 1) as AvailableBalance from o9deposit.dbo.DepositAccount where DepositStatus = 'N' and o9deposit.dbo.GetAvailableBalance(AccountNumber, @WorkingDate, 1) > 0) dptAcc on dptAcc.AccountNumber = dptLinkage.LinkageAccountNumber;

-- Update #ListRepayment cho trường hợp nhiều CRD <--> 1 DPT
-- Update lại #ListRepayment cho trường hợp Nhiều CRD <--> 1 DPT
	DECLARE @DepositAccountNumber VARCHAR(max),
	@AvailableBalance decimal(24,2);

	DECLARE @CreditAccountNumber VARCHAR(max),
	@CreditDueAmount decimal(24,2);

	DECLARE listRepaymentCursor CURSOR
	FOR
	SELECT DepositAccountNumber,
		CurrentBalance
	FROM #ListRepayment ;

		OPEN listRepaymentCursor;

		FETCH NEXT
		FROM listRepaymentCursor
		INTO @DepositAccountNumber,
			@AvailableBalance;

		WHILE @@FETCH_STATUS = 0
		BEGIN

		-- Phân bổ lại available balance cho từng CreditAccount
		DECLARE creditAccountCursor CURSOR
		FOR
		SELECT CreditAccountNumber,
				acc.DueAmount
		From #ListRepayment list
		inner join CreditAccount acc on list.CreditAccountNumber = acc.AccountNumber
		where DepositAccountNumber = @DepositAccountNumber
		order by CreditAccountNumber;

		OPEN creditAccountCursor;

		FETCH NEXT
			FROM creditAccountCursor
			INTO @CreditAccountNumber,
			@CreditDueAmount;
		
		WHILE @@FETCH_STATUS = 0

			BEGIN
			Update #ListRepayment 
				set ToTalPrincipalAmount =  iif(@AvailableBalance > @CreditDueAmount, @CreditDueAmount, @AvailableBalance)
			where DepositAccountNumber = @DepositAccountNumber and CreditAccountNumber = @CreditAccountNumber;

			select @AvailableBalance = @AvailableBalance -  iif(@AvailableBalance > @CreditDueAmount, @CreditDueAmount, @AvailableBalance);
			if(@AvailableBalance = 0)
			BEGIN
				BREAK;
			END
			FETCH NEXT
				FROM creditAccountCursor
				INTO @CreditAccountNumber,
					@CreditDueAmount;
		END;
		CLOSE creditAccountCursor;
		DEALLOCATE creditAccountCursor;

		FETCH NEXT
			FROM listRepaymentCursor
			INTO @DepositAccountNumber,
			@AvailableBalance;

		END;
	CLOSE listRepaymentCursor;
	DEALLOCATE listRepaymentCursor;
	
	Delete from #ListRepayment where ToTalPrincipalAmount = 0;


-- DecreasePrincipal
Update dbo.CreditAccount
set 
	OverdueAmount = Case when acc.ClassificationStatus != 'N' then acc.OverdueAmount - TotalPrincipalAmount else acc.OverdueAmount end, 
	NormalPrincipalAmount = Case when acc.ClassificationStatus = 'N' then acc.NormalPrincipalAmount - TotalPrincipalAmount else acc.NormalPrincipalAmount end, 
	PrincipalPaidAmount = acc.PrincipalPaidAmount + TotalPrincipalAmount,
	DueAmount = case when acc.DueAmount > TotalPrincipalAmount then acc.DueAmount - TotalPrincipalAmount else 0 end,
	Balance = Balance - TotalPrincipalAmount,
	WeekDebit = WeekDebit + TotalPrincipalAmount,
	MonthDebit = MonthDebit + TotalPrincipalAmount,
	QuarterDebit = QuarterDebit + TotalPrincipalAmount,
	SemiAnnualDebit = SemiAnnualDebit + TotalPrincipalAmount,
	YearDebit = YearDebit + TotalPrincipalAmount
from dbo.CreditAccount acc inner join #ListRepayment listRepayment on acc.AccountNumber = listRepayment.CreditAccountNumber;

-- Update CreditClassification if has data
Update dbo.CreditClassification 
set ClassificationAmount = ClassificationAmount + TotalPrincipalAmount 
	from dbo.CreditClassification class
    inner join dbo.CreditAccount acc on class.AccountNumber = acc.AccountNumber and class.ClassificationType = acc.ClassificationStatus
    inner join #ListRepayment listRepayment on acc.AccountNumber = listRepayment.CreditAccountNumber
	where class.Rptype ='P';

-- Insert CreditClasification if has no data
Insert into dbo.CreditClassification
    (AccountNumber, ClassificationAmount, Clsclr, ClassificationType, Rptype, Ord)
select
    AccountNumber as AccountNumber
	, TotalPrincipalAmount as ClassificationAmount
	, 0 as Clsclr
	, ClassificationStatus as ClassificationType
	, 'P' as Rptype
	, 1 as Ord
from
    (select
        acc.AccountNumber as AccountNumber 
	, listRepayment.TotalPrincipalAmount as TotalPrincipalAmount
	, acc.ClassificationStatus as ClassificationStatus
	, class.ClassificationAmount as ClassificationAmount
    from dbo.CreditAccount acc inner join #ListRepayment listRepayment on acc.AccountNumber = listRepayment.CreditAccountNumber
        left join dbo.CreditClassification class on class.AccountNumber = acc.AccountNumber and class.ClassificationType = acc.ClassificationStatus) a
where ClassificationAmount is null;

-- create statenment
insert into CreditStatement
    (
    [AccountNumber]
    , [StatementDate]
    , [ReferenceId]
    , [ValueDate]
    , [Amount]
    , [ConvertAmount]
    , [CurrencyCode]
    , [StatementCode]
    , [StatementStatus]
    , [TransCode]
    , [TransactionNumber]
    , [Description]
    , [CreatedOnUtc]
    , [UpdatedOnUtc]
    )
select
    acc.AccountNumber
	, GETUTCDATE()
	, @RefId  
    , @WorkingDate  
	, listRepayment.TotalPrincipalAmount
	, 0
	, acc.CurrencyCode
	, 'WDR'
	, 'N'
	, @StepName
	, @TransactionNumber
	, 'Principal collection. A/c: ' + acc.AccountNumber
	, GETUTCDATE()
    , GETUTCDATE()
from dbo.CreditAccount acc inner join #ListRepayment listRepayment on acc.AccountNumber = listRepayment.CreditAccountNumber;

-- Insert into Credit History
INSERT INTO CreditHistory
    (
    [AccountNumber],
    [TransactionDate],
    [TransactionRefId],
    [ValueDate],
    [TransactionCode],
    [Amount],
    [Dorc],
    [Description],
    [UserCreated],
    [STATUS],
    [UserApprove],
    [TransactionNumber],
    [ChannelId]
    )
SELECT CreditAccountNumber, --DefAccountNumber
    GETUTCDATE(), --TransactionDate
    @RefId, --TransactionRefId
    @WorkingDate, --ValueDate
    @StepName, --TransactionCode
    TotalPrincipalAmount, --Amount
    'D', --Dorc
    @StepName + ' Principal collection. A/c: [' + CreditAccountNumber + ']', -- [Description] --Description
    @UserCode, --@UserCode: UserCreated
    'N', --Status
    null, --@UserCode: UserApprove
    @TransactionNumber, -- TransactionNumber
    @ChannelID
from #ListRepayment;

-- Insert CreditAccountTrans
insert into [CreditAccountTrans]
    ([TransId], [TransactionNumber], [CreditAccount], [CurrentClassificationStatus], [TransCode], [TransactionStatus], [Amount], [GLPopulated], [CrossBranchCode], [CrossCurrencyCode])
select
    NewID(),
    @TransactionNumber --[TransactionNumber]
	, CreditAccountNumber  -- [CreditAccount]
	, acc.ClassificationStatus
	, 'CRD_DEBIT_BALANCE'
	, 'N' -- [TransactionStatus]
	, TotalPrincipalAmount -- [Amount]
	, 0
	, list.DepositBranchCode
	, list.DepositCurrencyCode
from #ListRepayment list inner join CreditAccount acc on acc.AccountNumber = list.CreditAccountNumber;

exec dbo.GenerateGLEntriesFromCreditAccountTrans

-- Update CreditAccountLimitDetail

insert into dbo.CreditAccountLimitDetail
    (TransactionRefId, TransactionDate, AccountNumber, SubProductLimitCode, ProductLimitCode, Acrt, Acamt, Splrt, Splamt, Plrt, Plamt, Status, Dorc, Txrefidrl, Txdtrl, Ord, Acpaid, Splpaid, Plpaid)
select
    @RefId
	, @WorkingDate
	, acc.AccountNumber
	, spLimit.SubProductLimitCode
	, pLimit.ProductLimitCode
	, limitDetail.Acrt
	, case when list.TotalPrincipalAmount < limitDetail.Acamt - limitDetail.Acpaid then list.TotalPrincipalAmount else limitDetail.Acamt - limitDetail.Acpaid end
	, limitDetail.Splrt
	, case when acc.CurrencyCode != pLimit.CurrencyCode then Round((case when list.TotalPrincipalAmount < limitDetail.Acamt - limitDetail.Acpaid then list.TotalPrincipalAmount else limitDetail.Acamt - limitDetail.Acpaid end)*limitDetail.Acrt/limitDetail.Splrt, 9) else (case when list.TotalPrincipalAmount < limitDetail.Acamt - limitDetail.Acpaid then list.TotalPrincipalAmount else limitDetail.Acamt - limitDetail.Acpaid end) end
	, limitDetail.Plrt
	, case when acc.CurrencyCode != pLimit.CurrencyCode then Round((case when list.TotalPrincipalAmount < limitDetail.Acamt - limitDetail.Acpaid then list.TotalPrincipalAmount else limitDetail.Acamt - limitDetail.Acpaid end)*limitDetail.Acrt/limitDetail.Plrt, 9) else (case when list.TotalPrincipalAmount < limitDetail.Acamt - limitDetail.Acpaid then list.TotalPrincipalAmount else limitDetail.Acamt - limitDetail.Acpaid end) end
	, 'N'
	, 'D'
	, limitDetail.TransactionRefId
	, limitDetail.TransactionDate
	, 1
	, (case when list.TotalPrincipalAmount < limitDetail.Acamt - limitDetail.Acpaid then list.TotalPrincipalAmount else limitDetail.Acamt - limitDetail.Acpaid end) --Acpaid
	, case when acc.CurrencyCode != pLimit.CurrencyCode then Round((case when list.TotalPrincipalAmount < limitDetail.Acamt - limitDetail.Acpaid then list.TotalPrincipalAmount else limitDetail.Acamt - limitDetail.Acpaid end)*limitDetail.Acrt/limitDetail.Splrt, 9) else (case when list.TotalPrincipalAmount < limitDetail.Acamt - limitDetail.Acpaid then list.TotalPrincipalAmount else limitDetail.Acamt - limitDetail.Acpaid end) end
	, case when acc.CurrencyCode != pLimit.CurrencyCode then Round((case when list.TotalPrincipalAmount < limitDetail.Acamt - limitDetail.Acpaid then list.TotalPrincipalAmount else limitDetail.Acamt - limitDetail.Acpaid end)*limitDetail.Acrt/limitDetail.Plrt, 9) else (case when list.TotalPrincipalAmount < limitDetail.Acamt - limitDetail.Acpaid then list.TotalPrincipalAmount else limitDetail.Acamt - limitDetail.Acpaid end) end

from #ListRepayment list inner join dbo.CreditAccount acc on list.CreditAccountNumber = acc.AccountNumber
    inner join dbo.CreditSubProductLimit spLimit on acc.SubProductLimitCode = spLimit.SubProductLimitCode
    inner join dbo.CreditProductLimit pLimit on spLimit.ProductLimitCode = pLimit.ProductLimitCode
    inner join dbo.CreditAccountLimitDetail limitDetail on limitDetail.AccountNumber = acc.AccountNumber
Where pLimit.LimitType ='M' and list.TotalPrincipalAmount > 0 and limitDetail.Dorc = 'C' and limitDetail.Status != 'R' and limitDetail.Acamt -  limitDetail.Acpaid > 0 and limitDetail.Txrefidrl is null;

-- Update SubProduct Limit 
Update dbo.CreditSubProductLimit 
set AvailableAmount = spLimit.AvailableAmount + (CreditSplamt - DebitSplamt)
from
    (Select Sum(Acamt) as CreditAcamt, sum(Plamt) as CreditAPlam, sum(Splamt) as CreditSplamt, AccountNumber
    from dbo.CreditAccountLimitDetail
    where Status != 'R' and Dorc = 'C'
    group by AccountNumber) CredittDetail
    inner join (Select Sum(Acamt) as DebitAcamt, sum(Plamt) as DebitAPlam, sum(Splamt) as DebitSplamt, AccountNumber
    from dbo.CreditAccountLimitDetail
    where Status != 'R' and Dorc = 'D'
    group by AccountNumber) DebitDetail
    on CredittDetail.AccountNumber = DebitDetail.AccountNumber
    inner join #ListRepayment list on list.CreditAccountNumber = DebitDetail.AccountNumber
    inner join dbo.CreditAccount acc on list.CreditAccountNumber = acc.AccountNumber
    inner join dbo.CreditSubProductLimit spLimit on spLimit.SubProductLimitCode = acc.SubProductLimitCode
    inner join dbo.CreditProductLimit pLimit on pLimit.ProductLimitCode = spLimit.ProductLimitCode
where CreditAcamt = DebitAcamt and (CreditAPlam != DebitAPlam or CreditSplamt != DebitSplamt)
    and pLimit.LimitType ='M';

-- Update ProductLimit Limit 
Update dbo.CreditProductLimit 
set AvailableAmount = pLimit.AvailableAmount + (CreditAPlam - DebitAPlam)
from
    (Select Sum(Acamt) as CreditAcamt, sum(Plamt) as CreditAPlam, sum(Splamt) as CreditSplamt, AccountNumber
    from dbo.CreditAccountLimitDetail
    where Status != 'R' and Dorc = 'C'
    group by AccountNumber) CredittDetail
    inner join (Select Sum(Acamt) as DebitAcamt, sum(Plamt) as DebitAPlam, sum(Splamt) as DebitSplamt, AccountNumber
    from dbo.CreditAccountLimitDetail
    where Status != 'R' and Dorc = 'D'
    group by AccountNumber) DebitDetail
    on CredittDetail.AccountNumber = DebitDetail.AccountNumber
    inner join #ListRepayment list on list.CreditAccountNumber = DebitDetail.AccountNumber
    inner join dbo.CreditAccount acc on list.CreditAccountNumber = acc.AccountNumber
    inner join dbo.CreditSubProductLimit spLimit on spLimit.SubProductLimitCode = acc.SubProductLimitCode
    inner join dbo.CreditProductLimit pLimit on pLimit.ProductLimitCode = spLimit.ProductLimitCode
where CreditAcamt = DebitAcamt and (CreditAPlam != DebitAPlam or CreditSplamt != DebitSplamt) and pLimit.LimitType ='M';


-- Update CreditAccountLimitDetail (ProcessDiff)
Update dbo.CreditAccountLimitDetail 
set Splpaid = Splpaid - (CreditSplamt - DebitSplamt), Splamt = Splamt - (CreditSplamt - DebitSplamt),
	Plpaid = Plpaid - (CreditAPlam - DebitAPlam), Plamt = Plamt - (CreditAPlam - DebitAPlam)
from
    (Select Sum(Acamt) as CreditAcamt, sum(Plamt) as CreditAPlam, sum(Splamt) as CreditSplamt, AccountNumber
    from dbo.CreditAccountLimitDetail
    where Status != 'R' and Dorc = 'C'
    group by AccountNumber) CredittDetail
    inner join (Select Sum(Acamt) as DebitAcamt, sum(Plamt) as DebitAPlam, sum(Splamt) as DebitSplamt, AccountNumber
    from dbo.CreditAccountLimitDetail
    where Status != 'R' and Dorc = 'D'
    group by AccountNumber) DebitDetail
    on CredittDetail.AccountNumber = DebitDetail.AccountNumber
    inner join #ListRepayment list on list.CreditAccountNumber = DebitDetail.AccountNumber
    inner join dbo.CreditAccount acc on list.CreditAccountNumber = acc.AccountNumber
    inner join dbo.CreditSubProductLimit spLimit on spLimit.SubProductLimitCode = acc.SubProductLimitCode
    inner join dbo.CreditProductLimit pLimit on pLimit.ProductLimitCode = spLimit.ProductLimitCode
where CreditAcamt = DebitAcamt and (CreditAPlam != DebitAPlam or CreditSplamt != DebitSplamt) and pLimit.LimitType ='M';

-- Update CreditLimit
insert into CreditAccountLimit
    (AccountNumber, ProductLimitCode, SubProductLimitCode)
select acc.AccountNumber, pLimit.ProductLimitCode, spLimit.SubProductLimitCode
from #ListRepayment list
    inner join dbo.CreditAccount acc on list.CreditAccountNumber = acc.AccountNumber
    inner join dbo.CreditSubProductLimit spLimit on acc.SubProductLimitCode = spLimit.SubProductLimitCode
    inner join dbo.CreditProductLimit pLimit on spLimit.ProductLimitCode = pLimit.ProductLimitCode
    left join CreditAccountLimit accLimit on list.CreditAccountNumber = accLimit.AccountNumber
where accLimit.AccountNumber is null and pLimit.LimitType = 'M';

Update CreditAccountLimit
set Acpaid = accLimit.Acpaid + accLimit.Acamt,
	Splpaid = accLimit.Splpaid + accLimit.Splamt,
	Plpaid = accLimit.Plpaid + accLimit.Plamt
from CreditAccountLimit accLimit inner join #ListRepayment list on list.CreditAccountNumber = accLimit.AccountNumber
    inner join dbo.CreditAccount acc on list.CreditAccountNumber = acc.AccountNumber
    inner join dbo.CreditSubProductLimit spLimit on acc.SubProductLimitCode = spLimit.SubProductLimitCode
    inner join dbo.CreditProductLimit pLimit on spLimit.ProductLimitCode = pLimit.ProductLimitCode
where pLimit.LimitType = 'M';

-- Update creditt Schedule

	DECLARE @AccountNumber VARCHAR(max),
    @DueNumber INT,
    @Amount decimal(24,2),
    @Paid decimal(24,2),
	@DueAmount decimal(24,2);

	DECLARE creditCursor CURSOR
	FOR
	SELECT list.CreditAccountNumber,
		list.ToTalPrincipalAmount
	FROM #ListRepayment list

	OPEN creditCursor;

	FETCH NEXT
	FROM creditCursor
	INTO @AccountNumber,
		@DueAmount;

	WHILE @@FETCH_STATUS = 0
	BEGIN

    -- Phân bổ amount cho schedule type 'P'
    DECLARE scheduleCursor CURSOR
		FOR
		SELECT DueNumber,
        Amount,
        Paid
    FROM CreditSchedule
    where AccountNumber = @AccountNumber and Rptype = 'P' and Amount - Paid > 0
    order by DueNumber;

    OPEN scheduleCursor;

    FETCH NEXT
		FROM scheduleCursor
		INTO @DueNumber,
			@Amount,
			@Paid;

    WHILE @@FETCH_STATUS = 0
		BEGIN
        Update CreditSchedule 
			set Paid = iif(@DueAmount > @Amount - @Paid, @Amount, @Paid + @DueAmount) where AccountNumber = @AccountNumber and DueNumber = @DueNumber and Rptype = 'P';
        select @DueAmount = @DueAmount - iif(@DueAmount > @Amount - @Paid,  @Amount - @Paid, @DueAmount);
        IF @DueAmount = 0
		BEGIN
            BREAK;
        END
        FETCH NEXT
		FROM scheduleCursor
		INTO @DueNumber,
			@Amount,
			@Paid;
    END;
    CLOSE scheduleCursor;
    DEALLOCATE scheduleCursor;

    FETCH NEXT
	FROM creditCursor
	INTO @AccountNumber,
		@DueAmount;

END;
	CLOSE creditCursor;
	DEALLOCATE creditCursor;

-- Create transaction
	EXEC o9deposit.dbo.CREATE_TRANSACTION  
	    @TransactionNumber ,
	    @WorkingDate ,
	    @UserCode ,
	    @UserName ,
	    @BatchDate ,
	    @StepName , 
	    @ReferenceId ,
	    @RefId ,
	    @ReferenceCode ,
	    @TranId ,
	    @Description ,
	    @BusinessCode ,
	    @ChannelID;
-- Update DepositAccount

Update o9deposit.dbo.DepositAccount
set 
	CurrentBalance = dpt.CurrentBalance - TotalAmount,
	WithdrawAmount = dpt.WithdrawAmount + TotalAmount,
	WeekDebit = WeekDebit + TotalAmount,
	MonthDebit = MonthDebit + TotalAmount,
	QuarterDebit = QuarterDebit + TotalAmount,
	SemiAnnualDebit = SemiAnnualDebit + TotalAmount,
	YearDebit = YearDebit + TotalAmount
from o9deposit.dbo.DepositAccount dpt inner join (Select Sum(TotalPrincipalAmount) as TotalAmount, DepositAccountNumber from #ListRepayment group by DepositAccountNumber) listRepayment on dpt.AccountNumber = listRepayment.DepositAccountNumber;

INSERT INTO o9deposit.dbo.DepositHistory
    ([AccountNumber], [ValueDate], [RefId], [TransactionDate], [TransactionCode], [Amount], [Dorc], [Description], [UsrCode], [Oder], [DepositHistoryStatus], [Stcode], [Usrid], [ChannelId])
SELECT
    DepositAccountNumber -- [AccountNumber]
		, @WorkingDate -- [ValueDate]
		, @RefId -- [RefId]
		, GETUTCDATE() -- [TransactionDate]
		, @StepName -- [TransactionCode]
		, ToTalPrincipalAmount -- [Amount]
		, 'D' -- [Dorc]
		, @StepName + ' Principal collection. A/c: [' + CreditAccountNumber + ']'-- [Description]
		, @UserCode -- [UsrCode]
		, 1 -- [Oder]
		, 'N' -- [DepositHistoryStatus] 
		, '-' -- [Stcode]
		, 0 --[Usrid]
		, 'C' -- Core
-- [ChannelId]
From #ListRepayment;

-- Insert deposit statement
Insert into o9deposit.dbo.DepositStatement ([AccountNumber], [StatementDate], [ReferenceId], [ValueDate], [Amount], [CurrencyCode], [ConvertAmount], [StatementCode], [StatementStatus], [RefNumber], [TransCode], [TransactionNumber], [Description], [CreatedOnUtc], [UpdatedOnUtc])
Select
    acc.AccountNumber 
	, GETUTCDATE()
	, @RefId  
	, @WorkingDate  
	, list.ToTalPrincipalAmount  
	, acc.CurrencyCode 
	, list.ToTalPrincipalAmount 
	, 'WDR' -- 'DEP'/'WDR' 
	, 'N' -- [StatementStatus]
	, 0 --[RefNumber]
	, 'DPT_DEBIT_BALANCE' -- [TransCode]
	, @TransactionNumber
	,  @StepName + ' Principal collection. A/c: [' + CreditAccountNumber + ']'-- [Description]
	, GETUTCDATE()
	, GETUTCDATE()
    From #ListRepayment list inner join o9deposit.dbo.DepositAccount acc on list.DepositAccountNumber = acc.AccountNumber;

-- Create DepositAccountTrans
INSERT INTO o9deposit.[dbo].[DepositAccountTrans]
    ([TransId], [TransactionNumber], [DepositAccount], [TransCode], [TransactionStatus], [Amount], [GLPopulated], [CrossBranchCode], [CrossCurrencyCode])
SELECT
    NewID() as [TransId]
	, @TransactionNumber as  [TransactionNumber]
	, DepositAccountNumber as [DepositAccount]
	, 'DPT_DEBIT_BALANCE' as [TransCode] -- 'Debit balance'
	, 'N' as  [TransactionStatus]
	, Round(ToTalPrincipalAmount, 2) as [Amount] -- accrual interest
	, 0 as  [GLPopulated]
	, CreditBranchCode
	, CreditCurrencyCode
FROM #ListRepayment;

-- Create GL entries
exec o9deposit.dbo.GenerateGLEntriesFromDepositAccountTrans
	@TransactionNumber=null;

-- drop temp table
DROP TABLE #ListRepayment;

COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    throw;
END CATCH;
GO


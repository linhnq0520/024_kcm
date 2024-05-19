use o9credit;
    GO

IF OBJECT_ID('[B_CRD_RID_EXEC]', 'P') IS NOT NULL
    BEGIN
    -- The procedure exists
    DROP PROCEDURE B_CRD_RID_EXEC;
END;
    GO

CREATE PROCEDURE [dbo].B_CRD_RID_EXEC
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
    DECLARE @IfcCode int,
        @IfcValue DECIMAL (24, 5),
        @MarginValue DECIMAL (24, 5),
		@IfcAmount DECIMAL(24, 5);

    DECLARE @strSQL NVARCHAR(max);
    DECLARE @strWorkingDate VARCHAR(20) = Convert(VARCHAR(20), @workingdate, 23);
    DECLARE @NumberOfDaysInTheYear VARCHAR(100) = ' ' + dbo.[GET_ACTUAL_DAYS_OF_CURRENT_YEAR]();-- check leap year

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

    -- Get list Repayment (hàm CalculateInterest trong CreditFOService)
    IF OBJECT_ID('tempdb..#ListRepayment') IS NOT NULL DROP TABLE #ListRepayment;
	CREATE TABLE #ListRepayment (DepositAccountNumber NVARCHAR(50)
								, CreditAccountNumber NVARCHAR(50)
								, InterestDue DECIMAL(24, 2)
								, InterestAmount DECIMAL(24, 2)
								, InterestPrepaid DECIMAL(24, 2)
								, InterestOverdue DECIMAL(24, 2)
								, InterestSuspense DECIMAL(24, 2)
								, ClassificationStatus NVARCHAR(50)
								, CreditCurrencyCode NVARCHAR(50)
								, CreditBranchCode NVARCHAR(50)
								, DepositCurrencyCode NVARCHAR(50)
								, DepositBranchCode NVARCHAR(50));

	insert into #ListRepayment
	select
		dptAcc.AccountNumber as DepositAccountNumber
		, crdAcc.AccountNumber as CreditAccountNumber 
        , 0 as InterestDue
        , 0 as InterestAmount
        , 0 as InterestPrepaid
        , 0 as InterestOverdue
        , 0 as InterestSuspense
        , crdAcc.ClassificationStatus as ClassificationStatus
		, crdAcc.CurrencyCode as CreditCurrencyCode
		, crdAcc.BranchCode as CreditBranchCode
		, dptAcc.CurrencyCode as DepositCurrencyCode
		, dptAcc.BranchCode as DepositBranchCode
		from (select * from dbo.CreditAccount where Crdsts in (0, 2, 3) and InterestDue > 0 and CreditFacility != 'OD') crdAcc
		inner join (select * from o9deposit.dbo.AccountLinkage where LinkageType = 'C' and LinkageClass ='A') dptLinkage on dptLinkage.MasterAccountNumber = crdAcc.AccountNumber
		inner join (select AccountNumber, o9deposit.dbo.GetAvailableBalance(AccountNumber, @WorkingDate, 1) as AvailableBalance, CurrencyCode, BranchCode  from o9deposit.dbo.DepositAccount where DepositStatus = 'N' and o9deposit.dbo.GetAvailableBalance(AccountNumber, @WorkingDate, 1) > 0 ) dptAcc on dptAcc.AccountNumber = dptLinkage.LinkageAccountNumber;

	-- Update lại #ListRepayment cho trường hợp Nhiều CRD <--> 1 DPT
	DECLARE @DepositAccountNumber VARCHAR(max),
	@AvailableBalance decimal(24,2);

	DECLARE @CreditAccountNumber VARCHAR(max),
	@CreditInterestDue decimal(24,2),
	@InterestOverdue decimal(24,2),
	@InterestSuspense decimal(24,2);

	DECLARE listRepaymentCursor CURSOR
	FOR
	SELECT DepositAccountNumber,
		o9deposit.dbo.GetAvailableBalance(DepositAccountNumber, @WorkingDate, 1)
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
				Round(acc.InterestDue, 2),
				Round(acc.InterestOverdue, 2),
				Round(acc.InterestSuspense, 2)
		From #ListRepayment list
		inner join CreditAccount acc on list.CreditAccountNumber = acc.AccountNumber
		where DepositAccountNumber = @DepositAccountNumber
		order by CreditAccountNumber;

		OPEN creditAccountCursor;

		FETCH NEXT
			FROM creditAccountCursor
			INTO @CreditAccountNumber,
			@CreditInterestDue,
			@InterestOverdue,
			@InterestSuspense;
		
		WHILE @@FETCH_STATUS = 0

			BEGIN
			Update #ListRepayment 
				set InterestDue =  iif(@AvailableBalance > @CreditInterestDue, @CreditInterestDue, @AvailableBalance),
					InterestOverdue = Round(iif(@InterestOverdue > iif(@AvailableBalance > @CreditInterestDue, @CreditInterestDue, @AvailableBalance), iif(@AvailableBalance > @CreditInterestDue, @CreditInterestDue, @AvailableBalance), @InterestOverdue), 2),
					InterestSuspense = Round(iif(@InterestSuspense > iif(@AvailableBalance > @CreditInterestDue, @CreditInterestDue, @AvailableBalance), iif(@AvailableBalance > @CreditInterestDue, @CreditInterestDue, @AvailableBalance), @InterestSuspense), 2)
			where DepositAccountNumber = @DepositAccountNumber and CreditAccountNumber = @CreditAccountNumber;

			select @AvailableBalance = @AvailableBalance -  iif(@AvailableBalance > @CreditInterestDue, @CreditInterestDue, @AvailableBalance);
			if(@AvailableBalance = 0)
			BEGIN
				BREAK;
			END
			FETCH NEXT
				FROM creditAccountCursor
				INTO @CreditAccountNumber,
					@CreditInterestDue,
					@InterestOverdue,
					@InterestSuspense;
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
	
	Delete from #ListRepayment where InterestDue = 0;
    -- Update creditt Schedule

	DECLARE @AccountNumber VARCHAR(max),
    @DueNumber INT,
    @Amount decimal(24,2),
    @Paid decimal(24,2),
	@DueAmount decimal(24,2);

	DECLARE myCursor CURSOR
	FOR
	SELECT list.CreditAccountNumber,
    list.InterestDue
	FROM #ListRepayment list

		OPEN myCursor;

		FETCH NEXT
		FROM myCursor
		INTO @AccountNumber,
			@DueAmount;

		WHILE @@FETCH_STATUS = 0
		BEGIN

		-- Phân bổ amount cho schedule type 'I'
		DECLARE myCursor1 CURSOR
			FOR
			SELECT DueNumber,
			Amount,
			Paid
		FROM CreditSchedule
		where AccountNumber = @AccountNumber and Rptype = 'I' and Amount - Paid > 0
		order by DueNumber;

		OPEN myCursor1;

		FETCH NEXT
			FROM myCursor1
			INTO @DueNumber,
				@Amount,
				@Paid;

		WHILE @@FETCH_STATUS = 0
			BEGIN
			Update CreditSchedule 
				set Paid = iif(@DueAmount > @Amount - @Paid, @Amount, @Paid + @DueAmount) where AccountNumber = @AccountNumber and DueNumber = @DueNumber and Rptype = 'I';
			select @DueAmount = @DueAmount - iif(@DueAmount > @Amount - @Paid,  @Amount - @Paid, @DueAmount);
			IF @DueAmount = 0
			BEGIN
				BREAK;
			END
			FETCH NEXT
				FROM myCursor1
				INTO @DueNumber,
				@Amount,
				@Paid;
		END;
		CLOSE myCursor1;
		DEALLOCATE myCursor1;

		FETCH NEXT
			FROM myCursor
			INTO @AccountNumber,
			@DueAmount;

	END;
	CLOSE myCursor;
	DEALLOCATE myCursor;

    -- Update CreditAccount
    Update dbo.CreditAccount
    set 
        InterestDue = iif(listRepayment.InterestDue > 0, acc.InterestDue - listRepayment.InterestDue, acc.InterestDue),
        InterestAmount = iif(listRepayment.InterestAmount > 0, acc.InterestAmount - listRepayment.InterestAmount, acc.InterestAmount),
        InterestOverdue = iif(listRepayment.InterestOverdue > 0, acc.InterestOverdue - listRepayment.InterestOverdue, acc.InterestOverdue),
        InterestPrepaid = iif(listRepayment.InterestPrepaid > 0, acc.InterestPrepaid + listRepayment.InterestPrepaid, acc.InterestPrepaid),
        InterestPaid = iif(listRepayment.InterestDue + listRepayment.InterestAmount != 0, acc.InterestPaid + listRepayment.InterestDue + listRepayment.InterestAmount - listRepayment.InterestPrepaid, acc.InterestPaid),
        InterestPayable = iif(listRepayment.InterestDue + listRepayment.InterestAmount != 0, acc.InterestPayable - listRepayment.InterestDue - listRepayment.InterestAmount, acc.InterestPayable),
        InterestSuspense = iif(listRepayment.InterestSuspense > 0, acc.InterestSuspense + listRepayment.InterestSuspense, acc.InterestSuspense)
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
    InterestDue, --Amount
    'C', --Dorc
    @StepName + ' Interest collection. A/c: [' + CreditAccountNumber + ']', -- [Description] --Description
    @UserCode, --@UserCode: UserCreated
    'N', --Status
    null, --@UserCode: UserApprove
    @TransactionNumber, -- TransactionNumber
    @ChannelID
from #ListRepayment;

    -- Update CreditClassification if has data
    Update dbo.CreditClassification 
    set Clsclr = case when listRepayment.InterestDue > 0 and class.ClassificationType = 'N' then class.Clsclr + listRepayment.InterestDue when  listRepayment.InterestOverdue > 0 and class.ClassificationType = 'O' then class.Clsclr + listRepayment.InterestOverdue else class.Clsclr end 
        from dbo.CreditClassification class
    inner join dbo.CreditAccount acc on class.AccountNumber = acc.AccountNumber
    inner join #ListRepayment listRepayment on acc.AccountNumber = listRepayment.CreditAccountNumber
        where class.Rptype ='I';

    -- Insert CreditClasification if has no data
    Insert into dbo.CreditClassification
    (AccountNumber, ClassificationAmount, Clsclr, ClassificationType, Rptype, Ord)
select
    AccountNumber as AccountNumber
        , 0 as ClassificationAmount
        , 0 as Clsclr
        , 'N'
        , 'I' as Rptype
        , 1 as Ord
from
    (select
        listRepayment.CreditAccountNumber as AccountNumber 
        , listRepayment.InterestDue as InterestDue
        , class.ClassificationAmount as ClassificationAmount
    from #ListRepayment listRepayment
        left join dbo.CreditClassification class on class.AccountNumber = listRepayment.CreditAccountNumber and Rptype = 'I' and ClassificationType = 'N') a
where ClassificationAmount is null and InterestDue > 0;

    Insert into dbo.CreditClassification
    (AccountNumber, ClassificationAmount, Clsclr, ClassificationType, Rptype, Ord)
select
    AccountNumber as AccountNumber
        , 0 as ClassificationAmount
        , 0 as Clsclr
        , 'O'
        , 'I' as Rptype
        , 1 as Ord
from
    (select
        listRepayment.CreditAccountNumber as AccountNumber 
        , listRepayment.InterestOverdue as InterestOverdue
        , class.ClassificationAmount as ClassificationAmount
    from #ListRepayment listRepayment
        left join dbo.CreditClassification class on class.AccountNumber = listRepayment.CreditAccountNumber and Rptype = 'I' and ClassificationType = 'O') a
where ClassificationAmount is null and InterestOverdue > 0;

	-- Insert Ifc balance detail

	DECLARE @CreditAccount VARCHAR(max),
	@InterestDue decimal(24,2),
	@CreditBalance decimal(24,2);

	DECLARE creditAccountCursor CURSOR
	FOR
	SELECT list.CreditAccountNumber,
    list.InterestDue,
	account.Balance
	FROM #ListRepayment list inner join CreditAccount account on list.CreditAccountNumber = account.AccountNumber

		OPEN creditAccountCursor;

		FETCH NEXT
		FROM creditAccountCursor
		INTO @CreditAccount,
			@InterestDue,
			@CreditBalance;

		WHILE @@FETCH_STATUS = 0
		BEGIN

		-- Phân bổ due amount cho từng ifcbalance
		DECLARE ifcBalCursor CURSOR
			FOR
			SELECT bal.IfcCode,
				bal.IfcValue,
				bal.MarginValue,
				bal.Amount
		FROM CreditIFCBalance bal inner join  CreditIFCDefinition def on bal.IfcCode = def.IfcCode
		where bal.AccountNumber = @CreditAccount and def.IfcType = 'I' and def.IfcStatus = 'N' and bal.Amount != 0
		order by bal.IfcCode;

		OPEN ifcBalCursor;

		FETCH NEXT
			FROM ifcBalCursor
			INTO @IfcCode,
				@IfcValue,
				@MarginValue,
				@IfcAmount;
		WHILE @@FETCH_STATUS = 0
			BEGIN
			INSERT INTO CreditIFCBalanceDetail([ModuleCode], [AccountNumber], [IfcCode], [IfcValue], [Balance], [FromDate], [ToDate], [Action], [Amount], [ReferenceId], [IFCBalanceDetailDescription])
			SELECT
				'CRD' as [ModuleCode]
				, @CreditAccount as [AccountNumber]
				, @IfcCode as [IfcCode]
				, @IfcValue + @MarginValue as [IfcValue]
				, @CreditBalance as [Balance]
				, @WorkingDate as [FromDate]
				, @WorkingDate as [ToDate]
				, 'D'
				, iif(@InterestDue > Round(@IfcAmount, 2), Round(@IfcAmount, 2), @InterestDue)
				, @TransactionNumber  as [ReferenceId]
				, @StepName as [IFCBalanceDetailDescription];

			select @InterestDue = @InterestDue - iif(@InterestDue > Round(@IfcAmount, 2), Round(@IfcAmount, 2), @InterestDue);
			IF @InterestDue = 0
			BEGIN
				BREAK;
			END
			FETCH NEXT
				FROM ifcBalCursor
				INTO @IfcCode,
				@IfcValue,
				@MarginValue,
				@IfcAmount;
		END;
		CLOSE ifcBalCursor;
		DEALLOCATE ifcBalCursor;

		FETCH NEXT
			FROM creditAccountCursor
			INTO @CreditAccount,
			@InterestDue,
			@CreditBalance;

	END;
	CLOSE creditAccountCursor;
	DEALLOCATE creditAccountCursor;
 
    -- Update IFCBalance
    UPDATE CreditIFCBalance
    SET Amount = ifcbal.Amount - ifcbaldetails.Amount, Amtpbl = ifcbal.Amtpbl - ifcbaldetails.Amount, Paid = ifcbal.Paid + ifcbaldetails.Amount
    FROM CreditIFCBalance ifcbal
    INNER JOIN CreditIFCBalanceDetail ifcbaldetails
    ON ifcbal.AccountNumber = ifcbaldetails.AccountNumber
        AND ifcbal.IfcCode = ifcbaldetails.IfcCode
    WHERE ifcbaldetails.ReferenceId = @TransactionNumber;


    -- Inser CreditIfcBalanceTrans
    INSERT INTO [dbo].[CreditIFCBalanceTrans]
    ([TransId], [TransactionNumber], [CreditAccount], [IFCCode], [TransCode], [ClassificationStatus], [TransactionStatus], [Amount], [GLPopulated], [CrossBranchCode], [CrossCurrencyCode], [BaseCurrencyAmount])
SELECT
    NewID() as [TransId]
        , @TransactionNumber as  [TransactionNumber]
        , list.CreditAccountNumber as [CreditAccount]
        , ifcbaldetail.[IFCCode] as [IFCCode]
        , 'DEBIT_INTEREST' as [TransCode] 
        , list.ClassificationStatus as  [CurrentClassificationStatus]
        , 'N' as  [TransactionStatus]
        , round(ifcbaldetail.Amount, 2) as [Amount] 
        , 0 as  [GLPopulated]
        , list.DepositBranchCode as  [CrossBranchCode]
        , list.DepositCurrencyCode as  [CrossCurrencyCode]
        , 0 as  [BaseCurrencyAmount]
FROM [CreditIFCBalanceDetail] ifcbaldetail
    inner join #ListRepayment list on ifcbaldetail.AccountNumber = list.CreditAccountNumber
    inner join [CreditIFCDefinition] def on ifcbaldetail.IFCCode = def.IfcCode and def.IfcType = 'I'
Where  ifcbaldetail.ReferenceId = @TransactionNumber

    INSERT INTO [dbo].[CreditIFCBalanceTrans]
    ([TransId], [TransactionNumber], [CreditAccount], [IFCCode], [TransCode], [ClassificationStatus], [TransactionStatus], [Amount], [GLPopulated], [CrossBranchCode], [CrossCurrencyCode], [BaseCurrencyAmount])
SELECT
    NewID() as [TransId]
        , @TransactionNumber as  [TransactionNumber]
        , list.CreditAccountNumber as [CreditAccount]
        , ifcbaldetail.[IFCCode] as [IFCCode]
        , 'CREDIT_PAID' as [TransCode] 
        , list.ClassificationStatus as  [CurrentClassificationStatus]
        , 'N' as  [TransactionStatus]
        , round(Amount, 2) as [Amount]
        , 0 as  [GLPopulated]
         , list.DepositBranchCode as  [CrossBranchCode]
        , list.DepositCurrencyCode as  [CrossCurrencyCode]
        , 0 as  [BaseCurrencyAmount]
FROM [CreditIFCBalanceDetail] ifcbaldetail
    inner join #ListRepayment list on ifcbaldetail.AccountNumber = list.CreditAccountNumber
    inner join [CreditIFCDefinition] def on ifcbaldetail.IFCCode = def.IfcCode and def.IfcType = 'I'
where ifcbaldetail.ReferenceId = @TransactionNumber and list.ClassificationStatus in ('D', 'L');

    -- Create GL entries
    exec dbo.GenerateGLEntriesFromCreditIFCBalanceTrans
        @TransactionNumber=null;

    -- Deposit
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
        CurrentBalance = dpt.CurrentBalance - listRepayment.SumInterestDue,
        WithdrawAmount = dpt.WithdrawAmount + listRepayment.SumInterestDue,
        WeekDebit = WeekDebit + listRepayment.SumInterestDue,
        MonthDebit = MonthDebit + listRepayment.SumInterestDue,
        QuarterDebit = QuarterDebit + listRepayment.SumInterestDue,
        SemiAnnualDebit = SemiAnnualDebit + listRepayment.SumInterestDue,
        YearDebit = YearDebit + listRepayment.SumInterestDue
    from o9deposit.dbo.DepositAccount dpt inner join (select Sum(InterestDue) as SumInterestDue, DepositAccountNumber from #ListRepayment group by DepositAccountNumber) listRepayment on dpt.AccountNumber = listRepayment.DepositAccountNumber;
	
	-- Insert Deposit history
    INSERT INTO o9deposit.dbo.DepositHistory
    ([AccountNumber], [ValueDate], [RefId], [TransactionDate], [TransactionCode], [Amount], [Dorc], [Description], [UsrCode], [Oder], [DepositHistoryStatus], [Stcode], [Usrid], [ChannelId])
SELECT
    DepositAccountNumber -- [AccountNumber]
            , @WorkingDate -- [ValueDate]
            , @RefId -- [RefId]
            , GETUTCDATE() -- [TransactionDate]
            , @StepName -- [TransactionCode]
            , InterestDue -- [Amount]
            , 'D' -- [Dorc]
            , @StepName + ' Interest collection. A/c: [' + CreditAccountNumber + ']'-- [Description]
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
			, list.InterestDue  
			, acc.CurrencyCode 
			, list.InterestDue 
			, 'WDR' -- 'DEP'/'WDR' 
			, 'N' -- [StatementStatus]
			, 0 --[RefNumber]
			, 'DPT_DEBIT_BALANCE' -- [TransCode]
			, @TransactionNumber
			, @StepName + ' Interest collection. A/c: [' + list.CreditAccountNumber + ']' -- [Description]
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
        , 'DPT_DEBIT_BALANCE' as [TransCode] 
        , 'N' as  [TransactionStatus]
        , Round(InterestDue, 2) as [Amount]
        , 0 as  [GLPopulated]
		, CreditBranchCode as [CrossBranchCode]
        , CreditCurrencyCode as [CrossCurrencyCode]
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


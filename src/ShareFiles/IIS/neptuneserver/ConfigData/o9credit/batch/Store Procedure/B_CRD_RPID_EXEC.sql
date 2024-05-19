use o9credit;
    GO

IF OBJECT_ID('[B_CRD_RPID_EXEC]', 'P') IS NOT NULL
    BEGIN
    -- The procedure exists
    DROP PROCEDURE B_CRD_RPID_EXEC;
END;
    GO

CREATE PROCEDURE [dbo].B_CRD_RPID_EXEC
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
    DECLARE @strSQL NVARCHAR(max);
    DECLARE @strWorkingDate VARCHAR(20) = Convert(VARCHAR(20), @workingdate, 23);

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

	-- Select list DPT account to update 
	IF OBJECT_ID('tempdb..#ListDpt') IS NOT NULL DROP TABLE #ListDpt;
	
	CREATE TABLE #ListDpt (DepositAccountNumber NVARCHAR(50)
								, IfcCode INT
								, IfcBalanceAmount DECIMAL(24, 2)
								, AvailableBalance DECIMAL(24, 2)
								, Amount DECIMAL(24, 2)
								, CreditAccountNumber NVARCHAR(50)
								, CreditBranchCode NVARCHAR(50)
								, CreditCurrencyCode NVARCHAR(50)
								, CreditClassificationStatus NVARCHAR(50)
								, DepositBranchCode NVARCHAR(50)
								, DepositCurrencyCode NVARCHAR(50));
	Insert into #ListDpt
		select
			dptAcc.AccountNumber as DepositAccountNumber
			, ifcbalance.IfcCode as IfcCode
			, Round(ifcbalance.Amount, 2) as IfcBalanceAmount
			, dptAcc.AvailableBalance as AvailableBalance
			, 0 as [Amount] 
			, acc.AccountNumber as CreditAccountNumber
			, acc.BranchCode as CreditBranchCode
			, acc.CurrencyCode as CreditCurrencyCode
			, acc.ClassificationStatus as CreditClassificationStatus
			, dptAcc.BranchCode as DepositBranchCode
			, dptAcc.CurrencyCode as DepositCurrencyCode
		From (select * from dbo.CreditAccount where Crdsts in (0, 2, 3) and CreditFacility != 'OD') acc 
		inner join (select * from dbo.CreditIFCBalance where Amount > 0) ifcbalance on acc.AccountNumber = ifcbalance.AccountNumber
		inner join (select * from dbo.CreditIFCDefinition where IfcType = 'F' and IfcSubType = 'PI') ifcDef on ifcbalance.IfcCode =  ifcDef.IfcCode
		inner join (select * from o9deposit.dbo.AccountLinkage where LinkageType = 'C' and LinkageClass ='A' ) dptLinkage on dptLinkage.MasterAccountNumber = acc.AccountNumber
		inner join (select *, o9deposit.dbo.GetAvailableBalance(AccountNumber, @WorkingDate, 1) as AvailableBalance from o9deposit.dbo.DepositAccount  where DepositStatus = 'N' and o9deposit.dbo.GetAvailableBalance
	(AccountNumber, @WorkingDate, 1) > 0) dptAcc on dptAcc.AccountNumber = dptLinkage.LinkageAccountNumber;


	-- Update ListDpt
	DECLARE @DepositAccount VARCHAR(max),
	@AvailableBalance decimal(24,5);

	DECLARE @CreditAccount VARCHAR(max),
	@IfcBalanceAmount decimal(24,5),
	@IfcCode INT;

	DECLARE listDPTCursor CURSOR
	FOR
	SELECT DepositAccountNumber,
		AvailableBalance
	FROM #ListDpt ;

		OPEN listDPTCursor;

		FETCH NEXT
		FROM listDPTCursor
		INTO @DepositAccount,
			@AvailableBalance;

		WHILE @@FETCH_STATUS = 0
		BEGIN

		-- Phân bổ due amount cho từng ifcbalance
		DECLARE creditIFCBalanceCursor CURSOR
			FOR
			SELECT CreditAccountNumber,
				IfcCode,
				IfcBalanceAmount
		From #ListDpt
		where DepositAccountNumber = @DepositAccount
		order by CreditAccountNumber;

		OPEN creditIFCBalanceCursor;

		FETCH NEXT
			FROM creditIFCBalanceCursor
			INTO @CreditAccount,
				@IfcCode,
				@IfcBalanceAmount;
		
		WHILE @@FETCH_STATUS = 0
			BEGIN
			Update #ListDpt set Amount =  iif(@AvailableBalance > @IfcBalanceAmount, @IfcBalanceAmount, @AvailableBalance) where DepositAccountNumber = @DepositAccount and CreditAccountNumber = @CreditAccount and IfcCode = @IfcCode;
			select @AvailableBalance = @AvailableBalance -  Round(iif(@AvailableBalance > @IfcBalanceAmount, @IfcBalanceAmount, @AvailableBalance), 5);
			if(@AvailableBalance = 0)
			BEGIN
				BREAK;
			END
			FETCH NEXT
				FROM creditIFCBalanceCursor
				INTO @CreditAccount,
					@IfcCode,
					@IfcBalanceAmount;
		END;
		CLOSE creditIFCBalanceCursor;
		DEALLOCATE creditIFCBalanceCursor;

		FETCH NEXT
			FROM listDPTCursor
			INTO @DepositAccount,
			@AvailableBalance;

	END;
	CLOSE listDPTCursor;
	DEALLOCATE listDPTCursor;

	DELETE FROM #ListDpt WHERE Round(Amount, 2) = 0;

	-- Insert into CreditIFCBalanceDetail
	INSERT INTO CreditIFCBalanceDetail
    ([ModuleCode], [AccountNumber], [IfcCode], [IfcValue], [Balance], [FromDate], [ToDate], [Action], [Amount], [ReferenceId], [IFCBalanceDetailDescription])
	SELECT *
	FROM (
		select
		'CRD' as [ModuleCode]
		, account.AccountNumber as [AccountNumber]
		, bal.IfcCode as [IfcCode]
		, bal.IfcValue +  bal.MarginValue as [IfcValue]
		, Balance as [Balance]
		, @strWorkingDate as [FromDate]
		, @strWorkingDate as [ToDate]
		, 'D' as [Action]
		, Round(list.Amount, 2) as [Amount]
		, REPLACE(@TransactionNumber, '''', '''''') as [ReferenceId]
		, REPLACE(@StepName, '''', '''''') as [IFCBalanceDetailDescription]
		From #ListDpt list inner join CreditIFCBalance bal on list.CreditAccountNumber = bal.AccountNumber and list.IfcCode = bal.IfcCode
			inner join CreditAccount account on account.AccountNumber = list.CreditAccountNumber
			 ) a
	WHERE amount <> 0;

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
	SELECT AccountNumber, --DefAccountNumber
		GETUTCDATE(), --TransactionDate
		@RefId, --TransactionRefId
		@WorkingDate, --ValueDate
		@StepName, --TransactionCode
		Amount, --Amount
		'D', --Dorc
		@StepName + ' Penalty interest collection. A/c: [' + AccountNumber + ']', -- [Description] --Description
		@UserCode, --@UserCode: UserCreated
		'N', --Status
		null, --@UserCode: UserApprove
		@TransactionNumber, -- TransactionNumber
		@ChannelID
	from CreditIFCBalanceDetail detail
	where ReferenceId = @TransactionNumber;		 
	
    -- Update IFCBalance
    UPDATE CreditIFCBalance
    SET Amount = ifcbal.Amount - ifcbaldetails.Amount, Amtpbl = ifcbal.Amtpbl - ifcbaldetails.Amount, Paid = ifcbal.Paid + ifcbaldetails.Amount
    FROM CreditIFCBalance ifcbal
    INNER JOIN CreditIFCBalanceDetail ifcbaldetails
    ON ifcbal.AccountNumber = ifcbaldetails.AccountNumber
        AND ifcbal.IfcCode = ifcbaldetails.IfcCode
    WHERE ifcbaldetails.ReferenceId = @TransactionNumber;

    -- Insert CreditIfcBalanceTrans
    INSERT INTO [dbo].[CreditIFCBalanceTrans]
    ([TransId], [TransactionNumber], [CreditAccount], [IFCCode], [TransCode], [ClassificationStatus], [TransactionStatus], [Amount], [GLPopulated], [CrossBranchCode], [CrossCurrencyCode], [BaseCurrencyAmount])
	SELECT
		NewID() as [TransId]
			, @TransactionNumber as  [TransactionNumber]
			, list.CreditAccountNumber as [CreditAccount]
			, ifcbaldetail.[IFCCode] as [IFCCode]
			, 'DEBIT_PENALTY_INT' as [TransCode] 
			, list.CreditClassificationStatus as  [CurrentClassificationStatus]
			, 'N' as  [TransactionStatus]
			, ifcbaldetail.Amount as [Amount] 
			, 0 as  [GLPopulated]
			, list.DepositBranchCode as  [CrossBranchCode]
			, list.DepositCurrencyCode as  [CrossCurrencyCode]
			, 0 as  [BaseCurrencyAmount]
	FROM [CreditIFCBalanceDetail] ifcbaldetail
		inner join #ListDpt list on list.CreditAccountNumber = ifcbaldetail.AccountNumber and list.IfcCode = ifcbaldetail.IfcCode
	Where  ifcbaldetail.ReferenceId = @TransactionNumber

    INSERT INTO [dbo].[CreditIFCBalanceTrans]
    ([TransId], [TransactionNumber], [CreditAccount], [IFCCode], [TransCode], [ClassificationStatus], [TransactionStatus], [Amount], [GLPopulated], [CrossBranchCode], [CrossCurrencyCode], [BaseCurrencyAmount])
	SELECT
		NewID() as [TransId]
			, @TransactionNumber as  [TransactionNumber]
			, list.CreditAccountNumber as [CreditAccount]
			, ifcbaldetail.[IFCCode] as [IFCCode]
			, 'CREDIT_PAID_PENALTY_INT' as [TransCode]
			, list.CreditClassificationStatus as  [CurrentClassificationStatus]
			, 'N' as  [TransactionStatus]
			, ifcbaldetail.Amount as [Amount] 
			, 0 as  [GLPopulated]
			, list.DepositBranchCode as  [CrossBranchCode]
			, list.DepositCurrencyCode as  [CrossCurrencyCode]
			, 0 as  [BaseCurrencyAmount]
	FROM [CreditIFCBalanceDetail] ifcbaldetail
		inner join #ListDpt list on list.CreditAccountNumber = ifcbaldetail.AccountNumber and list.IfcCode = ifcbaldetail.IfcCode
	where ifcbaldetail.ReferenceId = @TransactionNumber and list.CreditClassificationStatus in ('D', 'L');

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
        CurrentBalance = acc.CurrentBalance - list.SumAmount,
        WithdrawAmount = acc.WithdrawAmount + list.SumAmount,
        WeekDebit = acc.WeekDebit + list.SumAmount,
        MonthDebit = acc.MonthDebit + list.SumAmount,
        QuarterDebit = acc.QuarterDebit + list.SumAmount,
        SemiAnnualDebit = acc.SemiAnnualDebit + list.SumAmount,
        YearDebit = acc.YearDebit + list.SumAmount
	From (select sum(Round(Amount, 2)) as SumAmount, DepositAccountNumber as DepositAccountNumber from #ListDpt group by DepositAccountNumber) list inner join o9deposit.dbo.DepositAccount acc on list.DepositAccountNumber = acc.AccountNumber;

	-- Insert deposit statement
	 Insert into o9deposit.dbo.DepositStatement ([AccountNumber], [StatementDate], [ReferenceId], [ValueDate], [Amount], [CurrencyCode], [ConvertAmount], [StatementCode], [StatementStatus], [RefNumber], [TransCode], [TransactionNumber], [Description], [CreatedOnUtc], [UpdatedOnUtc])
		Select
           acc.AccountNumber 
			, GETUTCDATE()
			, @RefId  
			, @WorkingDate  
			, list.Amount  
			, acc.CurrencyCode 
			, list.Amount 
			, 'WDR' -- 'DEP'/'WDR' 
			, 'N' -- [StatementStatus]
			, 0 --[RefNumber]
			, 'DPT_DEBIT_BALANCE' -- [TransCode]
			, @TransactionNumber
			, @StepName + ' Penalty interest collection. A/c: [' + CreditAccountNumber + ']'-- [Description]
			, GETUTCDATE()
			, GETUTCDATE()
         From #ListDpt list inner join o9deposit.dbo.DepositAccount acc on list.DepositAccountNumber = acc.AccountNumber;

	-- Insert DepositHistory
    INSERT INTO o9deposit.dbo.DepositHistory
    ([AccountNumber], [ValueDate], [RefId], [TransactionDate], [TransactionCode], [Amount], [Dorc], [Description], [UsrCode], [Oder], [DepositHistoryStatus], [Stcode], [Usrid], [ChannelId])
	SELECT
		DepositAccountNumber -- [AccountNumber]
		, @WorkingDate -- [ValueDate]
		, @RefId -- [RefId]
		, GETUTCDATE() -- [TransactionDate]
		, @StepName -- [TransactionCode]
		, Amount -- [Amount]
		, 'D' -- [Dorc]
		, @StepName + ' Penalty interest collection. A/c: [' + CreditAccountNumber + ']'-- [Description]
		, @UserCode -- [UsrCode]
		, 1 -- [Oder]
		, 'N' -- [DepositHistoryStatus] 
		, '-' -- [Stcode]
		, 0 --[Usrid]
		, 'C' -- [ChannelId] Core
	From #ListDpt;

    -- Create DepositAccountTrans
    INSERT INTO o9deposit.[dbo].[DepositAccountTrans]
    ([TransId], [TransactionNumber], [DepositAccount], [TransCode], [TransactionStatus], [Amount], [GLPopulated], [CrossBranchCode], [CrossCurrencyCode])
	SELECT
		NewID() as [TransId]
			, @TransactionNumber as  [TransactionNumber]
			, DepositAccountNumber as [DepositAccount]
			, 'DPT_DEBIT_BALANCE' as [TransCode]
			, 'N' as  [TransactionStatus]
			, Amount as [Amount] 
			, 0 as  [GLPopulated]
			, list.CreditBranchCode
			, list.CreditCurrencyCode
	FROM #ListDpt list;

    -- Create GL entries
    exec o9deposit.dbo.GenerateGLEntriesFromDepositAccountTrans
        @TransactionNumber=null;

    -- drop temp table
    DROP TABLE #ListDpt;

COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    throw;
END CATCH;
GO


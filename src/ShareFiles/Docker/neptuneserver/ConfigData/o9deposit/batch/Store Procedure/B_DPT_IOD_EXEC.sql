use o9deposit;
GO

IF OBJECT_ID('[B_DPT_IOD_EXEC]', 'P') IS NOT NULL
BEGIN
    -- The procedure exists
    DROP PROCEDURE [B_DPT_IOD_EXEC]
;
END;
GO

CREATE PROCEDURE  [dbo].[B_DPT_IOD_EXEC]
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
DECLARE @StartTime DATE = GETUTCDATE();
DECLARE @BatchStepName VARCHAR(100) = @StepName;

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

-- Main processing code here
DECLARE @strSQL NVARCHAR(max) = '';
DECLARE @strWorkingDate VARCHAR(20) = Convert(VARCHAR(20), @workingdate, 23);
Declare @eom bit = case when EOMONTH(@WorkingDate) = @WorkingDate  then 1
						when  EOMONTH(@WorkingDate) !=  @WorkingDate then 0 end;
Declare @eoq bit = case when DATEADD(d, -1, DATEADD(q, DATEDIFF(q, 0, @WorkingDate) + 1, 0)) = @WorkingDate then 1
						when  DATEADD(d, -1, DATEADD(q, DATEDIFF(q, 0, @WorkingDate) + 1, 0)) !=  @WorkingDate then 0 end;

-- Insert Paid interest into IFCBalanceDetail
if @eom = 1 -- OD with InterestDueMode = 'MONTH'
begin
    SET @strSQL = '';
    -- clear strSQL
    SET @strSQL = ' DECLARE @WorkingDate DATE = ''' + convert(varchar(100), @WorkingDate, 23) + ''';';
    SET @strSQL = @strSQL + ' INSERT INTO ODContractIFCBalanceDetail([ModuleCode], [ContractNumber], [IfcCode], [IfcValue], [Balance], [FromDate], [ToDate], [Action], [Amount], [ReferenceId], [IFCBalanceDetailDescription])';
    SET @strSQL = @strSQL + ' SELECT * FROM (';
    SET @strSQL = @strSQL + ' select ';
    SET @strSQL = @strSQL + ' 	''OD'' as [ModuleCode]';
    SET @strSQL = @strSQL + ' 	, contract.ContractNumber as [ContractNumber]';
    SET @strSQL = @strSQL + ' 	, ifcbalance.IfcCode as [IfcCode]';
    SET @strSQL = @strSQL + ' 	, ifcbalance.IfcValue +  ifcbalance.MarginValue as [IfcValue]';
    SET @strSQL = @strSQL + ' 	, case when IfcType = ''I'' then dbo.GetOverDraftBalance(contract.AccountNumber) 
										when IfcType = ''F'' and IfcSubType = ''FC'' then dbo.GetUnUseBalance(contract.AccountNumber) 
										when IfcType = ''F'' and IfcSubType = ''PP'' then iif(dbo.GetOverDraftBalance(contract.AccountNumber) > OdLimit, OdLimit, dbo.GetOverDraftBalance(contract.AccountNumber))
										when IfcType = ''F'' and IfcSubType = ''PI'' then iif(dbo.GetOverDraftBalance(contract.AccountNumber) > OdLimit, dbo.GetOverDraftBalance(contract.AccountNumber) - OdLimit, 0) end as [Balance]';
    SET @strSQL = @strSQL + ' 	, ''' + @strWorkingDate + ''' as [FromDate]';
    SET @strSQL = @strSQL + ' 	, ''' + @strWorkingDate + ''' as [ToDate]';
    SET @strSQL = @strSQL + ' 	, ''P'' as [Action]';
    SET @strSQL = @strSQL + ' 	, round(ifcbalance.Amount, 2) as [Amount]';
    SET @strSQL = @strSQL + ' 	, ''' + REPLACE(@TransactionNumber, '''', '''''') + ''' as [ReferenceId]';
    SET @strSQL = @strSQL + ' 	, ''' + REPLACE(@BatchStepName, '''', '''''') + ''' as [IFCBalanceDetailDescription]';
    SET @strSQL = @strSQL + ' from dbo.OverdraftContract contract';
    SET @strSQL = @strSQL + ' inner join dbo.ODContractIFCBalance ifcbalance';
    SET @strSQL = @strSQL + ' 	on contract.ContractNumber = ifcbalance.ContractNumber';
    SET @strSQL = @strSQL + ' inner join dbo.DepositIFCDefinition ifcDef';
    SET @strSQL = @strSQL + ' 	on ifcDef.IfcCode = ifcbalance.IfcCode';
    SET @strSQL = @strSQL + ' inner join dbo.DepositAccount acc';
    SET @strSQL = @strSQL + ' 	on contract.AccountNumber = acc.AccountNumber';
    SET @strSQL = @strSQL + ' where (contract.ContractStatus = 0 or contract.ContractStatus = 2)';
    SET @strSQL = @strSQL + ' and (contract.InterestDueMode =''M''';
    SET @strSQL = @strSQL + ' or (contract.ToDate = @WorkingDate and contract.ToDate != DATEADD(d, -1, DATEADD(q, DATEDIFF(q, 0, @WorkingDate) + 1, 0))))';
    SET @strSQL = @strSQL + ' and ifcbalance.IfcBalanceStatus = ''N''';
    SET @strSQL = @strSQL + ' and acc.DepositStatus = ''N''';
    SET @strSQL = @strSQL + ' ) a WHERE amount <> 0';

    SET @strSQL = @strSQL + ' INSERT INTO ODContractIFCBalanceDetail([ModuleCode], [ContractNumber], [IfcCode], [IfcValue], [Balance], [FromDate], [ToDate], [Action], [Amount], [ReferenceId], [IFCBalanceDetailDescription])';
    SET @strSQL = @strSQL + ' SELECT * FROM (';
    SET @strSQL = @strSQL + ' select ';
    SET @strSQL = @strSQL + ' 	''OD'' as [ModuleCode]';
    SET @strSQL = @strSQL + ' 	, contract.ContractNumber as [ContractNumber]';
    SET @strSQL = @strSQL + ' 	, ifcbalance.IfcCode as [IfcCode]';
    SET @strSQL = @strSQL + ' 	, ifcbalance.IfcValue +  ifcbalance.MarginValue as [IfcValue]';
    SET @strSQL = @strSQL + ' 	, case when IfcType = ''I'' then dbo.GetOverDraftBalance(contract.AccountNumber) 
										when IfcType = ''F'' and IfcSubType = ''FC'' then dbo.GetUnUseBalance(contract.AccountNumber) 
										when IfcType = ''F'' and IfcSubType = ''PP'' then iif(dbo.GetOverDraftBalance(contract.AccountNumber) > OdLimit, OdLimit, dbo.GetOverDraftBalance(contract.AccountNumber))
										when IfcType = ''F'' and IfcSubType = ''PI'' then iif(dbo.GetOverDraftBalance(contract.AccountNumber) > OdLimit, dbo.GetOverDraftBalance(contract.AccountNumber) - OdLimit, 0) end as [Balance]';
    SET @strSQL = @strSQL + ' 	, ''' + @strWorkingDate + ''' as [FromDate]';
    SET @strSQL = @strSQL + ' 	, ''' + @strWorkingDate + ''' as [ToDate]';
    SET @strSQL = @strSQL + ' 	, ''A'' as [Action]';
    SET @strSQL = @strSQL + ' 	, round(ifcbalance.Amount, 2) - ifcbalance.Amount as [Amount]';
    SET @strSQL = @strSQL + ' 	, ''' + REPLACE(@TransactionNumber, '''', '''''') + ''' as [ReferenceId]';
    SET @strSQL = @strSQL + ' 	, ''' + REPLACE(@BatchStepName, '''', '''''') + ''' as [IFCBalanceDetailDescription]';
    SET @strSQL = @strSQL + ' from dbo.OverdraftContract contract';
    SET @strSQL = @strSQL + ' inner join dbo.ODContractIFCBalance ifcbalance';
    SET @strSQL = @strSQL + ' 	on contract.ContractNumber = ifcbalance.ContractNumber';
    SET @strSQL = @strSQL + ' inner join dbo.DepositIFCDefinition ifcDef';
    SET @strSQL = @strSQL + ' 	on ifcDef.IfcCode = ifcbalance.IfcCode';
    SET @strSQL = @strSQL + ' inner join dbo.DepositAccount acc';
    SET @strSQL = @strSQL + ' 	on contract.AccountNumber = acc.AccountNumber';
    SET @strSQL = @strSQL + ' where (contract.ContractStatus = 0 or contract.ContractStatus = 2)';
    SET @strSQL = @strSQL + ' and (contract.InterestDueMode =''M''';
    SET @strSQL = @strSQL + ' or (contract.ToDate = @WorkingDate and contract.ToDate != DATEADD(d, -1, DATEADD(q, DATEDIFF(q, 0, @WorkingDate) + 1, 0))))';
    SET @strSQL = @strSQL + ' and ifcbalance.IfcBalanceStatus = ''N''';
    SET @strSQL = @strSQL + ' and acc.DepositStatus = ''N''';
    SET @strSQL = @strSQL + ' ) a WHERE amount <> 0';

    PRINT @strSQL;
    EXEC (@strSQL);
end

IF  @eoq = 1 -- OD with InterestDueMode = 'QUARTER'
begin
    SET @strSQL = '';
    -- clear strSQL
    SET @strSQL = ' DECLARE @WorkingDate DATE = ''' + convert(varchar(100), @WorkingDate, 23) + ''';';
    SET @strSQL = @strSQL + ' INSERT INTO ODContractIFCBalanceDetail([ModuleCode], [ContractNumber], [IfcCode], [IfcValue], [Balance], [FromDate], [ToDate], [Action], [Amount], [ReferenceId], [IFCBalanceDetailDescription])';
    SET @strSQL = @strSQL + ' SELECT * FROM (';
    SET @strSQL = @strSQL + ' select ';
    SET @strSQL = @strSQL + ' 	''OD'' as [ModuleCode]';
    SET @strSQL = @strSQL + ' 	, contract.ContractNumber as [ContractNumber]';
    SET @strSQL = @strSQL + ' 	, ifcbalance.IfcCode as [IfcCode]';
    SET @strSQL = @strSQL + ' 	, ifcbalance.IfcValue +  ifcbalance.MarginValue as [IfcValue]';
    SET @strSQL = @strSQL + ' 	, case when IfcType = ''I'' then dbo.GetOverDraftBalance(contract.AccountNumber) 
										when IfcType = ''F'' and IfcSubType = ''FC'' then dbo.GetUnUseBalance(contract.AccountNumber) 
										when IfcType = ''F'' and IfcSubType = ''PP'' then iif(dbo.GetOverDraftBalance(contract.AccountNumber) > OdLimit, OdLimit, dbo.GetOverDraftBalance(contract.AccountNumber))
										when IfcType = ''F'' and IfcSubType = ''PI'' then iif(dbo.GetOverDraftBalance(contract.AccountNumber) > OdLimit, dbo.GetOverDraftBalance(contract.AccountNumber) - OdLimit, 0) end as [Balance]';
    SET @strSQL = @strSQL + ' 	, ''' + @strWorkingDate + ''' as [FromDate]';
    SET @strSQL = @strSQL + ' 	, ''' + @strWorkingDate + ''' as [ToDate]';
    SET @strSQL = @strSQL + ' 	, ''P'' as [Action]';
    SET @strSQL = @strSQL + ' 	, round(ifcbalance.Amount, 2) as [Amount]';
    SET @strSQL = @strSQL + ' 	, ''' + REPLACE(@TransactionNumber, '''', '''''') + ''' as [ReferenceId]';
    SET @strSQL = @strSQL + ' 	, ''' + REPLACE(@BatchStepName, '''', '''''') + ''' as [IFCBalanceDetailDescription]';
    SET @strSQL = @strSQL + ' from dbo.OverdraftContract contract';
    SET @strSQL = @strSQL + ' inner join dbo.ODContractIFCBalance ifcbalance';
    SET @strSQL = @strSQL + ' 	on contract.ContractNumber = ifcbalance.ContractNumber';
    SET @strSQL = @strSQL + ' inner join dbo.DepositIFCDefinition ifcDef';
    SET @strSQL = @strSQL + ' 	on ifcDef.IfcCode = ifcbalance.IfcCode';
    SET @strSQL = @strSQL + ' inner join dbo.DepositAccount acc';
    SET @strSQL = @strSQL + ' 	on contract.AccountNumber = acc.AccountNumber';
    SET @strSQL = @strSQL + ' where (contract.ContractStatus = 0 or contract.ContractStatus = 2)';
    SET @strSQL = @strSQL + ' and contract.InterestDueMode =''Q''';
    SET @strSQL = @strSQL + ' and ifcbalance.IfcBalanceStatus = ''N''';
    SET @strSQL = @strSQL + ' and acc.DepositStatus = ''N''';
    SET @strSQL = @strSQL + ' ) a WHERE amount <> 0';

    SET @strSQL = @strSQL + ' INSERT INTO ODContractIFCBalanceDetail([ModuleCode], [ContractNumber], [IfcCode], [IfcValue], [Balance], [FromDate], [ToDate], [Action], [Amount], [ReferenceId], [IFCBalanceDetailDescription])';
    SET @strSQL = @strSQL + ' SELECT * FROM (';
    SET @strSQL = @strSQL + ' select ';
    SET @strSQL = @strSQL + ' 	''OD'' as [ModuleCode]';
    SET @strSQL = @strSQL + ' 	, contract.ContractNumber as [ContractNumber]';
    SET @strSQL = @strSQL + ' 	, ifcbalance.IfcCode as [IfcCode]';
    SET @strSQL = @strSQL + ' 	, ifcbalance.IfcValue +  ifcbalance.MarginValue as [IfcValue]';
    SET @strSQL = @strSQL + ' 	,case when IfcType = ''I'' then dbo.GetOverDraftBalance(contract.AccountNumber) 
										when IfcType = ''F'' and IfcSubType = ''FC'' then dbo.GetUnUseBalance(contract.AccountNumber) 
										when IfcType = ''F'' and IfcSubType = ''PP'' then iif(dbo.GetOverDraftBalance(contract.AccountNumber) > OdLimit, OdLimit, dbo.GetOverDraftBalance(contract.AccountNumber))
										when IfcType = ''F'' and IfcSubType = ''PI'' then iif(dbo.GetOverDraftBalance(contract.AccountNumber) > OdLimit, dbo.GetOverDraftBalance(contract.AccountNumber) - OdLimit, 0) end as [Balance]';
    SET @strSQL = @strSQL + ' 	, ''' + @strWorkingDate + ''' as [FromDate]';
    SET @strSQL = @strSQL + ' 	, ''' + @strWorkingDate + ''' as [ToDate]';
    SET @strSQL = @strSQL + ' 	, ''A'' as [Action]';
    SET @strSQL = @strSQL + ' 	, round(ifcbalance.Amount, 2) - ifcbalance.Amount as [Amount]';
    SET @strSQL = @strSQL + ' 	, ''' + REPLACE(@TransactionNumber, '''', '''''') + ''' as [ReferenceId]';
    SET @strSQL = @strSQL + ' 	, ''' + REPLACE(@BatchStepName, '''', '''''') + ''' as [IFCBalanceDetailDescription]';
    SET @strSQL = @strSQL + ' from dbo.OverdraftContract contract';
    SET @strSQL = @strSQL + ' inner join dbo.ODContractIFCBalance ifcbalance';
    SET @strSQL = @strSQL + ' 	on contract.ContractNumber = ifcbalance.ContractNumber';
    SET @strSQL = @strSQL + ' inner join dbo.DepositIFCDefinition ifcDef';
    SET @strSQL = @strSQL + ' 	on ifcDef.IfcCode = ifcbalance.IfcCode';
    SET @strSQL = @strSQL + ' inner join dbo.DepositAccount acc';
    SET @strSQL = @strSQL + ' 	on contract.AccountNumber = acc.AccountNumber';
    SET @strSQL = @strSQL + ' where (contract.ContractStatus = 0 or contract.ContractStatus = 2)';
    SET @strSQL = @strSQL + ' and contract.InterestDueMode =''Q''';
    SET @strSQL = @strSQL + ' and ifcbalance.IfcBalanceStatus = ''N''';
    SET @strSQL = @strSQL + ' and acc.DepositStatus = ''N''';
    SET @strSQL = @strSQL + ' ) a WHERE amount <> 0';

    PRINT @strSQL;
    EXEC (@strSQL);
end

IF  @eom = 0 and @eoq =0  -- Normal day Get OD contract to duedate 
begin
    SET @strSQL = '';
    -- clear strSQL
    SET @strSQL = ' DECLARE @WorkingDate DATE = ''' + convert(varchar(100), @WorkingDate, 23) + ''';';
    SET @strSQL = @strSQL + ' INSERT INTO ODContractIFCBalanceDetail([ModuleCode], [ContractNumber], [IfcCode], [IfcValue], [Balance], [FromDate], [ToDate], [Action], [Amount], [ReferenceId], [IFCBalanceDetailDescription])';
    SET @strSQL = @strSQL + ' SELECT * FROM (';
    SET @strSQL = @strSQL + ' select ';
    SET @strSQL = @strSQL + ' 	''OD'' as [ModuleCode]';
    SET @strSQL = @strSQL + ' 	, contract.ContractNumber as [ContractNumber]';
    SET @strSQL = @strSQL + ' 	, ifcbalance.IfcCode as [IfcCode]';
    SET @strSQL = @strSQL + ' 	, ifcbalance.IfcValue +  ifcbalance.MarginValue as [IfcValue]';
    SET @strSQL = @strSQL + ' 	, case when IfcType = ''I'' then dbo.GetOverDraftBalance(contract.AccountNumber) 
										when IfcType = ''F'' and IfcSubType = ''FC'' then dbo.GetUnUseBalance(contract.AccountNumber) 
										when IfcType = ''F'' and IfcSubType = ''PP'' then iif(dbo.GetOverDraftBalance(contract.AccountNumber) > OdLimit, OdLimit, dbo.GetOverDraftBalance(contract.AccountNumber))
										when IfcType = ''F'' and IfcSubType = ''PI'' then iif(dbo.GetOverDraftBalance(contract.AccountNumber) > OdLimit, dbo.GetOverDraftBalance(contract.AccountNumber) - OdLimit, 0) end as [Balance]';
    SET @strSQL = @strSQL + ' 	, ''' + @strWorkingDate + ''' as [FromDate]';
    SET @strSQL = @strSQL + ' 	, ''' + @strWorkingDate + ''' as [ToDate]';
    SET @strSQL = @strSQL + ' 	, ''P'' as [Action]';
    SET @strSQL = @strSQL + ' 	, round(ifcbalance.Amount, 2) as [Amount]';
    SET @strSQL = @strSQL + ' 	, ''' + REPLACE(@TransactionNumber, '''', '''''') + ''' as [ReferenceId]';
    SET @strSQL = @strSQL + ' 	, ''' + REPLACE(@BatchStepName, '''', '''''') + ''' as [IFCBalanceDetailDescription]';
    SET @strSQL = @strSQL + ' from dbo.OverdraftContract contract';
    SET @strSQL = @strSQL + ' inner join dbo.ODContractIFCBalance ifcbalance';
    SET @strSQL = @strSQL + ' 	on contract.ContractNumber = ifcbalance.ContractNumber';
    SET @strSQL = @strSQL + ' inner join dbo.DepositIFCDefinition ifcDef';
    SET @strSQL = @strSQL + ' 	on ifcDef.IfcCode = ifcbalance.IfcCode';
    SET @strSQL = @strSQL + ' inner join dbo.DepositAccount acc';
    SET @strSQL = @strSQL + ' 	on contract.AccountNumber = acc.AccountNumber';
    SET @strSQL = @strSQL + ' where (contract.ContractStatus = 0 or contract.ContractStatus = 2)';
    SET @strSQL = @strSQL + ' and contract.ToDate = @WorkingDate';
    SET @strSQL = @strSQL + ' and ifcbalance.IfcBalanceStatus = ''N''';
    SET @strSQL = @strSQL + ' and acc.DepositStatus = ''N''';
    SET @strSQL = @strSQL + ' ) a WHERE amount <> 0';

    SET @strSQL = @strSQL + ' INSERT INTO ODContractIFCBalanceDetail([ModuleCode], [ContractNumber], [IfcCode], [IfcValue], [Balance], [FromDate], [ToDate], [Action], [Amount], [ReferenceId], [IFCBalanceDetailDescription])';
    SET @strSQL = @strSQL + ' SELECT * FROM (';
    SET @strSQL = @strSQL + ' select ';
    SET @strSQL = @strSQL + ' 	''OD'' as [ModuleCode]';
    SET @strSQL = @strSQL + ' 	, contract.ContractNumber as [ContractNumber]';
    SET @strSQL = @strSQL + ' 	, ifcbalance.IfcCode as [IfcCode]';
    SET @strSQL = @strSQL + ' 	, ifcbalance.IfcValue +  ifcbalance.MarginValue as [IfcValue]';
    SET @strSQL = @strSQL + ' 	, case when IfcType = ''I'' then dbo.GetOverDraftBalance(contract.AccountNumber) 
										when IfcType = ''F'' and IfcSubType = ''FC'' then dbo.GetUnUseBalance(contract.AccountNumber) 
										when IfcType = ''F'' and IfcSubType = ''PP'' then iif(dbo.GetOverDraftBalance(contract.AccountNumber) > OdLimit, OdLimit, dbo.GetOverDraftBalance(contract.AccountNumber))
										when IfcType = ''F'' and IfcSubType = ''PI'' then iif(dbo.GetOverDraftBalance(contract.AccountNumber) > OdLimit, dbo.GetOverDraftBalance(contract.AccountNumber) - OdLimit, 0) end as [Balance]';
    SET @strSQL = @strSQL + ' 	, ''' + @strWorkingDate + ''' as [FromDate]';
    SET @strSQL = @strSQL + ' 	, ''' + @strWorkingDate + ''' as [ToDate]';
    SET @strSQL = @strSQL + ' 	, ''A'' as [Action]';
    SET @strSQL = @strSQL + ' 	, round(ifcbalance.Amount, 2) - ifcbalance.Amount as [Amount]';
    SET @strSQL = @strSQL + ' 	, ''' + REPLACE(@TransactionNumber, '''', '''''') + ''' as [ReferenceId]';
    SET @strSQL = @strSQL + ' 	, ''' + REPLACE(@BatchStepName, '''', '''''') + ''' as [IFCBalanceDetailDescription]';
    SET @strSQL = @strSQL + ' from dbo.OverdraftContract contract';
    SET @strSQL = @strSQL + ' inner join dbo.ODContractIFCBalance ifcbalance';
    SET @strSQL = @strSQL + ' 	on contract.ContractNumber = ifcbalance.ContractNumber';
    SET @strSQL = @strSQL + ' inner join dbo.DepositIFCDefinition ifcDef';
    SET @strSQL = @strSQL + ' 	on ifcDef.IfcCode = ifcbalance.IfcCode';
    SET @strSQL = @strSQL + ' inner join dbo.DepositAccount acc';
    SET @strSQL = @strSQL + ' 	on contract.AccountNumber = acc.AccountNumber';
    SET @strSQL = @strSQL + ' where (contract.ContractStatus = 0 or contract.ContractStatus = 2)';
    SET @strSQL = @strSQL + ' and contract.ToDate = @WorkingDate';
    SET @strSQL = @strSQL + ' and ifcbalance.IfcBalanceStatus = ''N''';
    SET @strSQL = @strSQL + ' and acc.DepositStatus = ''N''';
    SET @strSQL = @strSQL + ' ) a WHERE amount <> 0';

    PRINT @strSQL;
    EXEC (@strSQL);
end

IF  @eom = 0 and @eoq =0  -- Normal day Get OD contract over due date anh have positive balance 
begin
    -- Select bảng tạm chứa OD contract quá due date và có balance dương
    IF OBJECT_ID('tempdb..#ListOdContract') IS NOT NULL DROP TABLE #ListOdContract;
    CREATE TABLE #ListOdContract
    (
        ContractNumber NVARCHAR(50)
								,
        IfcCode INT
								,
        DepositAccountNumber NVARCHAR(50)
								,
        IfcBalanceAmount DECIMAL(24, 2)
								,
        PositiveAmount DECIMAL(24, 2)
								,
        Amount DECIMAL(24, 2)
    );

    insert into #ListOdContract
    select
        contract.ContractNumber as ContractNumber
		, ifcbalance.IfcCode
		, contract.AccountNumber as DepositAccountNumber 
        , Round(ifcbalance.Amount, 2) as IfcBalanceAmount
        , account.PositiveAmount as PositiveAmount
		, 0 as Amount
    From dbo.OverdraftContract contract
        inner join (select *
        from dbo.ODContractIFCBalance
        where Amount > 0) ifcbalance on contract.ContractNumber = ifcbalance.ContractNumber
        inner join(select dbo.GetPositiveBalance(AccountNumber) as PositiveAmount, AccountNumber
        from DepositAccount
        where DepositStatus = 'N' and CurrentBalance > 0) account on contract.AccountNumber = account.AccountNumber
    Where (contract.ContractStatus = 0 or contract.ContractStatus = 2) -- Normal
        and contract.ToDate < @WorkingDate -- after maturity date
        and account.PositiveAmount > 0
    -- Update lại ListOdContract, phân bổ positive amount của Deposit account trả cho từng IFC balance

    DECLARE @DepositAccountNumber VARCHAR(max),
	@PositiveBalance decimal(24,2);

    DECLARE @ContractNumber VARCHAR(max),
	@IfcCode INT,
	@IfcBalanceAmount decimal(24,2);

    DECLARE listOdContractCursor CURSOR
	FOR
	SELECT DepositAccountNumber,
        PositiveAmount
    FROM #ListOdContract
    ;

    OPEN listOdContractCursor;

    FETCH NEXT
		FROM listOdContractCursor
		INTO @DepositAccountNumber,
			@PositiveBalance;

    WHILE @@FETCH_STATUS = 0
		BEGIN

        -- Phân bổ lại available balance cho từng CreditAccount
        DECLARE ifcBalanceCursor CURSOR
		FOR
		SELECT ContractNumber,
            IfcCode,
            IfcBalanceAmount
        From #ListOdContract list
        where DepositAccountNumber = @DepositAccountNumber
        order by IfcCode Desc;

        OPEN ifcBalanceCursor;

        FETCH NEXT
			FROM ifcBalanceCursor
			INTO @ContractNumber,
			@IfcCode,
			@IfcBalanceAmount;

        WHILE @@FETCH_STATUS = 0

			BEGIN
            Update #ListOdContract 
				set Amount =  iif(@PositiveBalance > @IfcBalanceAmount, @IfcBalanceAmount, @PositiveBalance)
			where DepositAccountNumber = @DepositAccountNumber and ContractNumber = @ContractNumber and IfcCode = @IfcCode;

            select @PositiveBalance = @PositiveBalance -  iif(@PositiveBalance > @IfcBalanceAmount, @IfcBalanceAmount, @PositiveBalance);
            if(@PositiveBalance = 0)
			BEGIN
                BREAK;
            END
            FETCH NEXT
				FROM ifcBalanceCursor
				INTO @ContractNumber,
					@IfcCode,
					@IfcBalanceAmount;
        END;
        CLOSE ifcBalanceCursor;
        DEALLOCATE ifcBalanceCursor;

        FETCH NEXT
			FROM listOdContractCursor
			INTO @DepositAccountNumber,
				@PositiveBalance;

    END;
    CLOSE listOdContractCursor;
    DEALLOCATE listOdContractCursor;

    Delete from #ListOdContract where Amount = 0;

    -- Insert ODContractIFCBalanceDetail 
    INSERT INTO ODContractIFCBalanceDetail
        ([ModuleCode], [ContractNumber], [IfcCode], [IfcValue], [Balance], [FromDate], [ToDate], [Action], [Amount], [ReferenceId], [IFCBalanceDetailDescription])
    SELECT *
    FROM (
    select
            'OD' as [ModuleCode]
    , list.ContractNumber as [ContractNumber]
    , bal.IfcCode as [IfcCode]
    , bal.IfcValue +  bal.MarginValue as [IfcValue]
    , case when IfcType = 'I' then dbo.GetOverDraftBalance(list.DepositAccountNumber) 
		when IfcType = 'F' and IfcSubType = 'FC' then dbo.GetUnUseBalance(list.DepositAccountNumber) 
		when IfcType = 'F' and IfcSubType = 'PP' then iif(dbo.GetOverDraftBalance(list.DepositAccountNumber) > OdLimit, OdLimit, dbo.GetOverDraftBalance(list.DepositAccountNumber))
		when IfcType = 'F' and IfcSubType = 'PI' then iif(dbo.GetOverDraftBalance(list.DepositAccountNumber) > OdLimit, dbo.GetOverDraftBalance(list.DepositAccountNumber) - OdLimit, 0) end as [Balance]
    , @strWorkingDate as [FromDate]
    , @strWorkingDate as [ToDate]
    , 'P' as [Action]
    , list.Amount as [Amount]
    , REPLACE(@TransactionNumber, '''', '''''') as [ReferenceId]
    , REPLACE(@BatchStepName, '''', '''''') as [IFCBalanceDetailDescription]
        From #ListOdContract list inner join ODContractIFCBalance bal on list.ContractNumber = bal.ContractNumber and list.IfcCode = bal.IfcCode
            inner join DepositIFCDefinition def on def.IfcCode = bal.IfcCode
            inner join OverdraftContract contract on contract.ContractNumber = list.ContractNumber) a
    WHERE amount <> 0;

    -- Adjust IFCBalance
    INSERT INTO ODContractIFCBalanceDetail
        ([ModuleCode], [ContractNumber], [IfcCode], [IfcValue], [Balance], [FromDate], [ToDate], [Action], [Amount], [ReferenceId], [IFCBalanceDetailDescription])
    SELECT *
    FROM (
    select
            'OD' as [ModuleCode]
    , list.ContractNumber as [ContractNumber]
    , bal.IfcCode as [IfcCode]
    , bal.IfcValue +  bal.MarginValue as [IfcValue]
    , case when IfcType = 'I' then dbo.GetOverDraftBalance(list.DepositAccountNumber) 
		when IfcType = 'F' and IfcSubType = 'FC' then dbo.GetUnUseBalance(list.DepositAccountNumber) 
		when IfcType = 'F' and IfcSubType = 'PP' then iif(dbo.GetOverDraftBalance(list.DepositAccountNumber) > OdLimit, OdLimit, dbo.GetOverDraftBalance(list.DepositAccountNumber))
		when IfcType = 'F' and IfcSubType = 'PI' then iif(dbo.GetOverDraftBalance(list.DepositAccountNumber) > OdLimit, dbo.GetOverDraftBalance(list.DepositAccountNumber) - OdLimit, 0) end as [Balance]
    , @strWorkingDate as [FromDate]
    , @strWorkingDate as [ToDate]
    , 'A' as [Action]
    , iif(list.Amount - Round(bal.Amount, 2) = 0, list.Amount - bal.Amount, 0) as [Amount]
    , REPLACE(@TransactionNumber, '''', '''''') as [ReferenceId]
    , REPLACE(@BatchStepName, '''', '''''') as [IFCBalanceDetailDescription]
        From #ListOdContract list inner join ODContractIFCBalance bal on list.ContractNumber = bal.ContractNumber and list.IfcCode = bal.IfcCode
            inner join DepositIFCDefinition ifcDef on ifcDef.IfcCode = bal.IfcCode
            inner join OverDraftContract contract on contract.ContractNumber = bal.ContractNumber) a
    WHERE amount <> 0;

end

-- Dự thu bù
INSERT INTO [dbo].[ODContractIFCBalanceTrans]
    ([TransId], [TransactionNumber], [ODContract], [IFCCode], [TransCode], [ClassificationStatus], [TransactionStatus], [Amount], [GLPopulated], [CrossBranchCode], [CrossCurrencyCode], [BaseCurrencyAmount], [GLGroup])
select *
from(
SELECT
        NewID() as [TransId]
	, @TransactionNumber as  [TransactionNumber]
	, contract.ContractNumber as [ODContract]
	, ifcbal.[IFCCode] as [IFCCode]
	, (case when ifcDef.IfcType ='F' and ifcDef.IfcSubType = 'PP' then 'DEBIT_PENALTY_PRIN_NO_UPDATE'
             when ifcDef.IfcType ='F' and ifcDef.IfcSubType = 'PI' then 'DEBIT_PENALTY_INT_NO_UPDATE'
             end) as [TransCode] -- 'OD_IFC_IACR' or 'OD_IFC_FACR'
	, contract.ClassificationStatus as  [CurrentClassificationStatus]
	, 'N' as  [TransactionStatus]
	, iif(ifcbaldetail.Amount - ifcbal.Amtpbl > 0,ifcbaldetail.Amount - ifcbal.Amtpbl, 0)  as [Amount] -- accrual interest
	, 0 as  [GLPopulated]
	, null as  [CrossBranchCode]
	, null as  [CrossCurrencyCode]
	, 0 as  [BaseCurrencyAmount]
	, 1 as [GLGroup]
    FROM ODContractIFCBalance ifcbal
        inner join OverDraftContract contract on ifcbal.ContractNumber=contract.ContractNumber and (contract.ContractStatus = 0 or contract.ContractStatus = 2) -- == Normal/block
        inner join DepositIFCDefinition ifcDef on ifcbal.IfcCode = ifcDef.IfcCode
        inner join ODContractIFCBalanceDetail ifcbaldetail on ifcbal.ContractNumber = ifcbaldetail.ContractNumber and ifcbal.IfcCode = ifcbaldetail.IfcCode
    WHERE ifcbal.IfcBalanceStatus = 'N'
        and (contract.ContractStatus = 0 or contract.ContractStatus = 2)-- == Normal 
        and ifcbaldetail.ReferenceId = @TransactionNumber
        and ifcbaldetail.Action = 'P') a
where Amount != 0;

-- Update Amtpbl sau khi dự thu

UPDATE ODContractIFCBalance
SET Amtpbl = Amtpbl + iif(ifcbaldetail.Amount - ifcbal.Amtpbl > 0, ifcbaldetail.Amount - ifcbal.Amtpbl, 0)
FROM ODContractIFCBalance ifcbal
    inner join OverDraftContract contract on ifcbal.ContractNumber=contract.ContractNumber and (contract.ContractStatus = 0 or contract.ContractStatus = 2) -- == Normal/block
    inner join DepositIFCDefinition ifcDef on ifcbal.IfcCode = ifcDef.IfcCode
    inner join ODContractIFCBalanceDetail ifcbaldetail on ifcbal.ContractNumber = ifcbaldetail.ContractNumber and ifcbal.IfcCode = ifcbaldetail.IfcCode
WHERE ifcbal.IfcBalanceStatus = 'N'
    and (contract.ContractStatus = 0 or contract.ContractStatus = 2)-- == Normal 
    and ifcbaldetail.ReferenceId = @TransactionNumber
    and ifcbaldetail.Action = 'P'


-- Update IFCBalance.Amount, IFCBalance.Paid 
UPDATE ODContractIFCBalance
SET Paid = Paid + Round(ifcbaldetails.Amount, 2) , Amount = ifcbal.Amount - ifcbaldetails.Amount, Amtpbl = Amtpbl - Round(ifcbaldetails.Amount, 2)
FROM ODContractIFCBalance ifcbal
    INNER JOIN (select sum(case when Action = 'P' then Amount when Action ='A' then -Amount end) Amount, count(ContractNumber) Count, ContractNumber, ReferenceId, IfcCode
    from ODContractIFCBalanceDetail
    where ReferenceId = @TransactionNumber
    group by ContractNumber, ReferenceId, IfcCode) ifcbaldetails on ifcbal.IfcCode = ifcbaldetails.IfcCode and ifcbal.ContractNumber = ifcbaldetails.ContractNumber

-- Create ODContractIFCBalanceTrans
INSERT INTO [dbo].[ODContractIFCBalanceTrans]
    ([TransId], [TransactionNumber], [ODContract], [IFCCode], [TransCode], [ClassificationStatus], [TransactionStatus], [Amount], [GLPopulated], [CrossBranchCode], [CrossCurrencyCode], [BaseCurrencyAmount], [GLGroup])
SELECT
    NewID() as [TransId]
	, @TransactionNumber as  [TransactionNumber]
	, contract.ContractNumber as [ODContract]
	, ifcbal.[IFCCode] as [IFCCode]
	, (case when ifcDef.IfcType ='I' then 'OD_IFC_IPAY'
             when ifcDef.IfcType ='F' and ifcDef.IfcSubType ='FC' then 'OD_IFC_FPAY'
			 when ifcDef.IfcType ='F' and ifcDef.IfcSubType ='PI' then 'DEBIT_PENALTY_INT'
			 when ifcDef.IfcType ='F' and ifcDef.IfcSubType ='PP' then 'DEBIT_PENALTY_PRIN'
             end) as [TransCode] -- 'OD_IFC_IACR' or 'OD_IFC_FACR'
	, contract.ClassificationStatus as  [CurrentClassificationStatus]
	, 'N' as  [TransactionStatus]
	, round(ifcbaldetail.Amount, 2) as [Amount] -- accrual interest
	, 0 as  [GLPopulated]
	, null as  [CrossBranchCode]
	, null as  [CrossCurrencyCode]
	, 0 as  [BaseCurrencyAmount]
	, 1 as [GLGroup]
FROM ODContractIFCBalance ifcbal
    inner join OverDraftContract contract on ifcbal.ContractNumber=contract.ContractNumber and (contract.ContractStatus = 0 or contract.ContractStatus = 2) -- == Normal/block
    inner join DepositIFCDefinition ifcDef on ifcbal.IfcCode = ifcDef.IfcCode
    inner join ODContractIFCBalanceDetail ifcbaldetail on ifcbal.ContractNumber = ifcbaldetail.ContractNumber and ifcbal.IfcCode = ifcbaldetail.IfcCode
WHERE ifcbal.IfcBalanceStatus = 'N'
    and (contract.ContractStatus = 0 or contract.ContractStatus = 2)-- == Normal 
    and ifcbaldetail.ReferenceId = @TransactionNumber
    and ifcbaldetail.Action = 'P';

-- If Classification status in ('D', 'L'), add action OD_IFC_IACR_REVERSE and OD_IFC_FACR_REVERSE
INSERT INTO [dbo].[ODContractIFCBalanceTrans]
    ([TransId], [TransactionNumber], [ODContract], [IFCCode], [TransCode], [ClassificationStatus], [TransactionStatus], [Amount], [GLPopulated], [CrossBranchCode], [CrossCurrencyCode], [BaseCurrencyAmount], [GLGroup])
SELECT
    NewID() as [TransId]
	, @TransactionNumber as  [TransactionNumber]
	, contract.ContractNumber as [ODContract]
	, ifcbal.[IFCCode] as [IFCCode]
	, (case when ifcDef.IfcType ='I' then 'OD_PAID_INTEREST'
             when ifcDef.IfcType ='F' and ifcDef.IfcSubType ='FC' then 'OD_PAID_COMMITMENT'
			 when ifcDef.IfcType ='F' and ifcDef.IfcSubType ='PI' then 'CREDIT_PAID_PENALTY_INT'
			 when ifcDef.IfcType ='F' and ifcDef.IfcSubType ='PP' then 'CREDIT_PAID_PENALTY_PRIN'
             end) as [TransCode] -- 'OD_PAID_INTEREST' or 'OD_PAID_COMMITMENT'
	, contract.ClassificationStatus as  [CurrentClassificationStatus]
	, 'N' as  [TransactionStatus]
	, round(ifcbaldetail.Amount, 2) as [Amount] -- accrual interest
	, 0 as  [GLPopulated]
	, null as  [CrossBranchCode]
	, null as  [CrossCurrencyCode]
	, 0 as  [BaseCurrencyAmount]
	, 1 as [GLGroup]
FROM ODContractIFCBalance ifcbal
    inner join OverDraftContract contract on ifcbal.ContractNumber=contract.ContractNumber and (contract.ContractStatus = 0 or contract.ContractStatus = 2) -- == Normal/block
    inner join DepositIFCDefinition ifcDef on ifcbal.IfcCode = ifcDef.IfcCode
    inner join ODContractIFCBalanceDetail ifcbaldetail on ifcbal.ContractNumber = ifcbaldetail.ContractNumber and ifcbal.IfcCode = ifcbaldetail.IfcCode
WHERE ifcbal.IfcBalanceStatus = 'N'
    and (contract.ContractStatus = 0 or contract.ContractStatus = 2)-- == Normal 
    and contract.ClassificationStatus in ('D', 'L')
    and ifcbaldetail.ReferenceId = @TransactionNumber
    and ifcbaldetail.Action = 'P';

-- Create GL entries
exec dbo.GenerateGLEntriesFromODContractIFCBalanceTrans
	@TransactionNumber=null;

-- update DepositAccount 
UPDATE DepositAccount
set CurrentBalance  = account.CurrentBalance - ifcbaldetail.Amount
from DepositAccount account
    inner join [OverdraftContract]  contract on account.AccountNumber  = contract.AccountNumber
    inner join (select sum(Round(Amount,2)) Amount, count(ContractNumber) Count, ContractNumber, ReferenceId
    from ODContractIFCBalanceDetail where Action = 'P'
    group by ContractNumber, ReferenceId) ifcbaldetail on contract.ContractNumber  = ifcbaldetail.ContractNumber
where ifcbaldetail.ReferenceId = @TransactionNumber;

-- Insert into DepositStatement

Insert into DepositStatement ([AccountNumber], [StatementDate], [ReferenceId], [ValueDate], [Amount], [CurrencyCode], [ConvertAmount], [StatementCode], [StatementStatus], 
            [RefNumber], [TransCode], [TransactionNumber] , [Description], [CreatedOnUtc], [UpdatedOnUtc])
Select 
        account.AccountNumber -- [AccountNumber]
        , GETUTCDATE()
        , @RefId  
		, @WorkingDate -- [ValueDate]
        , Round(ifcbaldetail.Amount, 2) -- [Amount]
        , account.CurrencyCode
        , Round(ifcbaldetail.Amount, 2) -- [ConvertAmount]
        , 'WDR' -- 'DEP'/'WDR' 
        , 'N' -- [StatementStatus]
        , NULL --[RefNumber]
        , 'DPT_DEBIT_BALANCE' -- [TransactionCode]
        , @TransactionNumber
        , case when ifcDef.IfcType = 'I' then @StepName + ': Interest repayment for OD contract of account [' + account.AccountNumber + ']' 
                    when ifcDef.IfcType = 'F' and IfcSubType = 'FC' then @StepName + ': CommitmentFee repayment for OD contract of account [' + account.AccountNumber + ']'
                    when ifcDef.IfcType = 'F' and IfcSubType = 'PI' then @StepName + ': Penalty interest repayment for OD contract of account [' + account.AccountNumber + ']' 
                    when ifcDef.IfcType = 'F' and IfcSubType = 'PP' then @StepName + ': Penalty principal repayment for OD contract of account [' + account.AccountNumber + ']' end-- [Description]
        , GETUTCDATE()
        , GETUTCDATE()
    From DepositAccount account
    inner join [OverdraftContract]  contract on account.AccountNumber  = contract.AccountNumber
    inner join ODContractIFCBalanceDetail ifcbaldetail on contract.ContractNumber  = ifcbaldetail.ContractNumber
    inner join DepositIFCDefinition ifcDef on ifcDef.IfcCode = ifcbaldetail.IfcCode
where ifcbaldetail.ReferenceId = @TransactionNumber and ifcbaldetail.Action = 'P';


-- Insert into Deposit History
INSERT INTO DepositHistory
    ([AccountNumber], [ValueDate], [RefId], [TransactionDate], [TransactionCode], [Amount], [Dorc], [Description], [UsrCode], [Oder], [DepositHistoryStatus], [Stcode], [Usrid], [ChannelId])
SELECT
    account.AccountNumber -- [AccountNumber]
		, @WorkingDate -- [ValueDate]
		, @RefId -- [RefId]
		, CONVERT(DATE,  GETDATE()) -- [TransactionDate]
		, @StepName -- [TransactionCode]
		, Round(ifcbaldetail.Amount, 2) -- [Amount]
		, 'D' -- [Dorc]
		, case when ifcDef.IfcType = 'I' then @StepName + ': Interest repayment for OD contract of account [' + account.AccountNumber + ']' 
			when ifcDef.IfcType = 'F' and IfcSubType = 'FC' then @StepName + ': CommitmentFee repayment for OD contract of account [' + account.AccountNumber + ']'
			when ifcDef.IfcType = 'F' and IfcSubType = 'PI' then @StepName + ': Penalty interest repayment for OD contract of account [' + account.AccountNumber + ']' 
			when ifcDef.IfcType = 'F' and IfcSubType = 'PP' then @StepName + ': Penalty principal repayment for OD contract of account [' + account.AccountNumber + ']' end-- [Description]
		, @UserCode -- [UsrCode]
		, 1 -- [Oder]
		, 'N' -- [DepositHistoryStatus] 
		, '-' -- [Stcode]
		, 0 --[Usrid]
		, @ChannelID
-- [ChannelId]
From DepositAccount account
    inner join [OverdraftContract]  contract on account.AccountNumber  = contract.AccountNumber
    inner join ODContractIFCBalanceDetail ifcbaldetail on contract.ContractNumber  = ifcbaldetail.ContractNumber
    inner join DepositIFCDefinition ifcDef on ifcDef.IfcCode = ifcbaldetail.IfcCode
where ifcbaldetail.ReferenceId = @TransactionNumber and ifcbaldetail.Action = 'P';


-- Create DepositAccountTrans
INSERT INTO [dbo].[DepositAccountTrans]
    ([TransId], [TransactionNumber], [DepositAccount], [TransCode], [TransactionStatus], [Amount], [GLPopulated], [GLGroup])
SELECT
    NewID() as [TransId]
	, @TransactionNumber as  [TransactionNumber]
	, contract.AccountNumber as [DepositAccount]
	, 'DPT_DEBIT_BALANCE' as [TransCode] -- 'Debit balance'
	, 'N' as  [TransactionStatus]
	, round(ifcbaldetail.Amount, 2) as [Amount] -- accrual interest
	, 0 as  [GLPopulated]
	, 1 as [GLGroup]
FROM OverDraftContract contract
    inner join (select sum(Round(Amount, 2)) Amount, count(ContractNumber) Count, ContractNumber, ReferenceId
    from ODContractIFCBalanceDetail where Action = 'P'
    group by ContractNumber, ReferenceId) ifcbaldetail on contract.ContractNumber  = ifcbaldetail.ContractNumber
    inner join DepositAccount account on contract.AccountNumber = account.AccountNumber
WHERE (contract.ContractStatus = 0 or contract.ContractStatus = 2) -- == Normal/Block
    and ifcbaldetail.ReferenceId = @TransactionNumber;

-- Create GL entries
exec dbo.GenerateGLEntriesFromDepositAccountTrans
	@TransactionNumber=null;

-- Create OD schedule 
INSERT INTO [dbo].[ODSchedule]
    ([ContractNumber], [DueDate], [DueStatus], [Amount], [Paid], [Ovd], [Mrkamt], [Mrksts], [Mrkdt], [Clrdt], [Clramt], [Prvrate], [Prvamt], [Prvclr], [Rptype], [DueNumber])
SELECT
    ifcbaldetail.ContractNumber as [ContractNumber]
	, @WorkingDate as [DueDate]
	, 'N' as [DueStatus]
	, round(ifcbaldetail.Amount, 2) as [Amount]
	, round(ifcbaldetail.Amount, 2) as [Paid]
	, 0 as  [Ovd]
	, 0 as  [Mrkamt]
	, null as  [Mrksts]
	, null as  [Mrkdt]
	, null as  [Clrdt]
	, null as  [Clramt]
	, null as  [Prvrate]
	, null as  [Prvamt]
	, null as  [Prvclr]
	, case when IfcSubType = 'IN' then 'I' 
			when IfcSubType = 'FC' then 'F'
			when IfcSubType = 'PP' then 'PP'
			when IfcSubType = 'PI' then 'PI' end as [Rptype]
	, (select dbo.GetNewDueNumber(ContractNumber, case when IfcSubType = 'IN' then 'I' 
													when IfcSubType = 'FC' then 'F'
													when IfcSubType = 'PP' then 'PP'
													when IfcSubType = 'PI' then 'PI' end)) as [DueNumber]
FROM ODContractIFCBalanceDetail ifcbaldetail
    inner join DepositIFCDefinition ifcDef on ifcbaldetail.IfcCode = ifcDef.IfcCode
WHERE ifcbaldetail.ReferenceId = @TransactionNumber AND ifcbaldetail.Action = 'P';

COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    throw;
END CATCH;

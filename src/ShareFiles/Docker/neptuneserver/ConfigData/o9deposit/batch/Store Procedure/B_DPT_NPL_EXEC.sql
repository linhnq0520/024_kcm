use o9deposit;
GO

IF OBJECT_ID('[B_DPT_NPL_EXEC]', 'P') IS NOT NULL
BEGIN
    -- The procedure exists
    DROP PROCEDURE B_DPT_NPL_EXEC
;
END;
GO

CREATE PROCEDURE [dbo].[B_DPT_NPL_EXEC]
    (
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
)
AS
BEGIN TRY
DECLARE @current_working_date DATE = @WorkingDate;
DECLARE @StartTime DATE = GETUTCDATE();

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

-- Overdraft contract with overdue days of interest and principle
Delete from dbo.ODContractOverDueDaysTable where WorkingDate =  @WorkingDate; -- in case batch fail and data already write into table

INSERT INTO dbo.ODContractOverDueDaysTable
    (
    ODContract,
    WorkingDate,
    CurrentStatus,
    PrincipalOverDueDays,
    MainInterestOverDueDays,
    NewStatus
    )
SELECT a.ContractNumber,
    @current_working_date,
    a.CurrentClassificationStatus,
    ISNULL(sum(a.PRINCIPAL_OVR_DAYS), 0) PRINCIPAL_OVR_DAYS,
    ISNULL(sum(a.MAIN_INT_OVR_DAYS), 0) MAIN_INT_OVR_DAYS,
    NULL AS NewStatus
FROM (
        -- overdue principal
                                          SELECT b.ContractNumber,
            case when ifcbal.Amount + dbo.GetOverDraftBalance(b.AccountNumber) = 0 then 0 else iif(DATEDIFF(day, b.ToDate, @current_working_date) < 0, 0, DATEDIFF(day, b.ToDate, @current_working_date)) end AS PRINCIPAL_OVR_DAYS,
            0 AS MAIN_INT_OVR_DAYS,
            b.ClassificationStatus AS CurrentClassificationStatus
        FROM OverDraftContract b
            inner join (select sum(Round(Amount, 2)) Amount, count(ContractNumber) Count, ContractNumber
            from ODContractIFCBalance
            group by ContractNumber) ifcbal on b.ContractNumber  = ifcbal.ContractNumber
        WHERE (b.ContractStatus = 0 or b.ContractStatus = 2)
            and b.Restruct = 'A'

    UNION

        -- overdue interest
        SELECT b.ContractNumber,
            0 AS PRINCIPAL_OVR_DAYS,
            b.InterestOverDays AS MAIN_INT_OVR_DAYS,
            b.ClassificationStatus AS CurrentClassificationStatus
        FROM OverDraftContract b
        WHERE (b.ContractStatus = 0 or b.ContractStatus = 2)
            and b.Restruct = 'A'
    ) a

GROUP BY a.ContractNumber,
    a.CurrentClassificationStatus;

DECLARE @strSQL NVARCHAR(max) = '';

SET @strSQL = 'UPDATE [ODContractOverDueDaysTable] 
	SET [newStatus] = CASE ';

DECLARE @expressions VARCHAR(max);

DECLARE myCursor CURSOR
FOR
SELECT ' WHEN CurrentStatus=''' + a.[From] + ''' and (' + a.[Condition] + ') THEN ''' + a.[To] + '''' AS expressions
FROM dbo.NPLRule a
WHERE a.RuleType = 'OD'
ORDER BY a.[From],
    a.[To];

OPEN myCursor;

FETCH NEXT
FROM myCursor
INTO @expressions;

WHILE @@FETCH_STATUS = 0
BEGIN
    SET @strSQL = @strSQL + @expressions;

    FETCH NEXT
    FROM myCursor
    INTO @expressions;
END;

CLOSE myCursor;

DEALLOCATE myCursor;

-- version 2016 not support function STRING_AGG (2022)
--SET @strSQL = @strSQL + (
--        SELECT STRING_AGG(' WHEN CurrentStatus=''' + a.[From] + ''' and (' + a.[Condition] + ') THEN ''' + a.[To] + '''', '
--		') AS expressions
--        FROM NPLRule a
--        );
SET @strSQL = @strSQL + ' ELSE [newStatus]';
SET @strSQL = @strSQL + ' END';
SET @strSQL = @strSQL + ' WHERE WorkingDate=''' + CONVERT(NVARCHAR, @current_working_date, 101) + ''';';
SET @strSQL = REPLACE(@strSQL, 'MAX_INT(', '[dbo].MAX_INT(');

PRINT @strSQL;
EXEC (@strSQL);

-- Remove accounts whose statuses were not changed
DELETE
FROM ODContractOverDueDaysTable
WHERE NewStatus IS NULL;

----  2.1.1 insert MasterTrans - principal entries

INSERT INTO dbo.[ClassificationTrans]
    (
    [TransactionNumber],
    [TransId],
    [ODContract],
    [FromStatus],
    [ToStatus],
    [TransactionStatus],
    [Amount],
    [GLPopulated],
    [GLGroup]
    )
SELECT @TransactionNumber,
    NewID(),
    --[TransactionNumber]
    b.ContractNumber,
    --[ODContract]
    a.CurrentStatus,
    --[FromStatus]
    a.NewStatus,
    -- [ToStatus]
    'N',
    -- [TransactionStatus]
    b.OverDraftBalance, -- [Amount]
    0,
    1
FROM ODContractOverDueDaysTable a
    INNER JOIN OverdraftContract b ON a.ODContract = b.ContractNumber
WHERE b.Restruct = 'A' -- auto npl
    AND a.WorkingDate = @WorkingDate
    AND a.CurrentStatus <> a.NewStatus;

-- IFC_AICR and IFC_AICR_REVERSE
insert into ODContractIFCBalanceTrans
    ([TransId], [TransactionNumber], [ODContract], [IFCCode], [TransCode], [ClassificationStatus], [TransactionStatus], [Amount], [GLPopulated], [CrossBranchCode], [CrossCurrencyCode], [BaseCurrencyAmount], [GLGroup])
-- Revert daily interest and fee calculation in old classification status
    select NewID() as TransId
		, @TransactionNumber as TransactionNumber
		, npl_change.ODContract as ODContract
		, ifc_balance.IfcCode as IFCCode
		, Case when IfcDef.IfcType = 'I' then  'OD_IFC_IACR_REVERSE' when IfcDef.IfcType = 'F' then  'OD_IFC_FACR_REVERSE' end as TransCode
		, npl_change.FromStatus as ClassificationStatus-- Notice***: FromStatus
		, 'N' as TransactionStatus
		, ifc_balance.Amtpbl as Amount
		, 0 as GLPopulated
		, null as CrossBranchCode
		, null as CrossCurrencyCode
		, 0 as BaseCurrencyAmount
		, 1 as [GLGroup]
    From [ClassificationTrans] npl_change
        inner join ODContractIFCBalance ifc_balance on (npl_change.ODContract = ifc_balance.ContractNumber and ifc_balance.IfcBalanceStatus = 'N') -- to get IFCs balance
        inner join DepositIFCDefinition IfcDef on (ifc_balance.IfcCode = IfcDef.IfcCode and (IfcDef.IfcType = 'I' or IfcDef.IfcType = 'F'))
    -- apply to Interest and CommitmentFee 
    where npl_change.TransactionNumber = @TransactionNumber

union
    -- Post daily interest and fee calculation in new classification status
    select NewID() as TransId
		, @TransactionNumber as TransactionNumber
		, npl_change.ODContract as ODContract
		, ifc_balance.IfcCode as IFCCode
		, Case when IfcDef.IfcType = 'I' then  'OD_IFC_IACR' when IfcDef.IfcType = 'F' then  'OD_IFC_FACR' end as TransCode
		, npl_change.ToStatus as ClassificationStatus-- Notice***: ToStatus
		, 'N' as TransactionStatus
		, ifc_balance.Amtpbl as Amount
		, 0 as GLPopulated
		, null as CrossBranchCode
		, null as CrossCurrencyCode
		, 0 as BaseCurrencyAmount
		, 1 as [GLGroup]
    From [ClassificationTrans] npl_change
        inner join ODContractIFCBalance ifc_balance on (npl_change.ODContract = ifc_balance.ContractNumber and ifc_balance.IfcBalanceStatus = 'N') -- to get IFCs balance
        inner join DepositIFCDefinition IfcDef on (ifc_balance.IfcCode = IfcDef.IfcCode and (IfcDef.IfcType = 'I' or IfcDef.IfcType = 'F'))
    -- apply to Interest and CommitmentFee 
    where npl_change.TransactionNumber = @TransactionNumber

-- 3. Reverse & Post Provisioning

-- Insert ProvisioningTrans with new status
INSERT INTO dbo.ProvisioningTrans
    (
    [TransactionNumber],
    [TransId],
    [ODContract],
    [TransCode],
    [Amount],
    [CurrentClassificationStatus],
    [TransactionStatus],
    [GLPopulated],
    [GLGroup]
    )
    (
        SELECT
        @TransactionNumber as  [TransactionNumber]
		, NewID() as [TransId]
		, contract.ContractNumber as [ODContract]
		, 'POST_PROVISIONING' as [TransCode] -- 'Credit overdraft balance'
		, Case 
			when Round((dbo.GetOverDraftBalance(contract.AccountNumber) + (case when ifcbal.Amount is null then 0 else ifcbal.Amount end) - contract.SecureAmount)* 
			 case
				when overduedays.NewStatus = 'N' then contract.PrincipalProvisionRate0
				when overduedays.NewStatus = 'P' then contract.PrincipalProvisionRate1
				when overduedays.NewStatus = 'O' then contract.PrincipalProvisionRate2
				when overduedays.NewStatus = 'D' then contract.PrincipalProvisionRate3
				when overduedays.NewStatus = 'L' then contract.PrincipalProvisionRate4
				else 0
				end
				/100, 2) > 0 then Round((dbo.GetOverDraftBalance(contract.AccountNumber) + Amount - contract.SecureAmount)* 
				case
				when overduedays.NewStatus = 'N' then contract.PrincipalProvisionRate0
				when overduedays.NewStatus = 'P' then contract.PrincipalProvisionRate1
				when overduedays.NewStatus = 'O' then contract.PrincipalProvisionRate2
				when overduedays.NewStatus = 'D' then contract.PrincipalProvisionRate3
				when overduedays.NewStatus = 'L' then contract.PrincipalProvisionRate4
				else 0
				end
				/100, 2)
			else 0 end as [Amount]
		, overduedays.NewStatus as  [CurrentClassificationStatus]
		, 'N' as  [TransactionStatus]
		, 0 as  [GLPopulated]
		, 1 as [GLGroup]
    FROM OverDraftContract contract
        left join (select sum(Round(Amount, 2)) Amount, count(ContractNumber) Count, ContractNumber
        from ODContractIFCBalance
        group by ContractNumber) ifcbal on contract.ContractNumber  = ifcbal.ContractNumber
        inner join ODContractOverDueDaysTable overduedays on contract.ContractNumber = overduedays.ODContract and overduedays.WorkingDate = @WorkingDate
    where (contract.ContractStatus = 0 or contract.ContractStatus = 2)
        and overduedays.CurrentStatus <> overduedays.NewStatus
Union

    SELECT
        @TransactionNumber as  [TransactionNumber]
		, NewID() as [TransId]
		, contract.ContractNumber as [ODContract]
		, 'REVERSE_PROVISIONING' as [TransCode] -- 'Credit overdraft balance'
		, contract.ProvisionAmount as [Amount]
		, overduedays.CurrentStatus as  [CurrentClassificationStatus]
		, 'N' as  [TransactionStatus]
		, 0 as  [GLPopulated]
		, 1 as [GLGroup]
    FROM OverDraftContract contract
        inner join ODContractOverDueDaysTable overduedays on contract.ContractNumber = overduedays.ODContract and overduedays.WorkingDate = @WorkingDate
    where (contract.ContractStatus = 0 or contract.ContractStatus = 2)
        and overduedays.CurrentStatus <> overduedays.NewStatus);

Delete From dbo.ProvisioningTrans where TransactionNumber = @TransactionNumber and Amount = 0; -- Delete unuse Trans

UPDATE OverdraftContract 
SET OverdraftContract.ClassificationStatus = b.NewStatus
FROM OverdraftContract a
    INNER JOIN ODContractOverDueDaysTable b
    ON a.ContractNumber = b.ODContract
        AND b.WorkingDate = @current_working_date
WHERE b.CurrentStatus <> b.NewStatus;

UPDATE OverdraftContract
SET ProvisionAmount = trans.Amount
FROM OverdraftContract contract
    inner join ProvisioningTrans trans on trans.ODContract = contract.ContractNumber
where trans.[TransactionNumber] = @TransactionNumber
    and trans.TransCode = 'POST_PROVISIONING';
-- normal

INSERT INTO DepositHistory
    ([AccountNumber], [ValueDate], [RefId], [TransactionDate], [TransactionCode], [Amount], [Dorc], [Description], [UsrCode], [Oder], [DepositHistoryStatus], [Stcode], [Usrid], [ChannelId])
SELECT
    contract.AccountNumber -- [AccountNumber]
		, @WorkingDate -- [ValueDate]
		, @RefId -- [RefId]
		, CONVERT(DATE,  GETDATE()) -- [TransactionDate]
		, @StepName -- [TransactionCode]
		, 0 -- [Amount]
		, 'D' -- [Dorc]
		, @StepName + ': NPL Processing for contract [' + contract.ContractNumber + ']'-- [Description]
		, @UserCode -- [UsrCode]
		, 1 -- [Oder]
		, 'N' -- [DepositHistoryStatus] 
		, '-' -- [Stcode]
		, 0 --[Usrid]
		, @ChannelID
-- [ChannelId]
From OverdraftContract contract
    INNER JOIN ODContractOverDueDaysTable overdue
    ON contract.ContractNumber = overdue.ODContract
        AND overdue.WorkingDate = @current_working_date
WHERE overdue.CurrentStatus <> overdue.NewStatus;

-- 4.1: Create GLEntries from [ClassificationTrans]
EXEC [GenerateGLEntriesFromClassificationTrans] ;

-- 4.2: Create GLEntries from [ProvisioningTrans]
EXEC [GenerateGLEntriesFromProvisioningTrans] ;

-- 4.3: Create GLEntries from [CreditIFCBalanceTrans]
EXEC [GenerateGLEntriesFromODContractIFCBalanceTrans] ;

-- Final step: update executing duration
UPDATE [Transaction]
SET Duration = DATEDIFF_BIG(ms, @StartTime, GETUTCDATE())
WHERE TransactionNumber = @TransactionNumber;

COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    throw;
END CATCH;
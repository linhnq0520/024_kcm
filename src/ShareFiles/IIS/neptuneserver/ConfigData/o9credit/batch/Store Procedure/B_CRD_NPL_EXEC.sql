USE o9credit;
GO

IF OBJECT_ID('dbo.[B_CRD_NPL_EXEC]', 'P') IS NOT NULL
BEGIN
    -- The table exists
    DROP PROCEDURE dbo.B_CRD_NPL_EXEC;
END;
GO

CREATE PROCEDURE [dbo].[B_CRD_NPL_EXEC] (
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

BEGIN TRANSACTION;

-- Create transaction
	EXEC CREATE_TRANSACTION  
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

-- Credit account with overdue days of interest and principle
-- DELETE FROM dbo.CreditAccountOverDueDaysTable;

-- INSERT INTO dbo.CreditAccountOverDueDaysTable (
--     AccountNumber,
--     CustomerCode,
--     WorkingDate,
--     CurrentStatus,
--     PrincipalOverDueDays,
--     MainInterestOverDueDays,
--     NewStatus
--     )
SELECT a.AccountNumber,
    a.CustomerCode,
    @current_working_date AS WorkingDate,
    a.CurrentClassificationStatus AS CurrentStatus,
    ISNULL(sum(a.PRINCIPAL_OVR_DAYS), 0) As PrincipalOverDueDays,
    ISNULL(sum(a.MAIN_INT_OVR_DAYS), 0) As MainInterestOverDueDays,
	ISNULL(SUM(a.PENALTY_PRIN), 0) As PenaltyPrincipal,
	ISNULL(SUM(a.PENALTY_INT), 0) As PenaltyInterest,
    '_' AS NewStatus
INTO #CreditOverDueDaysTable
FROM (
    -- overdue principal
    SELECT b.AccountNumber,
        isnull(max(abs(DATEDIFF(day, @current_working_date, DueDate))),0) AS PRINCIPAL_OVR_DAYS,
        0 AS MAIN_INT_OVR_DAYS,
		0 PENALTY_PRIN,
		0 AS PENALTY_INT,
        b.ClassificationStatus AS CurrentClassificationStatus,
        b.CustomerCode
    FROM 
        (SELECT * FROM CreditAccount c WHERE c.DisbursementAmount > 0 AND c.Crdsts NOT IN (1, 7) AND c.Restruct <> 'N') b 
            LEFT JOIN CreditSchedule a
                ON (a.AccountNumber = b.AccountNumber and a.Rptype = 'P' and a.Amount > a.Paid and a.DueDate < @current_working_date)
    GROUP BY b.AccountNumber,
        b.ClassificationStatus,
        b.CustomerCode
    
    UNION
    
    -- overdue interest
    SELECT b.AccountNumber,
        0 AS PRINCIPAL_OVR_DAYS,
        isnull(max(abs(DATEDIFF(day, @current_working_date, DueDate))),0) AS MAIN_INT_OVR_DAYS,
		0 PENALTY_PRIN,
		0 AS PENALTY_INT,
        b.ClassificationStatus AS CurrentClassificationStatus,
        b.CustomerCode
    FROM 
        (SELECT * FROM CreditAccount c WHERE c.DisbursementAmount > 0 AND c.Crdsts NOT IN (1, 7) AND c.Restruct <> 'N') b 
            LEFT JOIN CreditSchedule a
                ON (a.AccountNumber = b.AccountNumber and a.Rptype = 'I' and a.Amount > a.Paid and a.DueDate < @current_working_date)
    WHERE  b.DisbursementAmount > 0 AND b.Crdsts NOT IN (1, 7) and b.Restruct <> 'N'
    GROUP BY b.AccountNumber,
        b.ClassificationStatus,
        b.CustomerCode
				
    UNION
    -- penalty principal
    SELECT b.AccountNumber,
        0 AS PRINCIPAL_OVR_DAYS,
        0 AS MAIN_INT_OVR_DAYS,
        ISNULL(iif(SUM(Round(i.Amount, 2)) > 0, SUM(Round(i.Amount, 2)), 0), 0) PENALTY_PRIN,
		0 AS PENALTY_INT,
        b.ClassificationStatus AS CurrentClassificationStatus,
        b.CustomerCode
    FROM 
        (SELECT * FROM CreditAccount c WHERE c.DisbursementAmount > 0 AND c.Crdsts NOT IN (1, 7) AND c.Restruct <> 'N') b 
            LEFT JOIN 
		( 
			SELECT i.AccountNumber, i.Amount FROM CreditIFCBalance i INNER JOIN CreditIFCDefinition d ON i.IfcCode = d.IfcCode WHERE d.IfcSubType = 'PP' AND i.IfcBalanceStatus = 'N'
		) i ON b.AccountNumber = i.AccountNumber
    WHERE  b.DisbursementAmount > 0 AND b.Crdsts NOT IN (1, 7) and b.Restruct <> 'N'
    GROUP BY b.AccountNumber,
        b.ClassificationStatus,
        b.CustomerCode

	UNION
	-- penalty interest
    SELECT b.AccountNumber,
        0 AS PRINCIPAL_OVR_DAYS,
        0 AS MAIN_INT_OVR_DAYS,
		0 AS PENALTY_PRIN,
		ISNULL(iif(SUM(Round(i.Amount, 2)) > 0, SUM(Round(i.Amount, 2)), 0), 0) AS PENALTY_INT,
        b.ClassificationStatus AS CurrentClassificationStatus,
        b.CustomerCode
    FROM 
        (SELECT * FROM CreditAccount c WHERE c.DisbursementAmount > 0 AND c.Crdsts NOT IN (1, 7) AND c.Restruct <> 'N') b 
            LEFT JOIN 
		( 
			SELECT i.AccountNumber, i.Amount FROM CreditIFCBalance i INNER JOIN CreditIFCDefinition d ON i.IfcCode = d.IfcCode WHERE d.IfcSubType = 'PI' AND i.IfcBalanceStatus = 'N'
		) i ON b.AccountNumber = i.AccountNumber
    WHERE  b.DisbursementAmount > 0 AND b.Crdsts NOT IN (1, 7) and b.Restruct <> 'N'
    GROUP BY b.AccountNumber,
        b.ClassificationStatus,
        b.CustomerCode
    ) a

GROUP BY a.AccountNumber,
    a.CurrentClassificationStatus,
    a.CustomerCode;

DECLARE @strSQL NVARCHAR(max) = '';

SET @strSQL = 'UPDATE [#CreditOverDueDaysTable] 
	SET [newStatus] = CASE ';

DECLARE @expressions VARCHAR(max);

DECLARE myCursor CURSOR
FOR
SELECT ' WHEN CurrentStatus=''' + a.[From] + ''' and (' + a.[Condition] + ') THEN ''' + a.[To] + '''' AS expressions
FROM dbo.NPLRule a
WHERE a.RuleType = 'Normal_Loan'
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

-- PRINT @strSQL;

EXEC (@strSQL);

-- a sample of Update statement:
--update [dbo].[CreditAccountOverDueDaysTable]
--set [newStatus] = case
--  when CurrentStatus='N' and dbo.MAX_INT(PRINCIPAL_OVR_DAYS,MAIN_INT_OVR_DAYS) > 30  AND dbo.MAX_INT(PRINCIPAL_OVR_DAYS,MAIN_INT_OVR_DAYS) <= 60 THEN 'P'
--  when CurrentStatus='N' and dbo.MAX_INT(PRINCIPAL_OVR_DAYS,MAIN_INT_OVR_DAYS) > 60  AND dbo.MAX_INT(PRINCIPAL_OVR_DAYS,MAIN_INT_OVR_DAYS) <= 90 then 'O'
--  when CurrentStatus='N' and dbo.MAX_INT(PRINCIPAL_OVR_DAYS,MAIN_INT_OVR_DAYS) > 90  AND dbo.MAX_INT(PRINCIPAL_OVR_DAYS,MAIN_INT_OVR_DAYS) <= 180 then 'D'
--  when CurrentStatus='N' and dbo.MAX_INT(PRINCIPAL_OVR_DAYS,MAIN_INT_OVR_DAYS) > 180 then 'L'
--  when CurrentStatus='P' and dbo.MAX_INT(PRINCIPAL_OVR_DAYS,MAIN_INT_OVR_DAYS) = 0 then 'N'
--  when CurrentStatus='P' and dbo.MAX_INT(PRINCIPAL_OVR_DAYS,MAIN_INT_OVR_DAYS) > 60 AND dbo.MAX_INT(PRINCIPAL_OVR_DAYS,MAIN_INT_OVR_DAYS) <= 90 then 'O'
--  when CurrentStatus='P' and dbo.MAX_INT(PRINCIPAL_OVR_DAYS,MAIN_INT_OVR_DAYS) > 90  AND dbo.MAX_INT(PRINCIPAL_OVR_DAYS,MAIN_INT_OVR_DAYS) <= 180 then 'L'
--  when CurrentStatus='P' and dbo.MAX_INT(PRINCIPAL_OVR_DAYS,MAIN_INT_OVR_DAYS) > 180 then 'D'
--  when CurrentStatus='O' and dbo.MAX_INT(PRINCIPAL_OVR_DAYS,MAIN_INT_OVR_DAYS) = 0 then 'N'
--  when CurrentStatus='O' and dbo.MAX_INT(PRINCIPAL_OVR_DAYS,MAIN_INT_OVR_DAYS) > 90 AND dbo.MAX_INT(PRINCIPAL_OVR_DAYS,MAIN_INT_OVR_DAYS) <= 180 then 'D'
--  when CurrentStatus='O' and dbo.MAX_INT(PRINCIPAL_OVR_DAYS,MAIN_INT_OVR_DAYS) > 180 then 'L'
--  when CurrentStatus='D' and dbo.MAX_INT(PRINCIPAL_OVR_DAYS,MAIN_INT_OVR_DAYS) = 0 then 'N'
--  when CurrentStatus='D' and dbo.MAX_INT(PRINCIPAL_OVR_DAYS,MAIN_INT_OVR_DAYS) > 180 then 'L'
--  when CurrentStatus='L' and dbo.MAX_INT(PRINCIPAL_OVR_DAYS,MAIN_INT_OVR_DAYS) = 0 then 'N'
--  else [newStatus]
-- END;
-- Remove accounts whose statuses were not changed
DELETE
FROM #CreditOverDueDaysTable
WHERE NewStatus = '_';

-- 2. Insert data to [ClassificationTrans] for loan which has been changed classification statuses
-- This table to keep event data to generate postings for principle, interest
-- TransactionNumber
-- CreditAccount
-- TransCode
-- TransactionStatus
-- Amount
-- GLPopulated
-- CrossBranchCode
-- CrossCurrencyCode
----  2.1.1 insert MasterTrans - principal entries
DELETE
FROM [ClassificationTrans]
WHERE [TransactionNumber] = @TransactionNumber;

INSERT INTO dbo.[ClassificationTrans] (
    [TransactionNumber],
	[TransId],
    [CreditAccount],
    [FromStatus],
    [ToStatus],
    [TransactionStatus],
    [Amount],
    [GLPopulated],
    [GLGroup]
    )
SELECT @TransactionNumber,
    NewID(), --[TransactionNumber]
    b.AccountNumber, --[CreditAccount]
    a.CurrentStatus, --[FromStatus]
    a.NewStatus, -- [ToStatus]
    'N', -- [TransactionStatus]
    b.Balance, -- [Amount]
    0, -- [GLPopluated]
    1 -- [GLGroup]
FROM #CreditOverDueDaysTable a
INNER JOIN CreditAccount b ON a.AccountNumber = b.AccountNumber
WHERE b.IsProvision = 'Y' -- auto provision --> auto change classification status
    AND a.WorkingDate = @WorkingDate
    AND a.CurrentStatus <> a.NewStatus;

----  2.1.2. When the NPL occurs, need to reverse interest accrual (move from on-balance sheet to off-balance-sheet)
delete from CreditIFCBalanceTrans where TransactionNumber = @TransactionNumber;

insert into CreditIFCBalanceTrans ([TransId], [TransactionNumber], [CreditAccount], [IfcCode], [TransCode], [ClassificationStatus], [TransactionStatus], [Amount], [GLPopulated], [CrossBranchCode], [CrossCurrencyCode], [BaseCurrencyAmount], [GLGroup])
select * from (
-- Reverse old classification Status
select NewID() as TransId
	,@TransactionNumber as TransactionNumber
	,npl_change.CreditAccount as MasterAccount
	,ifc_balance.IfcCode as IFCCode
	, case when IfcDef.IfcType = 'I' then 'IFC_IACR_REVERSE' when IfcDef.IfcSubType = 'PP' then 'CREDIT_PENALTY_PRIN_NO_UPDATE' when IfcDef.IfcSubType = 'PI' then 'CREDIT_PENALTY_INT_NO_UPDATE' end as TransCode
	,npl_change.FromStatus as ClassificationStatus-- Notice***: ToStatus
	,'N' as TransactionStatus
	, iif(Round(ifc_balance.Amount, 2) > 0, Round(ifc_balance.Amount, 2), 0) as Amount
	,0 as GLPopulated
	,null as CrossBranchCode
	,null as CrossCurrencyCode
	,0 BaseCurrencyAmount
    ,1 GLGroup
From [ClassificationTrans] npl_change
	inner join CreditIFCBalance ifc_balance on (npl_change.CreditAccount = ifc_balance.AccountNumber and ifc_balance.IfcBalanceStatus = 'N') -- to get IFCs balance
	inner join CreditIFCDefinition IfcDef on (ifc_balance.IfcCode = IfcDef.IfcCode) -- apply to Interest only
where npl_change.TransactionNumber = @TransactionNumber
-- Post new classification Status
Union
select NewID() as TransId
	,@TransactionNumber as TransactionNumber
	,npl_change.CreditAccount as MasterAccount
	,ifc_balance.IfcCode as IFCCode
	, case when IfcDef.IfcType = 'I' then 'IFC_IACR' when IfcDef.IfcSubType = 'PP' then 'DEBIT_PENALTY_PRIN_NO_UPDATE' when IfcDef.IfcSubType = 'PI' then 'DEBIT_PENALTY_INT_NO_UPDATE' end as TransCode
	,npl_change.ToStatus as ClassificationStatus-- Notice***: ToStatus
	,'N' as TransactionStatus
	, iif(Round(ifc_balance.Amount, 2) > 0, Round(ifc_balance.Amount, 2), 0) as Amount
	,0 as GLPopulated
	,null as CrossBranchCode
	,null as CrossCurrencyCode
	,0 BaseCurrencyAmount
    ,1 GLGroup
From [ClassificationTrans] npl_change
	inner join CreditIFCBalance ifc_balance on (npl_change.CreditAccount = ifc_balance.AccountNumber and ifc_balance.IfcBalanceStatus = 'N') -- to get IFCs balance
	inner join CreditIFCDefinition IfcDef on (ifc_balance.IfcCode = IfcDef.IfcCode) -- apply to Interest only
where npl_change.TransactionNumber = @TransactionNumber
) a where Amount != 0

---- End 2.1.2.-----------------

---- 2.2 Update classification
UPDATE CreditAccount
SET CreditAccount.ClassificationStatus = b.NewStatus
FROM CreditAccount a
INNER JOIN #CreditOverDueDaysTable b
    ON a.AccountNumber = b.AccountNumber
        AND b.WorkingDate = @current_working_date
WHERE b.CurrentStatus <> b.NewStatus;

---- 2.3 Create CreditHistory
DELETE
FROM CreditHistory
WHERE TransactionNumber = @TransactionNumber;

INSERT INTO CreditHistory (
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
SELECT a.AccountNumber, --DefAccountNumber
    CONVERT(DATE,  GETDATE()), -- [TransactionDate]
    @RefId, --TransactionRefId
    @WorkingDate, --ValueDate
    @StepName, --TransactionCode
    b.[Balance], --Amount
    'D', --Dorc
    @StepName + ': NPL Processing for account [' + a.AccountNumber + ']', --Description
    @UserCode, --@UserCode: UserCreated
    'N', --Status
    0, --@UserCode: UserApprove
    @TransactionNumber, -- TransactionNumber
    @ChannelID
FROM #CreditOverDueDaysTable a
INNER JOIN CreditAccount b ON a.AccountNumber = b.AccountNumber
WHERE a.WorkingDate = @WorkingDate
    AND a.CurrentStatus <> a.NewStatus
    ;

-- 3. Reverse & Post Provisioning
DELETE
FROM dbo.ProvisioningTrans
WHERE TransactionNumber = @TransactionNumber;

INSERT INTO dbo.ProvisioningTrans (
    [TransactionNumber],
	[TransId],
    [CreditAccount],
    [TransCode],
    [Amount],
    [CurrentClassificationStatus],
    [TransactionStatus],
    [GLPopulated],
    [GLGroup]
    )
SELECT @TransactionNumber, NewID(),
    a.[CreditAccount], -- [CreditAccount]
    'REVERSE_PROVISIONING' as [TransCode], --[TransCode]
    b.[ProvisionOfOther] AS [Amount], --[Amount]: previous provisioning keep amount in field [ProvisionOfOther]
    a.FromStatus AS [ClassificationStatus], --[ClassificationStatus]
    'N' AS [TransactionStatus], --[TransactionStatus]
    0, --[GLPopulated]
    1 -- [GLGroup]
FROM [ClassificationTrans] a
INNER JOIN CreditAccount b
    ON a.CreditAccount = b.AccountNumber
WHERE b.ProvisionOfOther <> 0
    AND a.TransactionNumber = @TransactionNumber

UNION

SELECT @TransactionNumber, NewID(),
    a.[CreditAccount], -- [CreditAccount]
    'POST_PROVISIONING' as [TransCode], --[TransCode]
    ROUND((account.balance + ifcBal.Amount - account.[SecuredAmount]) * CASE 
            WHEN account.ClassificationStatus = 'N'
                THEN account.PrincipalProvisionRate0
            WHEN account.ClassificationStatus = 'P'
                THEN account.PrincipalProvisionRate1
            WHEN account.ClassificationStatus = 'O'
                THEN account.PrincipalProvisionRate2
            WHEN account.ClassificationStatus = 'D'
                THEN account.PrincipalProvisionRate3
            WHEN account.ClassificationStatus = 'L'
                THEN account.PrincipalProvisionRate4
            ELSE 0
            END / 100, 2) AS [Amount],
    --[Amount]
    a.ToStatus AS [ClassificationStatus], --[ClassificationStatus]
    'N' AS [TransactionStatus], --[TransactionStatus]
    0 AS [GLPopulated], --[GLPopulated]
    1 -- [GLGroup]
FROM ClassificationTrans a
INNER JOIN ClassificationGLConfig toGLConfig
    ON a.ToStatus = toGLConfig.ClassificationStatus
INNER JOIN CreditAccount account
    ON a.CreditAccount = account.AccountNumber
INNER JOIN (Select AccountNumber, Sum(Round(Amount, 2)) as Amount from CreditIFCBalance group by AccountNumber) ifcBal
    ON ifcBal.AccountNumber = account.AccountNumber
LEFT JOIN CreditSchedule prin_schedule
    ON a.CreditAccount = prin_schedule.AccountNumber
        AND prin_schedule.Rptype = 'P'
        AND prin_schedule.Amount - prin_schedule.Paid > 0
        AND prin_schedule.DueDate < @WorkingDate
LEFT JOIN CreditSchedule int_schedule
    ON a.CreditAccount = int_schedule.AccountNumber
        AND int_schedule.Rptype = 'I'
        AND int_schedule.Amount - int_schedule.Paid > 0
        AND int_schedule.DueDate < @WorkingDate
WHERE a.TransactionNumber = @TransactionNumber
    AND account.IsProvision = 'Y'
GROUP BY a.[CreditAccount],
    a.[ToStatus],
    account.[PrincipalProvisionRate0],
    account.[PrincipalProvisionRate1],
    account.[PrincipalProvisionRate2],
    account.[PrincipalProvisionRate3],
    account.[PrincipalProvisionRate4],
    account.[balance],
    account.[FineAmount],
    account.[FinePaid],
    account.[InterestDue],
    account.[InterestAmount],
    account.[SecuredAmount],
	account.ClassificationStatus,
	ifcBal.Amount;
	


-- 3.1: Update Post Provision Amount to Master accounts
UPDATE CreditAccount
SET ProvisionOfOther = iif(provision.Amount > 0, provision.Amount, 0)
FROM [CreditAccount] account
INNER JOIN [ProvisioningTrans] provision
    ON (
            account.AccountNumber = provision.CreditAccount
            AND provision.TransCode = 'POST_PROVISIONING'
			and provision.TransactionNumber = @TransactionNumber
            );

-- 4.1: Create GLEntries from [ClassificationTrans]
EXEC [GenerateGLEntriesFromClassificationTrans];

-- 4.2: Create GLEntries from [ProvisioningTrans]
EXEC [GenerateGLEntriesFromProvisioningTrans];

-- 4.3: Create GLEntries from [CreditIFCBalanceTrans]
EXEC [GenerateGLEntriesFromCreditIFCBalanceTrans] @TransactionNumber;

-- Final step: update executing duration
UPDATE [Transaction]
SET Duration = DATEDIFF_BIG(ms, @StartTime, GETUTCDATE())
WHERE TransactionNumber = @TransactionNumber;

-- Clean tables
exec B_CRD_MOVE_TO_HIS_TABLES;

COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    throw;
END CATCH;
GO

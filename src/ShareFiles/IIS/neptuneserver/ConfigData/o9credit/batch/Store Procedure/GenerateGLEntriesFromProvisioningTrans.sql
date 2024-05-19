USE o9credit;
GO

IF OBJECT_ID('GenerateGLEntriesFromProvisioningTrans', 'P') IS NOT NULL 
BEGIN -- The table exists
    DROP PROCEDURE dbo.GenerateGLEntriesFromProvisioningTrans;
END;
GO 
--@TransactionNumber:
    ---- NOT NUTLL: filter exactly by the value
    ---- NULL: not filter by transaction number
CREATE PROCEDURE [dbo].[GenerateGLEntriesFromProvisioningTrans] (@TransactionNumber VARCHAR(100) = NULL) AS 
BEGIN

INSERT INTO GLEntries (
        [TransactionNumber],
        [TransTableName],
        [TransId],
        [SysAccountName],
        [GLAccount],
        [DorC],
        [TransactionStatus],
        [Amount],
        [BranchCode],
        [CurrencyCode],
        [ValueDate],
        [Posted],
        [AccountingGroup]
    ) -- Reverse Debit Entry
SELECT provision_trans.TransactionNumber, -- [TransactionNumber]
    'ProvisioningTrans', --[TransTableName]
    [provision_trans].TransId, -- [TransId]
    gl.DebitSysAccountName, -- [SysAccountName] Notice******
    account_gls.GLAccount, -- [GLAccount]
    'D', --[DorC] Notice******
    'N', --[TransactionStatus], 
    provision_trans.[Amount],
    account.BranchCode AS [BranchCode],
    account.CurrencyCode AS [CurrencyCode],
    trans.ValueDate AS [ValueDate],
    0 AS [Posted],
    provision_trans.GLGroup
FROM [ProvisioningTrans] provision_trans
    INNER JOIN [Transaction] trans ON provision_trans.TransactionNumber = trans.TransactionNumber
    INNER JOIN [CreditAccount] account ON provision_trans.CreditAccount = account.AccountNumber
    INNER JOIN [ProvisioningGLConfig] gl ON (
        provision_trans.CurrentClassificationStatus = gl.ClassificationStatus
        AND provision_trans.TransCode = gl.TransCode
    )
    INNER JOIN [CreditAccountGLs] account_gls ON (
        account_gls.SysAccountName = gl.DebitSysAccountName -- Notice: DebitSysAccountName
        and account_gls.CreditAccount = account.AccountNumber
    )
WHERE (
        provision_trans.TransactionNumber = @TransactionNumber
        OR @TransactionNumber = NULL
    )
    AND provision_trans.TransactionStatus = 'N'
    AND provision_trans.GLPopulated = 0
    AND provision_trans.TransCode = 'REVERSE_PROVISIONING'
    AND provision_trans.[Amount] <> 0
UNION
-- Reverse Credit Entry
SELECT provision_trans.TransactionNumber, -- [TransactionNumber]
    'ProvisioningTrans', --[TransTableName]
    [provision_trans].TransId, -- [TransId]
    gl.CreditSysAccountName, -- [SysAccountName] Notice******
    account_gls.GLAccount, -- [GLAccount]
    'C', --[DorC] Notice******
    'N', --[TransactionStatus], 
    provision_trans.[Amount],
    account.BranchCode AS [BranchCode],
    account.CurrencyCode AS [CurrencyCode],
    trans.ValueDate AS [ValueDate],
    0 AS [Posted],
    provision_trans.GLGroup
FROM [ProvisioningTrans] provision_trans
    INNER JOIN [Transaction] trans ON provision_trans.TransactionNumber = trans.TransactionNumber
    INNER JOIN [CreditAccount] account ON provision_trans.CreditAccount = account.AccountNumber
    INNER JOIN [ProvisioningGLConfig] gl ON (
        provision_trans.CurrentClassificationStatus = gl.ClassificationStatus
        AND provision_trans.TransCode = gl.TransCode
    )
    INNER JOIN [CreditAccountGLs] account_gls ON (
        account_gls.SysAccountName = gl.CreditSysAccountName -- Notice: CreditSysAccountName
        and account_gls.CreditAccount = account.AccountNumber
    )
WHERE (
        provision_trans.TransactionNumber = @TransactionNumber
        OR @TransactionNumber = NULL
    )
    AND provision_trans.TransactionStatus = 'N'
    AND provision_trans.GLPopulated = 0
    AND provision_trans.TransCode = 'REVERSE_PROVISIONING'
    AND provision_trans.[Amount] <> 0
UNION
-- Post Debit Entry
SELECT provision_trans.TransactionNumber, -- [TransactionNumber]
    'ProvisioningTrans', --[TransTableName]
    [provision_trans].TransId, -- [TransId]
    gl.DebitSysAccountName, -- [SysAccountName] Notice******
    account_gls.GLAccount, -- [GLAccount]
    'D', --[DorC] Notice******
    'N', --[TransactionStatus], 
    provision_trans.[Amount],
    account.BranchCode AS [BranchCode],
    account.CurrencyCode AS [CurrencyCode],
    trans.ValueDate AS [ValueDate],
    0 AS [Posted],
    provision_trans.GLGroup
FROM [ProvisioningTrans] provision_trans
    INNER JOIN [Transaction] trans ON provision_trans.TransactionNumber = trans.TransactionNumber
    INNER JOIN [CreditAccount] account ON provision_trans.CreditAccount = account.AccountNumber
    INNER JOIN [ProvisioningGLConfig] gl ON (
        provision_trans.CurrentClassificationStatus = gl.ClassificationStatus
        AND provision_trans.TransCode = gl.TransCode
        and provision_trans.CreditAccount = account.AccountNumber
    )
    INNER JOIN [CreditAccountGLs] account_gls ON (account_gls.SysAccountName = gl.DebitSysAccountName and provision_trans.CreditAccount = account_gls.CreditAccount)-- Notice: DebitSysAccountName
WHERE (
        provision_trans.TransactionNumber = @TransactionNumber
        OR @TransactionNumber = NULL
    )
    AND provision_trans.TransactionStatus = 'N'
    AND provision_trans.GLPopulated = 0
    AND provision_trans.TransCode = 'POST_PROVISIONING'
    AND provision_trans.[Amount] <> 0
UNION
-- Post Credit Entry
SELECT provision_trans.TransactionNumber, -- [TransactionNumber]
    'ProvisioningTrans', --[TransTableName]
    [provision_trans].TransId, -- [TransId]
    gl.CreditSysAccountName, -- [SysAccountName] Notice******
    account_gls.GLAccount, -- [GLAccount]
    'C', --[DorC] Notice******
    'N', --[TransactionStatus], 
    provision_trans.[Amount],
    account.BranchCode AS [BranchCode],
    account.CurrencyCode AS [CurrencyCode],
    trans.ValueDate AS [ValueDate],
    0 AS [Posted],
    provision_trans.GLGroup
FROM [ProvisioningTrans] provision_trans
    INNER JOIN [Transaction] trans ON provision_trans.TransactionNumber = trans.TransactionNumber
    INNER JOIN [CreditAccount] account ON provision_trans.CreditAccount = account.AccountNumber
    INNER JOIN [ProvisioningGLConfig] gl ON (
        provision_trans.CurrentClassificationStatus = gl.ClassificationStatus
        AND provision_trans.TransCode = gl.TransCode
        and provision_trans.CreditAccount = account.AccountNumber
    )
    INNER JOIN [CreditAccountGLs] account_gls ON (account_gls.SysAccountName = gl.CreditSysAccountName and provision_trans.CreditAccount = account_gls.CreditAccount) -- Notice: CreditSysAccountName
WHERE (
        provision_trans.TransactionNumber = @TransactionNumber
        OR @TransactionNumber = NULL
    )
    AND provision_trans.TransactionStatus = 'N'
    AND provision_trans.GLPopulated = 0
    AND provision_trans.TransCode = 'POST_PROVISIONING'
    AND provision_trans.[Amount] <> 0;
-- update today provisioning entries were created GLs
UPDATE [ProvisioningTrans]
SET GLPopulated = 1
FROM [ProvisioningTrans] provision_trans
    INNER JOIN [GLEntries] GL ON (
        provision_trans.TransId = GL.TransId
        AND Gl.TransTableName = 'ProvisioningTrans'
    )
WHERE (
        provision_trans.TransactionNumber = @TransactionNumber
        OR @TransactionNumber = NULL
    )
    AND provision_trans.GLPopulated = 0;
END;
GO
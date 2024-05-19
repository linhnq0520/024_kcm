USE o9deposit;
GO

IF OBJECT_ID('[GenerateGLEntriesFromDepositIFCBalanceTrans]', 'P') IS NOT NULL
BEGIN
    -- The table exists
    DROP PROCEDURE GenerateGLEntriesFromDepositIFCBalanceTrans;
END;
GO

CREATE PROCEDURE [dbo].[GenerateGLEntriesFromDepositIFCBalanceTrans]
    (
    @TransactionNumber varchar(100) = null
)
AS

declare @TableName varchar(100) = 'DepositIFCBalanceTrans';

-- Principal entries
INSERT INTO dbo.GLEntries
    (
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
    [CrossBranchCode],
    [CrossCurrencyCode]
    )
-- Reverse Debit Entry (new status)
    select
        balance_trans.TransactionNumber, -- [TransactionNumber]
        'DepositIFCBalanceTrans', --[TransTableName]
        balance_trans.[TransId], -- [TransId]
        gl.DebitSysAccountName, -- [SysAccountName] Notice******
        ifc_gl.GLAccount, -- [GLAccount]
        'D', --[DorC] Notice******
        'N', --[TransactionStatus], 
        balance_trans.[Amount],
        account.BranchCode AS [BranchCode],
        account.CurrencyCode AS [CurrencyCode],
        trans.ValueDate AS [ValueDate],
        0 AS [Posted],
        balance_trans.CrossBranchCode,
        balance_trans.CrossCurrencyCode
    FROM dbo.[DepositIFCBalanceTrans] balance_trans
        INNER JOIN [Transaction] trans
        ON balance_trans.TransactionNumber = trans.TransactionNumber
        INNER JOIN [DepositAccount] account
        ON balance_trans.DepositAccount = account.AccountNumber
        INNER JOIN [DepositIFCBalanceGLConfig] gl -- use the same gl config table with Deposit account
        ON (balance_trans.TransCode = gl.TransCode and gl.ConfigurationGroup ='IFC')
        inner join [DepositAccountIFCGLs] ifc_gl
        on (balance_trans.DepositAccount = ifc_gl.DepositAccount
            and balance_trans.IFCCode = ifc_gl.IfcCode
            and gl.DebitSysAccountName = ifc_gl.SysAccountName)
    -- Notice Debit
    WHERE (balance_trans.TransactionNumber = @TransactionNumber or @TransactionNumber is null)
        and balance_trans.TransactionStatus='N'
        and balance_trans.GLPopulated = 0
        and balance_trans.[Amount] <> 0
        and gl.GenerateDebitEntry=1
    -- Notice Debit

Union
    -- Credit entry
    select
        balance_trans.TransactionNumber, -- [TransactionNumber]
        'DepositIFCBalanceTrans', --[TransTableName]
        balance_trans.[TransId], -- [TransId]
        gl.CreditSysAccountName, -- [SysAccountName] Notice******
        ifc_gl.GLAccount, -- [GLAccount]
        'C', --[DorC] Notice******
        'N', --[TransactionStatus], 
        balance_trans.[Amount],
        account.BranchCode AS [BranchCode],
        account.CurrencyCode AS [CurrencyCode],
        trans.ValueDate AS [ValueDate],
        0 AS [Posted],
        balance_trans.CrossBranchCode,
        balance_trans.CrossCurrencyCode
    FROM dbo.[DepositIFCBalanceTrans] balance_trans
        INNER JOIN [Transaction] trans
        ON balance_trans.TransactionNumber = trans.TransactionNumber
        INNER JOIN [DepositAccount] account
        ON balance_trans.DepositAccount = account.AccountNumber
        INNER JOIN [DepositIFCBalanceGLConfig] gl -- use the same gl config table with Deposit account
        ON (balance_trans.TransCode = gl.TransCode and gl.ConfigurationGroup='IFC')
        inner join [DepositAccountIFCGLs] ifc_gl
        on (balance_trans.DepositAccount = ifc_gl.DepositAccount
            and balance_trans.IFCCode = ifc_gl.IfcCode
            and gl.CreditSysAccountName = ifc_gl.SysAccountName)-- Notice Credit
    WHERE (balance_trans.TransactionNumber = @TransactionNumber or @TransactionNumber is null)
        and balance_trans.TransactionStatus='N'
        and balance_trans.GLPopulated = 0
        and balance_trans.[Amount] <> 0
        and gl.GenerateCreditEntry = 1;-- Notice Credit

-- update today provisioning entries were created GLs
UPDATE [DepositIFCBalanceTrans]
SET GLPopulated = 1
FROM [DepositIFCBalanceTrans] trans
INNER JOIN [GLEntries] gl
ON (trans.TransId = gl.TransId)
WHERE (trans.TransactionNumber = @TransactionNumber or @TransactionNumber is null)
and trans.GLPopulated = 0;

GO

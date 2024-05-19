USE o9credit;
GO

IF OBJECT_ID('dbo.[GenerateGLEntriesFromCreditIFCBalanceTrans]', 'P') IS NOT NULL
BEGIN
    -- The table exists
    DROP PROCEDURE dbo.GenerateGLEntriesFromCreditIFCBalanceTrans;
END;
GO

--@TransactionNumber:
---- NOT NUTLL: filter exactly by the value
---- NULL: not filter by transaction number
CREATE PROCEDURE [dbo].[GenerateGLEntriesFromCreditIFCBalanceTrans] (@TransactionNumber VARCHAR(100) = NULL)
AS
BEGIN
    DECLARE @TableName VARCHAR(100) = 'CreditIFCBalanceTrans';

    -- Principal entries
    INSERT INTO dbo.GLEntries (
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
        [AccountingGroup],
        [CrossBranchCode],
        [CrossCurrencyCode]
        )
    -- Reverse Debit Entry (new status)
            SELECT balance_trans.TransactionNumber, -- [TransactionNumber]
            'CreditIFCBalanceTrans', --[TransTableName]
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
            balance_trans.GLGroup,
            balance_trans.CrossBranchCode,
            balance_trans.CrossCurrencyCode
        FROM dbo.[CreditIFCBalanceTrans] balance_trans
            INNER JOIN [Transaction] trans
            ON balance_trans.TransactionNumber = trans.TransactionNumber
            INNER JOIN [CreditAccount] account
            ON balance_trans.CreditAccount = account.AccountNumber
            INNER JOIN [CreditIFCBalanceGLConfig] gl
            ON (
                balance_trans.TransCode = gl.TransCode
                AND gl.ConfigurationGroup = 'IFC'
                AND balance_trans.ClassificationStatus = gl.ClassificationStatus
                )
            INNER JOIN CreditAccountIFCGLs ifc_gl
            ON (
                balance_trans.CreditAccount = ifc_gl.CreditAccount
                AND balance_trans.IFCCode = ifc_gl.IfcCode
                AND gl.DebitSysAccountName = ifc_gl.SysAccountName
                )
        WHERE (
            balance_trans.TransactionNumber = @TransactionNumber
            OR @TransactionNumber IS NULL
            )
            AND balance_trans.TransactionStatus = 'N'
            AND balance_trans.GLPopulated = 0
            AND balance_trans.[Amount] <> 0
            AND gl.GenerateDebitEntry = 1

    UNION

        -- Credit entry
        SELECT balance_trans.TransactionNumber, -- [TransactionNumber]
            'CreditIFCBalanceTrans', --[TransTableName]
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
            balance_trans.GLGroup,
            balance_trans.CrossBranchCode,
            balance_trans.CrossCurrencyCode
        FROM dbo.[CreditIFCBalanceTrans] balance_trans
            INNER JOIN [Transaction] trans
            ON balance_trans.TransactionNumber = trans.TransactionNumber
            INNER JOIN [CreditAccount] account
            ON balance_trans.CreditAccount = account.AccountNumber
            INNER JOIN [CreditIFCBalanceGLConfig] gl
            ON (
                balance_trans.TransCode = gl.TransCode
                AND gl.ConfigurationGroup = 'IFC'
                AND balance_trans.ClassificationStatus = gl.ClassificationStatus
                )
            INNER JOIN CreditAccountIFCGLs ifc_gl
            ON (
                balance_trans.CreditAccount = ifc_gl.CreditAccount
                AND balance_trans.IFCCode = ifc_gl.IfcCode
                AND gl.CreditSysAccountName = ifc_gl.SysAccountName
                )
        WHERE (
            balance_trans.TransactionNumber = @TransactionNumber
            OR @TransactionNumber IS NULL
            )
            AND balance_trans.TransactionStatus = 'N'
            AND balance_trans.GLPopulated = 0
            AND balance_trans.[Amount] <> 0
            AND gl.GenerateCreditEntry = 1;

    -- update today provisioning entries were created GLs
    UPDATE [CreditIFCBalanceTrans]
    SET GLPopulated = 1
    FROM [CreditIFCBalanceTrans] trans
        INNER JOIN [GLEntries] gl
        ON (trans.TransId = gl.TransId)
    WHERE (
            trans.TransactionNumber = @TransactionNumber
        OR @TransactionNumber IS NULL
            )
        AND trans.GLPopulated = 0;
END;
GO

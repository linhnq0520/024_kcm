USE o9credit;
GO

IF OBJECT_ID('GenerateGLEntriesFromClassificationTrans', 'P') IS NOT NULL
BEGIN
    -- The table exists
    DROP PROCEDURE GenerateGLEntriesFromClassificationTrans;
END;
GO

--@TransactionNumber:
---- NOT NUTLL: filter exactly by the value
---- NULL: not filter by transaction number
CREATE PROCEDURE [dbo].[GenerateGLEntriesFromClassificationTrans] (@TransactionNumber VARCHAR(100) = NULL)
AS
BEGIN
    -- Principal entries
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
        )
    -- Reverse Debit Entry (new status)
    SELECT npl_trans.TransactionNumber, -- [TransactionNumber]
        'ClassificationTrans', --[TransTableName]
        npl_trans.TransId, -- [TransId]
        gl_config.SysAccountName, -- [SysAccountName] Notice******
        GLs.GLAccount, -- [GLAccount]
        'D', --[DorC] Notice******
        'N', --[TransactionStatus], 
        npl_trans.[Amount],
        account.BranchCode AS [BranchCode],
        account.CurrencyCode AS [CurrencyCode],
        trans.ValueDate AS [ValueDate],
        0 AS [Posted],
        npl_trans.GLGroup 
    FROM [ClassificationTrans] npl_trans
    INNER JOIN [Transaction] trans
        ON npl_trans.TransactionNumber = trans.TransactionNumber
    INNER JOIN [CreditAccount] account
        ON npl_trans.CreditAccount = account.AccountNumber
    INNER JOIN [ClassificationGLConfig] gl_config
        ON npl_trans.ToStatus = gl_config.ClassificationStatus -- NOTICE**** To Status
    INNER JOIN [CreditAccountGLs] GLs
        ON (
                account.AccountNumber = GLs.CreditAccount
                AND gl_config.SysAccountName = GLs.SysAccountName
                )
    WHERE (
            npl_trans.TransactionNumber = @TransactionNumber
            OR @TransactionNumber IS NULL
            )
        AND npl_trans.TransactionStatus = 'N'
        AND npl_trans.GLPopulated = 0
        AND npl_trans.[Amount] <> 0
    
    UNION
    
    -- Reverse Credit Entry (Old status)
    SELECT npl_trans.TransactionNumber, -- [TransactionNumber]
        'ClassificationTrans', --[TransTableName]
        npl_trans.TransId, -- [TransId]
        gl_config.SysAccountName, -- [SysAccountName] Notice******
        GLs.GLAccount, -- [GLAccount]
        'C', --[DorC] Notice******
        'N', --[TransactionStatus], 
        npl_trans.[Amount],
        account.BranchCode AS [BranchCode],
        account.CurrencyCode AS [CurrencyCode],
        trans.ValueDate AS [ValueDate],
        0 AS [Posted],
        npl_trans.GLGroup 
    FROM [ClassificationTrans] npl_trans
    INNER JOIN [Transaction] trans
        ON npl_trans.TransactionNumber = trans.TransactionNumber
    INNER JOIN [CreditAccount] account
        ON npl_trans.CreditAccount = account.AccountNumber
    INNER JOIN [ClassificationGLConfig] gl_config
        ON npl_trans.FromStatus = gl_config.ClassificationStatus -- NOTICE**** From Status
    INNER JOIN [CreditAccountGLs] GLs
        ON (
                account.AccountNumber = GLs.CreditAccount
                AND gl_config.SysAccountName = GLs.SysAccountName
                )
    WHERE (
            npl_trans.TransactionNumber = @TransactionNumber
            OR @TransactionNumber IS NULL
            )
        AND npl_trans.TransactionStatus = 'N'
        AND npl_trans.GLPopulated = 0
        AND npl_trans.[Amount] <> 0;

    -- update today provisioning entries were created GLs
    UPDATE [ClassificationTrans]
    SET GLPopulated = 1
    FROM [ClassificationTrans] npl_trans
    INNER JOIN [GLEntries] GL
        ON (
                GL.TransTableName = 'ClassificationTrans'
                AND gl.TransId = npl_trans.TransId
                )
    WHERE (
            npl_trans.TransactionNumber = @TransactionNumber
            OR @TransactionNumber IS NULL
            )
        AND npl_trans.GLPopulated = 0;

END;
GO

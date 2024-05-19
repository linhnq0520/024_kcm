USE o9deposit;
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
CREATE PROCEDURE [dbo].[GenerateGLEntriesFromClassificationTrans]
    (@TransactionNumber VARCHAR(100) = NULL)
AS
BEGIN
    -- Principal entries
    INSERT INTO GLEntries
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
        [Posted]
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
            contract.BranchCode AS [BranchCode],
            contract.Currency AS [CurrencyCode],
            trans.ValueDate AS [ValueDate],
            0 AS [Posted]
        FROM [ClassificationTrans] npl_trans
            INNER JOIN [Transaction] trans
            ON npl_trans.TransactionNumber = trans.TransactionNumber
            INNER JOIN OverdraftContract contract
            ON npl_trans.ODContract = contract.ContractNumber
            INNER JOIN [ClassificationGLConfig] gl_config
            ON npl_trans.ToStatus = gl_config.ClassificationStatus -- NOTICE**** To Status
            INNER JOIN [OverdraftContractGLs] GLs
            ON (
                contract.ContractNumber = GLs.ODContract
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
            contract.BranchCode AS [BranchCode],
            contract.Currency AS [CurrencyCode],
            trans.ValueDate AS [ValueDate],
            0 AS [Posted]
        FROM [ClassificationTrans] npl_trans
            INNER JOIN [Transaction] trans
            ON npl_trans.TransactionNumber = trans.TransactionNumber
            INNER JOIN [OverdraftContract] contract
            ON npl_trans.ODContract = contract.ContractNumber
            INNER JOIN [ClassificationGLConfig] gl_config
            ON npl_trans.FromStatus = gl_config.ClassificationStatus -- NOTICE**** From Status
            INNER JOIN [OverdraftContractGLs] GLs
            ON (
                contract.ContractNumber = GLs.ODContract
                AND gl_config.SysAccountName = GLs.SysAccountName
                )
        WHERE (
            npl_trans.TransactionNumber = @TransactionNumber
            OR @TransactionNumber IS NULL
            )
            AND npl_trans.TransactionStatus = 'N'
            AND npl_trans.GLPopulated = 0
            AND npl_trans.[Amount] <> 0

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

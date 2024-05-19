USE [o9fixedasset]
GO

IF OBJECT_ID('[GenerateGLEntriesFromFixedAssetTrans]', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE GenerateGLEntriesFromFixedAssetTrans;
END;
GO

--@TransactionNumber:
---- NOT NUTLL: filter exactly by the value
---- NULL: not filter by transaction number
CREATE PROCEDURE [dbo].[GenerateGLEntriesFromFixedAssetTrans] (@TransactionNumber VARCHAR(100) = NULL)
AS
BEGIN
    --Declare @HOBranchCode varchar(100) = '999';
    --Declare @BaseCurrencyCode varchar(100) = 'MMK';
    DECLARE @TableName VARCHAR(100) = 'FixedAssetAccountTrans';

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
        [Posted]
        )
    -- Debit entries
    SELECT trans.TransactionNumber, -- [TransactionNumber]
        @TableName, --[TransTableName]
        account_trans.[TransId], -- [TransId]
        config.DebitSysAccountName, -- [SysAccountName] Notice******
        GLs.GLAccount, -- [GLAccount]
        'D', --[DorC] Notice******
        'N', --[TransactionStatus], 
        account_trans.[Amount],
        account.BranchCode AS [BranchCode],
        account.CurrencyCode AS [CurrencyCode],
        trans.TransactionDate AS [ValueDate],
        0 AS [Posted]
    FROM [FixedAssetAccountTrans] account_trans
    INNER JOIN [Transaction] trans ON account_trans.TransactionNumber = trans.TransactionNumber
    INNER JOIN FixedAssetAccount account ON (account_trans.FixedAssetAccount = account.AccountNumber)
    INNER JOIN FixedAssetAccountGLConfig config ON ( account_trans.TransCode = config.TransCode )
    INNER JOIN FixedAssetAccountGLs GLs
        ON config.DebitSysAccountName = GLs.SysAccountName
            AND GLs.FixedAssetAccount = account.AccountNumber
    WHERE (
            account_trans.TransactionNumber = @TransactionNumber OR @TransactionNumber IS NULL
            )
        AND config.GenerateDebitEntry = 1
        AND account_trans.GLPopulated = 0
    
    UNION
    
    --Credit entries
    SELECT trans.TransactionNumber, -- [TransactionNumber]
        @TableName, --[TransTableName]
        account_trans.[TransId], -- [TransId]
        config.CreditSysAccountName, -- [SysAccountName] Notice******
        GLs.GLAccount, -- [GLAccount]
        'C', --[DorC] Notice******
        'N', --[TransactionStatus], 
        account_trans.[Amount],
        account.BranchCode AS [BranchCode],
        account.CurrencyCode AS [CurrencyCode],
        trans.TransactionDate AS [ValueDate],
        0 AS [Posted]
    FROM [FixedAssetAccountTrans] account_trans
    INNER JOIN [Transaction] trans ON account_trans.TransactionNumber = trans.TransactionNumber
    INNER JOIN FixedAssetAccount account ON (account_trans.FixedAssetAccount = account.AccountNumber)
    INNER JOIN FixedAssetAccountGLConfig config ON ( account_trans.TransCode = config.TransCode )
    INNER JOIN FixedAssetAccountGLs GLs
        ON config.DebitSysAccountName = GLs.SysAccountName
            AND GLs.FixedAssetAccount = account.AccountNumber
    WHERE (
            account_trans.TransactionNumber = @TransactionNumber OR @TransactionNumber IS NULL
            )
        AND config.GenerateCreditEntry = 1
        AND account_trans.GLPopulated = 0;

    UPDATE [FixedAssetAccountTrans]
    SET [GLPopulated] = 1
    FROM [FixedAssetAccountTrans] account_trans
    INNER JOIN [GLEntries] gl
        ON (
                gl.TransTableName = 'FixedAssetAccountTrans'
                AND account_trans.TransId = gl.TransId
                )
    WHERE account_trans.GLPopulated = 0;
END;
GO

USE [o9credit]
GO

IF OBJECT_ID('[GenerateGLEntriesFromCreditAccountTrans]', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE GenerateGLEntriesFromCreditAccountTrans;
END;
GO

--@TransactionNumber:
---- NOT NUTLL: filter exactly by the value
---- NULL: not filter by transaction number
CREATE PROCEDURE [dbo].[GenerateGLEntriesFromCreditAccountTrans]
    (@TransactionNumber VARCHAR(100) = NULL)
AS
BEGIN
    --Declare @HOBranchCode varchar(100) = '999';
    --Declare @BaseCurrencyCode varchar(100) = 'MMK';
    DECLARE @TableName VARCHAR(100) = 'CreditAccountTrans';

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
        [Posted],
        [AccountingGroup],
        [CrossBranchCode],
        [CrossCurrencyCode]
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
            trans.ValueDate AS [ValueDate],
            0 AS [Posted],
            account_trans.GLGroup,
            account_trans.CrossBranchCode,
            account_trans.CrossCurrencyCode
        FROM [CreditAccountTrans] account_trans
            INNER JOIN [Transaction] trans
            ON account_trans.TransactionNumber = trans.TransactionNumber
            INNER JOIN CreditAccount account
            ON (account_trans.CreditAccount = account.AccountNumber)
            INNER JOIN CreditAccountGLConfig config
            ON (
                account_trans.TransCode = config.TransCode
                AND account_trans.CurrentClassificationStatus = config.ClassificationStatus
                AND config.ConfigurationGroup = 'BALANCE'
                )
            INNER JOIN CreditAccountGLs GLs
            ON config.DebitSysAccountName = GLs.SysAccountName
                AND GLs.CreditAccount = account.AccountNumber
        WHERE (
            account_trans.TransactionNumber = @TransactionNumber
            OR @TransactionNumber IS NULL
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
            trans.ValueDate AS [ValueDate],
            0 AS [Posted],
            account_trans.GLGroup,
            account_trans.CrossBranchCode,
            account_trans.CrossCurrencyCode
        FROM CreditAccountTrans account_trans
            INNER JOIN [Transaction] trans
            ON account_trans.TransactionNumber = trans.TransactionNumber
            INNER JOIN CreditAccount account
            ON (account_trans.CreditAccount = account.AccountNumber)
            INNER JOIN CreditAccountGLConfig config
            ON (
                account_trans.TransCode = config.TransCode
                AND account_trans.CurrentClassificationStatus = config.ClassificationStatus
                AND config.ConfigurationGroup = 'BALANCE'
                )
            INNER JOIN CreditAccountGLs GLs
            ON config.CreditSysAccountName = GLs.SysAccountName
                AND GLs.CreditAccount = account.AccountNumber
        WHERE (
            account_trans.TransactionNumber = @TransactionNumber
            OR @TransactionNumber IS NULL
            )
            AND config.GenerateCreditEntry = 1
            AND account_trans.GLPopulated = 0;

    UPDATE [CreditAccountTrans]
    SET [GLPopulated] = 1
    FROM [CreditAccountTrans] account_trans
        INNER JOIN [GLEntries] gl
        ON (
                gl.TransTableName = 'CreditAccountTrans'
            AND account_trans.TransId = gl.TransId
                )
    WHERE account_trans.GLPopulated = 0;
END;
GO

USE [o9deposit]
GO

IF OBJECT_ID('[GenerateGLEntriesFromOverdraftContractTrans]', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE GenerateGLEntriesFromOverdraftContractTrans;
END;
GO

--@TransactionNumber:
---- NOT NUTLL: filter exactly by the value
---- NULL: not filter by transaction number
CREATE PROCEDURE GenerateGLEntriesFromOverdraftContractTrans
    (@TransactionNumber VARCHAR(100) = NULL)
AS
BEGIN
    --Declare @HOBranchCode varchar(100) = '999';
    --Declare @BaseCurrencyCode varchar(100) = 'MMK';
    DECLARE @TableName VARCHAR(100) = 'OverdraftContractTrans';

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
    -- Debit entries
            SELECT trans.TransactionNumber, -- [TransactionNumber]
            @TableName, --[TransTableName]
            contract_trans.[TransId], -- [TransId]
            config.DebitSysAccountName, -- [SysAccountName] Notice******
            GLs.GLAccount, -- [GLAccount]
            'D', --[DorC] Notice******
            'N', --[TransactionStatus], 
            contract_trans.[Amount],
            contract.BranchCode AS [BranchCode],
            contract.Currency AS [CurrencyCode],
            trans.ValueDate AS [ValueDate],
            0 AS [Posted]
        FROM [OverdraftContractTrans] contract_trans
            INNER JOIN [Transaction] trans
            ON contract_trans.TransactionNumber = trans.TransactionNumber
            INNER JOIN OverDraftContract contract
            ON (contract_trans.ODContract = contract.ContractNumber)
            INNER JOIN OverdraftContractGLConfig config
            ON (
                contract_trans.TransCode = config.TransCode
                AND contract_trans.CurrentClassificationStatus = config.ClassificationStatus
                AND config.ConfigurationGroup = 'OVERDRAFT_BALANCE'
                )
            INNER JOIN OverdraftContractGLs GLs
            ON config.DebitSysAccountName = GLs.SysAccountName
                AND GLs.ODContract = contract.ContractNumber
        WHERE (
            contract_trans.TransactionNumber = @TransactionNumber
            OR @TransactionNumber IS NULL
            )
            AND config.GenerateDebitEntry = 1
            AND contract_trans.GLPopulated = 0

    UNION

        --Credit entries
        SELECT trans.TransactionNumber, -- [TransactionNumber]
            @TableName, --[TransTableName]
            contract_trans.[TransId], -- [TransId]
            config.CreditSysAccountName, -- [SysAccountName] Notice******
            GLs.GLAccount, -- [GLAccount]
            'C', --[DorC] Notice******
            'N', --[TransactionStatus], 
            contract_trans.[Amount],
            contract.BranchCode AS [BranchCode],
            contract.Currency AS [CurrencyCode],
            trans.ValueDate AS [ValueDate],
            0 AS [Posted]
        FROM OverdraftContractTrans contract_trans
            INNER JOIN [Transaction] trans
            ON contract_trans.TransactionNumber = trans.TransactionNumber
            INNER JOIN OverDraftContract contract
            ON (contract_trans.ODContract = contract.ContractNumber)
            INNER JOIN OverdraftContractGLConfig config
            ON (
                contract_trans.TransCode = config.TransCode
                AND contract_trans.CurrentClassificationStatus = config.ClassificationStatus
                AND config.ConfigurationGroup = 'OVERDRAFT_BALANCE'
                )
            INNER JOIN OverdraftContractGLs GLs
            ON config.CreditSysAccountName = GLs.SysAccountName
                AND GLs.ODContract = contract.ContractNumber
        WHERE (
            contract_trans.TransactionNumber = @TransactionNumber
            OR @TransactionNumber IS NULL
            )
            AND config.GenerateCreditEntry = 1
            AND contract_trans.GLPopulated = 0;

    UPDATE [OverdraftContractTrans]
    SET [GLPopulated] = 1
    FROM [OverdraftContractTrans] contract_trans
        INNER JOIN [GLEntries] gl
        ON (
                gl.TransTableName = 'OverdraftContractTrans'
            AND contract_trans.TransId = gl.TransId
                )
    WHERE contract_trans.GLPopulated = 0;
END;
GO




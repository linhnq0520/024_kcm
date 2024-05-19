USE o9deposit;
GO

IF OBJECT_ID('dbo.[GenerateGLEntriesFromProvisioningTrans]', 'P') IS NOT NULL
BEGIN
	-- The table exists
	DROP PROCEDURE dbo.GenerateGLEntriesFromProvisioningTrans;
END;
GO

--@TransactionNumber:
---- NOT NUTLL: filter exactly by the value
---- NULL: not filter by transaction number
CREATE PROCEDURE [dbo].GenerateGLEntriesFromProvisioningTrans
	(@TransactionNumber VARCHAR(100) = NULL)
AS
BEGIN
	DECLARE @TableName VARCHAR(100) = 'ProvisioningTrans';

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
		[Posted]
		)
	-- Debit entries
			SELECT provisioning_trans.TransactionNumber, -- [TransactionNumber]
			'ProvisioningTrans', --[TransTableName]
			provisioning_trans.[TransId], -- [TransId]
			gl.DebitSysAccountName, -- [SysAccountName] 
			contract_gl.GLAccount, -- [GLAccount]
			'D', --[DorC] 
			'N', --[TransactionStatus], 
			provisioning_trans.[Amount],
			contract.BranchCode AS [BranchCode],
			contract.Currency AS [CurrencyCode],
			trans.ValueDate AS [ValueDate],
			0 AS [Posted]
		FROM dbo.ProvisioningTrans provisioning_trans
			INNER JOIN [Transaction] trans
			ON provisioning_trans.TransactionNumber = trans.TransactionNumber
			INNER JOIN [OverDraftContract] contract
			ON provisioning_trans.ODContract = contract.ContractNumber
			INNER JOIN [ProvisioningGLConfig] gl
			ON (
                provisioning_trans.TransCode = gl.TransCode
				AND gl.ClassificationStatus = provisioning_trans.CurrentClassificationStatus
				AND gl.ConfigurationGroup = 'PROVISION'	
                )
			INNER JOIN OverdraftContractGLs contract_gl
			ON (
                provisioning_trans.ODContract = contract_gl.ODContract
				AND gl.DebitSysAccountName = contract_gl.SysAccountName
                )
		WHERE (
            provisioning_trans.TransactionNumber = @TransactionNumber
			OR @TransactionNumber IS NULL
            )
			AND provisioning_trans.TransactionStatus = 'N'
			AND provisioning_trans.GLPopulated = 0
			AND provisioning_trans.[Amount] <> 0
			AND gl.GenerateDebitEntry = 1

	UNION

		-- Credit entry
		SELECT provisioning_trans.TransactionNumber, -- [TransactionNumber]
			'ProvisioningTrans', --[TransTableName]
			provisioning_trans.[TransId], -- [TransId]
			gl.CreditSysAccountName, -- [SysAccountName]
			contract_gl.GLAccount, -- [GLAccount]
			'C', --[DorC] 
			'N', --[TransactionStatus], 
			provisioning_trans.[Amount],
			contract.BranchCode AS [BranchCode],
			contract.Currency AS [CurrencyCode],
			trans.ValueDate AS [ValueDate],
			0 AS [Posted]
		FROM dbo.[ProvisioningTrans] provisioning_trans
			INNER JOIN [Transaction] trans
			ON provisioning_trans.TransactionNumber = trans.TransactionNumber
			INNER JOIN [OverDraftContract] contract
			ON provisioning_trans.ODContract = contract.ContractNumber
			INNER JOIN [ProvisioningGLConfig] gl
			ON (
                provisioning_trans.TransCode = gl.TransCode
				AND gl.ClassificationStatus = provisioning_trans.CurrentClassificationStatus
				AND gl.ConfigurationGroup = 'PROVISION'
                )
			INNER JOIN OverdraftContractGLs contract_gl
			ON (
                provisioning_trans.ODContract = contract_gl.ODContract
				AND gl.CreditSysAccountName = contract_gl.SysAccountName
                )
		WHERE (
            provisioning_trans.TransactionNumber = @TransactionNumber
			OR @TransactionNumber IS NULL
            )
			AND provisioning_trans.TransactionStatus = 'N'
			AND provisioning_trans.GLPopulated = 0
			AND provisioning_trans.[Amount] <> 0
			AND gl.GenerateCreditEntry = 1;

	-- update today provisioning entries were created GLs
	UPDATE [ProvisioningTrans]
    SET GLPopulated = 1
    FROM [ProvisioningTrans] trans
		INNER JOIN [GLEntries] gl
		ON (trans.TransId = gl.TransId)
    WHERE (
            trans.TransactionNumber = @TransactionNumber
		OR @TransactionNumber IS NULL
            )
		AND trans.GLPopulated = 0;
END;
GO
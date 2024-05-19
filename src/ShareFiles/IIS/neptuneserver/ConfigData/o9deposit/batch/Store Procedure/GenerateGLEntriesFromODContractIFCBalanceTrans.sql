USE o9deposit;
GO

IF OBJECT_ID('dbo.[GenerateGLEntriesFromODContractIFCBalanceTrans]', 'P') IS NOT NULL
BEGIN
	-- The table exists
	DROP PROCEDURE dbo.GenerateGLEntriesFromODContractIFCBalanceTrans;
END;
GO

--@TransactionNumber:
---- NOT NUTLL: filter exactly by the value
---- NULL: not filter by transaction number
CREATE PROCEDURE [dbo].[GenerateGLEntriesFromODContractIFCBalanceTrans]
	(@TransactionNumber VARCHAR(100) = NULL)
AS
BEGIN
	DECLARE @TableName VARCHAR(100) = 'ODContractIFCBalanceTrans';

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
			SELECT balance_trans.TransactionNumber, -- [TransactionNumber]
			'ODContractIFCBalanceTrans', --[TransTableName]
			balance_trans.[TransId], -- [TransId]
			gl.DebitSysAccountName, -- [SysAccountName] 
			ifc_gl.GLAccount, -- [GLAccount]
			'D', --[DorC] 
			'N', --[TransactionStatus], 
			balance_trans.[Amount],
			contract.BranchCode AS [BranchCode],
			contract.Currency AS [CurrencyCode],
			trans.ValueDate AS [ValueDate],
			0 AS [Posted]
		FROM dbo.[ODContractIFCBalanceTrans] balance_trans
			INNER JOIN [Transaction] trans
			ON balance_trans.TransactionNumber = trans.TransactionNumber
			INNER JOIN [OverDraftContract] contract
			ON balance_trans.ODContract = contract.ContractNumber
			INNER JOIN [ODContractIFCBalanceGLConfig] gl
			ON (
                balance_trans.TransCode = gl.TransCode
				AND gl.ClassificationStatus = balance_trans.ClassificationStatus
				AND gl.ConfigurationGroup = 'IFC'	
                )
			INNER JOIN OverdraftContractIFCGLs ifc_gl
			ON (
                balance_trans.ODContract = ifc_gl.ODContract
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
			'ODContractIFCBalanceTrans', --[TransTableName]
			balance_trans.[TransId], -- [TransId]
			gl.CreditSysAccountName, -- [SysAccountName]
			ifc_gl.GLAccount, -- [GLAccount]
			'C', --[DorC] 
			'N', --[TransactionStatus], 
			balance_trans.[Amount],
			contract.BranchCode AS [BranchCode],
			contract.Currency AS [CurrencyCode],
			trans.ValueDate AS [ValueDate],
			0 AS [Posted]
		FROM dbo.[ODContractIFCBalanceTrans] balance_trans
			INNER JOIN [Transaction] trans
			ON balance_trans.TransactionNumber = trans.TransactionNumber
			INNER JOIN [OverDraftContract] contract
			ON balance_trans.ODContract = contract.ContractNumber
			INNER JOIN [ODContractIFCBalanceGLConfig] gl
			ON (
                balance_trans.TransCode = gl.TransCode
				AND gl.ClassificationStatus = balance_trans.ClassificationStatus
				AND gl.ConfigurationGroup = 'IFC'
                )
			INNER JOIN OverdraftContractIFCGLs ifc_gl
			ON (
                balance_trans.ODContract = ifc_gl.ODContract
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
	UPDATE [ODContractIFCBalanceTrans]
    SET GLPopulated = 1
    FROM [ODContractIFCBalanceTrans] trans
		INNER JOIN [GLEntries] gl
		ON (trans.TransId = gl.TransId)
    WHERE (
            trans.TransactionNumber = @TransactionNumber
		OR @TransactionNumber IS NULL
            )
		AND trans.GLPopulated = 0;
END;
GO
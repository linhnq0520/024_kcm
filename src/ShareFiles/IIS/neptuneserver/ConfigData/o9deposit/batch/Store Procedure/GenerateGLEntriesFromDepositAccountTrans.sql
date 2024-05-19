USE [o9deposit]
GO

IF OBJECT_ID('[GenerateGLEntriesFromDepositAccountTrans]', 'P') IS NOT NULL
BEGIN
	drop procedure GenerateGLEntriesFromDepositAccountTrans;
END;
GO
--@TransactionNumber:
---- NOT NUTLL: filter exactly by the value
---- NULL: not filter by transaction number
CREATE PROCEDURE dbo.GenerateGLEntriesFromDepositAccountTrans
	(
	@TransactionNumber varchar(100) = null
)
AS

BEGIN
	--Declare @HOBranchCode varchar(100) = '999';
	--Declare @BaseCurrencyCode varchar(100) = 'MMK';
	BEGIN TRANSACTION;

	Declare @TableName varchar(100) = 'DepositAccountTrans';

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
		[CrossBranchCode],
		[CrossCurrencyCode]
		)
	-- Debit entries
			SELECT
			trans.TransactionNumber, -- [TransactionNumber]
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
			account_trans.CrossBranchCode,
			account_trans.CrossCurrencyCode
		FROM [DepositAccountTrans] account_trans
			INNER JOIN [Transaction] trans
			on account_trans.TransactionNumber = trans.TransactionNumber
			INNER JOIN DepositAccount account
			ON (account_trans.[DepositAccount] = account.AccountNumber)
			INNER JOIN DepositAccountGLConfig config
			ON (account_trans.TransCode = config.TransCode and config.ConfigurationGroup='BALANCE')
			INNER JOIN DepositAccountGLs GLs
			ON config.DebitSysAccountName = GLs.SysAccountName and GLs.DepositAccount=account.AccountNumber
		WHERE (account_trans.TransactionNumber = @TransactionNumber or @TransactionNumber is null)
			and config.GenerateDebitEntry =1 and account_trans.GLPopulated = 0

	Union

		--Credit entries
		SELECT
			trans.TransactionNumber, -- [TransactionNumber]
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
			account_trans.CrossBranchCode,
			account_trans.CrossCurrencyCode
		FROM [DepositAccountTrans] account_trans
			INNER JOIN [Transaction] trans
			on account_trans.TransactionNumber = trans.TransactionNumber
			INNER JOIN DepositAccount account
			ON (account_trans.[DepositAccount] = account.AccountNumber)
			INNER JOIN DepositAccountGLConfig config
			ON (account_trans.TransCode = config.TransCode and config.ConfigurationGroup='BALANCE')
			INNER JOIN DepositAccountGLs GLs
			ON config.CreditSysAccountName = GLs.SysAccountName and GLs.DepositAccount=account.AccountNumber
		WHERE (account_trans.TransactionNumber = @TransactionNumber or @TransactionNumber is null)
			and config.GenerateCreditEntry = 1 and account_trans.GLPopulated = 0;

	UPDATE [DepositAccountTrans]
	SET [GLPopulated] = 1
	FROM [DepositAccountTrans] account_trans
		INNER JOIN [GLEntries] gl on (gl.TransTableName='DepositAccountTrans' and account_trans.TransId = gl.TransId)
		where account_trans.GLPopulated = 0 and (@TransactionNumber is null or account_trans.TransactionNumber=@TransactionNumber);

	COMMIT TRANSACTION;

END;
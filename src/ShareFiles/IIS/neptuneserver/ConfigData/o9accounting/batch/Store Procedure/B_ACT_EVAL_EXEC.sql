USE [o9accounting]
GO

IF OBJECT_ID('[B_ACT_EVAL_EXEC]', 'P') IS NOT NULL
BEGIN
    -- The procedure exists
    DROP PROCEDURE B_ACT_EVAL_EXEC;
END;
GO

CREATE PROCEDURE [dbo].[B_ACT_EVAL_EXEC] (
    @TransactionNumber VARCHAR(36),
    @WorkingDate DATE,
    @UserCode NVARCHAR(50),
    @UserName NVARCHAR(250),
    @BatchDate DATETIME,
    @StepName NVARCHAR(200),
    @ReferenceId NVARCHAR(200) = NULL,
	@RefId NVARCHAR(200) = NULL,
    @ReferenceCode NVARCHAR(200) = NULL,
    @TranId NVARCHAR(200) = NULL,
    @Description NVARCHAR(200) = NULL,
    @BusinessCode NVARCHAR(200) = NULL,
    @ChannelID NVARCHAR(200) = NULL
	)
AS

DECLARE @current_working_date DATE = @WorkingDate;
DECLARE @StartTime DATE = GETUTCDATE();
DECLARE @BatchStepName VARCHAR(100) = 'B_ACT_EVAL_EXEC';

BEGIN TRY

DECLARE @BaseCurrency VARCHAR(3) = (SELECT [Value] FROM [o9admin].[dbo].[Setting] WHERE [Name] = 'AdminSetting.BaseCurrency');
DECLARE @HostBranch VARCHAR(5) = (SELECT [Value] FROM [o9admin].[dbo].[Setting] WHERE [Name] = 'AdminSetting.HostBranch');
DECLARE @ListThread TABLE (
    BaseCurrency VARCHAR(3),					--SDATA1
    AccountCurrency VARCHAR(3),					--SDATA2
    ClearingType VARCHAR(1),					--SDATA3
    EquivalentAccount VARCHAR(100),				--SDATA4	PGACC
    PositionAccount VARCHAR(100),				--SDATA5
    PositionBranch VARCHAR(5),					--NDATA1
    BaseCurrencyRate DECIMAL(24, 5) DEFAULT 0,	--NDATA2
    EquivalentBalance DECIMAL(38, 5) DEFAULT 0,	--NDATA3
    PositionBalance DECIMAL(24, 5) DEFAULT 0,	--NDATA4
    Amount DECIMAL(38, 5) DEFAULT 0				--NDATA5	PGAMT
);

BEGIN TRANSACTION

-- Create transaction
	EXEC dbo.CREATE_TRANSACTION @TransactionNumber = @TransactionNumber,
		@WorkingDate = @WorkingDate,
		@UserCode = @UserCode,
		@UserName = @UserName,
		@BatchDate = @BatchDate,
		@StepName = @StepName,
		@ReferenceId = @ReferenceId,
		@RefId = @RefId,
		@ReferenceCode = @ReferenceCode,
		@TranId = @TranId,
		@Description = @Description,
		@BusinessCode = @BusinessCode,
		@ChannelID = @ChannelID;

-- Main processing code here
-- Insert table temporary, same same table thread of old o9core 
	INSERT INTO @ListThread
	SELECT @BaseCurrency, Position.AccountCurrency, 'F', Equivalent.AccountNumber, Position.AccountNumber,
		Position.BranchCode, BaseCurrencyRate, Equivalent.Balance, Position.Balance, ROUND(Position.Balance*BaseCurrencyRate+Equivalent.Balance,2)
	FROM
	(
		--FX Equivalent account
		SELECT A.BranchCode, A.AccountNumber, A.ClearingCurrency, B.Balance
		FROM
		(
			SELECT DISTINCT BranchCode, AccountNumber, ClearingCurrency
			FROM ForeignExchangeAccountDefinition
			WHERE AccountCurrency = @BaseCurrency AND ClearingCurrency <> @BaseCurrency
		) A
		INNER JOIN AccountBalance B
		ON A.AccountNumber = B.AccountNumber
		INNER JOIN AccountChart D
		ON A.AccountNumber = D.AccountNumber
	) Equivalent
	INNER JOIN
	(
		--FX Position account
		SELECT A.BranchCode, A.AccountNumber, A.AccountCurrency, B.Balance
		FROM
		(
			SELECT DISTINCT BranchCode, AccountNumber, AccountCurrency
			FROM ForeignExchangeAccountDefinition
			WHERE AccountCurrency <> @BaseCurrency AND ClearingCurrency = @BaseCurrency
		) A
		INNER JOIN AccountBalance B
		ON A.AccountNumber = B.AccountNumber
		INNER JOIN AccountChart D
		ON A.AccountNumber = D.AccountNumber
	) Position ON Equivalent.BranchCode = Position.BranchCode AND Equivalent.ClearingCurrency = Position.AccountCurrency
	INNER JOIN
	(
		--Exchange rate. Su dung V_FXRATE.
		SELECT A.CurrencyCode, A.BaseCurrencyRate
		FROM [o9fx].[dbo].[ForeignExchangeRate] A
		INNER JOIN
		(
			SELECT A.CurrencyCode, A.ExchangeRateType, CAST(A.ValueDate AS DATE) ValueDate, A.BranchCode, MAX(A.RateSequence) RateSequence
			FROM [o9fx].[dbo].[ForeignExchangeRate] A
			INNER JOIN
			(
				SELECT CurrencyCode, ExchangeRateType, BranchCode, MAX(CAST(ValueDate AS DATE)) ValueDate
				FROM [o9fx].[dbo].[ForeignExchangeRate]
				GROUP BY CurrencyCode, ExchangeRateType, BranchCode
			) B
			ON A.CurrencyCode = B.CurrencyCode AND A.ExchangeRateType = B.ExchangeRateType AND A.BranchCode = B.BranchCode AND CAST(A.ValueDate AS DATE) = B.ValueDate
			GROUP BY A.CurrencyCode, A.ExchangeRateType, A.BranchCode, CAST(A.ValueDate AS DATE)
		) B
		ON A.CurrencyCode = B.CurrencyCode AND A.ExchangeRateType = B.ExchangeRateType AND CAST(A.ValueDate AS DATE) = B.ValueDate AND A.BranchCode = B.BranchCode AND A.RateSequence = B.RateSequence
		WHERE A.ExchangeRateType = 'BK' AND A.BranchCode = @HostBranch
	) Rate ON Position.AccountCurrency = Rate.CurrencyCode
	WHERE (Equivalent.Balance <> 0 OR Position.Balance <> 0) AND Position.Balance*BaseCurrencyRate <> Equivalent.Balance
	ORDER BY Position.BranchCode

-- Insert GL entries
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
	--Debit Entry
	SELECT
		@TransactionNumber,
		'',
		NewID(),
		'',
		CASE WHEN CreditAccountType = 'G' THEN EquivalentAccount WHEN CreditAccountType = 'L' THEN GainLossAccount END,
		'D',
		'N',
		Amount,
		PositionBranch,
		@BaseCurrency,
		@WorkingDate,
		0,
		CASE WHEN CreditAccountType = 'G' THEN 1 WHEN CreditAccountType = 'L' THEN 2 END
	FROM
	(
		SELECT			
			EquivalentAccount, --PGACC
			CASE				
				WHEN Amount < 0 THEN 'L' --Loss				
				ELSE 'G' -- Gain
			END	CreditAccountType, --CACTYPE
			ABS(Amount) Amount, --PGACC
			CASE
				WHEN Amount < 0 THEN dbo.ACCOUNT_COMMON('FXLOSS', PositionBranch, @BaseCurrency) --Loss				
				ELSE dbo.ACCOUNT_COMMON('FXGAIN', PositionBranch, @BaseCurrency) --Gain
			END	GainLossAccount, --PGOACC
			'FX Revaluation for ' + PositionAccount [Description], --DESCS
			PositionBranch
		FROM @ListThread
		WHERE ABS(Amount) > 0
	) DebitEntries
	UNION
	--Credit Entry
	SELECT
		@TransactionNumber,
		'',
		NewID(),
		'',
		CASE WHEN CreditAccountType = 'G' THEN GainLossAccount WHEN CreditAccountType = 'L' THEN EquivalentAccount END,
		'C',
		'N',
		Amount,
		PositionBranch,
		@BaseCurrency,
		@WorkingDate,
		0,
		CASE WHEN CreditAccountType = 'G' THEN 1 WHEN CreditAccountType = 'L' THEN 2 END
	FROM
	(
		SELECT			
			EquivalentAccount, --PGACC
			CASE				
				WHEN Amount < 0 THEN 'L' --Loss				
				ELSE 'G' -- Gain
			END	CreditAccountType, --CACTYPE
			ABS(Amount) Amount, --PGACC
			CASE
				WHEN Amount < 0 THEN dbo.ACCOUNT_COMMON('FXLOSS', PositionBranch, @BaseCurrency) --Loss				
				ELSE dbo.ACCOUNT_COMMON('FXGAIN', PositionBranch, @BaseCurrency) --Gain
			END	GainLossAccount, --PGOACC
			'FX Revaluation for ' + PositionAccount [Description], --DESCS
			PositionBranch
		FROM @ListThread
		WHERE ABS(Amount) > 0
	) CreditEntries
COMMIT TRANSACTION

END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
    THROW
END CATCH
GO
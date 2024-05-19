USE [o9accounting]
GO

IF OBJECT_ID('[B_ACT_MOVEPLTORL_EXEC]', 'P') IS NOT NULL
BEGIN
    -- The procedure exists
    DROP PROCEDURE B_ACT_MOVEPLTORL_EXEC;
END;
GO

CREATE PROCEDURE [dbo].[B_ACT_MOVEPLTORL_EXEC] (
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
DECLARE @BatchStepName VARCHAR(100) = 'B_ACT_MOVEPLTORL_EXEC';

BEGIN TRY

DECLARE @ListThread TABLE (
    AccountNumber VARCHAR(100),			--SDATA1	PGACC
    AccountGroup VARCHAR(1),			--SDATA2	CACTYPE
    CurrencyCode VARCHAR(3),			--SDATA3	CCCR
    Balance DECIMAL(24, 5) DEFAULT 0,	--NDATA1	PGAMT
    BranchCode VARCHAR(5)				--NDATA2
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
	SELECT C.AccountNumber, C.AccountGroup, C.CurrencyCode, B.Balance, C.BranchCode
	FROM AccountChart C INNER JOIN AccountBalance B ON C.AccountNumber = B.AccountNumber
	WHERE C.AccountGroup = 'L' AND B.Balance <> 0

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
		CASE WHEN Balance > 0 THEN AccountNumber ELSE ProfitLossAccount END AccountNumber,
		'D',
		'N',
		ABS(Balance),
		BranchCode,
		CurrencyCode,
		@WorkingDate,
		0,
		1
	FROM
	(
		SELECT			
			AccountNumber, --PGACC
			dbo.ACCOUNT_COMMON('RETAIL_EARNINGS', BranchCode, CurrencyCode) ProfitLossAccount, --PGOACC
			AccountGroup, --CACTYPE
			Balance, --PGAMT
			'Profit&loss move to retail_earnings' [Description], --DESCS
			CurrencyCode, --CCCR
			BranchCode
		FROM @ListThread
		WHERE ABS(Balance) > 0
	) DebitEntries
	UNION
	--Credit Entry
	SELECT
		@TransactionNumber,
		'',
		NewID(),
		'',
		CASE WHEN Balance > 0 THEN ProfitLossAccount ELSE AccountNumber END AccountNumber,
		'C',
		'N',
		ABS(Balance),
		BranchCode,
		CurrencyCode,
		@WorkingDate,
		0,
		1
	FROM
	(
		SELECT			
			AccountNumber, --PGACC
			dbo.ACCOUNT_COMMON('RETAIL_EARNINGS', BranchCode, CurrencyCode) ProfitLossAccount, --PGOACC
			AccountGroup, --CACTYPE
			Balance, --PGAMT
			'Profit&loss move to retail_earnings' [Description], --DESCS
			CurrencyCode, --CCCR
			BranchCode
		FROM @ListThread
		WHERE ABS(Balance) > 0
	) CreditEntries
COMMIT TRANSACTION

END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
    THROW
END CATCH
GO

use o9deposit;
GO
-- Repay due interest of a CASA account
IF OBJECT_ID('[DPT_DEBIT_ACCOUNT]', 'P') IS NOT NULL
BEGIN
    drop procedure DPT_DEBIT_ACCOUNT;
END;
GO 
CREATE PROCEDURE DPT_DEBIT_ACCOUNT
(
	@TransactionNumber VARCHAR(36),
    @WorkingDate DATE,
    @StepName NVARCHAR(200),
	@AccountNumber NVARCHAR(100),
	@DebitAmount decimal(24, 5),
    @RefId NVARCHAR(200) = ''
)
AS
begin

	Declare @TransCode varchar(100) = 'DPT_DEBIT_BALANCE';

	-- update Master account
	update DepositAccount
	set CurrentBalance = CurrentBalance - @DebitAmount
	where AccountNumber = @AccountNumber;

	-- update statement
	declare @CurrencyCode varchar(100) = (select Currencycode From DepositAccount where AccountNumber=@AccountNumber);
	exec DPT_CREATE_STATEMENT
		@TransactionNumber = @TransactionNumber,
		@WorkingDate =@WorkingDate,
		@AccountNumber = @AccountNumber,
		@Amount =@DebitAmount,
		@CurrencyCode = @CurrencyCode,
		@StatementCode = 'WDR',
		@StatementStatus = 'N',
		@TransactionCode = @StepName,
		@Description = @StepName,
		@Refnum = NULL,
        @RefId = @RefId

	-- Update MasterTrans
	insert into [DepositAccountTrans]
		(
			[TransId], [TransactionNumber], [DepositAccount], [TransCode], [TransactionStatus], [Amount], [GLPopulated]
		)
		values
		(
			NewID(),
			@TransactionNumber --[TransactionNumber]
			, @AccountNumber  -- [DepositAccount]
			, @TransCode -- [TransCode]
			, 'N' -- [TransactionStatus]
			, @DebitAmount -- [Amount]
			, 0 -- [GLPopulated]
		);

END; 
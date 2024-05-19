use [o9accounting];

IF OBJECT_ID('[B_ACT_CVS_EXEC]', 'P') IS NOT NULL
BEGIN
    -- The procedure exists
    DROP PROCEDURE B_ACT_CVS_EXEC;
END;
GO

Create procedure [dbo].[B_ACT_CVS_EXEC] (
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
    @ChannelID NVARCHAR(200) = 'C'
)
AS
DECLARE @current_working_date DATE = @WorkingDate;

DECLARE @StartTime DATE = GETUTCDATE();

DECLARE @BatchStepName VARCHAR(100) = 'B_ACT_CVS_EXEC';

DECLARE @BaseCurrency VARCHAR(100);
DECLARE @ShortCurrencyID VARCHAR(100);
DECLARE @HostBranch VARCHAR(100);

DECLARE @ListOfAccount TABLE (
    Id INT identity(1, 1),
    DebitAccount VARCHAR(100),
    CreditAccount VARCHAR(100),
    Balance DECIMAL(24,5),
	BaseCurrencyRate DECIMAL(24,5)
);
BEGIN TRY
BEGIN TRANSACTION;

SELECT @BaseCurrency = Value from [dbo].[Setting] where Name = 'AccountingSettings.CurrentBaseCurrency';
SELECT @ShortCurrencyID = ShortCurrencyID FROM [o9admin].[dbo].[Currency] WHERE CurrencyId = @BaseCurrency;
select @HostBranch = Value from [o9admin].[dbo].[Setting] where Name = 'AdminSetting.HostBranch';

EXEC [dbo].[CREATE_TRANSACTION] @TransactionNumber = @TransactionNumber,
        @WorkingDate = @WorkingDate,
        @UserCode = @UserCode,
        @UserName = @UserName,
        @BatchDate = @BatchDate,
        @StepName = @StepName,
        @ReferenceId = @ReferenceId,
        @RefId = @RefId,
        @TranId = @TranId,
        @Description = @Description,
        @BusinessCode = @BusinessCode,
        @ChannelID = @ChannelID;

		INSERT INTO @ListOfAccount (DebitAccount, CreditAccount, Balance, BaseCurrencyRate)
		select 
			C.AccountNumber DebitAccount,
			SUBSTRING(C.AccountNumber, 1, 16) + @ShortCurrencyID CreditAccount,
			B.Balance Balance,
			F.BaseCurrencyRate BaseCurrencyRate
		from [dbo].[AccountChart] C 
		inner join [dbo].[AccountBalance] B
		on C.AccountNumber = B.AccountNumber
		inner join 
			(select * from [o9fx].[dbo].[ForeignExchangeRate] where ExchangeRateType = 'BK' and BranchCode = @HostBranch) F
		on C.CurrencyCode = f.CurrencyCode
		where c.CurrencyCode <> @BaseCurrency and f.ExchangeRateType = 'BK' and c.JobProcessOption in ('C', 'F') and b.Balance <> 0;

		-- insert table GL entries
		DECLARE @TableName VARCHAR(100) = '';

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
			-- Debit entry
			select @TransactionNumber, -- [TransactionNumber]
			@TableName, --[TransTableName]
			NEWID(), -- [TransId]
			'' SysAccountName, -- [SysAccountName] Notice******
			case when lst.Balance>0 then lst.DebitAccount else lst.CreditAccount end GLAccount, -- [GLAccount]
			'D', --[DorC] Notice******
			'N', --[TransactionStatus],
			case when lst.Balance>0 then lst.Balance else ABS(round(lst.Balance*lst.BaseCurrencyRate,2)) end Amount,
			account.BranchCode,
			account.CurrencyCode,
			trans.ValueDate,
			0 AS [Posted]
			from @ListOfAccount lst
			inner join [dbo].[AccountChart] account on account.AccountNumber = (case when lst.Balance>0 then lst.DebitAccount else lst.CreditAccount end)
			inner join [dbo].[Transaction] trans on @TransactionNumber = trans.TransactionNumber
	union
			-- Credit entry
			select @TransactionNumber, -- [TransactionNumber]
			@TableName,  --[TransTableName]
			NEWID(),  -- [TransId]
			'' SysAccountName, -- [SysAccountName] Notice******
			case when lst.Balance<0 then lst.DebitAccount else lst.CreditAccount end GLAccount,  -- [GLAccount]
			'C',--[DorC] Notice****** 
			'N',--[TransactionStatus]
			case when lst.Balance<0 then -lst.Balance else round(lst.Balance*lst.BaseCurrencyRate,2) end Amount,
			account.BranchCode,
			account.CurrencyCode,
			trans.ValueDate,
			0 AS [Posted]
			from @ListOfAccount lst
			inner join [dbo].[AccountChart] account on account.AccountNumber = (case when lst.Balance<0 then lst.DebitAccount else lst.CreditAccount end)
			inner join [dbo].[Transaction] trans on @TransactionNumber = trans.TransactionNumber
COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    throw;
END CATCH;
use o9deposit;
GO

IF OBJECT_ID('[B_DPT_ERL_EXEC]', 'P') IS NOT NULL
BEGIN
    -- The procedure exists
    DROP PROCEDURE B_DPT_ERL_EXEC
;
END;
GO

CREATE PROCEDURE dbo.[B_DPT_ERL_EXEC]
    (
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
BEGIN TRY

DECLARE @current_working_date DATE = @WorkingDate;
DECLARE @StartTime DATE = GETUTCDATE();
DECLARE @BatchStepName VARCHAR(100) = @StepName;

BEGIN TRANSACTION;

-- Create transaction
EXEC CREATE_TRANSACTION @TransactionNumber = @TransactionNumber,
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

-- Update DepositAccount
UPDATE DepositAccount
SET EarmarkBookAmount = EarmarkBookAmount - (earmark.Amount - earmark.ClearingAmount)
FROM DepositAccount account
    inner join DepositEarmark earmark on account.AccountNumber = earmark.AccountNumber
WHERE  ((earmark.ExpiredDate = @WorkingDate) or (account.EndOfTenor = @WorkingDate and account.Rollover = 'N' and account.DepositType = 'T')) AND earmark.Amount > earmark.ClearingAmount;

-- Insert into DepositHistory
DECLARE @Stcode varchar(30);
SELECT @Stcode = ISNULL(TransactionType, '-') 
FROM o9admin.dbo.TransactionDefinition td 
WHERE TransactionCode = 'DPT_ERL';
INSERT INTO DepositHistory
    ([AccountNumber], [ValueDate], [RefId], [TransactionDate], [TransactionCode], [Amount], [Dorc], [Description], [UsrCode], [Oder], [DepositHistoryStatus], [Stcode], [Usrid], [ChannelId])
Select
    account.AccountNumber -- [AccountNumber]
	, @WorkingDate -- [ValueDate]
	, @RefId -- [RefId]
	, GETUTCDATE() -- [TransactionDate]
	, @StepName -- [TransactionCode]
	, 0 -- [Amount]
	, 'D' -- [Dorc]
	, @StepName + ': Auto Release hold balance for account [' + account.AccountNumber + ']' -- [Description]
	, @UserCode -- [UsrCode]
	, 1 -- [Oder]
	, 'N' -- [DepositHistoryStatus] 
	, @Stcode -- [Stcode]
	, 0 --[Usrid]
	, @ChannelID
-- [ChannelId]
FROM DepositAccount account
    inner join DepositEarmark earmark on account.AccountNumber = earmark.AccountNumber
WHERE  ((earmark.ExpiredDate = @WorkingDate) or (account.EndOfTenor = @WorkingDate and account.Rollover = 'N' and account.DepositType = 'T')) AND earmark.Amount > earmark.ClearingAmount;
-- Update DepositEarmark
UPDATE DepositEarmark
SET ClearingAmount = Amount,
		ClearingDate = @WorkingDate,
		UserRelease = @UserCode
FROM DepositEarmark earmark
    inner join DepositAccount account on account.AccountNumber = earmark.AccountNumber
WHERE ((earmark.ExpiredDate = @WorkingDate) or (account.EndOfTenor = @WorkingDate and account.Rollover = 'N' and account.DepositType = 'T')) AND earmark.Amount > earmark.ClearingAmount;

COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    throw;
END CATCH;
GO
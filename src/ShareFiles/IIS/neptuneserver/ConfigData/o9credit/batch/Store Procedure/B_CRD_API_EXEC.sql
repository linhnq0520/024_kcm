use o9credit;
GO

IF OBJECT_ID('[B_CRD_API_EXEC]', 'P') IS NOT NULL
BEGIN
    -- The procedure exists
    DROP PROCEDURE [B_CRD_API_EXEC];
END;
GO


CREATE PROCEDURE [dbo].[B_CRD_API_EXEC] (
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
BEGIN TRY

DECLARE @current_working_date DATE = @WorkingDate;
DECLARE @StartTime DATE = GETUTCDATE();
DECLARE @BatchStepName VARCHAR(100) = 'B_CRD_API_EXEC';

Declare @TransCode varchar(100)= 'IFC_IPAY'; 
DECLARE @AccountNumber varchar(50);
DECLARE @Amount decimal(24, 5);

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
INSERT INTO [dbo].[CreditIFCBalanceTrans]([TransId], [TransactionNumber], [CreditAccount], [IFCCode], [TransCode], [ClassificationStatus], [TransactionStatus], [Amount], [GLPopulated], [CrossBranchCode], [CrossCurrencyCode], [BaseCurrencyAmount])
SELECT
	NewID() as [TransId]
	, @TransactionNumber as [TransactionNumber]
	, account.AccountNumber as [CreditAccount]
	, ifcbal.[IFCCode] as [IFCCode]
	, @TransCode as [TransCode] -- 'IFC_IPAY'
	, account.ClassificationStatus as  [CurrentClassificationStatus]
	, 'N' as  [TransactionStatus]
	, Least(account.InterestDue, account.InterestPrepaid) as [Amount] 
	, 0 as  [GLPopulated]
	, null as  [CrossBranchCode]
	, null as  [CrossCurrencyCode]
	, 0 as  [BaseCurrencyAmount]
FROM CreditIFCBalance ifcbal
	inner join CreditAccount account on ifcbal.AccountNumber=account.AccountNumber
    inner join [CreditIFCDefinition] def on ifcbal.IfcCode = def.IfcCode
WHERE ifcbal.IfcBalanceStatus = 'N'
    and def.IfcSubType = 'IN'
	and account.Crdsts NOT IN (1, 7) -- <> Closed, Legal
	and account.InterestPrepaid > 0 and account.InterestDue > 0; -- have prepaid interest and interest due

-- Create GL entries
exec dbo.GenerateGLEntriesFromCreditIFCBalanceTrans
	@TransactionNumber=null;

-- update IFCBalance.Amtpbl (Interest receiable), IFC level
UPDATE CreditIFCBalance
set Amtpbl = balance.Amtpbl - trans.Amount,
    Amount = balance.Amount - trans.Amount,
    Paid = balance.Paid + trans.Amount
from CreditIFCBalance balance
	 inner join [CreditIFCBalanceTrans] trans on balance.AccountNumber = trans.CreditAccount and balance.IfcCode = trans.IFCCode
	 inner join [CreditIFCDefinition] def on trans.IFCCode = def.IfcCode and def.IfcSubType = 'IN'
	 inner join CreditAccount account on trans.CreditAccount = account.AccountNumber and account.Crdsts NOT IN (1, 7) -- <> Closed, Legal
where trans.TransactionNumber = @TransactionNumber;

-- Update Credit account level
UPDATE CreditAccount
SET InterestPrepaid = InterestPrepaid - trans.Amount,
    InterestDue = InterestDue - trans.Amount,
    InterestPaid = InterestPaid + trans.Amount
from CreditIFCBalance balance
	 inner join [CreditIFCBalanceTrans] trans on balance.AccountNumber = trans.CreditAccount and balance.IfcCode = trans.IFCCode
	 inner join [CreditIFCDefinition] def on trans.IFCCode = def.IfcCode and def.IfcSubType = 'IN'
	 inner join CreditAccount account on trans.CreditAccount = account.AccountNumber and account.Crdsts  NOT IN (1, 7) -- <> Closed, Legal
where trans.TransactionNumber = @TransactionNumber;

-- Update Credit schedule
DECLARE accountCursor CURSOR 
FOR 
SELECT trans.CreditAccount, trans.Amount
from CreditIFCBalance balance
	 inner join [CreditIFCBalanceTrans] trans on balance.AccountNumber = trans.CreditAccount and balance.IfcCode = trans.IFCCode
	 inner join [CreditIFCDefinition] def on trans.IFCCode = def.IfcCode and def.IfcType = 'I'
	 inner join CreditAccount account on trans.CreditAccount = account.AccountNumber and account.Crdsts NOT IN (1, 7) -- <> Closed, Legal
where trans.TransactionNumber = @TransactionNumber;

OPEN accountCursor;
FETCH NEXT FROM accountCursor INTO @AccountNumber, @Amount;

WHILE @@FETCH_STATUS = 0
BEGIN 
    EXEC Update_Schedule @AccountNumber = @AccountNumber, @Rptype = 'I', @Amount = @Amount;
    FETCH NEXT FROM accountCursor INTO @AccountNumber, @Amount;
END;

CLOSE accountCursor;
DEALLOCATE accountCursor;


COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    throw;
END CATCH;
GO

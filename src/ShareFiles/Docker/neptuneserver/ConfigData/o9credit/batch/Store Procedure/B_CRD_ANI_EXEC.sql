use o9credit;
GO

IF OBJECT_ID('[B_CRD_ANI_EXEC]', 'P') IS NOT NULL
BEGIN
    -- The procedure exists
    DROP PROCEDURE B_CRD_ANI_EXEC;
END;
GO

CREATE PROCEDURE [dbo].[B_CRD_ANI_EXEC]
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
    @ChannelID NVARCHAR(200) = NULL
)
AS
BEGIN TRY

DECLARE @current_working_date DATE = @WorkingDate;
DECLARE @StartTime DATE = GETUTCDATE();
DECLARE @BatchStepName VARCHAR(100) = 'B_CRD_ANI_EXEC';

Declare @TransCode varchar(100)= 'IFC_IACR'; -- Interest Accrual Code

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

-- Main processing code here (Master Trans)
INSERT INTO [dbo].[CreditIFCBalanceTrans]
    ([TransId], [TransactionNumber], [CreditAccount], [IFCCode], [TransCode], [ClassificationStatus], [TransactionStatus], [Amount], [GLPopulated], [CrossBranchCode], [CrossCurrencyCode], [BaseCurrencyAmount])
SELECT
    NewID() as [TransId]
	, @TransactionNumber as  [TransactionNumber]
	, account.AccountNumber as [CreditAccount]
	, ifcbal.[IFCCode] as [IFCCode]
	, case when def.IfcType = 'I' then 'IFC_IACR' when def.IfcType = 'F' then (case when def.IfcSubType ='PI' then 'FEE_PENALTY_INT' when def.IfcSubType ='PP' then 'FEE_PENALTY_PRIN' end) end as [TransCode] -- 'IFC_IACR'
	, account.ClassificationStatus as  [CurrentClassificationStatus]
	, 'N' as  [TransactionStatus]
	, round(Amount - Amtpbl, 2) as [Amount] -- Today receivable interest amount
	, 0 as  [GLPopulated]
	, null as  [CrossBranchCode]
	, null as  [CrossCurrencyCode]
	, 0 as  [BaseCurrencyAmount]
FROM [CreditIFCBalance] ifcbal
    inner join CreditAccount account on ifcbal.AccountNumber=account.AccountNumber
    inner join [CreditIFCDefinition] def on ifcbal.IFCCode = def.IfcCode
WHERE ifcbal.IfcBalanceStatus = 'N'
    and account.Crdsts NOT IN (1, 7) -- <> Closed, Legal
    and round(ifcbal.Amount - ifcbal.Amtpbl, 2) > 0; -- Have accrual interest

-- Create GL entries
exec dbo.GenerateGLEntriesFromCreditIFCBalanceTrans
	@TransactionNumber=null;

-- Update Receivable Interest to Credit account level
UPDATE CreditAccount
SET InterestPayable = InterestPayable + Amount -- Sum up from IFC level
FROM CreditAccount account
    inner join (
		 select CreditAccount, round(sum(amount), 5) as amount
    from [CreditIFCBalanceTrans] trans
        INNER JOIN CreditIFCDefinition def on trans.IfcCode = def.IfcCode
    where TransactionNumber = @TransactionNumber and def.IfcType = 'I'
    -- today records
    group by CreditAccount
	 ) trans on account.AccountNumber = trans.CreditAccount;

-- update IFCBalance.Amtpbl (Interest receiable), IFC level

UPDATE CreditIFCBalance
set Amtpbl = balance.Amtpbl + trans.Amount
from [CreditIFCBalance] balance
    inner join (
		 select CreditAccount, IfcCode, round(sum(amount), 5) as amount
    from [CreditIFCBalanceTrans]
    where TransactionNumber = @TransactionNumber
    -- today records
    group by CreditAccount, IfcCode
	 ) trans on balance.AccountNumber = trans.CreditAccount and balance.IfcCode = trans.IFCCode;


COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    throw;
END CATCH;
GO


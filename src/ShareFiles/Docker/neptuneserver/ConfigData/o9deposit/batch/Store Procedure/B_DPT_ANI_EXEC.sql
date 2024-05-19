use o9deposit;
GO

IF OBJECT_ID('[B_DPT_ANI_EXEC]', 'P') IS NOT NULL 
BEGIN DROP PROCEDURE B_DPT_ANI_EXEC;
END;
GO 

CREATE PROCEDURE [dbo].[B_DPT_ANI_EXEC] (
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
    ) AS
DECLARE @current_working_date DATE = @WorkingDate;
DECLARE @StartTime DATE = GETUTCDATE();
DECLARE @BatchStepName VARCHAR(100) = 'B_DTP_ANI_EXEC';
DECLARE @InterestCalculation_BatchStepName VARCHAR(100) = 'B_DPT_DIC_EXEC';
Declare @TransCode varchar(100) = 'IFC_IACR';
-- Interest Accrual Code
BEGIN TRY BEGIN TRANSACTION;
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
-- Main processing code here (create master trans)
INSERT INTO [DepositIFCBalanceTrans](
        [TransId],
        [TransactionNumber],
        [DepositAccount],
        [IFCCode],
        [TransCode],
        [TransactionStatus],
        [Amount],
        [GLPopulated],
        [CrossBranchCode],
        [CrossCurrencyCode],
        [BaseCurrencyAmount]
    )
SELECT NewID() as [TransId],
    @TransactionNumber as [TransactionNumber],
    account.AccountNumber as [DepositAccount],
    ifcbal.[IFCCode] as [IFCCode],
    @TransCode as [TransCode],
    'N' as [TransactionStatus],
    round(Amount - Amtpbl, 2) as [Amount] -- round 2 decimals for posting
,
    0 as [GLPopulated],
    null as [CrossBranchCode],
    null as [CrossCurrencyCode],
    0 as [BaseCurrencyAmount]
FROM IFCBalance ifcbal
    inner join DepositAccount account on ifcbal.AccountNumber = account.AccountNumber
WHERE ifcbal.IfcBalanceStatus = 'N'
    and account.DepositStatus <> 'C' -- <> Closed
    and ROUND(Amount, 2) - Amtpbl > 0;
-- Have accrual interest
-- Create GL entries
exec GenerateGLEntriesFromDepositIFCBalanceTrans @TransactionNumber = null;
-- null: Generate to all un-populated rows
-- update to IFC level, today interest
Update IFCBalance
set Amtpbl = balance.Amtpbl + trans.Amount
from IFCBalance balance
    inner join [DepositIFCBalanceTrans] trans on balance.AccountNumber = trans.DepositAccount
    and balance.IfcCode = trans.IFCCode
where trans.TransactionNumber = @TransactionNumber;
-- today records
-- Update Interest Payable at account level
UPDATE dbo.DepositAccount
SET Intpbl = ROUND(InterestAccrual, 2)
WHERE InterestAccrual <> 0;
COMMIT TRANSACTION;
END TRY BEGIN CATCH ROLLBACK TRANSACTION;
throw;
END CATCH;
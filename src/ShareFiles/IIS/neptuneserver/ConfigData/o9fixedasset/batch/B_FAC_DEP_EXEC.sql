use o9fixedasset;
GO

IF OBJECT_ID('[B_FAC_DEP_EXEC]', 'P') IS NOT NULL
BEGIN
    -- The procedure exists
    DROP PROCEDURE [B_FAC_DEP_EXEC];
END;
GO


CREATE PROCEDURE [dbo].[B_FAC_DEP_EXEC]
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
DECLARE @BatchStepName VARCHAR(100) = 'B_FAC_DEP_EXEC';

Declare @TransCode varchar(100)= 'CREDIT_EXPENSE'; 

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
INSERT INTO [dbo].[FixedAssetAccountTrans]
    ([TransId], [TransactionNumber], [FixedAssetAccount], [TransCode], [TransactionStatus], [Amount], [GLPopulated], [CrossBranchCode], [CrossCurrencyCode], [BaseCurrencyAmount])
SELECT
    NewID() as [TransId]
	, @TransactionNumber as  [TransactionNumber]
	, fac.AccountNumber as [FixedAssetAccount]
	, @TransCode as [TransCode] -- 'IFC_IACR'
	, 'N' as  [TransactionStatus]
	, CASE DepreciationMethod WHEN 'B' THEN AccummulateAmount - ExpenseAmount
        WHEN 'F' THEN 
        CASE WHEN NetBookingValue <= SalvageAmount THEN NetBookingValue 
        ELSE ROUND((DepreciationRate * BookingAmount / 100)/12, 2) 
        END 
      END as [Amount]
	, 0 as  [GLPopulated]
	, null as  [CrossBranchCode]
	, null as  [CrossCurrencyCode]
	, 0 as  [BaseCurrencyAmount]
FROM FixedAssetAccount fac
WHERE FixedAssetStatus = 'N'
    AND (NetBookingValue > 0 OR (DepreciationMethod = 'B' AND AccummulateAmount - ExpenseAmount > 0)
    OR (DepreciationMethod = 'F' AND (
            (NetBookingValue <= SalvageAmount AND NetBookingValue > 0)
    OR (NetBookingValue > SalvageAmount AND Round((DepreciationRate * BookingAmount / 100)/12, 2) > 0))));

-- Create GL entries
exec dbo.GenerateGLEntriesFromFixedAssetTrans
	@TransactionNumber = null;

UPDATE FixedAssetAccount 
SET ExpenseAmount = ExpenseAmount + trans.Amount
FROM FixedAssetAccount fac
    INNER JOIN FixedAssetAccountTrans trans ON fac.AccountNumber = trans.FixedAssetAccount 
WHERE trans.TransactionNumber = @TransactionNumber;

-- Final step: update executing duration
UPDATE [Transaction]
SET Duration = DATEDIFF_BIG(ms, @StartTime, GETUTCDATE())
WHERE TransactionNumber = @TransactionNumber;

COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    throw;
END CATCH;
GO

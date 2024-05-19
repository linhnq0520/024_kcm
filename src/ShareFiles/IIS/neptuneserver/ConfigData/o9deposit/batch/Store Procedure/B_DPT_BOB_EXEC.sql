use o9deposit;

IF OBJECT_ID('[B_DPT_BOB_EXEC]', 'P') IS NOT NULL
BEGIN
    -- The procedure exists
    DROP PROCEDURE B_DPT_BOB_EXEC
;
END;
GO


CREATE PROCEDURE [dbo].[B_DPT_BOB_EXEC] (
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

DECLARE @BatchStepName VARCHAR(100) = 'B_DPT_BOB_EXEC';

BEGIN TRY
BEGIN TRANSACTION;
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
        
        DECLARE @LengthPsts INT;
        SELECT @LengthPsts = CHARACTER_MAXIMUM_LENGTH
        FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'DepositAccount' AND COLUMN_NAME = 'Psts';

      --2. Update Dormant status for non-tenor accounts

        UPDATE dbo.DepositAccount
        SET DepositStatus = 'D',
            DormantDate = @WorkingDate,
            Psts = CASE WHEN LEN(Psts) < @LengthPsts - 1 THEN (CASE WHEN Psts IS NULL OR TRIM (Psts) = '' THEN DepositStatus ELSE Psts + '|' + DepositStatus END) ELSE SUBSTRING(Psts,3,LEN(Psts)) + '|' + DepositStatus  END
        FROM dbo.DepositAccount D
        WHERE     DepositStatus = 'N' AND (Tenor+Tenor2) = 0 AND DepositType <> 'T' AND (
       (
            CASE
                WHEN DormantPeriodUnit = 'D' THEN DATEADD(DAY, DormantPeriod, LastTransactionDate)
                WHEN DormantPeriodUnit = 'W' THEN DATEADD(DAY, DormantPeriod * 7, LastTransactionDate)
                WHEN DormantPeriodUnit = 'M' THEN DATEADD(MONTH, DormantPeriod, LastTransactionDate)
                WHEN DormantPeriodUnit = 'Q' THEN DATEADD(MONTH, DormantPeriod * 3, LastTransactionDate)
                WHEN DormantPeriodUnit = 'H' THEN DATEADD(MONTH, DormantPeriod * 6, LastTransactionDate)
                WHEN DormantPeriodUnit = 'Y' THEN DATEADD(MONTH, DormantPeriod* 12, LastTransactionDate)
            END <= @WorkingDate
        ) AND (CurrentBalance < MinimumDormantAmount OR (CurrentBalance=0 AND MinimumDormantAmount=0 )));

      --4. Update LINTDUEDT for new term deposit account
        UPDATE dbo.DepositAccount
        SET LastTransferInterestToDue = @WorkingDate
        FROM dbo.DepositAccount D
        WHERE Tenor > 0 AND OpenDate = @WorkingDate;

          --4. Update Normal Status when changed Dormant
--        UPDATE dbo.DepositAccount
--        SET DepositStatus = 'N',
--            DormantDate = NULL
--        FROM dbo.DepositAccount D
--        WHERE     DepositStatus = 'D' AND (Tenor + Tenor2) = 0 AND DepositType <> 'T' AND (
--       (
--            CASE
--                WHEN DormantPeriodUnit = 'D' THEN DATEADD(DAY, DormantPeriod, LastTransactionDate)
--                WHEN DormantPeriodUnit = 'W' THEN DATEADD(DAY, DormantPeriod * 7, LastTransactionDate)
--                WHEN DormantPeriodUnit = 'M' THEN DATEADD(MONTH, DormantPeriod, LastTransactionDate)
--                WHEN DormantPeriodUnit = 'Q' THEN DATEADD(MONTH, DormantPeriod * 3, LastTransactionDate)
--                WHEN DormantPeriodUnit = 'H' THEN DATEADD(MONTH, DormantPeriod * 6, LastTransactionDate)
--                WHEN DormantPeriodUnit = 'Y' THEN DATEADD(MONTH, DormantPeriod* 12, LastTransactionDate)
--            END > @WorkingDate
--        ) OR (CurrentBalance >= MinimumDormantAmount AND (CurrentBalance>0 OR MinimumDormantAmount>0) ) );

COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    throw;
END CATCH;
use o9deposit;

IF OBJECT_ID('[B_DPT_CWD_EXEC]', 'P') IS NOT NULL
BEGIN
    -- The procedure exists
    DROP PROCEDURE B_DPT_CWD_EXEC
;
END;
GO

CREATE PROCEDURE [dbo].[B_DPT_CWD_EXEC] (
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

DECLARE @BatchStepName VARCHAR(100) = 'B_DPT_CWD_EXEC';

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
        
        UPDATE dbo.DepositAccount
         SET MonthAverageBalance = CurrentBalance,
             QuarterAverageBalance = CurrentBalance,
             SemiAnnualAverageBalance = CurrentBalance,
             YearAverageBalance = CurrentBalance
        FROM dbo.DepositAccount
        WHERE DepositStatus = 'N' AND Tenor = 0 AND OpenDate = @WorkingDate;

COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    throw;
END CATCH;
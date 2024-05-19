use o9deposit;

IF OBJECT_ID('[B_DPT_BOD_EXEC]', 'P') IS NOT NULL
BEGIN
    -- The procedure exists
    DROP PROCEDURE B_DPT_BOD_EXEC
;
END;
GO


CREATE PROCEDURE [dbo].[B_DPT_BOD_EXEC] (
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

DECLARE @BatchStepName VARCHAR(100) = 'B_DPT_BOD_EXEC';

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
        
        --Update status to Maturity
        UPDATE  dbo.DepositAccount
        SET     DepositStatus = 'M', Psts = CASE WHEN LEN(Psts) < 499 THEN Psts + '|' + DepositStatus ELSE SUBSTRING(Psts, 2, LEN(Psts)) + '|' + DepositStatus END
        FROM dbo.DepositAccount
        WHERE  Tenor > 0 AND EndOfTenor <= @WorkingDate AND (Rollover IN ('A','N') OR (Rollover = 'P' AND InterestAccrual = 0) OR Rollover = 'P' ) AND DepositStatus NOT IN ('B' ,'C') ;

        -- Reset Amount auto fund transfer
        UPDATE dbo.AccountLinkage 
        SET Amount = 0
        WHERE LinkageClass = 'F' AND LinkageType = 'D' AND LimitAmount <> 0;

COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    throw;
END CATCH;
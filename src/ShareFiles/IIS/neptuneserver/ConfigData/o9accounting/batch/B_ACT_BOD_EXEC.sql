use o9accounting;
GO

IF OBJECT_ID('[B_ACT_BOD_EXEC]', 'P') IS NOT NULL
BEGIN
    -- The procedure exists
    DROP PROCEDURE [B_ACT_BOD_EXEC];
END;
GO


CREATE PROCEDURE [dbo].[B_ACT_BOD_EXEC] (
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
DECLARE @BatchStepName VARCHAR(100) = 'B_ACT_BOD_EXEC';
DECLARE @CurrentYear int = YEAR(@WorkingDate); 
DECLARE @IsBOQ int;
DECLARE @IsBOH int;
DECLARE @IsBOY int;

BEGIN TRANSACTION;

SET @IsBOQ = 0;
SET @IsBOH = 0;
SET @IsBOY = 0;

IF (CAST(CONCAT('01/01/', @CurrentYear) AS DATE) = @WorkingDate OR CAST(CONCAT('04/01/', @CurrentYear) AS DATE) = @WorkingDate OR CAST(CONCAT('07/01/', @CurrentYear) AS DATE) = @WorkingDate OR CAST(CONCAT('10/01/', @CurrentYear) AS DATE) = @WorkingDate) 
	SET @IsBOQ = 1;

IF (CAST(CONCAT('01/01/', @CurrentYear) AS DATE) = @WorkingDate OR CAST(CONCAT('07/01/', @CurrentYear) AS DATE) = @WorkingDate)
	SET @IsBOH = 1;

IF (CAST(CONCAT('01/01/', @CurrentYear) AS DATE) = @WorkingDate)
	SET @IsBOY = 1;

UPDATE AccountBalance 
SET     DailyDebit = 0,
        DailyCredit = 0,
        WeeklyDebit = CASE WHEN DAY(@WorkingDate) = 1 THEN 0 ELSE WeeklyDebit END,
        WeeklyCredit = CASE WHEN DAY(@WorkingDate) = 1 THEN 0 ELSE WeeklyCredit END,
				QuarterlyDebit = CASE WHEN @IsBOQ = 1 THEN 0 ELSE QuarterlyDebit END,
				QuarterlyCredit = CASE WHEN @IsBOQ = 1 THEN 0 ELSE QuarterlyCredit END,
				HalfYearlyDebit = CASE WHEN @IsBOH = 1 THEN 0 ELSE HalfYearlyDebit END,
				HalfYearlyCredit = CASE WHEN @IsBOH = 1 THEN 0 ELSE HalfYearlyCredit END,
				YearlyDebit = CASE WHEN @IsBOY = 1 THEN 0 ELSE YearlyDebit END,
				YearlyCredit = CASE WHEN @IsBOY = 1 THEN 0 ELSE YearlyCredit END;


COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    throw;
END CATCH;
GO

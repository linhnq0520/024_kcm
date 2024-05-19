use o9fixedasset;
GO

IF OBJECT_ID('[B_FAC_ACR_EXEC]', 'P') IS NOT NULL
BEGIN
    -- The procedure exists
    DROP PROCEDURE [B_FAC_ACR_EXEC];
END;
GO


CREATE PROCEDURE [dbo].[B_FAC_ACR_EXEC] (
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
DECLARE @BatchStepName VARCHAR(100) = 'B_FAC_ACR_EXEC';
DECLARE @AccountNumber VARCHAR(50);
DECLARE @BookingAmount DECIMAL(24, 5);
DECLARE @NetBookingValue DECIMAL(24, 5);
DECLARE @DepreciationRate DECIMAL(24, 5);
DECLARE @SalvageAmount DECIMAL(24, 5);
DECLARE @Dprdt DATE;
DECLARE @DailyAccumulateAmount DECIMAL(24, 5);

BEGIN TRANSACTION;

DECLARE myCursor CURSOR
FOR
SELECT AccountNumber, BookingAmount, NetBookingValue, DepreciationRate, SalvageAmount, Dprdt
FROM FixedAssetAccount acc
WHERE FixedAssetStatus = 'N' 
    and NetBookingValue > 0 
    and NetBookingValue != 1 
    and DepreciationMethod = 'B' 
    and (BookingAmount - SalvageAmount) > 0;

OPEN myCursor;

FETCH NEXT
FROM myCursor
INTO @AccountNumber, @BookingAmount, @NetBookingValue, @DepreciationRate, @SalvageAmount, @Dprdt;

WHILE @@FETCH_STATUS = 0
BEGIN
    IF (@SalvageAmount = 1)
        SET @DailyAccumulateAmount = (@BookingAmount * @DepreciationRate / 36500);
    ELSE 
        SET @DailyAccumulateAmount = ((@BookingAmount - @SalvageAmount) * @DepreciationRate / 36500);
    
    IF (DATEDIFF(DAY, @WorkingDate, @Dprdt) = 0)
        SET @DailyAccumulateAmount = @DailyAccumulateAmount;
    ELSE 
        SET @DailyAccumulateAmount = DATEDIFF(DAY, @Dprdt, @WorkingDate) * @DailyAccumulateAmount;
    
    IF (@NetBookingValue < @DailyAccumulateAmount + @SalvageAmount)
        SET @DailyAccumulateAmount = @NetBookingValue - @SalvageAmount;

    SET @DailyAccumulateAmount = Round(@DailyAccumulateAmount, 2);
    
    UPDATE FixedAssetAccount 
    SET AccummulateAmount = AccummulateAmount + @DailyAccumulateAmount,
        NetBookingValue = NetBookingValue - @DailyAccumulateAmount,
        Dprdt = @WorkingDate
    WHERE AccountNumber = @AccountNumber;

    FETCH NEXT
    FROM myCursor
    INTO @AccountNumber, @BookingAmount, @NetBookingValue, @DepreciationRate, @SalvageAmount, @Dprdt;
END;

CLOSE myCursor;
DEALLOCATE myCursor;

COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    throw;
END CATCH;
GO

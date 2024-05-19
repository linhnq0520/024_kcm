use o9credit;
GO

IF OBJECT_ID('[UPDATE_SCHEDULE]', 'P') IS NOT NULL
BEGIN
    -- The procedure exists
    DROP PROCEDURE [UPDATE_SCHEDULE];
END;
GO

CREATE PROCEDURE [dbo].[UPDATE_SCHEDULE]
(
    @AccountNumber VARCHAR(36),
    @Rptype VARCHAR(1),
    @Amount DECIMAL(24, 5)
)
AS
BEGIN

DECLARE @DueNumber int;
DECLARE @InterestAmount decimal(24, 5);
DECLARE @Temp decimal(24, 5);

DECLARE myCursor CURSOR
FOR
SELECT DueNumber, Amount - Paid
FROM CreditSchedule 
WHERE AccountNumber = @AccountNumber and Rptype = @Rptype and Amount - Paid > 0 ORDER BY DueNumber;

OPEN myCursor;
FETCH NEXT 
FROM myCursor 
INTO @DueNumber, @InterestAmount;

WHILE @@FETCH_STATUS = 0
BEGIN
    IF (@Amount <= 0) 
        BREAK;
    
    SET @Temp = LEAST(@Amount, @InterestAmount);

    UPDATE CreditSchedule 
    SET     Paid = Paid + @Temp 
    WHERE AccountNumber = @AccountNumber and Rptype = @Rptype and DueNumber = @DueNumber;

    SET @Amount = @Amount - @Temp;

    FETCH NEXT FROM myCursor INTO @DueNumber, @InterestAmount;
END;

CLOSE myCursor;

DEALLOCATE myCursor;

END;

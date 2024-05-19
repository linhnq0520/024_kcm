USE o9credit;
GO

IF OBJECT_ID('[NextDueDate]', 'FN') IS NOT NULL
BEGIN
    Drop FUNCTION [NextDueDate];
END;
GO

CREATE FUNCTION [dbo].[NextDueDate] (@AccountNumber NVARCHAR(50), @Tenor int, @TenorUnit NVARCHAR(1), @WorkingDate Date, @FromDate Date = Null,  @ToDate Date = Null)
    RETURNS Date
BEGIN
    DECLARE @DueDate Date;
    DECLARE @DueNumber Int; 

    If (@TenorUnit = 'B' Or @TenorUnit = 'E') 
        SET @DueDate = @ToDate;
    Else
        If (@Tenor > 0) 
            BEGIN
                SELECT @DueNumber = IsNull(Max(DueNumber), 0)
                FROM dbo.CreditSchedule
                WHERE AccountNumber = @AccountNumber and Rptype = 'I';

                SELECT @DueDate = CASE @TenorUnit
                    WHEN 'M' THEN DATEADD (MONTH, @Tenor * @DueNumber, @FromDate)
                    WHEN 'Q' THEN DATEADD (MONTH, @Tenor * 3 * @DueNumber, @FromDate)
                    WHEN 'H' THEN DATEADD (MONTH, @Tenor * 6 * @DueNumber, @FromDate)
                    WHEN 'Y' THEN DATEADD (MONTH, @Tenor * 12 * @DueNumber, @FromDate)
                    WHEN 'D' THEN DATEADD (DAY, @Tenor * @DueNumber, @FromDate)
                    WHEN 'W' THEN DATEADD(DAY, 7 * @Tenor * @DueNumber, @FromDate)
                END;
            END;
        Else 
            SET @DueDate = @FromDate;

    RETURN @DueDate;
END

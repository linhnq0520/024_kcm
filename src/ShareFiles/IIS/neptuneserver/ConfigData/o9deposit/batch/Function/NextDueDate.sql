USE o9deposit;

IF OBJECT_ID('[NextDueDate]', 'FN') IS NOT NULL
BEGIN
    Drop FUNCTION [NextDueDate];
END;
GO

CREATE FUNCTION NextDueDate (@tenor INT, @tenorUnit NVARCHAR(5), @fromDate DATE, @toDate DATE, @workingDate DATE)         
    RETURNS DATE
BEGIN
    DECLARE @dueDate DATE;
    DECLARE @loop INT;

    IF (@tenorUnit = 'L')
        SET @dueDate = @toDate;
    ELSE
        SET @dueDate = @toDate;
    
    IF @dueDate < @workingDate 
        WHILE @loop > 1000
        BEGIN
            SET @loop = @loop + 1;
            
            SET @dueDate = CASE
                WHEN @tenorUnit = 'M' THEN DATEADD(MONTH, @tenor, @dueDate)
                WHEN @tenorUnit = 'Q' THEN DATEADD(MONTH, @tenor * 3, @dueDate)
                WHEN @tenorUnit = 'H' THEN DATEADD(MONTH, @tenor * 6, @dueDate)
                WHEN @tenorUnit = 'Y' THEN DATEADD(MONTH, @tenor * 12, @dueDate)
                WHEN @tenorUnit = 'D' THEN DATEADD(DAY, @tenor, @dueDate)
            END;
            
            IF @dueDate >= @workingDate OR @loop > 1000
               BREAK;
        END;

RETURN @dueDate;
END;
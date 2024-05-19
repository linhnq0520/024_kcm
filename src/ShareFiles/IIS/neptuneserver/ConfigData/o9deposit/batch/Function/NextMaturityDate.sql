USE o9deposit;

IF OBJECT_ID('[NextMaturityDate]', 'FN') IS NOT NULL
BEGIN
    Drop FUNCTION [NextMaturityDate];
END;
GO

CREATE FUNCTION [dbo].NextMaturityDate (@tenor INT, @tenorUnit NVARCHAR(5), @date DATE)         
    RETURNS DATE
BEGIN
    DECLARE @result DATE = CAST(@date as DATE);
    IF (@date IS NOT NULL)
        SET @result = CASE
            WHEN @tenorUnit = 'M' THEN DATEADD(MONTH, @tenor, @result)
            WHEN @tenorUnit = 'Q' THEN DATEADD(MONTH, @tenor * 3, @result)
            WHEN @tenorUnit = 'H' THEN DATEADD(MONTH, @tenor * 6, @result)
            WHEN @tenorUnit = 'Y' THEN DATEADD(MONTH, @tenor * 12, @result)
            WHEN @tenorUnit = 'D' THEN DATEADD(DAY, @tenor, @result)
        END;
    IF (@date = EOMONTH(@date))
        SET @result = EOMONTH(@result);

RETURN @result;
END
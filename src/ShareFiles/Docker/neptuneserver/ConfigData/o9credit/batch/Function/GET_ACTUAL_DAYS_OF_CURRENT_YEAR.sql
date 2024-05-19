USE O9Credit;
GO

IF OBJECT_ID('[GET_ACTUAL_DAYS_OF_CURRENT_YEAR]', 'FN') IS NOT NULL
BEGIN
    Drop FUNCTION [GET_ACTUAL_DAYS_OF_CURRENT_YEAR];
END;
GO

CREATE FUNCTION [GET_ACTUAL_DAYS_OF_CURRENT_YEAR]()
RETURNS int
AS
BEGIN
	DECLARE @currentYear int = YEAR(GETDATE());

	IF((@currentYear % 4 = 0 AND @currentYear % 100 <> 0) OR @currentYear % 400 = 0)
		return 366;

	return 365;
END
GO

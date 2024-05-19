USE O9Credit;
GO

IF OBJECT_ID('dbo.MAX_INT', 'FN') IS NOT NULL
BEGIN
    Drop FUNCTION dbo.[MAX_INT];
END;
GO

CREATE FUNCTION MAX_INT
(
	-- Add the parameters for the function here
	@p1 int , @p2 int
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	if (@p1 > @p2) 
	RETURN  @p1;

	return @p2;

END
GO


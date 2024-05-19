USE o9credit;
GO

IF OBJECT_ID('[GetNewDueNumber]', 'FN') IS NOT NULL
BEGIN
    Drop FUNCTION [GetNewDueNumber];
END;
GO

CREATE FUNCTION [dbo].[GetNewDueNumber] (@AccountNumber NVARCHAR(50), @Rptype NVARCHAR(50))        
    RETURNS INT
BEGIN
    DECLARE @DueNumber INT;

    SELECT @DueNumber = ISNULL(Max(DueNumber), 0)
    FROM dbo.CreditSchedule
    WHERE AccountNumber = @AccountNumber and Rptype = @Rptype;

    RETURN @DueNumber + 1;
END

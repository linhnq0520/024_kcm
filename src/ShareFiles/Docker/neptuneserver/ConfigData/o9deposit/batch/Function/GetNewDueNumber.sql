USE o9deposit;
GO

IF OBJECT_ID('[GetNewDueNumber]', 'FN') IS NOT NULL
BEGIN
    Drop FUNCTION [GetNewDueNumber];
END;
GO

CREATE FUNCTION GetNewDueNumber (@ContractNumber NVARCHAR(50), @Rptype NVARCHAR(50))        
    RETURNS INT
BEGIN
    DECLARE @DueNumber INT;

    SELECT @DueNumber = Max(DueNumber)
    FROM dbo.ODSchedule
    WHERE ContractNumber = @ContractNumber and Rptype = @Rptype;
    IF @DueNumber is NULL
        select @DueNumber =0;

    RETURN @DueNumber + 1;
END
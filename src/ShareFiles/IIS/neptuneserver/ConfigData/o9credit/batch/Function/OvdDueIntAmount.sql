

USE o9credit; 
GO

IF OBJECT_ID('[GetCreditOvdDueIntAmount]', 'FN') IS NOT NULL
BEGIN
	Drop FUNCTION [GetCreditOvdDueIntAmount];
END;
GO

CREATE FUNCTION [dbo].[GetCreditOvdDueIntAmount] (@AccountNumber NVARCHAR(100),  @WorkingDate Date)
    RETURNS decimal(24,5)
BEGIN
	DECLARE @Amount decimal(24,5) = 0;

	SELECT @Amount = Sum(Amount - Paid)
	FROM CreditSchedule i
		INNER JOIN CreditAccount c ON i.AccountNumber = c.AccountNumber
	WHERE c.AccountNumber = @AccountNumber
		AND i.Amount - i.Paid > 0
		AND i.Rptype = 'I'
		AND DATEADD(DAY, c.InterestGracePeriod, i.DueDate) <= @WorkingDate;


	RETURN @Amount;
END

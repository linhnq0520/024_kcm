USE o9credit;
GO

IF OBJECT_ID('[GetCreditOvdDuePrinAmount]', 'FN') IS NOT NULL
BEGIN
  Drop FUNCTION [GetCreditOvdDuePrinAmount];
END;
GO

CREATE FUNCTION [dbo].[GetCreditOvdDuePrinAmount] ( @accountNumber NVARCHAR(100), @WorkingDate DATE)
RETURNS decimal(24,5)
BEGIN
  DECLARE @Amount decimal(24,5) = 0;

  SELECT @Amount = Sum(Amount - Paid)
  FROM CreditSchedule i
    INNER JOIN CreditAccount c ON i.AccountNumber = c.AccountNumber
  WHERE c.AccountNumber = @accountNumber
    AND i.Amount - i.Paid > 0
    AND i.Rptype = 'P'
    AND DATEADD(DAY, c.PrincipalGracePeriod, i.DueDate) <= @WorkingDate;

  RETURN @Amount;
END;
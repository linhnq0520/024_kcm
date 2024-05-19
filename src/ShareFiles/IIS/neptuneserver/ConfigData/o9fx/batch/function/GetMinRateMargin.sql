USE o9fx
GO

IF OBJECT_ID('[GetMinRateMargin]', 'FN') IS NOT NULL
BEGIN
    Drop FUNCTION GetMinRateMargin;
END;
GO

CREATE FUNCTION dbo.GetMinRateMargin(@CurrencyCode1 nvarchar(50), @CurrencyCode2 nvarchar(50))
RETURNS decimal
AS
BEGIN
    Declare @MinRateMargin decimal(24, 9) = (select Min(RateMargin)
    from ForeignExchangeRate
    where CurrencyCode = @CurrencyCode1 or CurrencyCode = @CurrencyCode2);
    RETURN @MinRateMargin;
END
GO
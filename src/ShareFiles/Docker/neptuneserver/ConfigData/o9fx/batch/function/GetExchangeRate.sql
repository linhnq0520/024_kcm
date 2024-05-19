USE o9fx
GO

IF OBJECT_ID('[GetExchangeRate]', 'FN') IS NOT NULL
BEGIN
    Drop FUNCTION GetExchangeRate;
END;
GO

CREATE FUNCTION dbo.GetExchangeRate(@CurrencyCode nvarchar(50), @ExchangeRateType nvarchar(50), @BranchCode nvarchar(50) = null, @ValueDate Date)
RETURNS decimal
AS
BEGIN

    -- if branch null get host branch
    if(@BranchCode is null)
	set @BranchCode = (select Value
    from Setting
    where Name = 'FXSettings.HostBranch');

    -- Get max value date and Max RateSequence
    Declare @MaxValueDate Date = (select Max(ValueDate)
    from ForeignExchangeRate
    where CurrencyCode = @CurrencyCode and ExchangeRateType = @ExchangeRateType and BranchCode = @BranchCode and Valuedate <= @ValueDate);

    Declare @MaxRateSequence int = (select Max(RateSequence)
    from ForeignExchangeRate
    where CurrencyCode = @CurrencyCode and ExchangeRateType = @ExchangeRateType and BranchCode = @BranchCode and Valuedate = @MaxValueDate);

    -- Get base currency rate
    Declare @Rate decimal (24,9) = (select Max(case when IsListed = 1 then 1/ RateSequence when IsListed = 0 then RateSequence end)
    from ForeignExchangeRate
    where CurrencyCode = @CurrencyCode and ExchangeRateType = @ExchangeRateType and BranchCode = @BranchCode and Valuedate = @MaxValueDate and RateSequence = @MaxRateSequence);

    RETURN @Rate;
END
GO
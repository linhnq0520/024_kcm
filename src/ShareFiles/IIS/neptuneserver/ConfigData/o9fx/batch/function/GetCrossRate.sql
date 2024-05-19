USE o9fx
GO

IF OBJECT_ID('[GetCrossRate]', 'FN') IS NOT NULL
BEGIN
    Drop FUNCTION GetCrossRate;
END;
GO

CREATE FUNCTION dbo.GetCrossRate(@CurrencyCode1 nvarchar(50), @CurrencyCode2 nvarchar(50), @RateType1 nvarchar(50), @RateType2 nvarchar(50), @BranchCodeFX nvarchar(50), @ValueDate Date, @DefValue decimal(24,9) = null)
RETURNS decimal
AS
BEGIN
    Declare @MarginRate decimal(24, 9) = dbo.GetMinRateMargin(@CurrencyCode2, @CurrencyCode2);
    if(@CurrencyCode1 = @CurrencyCode2)
		RETURN 1;
    Declare @BaseCur1Rate decimal(24, 9) = dbo.GetBaseCurrencyRate(@CurrencyCode1, @RateType1,@BranchCodeFX, @ValueDate);
    Declare @BaseCur2Rate decimal(24, 9) = dbo.GetBaseCurrencyRate(@CurrencyCode2, @RateType2,@BranchCodeFX, @ValueDate);

    Declare @CrossRate decimal(24, 9) = @BaseCur1Rate/@BaseCur2Rate;
    if(@DefValue is not null and @DefValue !=0)
	begin
        Declare @MinValue decimal(24, 9) = @CrossRate * (1 - @MarginRate);
        Declare @MaxValue decimal(24, 9) = @CrossRate * (1 + @MarginRate);
        if(@DefValue > @MinValue and @DefValue < @MaxValue)
			return @DefValue;
		else if(@DefValue < @MinValue)
			return @MinValue;
		else if(@DefValue > @MaxValue)
			return @MaxValue;
    end
    return @CrossRate;
END
GO
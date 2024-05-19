USE o9fx
GO

IF OBJECT_ID('[GetBaseCurrencyRate]', 'FN') IS NOT NULL
BEGIN
	Drop FUNCTION GetBaseCurrencyRate;
END;
GO

CREATE FUNCTION dbo.GetBaseCurrencyRate(@CurrencyCode nvarchar(50), @ExchangeRateType nvarchar(50), @BranchCode nvarchar(50) = null, @ValueDate Date)
RETURNS decimal
AS
BEGIN
	declare @BaseCurrenyRate decimal(24,9) = 0;
	declare @BaseCurrency nvarchar(50) = (select Value
	from Setting
	where Name = 'FXSettings.CurentBaseCurrency');
	declare  @HostBranch nvarchar(50) = (select Value
	from Setting
	where Name = 'FXSettings.HostBranch');
	if(@BranchCode is null)
	set @BranchCode = @HostBranch;

	if(@CurrencyCode = @BaseCurrency)
		RETURN 1;	
	ELSE
	begin
		set @BaseCurrenyRate = dbo.GetExchangeRate(@CurrencyCode, @ExchangeRateType, @BranchCode, @ValueDate);
		if (@BaseCurrenyRate = 0 or @BaseCurrenyRate is null)
			set @BaseCurrenyRate = dbo.GetExchangeRate(@CurrencyCode, @ExchangeRateType, @HostBranch, @ValueDate);
	end
	RETURN @BaseCurrenyRate;
END
GO
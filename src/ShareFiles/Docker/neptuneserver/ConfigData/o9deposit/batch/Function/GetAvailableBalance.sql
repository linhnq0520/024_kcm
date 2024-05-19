USE o9deposit;
GO

IF OBJECT_ID('[GetAvailableBalance]', 'FN') IS NOT NULL
BEGIN
	Drop FUNCTION [GetAvailableBalance];
END;
GO

CREATE FUNCTION dbo.GetAvailableBalance (@AccountNumber NVARCHAR(100), @WorkingDate DATE, @IsBlockAmount BIT = 1)        
    RETURNS DECIMAL(24,6)
BEGIN
	DECLARE @AvailableBalance DECIMAL(24,6) = 0;
	DECLARE @DepositGroup NVARCHAR(20);
	DECLARE @BlockAmount DECIMAL(24,6) = 0;
	DECLARE @MinimumDepositAmount DECIMAL(24,6) = 0;

	SELECT @DepositGroup = DepositGroup, @MinimumDepositAmount = MinimumDepositAmount
	FROM dbo.DepositAccount
	WHERE AccountNumber = @AccountNumber;
	if(@DepositGroup != '23') -- != MASTER_FD_ACCOUNT
	begin
		SELECT @AvailableBalance = account.CurrentBalance - account.EarmarkBookAmount + (case when odContract.OdLimit is null then 0 else odContract.OdLimit end)
		from dbo.DepositAccount account
			left join (select AccountNumber, OdLimit
			from dbo.OverdraftContract
			WHERE ContractStatus = 0 and (CAST(@WorkingDate AS DATE) <= CAST(ToDate AS DATE)) and (CAST(@WorkingDate AS DATE) >= CAST(FromDate AS DATE))) odContract on account.AccountNumber = odContract.AccountNumber
		where account.AccountNumber = @AccountNumber;
	end;

	if(@DepositGroup = '23') -- MASTER_FD_ACCOUNT
	begin
		SELECT @AvailableBalance = CurrentBalance - EarmarkBookAmount
		from dbo.DepositAccountMFA
		where AccountNumber = @AccountNumber;
	end;

	if(@IsBlockAmount = 1 and @AvailableBalance - @MinimumDepositAmount > 0)
	begin
		select @BlockAmount = Sum(Amount)
		from dbo.IFCBalance bal inner join DepositIFCDefinition def on bal.IfcCode = def.IfcCode
		where AccountNumber = @AccountNumber and def.IfcSubType = 'FD'
		;
		if(@BlockAmount is null)
			select @BlockAmount = 0;
		select @BlockAmount = case when  @BlockAmount < @AvailableBalance - @MinimumDepositAmount then @BlockAmount else @AvailableBalance - @MinimumDepositAmount end;
	end;

	RETURN @AvailableBalance - (@MinimumDepositAmount + @BlockAmount);
END
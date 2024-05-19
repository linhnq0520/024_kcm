use o9credit;
GO

IF OBJECT_ID('[CanCollectInterest]', 'P') IS NOT NULL
BEGIN
	-- The procedure exists
	DROP PROCEDURE CanCollectInterest
;
END;
GO

CREATE PROCEDURE dbo.CanCollectInterest
	(
	@CreditAccount NVARCHAR(100),
	@IfcCode int,
	@WorkingDate Date
)
AS
BEGIN TRY

DECLARE @str NVARCHAR(max);
DECLARE @condition NVARCHAR(max);
DECLARE @isExist INT = 0;

BEGIN TRANSACTION;

-- Main processing code here
DECLARE @strWorkingDate VARCHAR(20) = Convert(VARCHAR(20), @workingdate, 23);
DECLARE @strCode VARCHAR(20) = Convert(VARCHAR(20), @IfcCode, 23);
DECLARE @AccountNumber VARCHAR(20);


select @condition = ifcdef.IfcCondition
from CreditAccount account
	inner join CreditIFCBalance ifcbal on account.AccountNumber = ifcbal.AccountNumber
	inner join CreditIFCDefinition ifcdef on ifcdef.IfcCode = ifcbal.IfcCode
where account.AccountNumber = @CreditAccount;
print @condition;
set @str = 'select @isExist = Count(account.AccountNumber) from CreditAccount account ';
set @str = @str + 'inner join CreditIFCBalance ifcbal on account.AccountNumber = ifcbal.AccountNumber ';
set @str = @str + 'inner join  (select IfcCode, IfcCondition, ValueBasic, IfcTenor, IfcType, CAST('''+@strWorkingDate+''' AS DATE) as WorkingDate from CreditIFCDefinition where IfcCode = CAST('''+@strCode+''' AS INT)) ifcdef on ifcdef.IfcCode = ifcbal.IfcCode where ';
set @str = @str + 'account.AccountNumber = ''' + @CreditAccount;

IF (@condition <> '')
begin
	set @str = @str + ''' and ';
	set @str = @str + REPLACE(@condition, '''', '''''')
end;

print (@str);
exec sp_executesql @str, N'@isExist INT OUTPUT', @isExist = @isExist OUTPUT;

print @isExist;

COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    throw;
END CATCH;
GO
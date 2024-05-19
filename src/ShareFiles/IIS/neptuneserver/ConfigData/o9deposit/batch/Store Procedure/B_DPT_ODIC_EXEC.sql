use o9deposit;
GO

IF OBJECT_ID('[B_DPT_ODIC_EXEC]', 'P') IS NOT NULL
BEGIN
    -- The procedure exists
    DROP PROCEDURE B_DPT_ODIC_EXEC
;
END;
GO

CREATE PROCEDURE dbo.[B_DPT_ODIC_EXEC]
    (
    @TransactionNumber VARCHAR(36),
    @WorkingDate DATE,
    @UserCode NVARCHAR(50),
    @UserName NVARCHAR(250),
    @BatchDate DATETIME,
    @StepName NVARCHAR(200),
    @ReferenceId NVARCHAR(200) = NULL,
    @RefId NVARCHAR(200) = NULL,
    @ReferenceCode NVARCHAR(200) = NULL,
    @TranId NVARCHAR(200) = NULL,
    @Description NVARCHAR(200) = NULL,
    @BusinessCode NVARCHAR(200) = NULL,
    @ChannelID NVARCHAR(200) = NULL
)
AS
BEGIN TRY

DECLARE @current_working_date DATE = @WorkingDate;
DECLARE @StartTime DATE = GETUTCDATE();
DECLARE @BatchStepName VARCHAR(100) = @StepName;

BEGIN TRANSACTION;

-- Create transaction
EXEC CREATE_TRANSACTION @TransactionNumber = @TransactionNumber,
        @WorkingDate = @WorkingDate,
        @UserCode = @UserCode,
        @UserName = @UserName,
        @BatchDate = @BatchDate,
        @StepName = @StepName,
        @ReferenceId = @ReferenceId,
        @RefId = @RefId,
        @ReferenceCode = @ReferenceCode,
        @TranId = @TranId,
        @Description = @Description,
        @BusinessCode = @BusinessCode,
        @ChannelID = @ChannelID;

-- Main processing code here
DECLARE @log NVARCHAR(max) = '';
DECLARE @strSQL NVARCHAR(max) = '';
DECLARE @NumberOfDaysInTheYear VARCHAR(100) = ' ' + dbo.[GET_ACTUAL_DAYS_OF_CURRENT_YEAR](@WorkingDate);-- check leap year
DECLARE @strWorkingDate VARCHAR(20) = Convert(VARCHAR(20), @workingdate, 23);
DECLARE @IfcCode int,
    @ValueBasic VARCHAR(max),
    @IfcCondition VARCHAR(max),
    @IfcOperator VARCHAR(100);

DECLARE myCursor CURSOR
FOR
SELECT def.IfcCode,
    def.ValueBasic,
    def.IfcCondition,
    def.IfcOperator
FROM dbo.DepositIFCDefinition def
WHERE IfcCode IN (
        SELECT DISTINCT ifccode
FROM dbo.ODContractIFCBalance
where IfcBalanceStatus = 'N'
        );

OPEN myCursor;

FETCH NEXT
FROM myCursor
INTO @IfcCode,
    @ValueBasic,
    @IfcCondition,
    @IfcOperator;

WHILE @@FETCH_STATUS = 0
BEGIN
    set  @strSQL = '';
    -- clear query 
    SET @strSQL = ' DECLARE @WorkingDate DATE = ''' + convert(varchar(100), @WorkingDate, 23) + ''';';
    SET @strSQL = @strSQL + ' INSERT INTO ODContractIFCBalanceDetail([ModuleCode], [ContractNumber], [IfcCode], [IfcValue], [Balance], [FromDate], [ToDate], [Action], [Amount], [ReferenceId], [IFCBalanceDetailDescription])';
    SET @strSQL = @strSQL + ' SELECT * FROM (';
    SET @strSQL = @strSQL + ' select ';
    SET @strSQL = @strSQL + ' 	''OD'' as [ModuleCode]';
    SET @strSQL = @strSQL + ' 	, contract.ContractNumber as [ContractNumber]';
    SET @strSQL = @strSQL + ' 	, ifcbalance.IfcCode as [IfcCode]';
    SET @strSQL = @strSQL + ' 	, ifcbalance.IfcValue + ifcbalance.MarginValue as [IfcValue]';
    SET @strSQL = @strSQL + ' 	, case when IfcType = ''I'' then dbo.GetOverDraftBalance(AccountNumber) 
										when IfcType = ''F'' and IfcSubType = ''FC'' then dbo.GetUnUseBalance(AccountNumber) 
										when IfcType = ''F'' and IfcSubType = ''PP'' then iif(dbo.GetOverDraftBalance(AccountNumber) > OdLimit, OdLimit, dbo.GetOverDraftBalance(AccountNumber))
										when IfcType = ''F'' and IfcSubType = ''PI'' then iif(dbo.GetOverDraftBalance(AccountNumber) > OdLimit, dbo.GetOverDraftBalance(AccountNumber) - OdLimit, 0) end as [Balance]';
    SET @strSQL = @strSQL + ' 	, ''' + @strWorkingDate + ''' as [FromDate]';
    SET @strSQL = @strSQL + ' 	, ''' + @strWorkingDate + ''' as [ToDate]';
    SET @strSQL = @strSQL + ' 	, ''C'' as [Action]';
    SET @strSQL = @strSQL + ' 	, round(' + REPLACE(@ValueBasic, '''', '''''') + ' * (ifcbalance.IfcValue ' + @IfcOperator + ' ifcbalance.MarginValue) * IfcTenor / 100 / DaysBasis, 5) as [Amount]';
    SET @strSQL = @strSQL + ' 	, ''' + REPLACE(@TransactionNumber, '''', '''''') + ''' as [ReferenceId]';
    SET @strSQL = @strSQL + ' 	, ''' + REPLACE(@BatchStepName, '''', '''''') + ''' as [IFCBalanceDetailDescription]';
    SET @strSQL = @strSQL + ' from dbo.OverdraftContract contract';
    SET @strSQL = @strSQL + ' inner join dbo.ODContractIFCBalance ifcbalance';
    SET @strSQL = @strSQL + ' 	on contract.ContractNumber = ifcbalance.ContractNumber';
    SET @strSQL = @strSQL + ' inner join (select IfcCode, IfcCondition, ValueBasic, IfcTenor, IfcType, IfcSubType, CAST('''+@strWorkingDate+''' AS DATE) as WorkingDate, ';
    SET @strSQL = @strSQL + '   case ';
    SET @strSQL = @strSQL + ' 	   when IfcTenorUnit=''D'' then 1 ';
    SET @strSQL = @strSQL + ' 	   when IfcTenorUnit=''W'' then 7 ';
    SET @strSQL = @strSQL + ' 	   when IfcTenorUnit=''M'' then 30 ';
    SET @strSQL = @strSQL + ' 	   when IfcTenorUnit=''Q'' then 90 ';
    SET @strSQL = @strSQL + ' 	   when IfcTenorUnit=''H'' then 180 ';
    SET @strSQL = @strSQL + ' 	   when IfcTenorUnit=''Y'' then 365 ';
    SET @strSQL = @strSQL + '   end as DaysBasis from dbo.DepositIFCDefinition where IfcCode = ' + convert(varchar(100), @IfcCode) + ') ifc';-- select all IFC
    SET @strSQL = @strSQL + ' 	on ifcbalance.IfcCode = ifc.IfcCode';
    -- select IFC type INTEREST only
    SET @strSQL = @strSQL + ' where (contract.ContractStatus = 0 or contract.ContractStatus = 2 or (contract.ContractStatus = 7 and ifc.IfcType = ''F'' and ifc.IfcSubType in (''PP'', ''PI'')))';-- Normal
    SET @strSQL = @strSQL + ' and ifcbalance.IfcBalanceStatus = ''N''';-- Normal
    SET @strSQL = @strSQL + ' and ifc.IfcCode = ' + convert(varchar(100), @IfcCode);

    IF (@IfcCondition <> '')
        SET @strSQL = @strSQL + ' and (' + REPLACE(@IfcCondition, '''', '''''') + ')';
    SET @strSQL = @strSQL + ' ) a WHERE amount <> 0 ;';

    PRINT @strSQL;
    EXEC (@strSQL);
    FETCH NEXT
    FROM myCursor
    INTO @IfcCode,
        @ValueBasic,
        @IfcCondition,
        @IfcOperator;

END;

CLOSE myCursor;

DEALLOCATE myCursor;

-- Update IFCBalance
UPDATE ODContractIFCBalance
SET Amount = round(ifcbal.Amount + ifcbaldetails.Amount, 5)
FROM ODContractIFCBalance ifcbal
    INNER JOIN ODContractIFCBalanceDetail ifcbaldetails
    ON ifcbal.ContractNumber = ifcbaldetails.ContractNumber
        AND ifcbal.IfcCode = ifcbaldetails.IfcCode
WHERE ifcbaldetails.ReferenceId = @TransactionNumber;

COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    throw;
END CATCH;
GO
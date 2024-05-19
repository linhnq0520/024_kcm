use o9credit;
GO

IF OBJECT_ID('[B_CRD_CIC_EXEC]', 'P') IS NOT NULL
BEGIN
    -- The procedure exists
    DROP PROCEDURE [B_CRD_CIC_EXEC];
END;
GO

CREATE PROCEDURE [dbo].[B_CRD_CIC_EXEC]
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
EXEC CREATE_TRANSACTION 
		@TransactionNumber = @TransactionNumber,
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
DECLARE @strSQL NVARCHAR(max) = '';
DECLARE @NumberOfDaysInTheYear VARCHAR(100) = ' ' + dbo.[GET_ACTUAL_DAYS_OF_CURRENT_YEAR]();-- check leap year
DECLARE @strWorkingDate VARCHAR(20) = Convert(VARCHAR(20), @workingdate, 23);
DECLARE @IfcCode int,
    @ValueBasic NVARCHAR(max),
    @IfcCondition NVARCHAR(max),
    @IfcOperator NVARCHAR(100)

DECLARE myCursor CURSOR
FOR
SELECT def.IfcCode,
    def.ValueBasic,
    def.IfcCondition,
    def.IfcOperator
FROM CreditIFCDefinition def
WHERE IfcCode IN (
    SELECT distinct bal.ifccode
    FROM dbo.CreditIFCBalance bal
) and def.IfcType = 'I';

OPEN myCursor;

FETCH NEXT
FROM myCursor
INTO @IfcCode,
    @ValueBasic,
    @IfcCondition,
    @IfcOperator;

WHILE @@FETCH_STATUS = 0
BEGIN
    SET @strSQL = ' DECLARE @WorkingDate date = ''' + convert(varchar(100), @WorkingDate, 23) + ''';';
    SET @strSQL = @strSQL + ' INSERT INTO CreditIFCBalanceDetail([ModuleCode], [AccountNumber], [IfcCode], [IfcValue], [Balance], [FromDate], [ToDate], [Action], [Amount], [ReferenceId], [IFCBalanceDetailDescription])';
    SET @strSQL = @strSQL + ' SELECT * FROM (';
    SET @strSQL = @strSQL + ' select ';
    SET @strSQL = @strSQL + ' 	''CRD'' as [ModuleCode]';
    SET @strSQL = @strSQL + ' 	, account.AccountNumber as [AccountNumber]';
    SET @strSQL = @strSQL + ' 	, ifcbalance.IfcCode as [IfcCode]';
    SET @strSQL = @strSQL + ' 	, ifcbalance.IfcValue + ifcbalance.MarginValue as [IfcValue]';
    SET @strSQL = @strSQL + ' 	, Balance as [Balance]';
    SET @strSQL = @strSQL + ' 	, ''' + @strWorkingDate + ''' as [FromDate]';
    SET @strSQL = @strSQL + ' 	, ''' + @strWorkingDate + ''' as [ToDate]';
    SET @strSQL = @strSQL + ' 	, ''C'' as [Action]';

    SET @strSQL = @strSQL + '   , case when RoundingRule=''R'' then';
    -- round
    SET @strSQL = @strSQL + '               round(' + @ValueBasic + ' * (IfcValue ' + @IfcOperator + ' MarginValue) * IfcTenor / 100 / DaysBasis, RoundingNum)';
    SET @strSQL = @strSQL + '          when RoundingRule = ''U'' then';
    -- round up
    SET @strSQL = @strSQL + '               Cast(CEILING(' + @ValueBasic + ' * (IfcValue ' + @IfcOperator + ' MarginValue) * IfcTenor / 100 / DaysBasis) as decimal(24, 0))';
    SET @strSQL = @strSQL + '          when RoundingRule = ''D'' then';
    -- round down
    SET @strSQL = @strSQL + '               Cast(FLOOR(' + @ValueBasic + ' * (IfcValue ' + @IfcOperator + ' MarginValue) * IfcTenor / 100 / DaysBasis) as decimal(24, 0))';
    SET @strSQL = @strSQL + '          when RoundingRule = ''T'' then';
    -- truncate (round(x, 0))
    SET @strSQL = @strSQL + '               round(' + @ValueBasic + ' * (IfcValue ' + @IfcOperator + ' MarginValue) * IfcTenor / 100 / DaysBasis, 0)';
    SET @strSQL = @strSQL + '          else     ';
    -- round(x, 2)
    SET @strSQL = @strSQL + '               round(' + @ValueBasic + ' * (IfcValue ' + @IfcOperator + ' MarginValue) * IfcTenor / 100 / DaysBasis, 2)';
    SET @strSQL = @strSQL + '   end as [Amount]';

    SET @strSQL = @strSQL + ' 	, ''' + REPLACE(@TransactionNumber, '''', '''''') + ''' as [ReferenceId]';
    SET @strSQL = @strSQL + ' 	, ''' + REPLACE(@BatchStepName, '''', '''''') + ''' as [IFCBalanceDetailDescription]';
    SET @strSQL = @strSQL + ' from (select ac.*, @WorkingDate as [WorkingDate] from dbo.CreditAccount ac where ac.Crdsts NOT IN(1, 7)) account';
    SET @strSQL = @strSQL + ' inner join dbo.CreditIFCBalance ifcbalance';
    SET @strSQL = @strSQL + ' 	on account.AccountNumber = ifcbalance.AccountNumber AND ifcbalance.ifcbalancestatus = ''N''';
    SET @strSQL = @strSQL + ' inner join (select IfcCode, IfcCondition, ValueBasic, IfcTenor, RoundingNum, RoundingRule,';
    SET @strSQL = @strSQL + '   case ';
    SET @strSQL = @strSQL + ' 	   when IfcTenorUnit=''D'' then 1 ';
    SET @strSQL = @strSQL + ' 	   when IfcTenorUnit=''W'' then 7 ';
    SET @strSQL = @strSQL + ' 	   when IfcTenorUnit=''M'' then 30 ';
    SET @strSQL = @strSQL + ' 	   when IfcTenorUnit=''Q'' then 90';
    SET @strSQL = @strSQL + ' 	   when IfcTenorUnit=''H'' then 180';
    SET @strSQL = @strSQL + ' 	   when IfcTenorUnit=''Y'' then ' + @NumberOfDaysInTheYear;
    SET @strSQL = @strSQL + '   end as DaysBasis from dbo.CreditIFCDefinition where IfcType in (''I'') and IfcStatus=''N'' and IfcCode=' + convert(varchar(100), @IfcCode) + ') ifc';
    SET @strSQL = @strSQL + ' 	on ifcbalance.IfcCode = ifc.IfcCode';
    -- select IFC type INTEREST only
    SET @strSQL = @strSQL + ' where Crdsts IN (0, 2)';
    -- <> Closed
    -- in contract period
    SET @strSQL = @strSQL + ' and account.InterestComputationMode = ''F''';
    -- Fixed type
    SET @strSQL = @strSQL + ' and ifc.IfcCode = ' + convert(varchar(100), @IfcCode);

    IF (@IfcCondition <> '')
        SET @strSQL = @strSQL + ' and (' + @IfcCondition + ')';
    SET @strSQL = @strSQL + ' ) a WHERE amount <> 0;';



    --PRINT @strSQL;

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

-- << Calculate Interest for Installments
DECLARE myNonFixedCursor CURSOR
FOR
	SELECT def.IfcCode,
    def.ValueBasic,
    def.IfcCondition,
    def.IfcOperator
FROM CreditIFCDefinition def
WHERE IfcCode IN (
		SELECT distinct bal.ifccode
    FROM dbo.CreditIFCBalance bal
        inner join CreditAccount acc on bal.AccountNumber = acc.AccountNumber
    where acc.Crdsts in (0, 2) and acc.InterestComputationMode <> 'F'  -- Non-fixed type
	) and def.IfcType = 'I';

OPEN myNonFixedCursor;

FETCH NEXT
FROM myNonFixedCursor
INTO @IfcCode,
    @ValueBasic,
    @IfcCondition,
    @IfcOperator;

WHILE @@FETCH_STATUS = 0
BEGIN

    SET @strSQL = ' 
DECLARE @WorkingDate date = ''' + convert(varchar(100), @WorkingDate, 23) + ''';
DECLARE @TransactionNumber varchar(100) = ''' + @TransactionNumber + ''';
DECLARE @BatchStepName varchar(100) = ''' + @BatchStepName + ''';
INSERT INTO CreditIFCBalanceDetail
    ([ModuleCode], [AccountNumber], [IfcCode], [IfcValue], [Balance], [FromDate], [ToDate], [Action], [Amount], [ReferenceId], [IFCBalanceDetailDescription])

SELECT [ModuleCode], [AccountNumber], [IfcCode], [IfcValue], [Balance], [FromDate], [ToDate], [Action], [Amount], [ReferenceId], [IFCBalanceDetailDescription] 
FROM 
(
    SELECT
        ''CRD'' as [ModuleCode]
        , schedule.[AccountNumber]
        , ifcbalance.[IfcCode]
        , ifcbalance.IfcValue + ifcbalance.MarginValue [IfcValue]
        , acc.Balance [Balance]
        , @WorkingDate [FromDate]
        , @WorkingDate [ToDate]
        , ''C'' as [Action]
        , ROUND(
			(
					(schedule.Amount - acc.InterestAmount) -- // = (Interest on schedule � Accrued)
						/ 
					(DateDiff(day, @WorkingDate, schedule.ITodate) + 1) -- Remaining days
			)
		, 5)
		as [Amount] -- (Interest on schedule � Accrued)/Remaining days
        , @TransactionNumber as [ReferenceId]
        , @BatchStepName as [IFCBalanceDetailDescription]
		, @WorkingDate as [WorkingDate]
    FROM CreditSchedule schedule
        inner join CreditIFCBalance ifcbalance on schedule.AccountNumber = ifcbalance.AccountNumber AND ifcbalance.ifcbalancestatus = ''N''
        inner join CreditIFCDefinition def on ifcbalance.IfcCode = def.IfcCode and def.IfcType = ''I'' and def.IfcCode=' + CAST(@IfcCode as varchar(100)) + '
        inner join CreditAccount acc on schedule.AccountNumber = acc.AccountNumber AND (acc.InterestComputationMode <> ''F'') AND acc.DisbursementAmount > 0
		,(select @WorkingDate as [WorkingDate]) wd
	WHERE 
    acc.Crdsts IN (0, 2) -- Normal, block
        and schedule.Rptype=''I''
        and @WorkingDate between schedule.IFromDate and schedule.IToDate
';
    if (@IfcCondition <> '')
	begin
        SET @strSQL = @strSQL + ' and ' + @IfcCondition;
    end;

    SET @strSQL = @strSQL + ' ) a WHERE [Amount] > 0 ';

    --PRINT (@strSQL);

    EXEC (@strSQL);

    FETCH NEXT
		FROM myNonFixedCursor
		INTO @IfcCode,
			@ValueBasic,
			@IfcCondition,
			@IfcOperator;
END;

CLOSE myNonFixedCursor;

DEALLOCATE myNonFixedCursor;
-- End of Interest Calculation for Non-fixed account

-- Calculate penalty fee
DECLARE myCursorFee CURSOR
FOR
SELECT def.IfcCode,
    def.ValueBasic,
    def.IfcCondition,
    def.IfcOperator
FROM CreditIFCDefinition def
WHERE IfcCode IN (
    SELECT distinct bal.ifccode
    FROM dbo.CreditIFCBalance bal
) and def.IfcType = 'F';

OPEN myCursorFee;

FETCH NEXT
FROM myCursorFee
INTO @IfcCode,
    @ValueBasic,
    @IfcCondition,
    @IfcOperator;

WHILE @@FETCH_STATUS = 0
BEGIN
    SET @strSQL = ' DECLARE @WorkingDate date = ''' + convert(varchar(100), @WorkingDate, 23) + ''';';
    SET @strSQL = @strSQL + ' INSERT INTO CreditIFCBalanceDetail([ModuleCode], [AccountNumber], [IfcCode], [IfcValue], [Balance], [FromDate], [ToDate], [Action], [Amount], [ReferenceId], [IFCBalanceDetailDescription])';
    SET @strSQL = @strSQL + ' SELECT * FROM (';
    SET @strSQL = @strSQL + ' select ';
    SET @strSQL = @strSQL + ' 	''CRD'' as [ModuleCode]';
    SET @strSQL = @strSQL + ' 	, account.AccountNumber as [AccountNumber]';
    SET @strSQL = @strSQL + ' 	, ifcbalance.IfcCode as [IfcCode]';
    SET @strSQL = @strSQL + ' 	, ifcbalance.IfcValue + ifcbalance.MarginValue as [IfcValue]';
    SET @strSQL = @strSQL + ' 	, ' + @ValueBasic + ' as [Balance]';
    SET @strSQL = @strSQL + ' 	, ''' + @strWorkingDate + ''' as [FromDate]';
    SET @strSQL = @strSQL + ' 	, ''' + @strWorkingDate + ''' as [ToDate]';
    SET @strSQL = @strSQL + ' 	, ''C'' as [Action]';

    SET @strSQL = @strSQL + '   , case when RoundingRule=''R'' then';
    -- round
    SET @strSQL = @strSQL + '               round(' + @ValueBasic + ' * (IfcValue ' + @IfcOperator + ' MarginValue) * IfcTenor / 100 / DaysBasis, RoundingNum)';
    SET @strSQL = @strSQL + '          when RoundingRule = ''U'' then';
    -- round up
    SET @strSQL = @strSQL + '               Cast(CEILING(' + @ValueBasic + ' * (IfcValue ' + @IfcOperator + ' MarginValue) * IfcTenor / 100 / DaysBasis) as decimal(24, 0))';
    SET @strSQL = @strSQL + '          when RoundingRule = ''D'' then';
    -- round down
    SET @strSQL = @strSQL + '               Cast(FLOOR(' + @ValueBasic + ' * (IfcValue ' + @IfcOperator + ' MarginValue) * IfcTenor / 100 / DaysBasis) as decimal(24, 0))';
    SET @strSQL = @strSQL + '          when RoundingRule = ''T'' then';
    -- truncate (round(x, 0))
    SET @strSQL = @strSQL + '               round(' + @ValueBasic + ' * (IfcValue ' + @IfcOperator + ' MarginValue) * IfcTenor / 100 / DaysBasis, 0)';
    SET @strSQL = @strSQL + '          else     ';
    -- round(x, 2)
    SET @strSQL = @strSQL + '               round(' + @ValueBasic + ' * (IfcValue ' + @IfcOperator + ' MarginValue) * IfcTenor / 100 / DaysBasis, 2)';
    SET @strSQL = @strSQL + '   end as [Amount]';

    SET @strSQL = @strSQL + ' 	, ''' + REPLACE(@TransactionNumber, '''', '''''') + ''' as [ReferenceId]';
    SET @strSQL = @strSQL + ' 	, ''' + REPLACE(@BatchStepName, '''', '''''') + ''' as [IFCBalanceDetailDescription]';
    SET @strSQL = @strSQL + ' from (select ac.*, @WorkingDate as [WorkingDate] from dbo.CreditAccount ac where ac.Crdsts NOT IN(1)) account';
    SET @strSQL = @strSQL + ' inner join dbo.CreditIFCBalance ifcbalance';
    SET @strSQL = @strSQL + ' 	on account.AccountNumber = ifcbalance.AccountNumber AND ifcbalance.ifcbalancestatus = ''N''';
    SET @strSQL = @strSQL + ' inner join (select IfcCode, IfcCondition, ValueBasic, IfcTenor, RoundingNum, RoundingRule,';
    SET @strSQL = @strSQL + '   case ';
    SET @strSQL = @strSQL + ' 	   when IfcTenorUnit=''D'' then 1 ';
    SET @strSQL = @strSQL + ' 	   when IfcTenorUnit=''W'' then 7 ';
    SET @strSQL = @strSQL + ' 	   when IfcTenorUnit=''M'' then 30 ';
    SET @strSQL = @strSQL + ' 	   when IfcTenorUnit=''Q'' then 90';
    SET @strSQL = @strSQL + ' 	   when IfcTenorUnit=''H'' then 180';
    SET @strSQL = @strSQL + ' 	   when IfcTenorUnit=''Y'' then ' + @NumberOfDaysInTheYear;
    SET @strSQL = @strSQL + '   end as DaysBasis from dbo.CreditIFCDefinition where IfcType in (''F'') and IfcStatus=''N'' and IfcCode=' + convert(varchar(100), @IfcCode) + ') ifc';
    SET @strSQL = @strSQL + ' 	on ifcbalance.IfcCode = ifc.IfcCode';
    SET @strSQL = @strSQL + ' where Crdsts IN (0, 2, 7)';
    -- <> Closed;  
    SET @strSQL = @strSQL + ' and ifc.IfcCode = ' + convert(varchar(100), @IfcCode);

    IF (@IfcCondition <> '')
        SET @strSQL = @strSQL + ' and (' + @IfcCondition + ')';
    SET @strSQL = @strSQL + ' ) a WHERE amount <> 0;';



    --PRINT @strSQL;

    EXEC (@strSQL);
    FETCH NEXT
    FROM myCursorFee
    INTO @IfcCode,
        @ValueBasic,
        @IfcCondition,
        @IfcOperator;
END;

CLOSE myCursorFee;

DEALLOCATE myCursorFee;

-- Update IFCBalance
UPDATE CreditIFCBalance
SET Amount = round(ifcbal.Amount + ifcbaldetails.Amount, 5)
FROM CreditIFCBalance ifcbal
    INNER JOIN CreditIFCBalanceDetail ifcbaldetails
    ON ifcbal.AccountNumber = ifcbaldetails.AccountNumber
        AND ifcbal.IfcCode = ifcbaldetails.IfcCode 
WHERE ifcbaldetails.ReferenceId = @TransactionNumber;

UPDATE CreditAccount
SET InterestAmount = ROUND(InterestAmount + Amount, 5)
FROM CreditAccount account
    INNER JOIN (
    SELECT AccountNumber,
        ROUND(SUM(bal.Amount), 5) Amount
    FROM CreditIFCBalanceDetail bal
        INNER JOIN CreditIFCDefinition def on bal.IfcCode = def.IfcCode
    WHERE ReferenceId = @TransactionNumber and def.IfcType = 'I'
    GROUP BY AccountNumber
    ) ifcBalance
    ON account.AccountNumber = ifcBalance.AccountNumber;
	
	

COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    throw;
END CATCH;
GO

use o9deposit;
GO

IF OBJECT_ID('[B_DPT_DIC_EXEC]', 'P') IS NOT NULL
BEGIN
    -- The procedure exists
    DROP PROCEDURE B_DPT_DIC_EXEC;
END;
GO

CREATE PROCEDURE [dbo].[B_DPT_DIC_EXEC] (
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
DECLARE @current_working_date DATE = @WorkingDate;
DECLARE @StartTime DATE = GETUTCDATE();
DECLARE @BatchStepName VARCHAR(100) = 'B_DPT_DIC_EXEC';

BEGIN TRY
BEGIN TRANSACTION;

-- Create transaction
    EXEC dbo.CREATE_TRANSACTION @TransactionNumber = @TransactionNumber,
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
DECLARE @NumberOfDaysInTheYear VARCHAR(100) = ' ' + dbo.[GET_ACTUAL_DAYS_OF_CURRENT_YEAR](@WorkingDate);-- check leap year
DECLARE @strWorkingDate VARCHAR(20) = Convert(VARCHAR(20), @workingdate, 23);
DECLARE @IfcCode int,
    @ValueBasic NVARCHAR(max),
    @IfcCondition NVARCHAR(max),
    @IfcOperator NVARCHAR(100);

DECLARE myCursor CURSOR
FOR
SELECT def.IfcCode,
    def.ValueBasic,
    def.IfcCondition,
    def.IfcOperator
FROM DepositIFCDefinition def
WHERE IfcCode IN (
    SELECT distinct ifccode 
    FROM dbo.IFCBalance
) AND def.IfcType <> 'F' AND def.IfcSubType <> 'IE';

OPEN myCursor;

FETCH NEXT
FROM myCursor
INTO @IfcCode,
    @ValueBasic,
    @IfcCondition,
    @IfcOperator;

WHILE @@FETCH_STATUS = 0
BEGIN
    SET @strSQL = ' INSERT INTO dbo.IFCBalanceDetail([ModuleCode], [AccountNumber], [IfcCode], [IfcValue], [Balance], [FromDate], [ToDate], [Action], [Amount], [ReferenceId], [IFCBalanceDetailDescription])';
    SET @strSQL = @strSQL + ' SELECT * FROM (';
    SET @strSQL = @strSQL + ' select ';
    SET @strSQL = @strSQL + '   ''DPT'' as [ModuleCode]';
    SET @strSQL = @strSQL + '   , AccountNumber';
    SET @strSQL = @strSQL + '   , IfcCode';
    SET @strSQL = @strSQL + '   , IfcValue + MarginValue as IfcValue';
    SET @strSQL = @strSQL + '   , CurrentBalance';
    SET @strSQL = @strSQL + '   , ''' + @strWorkingDate + ''' as [FromDate]';
    SET @strSQL = @strSQL + '   , ''' + @strWorkingDate + ''' as [ToDate]';
    SET @strSQL = @strSQL + '   , ''C'' as [Action]';

    SET @strSQL = @strSQL + '   , CASE WHEN EndOfTenor IS NOT NULL AND DepositSubType = ''T6'' AND ABS(DATEDIFF(DAY, EndOfTenor, CAST('''+@strWorkingDate+''' as DATE))) = 1 THEN PrepaidAmount';
    SET @strSQL = @strSQL + '   ELSE';
    SET @strSQL = @strSQL + '   case when RoundingRule=''R'' then'; -- round
    SET @strSQL = @strSQL + '               round(' + @ValueBasic + ' * (IfcValue ' + @IfcOperator + ' MarginValue) / IfcTenor / 100 / DaysBasis, RoundingNum)';
    SET @strSQL = @strSQL + '          when RoundingRule = ''U'' then'; -- round up
    SET @strSQL = @strSQL + '               Cast(CEILING(' + @ValueBasic + ' * (IfcValue ' + @IfcOperator + ' MarginValue) / IfcTenor / 100 / DaysBasis) as decimal(24, 0))';
    SET @strSQL = @strSQL + '          when RoundingRule = ''D'' then'; -- round down
    SET @strSQL = @strSQL + '               Cast(FLOOR(' + @ValueBasic + ' * (IfcValue ' + @IfcOperator + ' MarginValue) / IfcTenor / 100 / DaysBasis) as decimal(24, 0))';
    SET @strSQL = @strSQL + '          when RoundingRule = ''T'' then'; -- truncate (round(x, 0))
    SET @strSQL = @strSQL + '               round(' + @ValueBasic + ' * (IfcValue ' + @IfcOperator + ' MarginValue) / IfcTenor / 100 / DaysBasis, 0)';
    SET @strSQL = @strSQL + '          else     '; -- round(x, 2)
    SET @strSQL = @strSQL + '               round(' + @ValueBasic + ' * (IfcValue ' + @IfcOperator + ' MarginValue) / IfcTenor / 100 / DaysBasis, 2)';
    SET @strSQL = @strSQL + '   END';
    SET @strSQL = @strSQL + '   END as [Amount]';

    SET @strSQL = @strSQL + '   , ''' + REPLACE(@ReferenceId, '''', '''''') + ''' as [ReferenceId]';
    SET @strSQL = @strSQL + '   , ''' + REPLACE(@BatchStepName, '''', '''''') + ''' as [IFCBalanceDetailDescription]';
    SET @strSQL = @strSQL + 'FROM (SELECT account.*,ifcbalance.PrepaidAmount,ifcbalance.IfcCode,ifcbalance.IfcValue, IfcCondition, ValueBasic, IfcTenor, ifcbalance.MarginValue, '
    SET @strSQL = @strSQL + '    CASE  ';
    SET @strSQL = @strSQL + '      WHEN CreditInterestTenorUnit = ''M'' AND IfcTenorUnit=''M'' THEN 1 ' ;
    SET @strSQL = @strSQL + '      WHEN CreditInterestTenorUnit = ''D'' AND IfcTenorUnit=''D'' THEN 1 ';
    SET @strSQL = @strSQL + '      WHEN CreditInterestTenorUnit = ''D'' AND IfcTenorUnit=''W'' THEN 7 ';
    SET @strSQL = @strSQL + '      WHEN CreditInterestTenorUnit = ''D'' AND IfcTenorUnit=''M'' THEN 30 ';
    SET @strSQL = @strSQL + '      WHEN CreditInterestTenorUnit = ''D'' AND IfcTenorUnit=''Q'' THEN 90';
    SET @strSQL = @strSQL + '      WHEN CreditInterestTenorUnit = ''D'' AND IfcTenorUnit=''H'' THEN 180';
    SET @strSQL = @strSQL + '      WHEN CreditInterestTenorUnit = ''D'' AND IfcTenorUnit=''Y'' THEN ' + @NumberOfDaysInTheYear;
    SET @strSQL = @strSQL + ' end as DaysBasis , RoundingNum, RoundingRule, CAST('''+@strWorkingDate+''' AS DATE) as WorkingDate from dbo.DepositAccount account';
    SET @strSQL = @strSQL + ' inner join dbo.IFCBalance ifcbalance';
    SET @strSQL = @strSQL + '   on account.AccountNumber = ifcbalance.AccountNumber';
    SET @strSQL = @strSQL + ' inner join (select IfcCode, IfcCondition, ValueBasic, IfcTenor, MarginValue, RoundingNum, RoundingRule, IfcTenorUnit';
    
    SET @strSQL = @strSQL + '   from dbo.DepositIFCDefinition where IfcType = ''I'' and IfcStatus=''N'' and IfcCode=' + convert(varchar(100), @IfcCode) + ') ifc';
    SET @strSQL = @strSQL + '   on ifcbalance.IfcCode = ifc.IfcCode';-- select IFC type INTEREST only
    SET @strSQL = @strSQL + ' where DepositStatus <> ''C'' AND CAST('''+@strWorkingDate+''' AS date) < CASE WHEN DepositType = ''T'' THEN EndOfTenor ELSE DATEADD(DAY,1, CAST('''+@strWorkingDate+''' AS date)) END';-- Not closed
    SET @strSQL = @strSQL + ' AND ifcbalance.IfcBalanceStatus=''N'' and ifc.IfcCode = ' + convert(varchar(100), @IfcCode);

    IF (@IfcCondition <> '')
        SET @strSQL = @strSQL + ' ) a WHERE (' + @IfcCondition + ')';
    ELSE SET @strSQL = @strSQL + ' ) a'
    SET @strSQL = @strSQL + ' ) a WHERE amount <> 0;';

    -- PRINT @strSQL;

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

-- Update IFCBalance level
UPDATE IFCBalance
SET Amount = CASE WHEN (ifcDef.IfcSubType = 'IP' AND ifcDef.IfcType = 'I')
                THEN ifcbal.Amount 
                ELSE round(ifcbal.Amount + ifcbaldetails.Amount, 5) END,
Paid = CASE WHEN (ifcDef.IfcSubType = 'IP' AND ifcDef.IfcType = 'I')
                THEN Paid + ifcbaldetails.Amount 
                ELSE Paid END,
PrepaidAmount = CASE WHEN (ifcDef.IfcSubType = 'IP' AND ifcDef.IfcType = 'I')
                THEN PrepaidAmount - ifcbaldetails.Amount 
                ELSE PrepaidAmount END
FROM IFCBalance ifcbal
INNER JOIN IFCBalanceDetail ifcbaldetails
    ON ifcbal.AccountNumber = ifcbaldetails.AccountNumber
        AND ifcbal.IfcCode = ifcbaldetails.IfcCode
INNER JOIN (SELECT IfcCode, IfcSubType, IfcType FROM dbo.DepositIFCDefinition) ifcDef
ON ifcbal.IfcCode = ifcDef.IfcCode
WHERE ifcDef.IfcSubType <> 'IE' AND ifcbaldetails.ReferenceId = @ReferenceId; -- today records

-- Sum up to Deposit account level
UPDATE DepositAccount
SET InterestAccrual = CASE WHEN (ifc.IfcSubType = 'IP' AND ifc.IfcType = 'I')
THEN InterestAccrual
            ELSE InterestAccrual + ifcbaldetails.Amount END,
Intpre = CASE WHEN (ifc.IfcSubType = 'IP' AND ifc.IfcType = 'I')
            THEN Intpre - ifcbaldetails.Amount 
            ELSE Intpre END,
InterestPaid = CASE WHEN (ifc.IfcSubType = 'IP' AND ifc.IfcType = 'I')
            THEN InterestPaid + ifcbaldetails.Amount 
            ELSE InterestPaid END
FROM DepositAccount account
INNER JOIN [IFCBalance] ifcbal on account.AccountNumber = ifcbal.AccountNumber
INNER JOIN (SELECT * FROM [IFCBalanceDetail] WHERE ReferenceId = @ReferenceId) ifcbaldetails 
    on ifcbal.AccountNumber = ifcbaldetails.AccountNumber AND ifcbal.IfcCode = ifcbaldetails.IfcCode
INNER JOIN (SELECT IfcCode, IfcSubType, IfcType FROM dbo.DepositIFCDefinition) ifc ON ifcbal.IfcCode = ifc.IfcCode
WHERE ifcbaldetails.[Action] = 'C';

INSERT INTO [DepositIFCBalanceTrans]([TransId], [TransactionNumber], [DepositAccount], [IFCCode], [TransCode], [TransactionStatus], [Amount], [GLPopulated], [CrossBranchCode], [CrossCurrencyCode], [BaseCurrencyAmount])
SELECT
    NewID() as [TransId]
    , @TransactionNumber as  [TransactionNumber]
    , ifcbaldetails.AccountNumber as [DepositAccount]
    , ifcbaldetails.[IFCCode] as [IFCCode]
    , 'IFC_PREPAID' as  [TransCode]
    , 'N' as  [TransactionStatus]
    , ifcbaldetails.Amount as [Amount] -- round 2 decimals for posting
    , 0 as  [GLPopulated]
    , null as  [CrossBranchCode]
    , null as  [CrossCurrencyCode]
    , 0 as  [BaseCurrencyAmount]
FROM dbo.IFCBalanceDetail ifcbaldetails
INNER JOIN (
        SELECT
            IfcCode,
            IfcSubType,
            IfcType
        FROM
            dbo.DepositIFCDefinition
    ) ifcDef
ON ifcbaldetails.IfcCode = ifcDef.IfcCode
WHERE     ifcbaldetails.ReferenceId = @ReferenceId -- today records
    AND ifcDef.IfcSubType = 'IP'
    AND ifcDef.IfcType = 'I' AND ifcbaldetails.[Action] = 'C';

exec GenerateGLEntriesFromDepositIFCBalanceTrans
    @TransactionNumber=@TransactionNumber; 

INSERT INTO dbo.IFCBalanceDetail(
                    [ModuleCode],
                    [AccountNumber],
                    [IfcCode],
                    [IfcValue],
                    [Balance],
                    [FromDate],
                    [ToDate],
                    [Action],
                    [Amount],
                    [ReferenceId],
                    [IFCBalanceDetailDescription]
    )
SELECT
    ifcbaldetails.ModuleCode,
    ifcbaldetails.AccountNumber,
    ifcbaldetails.IfcCode,
    ifcbaldetails.IfcValue,
    ifcbaldetails.Balance,
    ifcbaldetails.FromDate,
    ifcbaldetails.ToDate,
    'D',
    ifcbaldetails.Amount,
    ifcbaldetails.ReferenceId,
    ifcbaldetails.IFCBalanceDetailDescription
FROM
    IFCBalance ifcbal
INNER JOIN IFCBalanceDetail ifcbaldetails
    ON
    ifcbal.AccountNumber = ifcbaldetails.AccountNumber
    AND ifcbal.IfcCode = ifcbaldetails.IfcCode
INNER JOIN (
        SELECT
            IfcCode,
            IfcSubType,
            IfcType
        FROM
            dbo.DepositIFCDefinition
    ) ifcDef
ON
    ifcbal.IfcCode = ifcDef.IfcCode
WHERE
    ifcbaldetails.ReferenceId = @ReferenceId -- today records
    AND ifcDef.IfcSubType = 'IP'
    AND ifcDef.IfcType = 'I';

COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    throw;
END CATCH;
GO
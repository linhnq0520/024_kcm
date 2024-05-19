use o9accounting;
GO

IF OBJECT_ID('[B_SYS_CWD_EXEC]', 'P') IS NOT NULL
BEGIN
	-- The procedure exists
	DROP PROCEDURE [B_SYS_CWD_EXEC];
END;
GO


CREATE PROCEDURE dbo.[B_SYS_CWD_EXEC]
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

BEGIN

TRY BEGIN TRANSACTION;

DECLARE @ListOfAccount TABLE (
    refId varchar(50),
    transNumber varchar(50),
    glaccount varchar(36),
    dorc varchar(2),
    branchCode varchar(10),
    currencycode varchar(5),
    crossBranchCode varchar(10),
    crossCurrencyCode varchar(5),
    valuedate date,
    amount decimal(38,2),
    transcode varchar(50)
);

INSERT INTO @ListOfAccount(refId, transNumber, glaccount,dorc, valuedate, amount, branchCode, currencycode, crossBranchCode, crossCurrencyCode, transcode)
SELECT
    lower(replace(newid(), '-', '')) AS REF,
    glc.TransactionNumber,
    glc.glaccount,
    glc.dorc,
    glc.valuedate,
    glc.amount,
    glc.branchCode,
    glc.currencycode,
    glc.crossBranchCode,
    glc.crossCurrencyCode,
    glc.dorc
FROM
    ( SELECT GLAccount, DorC, ValueDate, Sum(Amount) Amount, branchCode, currencycode, TransactionNumber, CrossBranchCode, CrossCurrencyCode
    FROM [o9deposit].dbo.[glentries]
    WHERE transactionstatus = 'N' AND posted = 0 AND CAST(ValueDate AS date) = CAST (@WorkingDate AS date)
    GROUP BY
        glaccount, dorc, valuedate, branchCode, currencycode, TransactionNumber, CrossBranchCode, CrossCurrencyCode) glc
INNER JOIN [o9accounting].dbo.[accountbalance] acb ON
    glc.GLAccount = acb.AccountNumber

UNION

SELECT
    lower(replace(newid(), '-', '')) AS REF,
    glc.TransactionNumber,
    glc.glaccount,
    glc.dorc,
    glc.valuedate,
    glc.amount,
    glc.branchCode,
    glc.currencycode,
    glc.crossBranchCode,
    glc.crossCurrencyCode,
    glc.dorc
FROM
    ( SELECT GLAccount, DorC, ValueDate, Sum(Amount) Amount, branchCode,currencycode, TransactionNumber, CrossBranchCode, CrossCurrencyCode
    FROM [o9credit].dbo.[glentries]
    WHERE transactionstatus = 'N' AND posted = 0 AND CAST(ValueDate AS date) = CAST (@WorkingDate AS date)
    GROUP BY
        glaccount, dorc, valuedate, branchCode,currencycode, TransactionNumber, CrossBranchCode, CrossCurrencyCode) glc
INNER JOIN [o9accounting].dbo.[accountbalance] acb ON
    glc.GLAccount = acb.AccountNumber

UNION

    SELECT
    lower(replace(newid(), '-', '')) AS REF,
    glc.TransactionNumber,
    glc.glaccount,
    glc.dorc,
    glc.valuedate,
    glc.amount,
    glc.branchCode,
    glc.currencycode,
    glc.crossBranchCode,
    glc.crossCurrencyCode,
    glc.dorc
FROM
    ( SELECT GLAccount, DorC, ValueDate, Sum(Amount) Amount, branchCode, currencycode, TransactionNumber, CrossBranchCode, CrossCurrencyCode
    FROM [o9cash].dbo.[glentries]
    WHERE transactionstatus = 'N' AND posted = 0 AND CAST(ValueDate AS date) = CAST (@WorkingDate AS date)
    GROUP BY
        glaccount, dorc, valuedate, branchCode, currencycode, TransactionNumber, CrossBranchCode, CrossCurrencyCode) glc
INNER JOIN [o9accounting].dbo.[accountbalance] acb ON
    glc.GLAccount = acb.AccountNumber

UNION

    SELECT
    lower(replace(newid(), '-', '')) AS REF,
    glc.TransactionNumber,
    glc.glaccount,
    glc.dorc,
    glc.valuedate,
    glc.amount,
    glc.branchCode,
    glc.currencycode,
    glc.crossBranchCode,
    glc.crossCurrencyCode,
    glc.dorc
FROM
    ( SELECT GLAccount, DorC, ValueDate, Sum(Amount) Amount, branchCode, currencycode, TransactionNumber, CrossBranchCode, CrossCurrencyCode
    FROM [o9accounting].dbo.[glentries]
    WHERE transactionstatus = 'N' AND posted = 0 AND CAST(ValueDate AS date) = CAST (@WorkingDate AS date)
    GROUP BY
        glaccount, dorc, valuedate, branchCode, currencycode, TransactionNumber, CrossBranchCode, CrossCurrencyCode) glc
INNER JOIN [o9accounting].dbo.[accountbalance] acb ON
    glc.GLAccount = acb.AccountNumber

    -- Proccess IBT
    DECLARE @countIBT1 INT = 0;
    SELECT @countIBT1 = COUNT(*) FROM @ListOfAccount lst
    WHERE lst.crossBranchCode IS NOT NULL AND lst.crossBranchCode <> '' AND lst.branchCode <> lst.crossBranchCode;
    
    DECLARE @countIBT2 INT = 0;
    SELECT @countIBT2 = COUNT(*) FROM @ListOfAccount lst
    INNER JOIN o9accounting.dbo.AccountClearing ac ON lst.branchCode = ac.BranchCode AND lst.crossBranchCode = ac.ClearingBranchCode 
    WHERE lst.crossBranchCode IS NOT NULL AND lst.crossBranchCode <> '' AND lst.branchCode <> lst.crossBranchCode AND ac.CurrencyId = lst.currencycode
    
    IF @countIBT1 <> @countIBT2 THROW 51000, 'Invalid account clearing', 1;

    DECLARE @ListOfAccountIBT TABLE (
        refId varchar(50),
        transNumber varchar(50),
        glaccount varchar(36),
        dorc varchar(2),
        branchCode varchar(10),
        currencycode varchar(5),
        crossBranchCode varchar(10),
        crossCurrencyCode varchar(5),
        valuedate date,
        amount decimal(38,2),
        transcode varchar(50)
    );

    INSERT INTO @ListOfAccountIBT(refId, transNumber, glaccount,dorc, valuedate, amount, branchCode, currencycode, transcode)
    SELECT lst.refId, lst.transNumber, ac.AccountNumber,CASE WHEN dorc = 'D' THEN 'C' ELSE 'D' END, lst.valuedate, lst.amount, ac.branchCode, lst.currencycode, CASE WHEN dorc = 'D' THEN 'C' ELSE 'D' END
    FROM @ListOfAccount lst
    INNER JOIN o9accounting.dbo.AccountClearing ac ON lst.branchCode = ac.BranchCode AND lst.crossBranchCode = ac.ClearingBranchCode 
    WHERE lst.crossBranchCode IS NOT NULL AND lst.crossBranchCode <> '' AND lst.branchCode <> lst.crossBranchCode AND ac.CurrencyId = lst.currencycode

    INSERT INTO @ListOfAccountIBT
    SELECT * FROM @ListOfAccount lst;

    DECLARE @unbalance INT = 0;
    SELECT @unbalance = CASE WHEN SUM(CASE WHEN dorc = 'C' THEN amount ELSE -amount END) <> 0 THEN 1 ELSE 0 END FROM @ListOfAccountIBT

    IF @unbalance <> 0 THROW 51000, 'unbalance posting', 1;

    INSERT INTO [o9accounting].dbo.[accountstatement] (
        TransactionNumber,
        accountnumber,
        currencycode,
        convertamount,
        amount,
        referenceid,
        statementstatus,
        statementdate,
        valuedate,
        statementcode,
        refnumber,
        transcode,
        description,
        createdonutc,
        updatedonutc)
    SELECT transNumber, glaccount, currencycode, 0, amount, refId, 'N', GETUTCDATE(), valuedate,
    CASE WHEN transcode = 'D' THEN 'WDR' ELSE 'DEP' END, '', transcode, @StepName, GETUTCDATE(), GETUTCDATE()
    FROM @ListOfAccountIBT
    
    UPDATE [o9accounting].dbo.[accountbalance]
    SET
            balance = balance - lst.amount,
            DailyDebit = DailyDebit + lst.amount, 
            WeeklyDebit = WeeklyDebit + lst.amount, 
            MonthlyDebit = MonthlyDebit + lst.amount, 
            QuarterlyDebit = QuarterlyDebit + lst.amount, 
            HalfYearlyDebit = HalfYearlyDebit + lst.amount, 
            YearlyDebit = YearlyDebit + lst.amount
    FROM [o9accounting].dbo.[accountbalance] ac
    INNER JOIN ( SELECT Sum(Amount) AS Amount,glaccount, dorc FROM  @ListOfAccountIBT GROUP BY glaccount, dorc) lst ON ac.AccountNumber = lst.glaccount
    WHERE lst.dorc = 'D';
    
    UPDATE [o9accounting].dbo.[accountbalance]
    SET
            balance = balance + lst.amount, 
            dailycredit = dailycredit + lst.amount, 
            WeeklyCredit = WeeklyCredit + lst.amount, 
            MonthlyCredit = MonthlyCredit + lst.amount, 
            QuarterlyCredit = QuarterlyCredit + lst.amount, 
            HalfYearlyCredit = HalfYearlyCredit + lst.amount, 
            YearlyCredit = YearlyCredit + lst.amount
    FROM [o9accounting].dbo.[accountbalance] ac
    INNER JOIN ( SELECT Sum(Amount) AS Amount,glaccount, dorc FROM  @ListOfAccountIBT GROUP BY glaccount, dorc) lst ON ac.AccountNumber = lst.glaccount
    WHERE lst.dorc = 'C';


    UPDATE [o9deposit].dbo.[glentries]
    SET
        posted = 1
    FROM [o9deposit].dbo.[glentries] gl
    INNER JOIN @ListOfAccount lst ON gl.GLAccount = lst.glaccount
    WHERE
        gl.posted = 0
        AND gl.valuedate = lst.valuedate
        AND gl.dorc = lst.dorc;
    
    UPDATE [o9credit].dbo.[glentries]
    SET
        posted = 1
    FROM [o9credit].dbo.[glentries] gl
    INNER JOIN @ListOfAccount lst ON gl.GLAccount = lst.glaccount
    WHERE
        gl.posted = 0
        AND gl.valuedate = lst.valuedate
        AND gl.dorc = lst.dorc;
    
    UPDATE [o9cash].dbo.[glentries]
    SET
        posted = 1
    FROM [o9cash].dbo.[glentries] gl
    INNER JOIN @ListOfAccount lst ON gl.GLAccount = lst.glaccount
    WHERE
        gl.posted = 0
        AND gl.valuedate = lst.valuedate
        AND gl.dorc = lst.dorc;

COMMIT TRANSACTION;
END TRY
BEGIN CATCH
ROLLBACK TRANSACTION;

throw;
END CATCH;
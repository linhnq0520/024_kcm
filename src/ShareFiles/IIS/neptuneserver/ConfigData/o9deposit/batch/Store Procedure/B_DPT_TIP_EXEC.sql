USE o9deposit;
GO
    IF OBJECT_ID('[B_DPT_TIP_EXEC]', 'P') IS NOT NULL BEGIN -- The procedure exists
    DROP PROCEDURE B_DPT_TIP_EXEC;END;
GO


CREATE PROCEDURE [dbo].[B_DPT_TIP_EXEC] (
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
    @ChannelID NVARCHAR(200) = 'C'
) AS DECLARE @TransCode varchar(100) = 'IFC_IPAY';

BEGIN TRY 

DECLARE @current_working_date DATE = @WorkingDate;
DECLARE @StartTime DATE = GETUTCDATE();
DECLARE @BatchStepName VARCHAR(100) = 'B_DPT_TIP_EXEC';-- Create transaction

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
    @ChannelID = @ChannelID;-- Main processing code here
    
DECLARE @ListOfAccount TABLE (
    id INT identity(1, 1),
    AccountNumber VARCHAR(100),
    Currencycode VARCHAR(10),
    InterestAccrual DECIMAL(24, 5) DEFAULT 0,
    CurrentBalance DECIMAL(24, 5) DEFAULT 0,
    Intpbl DECIMAL(24, 5) DEFAULT 0,
    Amount DECIMAL(24, 5) DEFAULT 0,
    Amtpbl DECIMAL(24, 5) DEFAULT 0,
    InterestDue DECIMAL(24, 5) DEFAULT 0
);-- List of accounts to be paid due interest

    INSERT INTO
        @ListOfAccount (
            AccountNumber,
            Currencycode,
            InterestAccrual,
            CurrentBalance,
            InterestDue
        )
    SELECT
        A.AccountNumber,
        Currencycode,
        InterestAccrual,
        CurrentBalance,
        InterestDue
    FROM
        dbo.DepositAccount A
    WHERE
        DepositType = 'S'
        AND InterestAccrual + InterestDue > 0
        AND DepositStatus NOT IN ('C', 'B');
        
        UPDATE
            dbo.DepositAccount
        SET
            InterestAccrual = a.InterestAccrual - b.InterestAccrual,
            InterestDue = a.InterestDue - b.InterestDue,
            Intpbl = a.Intpbl - ROUND(b.InterestAccrual, 2),
            InterestPaid = a.InterestPaid + b.InterestDue + ROUND(b.InterestAccrual, 2)
        FROM dbo.DepositAccount a
        INNER JOIN @ListOfAccount b ON a.AccountNumber = b.AccountNumber;
        
    BEGIN TRANSACTION;

        DECLARE @Stcode varchar(30);
        SELECT @Stcode = ISNULL(TransactionType, '-') FROM o9admin.dbo.TransactionDefinition td WHERE TransactionCode = 'DPT_TIP';
        INSERT INTO [DepositAccountTrans]
        (
            [TransId], [TransactionNumber], [DepositAccount], [TransCode], [TransactionStatus], [Amount], [GLPopulated]
        )
        SELECT NewID(), @TransactionNumber, account.AccountNumber, 'DPT_CREDIT_BALANCE', 'N', balance.Amount, 0
        FROM (SELECT AccountNumber, SUM(ROUND(Amount, 2)) Amount FROM dbo.IfcBalance
            WHERE Amount > 0 AND IfcBalanceStatus = 'N'
                GROUP BY  AccountNumber) balance
        INNER JOIN @ListOfAccount account ON balance.AccountNumber = account.AccountNumber;
    
        insert into DepositStatement
            (
            [AccountNumber]
            , [StatementDate]
            , [ReferenceId]
            , [ValueDate]
            , [Amount]
            , [CurrencyCode]
            , [ConvertAmount]
            , [StatementCode]
            , [StatementStatus]
            , [RefNumber]
            , [TransCode]
            , [TransactionNumber]
            , [Description]
            , [CreatedOnUtc]
            , [UpdatedOnUtc]
            )
            SELECT 
                account.AccountNumber
                , GETUTCDATE()
                , @RefId  
                , @WorkingDate  
                , trans.Amount
                , account.Currencycode 
                , trans.Amount 
                , 'DEP' -- 'DEP'/'WDR' 
                , 'N' -- [StatementStatus]
                , NULL --[RefNumber]
                , 'DPT_CREDIT_BALANCE' -- [TransactionCode]
                , @TransactionNumber
                , @StepName + ': Interest repayment for Saving: ['+ account.AccountNumber +']' -- [Description]
                , GETUTCDATE()
                , GETUTCDATE()
            FROM [DepositAccountTrans] trans
            INNER JOIN dbo.DepositAccount account ON trans.DepositAccount = account.AccountNumber
            WHERE trans.TransactionNumber = @TransactionNumber;
    
        UPDATE dbo.DepositAccount SET CurrentBalance = CurrentBalance + trans.Amount
        FROM dbo.DepositAccount account
        INNER JOIN [DepositAccountTrans] trans ON trans.DepositAccount = account.AccountNumber
        WHERE trans.TransactionNumber = @TransactionNumber;

        INSERT INTO
            DepositHistory (
                [AccountNumber],
                [ValueDate],
                [RefId],
                [TransactionDate],
                [TransactionCode],
                [Amount],
                [Dorc],
                [Description],
                [UsrCode],
                [Oder],
                [DepositHistoryStatus],
                [Stcode],
                [Usrid],
                [ChannelId])
         SELECT 
            DepositAccount, 
            @WorkingDate, 
            @RefId, 
            GETUTCDATE(), 
            @StepName, 
            Amount, 
            'C', 
            @StepName + ': Interest repayment for Saving [' + DepositAccount + ']', -- [Description],
            @UserCode, -- [UsrCode]
            1, -- [Oder]
            'N', -- [DepositHistoryStatus]
            @Stcode, -- [Stcode]
            0, --[Usrid]
            @ChannelID -- [ChannelId]
        FROM [DepositAccountTrans]
        WHERE TransactionNumber = @TransactionNumber;


    -- IFC
    INSERT INTO
    dbo.IFCBalanceDetail(
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
            'DPT' AS [ModuleCode] ,
            balance.AccountNumber ,
            balance.IfcCode ,
            IfcValue + MarginValue,
            account.CurrentBalance ,
            @WorkingDate AS [FromDate] ,
            @WorkingDate AS [ToDate] ,
            'A' AS [Action] ,
            ROUND(balance.Amount, 2) - balance.Amount AS [Amount] ,
            @ReferenceId AS [ReferenceId] ,
            @BatchStepName AS [IFCBalanceDetailDescription]
        FROM dbo.IFCBalance balance
        INNER JOIN @ListOfAccount account ON balance.AccountNumber = account.AccountNumber
    WHERE
        balance.Amount > 0 AND balance.IfcBalanceStatus = 'N';
    
    INSERT INTO
    dbo.IFCBalanceDetail(
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
            'DPT' AS [ModuleCode] ,
            balance.AccountNumber ,
            balance.IfcCode ,
            balance.IfcValue + balance.MarginValue ,
            account.CurrentBalance ,
            @WorkingDate AS [FromDate] ,
            @WorkingDate AS [ToDate] ,
            'D' AS [Action] ,
            ROUND(balance.Amount,2) AS [Amount] ,
            @ReferenceId AS [ReferenceId] ,
            @BatchStepName AS [IFCBalanceDetailDescription]
        FROM dbo.IFCBalance balance
        INNER JOIN @ListOfAccount account ON balance.AccountNumber = account.AccountNumber
        INNER JOIN dbo.DepositIFCDefinition di ON di.IfcCode = balance.IfcCode
    WHERE balance.Amount > 0 AND di.IfcType = 'I' AND balance.IfcBalanceStatus = 'N';

    
    INSERT INTO
        [DepositIFCBalanceTrans](
            [TransId],
            [TransactionNumber],
            [DepositAccount],
            [IFCCode],
            [TransCode],
            [TransactionStatus],
            [Amount],
            [GLPopulated],
            [CrossBranchCode],
            [CrossCurrencyCode],
            [BaseCurrencyAmount]
        )
    SELECT
        NewID() AS [TransId],
        @TransactionNumber AS [TransactionNumber],
        account.AccountNumber AS [DepositAccount],
        detail.[IFCCode] AS [IFCCode],
        @TransCode AS [TransCode],
        'N' AS [TransactionStatus],
        detail.Amount AS [Amount],
        0 AS [GLPopulated],
        NULL AS [CrossBranchCode],
        NULL AS [CrossCurrencyCode],
        0 AS [BaseCurrencyAmount]
    FROM
        dbo.IFCBalanceDetail detail
        INNER JOIN dbo.DepositAccount account ON detail.AccountNumber = account.AccountNumber
        INNER JOIN dbo.DepositIFCDefinition ifcdef ON ifcdef.IfcCode = detail.IfcCode
    WHERE detail.ReferenceId = @ReferenceId AND detail.[Action] = 'D';
        
     UPDATE
         dbo.IFCBalance
     SET
         Amount = balance.Amount + detail.Amount
   FROM
         dbo.IFCBalance balance
         INNER JOIN (SELECT * FROM dbo.[IFCBalanceDetail] WHERE ReferenceId = @ReferenceId AND [Action] = 'A') detail 
         ON balance.AccountNumber = detail.AccountNumber AND balance.IfcCode = detail.IfcCode

    UPDATE
        dbo.IFCBalance
    SET
        Amount = Amount - detail.DetailAmount,
        Paid = Paid + detail.DetailAmount,
        Amtpbl = Amtpbl - detail.DetailAmount
    FROM
        dbo.IFCBalance balance
        INNER JOIN (SELECT AccountNumber, IfcCode, Amount AS DetailAmount FROM [IFCBalanceDetail] WHERE [Action] = 'D' AND ReferenceId = @ReferenceId) detail  ON balance.AccountNumber = detail.AccountNumber
        AND balance.IfcCode = detail.IfcCode

    EXEC GenerateGLEntriesFromDepositAccountTrans @TransactionNumber = @TransactionNumber;-- Generate GL From DepositIFCBalanceTrans (for debit deposit)
    EXEC GenerateGLEntriesFromDepositIFCBalanceTrans @TransactionNumber = @TransactionNumber;-- null: Generate to all un-populated rows

COMMIT TRANSACTION;
END TRY BEGIN CATCH ROLLBACK TRANSACTION;
throw;
END CATCH;

GO
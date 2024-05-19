use o9deposit;
GO

IF OBJECT_ID('[B_DPT_ACI_EXEC]', 'P') IS NOT NULL
BEGIN
    -- The procedure exists
    DROP PROCEDURE B_DPT_ACI_EXEC;
END;
GO

CREATE PROCEDURE [dbo].[B_DPT_ACI_EXEC] (
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
    )
AS
DECLARE @current_working_date DATE = @WorkingDate;

DECLARE @StartTime DATE = GETUTCDATE();

DECLARE @BatchStepName VARCHAR(100) = 'B_DPT_ACI_EXEC';

DECLARE @ListOfAccount TABLE (
    Id INT identity(1, 1),
    DebitAccount VARCHAR(100),
    CurrentBalanceDebit DECIMAL(24, 5) DEFAULT 0,
    CreditAccount VARCHAR(100),
    DebitCurrency VARCHAR(10),
    CreditCurrency VARCHAR(10),
    DebitBranchCode VARCHAR(10),
    CreditBranchCode VARCHAR(10),
    InterestDue DECIMAL(24, 5) DEFAULT 0,
    Intpre DECIMAL(24, 5) DEFAULT 0,
    Intovd DECIMAL(24, 5) DEFAULT 0,
    Intspamt DECIMAL(24, 5) DEFAULT 0,
    InterestNotPaid DECIMAL(24, 5) DEFAULT 0,
    Intpbl DECIMAL(24, 5) DEFAULT 0,
    TotalDebitAmount DECIMAL(24, 5) DEFAULT 0,
    RepaymentBalance DECIMAL(24, 5) DEFAULT 0
);

DECLARE @TransCode varchar(100)= 'IFC_IPAY';

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
        
        INSERT INTO @ListOfAccount ( DebitAccount, CurrentBalanceDebit, CreditAccount, DebitCurrency, CreditCurrency,DebitBranchCode, CreditBranchCode, InterestDue, Intovd, InterestNotPaid, TotalDebitAmount )
          SELECT
                    D.AccountNumber DebitAccount,          /*Debit account*/
                    D.CurrentBalance CurrentBalanceDebit,
                    T.AccountNumber CreditAccount,          /*Credit account*/
                    D.CurrencyCode DebitCurrency,         /*Debit currency*/
                    T.CurrencyCode CreditCurrency,         /*Credit currency*/
                    D.BranchCode DebitBranchCode,
                    T.BranchCode CreditBranchCode,
                    D.InterestDue,
                    D.Intovd,
                    D.InterestNotPaid,
                    D.InterestDue + D.Intovd + D.InterestNotPaid TotalDebitAmount  /* Total debit amount*/
               FROM dbo.DepositAccount D ,
                    (SELECT E.MasterAccountNumber, T.AccountNumber, T.CurrencyCode, T.BranchCode, T.DepositStatus FROM dbo.AccountLinkage E
                    INNER JOIN dbo.DepositAccount T ON E.LinkageAccountNumber = T.AccountNumber
                    WHERE MasterModuleCode = 'DPT' AND LinkageModuleCode = 'DPT' AND LinkageType = 'D' AND LinkageClass IN ( 'I','A' ) 
                            AND T.DepositType IN ('C', 'S')) T
              WHERE D.AccountNumber = T.MasterAccountNumber AND D.CurrencyCode = T.CurrencyCode
                AND T.DepositStatus = 'N' AND D.Rollover <> 'A'
                    AND (
                        (D.DepositStatus NOT IN ('C', 'B', 'S', 'P') AND CAST(D.EndOfTenor AS DATE) = CAST(@WorkingDate AS DATE))
                    OR  (D.DepositStatus = 'M' AND CAST(D.EndOfTenor AS DATE) <= CAST(@WorkingDate AS DATE))
                    );
        
        -- Credit linkage
        INSERT INTO [DepositAccountTrans]
        (
            [TransId], [TransactionNumber], [DepositAccount], [TransCode], [TransactionStatus], [Amount], [GLPopulated], [CrossBranchCode], [CrossCurrencyCode]
        )
        SELECT NewID(), @TransactionNumber, CreditAccount, 'DPT_CREDIT_BALANCE', 'N', TotalDebitAmount, 0, DebitBranchCode, DebitCurrency  FROM @ListOfAccount WHERE TotalDebitAmount <> 0;
    
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
                CreditAccount 
                , GETUTCDATE()
                , @RefId  
                , @WorkingDate  
                , TotalDebitAmount  
                , CreditCurrency 
                , TotalDebitAmount 
                , 'DEP' -- 'DEP'/'WDR' 
                , 'N' -- [StatementStatus]
                , NULL --[RefNumber]
                , 'DPT_CREDIT_BALANCE' -- [TransactionCode]
                , @TransactionNumber
                , @StepName + ': Auto Repayment interest From AC ['+ DebitAccount +'] to ['+ CreditAccount +']'-- [Description]
                , GETUTCDATE()
                , GETUTCDATE()
            FROM @ListOfAccount WHERE TotalDebitAmount <> 0;
    
        UPDATE dbo.DepositAccount SET CurrentBalance = CurrentBalance + trans.Amount
        FROM dbo.DepositAccount da
        INNER JOIN [DepositAccountTrans] trans ON da.AccountNumber = trans.DepositAccount
        WHERE trans.TransactionNumber = @TransactionNumber;
        
        -- Debit account Fixed
        UPDATE dbo.DepositAccount SET 
        InterestDue = da.InterestDue - lst.InterestDue,
        Intovd = da.Intovd - lst.Intovd,
        InterestNotPaid = da.InterestNotPaid - lst.InterestNotPaid,
        InterestPaid = InterestPaid + lst.InterestDue
        FROM dbo.DepositAccount da
        INNER JOIN @ListOfAccount lst ON da.AccountNumber = lst.DebitAccount
        WHERE lst.TotalDebitAmount <> 0
    
        DECLARE @Stcode varchar(30);
        SELECT @Stcode = ISNULL(TransactionType, '-') 
        FROM o9admin.dbo.TransactionDefinition td 
        WHERE TransactionCode = 'DPT_ACI';
        
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
                [ChannelId]
   )
        SELECT CreditAccount, @WorkingDate,@RefId,GETUTCDATE(),@StepName, TotalDebitAmount, 'C',
                @StepName + ': Auto pay interest from deposit account [' + DebitAccount + ']',
                @UserCode,1,'N',@Stcode,0,@ChannelID
        FROM @ListOfAccount WHERE TotalDebitAmount <> 0
        UNION
        SELECT DebitAccount, @WorkingDate,@RefId,GETUTCDATE(),@StepName, 0, 'N',
                @StepName + ': Auto pay interest to deposit account [' + CreditAccount + ']',
                @UserCode,1,'N',@Stcode,0,@ChannelID
        FROM @ListOfAccount WHERE TotalDebitAmount <> 0
    
    -- IFC
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
                        'DPT' AS [ModuleCode] ,
                        balance.AccountNumber ,
                        balance.IfcCode ,
                        IfcValue + MarginValue,
                        account.CurrentBalanceDebit ,
                        @WorkingDate AS [FromDate] ,
                        @WorkingDate AS [ToDate] ,
                        'D' AS [Action] ,
                         balance.Amount [Amount] ,
                        @ReferenceId AS [ReferenceId] ,
    @BatchStepName AS [IFCBalanceDetailDescription]
            FROM
                dbo.IFCBalance balance
            INNER JOIN @ListOfAccount account ON
                balance.AccountNumber = account.DebitAccount
            WHERE balance.Amount > 0;
            
            INSERT INTO [DepositIFCBalanceTrans]([TransId], [TransactionNumber], [DepositAccount], [IFCCode], [TransCode], [TransactionStatus], [Amount], [GLPopulated], [CrossBranchCode], [CrossCurrencyCode], [BaseCurrencyAmount])
                        SELECT NewID() AS [TransId]
                            , @TransactionNumber AS [TransactionNumber]
                            , detail.AccountNumber AS [DepositAccount]
                            , detail.[IFCCode] AS [IFCCode]
                            , @TransCode AS [TransCode]
                            , 'N' AS [TransactionStatus]
                            , detail.Amount AS [Amount]
                            , 0 AS [GLPopulated]
                            , account.CreditBranchCode AS [CrossBranchCode]
                            , account.CreditCurrency AS [CrossCurrencyCode]
                            , 0 AS [BaseCurrencyAmount]
            FROM IFCBalanceDetail detail
            INNER JOIN @ListOfAccount account ON account.DebitAccount = detail.AccountNumber 
            WHERE ReferenceId = @ReferenceId;
            
            
        UPDATE IFCBalance
            SET
            Amount = balance.Amount - detail.Amount,
            Paid = balance.Paid + detail.Amount,
            Amtpbl = balance.Amtpbl - detail.Amount
        FROM IFCBalance balance
        INNER JOIN IFCBalanceDetail detail ON
            balance.AccountNumber = detail.AccountNumber
            AND balance.IfcCode = detail.IfcCode
            WHERE detail.ReferenceId = @ReferenceId;
        
        -- Create GL entries
        EXEC GenerateGLEntriesFromDepositAccountTrans  @TransactionNumber = @TransactionNumber;
        EXEC GenerateGLEntriesFromDepositIFCBalanceTrans  @TransactionNumber = @TransactionNumber;

COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    throw;
END CATCH;
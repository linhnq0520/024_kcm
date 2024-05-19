use o9deposit;

IF OBJECT_ID('[B_DPT_ROV_EXEC]', 'P') IS NOT NULL
BEGIN
    -- The procedure exists
    DROP PROCEDURE B_DPT_ROV_EXEC
;
END;
GO

CREATE PROCEDURE [dbo].[B_DPT_ROV_EXEC] (
    @TransactionNumber VARCHAR(36),
    @WorkingDate DATE,
    @UserCode NVARCHAR(50),
    @UserName NVARCHAR(250),
    @BatchDate DATETIME,
    @StepName NVARCHAR(200),
    @ReferenceId NVARCHAR(200) = '',
    @RefId NVARCHAR(200) = '',
    @ReferenceCode NVARCHAR(200) = NULL,
    @TranId NVARCHAR(200) = NULL,
    @Description NVARCHAR(200) = NULL,
    @BusinessCode NVARCHAR(200) = NULL,
    @ChannelID NVARCHAR(200) = 'C'
    )
AS
DECLARE @current_working_date DATE = @WorkingDate;

DECLARE @StartTime DATE = GETUTCDATE();

DECLARE @BatchStepName VARCHAR(100) = 'B_DPT_ROV_EXEC';

DECLARE @ListOfAccount TABLE (
    Id INT identity(1, 1),
    AccountNumber VARCHAR(100),
    Rollover VARCHAR(100),
    DepositStatus VARCHAR(3),
    BranchCode VARCHAR(10),
    CurrencyCode VARCHAR(3),
    CurrentBalance DECIMAL(24, 5) DEFAULT 0,
    InterestDue DECIMAL(24, 5) DEFAULT 0,
    Intpbl DECIMAL(24, 5) DEFAULT 0,
    CatalogCode  VARCHAR(100),
    InterestPaid DECIMAL(24, 5) DEFAULT 0,
    Amount DECIMAL(24, 5) DEFAULT 0,
    Paid DECIMAL(24, 5) DEFAULT 0,
    DepositGroup  VARCHAR(100),
    InterestNotPaid DECIMAL(24, 5) DEFAULT 0,
    AccountLinkage VARCHAR(100) DEFAULT NULL,
    AccountLinkageStatus VARCHAR(3) DEFAULT NULL,
    LinkageBranchCode VARCHAR(10),
    LinkageCurrencyCode VARCHAR(3)
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
            
        
        INSERT INTO @ListOfAccount ( AccountNumber, Rollover,DepositStatus,BranchCode, CurrencyCode, CurrentBalance,InterestDue,Intpbl,CatalogCode,InterestPaid,DepositGroup,InterestNotPaid, AccountLinkage, AccountLinkageStatus, LinkageBranchCode, LinkageCurrencyCode)
        SELECT A.AccountNumber, A.Rollover,A.DepositStatus,A.BranchCode, A.CurrencyCode, A.CurrentBalance , A.InterestDue, A.Intpbl,
          (CASE WHEN  A.RolloverToCatalog IS NULL OR A.RolloverToCatalog = '' THEN a.CatalogCode ELSE A.RolloverToCatalog END) AS CatalogCode, 
          A.InterestPaid,  DepositGroup, InterestNotPaid, linkage.LinkageAccountNumber AS AccountLinkage, linkage.AccountLinkageStatus, linkage.LinkageBranchCode, linkage.LinkageCurrencyCode
        FROM    dbo.DepositAccount A 
        LEFT JOIN (SELECT al.*, ac.DepositStatus AS AccountLinkageStatus, ac.BranchCode as LinkageBranchCode, ac.CurrencyCode as LinkageCurrencyCode FROM dbo.AccountLinkage al
                    INNER JOIN (SELECT AccountNumber, DepositStatus, BranchCode, CurrencyCode FROM dbo.DepositAccount) ac ON al.LinkageAccountNumber = ac.AccountNumber
                    WHERE al.LinkageType = 'D' AND al.LinkageClass IN ('I', 'A')
        ) linkage ON A.AccountNumber = linkage.MasterAccountNumber
        WHERE (Tenor + Tenor2) > 0 AND DepositStatus IN ('M','D','B')
        AND ((a.Rollover <> 'N' AND CAST(EndOfTenor AS DATE) = CAST(@WorkingDate AS DATE)) OR (a.Rollover = 'N' AND linkage.LinkageAccountNumber IS NOT NULL));
    
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
            balance.IfcValue + balance.MarginValue ,
            account.CurrentBalance ,
            @WorkingDate AS [FromDate] ,
            @WorkingDate AS [ToDate] ,
            'D' AS [Action] ,
            balance.Amount AS [Amount] ,
            @ReferenceId AS [ReferenceId] ,
            @BatchStepName AS [IFCBalanceDetailDescription]
        FROM dbo.IFCBalance balance
        INNER JOIN @ListOfAccount account ON balance.AccountNumber = account.AccountNumber
        INNER JOIN dbo.DepositIFCDefinition di ON di.IfcCode = balance.IfcCode
WHERE balance.Amount > 0 AND di.IfcType = 'I' AND balance.IfcBalanceStatus = 'N' 
           AND account.Rollover = 'A' AND account.DepositStatus <> 'B';

    
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
        detail.AccountNumber AS [DepositAccount],
        detail.[IFCCode] AS [IFCCode],
        @TransCode AS [TransCode],
        'N' AS [TransactionStatus],
        detail.Amount AS [Amount],
        0 AS [GLPopulated],
        account.LinkageBranchCode AS [CrossBranchCode],
        account.LinkageCurrencyCode AS [CrossCurrencyCode],
        0 AS [BaseCurrencyAmount]
    FROM dbo.IFCBalanceDetail detail
    INNER JOIN @ListOfAccount account ON detail.AccountNumber = account.AccountNumber
    WHERE detail.ReferenceId = @ReferenceId AND detail.[Action] = 'D';

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
    
    DECLARE @Stcode varchar(30);
    SELECT @Stcode = ISNULL(TransactionType, '-') 
    FROM o9admin.dbo.TransactionDefinition td 
    WHERE TransactionCode = 'DPT_ROV';
    
        -- WHEN Rollover = A => CurrentBalance= CurrentBalance + InterestDue
        INSERT INTO [DepositAccountTrans]
        (
            [TransId], [TransactionNumber], [DepositAccount], [TransCode], [TransactionStatus], [Amount], [GLPopulated], [CrossBranchCode], [CrossCurrencyCode]
        )
        SELECT NewID(), @TransactionNumber, lst.AccountNumber, 'DPT_CREDIT_BALANCE', 'N', lst.InterestDue, 0  , da.BranchCode, da.CurrencyCode
        FROM dbo.DepositAccount da
        INNER JOIN @ListOfAccount lst ON da.AccountNumber = lst.AccountNumber
        WHERE lst.InterestDue <> 0 AND lst.Rollover = 'A' AND lst.DepositStatus <> 'B';
    
        INSERT INTO DepositStatement
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
                lst.AccountNumber 
                , GETUTCDATE()
                , @RefId  
                , @WorkingDate  
                , lst.InterestDue  
                , da.CurrencyCode 
                , lst.InterestDue 
                , 'DEP' -- 'DEP'/'WDR' 
                , 'N' -- [StatementStatus]
                , NULL --[RefNumber]
                , 'DPT_CREDIT_BALANCE' -- [TransactionCode]
                , @TransactionNumber
                , @StepName + ': Auto renew account [' + lst.AccountNumber + ']'-- [Description]
                , GETUTCDATE()
                , GETUTCDATE()
            FROM dbo.DepositAccount da
            INNER JOIN @ListOfAccount lst ON da.AccountNumber = lst.AccountNumber 
            WHERE lst.InterestDue <> 0 AND lst.Rollover = 'A' AND lst.DepositStatus <> 'B';
        
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
                    [ChannelId] )
                 SELECT AccountNumber, @WorkingDate,@RefId,GETUTCDATE(),@StepName, InterestDue, 'C',
                    @StepName + ': Auto renew account [' + AccountNumber + ']',
                    @UserCode,1,'N',@Stcode,0,@ChannelID
        FROM @ListOfAccount WHERE InterestDue <> 0 AND Rollover = 'A' AND DepositStatus <> 'B';
    
        UPDATE dbo.DepositAccount SET CurrentBalance = da.CurrentBalance + lst.InterestDue
        FROM dbo.DepositAccount da
        INNER JOIN @ListOfAccount lst ON da.AccountNumber = lst.AccountNumber
        WHERE lst.InterestDue <> 0 AND lst.Rollover = 'A' AND lst.DepositStatus <> 'B';
    
        -- WHEN Rollover = N => Transfer CurrentBalance Fixed to Account Linkage
        -- CREDIT
        INSERT INTO [DepositAccountTrans]
        (
            [TransId], [TransactionNumber], [DepositAccount], [TransCode], [TransactionStatus], [Amount], [GLPopulated], [CrossBranchCode], [CrossCurrencyCode]
        )
        SELECT NewID(), @TransactionNumber, AccountLinkage, 'DPT_CREDIT_BALANCE', 'N', lst.CurrentBalance, 0 , lst.BranchCode, lst.CurrencyCode
        FROM dbo.DepositAccount da
        INNER JOIN @ListOfAccount lst ON da.AccountNumber = lst.AccountLinkage
        WHERE lst.Rollover = 'N' AND lst.AccountLinkage IS NOT NULL AND lst.AccountLinkageStatus = 'N' AND lst.DepositStatus <> 'B';
    
        INSERT INTO DepositStatement
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
                lst.AccountLinkage 
                , GETUTCDATE()
                , @RefId  
                , @WorkingDate  
                , lst.CurrentBalance  
                , da.CurrencyCode
                , lst.CurrentBalance 
                , 'DEP' -- 'DEP'/'WDR' 
                , 'N' -- [StatementStatus]
                , NULL --[RefNumber]
                , 'DPT_CREDIT_BALANCE' -- [TransactionCode]
                , @TransactionNumber
                , @StepName +': Trasfer balance from [' + lst.AccountNumber +'] to ['+lst.AccountLinkage+']' -- [Description]
                , GETUTCDATE()
                , GETUTCDATE()
            FROM dbo.DepositAccount da
            INNER JOIN @ListOfAccount lst ON da.AccountNumber = lst.AccountLinkage
            WHERE lst.Rollover = 'N' AND lst.AccountLinkageStatus = 'N' AND lst.DepositStatus <> 'B';
        
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
                    [ChannelId] )
                 SELECT AccountLinkage, @WorkingDate,@RefId,GETUTCDATE(),@StepName, CurrentBalance, 'C',
                    @StepName + ': Auto renew account [' + AccountLinkage + ']',
                    @UserCode,1,'N',@Stcode,0,@ChannelID
        FROM @ListOfAccount WHERE CurrentBalance <> 0 AND Rollover = 'N' AND AccountLinkageStatus = 'N' AND DepositStatus <> 'B';
    
        UPDATE dbo.DepositAccount SET CurrentBalance = da.CurrentBalance + lst.CurrentBalance
        FROM dbo.DepositAccount da
        INNER JOIN @ListOfAccount lst ON da.AccountNumber = lst.AccountLinkage
        WHERE lst.Rollover = 'N' AND lst.AccountLinkageStatus = 'N' AND lst.DepositStatus <> 'B';
    
 -- DEBIT
        INSERT INTO [DepositAccountTrans]
        (
            [TransId], [TransactionNumber], [DepositAccount], [TransCode], [TransactionStatus], [Amount], [GLPopulated], [CrossBranchCode], [CrossCurrencyCode]
        )
        SELECT NewID(), @TransactionNumber, lst.AccountNumber, 'DPT_DEBIT_BALANCE', 'N', lst.CurrentBalance, 0 , lst.LinkageBranchCode, lst.LinkageCurrencyCode
        FROM dbo.DepositAccount da
        INNER JOIN @ListOfAccount lst ON da.AccountNumber = lst.AccountNumber
        WHERE lst.Rollover = 'N' AND lst.AccountLinkage IS NOT NULL AND lst.AccountLinkageStatus = 'N' AND lst.DepositStatus <> 'B';
    
        INSERT INTO DepositStatement
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
                lst.AccountNumber 
                , GETUTCDATE()
                , @RefId  
                , @WorkingDate  
                , lst.CurrentBalance  
                , da.CurrencyCode
                , lst.CurrentBalance 
                , 'WDR' -- 'DEP'/'WDR' 
                , 'N' -- [StatementStatus]
                , NULL --[RefNumber]
                , 'DPT_DEBIT_BALANCE' -- [TransactionCode]
                , @TransactionNumber
                , @StepName +': Trasfer balance from [' + lst.AccountNumber +'] to ['+lst.AccountLinkage+']' -- [Description]
                , GETUTCDATE()
                , GETUTCDATE()
            FROM dbo.DepositAccount da
            INNER JOIN @ListOfAccount lst ON da.AccountNumber = lst.AccountNumber
            WHERE lst.Rollover = 'N' AND lst.AccountLinkage IS NOT NULL AND lst.AccountLinkageStatus = 'N' AND lst.DepositStatus <> 'B';
        
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
                    [ChannelId] )
                 SELECT AccountNumber, @WorkingDate,@RefId,GETUTCDATE(),@StepName, CurrentBalance, 'D',
                    @StepName + ': Auto renew account [' + AccountNumber + ']',
                    @UserCode,1,'N',@Stcode,0,@ChannelID
        FROM @ListOfAccount WHERE Rollover = 'N' AND AccountLinkage IS NOT NULL AND AccountLinkageStatus = 'N' AND DepositStatus <> 'B';
    
        UPDATE dbo.DepositAccount SET CurrentBalance = da.CurrentBalance - lst.CurrentBalance
        FROM dbo.DepositAccount da
        INNER JOIN @ListOfAccount lst ON da.AccountNumber = lst.AccountNumber
        WHERE lst.Rollover = 'N' AND lst.AccountLinkage IS NOT NULL AND lst.AccountLinkageStatus = 'N' AND lst.DepositStatus <> 'B';
    
        DECLARE @rows INT = ( SELECT COUNT(*) FROM @ListOfAccount);
        
        DECLARE @row INT = 0;
        WHILE (@row < @rows)
            BEGIN
                SET @row = @row + 1;
        
            DECLARE @AccountNumber VARCHAR(100) = '',
                    @Rollover VARCHAR(100) = '',
                    @CatalogCode  VARCHAR(100) = '',
                    @AccountLinkage VARCHAR(100) = NULL,
                    @AccountLinkageStatus VARCHAR(3) = NULL;
            
            SELECT @AccountNumber = AccountNumber, @Rollover = Rollover, @CatalogCode = CatalogCode,
                    @AccountLinkage = AccountLinkage, @AccountLinkageStatus = AccountLinkageStatus
            FROM @ListOfAccount
            WHERE Id = @row;

            -- Rollover
            IF (@Rollover = 'A' OR (@Rollover = 'P' AND (@AccountLinkage IS NOT NULL AND @AccountLinkageStatus = 'N')))
                EXEC dbo.Rollover @AccountNumber = @AccountNumber, @CatalogCode = @CatalogCode, @WorkingDate = @WorkingDate;
            
        END;
    
        UPDATE dbo.DepositAccount
        SET BeginOfTenor = CAST(@WorkingDate AS DATE),
            EndOfTenor = dbo.NextMaturityDate(Tenor, TenorUnit, @WorkingDate),
            DepositStatus = 'M'
        FROM dbo.DepositAccount da
        INNER JOIN @ListOfAccount lst ON da.AccountNumber = lst.AccountNumber
        WHERE DepositType = 'T' AND CAST(EndOfTenor AS DATE) = CAST(@WorkingDate AS DATE) AND lst.Rollover = 'P' AND (lst.AccountLinkage IS NULL OR lst.AccountLinkageStatus <> 'N');
    
        UPDATE dbo.DepositAccount
        SET
        InterestDue = CASE WHEN lst.Rollover = 'A' OR (lst.AccountLinkage IS NOT NULL AND lst.AccountLinkageStatus = 'N') THEN 0 
                        ELSE da.InterestDue END,
        InterestPaid = CASE WHEN lst.Rollover IN ('P', 'N') AND (lst.AccountLinkage IS NULL OR lst.AccountLinkageStatus <> 'N') THEN da.InterestPaid 
                        ELSE da.InterestPaid + lst.InterestDue END,
        DepositStatus = CASE WHEN lst.Rollover = 'N' AND (lst.AccountLinkage IS NOT NULL AND lst.AccountLinkageStatus = 'N') THEN 'C' ELSE da.DepositStatus END,
        Psts = CASE WHEN lst.Rollover = 'N' AND (lst.AccountLinkage IS NOT NULL AND lst.AccountLinkageStatus = 'N') THEN CASE 
                                    WHEN LEN(Psts) < 499 
                                    THEN Psts + '|' + da.DepositStatus 
                                    ELSE SUBSTRING(Psts, 2, LEN(Psts)) + '|' + da.DepositStatus END ELSE Psts END
        FROM dbo.DepositAccount da
        INNER JOIN @ListOfAccount lst ON da.AccountNumber = lst.AccountNumber
        WHERE lst.DepositStatus <> 'B';
        
         -- Create GL entries
        EXEC GenerateGLEntriesFromDepositIFCBalanceTrans @TransactionNumber = @TransactionNumber;
        EXEC GenerateGLEntriesFromDepositAccountTrans  @TransactionNumber = @TransactionNumber;

COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    throw;
END CATCH;
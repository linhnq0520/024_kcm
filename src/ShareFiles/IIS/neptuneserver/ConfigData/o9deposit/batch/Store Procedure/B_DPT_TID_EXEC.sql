use o9deposit;

IF OBJECT_ID('[B_DPT_TID_EXEC]', 'P') IS NOT NULL
BEGIN
    -- The procedure exists
    DROP PROCEDURE B_DPT_TID_EXEC
;
END;
GO

CREATE PROCEDURE [dbo].[B_DPT_TID_EXEC] (
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

DECLARE @BatchStepName VARCHAR(100) = 'B_DPT_TID_EXEC';

DECLARE @ListOfAccount TABLE (
    Id INT identity(1, 1), 
    AccountNumber VARCHAR(100), 
    InterestAccrual DECIMAL(24, 5) DEFAULT 0, 
    Amount DECIMAL(24, 5) DEFAULT 0,
    CurrentBalance DECIMAL(24, 5) DEFAULT 0
);

-- DECLARE @TransCode varchar(100)= 'DPT_TID';

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
        
        INSERT INTO @ListOfAccount ( AccountNumber, InterestAccrual, Amount, CurrentBalance )
        SELECT A.AccountNumber, A.InterestAccrual, B.Amount, A.CurrentBalance
        FROM dbo.DepositAccount A
        LEFT JOIN
                        (
                            SELECT AccountNumber, ISNULL(SUM(Amount),0) AS Amount
                            FROM (
                                SELECT A.AccountNumber, A.Amount
                                FROM dbo.IFCBalance A, dbo.DepositIFCDefinition B
                                WHERE A.IfcCode = B.IfcCode
                                AND B.IfcType = 'T'
                                AND B.IfcSubType = 'TW'
                                AND A.ModuleCode = 'DPT'
                            ) AS B GROUP BY B.AccountNumber
                        ) B ON
        A.AccountNumber = B.AccountNumber
        WHERE Tenor > 0
        AND InterestAccrual > 0
        AND dbo.NextDueDate(InterestTenor, InterestTenorUnit, LastTransferInterestToDue, EndOfTenor, @WorkingDate) = @WorkingDate;
    
        UPDATE dbo.DepositAccount
        SET
        InterestDue = da.InterestDue + ROUND(lst.InterestAccrual, 2), 
        InterestAccrual = da.InterestAccrual - lst.InterestAccrual,
        Intpbl = da.Intpbl - ROUND(lst.InterestAccrual, 2)
        FROM dbo.DepositAccount da
        INNER JOIN @ListOfAccount lst ON da.AccountNumber = lst.AccountNumber;
    
        DECLARE @Stcode varchar(30);
        SELECT @Stcode = ISNULL(TransactionType, '-') FROM o9admin.dbo.TransactionDefinition td WHERE TransactionCode = 'DPT_TID';
   
        INSERT INTO DepositHistory (
        [AccountNumber], [ValueDate], [RefId], [TransactionDate], [TransactionCode], [Amount], [Dorc], [Description], [UsrCode], [Oder], [DepositHistoryStatus], [Stcode], [Usrid], [ChannelId])
        SELECT 
            AccountNumber, 
            @WorkingDate, 
            @RefId, 
            GETUTCDATE(), 
            @StepName, 
            0, 
            'N', 
            @StepName + ':Transfer interest to due [' + AccountNumber + ']',
            @UserCode, -- [UsrCode]
            1, -- [Oder]
            'N', -- [DepositHistoryStatus]
            @Stcode, -- [Stcode]
            0, --[Usrid]
            @ChannelID -- [ChannelId]
        FROM @ListOfAccount WHERE ROUND(InterestAccrual, 2) <> 0;
    
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
                ROUND(balance.Amount,2) - balance.Amount AS [Amount] ,
                @ReferenceId AS [ReferenceId] ,
                @BatchStepName AS [IFCBalanceDetailDescription]
            FROM dbo.IFCBalance balance
            INNER JOIN @ListOfAccount account ON balance.AccountNumber = account.AccountNumber
        WHERE
            balance.Amount > 0 AND balance.IfcBalanceStatus = 'N';

    UPDATE
         dbo.IFCBalance
     SET
         Amount = balance.Amount + detail.Amount
     FROM
         dbo.IFCBalance balance
         INNER JOIN (SELECT * FROM IFCBalanceDetail 
                WHERE ReferenceId = @ReferenceId AND [Action] = 'A' ) detail 
            ON balance.AccountNumber = detail.AccountNumber AND balance.IfcCode = detail.IfcCode

    -- Create GL entries
    EXEC GenerateGLEntriesFromDepositIFCBalanceTrans @TransactionNumber = @TransactionNumber;

COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    throw;
END CATCH;
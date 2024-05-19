use o9deposit;

IF OBJECT_ID('[B_DPT_ATL_GEN]', 'P') IS NOT NULL
BEGIN
    -- The procedure exists
    DROP PROCEDURE B_DPT_ATL_GEN
;
END;
GO

CREATE PROCEDURE [dbo].[B_DPT_ATL_GEN] (
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

DECLARE @BatchStepName VARCHAR(100) = 'B_DPT_ATL_GEN';

DECLARE @ListOfAccount TABLE (
    Id INT identity(1, 1),
    DebitAccount VARCHAR(100),
    CreditAccount VARCHAR(100),
    Amount DECIMAL(24, 5) DEFAULT 0
);

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
        
        INSERT INTO @ListOfAccount ( DebitAccount, CreditAccount, Amount )
        SELECT  
                CASE WHEN M.CurrentBalance > M.MinimumDepositAmount THEN M.AccountNumber ELSE L.AccountNumber END DebitAccount,
                CASE WHEN M.CurrentBalance < M.MinimumDepositAmount THEN M.AccountNumber ELSE L.AccountNumber END CreditAccount,
                CASE WHEN M.CurrentBalance > M.MinimumDepositAmount THEN M.CurrentBalance - M.MinimumDepositAmount ELSE LEAST(ABS(M.CurrentBalance - M.MinimumDepositAmount), L.CurrentBalance )END Amount
        FROM    dbo.DepositAccount M
        INNER JOIN
        (
            SELECT  MasterAccountNumber , LinkageAccountNumber
            FROM    dbo.AccountLinkage
            WHERE LinkageType = 'D' AND LinkageClass = 'L'
        )A ON M.AccountNumber = A.MasterAccountNumber
        INNER JOIN dbo.DepositAccount L ON L.AccountNumber = A.LinkageAccountNumber
        WHERE   M.DepositStatus <> 'C' AND L.DepositStatus <> 'C' AND
                (M.CurrentBalance > M.MinimumDepositAmount  OR (M.CurrentBalance <M.MinimumDepositAmount AND L.CurrentBalance >0));
            
        DECLARE @rows INT = ( SELECT COUNT(*) FROM @ListOfAccount);
        
        -- IF (@rows = 0)
        --         RETURN;
        DECLARE @row INT = 0;
        WHILE (@row < @rows)
            BEGIN
                SET @row = @row + 1;
        
            DECLARE @DebitAccount VARCHAR(100),
                    @CreditAccount VARCHAR(100),
                    @Amount DECIMAL(24, 5) = 0;
            
            SELECT @DebitAccount = DebitAccount, @CreditAccount = CreditAccount, @Amount = Amount
            FROM @ListOfAccount
            WHERE Id = @row;
        
            --
            EXEC DPT_CREDIT_ACCOUNT @TransactionNumber = @TransactionNumber,
            @WorkingDate = @WorkingDate,
            @StepName = @StepName,
            @AccountNumber = @CreditAccount,
            @CreditAmount = @Amount,
            @RefId = @RefId;
            
            INSERT INTO DepositHistory (
                        [AccountNumber], [ValueDate], [RefId], [TransactionDate], [TransactionCode], [Amount], [Dorc], [Description], [UsrCode], [Oder], [DepositHistoryStatus], [Stcode], [Usrid], [ChannelId]
                        )
            VALUES (
                        @CreditAccount -- [AccountNumber]
                        , @WorkingDate -- [ValueDate]
                        , @TransactionNumber -- [ReferenceId]
                        , GETUTCDATE() -- [TransactionDate]
                        , @StepName -- [TransactionCode]
                        , @Amount -- [Amount]
                        , 'C' -- [Dorc]
                        , @StepName + ':Transfer interest to due [' + @CreditAccount + ']' -- [Description]
                        , @UserCode -- [UsrCode]
                        , 1 -- [Oder]
                        , 'N' -- [DepositHistoryStatus]
                        , '-' -- [Stcode]
                        , 0 --[Usrid]
                        , @ChannelID -- [ChannelId]
                        );
            
            --
            EXEC DPT_DEBIT_ACCOUNT @TransactionNumber = @TransactionNumber,
            @WorkingDate = @WorkingDate,
            @StepName = @StepName,
            @AccountNumber = @DebitAccount,
            @DebitAmount = @Amount,
            @RefId = @RefId;
        
            INSERT INTO DepositHistory (
                        [AccountNumber], [ValueDate], [RefId], [TransactionDate], [TransactionCode], [Amount], [Dorc], [Description], [UsrCode], [Oder], [DepositHistoryStatus], [Stcode], [Usrid], [ChannelId]
                        )
            VALUES (
                        @DebitAccount -- [AccountNumber]
                        , @WorkingDate -- [ValueDate]
                        , @TransactionNumber -- [ReferenceId]
                        , GETUTCDATE() -- [TransactionDate]
                        , @StepName -- [TransactionCode]
                        , @Amount -- [Amount]
                        , 'D' -- [Dorc]
                        , @StepName + ':Transfer interest to due [' + @DebitAccount + ']' -- [Description]
                        , @UserCode -- [UsrCode]
                        , 1 -- [Oder]
                        , 'N' -- [DepositHistoryStatus]
                        , '-' -- [Stcode]
                        , 0 --[Usrid]
                        , @ChannelID -- [ChannelId]
                        );
            
        END;

COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    throw;
END CATCH;
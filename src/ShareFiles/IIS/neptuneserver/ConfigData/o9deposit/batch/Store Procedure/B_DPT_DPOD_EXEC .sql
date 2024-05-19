use o9deposit;
GO

IF OBJECT_ID('[B_DPT_DPOD_EXEC]', 'P') IS NOT NULL
BEGIN
    -- The procedure exists
    DROP PROCEDURE B_DPT_DPOD_EXEC
;
END;
GO

CREATE PROCEDURE dbo.[B_DPT_DPOD_EXEC]
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

DECLARE @ContractNumber VARCHAR(100),
    @ClassificationStatus VARCHAR(10),
    @AccountNumber VARCHAR(100),
    @DiffOverdraftBalance DECIMAL(24,3)= 0,
    @TransId VARCHAR(100);

-- Collect OD contract have diff overdraft balance
DECLARE myCursor CURSOR
FOR
SELECT cont.ContractNumber,
    cont.ClassificationStatus,
    cont.AccountNumber,
    dbo.GetOverDraftBalance(cont.AccountNumber) - cont.OverDraftBalance,
    NewID()
FROM dbo.OverDraftContract cont
WHERE (ContractStatus = 0 or ContractStatus = 2)
    AND dbo.GetOverDraftBalance(cont.AccountNumber) - cont.OverDraftBalance != 0; --Normal

OPEN myCursor;

FETCH NEXT
FROM myCursor
INTO  @ContractNumber,
    @ClassificationStatus,
    @AccountNumber,
    @DiffOverdraftBalance,
    @TransId;

WHILE @@FETCH_STATUS = 0
BEGIN
    if @DiffOverdraftBalance > 0
	begin
        -- Create OverdraftContractTrans
        INSERT INTO [dbo].[OverdraftContractTrans]
            ([TransId], [TransactionNumber], [ODContract], [TransCode], [CurrentClassificationStatus], [TransactionStatus], [Amount], [GLPopulated], [CrossBranchCode], [CrossCurrencyCode], [BaseCurrencyAmount], [GLGroup])
        SELECT
            @TransId as [TransId]
			, @TransactionNumber as  [TransactionNumber]
			, @ContractNumber as [ODContract]
			, 'OD_CREDIT_BALANCE' as [TransCode] -- 'Credit overdraft balance'
			, @ClassificationStatus as  [CurrentClassificationStatus]
			, 'N' as  [TransactionStatus]
			, @DiffOverdraftBalance as [Amount]
			, 0 as  [GLPopulated]
			, null as  [CrossBranchCode]
			, null as  [CrossCurrencyCode]
			, 0 as  [BaseCurrencyAmount]
			, 1 as [GLGroup]
        FROM OverDraftContract contract
        WHERE ContractNumber = @ContractNumber;

        INSERT INTO [dbo].[DepositAccountTrans]
            ([TransId], [TransactionNumber], [DepositAccount], [TransCode], [TransactionStatus], [Amount], [GLPopulated], [CrossBranchCode], [CrossCurrencyCode], [BaseCurrencyAmount], [GLGroup])
        SELECT
            @TransId as [TransId]
			, @TransactionNumber as  [TransactionNumber]
			, @AccountNumber as [DepositAccount]
			, 'OD_MAP_CONTRACT_CREDIT' as [TransCode] -- 'Credit overdraft balance'
			, 'N' as  [TransactionStatus]
			, @DiffOverdraftBalance as [Amount]
			, 0 as  [GLPopulated]
			, null as  [CrossBranchCode]
			, null as  [CrossCurrencyCode]
			, 0 as  [BaseCurrencyAmount]
			, 1 as [GLGroup]
        FROM DepositAccount account
        WHERE AccountNumber = @AccountNumber;
    end
    if @DiffOverdraftBalance < 0
	begin
        -- Create OverdraftContractTrans
        INSERT INTO [dbo].[OverdraftContractTrans]
            ([TransId], [TransactionNumber], [ODContract], [TransCode], [CurrentClassificationStatus], [TransactionStatus], [Amount], [GLPopulated], [CrossBranchCode], [CrossCurrencyCode], [BaseCurrencyAmount], [GLGroup])
        SELECT
            @TransId as [TransId]
			, @TransactionNumber as  [TransactionNumber]
			, @ContractNumber as [ODContract]
			, 'OD_DEBIT_BALANCE' as [TransCode] -- 'Credit overdraft balance'
			, @ClassificationStatus as  [CurrentClassificationStatus]
			, 'N' as  [TransactionStatus]
			, ABS(@DiffOverdraftBalance) as [Amount]
			, 0 as  [GLPopulated]
			, null as  [CrossBranchCode]
			, null as  [CrossCurrencyCode]
			, 0 as  [BaseCurrencyAmount]
			, 1 as [GLGroup]
        FROM OverDraftContract contract
        WHERE ContractNumber = @ContractNumber;

        INSERT INTO [dbo].[DepositAccountTrans]
            ([TransId], [TransactionNumber], [DepositAccount], [TransCode], [TransactionStatus], [Amount], [GLPopulated], [CrossBranchCode], [CrossCurrencyCode], [BaseCurrencyAmount], [GLGroup])
        SELECT
            @TransId as [TransId]
			, @TransactionNumber as  [TransactionNumber]
			, @AccountNumber as [DepositAccount]
			, 'OD_MAP_CONTRACT_DEBIT' as [TransCode] -- 'Credit overdraft balance'
			, 'N' as  [TransactionStatus]
			, ABS(@DiffOverdraftBalance) as [Amount]
			, 0 as  [GLPopulated]
			, null as  [CrossBranchCode]
			, null as  [CrossCurrencyCode]
			, 0 as  [BaseCurrencyAmount]
			, 1 as [GLGroup]
        FROM DepositAccount account
        WHERE AccountNumber = @AccountNumber;

        -- Update OD schedule
        UPDATE OdSchedule
        SET Paid = Paid - @DiffOverdraftBalance
        FROM OdSchedule
        WHERE ContractNumber = @ContractNumber and Rptype = 'P';

    end

    UPDATE OverdraftContract
    SET OverDraftBalance = dbo.GetOverDraftBalance(@AccountNumber)
    FROM OverdraftContract contract
    WHERE ContractNumber = @ContractNumber;

    FETCH NEXT
    FROM myCursor
    INTO  @ContractNumber,
		@ClassificationStatus,
		@AccountNumber,
		@DiffOverdraftBalance,
        @TransId;

END;

CLOSE myCursor;

DEALLOCATE myCursor;

-- Update Interest overdays
UPDATE OverdraftContract 
SET InterestOverDays = case when OverDraftBalance > OdLimit then InterestOverDays + 1 when OverDraftBalance <= OdLimit then 0 end
FROM OverdraftContract contract where ContractStatus != 1;

-- Create GL entries
exec dbo.GenerateGLEntriesFromOverdraftContractTrans
	@TransactionNumber=null;

exec dbo.GenerateGLEntriesFromDepositAccountTrans
	@TransactionNumber=null;

COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    throw;
END CATCH;

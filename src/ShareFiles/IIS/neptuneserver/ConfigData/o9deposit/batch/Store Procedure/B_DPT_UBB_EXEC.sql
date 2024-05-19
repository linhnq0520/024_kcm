use o9deposit;

IF OBJECT_ID('[B_DPT_UBB_EXEC]', 'P') IS NOT NULL
BEGIN
    -- The procedure exists
    DROP PROCEDURE B_DPT_UBB_EXEC
;
END;
GO

CREATE PROCEDURE [dbo].[B_DPT_UBB_EXEC] (
    @TransactionNumber VARCHAR(36),
    @WorkingDate DATE,
    @UserCode NVARCHAR(5),
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

DECLARE @BatchStepName VARCHAR(100) = 'B_DPT_UBB_EXEC';

DECLARE @ListOfAccount TABLE (
    Id INT identity(1, 1),
    AccountNumber NVARCHAR(100),
    IfcCondition NVARCHAR(1000),
    IfcCode INT,
    ValueBasic NVARCHAR(500)
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
        
        INSERT @ListOfAccount(AccountNumber, IfcCode, ValueBasic, IfcCondition)
        SELECT A.AccountNumber, B.IfcCode, C.ValueBasic, C.IfcCondition FROM dbo.DepositAccount A
        INNER JOIN (SELECT AccountNumber, IfcCode, IfcBalanceStatus FROM dbo.IFCBalance) B ON a.AccountNumber = B.AccountNumber 
        INNER JOIN (SELECT IfcCode, ValueBasic, IfcCondition FROM dbo.DepositIFCDefinition) C ON B.IfcCode = C.IfcCode
        WHERE  A.DepositStatus <> 'C' AND ((A.DepositType = 'T' AND @WorkingDate >= A.BeginOfTenor AND @WorkingDate <= A.EndOfTenor) OR A.DepositType <> 'T')
                AND B.IfcBalanceStatus = 'N' AND (C.ValueBasic LIKE '%GetMinBalance%' OR C.ValueBasic LIKE '%GetAverageBalance%');
        
        DECLARE @rows INT = ( SELECT COUNT(*) FROM @ListOfAccount);
        DECLARE @strWorkingDate VARCHAR(20) = Convert(VARCHAR(20), @workingdate, 23);
        
        UPDATE dbo.IfcBalance SET BasicBalance = dbo.GetBasicBalance(balance.AccountNumber , balance.IfcCode ,@WorkingDate)
        FROM dbo.IfcBalance balance
        INNER JOIN @ListOfAccount lst ON balance.AccountNumber = lst.AccountNumber;
    

COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    throw;
END CATCH;
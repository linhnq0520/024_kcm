use [o9accounting];

IF OBJECT_ID('[B_ACT_CLS_EXEC]', 'P') IS NOT NULL
BEGIN
    -- The procedure exists
    DROP PROCEDURE B_ACT_CLS_EXEC;
END;
GO

CREATE PROCEDURE [dbo].[B_ACT_CLS_EXEC] (
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
DECLARE @BatchStepName VARCHAR(100) = 'B_ACT_CLS_EXEC';
Declare @TableName varchar(100) = 'AccountingTransaction';
DECLARE @ProfisAccount NVARCHAR(100); 

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
DECLARE @ListOfAccountPre TABLE (
    Id INT identity(1, 1),
    AccountNumber NVARCHAR(100),
    AccountGroup NVARCHAR(1) ,
    CurrencyCode NVARCHAR(3),
	  BranchCode NVARCHAR(5),
	  Balance DECIMAL(24,5)DEFAULT 0,
	  ProfitAcount NVARCHAR(100)
);
--insert data to Pre
INSERT INTO @ListOfAccountPre
( AccountNumber,
  AccountGroup,
	CurrencyCode,
	BranchCode,
	Balance,
	ProfitAcount
	)
SELECT 
 A.AccountNumber,
 A.AccountGroup,
 A.CurrencyCode,
 A.BranchCode,
 B.Balance,
 dbo.ACCOUNT_COMMON('PROFIT',A.BranchCode,A.CurrencyCode)     
FROM (
  SELECT AccountGroup,AccountNumber,CurrencyCode,BranchCode 
  FROM dbo.AccountChart 
  WHERE AccountGroup  IN ('I','E') 
) as A 
JOIN dbo.AccountBalance as B 
ON A.AccountNumber = B.AccountNumber
WHERE B.Balance <> 0;
--end insert

	INSERT INTO GLEntries
		(
		[TransactionNumber],
		[TransTableName],
		[TransId],
		[SysAccountName],
		[GLAccount],
		[DorC],
		[TransactionStatus],
		[Amount],
		[BranchCode],
		[CurrencyCode],
		[ValueDate],
		[Posted]
		)
--GLDebit
    SELECT 
	 @TransactionNumber as [TransactionNumber],
	 @TableName as [TransTableName], --[TransTableName]
	 NewID() as [TransId],
	 CASE -- [SysAccountName] Notice******
	  WHEN A.Balance < 0 Then 'PROFIT'
	  WHEN A.Balance >0 Then ''
	 END, -- [SysAccountName] Notice******
	 CASE -- [AccountNumber] 
	  WHEN A.Balance < 0 Then A.ProfitAcount
	  WHEN A.Balance >0 Then A.AccountNumber
	 END, -- [AccountNumber] 
	 'D',--[DorC] Notice******
	 'N',--[TransactionStatus],
	  CASE 
	  WHEN A.Balance < 0 Then -A.Balance
	  WHEN A.Balance >0 Then A.Balance
	 END, 
	 A.BranchCode,
	 A.CurrencyCode,
	 @current_working_date,-- [ValueDate]
	 0 -- [Posted]
	FROM @ListOfAccountPre as A  
UNION
--GLCredit
 SELECT 
	 @TransactionNumber as [TransactionNumber],
	 @TableName as [TransTableName], --[TransTableName]
	 NewID() as [TransId],
	 CASE -- [SysAccountName] Notice******
	  WHEN  B.Balance < 0 Then  '' 
	  WHEN  B.Balance > 0 Then  'PROFIT'
	 END, -- [SysAccountName] Notice******
	 CASE -- [AccountNumber] 
	  WHEN  B.Balance < 0 Then  B.AccountNumber 
	  WHEN  B.Balance > 0 Then  B.ProfitAcount
	 END, -- [AccountNumber] 
	 'C',--[DorC] Notice******
	 'N',--[TransactionStatus],
	  CASE 
	  WHEN  B.Balance < 0 Then - B.Balance
	  WHEN  B.Balance >0 Then  B.Balance
	 END, 
	  B.BranchCode,
	  B.CurrencyCode,
	 @current_working_date,-- [ValueDate]
	 0 -- [Posted]
	FROM @ListOfAccountPre as B; 

COMMIT TRANSACTION;

END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    throw;
END CATCH;
GO
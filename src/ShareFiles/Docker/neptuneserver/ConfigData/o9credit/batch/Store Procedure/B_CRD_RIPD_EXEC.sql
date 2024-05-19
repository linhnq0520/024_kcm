
USE o9credit;
GO 
IF OBJECT_ID('[B_CRD_RIPD_EXEC]', 'P') IS NOT NULL 
BEGIN 
    -- The procedure exists
    DROP PROCEDURE B_CRD_RIPD_EXEC;
END;
GO 

CREATE PROCEDURE [dbo].[B_CRD_RIPD_EXEC] (
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
DECLARE @TransCode varchar(100) = 'CRD_RIPD';
BEGIN TRY
DECLARE @current_working_date DATE = @WorkingDate;
DECLARE @StartTime DATE = GETUTCDATE();
DECLARE @BatchStepName VARCHAR(100) = 'B_CRD_RIPD_EXEC';
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

DECLARE @ListOfAccount TABLE (
        id INT identity(1, 1),
        AccountCredit VARCHAR(100),
		AccountDeposit VARCHAR(100),
        CurrentBalance DECIMAL(24, 5) DEFAULT 0 ,
        DueAmount DECIMAL(24, 5) DEFAULT 0 ,
        InterestDue DECIMAL(24, 5) DEFAULT 0 );
-- List of accounts to be repayemnt.

SELECT D.AccountNumber , D.CurrentBalance , MasterAccountNumber
INTO #DepositTemp
		FROM o9deposit.dbo.DepositAccount  D
INNER JOIN (SELECT LinkageAccountNumber, 
                    MasterAccountNumber 
            FROM o9deposit.dbo.AccountLinkage
            WHERE LinkageType = 'C' AND LinkageClass = 'A') L
ON D.AccountNumber = L.LinkageAccountNumber
WHERE  D.DepositStatus <> 'C' AND D.CurrentBalance > 0;

INSERT INTO @ListOfAccount (
AccountCredit,
AccountDeposit,
CurrentBalance,
DueAmount,
InterestDue)
SELECT account.AccountNumber, b.AccountNumber, b.CurrentBalance, account.DueAmount,account.InterestDue
FROM o9credit.dbo.CreditAccount account
INNER JOIN #DepositTemp B ON account.AccountNumber=B.MasterAccountNumber
where ClassificationStatus = 'N' and CreditFacility <> 'OD' and (DueAmount > 0 OR ROUND (InterestDue, 2) > 0 );

DECLARE @rows INT = (
        SELECT COUNT(*)
        FROM @ListOfAccount
    );
IF (@rows = 0) RETURN;
BEGIN TRANSACTION;
DECLARE @row INT = 0;
WHILE (@row < @rows) BEGIN
	SET @row = @row + 1;

	DECLARE @AccountCredit VARCHAR(100), @AccountDeposit VARCHAR(100) , @CurrentBalance DECIMAL(24,5)=0, @DueAmount DECIMAL(24,5)=0, @InterestDue DECIMAL(24,5)=0;
	SELECT @AccountCredit = AccountDeposit, @AccountDeposit = AccountDeposit, @CurrentBalance= CurrentBalance, @DueAmount=DueAmount, @InterestDue=InterestDue
	FROM @ListOfAccount
	WHERE id = @row;

	DECLARE @AmountPenatyInt DECIMAL(24,5) = 0;
	DECLARE @AmountPenatyPrin DECIMAL(24,5) = 0;
	DECLARE @AmountInt DECIMAL(24,5)=0;
    DECLARE @AmountPrin DECIMAL(24,5) = 0;

	SELECT @AmountPenatyInt=a.Amount FROM o9credit.dbo.CreditIFCBalance a inner join o9credit.dbo.CreditIFCDefinition b on a.IfcCode=b.IfcCode
	WHERE b.IfcStatus='N' and b.IfcSubType='PI' and a.AccountNumber=@AccountCredit;
	SELECT @AmountPenatyPrin=a.Amount FROM o9credit.dbo.CreditIFCBalance a inner join o9credit.dbo.CreditIFCDefinition b on a.IfcCode=b.IfcCode
	WHERE b.IfcStatus='N' and b.IfcSubType='PI' and a.AccountNumber=@AccountCredit;


	IF( @CurrentBalance >0)
	BEGIN 
		EXEC  @AmountPenatyInt= o9credit.dbo.CreditAllocateCollect  @AccountNumber = @AccountCredit,
			@CurrentBalance = @CurrentBalance ,
			@PrincipalAmount = 0 ,
			@PenaltyInterest =@AmountPenatyInt , 
			@PenaltyPrinciple=0 ,
			@InterestAmount =0, 
			@RepaymentField ='PenaltyInterest',
			@RepaymentType ='PI', 
			@AdjustAmount  = 0 ,
			@WorkingDate = @WorkingDate ;
		EXEC  @AmountPenatyPrin = o9credit.dbo.CreditAllocateCollect  @AccountNumber = @AccountCredit,
			@CurrentBalance = @CurrentBalance ,
			@PrincipalAmount = 0 ,
			@PenaltyInterest =0 , 
			@PenaltyPrinciple=@AmountPenatyPrin ,
			@InterestAmount =0, 
			@RepaymentField ='PenaltyPrinciple',
			@RepaymentType ='PP', 
			@AdjustAmount  = 0 ,
			@WorkingDate = @WorkingDate ;

		EXEC  @AmountInt= o9credit.dbo.CreditAllocateCollect  @AccountNumber = @AccountCredit,
			@CurrentBalance = @CurrentBalance ,
			@PrincipalAmount = 0 ,
			@PenaltyInterest =0 , 
			@PenaltyPrinciple=0 ,
			@InterestAmount =@InterestDue, 
			@RepaymentField ='Interest',
			@RepaymentType ='I', 
			@AdjustAmount  = 0 ,
			@WorkingDate = @WorkingDate ;

		EXEC  @AmountPrin = o9credit.dbo.CreditAllocateCollect  @AccountNumber = @AccountCredit,
			@CurrentBalance = @CurrentBalance ,
			@PrincipalAmount = @DueAmount ,
			@PenaltyInterest =0 , 
			@PenaltyPrinciple=0 ,
			@InterestAmount =0, 
			@RepaymentField ='Principle',
			@RepaymentType ='P', 
			@AdjustAmount  = 0 ,
			@WorkingDate = @WorkingDate ;
	END;

	-- update IFCBalance
	UPDATE  o9credit.dbo.CreditIFCBalance 
	SET Amount -= CASE b.IfcSubType
		WHEN 'PI' THEN  @AmountPenatyInt
		WHEN 'PP' THEN  @AmountPenatyPrin
		WHEN 'IN' THEN  @InterestDue else 0 end ,
	Paid += CASE b.IfcSubType
		WHEN 'PI' THEN  @AmountPenatyInt
		WHEN 'PP' THEN  @AmountPenatyPrin
		WHEN 'IN' THEN  @InterestDue else 0 end
	FROM o9credit.dbo.CreditIFCBalance a inner join o9credit.dbo.CreditIFCDefinition b on a.IfcCode=b.IfcCode
	WHERE b.IfcStatus='N' and a.AccountNumber=@AccountCredit;
 
	--  Update credit account
	UPDATE o9credit.dbo.CreditAccount
	SET Balance -= @AmountPrin,
		DueAmount -= @AmountPrin,
		PrincipalPaidAmount += @AmountPrin,
		InterestDue -= @AmountInt,
		InterestPaid+=@AmountInt,
		LastTransactionDate = @WorkingDate
	FROM o9credit.dbo.CreditAccount account where account.AccountNumber=@AccountCredit;

	DECLARE @Amt DECIMAL(24, 5) = ROUND (@AmountInt + @AmountPrin + @AmountPenatyPrin+ @AmountPenatyInt,2);
		---- 3 Create CreditHistory
		DELETE FROM o9credit.dbo.CreditHistory
		WHERE TransactionRefId = @TransactionNumber;
		INSERT INTO o9credit.dbo.CreditHistory (
				[AccountNumber],
				[TransactionDate],
				[TransactionRefId],
				[ValueDate],
				[TransactionCode],
				[Amount],
				[Dorc],
				[Description],
				[UserCreated],
				[STATUS],
				[UserApprove]
			)
		SELECT account.AccountNumber,--DefAccountNumber
			@WorkingDate,--TransactionDate
			@TransactionNumber,--TransactionRefId
			@WorkingDate,--ValueDate
			'B_CRD_RIPD_EXEC',--TransactionCode
			@Amt,--Amount
			'C',--Dorc
			@Description,--Description
			0,--@UserCode: UserCreated
			'N',--Status
			0 --@UserCode: UserApprove
		FROM o9credit.dbo.CreditAccount account WHERE AccountNumber=@AccountCredit;

		-- Cap nhap deposit 
		EXEC o9deposit.dbo.DPT_DEBIT_ACCOUNT @TransactionNumber = @TransactionNumber,
		@WorkingDate = @WorkingDate,
		@StepName = @StepName,
		@AccountNumber = @AccountDeposit,
		@DebitAmount = @Amt;

		INSERT INTO o9deposit.dbo.DepositHistory (
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
		VALUES (
				@AccountDeposit -- [AccountNumber]
		,
				@WorkingDate -- [ValueDate]
		,
				@TransactionNumber -- [ReferenceId]
		,
				CONVERT(DATE, GETDATE()) -- [TransactionDate]
		,
				@StepName -- [TransactionCode]
		,
				@Amt -- [Amount]
		,
				'D' -- [Dorc]
		,
				@StepName + ': Interest repayment for [' + @AccountDeposit + ']' -- [Description]
		,
				@UserCode -- [UsrCode]
		,
				1 -- [Oder]
		,
				'N' -- [DepositHistoryStatus]
		,
				'-' -- [Stcode]
		,
				0 --[Usrid]
		,
				@ChannelID -- [ChannelId]
			);

		END;


DROP TABLE #DepositTemp;

COMMIT TRANSACTION;
END TRY BEGIN CATCH ROLLBACK TRANSACTION;
throw;
END CATCH;

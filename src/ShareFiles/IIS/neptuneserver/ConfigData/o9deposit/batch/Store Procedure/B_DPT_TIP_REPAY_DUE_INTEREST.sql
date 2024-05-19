USE o9deposit;
GO

-- Repay due interest of a CASA account
IF OBJECT_ID('[B_DPT_TIP_REPAY_DUE_INTEREST]', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE B_DPT_TIP_REPAY_DUE_INTEREST;
END;
GO

CREATE PROCEDURE [dbo].[B_DPT_TIP_REPAY_DUE_INTEREST] (
    @StepName VARCHAR(100),
    @TransactionNumber VARCHAR(100),
    @WorkingDate DATE,
    @DebitedDepositAccount VARCHAR(100),
    @RepayInterestAmount DECIMAL(24,5)
    )
AS
BEGIN
    DECLARE @count INT,
        @CurrentBalance DECIMAL(24,5);

    SELECT @CurrentBalance = CurrentBalance,
        @count = count(*)
    FROM DepositAccount
    WHERE AccountNumber = @DebitedDepositAccount
        AND DepositStatus <> 'C' -- not closed
    GROUP BY CurrentBalance;

    IF (@count = 0)
        RETURN;
	
	print('B_DPT_TIP_REPAY_DUE_INTEREST: @DebitedDepositAccount=' + @DebitedDepositAccount );
	print('B_DPT_TIP_REPAY_DUE_INTEREST: @RepayInterestAmount=' + cast(@RepayInterestAmount as varchar) );

	print('B_DPT_TIP_REPAY_DUE_INTEREST - @count=' + cast(@count as varchar))
    DECLARE @IFCTable TABLE (
        id INT identity(1, 1),
        IfcCode VARCHAR(100),
        Amount DECIMAL(24,5),
        Paid DECIMAL(24,5)
        );

    INSERT INTO @IFCTable
    SELECT IfcCode,
        Amount,
        Paid
    FROM IFCBalance
    WHERE AccountNumber = @DebitedDepositAccount
    ORDER BY Amount - Paid DESC;

    DECLARE @Rows INT = (
            SELECT count(*)
            FROM @IFCTable
            );
    DECLARE @i INT = 0;
    DECLARE @RemainAmount DECIMAL(24,5) = @RepayInterestAmount;
	print('B_DPT_TIP_REPAY_DUE_INTEREST - @Rows=' + cast(@Rows as varchar))
    WHILE (
            @i < @Rows
            AND @RemainAmount > 0
            )
    BEGIN
        SET @i = @i + 1;

        DECLARE @IfcCode VARCHAR(100),
            @NotPaidAmount DECIMAL(24,5);

        SELECT @IfcCode = IfcCode,
            @NotPaidAmount = ROUND(Amount - Paid,2)
        FROM @IFCTable
        WHERE id = @i;

        DECLARE @paid_amount DECIMAL(24,5) = iif(@NotPaidAmount <= @RemainAmount, @NotPaidAmount, @RemainAmount);

        SET @RemainAmount = @RemainAmount - @paid_amount;

        -- insert to IFCbalanceDetails
        INSERT INTO IFCBalanceDetail (
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
        VALUES (
            'DPT' --[ModuleCode]
            ,
            @DebitedDepositAccount --[AccountNumber]
            ,
            @IfcCode -- [IfcCode]
            ,
            @paid_amount, --[IfcValue]
            @CurrentBalance --[Balance]
            ,
            @WorkingDate --[FromDate]
            ,
            @WorkingDate --[ToDate]
            ,
            'C' -- [Action]
            ,
            @paid_amount -- [Amount]
            ,
            @TransactionNumber -- [ReferenceId]
            ,
            @StepName --[IFCBalanceDetailDescription]
            );
    END;

    -- update ifcbalance
    UPDATE IFCBalance
    SET Paid = Paid + ifcdetails.Amount
    FROM IFCBalance ifcbal
    INNER JOIN (
        SELECT AccountNumber,
            ifccode,
            sum(Amount) AS Amount
        FROM IFCBalanceDetail
        WHERE ReferenceId = @TransactionNumber
            AND AccountNumber = @DebitedDepositAccount
        GROUP BY AccountNumber,
            ifccode
        ) ifcdetails
        ON ifcbal.AccountNumber = ifcdetails.AccountNumber
            AND ifcbal.IfcCode = ifcdetails.ifccode
    WHERE ifcbal.AccountNumber = @DebitedDepositAccount;

    -- Update due interest of the deposit account
    UPDATE DepositAccount
    SET InterestDue = account.InterestDue - detail.Amount
    FROM DepositAccount account
    INNER JOIN (
        SELECT AccountNumber,
            Sum(Amount) as Amount
        FROM IFCBalanceDetail
        WHERE AccountNumber = @DebitedDepositAccount
            AND ReferenceId = @TransactionNumber
        GROUP BY AccountNumber
        ) detail
        ON account.AccountNumber = detail.AccountNumber;

    -- Debit Due Interest of Master account
    INSERT INTO DepositIFCBalanceTrans (
        [TransId],
        [TransactionNumber],
        [DepositAccount],
        [IFCCode],
        [TransCode],
        [TransactionStatus],
        [Amount],
        [GLPopulated],
        [BaseCurrencyAmount]
        )
    SELECT NewID() AS [TransId],
        @TransactionNumber AS [TransactionNumber],
        details.AccountNumber AS [DepositAccount],
        details.IfcCode AS [IFCCode],
        'IFC_IPAY' AS [TransCode] -- Interest Payment code
        ,
        'N' AS [TransactionStatus],
        details.Amount AS [Amount],
        0 AS [GLPopulated],
        details.Amount AS [BaseCurrencyAmount]
    FROM IFCBalanceDetail details
    WHERE details.ReferenceId = @TransactionNumber 
		and details.AccountNumber=@DebitedDepositAccount; 
END;

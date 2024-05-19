USE o9credit;
GO

IF OBJECT_ID('[CreditAllocateCollect]', 'FN') IS NOT NULL
BEGIN
	Drop FUNCTION [CreditAllocateCollect];
END;
GO

CREATE FUNCTION [dbo].[CreditAllocateCollect] (@AccountNumber NVARCHAR(50), @CurrentBalance DECIMAL(24,5), @PrincipalAmount DECIMAL(24,5),@PenaltyInterest DECIMAL(24,5), @PenaltyPrinciple DECIMAL(24,5),
		@InterestAmount DECIMAL(24,5), @RepaymentField NVARCHAR(50), @RepaymentType NVARCHAR(3), @AdjustAmount  DECIMAL(24,5)= 0 , @WorkingDate Date)
    RETURNS DECIMAL(24,5)
BEGIN
	DECLARE @Amount DECIMAL(24,5) = @CurrentBalance;
	DECLARE @AmountTemp DECIMAL(24,5) = 0;
	DECLARE @AmountNew DECIMAL(24,5) = 0;
	DECLARE @AmountInt DECIMAL(24,5) = 0;
	DECLARE @AmountPrin DECIMAL(24,5) = 0;
	DECLARE @AmountPenatyPrin DECIMAL(24,5) = 0;
	DECLARE @AmountPenatyInt DECIMAL(24,5) = 0;
	DECLARE @HierachyMode INT= 1;

	DECLARE @PaymentOrders INT =0;
	SELECT @PaymentOrders=RepaymentOrder
	FROM RepaymentHierarchy;
	DECLARE @PaymentOrder INT = 0;
	WHILE (@PaymentOrder < @PaymentOrders and @Amount > 0)
		BEGIN
		SET @PaymentOrder = @PaymentOrder + 1;

		SELECT @AmountTemp = CASE RepaymentType
				WHEN 'I' THEN  @InterestAmount 
				WHEN 'P' THEN  @PrincipalAmount
				WHEN 'PP' THEN  @PenaltyInterest
				WHEN 'PI' THEN  @PenaltyInterest
				else  0
			END
		FROM RepaymentHierarchy
		WHERE RepaymentOrder = @PaymentOrder;
		SET @Amount -=  Case When @AmountTemp < @Amount  Then @AmountTemp Else @Amount End
	;
	END

	IF(@Amount<=0) RETURN 0;

	DECLARE @ListOfTemp TABLE (
		Id INT identity(1, 1),
		AccountNumber VARCHAR(100),
		DueDate Date,
		Amount DECIMAL(24, 5) DEFAULT 0,
		Paid DECIMAL(24, 5) DEFAULT 0,
		Ovd DECIMAL(24, 5) DEFAULT 0,
		Rptype VARCHAR(1),
		RepaymentField VARCHAR(50),
		RepaymentType VARCHAR(3),
		RepaymentOrder INT DEFAULT 0
	);

	SELECT @HierachyMode = CAST(s.Value as INT)
	FROM o9credit.dbo.Setting s
	WHERE Name='CreditSetting.HierachyMode';
	IF(@RepaymentField='PenaltyInterest' or @RepaymentField='PenaltyPrinciple')   
	BEGIN
		INSERT INTO @ListOfTemp
			( AccountNumber, Amount ,Paid,Ovd ,Rptype,RepaymentField ,RepaymentType,RepaymentOrder)
		SELECT A.AccountNumber, A.Amount, 0 , 0, B.IfcSubType, C.RepaymentField , C.RepaymentType, C.RepaymentOrder
		FROM (  SELECT AccountNumber, Amount, IfcCode
			FROM CreditIFCBalance ) A
			INNER JOIN
			(SELECT IfcCode, IfcSubType, IfcStatus
			FROM CreditIFCDefinition) B
			ON A.IfcCode=B.IfcCode
			INNER JOIN
			(SELECT RepaymentField, RepaymentType, RepaymentOrder
			FROM RepaymentHierarchy) C
			ON B.IfcSubType = C.RepaymentType
		WHERE  AccountNumber = @AccountNumber AND IfcStatus='N'
		ORDER BY RepaymentOrder ASC

		DECLARE @rows INT = ( SELECT COUNT(*)
		FROM @ListOfTemp);

		DECLARE @row INT = 0;
		WHILE (@row < @rows and @Amount>0)
			BEGIN
			SET @row = @row + 1;

			SELECT @AmountTemp = CASE Rptype
					WHEN 'PI' THEN  Amount + @AdjustAmount
					WHEN 'PP' THEN  Amount
				END
			FROM @ListOfTemp
			WHERE Id = @row;

			IF (@RepaymentType='PI') 
					SET @AmountPenatyInt+= Case When @AmountTemp < @Amount  Then @AmountTemp Else @Amount End ;
				else
					SET @AmountPenatyPrin += Case When @AmountTemp < @Amount  Then @AmountTemp Else @Amount End ;
		end
		SET @Amount -=  Case When @AmountTemp < @Amount  Then @AmountTemp Else @Amount End
	;
	END


	IF ( @HierachyMode=1 and ((@RepaymentField='Interest' or @RepaymentField='Principle')))
		BEGIN
		INSERT INTO @ListOfTemp
			( AccountNumber, DueDate, Amount ,Paid,Ovd ,Rptype,RepaymentField ,RepaymentType,RepaymentOrder)
		SELECT A.AccountNumber, A.DueDate, A.Amount, A.Paid , A.Ovd, A.Rptype, B.RepaymentField , B.RepaymentType, B.RepaymentOrder
		FROM (  SELECT AccountNumber, DueDate, DueNumber, Amount , Paid, Ovd, Rptype
			FROM CreditSchedule ) A
			INNER JOIN
			(SELECT RepaymentField, RepaymentType, RepaymentOrder
			FROM RepaymentHierarchy) B
			ON A.Rptype = B.RepaymentType
		WHERE  AccountNumber = @AccountNumber AND DueDate <= @WorkingDate AND Amount - Paid > 0
		ORDER BY DueDate DESC, RepaymentOrder ASC

		SET @rows = ( SELECT COUNT(*)
		FROM @ListOfTemp);

		SET @row = 0;
		WHILE (@row < @rows and @Amount>0)
				BEGIN
			SET @row = @row + 1;

			SELECT @AmountTemp = CASE Rptype
						WHEN 'I' THEN  Amount-Paid + @AdjustAmount
						WHEN 'P' THEN  Amount-Paid
					END
			FROM @ListOfTemp
			WHERE Id = @row;

			IF (@RepaymentType='I') 
						SET @AmountInt += Case When @AmountTemp < @Amount  Then @AmountTemp Else @Amount End ;
					else
						SET @AmountPrin += Case When @AmountTemp < @Amount  Then @AmountTemp Else @Amount End ;
		end
		SET @Amount -=  Case When @AmountTemp < @Amount  Then @AmountTemp Else @Amount End
	;
	END
		ELSE
		BEGIN
		INSERT INTO @ListOfTemp
			( AccountNumber, DueDate, Amount ,Paid,Ovd ,Rptype,RepaymentField ,RepaymentType,RepaymentOrder)
		SELECT A.AccountNumber, A.DueDate, A.Amount, A.Paid , A.Ovd, A.Rptype, B.RepaymentField , B.RepaymentType, B.RepaymentOrder
		FROM (  SELECT AccountNumber, DueDate, DueNumber, Amount , Paid, Ovd, Rptype
			FROM CreditSchedule ) A
			INNER JOIN
			(SELECT RepaymentField, RepaymentType, RepaymentOrder
			FROM RepaymentHierarchy) B
			ON A.Rptype = B.RepaymentType
		WHERE  AccountNumber = @AccountNumber AND DueDate <= @WorkingDate AND Amount - Paid > 0 and Rptype= @RepaymentType
		ORDER BY DueDate ASC, RepaymentOrder ASC;

		SET @rows  = ( SELECT COUNT(*)
		FROM @ListOfTemp);
		SET @row  = 0;
		WHILE (@row < @rows and @Amount>0)
				BEGIN
			SET @row = @row + 1;

			SELECT @AmountTemp = CASE Rptype
						WHEN 'I' THEN  Amount-Paid +@AdjustAmount
						WHEN 'P' THEN  Amount-Paid
					END
			FROM @ListOfTemp
			WHERE Id = @row;

			IF (@RepaymentType='I') 
						SET @AmountInt += Case When @AmountTemp < @Amount  Then @AmountTemp Else @Amount End ;
					else
						SET @AmountPrin += Case When @AmountTemp < @Amount  Then @AmountTemp Else @Amount End ;
		end

		SET @Amount -=  Case When @AmountTemp < @Amount  Then @AmountTemp Else @Amount End
	;
	END

	IF (@RepaymentType='I') SET @AmountNew = @AmountInt;
	ELSE IF (@RepaymentType='P') SET @AmountNew =  @AmountPrin;
	ELSE IF (@RepaymentType='PI') SET @AmountNew =  @AmountPenatyInt;
	ELSE  SET @AmountNew =  @AmountPenatyPrin;
	RETURN @AmountNew;
END;









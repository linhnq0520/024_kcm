use o9credit;
GO

IF OBJECT_ID('[B_CRD_CTD_EXEC]', 'P') IS NOT NULL
BEGIN
    -- The procedure exists
    DROP PROCEDURE [B_CRD_CTD_EXEC];
END;
GO


CREATE PROCEDURE [dbo].[B_CRD_CTD_EXEC] (
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

DECLARE @current_working_date DATE = @WorkingDate;
DECLARE @StartTime DATE = GETUTCDATE();
DECLARE @BatchStepName VARCHAR(100) = 'B_CRD_CTD_EXEC';

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
--1. Transfer interest to due: Installment loan
Update crd 
SET InterestDue = InterestDue + Round(InterestAmount, 2),
    InterestAmount = InterestAmount - Round(InterestAmount, 2)
FROM CreditAccount crd
	inner join CreditSchedule sch on crd.AccountNumber = sch.AccountNumber
WHERE 
    crd.Crdsts in (0, 2) -- Closed, legal
    and crd.InterestComputationMode in ('C', 'B', 'P')
    and sch.Rptype = 'I' and sch.DueDate = @WorkingDate;

--2. Generate new record for due date: Fixed Loan 
Insert Into [CreditSchedule] ([AccountNumber], [DueNumber], [DueDate], [DueStatus], [Amount], [Paid], [Ovd], [Mrkamt], [Mrksts], [Clrdt], [Clramt], [Prvrate], [Prvamt], [Prvclr], [Rptype])
Select
    crd.AccountNumber as [AccountNumber]
    , (select dbo.GetNewDueNumber(crd.AccountNumber, 'I')) as [DueNumber]
    , @WorkingDate as [DueDate]
    , 'N' as [DueStatus]
    , Round(crd.InterestAmount, 2) as [Amount]
    , 0 as [Paid]
    , 0 as [Ovd]
    , 0 as [Mrkamt]
    , null as [Mrksts]
    , null as [Clrdt]
    , 0 as [Clramt]
    , 0 as [Prvrate]
    , 0 as [Prvamt] 
    , 0 as [Prvclr]
    , 'I' as [Rptype]
FROM (SELECT AccountNumber, InterestAmount 
    FROM CreditAccount 
    WHERE Crdsts  in (0, 2)
        AND CreditFacility <> 'OD' 
        AND InterestTenorUnit <> 'E' 
        AND InterestComputationMode IN ('F', 'S')
        AND ROUND(InterestAmount, 2) > 0) crd
    INNER JOIN (SELECT AccountNumber, Amount FROM CreditScheduleEstimate WHERE Rptype = 'E' AND DueDate = @WorkingDate) sch on crd.AccountNumber = sch.AccountNumber;

--2. Transfer interest to due: Fixed loan
Update crd 
SET InterestDue = InterestDue + Round(InterestAmount, 2),
    -- InterestAmount = InterestAmount - Round(InterestAmount, 2)
    InterestAmount = InterestAmount - InterestAmount
FROM CreditAccount crd 
    inner join CreditSchedule sch on crd.AccountNumber = sch.AccountNumber
WHERE 
    crd.Crdsts in (0, 2) -- Closed, legal
    and crd.CreditFacility <> 'OD' and crd.InterestTenorUnit <> 'E'
    and crd.InterestComputationMode in ('F', 'S', 'U', 'O')
    and sch.Rptype = 'I' and sch.DueDate = @WorkingDate;

-- if not disbursement => clear amount 
UPDATE sch
SET Amount = 0
FROM CreditSchedule sch
    Inner Join CreditAccount account On sch.AccountNumber = account.AccountNumber
WHERE sch.Rptype = 'P' 
    and sch.DueDate <= @WorkingDate
    and account.CreditType = 'F' AND account.InterestComputationMode In ('C', 'B', 'P')
    And account.Crdsts in (0, 2) -- Closed, legal 
	And account.Balance + account.PrincipalPaidAmount = 0;

-- transfer principal to due
UPDATE account 
Set DueAmount = DueAmount + Least(sch.Amount - sch.Paid, account.Balance)
FROM CreditAccount account 
    INNER JOIN (SELECT AccountNumber, Amount, Paid, DueDate FROM CreditSchedule WHERE Amount - Paid > 0 AND Rptype = 'P') sch On account.AccountNumber = sch.AccountNumber
WHERE sch.DueDate = @WorkingDate 
and account.Crdsts in (0, 2); -- Closed, legal 

-- Insert into CreditIfcBalanceDetail Adjust value

INSERT INTO CreditIFCBalanceDetail([ModuleCode], [AccountNumber], [IfcCode], [IfcValue], [Balance], [FromDate], [ToDate], [Action], [Amount], [ReferenceId], [IFCBalanceDetailDescription])
SELECT 
	'CRD' as [ModuleCode]
	, crd.AccountNumber as [AccountNumber]
	, bal.IfcCode as [IfcCode]
	, bal.IfcValue + bal.MarginValue
	, Balance as [Balance]
	, @WorkingDate as [FromDate]
	, @WorkingDate as [ToDate]
	, 'A' as [Action] -- Adjust
	, bal.Amount - Round(bal.Amount, 2) as [Amount] 
	, @TransactionNumber as [ReferenceId]
	, @StepName as [IFCBalanceDetailDescription]
From CreditIFCBalance bal 
	inner join CreditIFCDefinition def on def.IfcCode = bal.IfcCode
	inner join CreditAccount crd on bal.AccountNumber = crd.AccountNumber
	inner join CreditSchedule sch on crd.AccountNumber = sch.AccountNumber
WHERE 
	crd.Crdsts in (0, 2) -- Closed, legal
	and def.IfcType = 'I'
	and crd.CreditFacility <> 'OD' and crd.InterestTenorUnit <> 'E'
	and crd.InterestComputationMode in ('F', 'S', 'U', 'O')
	and sch.Rptype = 'I' and sch.DueDate = @WorkingDate;

-- Adjust OS IfcBalance: Fixed loan
Update bal 
SET Amount = Round(bal.Amount, 2)
FROM CreditIFCBalance bal 
	inner join CreditIFCDefinition def on def.IfcCode = bal.IfcCode
	inner join CreditAccount crd on bal.AccountNumber = crd.AccountNumber
    inner join CreditSchedule sch on crd.AccountNumber = sch.AccountNumber
WHERE 
    crd.Crdsts in (0, 2) -- Closed, legal
	and def.IfcType = 'I'
    and crd.CreditFacility <> 'OD' and crd.InterestTenorUnit <> 'E'
    and crd.InterestComputationMode in ('F', 'S', 'U', 'O')
    and sch.Rptype = 'I' and sch.DueDate = @WorkingDate;



COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    throw;
END CATCH;
GO

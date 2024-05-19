USE o9credit;
GO

IF OBJECT_ID('dbo.[B_CRD_PROV_EXEC]', 'P') IS NOT NULL
BEGIN
    -- The table exists
    DROP PROCEDURE dbo.B_CRD_PROV_EXEC;
END;
GO

CREATE PROCEDURE [dbo].[B_CRD_PROV_EXEC] (
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
BEGIN
	TRY

DECLARE @current_working_date DATE = @WorkingDate;
Declare @TransCode_POST_PROVISIONING varchar(100) = 'POST_PROVISIONING';
Declare @TransCode_REVERSE_PROVISIONING varchar(100) = 'REVERSE_PROVISIONING';
DECLARE @StartTime DATE = GETUTCDATE();

BEGIN
	TRANSACTION;

-- Create transaction
	EXEC CREATE_TRANSACTION  
	    @TransactionNumber ,
	    @WorkingDate ,
	    @UserCode ,
	    @UserName ,
	    @BatchDate ,
	    @StepName , 
	    @ReferenceId ,
	    @RefId ,
	    @ReferenceCode ,
	    @TranId ,
	    @Description ,
	    @BusinessCode ,
	    @ChannelID;
	   
-- I. Post provision if be changed
DELETE
FROM
	dbo.ProvisioningTrans
WHERE
	TransactionNumber = @TransactionNumber;

DECLARE @ProvisionTable TABLE (
 [AccountNumber] Nvarchar(100),
 [NewProvisionAmount] decimal(24,5),
 [CurrentProvisionAmount] decimal(24,5),
 [ClassificationStatus] varchar(10)
);

-- Caculate current & new provision amount of active credit accounts
insert
	into
	@ProvisionTable
SELECT
			ac.AccountNumber, 
			ROUND(
			(
				ac.balance /*OS*/
				+ (ac.InterestPayable)/*Due int + Acr Int*/
				+ SUM(ISNULL(ovd_prin_fine.Amount, 0))/*overdue principal fine*/
				+ SUM(ISNULL(ovd_int_fine.Amount, 0))/*overdue interest fine*/
				- ac.[SecuredAmount] -- Secured amount
				-- + SUM(ISNULL(int_schedule.[Amount], 0)) -- overdue unpaid int
				-- + SUM(ISNULL(prin_schedule.[Amount], 0)) -- overdue unpaid prin
			)
			* CASE 
	            WHEN ccl.CodeValue = '01'
	                THEN ac.PrincipalProvisionRate0
	            WHEN ccl.CodeValue = '02'
	                THEN ac.PrincipalProvisionRate1
	            WHEN ccl.CodeValue = '03'
	                THEN ac.PrincipalProvisionRate2
	            WHEN ccl.CodeValue = '04'
	                THEN ac.PrincipalProvisionRate3
	            WHEN ccl.CodeValue = '05'
	                THEN ac.PrincipalProvisionRate4
	            ELSE 0
	            END / 100, 2) AS [NewProvisionAmount],
			ac.ProvisionOfOther as [CurrentProvisionAmount],
			ac.ClassificationStatus AS [ClassificationStatus]
FROM
		CreditAccount ac
inner join CreditCodeList ccl on
		(ccl.CodeName = 'CLSTS'
		and ccl.CodeGroup = 'CRD'
		and ac.ClassificationStatus = ccl.CodeId)
left join (
	select ifcbal.AccountNumber, SUM(ROUND(ifcbal.Amount, 2)) as [Amount]
	from CreditIFCBalance ifcbal 
	inner join CreditIFCDefinition ifcdef on ifcbal.IfcCode = ifcdef.IfcCode
	inner join CreditAccount ac on ifcbal.AccountNumber = ac.AccountNumber 
		and ac.Crdsts in (
			0 /*Normal*/
			, 2 /*Blocked*/
			, 3 /*Suspend*/
		)
	where ifcdef.IfcType = 'F' -- Fine
		and ifcdef.IfcSubType = 'PP' -- Principal Penalty
    group by ifcbal.AccountNumber
) ovd_prin_fine on ac.AccountNumber = ovd_prin_fine.AccountNumber
left join (
	select ifcbal.AccountNumber, SUM(ROUND(ifcbal.Amount, 2)) as [Amount]
	from CreditIFCBalance ifcbal 
	inner join CreditIFCDefinition ifcdef on ifcbal.IfcCode = ifcdef.IfcCode
	inner join CreditAccount ac on ifcbal.AccountNumber = ac.AccountNumber 
		and ac.Crdsts in (
			0 /*Normal*/
			, 2 /*Blocked*/
			, 3 /*Suspend*/
		)
	where ifcdef.IfcType = 'F' -- Fine
		and ifcdef.IfcSubType = 'PI' -- Interest Penalty
	group by ifcbal.AccountNumber
) ovd_int_fine on ac.AccountNumber = ovd_int_fine.AccountNumber
left join (
		select AccountNumber, sum(Amount - Paid) as [Amount] 
		from CreditSchedule 
		where rptype = 'I'
			and dueDate < @WorkingDate
			and Amount - Paid > 0
		group by AccountNumber
		) int_schedule on (ac.AccountNumber = int_schedule.AccountNumber)/*overdue interest*/
left join (
		select AccountNumber, sum(Amount - Paid) as [Amount]  
		from CreditSchedule 
		where rptype = 'P'
			and dueDate < @WorkingDate
			and Amount - Paid > 0
		group by AccountNumber
		) prin_schedule on (ac.AccountNumber = prin_schedule.AccountNumber)/*overdue principal */
WHERE
	ac.DisbursementAmount > 0
	and ac.Crdsts in (
	0 /*Normal*/
	, 2 /*Blocked*/
	, 3 /*Suspend*/
	)
	and ac.IsProvision = 'Y' /*provisioned*/
GROUP BY
		ac.AccountNumber,
		ac.ClassificationStatus, 
		ac.[PrincipalProvisionRate0],
		ac.[PrincipalProvisionRate1],
		ac.[PrincipalProvisionRate2],
		ac.[PrincipalProvisionRate3],
		ac.[PrincipalProvisionRate4],
		ac.[balance],
		ac.[InterestPayable],
		ac.[SecuredAmount],
		ac.ProvisionOfOther,
		ccl.CodeValue;

delete from @ProvisionTable where NewProvisionAmount = CurrentProvisionAmount;
update @ProvisionTable set NewProvisionAmount = 0 where NewProvisionAmount < 0;

-- I.1. Create master trans - Reverse Provision Records
INSERT
	INTO
	dbo.ProvisioningTrans (
    [TransactionNumber],
	[TransId],
	[CreditAccount],
	[TransCode],
	[Amount],
	[CurrentClassificationStatus],
	[TransactionStatus],
	[GLPopulated]
    )
select
	@TransactionNumber as [TransactionNumber],
	NewID() as [TransId],
	s.AccountNumber as [CreditAccount],
	@TransCode_REVERSE_PROVISIONING as [TransCode],
	s.[CurrentProvisionAmount] as [Amount],
	s.[ClassificationStatus] as [CurrentClassificationStatus],
	'N' AS [TransactionStatus],
	0 AS [GLPopulated]
FROM @ProvisionTable s
where
	s.[NewProvisionAmount] <> s.[CurrentProvisionAmount] 
	and s.[CurrentProvisionAmount] > 0;
	
-- I.2. Create master trans - Post Provision Records
INSERT
	INTO
	dbo.ProvisioningTrans (
    [TransactionNumber],
	[TransId],
	[CreditAccount],
	[TransCode],
	[Amount],
	[CurrentClassificationStatus],
	[TransactionStatus],
	[GLPopulated]
    )
select
	@TransactionNumber as [TransactionNumber],
	NewID() as [TransId],
	s.AccountNumber as [CreditAccount],
	@TransCode_POST_PROVISIONING as [TransCode],
	s.[NewProvisionAmount] as [Amount],
	s.[ClassificationStatus] as [CurrentClassificationStatus],
	'N' AS [TransactionStatus],
	0 AS [GLPopulated]
FROM
	@ProvisionTable s
where
	s.[NewProvisionAmount] >= 0
	and s.[NewProvisionAmount] <> s.[CurrentProvisionAmount];
	 
-- II.1: Reverse current Amount
update ca
set ca.ProvisionOfOther = ca.ProvisionOfOther - prov.Amount
From CreditAccount ca
inner join ProvisioningTrans prov on ca.AccountNumber=prov.CreditAccount and prov.TransCode = @TransCode_REVERSE_PROVISIONING
where prov.TransactionNumber=@TransactionNumber;

-- II.2. Update new provision amount to credit account table
update ca
set ca.ProvisionOfOther = prov.Amount
From CreditAccount ca
inner join ProvisioningTrans prov on ca.AccountNumber=prov.CreditAccount and prov.TransCode = @TransCode_POST_PROVISIONING
where prov.TransactionNumber=@TransactionNumber;
 
-- III. Generate GL Entries
exec GenerateGLEntriesFromProvisioningTrans @TransactionNumber = @TransactionNumber;

-- IV. Clean tables
exec B_CRD_MOVE_TO_HIS_TABLES;

COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    throw;
END CATCH;
GO

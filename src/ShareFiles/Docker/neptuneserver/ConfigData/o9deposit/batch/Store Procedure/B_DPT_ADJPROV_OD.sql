use o9deposit;
GO

IF OBJECT_ID('[B_DPT_ADJPROV_OD]', 'P') IS NOT NULL
BEGIN
    -- The procedure exists
    DROP PROCEDURE B_DPT_ADJPROV_OD
;
END;
GO

CREATE PROCEDURE dbo.[B_DPT_ADJPROV_OD]
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

-- Create OverdraftContractTrans
INSERT INTO [dbo].[ProvisioningTrans]
    ([TransId], [TransactionNumber], [TransCode], [ODContract], [CurrentClassificationStatus], [TransactionStatus], [Amount], [GLPopulated], [GLGroup] )
SELECT
    NewID() as [TransId]
	, @TransactionNumber as  [TransactionNumber]
	, 'REVERSE_PROVISIONING' as [TransCode] -- 'Credit overdraft balance'
	, contract.ContractNumber as [ODContract]
	, contract.ClassificationStatus as  [CurrentClassificationStatus]
	, 'N' as  [TransactionStatus]
	, contract.ProvisionAmount as [Amount]
	, 0 as  [GLPopulated]
	, 1 as [GLGroup]

FROM OverDraftContract contract
where (contract.ContractStatus = 0 or contract.ContractStatus = 2); -- normal;


INSERT INTO [dbo].[ProvisioningTrans]
    ([TransId], [TransactionNumber], [TransCode], [ODContract], [CurrentClassificationStatus], [TransactionStatus], [Amount], [GLPopulated], [GLGroup])
SELECT
    NewID() as [TransId]
	, @TransactionNumber as  [TransactionNumber]
	, 'POST_PROVISIONING' as [TransCode] -- 'Credit overdraft balance'
	, contract.ContractNumber as [ODContract]
	, contract.ClassificationStatus as  [CurrentClassificationStatus]
	, 'N' as  [TransactionStatus]
	, Case 
		when Round((dbo.GetOverDraftBalance(contract.AccountNumber) + (case when Amount is null then 0 else Amount end) - contract.SecureAmount)* 
		 case
			when contract.ClassificationStatus = 'N' then contract.PrincipalProvisionRate0
			when contract.ClassificationStatus = 'P' then contract.PrincipalProvisionRate1
			when contract.ClassificationStatus = 'O' then contract.PrincipalProvisionRate2
			when contract.ClassificationStatus = 'D' then contract.PrincipalProvisionRate3
			when contract.ClassificationStatus = 'L' then contract.PrincipalProvisionRate4
			else 0
			end
			/100, 2) > 0 then Round((dbo.GetOverDraftBalance(contract.AccountNumber) + (case when Amount is null then 0 else Amount end) - contract.SecureAmount)* case
			when contract.ClassificationStatus = 'N' then contract.PrincipalProvisionRate0
			when contract.ClassificationStatus = 'P' then contract.PrincipalProvisionRate1
			when contract.ClassificationStatus = 'O' then contract.PrincipalProvisionRate2
			when contract.ClassificationStatus = 'D' then contract.PrincipalProvisionRate3
			when contract.ClassificationStatus = 'L' then contract.PrincipalProvisionRate4
			else 0
			end
			/100, 2)
		else 0 end as [Amount]
	, 0 as  [GLPopulated]
	, 1 as [GLGroup]
FROM OverDraftContract contract
    left join (select sum(Round(Amount, 2)) Amount, count(ContractNumber) Count, ContractNumber
    from ODContractIFCBalance
    group by ContractNumber) ifcbal on contract.ContractNumber  = ifcbal.ContractNumber
where (contract.ContractStatus = 0 or contract.ContractStatus = 2); -- normal
 
-- Delete where old provision amount = new provision amount
delete from [dbo].[ProvisioningTrans] where ODContract in (
select a.ODContract
    from (
        (select *
        from dbo.ProvisioningTrans
        where TransactionNumber = @TransactionNumber and TransCode = 'REVERSE_PROVISIONING') a
        inner join (select *
        from dbo.ProvisioningTrans
        where TransactionNumber = @TransactionNumber and TransCode = 'POST_PROVISIONING') b on a.ODContract = b.ODContract and a.Amount = b.Amount)) and TransactionNumber = @TransactionNumber;

-- Create GL entries
exec dbo.GenerateGLEntriesFromProvisioningTrans
	@TransactionNumber=null;

-- Update new provisioning amount to OD contract
UPDATE OverdraftContract
SET ProvisionAmount = trans.Amount
FROM OverdraftContract contract
    inner join [ProvisioningTrans] trans on contract.ContractNumber = trans.ODContract
where [TransactionNumber] = @TransactionNumber
    and [TransCode] = 'POST_PROVISIONING';

COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    throw;
END CATCH;

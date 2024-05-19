use o9deposit;
GO

IF OBJECT_ID('[B_DPT_ODANI_EXEC]', 'P') IS NOT NULL
BEGIN
    -- The procedure exists
    DROP PROCEDURE B_DPT_ODANI_EXEC
;
END;
GO

CREATE PROCEDURE dbo.[B_DPT_ODANI_EXEC]
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

DECLARE @current_working_date DATE = @WorkingDate;
DECLARE @StartTime DATE = GETUTCDATE();
DECLARE @BatchStepName VARCHAR(100) = 'B_DPT_ODANI_EXEC';

DECLARE @InterestCalculation_BatchStepName VARCHAR(100) = 'B_DPT_ODANI_EXEC';

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
       
-- Create ODContractIFCBalance Trans
INSERT INTO [dbo].[ODContractIFCBalanceTrans]
    ([TransId], [TransactionNumber], [ODContract], [IFCCode], [TransCode], [ClassificationStatus], [TransactionStatus], [Amount], [GLPopulated], [CrossBranchCode], [CrossCurrencyCode], [BaseCurrencyAmount], [GLGroup])
SELECT
    NewID() as [TransId]
	, @TransactionNumber as  [TransactionNumber]
	, contract.ContractNumber as [ODContract]
	, ifcbal.[IFCCode] as [IFCCode]
	, (case when ifcDef.IfcType ='I' then 'OD_IFC_IACR'
             when ifcDef.IfcType ='F' and ifcDef.IfcSubType = 'FC' then 'OD_IFC_FACR'
			 when ifcDef.IfcType ='F' and ifcDef.IfcSubType = 'PP' then 'DEBIT_PENALTY_PRIN_NO_UPDATE'
			 when ifcDef.IfcType ='F' and ifcDef.IfcSubType = 'PI' then 'DEBIT_PENALTY_INT_NO_UPDATE'
             end) as [TransCode] -- 'OD_IFC_IACR' or 'OD_IFC_FACR'
	, contract.ClassificationStatus as  [CurrentClassificationStatus]
	, 'N' as  [TransactionStatus]
	, round(Amount - Amtpbl, 2) as [Amount] -- Today receivable interest amount
	, 0 as  [GLPopulated]
	, null as  [CrossBranchCode]
	, null as  [CrossCurrencyCode]
	, 0 as  [BaseCurrencyAmount]
	, 1 as [GLGroup]
FROM ODContractIFCBalance ifcbal
    inner join OverDraftContract contract on ifcbal.ContractNumber=contract.ContractNumber and (contract.ContractStatus = 0 or contract.ContractStatus = 2)-- == Normal 
    inner join DepositIFCDefinition ifcDef on ifcbal.IfcCode = ifcDef.IfcCode
WHERE ifcbal.IfcBalanceStatus = 'N'
    and (contract.ContractStatus = 0 or contract.ContractStatus = 2) -- == Normal 
    and ROUND(Amount, 2) - Amtpbl > 0; -- Have accrual interest

-- Create GL entries
exec dbo.GenerateGLEntriesFromODContractIFCBalanceTrans
	@TransactionNumber=null;

-- update IFCBalance.Amtpbl (Interest receiable), IFC level
UPDATE ODContractIFCBalance
set Amtpbl = balance.Amtpbl + trans.Amount
from ODContractIFCBalance balance
    inner join [ODContractIFCBalanceTrans] trans on balance.ContractNumber = trans.ODContract and balance.IfcCode = trans.IfcCode
    inner join [DepositIFCDefinition] def on trans.IfcCode = def.IfcCode and (def.IfcType = 'I' or def.IfcType = 'F')-- Get all IFC main interest and IFC commitment fee
    inner join [OverDraftContract] contract on trans.ODContract = contract.ContractNumber and (contract.ContractStatus = 0 or contract.ContractStatus = 2) -- = Normal
where trans.TransactionNumber = @TransactionNumber;


COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    throw;
END CATCH;

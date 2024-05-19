USE o9credit;
GO

IF OBJECT_ID('dbo.[B_CRD_MOVE_TO_HIS_TABLES]', 'P') IS NOT NULL
BEGIN
    -- The table exists
    DROP PROCEDURE dbo.B_CRD_MOVE_TO_HIS_TABLES;
END;
GO

CREATE PROCEDURE [dbo].B_CRD_MOVE_TO_HIS_TABLES
AS
BEGIN
-- Credit account
insert into CreditAccountTransHis ([TransId], [TransactionNumber], [CreditAccount], [TransCode], [CurrentClassificationStatus], [TransactionStatus], [Amount], [GLPopulated], [CrossBranchCode], [CrossCurrencyCode], [BaseCurrencyAmount])
select [TransId], [TransactionNumber], [CreditAccount], [TransCode], [CurrentClassificationStatus], [TransactionStatus], [Amount], [GLPopulated], [CrossBranchCode], [CrossCurrencyCode], [BaseCurrencyAmount]
from CreditAccountTrans where GLPopulated = 1;

DELETE FROM CreditAccountTrans
WHERE TransactionNumber IN (SELECT TransactionNumber FROM CreditAccountTransHis WHERE GLPopulated = 1);

-- Classification
INSERT INTO ClassificationTransHis ([TransId], [TransactionNumber], [TransCode], [TransactionStatus], [Amount], [GLPopulated], [CreditAccount], [FromStatus], [ToStatus])
SELECT [TransId], [TransactionNumber], [TransCode], [TransactionStatus], [Amount], [GLPopulated], [CreditAccount], [FromStatus], [ToStatus] 
FROM ClassificationTrans WHERE GLPopulated = 1;

DELETE FROM ClassificationTrans
WHERE TransactionNumber IN (SELECT TransactionNumber FROM ClassificationTransHis WHERE GLPopulated = 1);

-- Provisioning
INSERT INTO ProvisioningTransHis ([TransId], [TransactionNumber], [CreditAccount], [TransCode], [Amount], [CurrentClassificationStatus], [TransactionStatus], [GLPopulated])
SELECT [TransId], [TransactionNumber], [CreditAccount], [TransCode], [Amount], [CurrentClassificationStatus], [TransactionStatus], [GLPopulated] FROM ProvisioningTrans WHERE GLPopulated = 1;

DELETE FROM ProvisioningTrans
WHERE TransactionNumber IN (SELECT TransactionNumber FROM ProvisioningTransHis WHERE GLPopulated = 1);

END;
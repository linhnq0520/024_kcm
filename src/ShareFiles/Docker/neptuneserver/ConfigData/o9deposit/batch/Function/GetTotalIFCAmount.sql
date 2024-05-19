USE o9deposit;
GO

IF OBJECT_ID('[GetTotalIFCAmount]', 'FN') IS NOT NULL
BEGIN
    Drop FUNCTION [GetTotalIFCAmount];
END;
GO

CREATE FUNCTION dbo.GetTotalIFCAmount (@ContractNumber NVARCHAR(200))        
    RETURNS DECIMAL(24,5)
BEGIN
    DECLARE @TotalAmount DECIMAL(24,5);

    Select @TotalAmount = SUM(Amount)
    FROM dbo.ODContractIFCBalance a
        INNER JOIN dbo.OverDraftContract b on a.ContractNumber = b.ContractNumber
    where a.ContractNumber = @ContractNumber
        AND (b.ContractStatus = 0 or b.ContractStatus = 2);

    RETURN @TotalAmount;
END
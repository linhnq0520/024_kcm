USE o9accounting;
GO

IF OBJECT_ID('ACCOUNT_COMMON', 'FN') IS NOT NULL
BEGIN
    Drop FUNCTION ACCOUNT_COMMON;
END;
GO

CREATE FUNCTION [dbo].[ACCOUNT_COMMON]( @pAccountName NVARCHAR(500),
                                    @pBranchCode  NVARCHAR(5) ,
                                    @pCurrencyCode   NVARCHAR(5) 
                               )
RETURNS  NVARCHAR(100)
AS
  BEGIN
    DECLARE @vAcNoCommon NVARCHAR(100);
    DECLARE @vBranchCode VARCHAR(4);
    DECLARE @vShortID NVARCHAR(100);

    SET @vBranchCode = RIGHT('000' + CONVERT(VARCHAR(3), @pBranchCode), 3);
    SET @vAcNoCommon = (SELECT AccountNumber FROM dbo.AccountCommon WHERE AccountName=@pAccountName);

    IF CHARINDEX('---', @vAcNoCommon) > 0 --Branch code
    BEGIN
        IF @pBranchCode IS NOT NULL
        BEGIN
            SET @vAcNoCommon = REPLACE(@vAcNoCommon, '---', @vBranchCode);
        END;
    END;

    IF CHARINDEX('**', @vAcNoCommon) > 0 --Currency
    BEGIN
        IF @pCurrencyCode IS NOT NULL
        BEGIN
           SET  @vShortID = (SELECT ShortCurrencyId  FROM  [o9admin].[dbo].[Currency]  WHERE CurrencyId = @pCurrencyCode);
           SET  @vAcNoCommon = REPLACE(@vAcNoCommon, '**', @vShortID);
        END;
    END;

    SET @vAcNoCommon = REPLACE(@vAcNoCommon, '?', CASE WHEN CAST(RIGHT(@vAcNoCommon, 2) AS INT) < 9 
	    THEN CAST(RIGHT(@vAcNoCommon, 2) AS INT) ELSE 9 END);
 
    RETURN @vAcNoCommon;
END;
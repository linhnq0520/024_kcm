use o9deposit;
GO
-- Repay due interest of a CASA account
IF OBJECT_ID('[DPT_CREATE_STATEMENT]', 'P') IS NOT NULL
BEGIN
    drop procedure DPT_CREATE_STATEMENT;
END;
GO 
CREATE PROCEDURE DPT_CREATE_STATEMENT
(
    @TransactionNumber VARCHAR(36),
    @WorkingDate DATE,
    @AccountNumber NVARCHAR(100),
    @Amount decimal(24,5),
    @CurrencyCode VARCHAR(100),
    @StatementCode VARCHAR(100),
    @StatementStatus VARCHAR(100),
    @TransactionCode VARCHAR(100),
    @Description  NVARCHAR(1000),
    @Refnum varchar(100) = NULL,
    @RefId NVARCHAR(200) = ''
)
AS
begin
    if (@StatementStatus = 'N')
        begin
            -- update statement
            insert into DepositStatement
            (
            [AccountNumber]
            , [StatementDate]
            , [ReferenceId]
            , [ValueDate]
            , [Amount]
            , [CurrencyCode]
            , [ConvertAmount]
            , [StatementCode]
            , [StatementStatus]
            , [RefNumber]
            , [TransCode]
            , [TransactionNumber]
            , [Description]
            , [CreatedOnUtc]
            , [UpdatedOnUtc]
            )
            values(
                @AccountNumber 
                , GETUTCDATE()
                , @RefId  
                , @WorkingDate  
                , @Amount  
                , @CurrencyCode 
                , @Amount 
                , @StatementCode -- 'DEP'/'WDR' 
                , @StatementStatus -- [StatementStatus]
                , @Refnum --[RefNumber]
                , @TransactionCode -- [TransactionCode]
                , @TransactionNumber
                , @Description -- [Description]
                , GETUTCDATE()
                , GETUTCDATE()
            )
        end;
        else
        begin
            update DepositStatement
            set [StatementStatus] = 'R'
            where [RefNumber]=@Refnum;
        end;

END;
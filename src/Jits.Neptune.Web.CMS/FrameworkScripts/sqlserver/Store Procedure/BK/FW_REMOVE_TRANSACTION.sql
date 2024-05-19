IF OBJECT_ID('[FW_REMOVE_TRANSACTION]', 'P') IS NOT NULL
BEGIN
    -- The procedure exists
    DROP PROCEDURE FW_REMOVE_TRANSACTION
;
END;
GO

CREATE PROCEDURE [dbo].[FW_REMOVE_TRANSACTION]
    @WorkflowScheme nvarchar(max), 
    @IsReverse nvarchar(1), -- R: Reverse |N: Normal
    @OutputWorkflowScheme nvarchar(max) OUTPUT
AS
BEGIN
    BEGIN TRY
	BEGIN TRANSACTION;

    	-- Lấy giá trị các field cần thiết
    DECLARE @RefId VARCHAR(50) = JSON_VALUE(
        @WorkflowScheme,
        '$.request.request_header.tx_context.base_transaction_model.ref_id'
    );
    DECLARE @TransactionNumber VARCHAR(50) = JSON_VALUE(
        @WorkflowScheme,
        '$.request.request_header.tx_context.base_transaction_model.transaction_number'
    );

    DELETE from dbo.TransactionDetails where Id IN (
    SELECT Id from dbo.TransactionDetails WITH (NOLOCK) where RefId = @RefId and [Status] = 'R') 

    DELETE from dbo.GLEntries where Id IN (
    SELECT Id from dbo.GLEntries WITH (NOLOCK) where TransactionNumber = @TransactionNumber and [TransactionStatus]='R') 

    DECLARE @StatementClass NVARCHAR(100)
    DECLARE @MasterTransClass NVARCHAR(100)
    DECLARE @StatementTableName NVARCHAR(100)
    DECLARE @TransTableName NVARCHAR(100)
    DECLARE @StrQuery NVARCHAR(MAX)

    -- Initialize the string variable
    SET @StrQuery = ''

    -- Cursor to loop through dbo.MasterMapping
    DECLARE cur CURSOR FOR
    SELECT StatementClass, MasterTransClass
    FROM dbo.MasterMapping

    OPEN cur
    FETCH NEXT FROM cur INTO @StatementClass, @MasterTransClass

    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Extract table name from StatementClass and MasterTransClass
        -- Check if StatementClass is not empty
        IF @StatementClass IS NOT NULL AND @StatementClass <> ''
        BEGIN
            -- Extract table name from StatementClass
            SET @StatementTableName = RIGHT(@StatementClass, CHARINDEX('.', REVERSE(@StatementClass)) - 1)
        END
        ELSE
        BEGIN
            -- Handle the scenario where StatementClass is empty or doesn't contain the delimiter
            SET @StatementTableName = NULL; -- or any appropriate action based on your requirements
        END
        
        -- Check if MasterTransClass is not empty
        IF @MasterTransClass IS NOT NULL AND @MasterTransClass <> ''
        BEGIN
            SET @TransTableName = RIGHT(@MasterTransClass, CHARINDEX('.', REVERSE(@MasterTransClass)) - 1)
        END
        ELSE
        BEGIN
            -- Handle the scenario where MasterTransClass is empty or doesn't contain the delimiter
            SET @TransTableName = NULL; -- or any appropriate action based on your requirements
        END

        -- Construct the DELETE statement for StatementClass
            IF (@StatementTableName IS NOT NULL AND @StatementTableName <> '')
            SET @StrQuery += 'DELETE FROM dbo.[' + @StatementTableName + ']
                            WHERE Id IN (
                                SELECT Id FROM dbo.[' + @StatementTableName + '] WITH (NOLOCK)
                                WHERE TransactionNumber = ''' + @TransactionNumber + '''
                                AND [StatementStatus] = ''R''
                            ); '

        -- Construct the DELETE statement for MasterTransClass
            IF (@TransTableName IS NOT NULL AND @TransTableName <> '')
            SET @StrQuery += 'DELETE FROM dbo.[' + @TransTableName + ']
                            WHERE Id IN (
                                SELECT Id FROM dbo.[' + @TransTableName + '] WITH (NOLOCK)
                                WHERE TransactionNumber = ''' + @TransactionNumber + '''
                                AND [TransactionStatus] = ''R''
                            ); '

        FETCH NEXT FROM cur INTO @StatementClass, @MasterTransClass
    END

    CLOSE cur
    DEALLOCATE cur

    -- Execute the generated SQL statement
    EXECUTE(@StrQuery);   
    
     SET @OutputWorkflowScheme = @WorkflowScheme;

    COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
		-- Roll back transaction 
		ROLLBACK TRANSACTION;
        -- Ghi thông tin vào log
        DECLARE @Error NVARCHAR(MAX) = ERROR_MESSAGE();
        DECLARE @FullError NVARCHAR(MAX) = 'ErrorMessage: ' + ISNULL(ERROR_MESSAGE(), '') + ' - ErrorStore: '+ ISNULL(ERROR_PROCEDURE(), '') +' - ErrorLine: ' + CAST(ISNULL(ERROR_LINE(), -1) AS varchar(10));
       

        DECLARE @TransactionCode VARCHAR(50)=JSON_VALUE(
        @WorkflowScheme,
        '$.request.request_header.tx_context.base_transaction_model.transaction_code'
    );

        INSERT
            INTO
            dbo.Log
                (
                ShortMessage,
                LogLevelId,
                FullMessage,
                PageUrl,
                ReferredUrl,
                CreatedOnUtc
            )
            VALUES(
                ISNULL(
                    @Error,
                    ''
                ),
                20,
                ISNULL(
                    @FullError,
                    ''
                ),
                ISNULL(
                    @TransactionCode,
                    ''
                ),
                ISNULL(
                    @RefId,
                    ''
                ),
                GETUTCDATE()
            );
    
        throw;
    END CATCH;
END
IF OBJECT_ID('[FW_LIST_GLENTRIES_BY_TRANSACTION_NUMBER]', 'P') IS NOT NULL
BEGIN
    -- The procedure exists
    DROP PROCEDURE FW_LIST_GLENTRIES_BY_TRANSACTION_NUMBER
;
END;
GO

CREATE PROCEDURE [dbo].[FW_LIST_GLENTRIES_BY_TRANSACTION_NUMBER]
    @WorkflowScheme nvarchar(max), 
    @IsReverse nvarchar(1), -- R: Reverse |N: Normal
    @OutputWorkflowScheme nvarchar(max) OUTPUT
AS
BEGIN
    BEGIN TRY
	BEGIN TRANSACTION;

    -- Logic here
    SET @OutputWorkflowScheme = @WorkflowScheme;
     DECLARE @TransactionNumber VARCHAR(50) = JSON_VALUE(
        @WorkflowScheme,
        '$.request.request_header.tx_context.base_transaction_model.transaction_number'
    );
     DECLARE @listGL NVARCHAR(MAX) = (SELECT *
                                                    FROM
                                                        dbo.GLEntries  WITH (NOLOCK)
                                                    WHERE
                                                        TransactionNumber = @TransactionNumber and Posted =0
                                                    ORDER BY GLAccount
                                                    FOR JSON PATH)


  -- Check if @listGL is not null or empty
        IF ISNULL(@listGL, '') != ''
        BEGIN
            SET @OutputWorkflowScheme = JSON_MODIFY(@OutputWorkflowScheme, '$.response.data', JSON_QUERY(@listGL));
        END
        ELSE
        BEGIN
            -- If @listGL is null or empty, add an empty array to $.response.data
            SET @OutputWorkflowScheme = JSON_MODIFY(@OutputWorkflowScheme, '$.response.data', JSON_QUERY('[]'));
        END

    COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
		-- Roll back transaction 
		ROLLBACK TRANSACTION;
        -- Ghi thông tin vào log
        DECLARE @Error NVARCHAR(MAX) = ERROR_MESSAGE();
        DECLARE @FullError NVARCHAR(MAX) = 'ErrorMessage: ' + ISNULL(ERROR_MESSAGE(), '') + ' - ErrorStore: '+ ISNULL(ERROR_PROCEDURE(), '') +' - ErrorLine: ' + CAST(ISNULL(ERROR_LINE(), -1) AS varchar(10));
		 
       
        DECLARE @RefId VARCHAR(50) = JSON_VALUE(
        @WorkflowScheme,
        '$.request.request_header.tx_context.base_transaction_model.ref_id');

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
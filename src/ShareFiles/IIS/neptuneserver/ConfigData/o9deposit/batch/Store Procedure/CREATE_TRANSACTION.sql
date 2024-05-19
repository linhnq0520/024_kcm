use o9deposit;
GO

IF OBJECT_ID('[CREATE_TRANSACTION]', 'P') IS NOT NULL
BEGIN
	-- The procedure exists
	DROP PROCEDURE CREATE_TRANSACTION;
END;
GO

CREATE PROCEDURE [dbo].[CREATE_TRANSACTION]
	(
	@TransactionNumber VARCHAR(36),
	@WorkingDate DATE,
	@UserCode NVARCHAR(5),
	@UserName NVARCHAR(250),
	@BatchDate DATETIME,
	@StepName NVARCHAR(200),
	@ReferenceId NVARCHAR(200) = NULL,
	@RefId NVARCHAR(200) = NULL,
	@ReferenceCode NVARCHAR(200) = NULL,
	@TranId NVARCHAR(200) = NULL,
	@Description NVARCHAR(200) = NULL,
	@BusinessCode NVARCHAR(200) = NULL,
	@ChannelID NVARCHAR(200) = 'C'
)
AS
BEGIN
	DECLARE @StartTime DATE = GETUTCDATE();

	-- Create transaction
	INSERT INTO [Transaction]
		(
		[TransactionCode],
		[SubCode],
		[TransactionDate],
		[ValueDate],
		[ReferenceId],
		[RefId],
		[TransactionNumber],
		[Status],
		[IsReverse],
		[Amount1],
		[RequestBody],
		[ResponseBody],
		[Description],
		[StartTime],
		[Duration],
		[ReferenceCode],
		[BusinessCode]
		)
	VALUES
		(
			@StepName, --[TransactionCode]
			@StepName, --[SubCode]
			SYSDATETIME(), --[TransactionDate]
			@WorkingDate,
			@ReferenceId, --[ReferenceId]
			@RefId, --[RefId]
			@TransactionNumber, --[TransactionNumber]
			'C', --[Status]
			0, -- [IsReverse]
			0, --[Amount1]
			NULL, --[RequestBody]
			NULL, --[[ResponseBody]]
			@StepName, ---[Description]
			DATEDIFF_BIG(ms, DATEFROMPARTS(1970, 1, 1), @StartTime), --[StartTime]
			0, --[Duration]
			@ReferenceId, --[ReferenceCode]
			@BusinessCode -- [BusinessCode],
		);
End;
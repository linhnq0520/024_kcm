use neptune;

IF OBJECT_ID('[PURGE_WORKFLOWS]', 'P') IS NOT NULL
BEGIN
    -- The procedure exists
    DROP PROCEDURE [PURGE_WORKFLOWS];
END;
GO

CREATE PROCEDURE [dbo].[PURGE_WORKFLOWS] (
    @DeletePointOfTime bigint = 0, @MaximumRows bigint = 1000, @OutputNumberOfDeletedWorkflows bigint output
    )
AS
BEGIN
	Declare @DeletePoint bigint = @DeletePointOfTime;
	set @OutputNumberOfDeletedWorkflows = (select count(*) from dbo.WF_EXEC_DONE where CREATED_ON <= @DeletePoint);
	if (@MaximumRows < @OutputNumberOfDeletedWorkflows)
		set @OutputNumberOfDeletedWorkflows = @MaximumRows;

	-- workflow data
	Delete from dbo.WF_STEP_EXEC_DONE where EXECUTION_ID in (select top (@MaximumRows) EXECUTION_ID from dbo.WF_EXEC_DONE where CREATED_ON <= @DeletePoint);
	Delete from dbo.WF_GROUP_EXEC_DONE where EXECUTION_ID in (select top (@MaximumRows) EXECUTION_ID from dbo.WF_EXEC_DONE where CREATED_ON <= @DeletePoint);
	Delete from dbo.WF_EXEC_DONE where EXECUTION_ID in (select top (@MaximumRows) EXECUTION_ID from dbo.WF_EXEC_DONE where CREATED_ON <= @DeletePoint);
	-- LOG data
	Delete from dbo.LOG_API where UTC_TIME <= @DeletePoint;
	Delete from dbo.LOG_EVENT where UTC_TIME <= @DeletePoint;
	Delete from dbo.LOG_GRPC where SERVER_TIME <= @DeletePoint;
	Delete from dbo.LOG_HTTP_REQUEST where TIME_IN <= @DeletePoint;
	Delete from dbo.LOG_INCOMING_QUEUE_MESSAGE where COMING_TIME <= @DeletePoint;
	Delete from dbo.LOG_RECEIVING_HTTP where TIME_START <= @DeletePoint;
END;
GO
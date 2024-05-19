USE [neptune]
GO

IF OBJECT_ID('[__EFMigrationsHistory]','TABLE') IS NULL
BEGIN
	CREATE TABLE [dbo].[__EFMigrationsHistory](
		[MigrationId] [nvarchar](150) NOT NULL,
		[ProductVersion] [nvarchar](32) NOT NULL,
	 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
	(
		[MigrationId] ASC
	))
END;

IF OBJECT_ID('[AUTH_ORGANIZATION]','TABLE') IS NULL
BEGIN
	CREATE TABLE [dbo].[AUTH_ORGANIZATION](
		[OrganizationID] [nvarchar](100) NOT NULL,
		[OrganizationCode] [nvarchar](100) NOT NULL,
		[OrganizationName] [nvarchar](500) NOT NULL,
		[Phone] [nvarchar](50) NULL,
		[Status] [nvarchar](10) NOT NULL,
		[Email] [nvarchar](1000) NULL,
		[Website] [nvarchar](1000) NULL,
		[welcome_logo] [text] NULL,
		[login_background] [text] NULL,
	 CONSTRAINT [PK_AUTH_ORGANIZATION] PRIMARY KEY CLUSTERED 
	(
		[OrganizationID] ASC
	))
END;

IF OBJECT_ID('[AUTH_ROLE]','TABLE') IS NULL
BEGIN
	CREATE TABLE [dbo].[AUTH_ROLE](
		[RoleID] [nvarchar](100) NOT NULL,
		[RoleCode] [nvarchar](100) NOT NULL,
		[RoleName] [nvarchar](500) NOT NULL,
	 CONSTRAINT [PK_AUTH_ROLE] PRIMARY KEY CLUSTERED 
	(
		[RoleID] ASC
	))
END;

IF OBJECT_ID('[AUTH_ROLE_USER]','TABLE') IS NULL
BEGIN
	CREATE TABLE [dbo].[AUTH_ROLE_USER](
		[RoleID] [nvarchar](100) NOT NULL,
		[UserID] [nvarchar](100) NOT NULL,
	 CONSTRAINT [PK_AUTH_ROLE_USER] PRIMARY KEY CLUSTERED 
	(
		[RoleID] ASC,
		[UserID] ASC
	))
END;

IF OBJECT_ID('[AUTH_ROLE_WF]','TABLE') IS NULL
BEGIN
	CREATE TABLE [dbo].[AUTH_ROLE_WF](
		[RoleID] [nvarchar](100) NOT NULL,
		[WorflowID] [nvarchar](100) NOT NULL,
	 CONSTRAINT [PK_AUTH_ROLE_WF] PRIMARY KEY CLUSTERED 
	(
		[RoleID] ASC,
		[WorflowID] ASC
	))
END;

IF OBJECT_ID('[AUTH_USER]','TABLE') IS NULL
BEGIN
	CREATE TABLE [dbo].[AUTH_USER](
		[UserID] [nvarchar](100) NOT NULL,
		[UserCode] [nvarchar](100) NOT NULL,
		[OrganizationID] [nvarchar](100) NOT NULL,
		[UserName] [nvarchar](500) NULL,
		[FullName] [nvarchar](500) NULL,
		[Status] [nvarchar](10) NOT NULL,
		[LanguageCode] [nvarchar](2) NOT NULL,
		[SessionExpirationInMinutes] [int] NOT NULL,
		[HashPassword] [nvarchar](500) NULL,
		[PastHashPassword1] [nvarchar](500) NULL,
		[PastHashPassword2] [nvarchar](500) NULL,
		[PastHashPassword3] [nvarchar](500) NULL,
		[PastHashPassword4] [nvarchar](500) NULL,
		[PastHashPassword5] [nvarchar](500) NULL,
		[PastHashPassword6] [nvarchar](500) NULL,
		[PastHashPassword7] [nvarchar](500) NULL,
		[PastHashPassword8] [nvarchar](500) NULL,
		[PastHashPassword9] [nvarchar](500) NULL,
		[PastHashPassword10] [nvarchar](500) NULL,
		[FailureCount] [int] NOT NULL,
		[PasswordCreatedDate] [bigint] NOT NULL,
		[TimeZone] [decimal](18, 2) NULL,
		[ChannelID] [varchar](100) NULL,
		[ConcurrentMaximumRequests] [int] NOT NULL,
	 CONSTRAINT [PK_AUTH_USER] PRIMARY KEY CLUSTERED 
	(
		[UserID] ASC
	))
END;

IF OBJECT_ID('[CONFIGURATION]','TABLE') IS NULL
BEGIN
	CREATE TABLE [dbo].[CONFIGURATION](
		[PARA_CODE] [nvarchar](500) NOT NULL,
		[PARA_VALUE] [nvarchar](4000) NULL,
	 CONSTRAINT [PK_CONFIGURATION] PRIMARY KEY CLUSTERED 
	(
		[PARA_CODE] ASC
	))
END;

IF OBJECT_ID('[ENVIRONMENT_VARIABLE]','TABLE') IS NULL
BEGIN
	CREATE TABLE [dbo].[ENVIRONMENT_VARIABLE](
		[VARIABLE_NAME] [nvarchar](500) NOT NULL,
		[E1] [text] NULL,
		[E2] [text] NULL,
		[E3] [text] NULL,
		[E4] [text] NULL,
		[E5] [text] NULL,
		[E6] [text] NULL,
		[E7] [text] NULL,
		[E8] [text] NULL,
		[E9] [text] NULL,
	 CONSTRAINT [PK_ENVIRONMENT_VARIABLE] PRIMARY KEY CLUSTERED 
	(
		[VARIABLE_NAME] ASC
	))
END;

IF OBJECT_ID('[EVENT_DEF]','TABLE') IS NULL
BEGIN
	CREATE TABLE [dbo].[EVENT_DEF](
		[EVENT_NAME] [nvarchar](500) NOT NULL,
		[STATUS] [nvarchar](50) NOT NULL,
		[TYPE] [nvarchar](50) NOT NULL,
		[DESCRIPTION] [nvarchar](500) NULL,
	 CONSTRAINT [PK_EVENT_DEF] PRIMARY KEY CLUSTERED 
	(
		[EVENT_NAME] ASC
	))
END;

IF OBJECT_ID('[INSTANCE]','TABLE') IS NULL
BEGIN
	CREATE TABLE [dbo].[INSTANCE](
		[INSTANCE_ID] [nvarchar](50) NOT NULL,
		[GRPC_URL] [nvarchar](500) NOT NULL,
		[UTC_TIME] [bigint] NOT NULL,
		[UTC_EXP_TIME] [bigint] NOT NULL,
		[SERVICE_ID] [nvarchar](100) NULL,
		[EVENT_QUEUE_NAME] [nvarchar](500) NULL,
		[COMMAND_QUEUE_NAME] [nvarchar](500) NULL,
	 CONSTRAINT [PK_INSTANCE] PRIMARY KEY CLUSTERED 
	(
		[INSTANCE_ID] ASC
	))
END;

IF OBJECT_ID('[JWT]','TABLE') IS NULL
BEGIN
	CREATE TABLE [dbo].[JWT](
		[ID] [nvarchar](1000) NOT NULL,
		[token] [nvarchar](1000) NOT NULL,
		[valid_from] [bigint] NOT NULL,
		[valid_to] [bigint] NOT NULL,
		[user_id] [nvarchar](1000) NOT NULL,
		[user_code] [nvarchar](1000) NOT NULL,
		[user_name] [nvarchar](1000) NOT NULL,
		[organization_id] [nvarchar](1000) NOT NULL,
		[organization_code] [nvarchar](1000) NOT NULL,
		[organization_name] [nvarchar](1000) NOT NULL,
	 CONSTRAINT [PK_JWT] PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	))
END;

IF OBJECT_ID('[JWT_STATIC]','TABLE') IS NULL
BEGIN
	CREATE TABLE [dbo].[JWT_STATIC](
		[ID] [nvarchar](1000) NOT NULL,
		[token] [nvarchar](1000) NOT NULL,
		[valid_from] [bigint] NOT NULL,
		[valid_to] [bigint] NOT NULL,
		[user_id] [nvarchar](1000) NOT NULL,
		[user_code] [nvarchar](1000) NOT NULL,
		[user_name] [nvarchar](1000) NOT NULL,
		[organization_id] [nvarchar](1000) NOT NULL,
		[organization_code] [nvarchar](1000) NOT NULL,
		[organization_name] [nvarchar](1000) NOT NULL,
	 CONSTRAINT [PK_JWT_STATIC] PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	))
END;

IF OBJECT_ID('[LANGUAGE_RESOURCE]','TABLE') IS NULL
BEGIN
	CREATE TABLE [dbo].[LANGUAGE_RESOURCE](
		[RESOURCE_CODE] [nvarchar](500) NOT NULL,
		[ID] [nvarchar](100) NOT NULL,
		[EN] [text] NOT NULL,
		[VI] [text] NULL,
		[LA] [text] NULL,
		[KR] [text] NULL,
		[MM] [text] NULL,
		[TH] [text] NULL,
	 CONSTRAINT [PK_LANGUAGE_RESOURCE] PRIMARY KEY CLUSTERED 
	(
		[RESOURCE_CODE] ASC
	))
END;

IF OBJECT_ID('[LOG_API]','TABLE') IS NULL
BEGIN
	CREATE TABLE [dbo].[LOG_API](
		[AUDIT_ID] [nvarchar](100) NOT NULL,
		[UTC_TIME] [bigint] NOT NULL,
		[REQUEST_SCHEME] [nvarchar](100) NULL,
		[REQUEST_SERVER_IP] [nvarchar](100) NULL,
		[REQUEST_PATH] [nvarchar](4000) NULL,
		[REQUEST_HOST] [nvarchar](4000) NULL,
		[REQUEST_BODY] [text] NULL,
		[LOGIN_USER_ID] [nvarchar](100) NULL,
		[LOGIN_ORGANIZATION_ID] [nvarchar](100) NULL,
		[RESPONSE_EXECUTION_ID] [nvarchar](100) NULL,
		[RESPONSE_DESCRIPTION] [nvarchar](4000) NULL,
		[RESPONSE_STATUS] [nvarchar](100) NULL,
		[RESPONSE_DATA] [text] NULL,
		[TRACK_CHANGE] [text] NULL,
	 CONSTRAINT [PK_LOG_API] PRIMARY KEY CLUSTERED 
	(
		[AUDIT_ID] ASC
	))
END;

IF OBJECT_ID('[LOG_EVENT]','TABLE') IS NULL
BEGIN
	CREATE TABLE [dbo].[LOG_EVENT](
		[EVENT_ID] [nvarchar](50) NOT NULL,
		[INSTANCE_ID] [nvarchar](500) NOT NULL,
		[RUNNING_ID] [nvarchar](500) NOT NULL,
		[EVENT_TYPE] [nvarchar](100) NOT NULL,
		[UTC_TIME] [bigint] NOT NULL,
		[DESCS] [text] NOT NULL,
		[EVENT_DATA] [text] NULL,
	 CONSTRAINT [PK_LOG_EVENT] PRIMARY KEY CLUSTERED 
	(
		[EVENT_ID] ASC
	))
END;

IF OBJECT_ID('[LOG_GRPC]','TABLE') IS NULL
BEGIN
	CREATE TABLE [dbo].[LOG_GRPC](
		[ID] [nvarchar](50) NOT NULL,
		[INSTANCE_ID] [nvarchar](500) NOT NULL,
		[RUNNING_ID] [nvarchar](500) NOT NULL,
		[SERVER_TIME] [bigint] NOT NULL,
		[FROM_SERVICE_ID] [nvarchar](100) NULL,
		[TO_SERVICE_ID] [nvarchar](100) NULL,
		[METHOD_SPEC] [nvarchar](4000) NULL,
		[METHOD_RESULT] [text] NULL,
	 CONSTRAINT [PK_LOG_GRPC] PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	))
END;

IF OBJECT_ID('[LOG_HTTP_REQUEST]','TABLE') IS NULL
BEGIN
	CREATE TABLE [dbo].[LOG_HTTP_REQUEST](
		[REQUEST_ID] [nvarchar](100) NOT NULL,
		[TIME_IN] [bigint] NOT NULL,
		[TIME_OUT] [bigint] NOT NULL,
		[DATA] [text] NULL,
	 CONSTRAINT [PK_LOG_HTTP_REQUEST] PRIMARY KEY CLUSTERED 
	(
		[REQUEST_ID] ASC
	))
END;

IF OBJECT_ID('[LOG_INCOMING_QUEUE_MESSAGE]','TABLE') IS NULL
BEGIN
	CREATE TABLE [dbo].[LOG_INCOMING_QUEUE_MESSAGE](
		[MESSAGE_ID] [nvarchar](100) NOT NULL,
		[COMING_TIME] [bigint] NOT NULL,
		[COMING_STATUS] [nvarchar](50) NOT NULL,
		[COMING_CONTENT] [text] NULL,
		[PROCESSING_ERROR] [text] NULL,
		[REQUEST_EXEC_STEP_ID] [nvarchar](100) NULL,
		[RESPONSE_STATUS] [nvarchar](100) NULL,
		[RESPONSE_OUTPUT] [text] NULL,
	 CONSTRAINT [PK_LOG_INCOMING_QUEUE_MESSAGE] PRIMARY KEY CLUSTERED 
	(
		[MESSAGE_ID] ASC
	))
END;

IF OBJECT_ID('[LOG_RECEIVING_HTTP]','TABLE') IS NULL
BEGIN
	CREATE TABLE [dbo].[LOG_RECEIVING_HTTP](
		[HTTP_ID] [nvarchar](100) NOT NULL,
		[TIME_START] [bigint] NOT NULL,
		[TIME_FINISH] [bigint] NOT NULL,
		[RECEIVING_DATA] [text] NULL,
		[SENDING_DATA] [text] NULL,
		[ERROR_DATA] [text] NULL,
	 CONSTRAINT [PK_LOG_RECEIVING_HTTP] PRIMARY KEY CLUSTERED 
	(
		[HTTP_ID] ASC
	))
END;

IF OBJECT_ID('[MAPPING_DICTIONARY]','TABLE') IS NULL
BEGIN
	CREATE TABLE [dbo].[MAPPING_DICTIONARY](
		[MAPPING_KEY] [nvarchar](200) NOT NULL,
		[MAPPING_VALUE] [nvarchar](500) NULL,
	 CONSTRAINT [PK_MAPPING_DICTIONARY] PRIMARY KEY CLUSTERED 
	(
		[MAPPING_KEY] ASC
	))
END;

IF OBJECT_ID('[SENDING_HTTP]','TABLE') IS NULL
BEGIN
	CREATE TABLE [dbo].[SENDING_HTTP](
		[HTTP_ID] [nvarchar](100) NOT NULL,
		[TIME_START] [bigint] NOT NULL,
		[TIME_FINISH] [bigint] NOT NULL,
		[SENDING_DATA] [text] NULL,
		[RECEIVING_DATA] [text] NULL,
		[ERROR_DATA] [text] NULL,
	 CONSTRAINT [PK_SENDING_HTTP] PRIMARY KEY CLUSTERED 
	(
		[HTTP_ID] ASC
	))
END;

IF OBJECT_ID('[SERVICE_DEF]','TABLE') IS NULL
BEGIN
	CREATE TABLE [dbo].[SERVICE_DEF](
		[SERVICE_ID] [nvarchar](100) NOT NULL,
		[SERVICE_CODE] [nvarchar](100) NOT NULL,
		[SERVICE_NAME] [nvarchar](4000) NOT NULL,
		[STATUS] [nvarchar](50) NOT NULL,
		[QUEUE_NAME] [nvarchar](100) NOT NULL,
		[ACCEPT_TIME] [bigint] NOT NULL,
		[GRPC_STATUS] [nvarchar](50) NOT NULL,
		[GRPC_TIMEOUT] [bigint] NOT NULL,
		[GRPC_URL] [nvarchar](500) NULL,
		[EVENT_REGISTRATION] [nvarchar](50) NOT NULL,
		[IMPORT_EXPORT_STEP_CODE] [nvarchar](50) NOT NULL,
		[CONCURRENT_THREADS] [bigint] NOT NULL,
		[SERVICE_INSTANCE_TYPE] [nvarchar](50) NOT NULL,
	 CONSTRAINT [PK_SERVICE_DEF] PRIMARY KEY CLUSTERED 
	(
		[SERVICE_ID] ASC
	))
END;

IF OBJECT_ID('[WF_DEF]','TABLE') IS NULL
BEGIN
	CREATE TABLE [dbo].[WF_DEF](
		[WFID] [nvarchar](100) NOT NULL,
		[Code] [nvarchar](100) NULL,
		[Name] [nvarchar](500) NULL,
		[Status] [nvarchar](100) NOT NULL,
		[AllowReversal] [nvarchar](100) NOT NULL,
		[Description] [nvarchar](500) NULL,
		[TimeoutInMiliseconds] [bigint] NOT NULL,
		[KeepExecSeconds] [bigint] NOT NULL,
		[OpenAPITags] [nvarchar](500) NULL,
		[OpenAPIResponse] [nvarchar](max) NULL,
		[OpenAPIResponseSpec] [nvarchar](max) NULL,
		[EventWorkflowRegistered] [nvarchar](50) NOT NULL,
		[EventWorkflowCompleted] [nvarchar](50) NOT NULL,
		[EventWorkflowError] [nvarchar](50) NOT NULL,
		[EventWorkflowTimeout] [nvarchar](50) NOT NULL,
		[EventWorkflowCompensated] [nvarchar](50) NOT NULL,
		[EventWorkflowReversed] [nvarchar](50) NOT NULL,
		[EventWorkflowStepStart] [nvarchar](50) NOT NULL,
		[EventWorkflowStepCompleted] [nvarchar](50) NOT NULL,
		[EventWorkflowStepError] [nvarchar](50) NOT NULL,
		[EventWorkflowStepTimeout] [nvarchar](50) NOT NULL,
		[EventWorkflowStepCompensated] [nvarchar](50) NOT NULL,
	 CONSTRAINT [PK_WF_DEF] PRIMARY KEY CLUSTERED 
	(
		[WFID] ASC
	))
END;

IF OBJECT_ID('[WF_EXEC]','TABLE') IS NULL
BEGIN
	CREATE TABLE [dbo].[WF_EXEC](
		[EXECUTION_ID] [nvarchar](100) NOT NULL,
		[USER_ID] [nvarchar](100) NOT NULL,
		[ORGANIZATION_ID] [nvarchar](100) NOT NULL,
		[INPUT] [text] NOT NULL,
		[WFID] [nvarchar](100) NOT NULL,
		[LANG] [nvarchar](2) NOT NULL,
		[CREATED_ON] [bigint] NOT NULL,
		[STATUS] [nvarchar](100) NOT NULL,
		[FINISH_ON] [bigint] NOT NULL,
		[IS_SUCCESS] [nvarchar](100) NOT NULL,
		[IS_TIMEOUT] [nvarchar](100) NOT NULL,
		[IS_PROCESSING] [nvarchar](100) NOT NULL,
		[STOP_ERROR] [text] NULL,
		[WORKFLOW_TYPE] [nvarchar](100) NOT NULL,
		[REVERSED_EXECUTION_ID] [nvarchar](100) NOT NULL,
		[REVERSED_BY_EXECUTION_ID] [nvarchar](100) NOT NULL,
		[IS_DISPUTED] [nvarchar](450) NOT NULL,
		[ARCHIVING_TIME] [bigint] NOT NULL,
		[PURGING_TIME] [bigint] NOT NULL,
		[TX_CONTEXT] [text] NOT NULL,
		[APPROVED_EXECUTION_ID] [nvarchar](100) NULL,
		[SERVICE_INSTANCES] [nvarchar](2000) NULL,
		[CHANNEL_ID] [nvarchar](100) NULL,
		[REFERENCE_ID] [nvarchar](100) NULL,
		[REFERENCE_CODE] [nvarchar](100) NULL,
		[TRANS_ID] [nvarchar](100) NULL,
		[BUSINESS_CODE] [nvarchar](100) NULL,
		[DESCRIPTION] [nvarchar](500) NULL,
	 CONSTRAINT [PK_WF_EXEC] PRIMARY KEY CLUSTERED 
	(
		[EXECUTION_ID] ASC
	))
END;

IF OBJECT_ID('[WF_EXEC_DONE]','TABLE') IS NULL
BEGIN
	CREATE TABLE [dbo].[WF_EXEC_DONE](
		[EXECUTION_ID] [nvarchar](100) NOT NULL,
		[USER_ID] [nvarchar](100) NOT NULL,
		[ORGANIZATION_ID] [nvarchar](100) NOT NULL,
		[INPUT] [text] NOT NULL,
		[WFID] [nvarchar](100) NOT NULL,
		[LANG] [nvarchar](2) NOT NULL,
		[CREATED_ON] [bigint] NOT NULL,
		[STATUS] [nvarchar](100) NOT NULL,
		[FINISH_ON] [bigint] NOT NULL,
		[IS_SUCCESS] [nvarchar](100) NOT NULL,
		[IS_TIMEOUT] [nvarchar](100) NOT NULL,
		[IS_PROCESSING] [nvarchar](100) NOT NULL,
		[STOP_ERROR] [text] NULL,
		[WORKFLOW_TYPE] [nvarchar](100) NOT NULL,
		[REVERSED_EXECUTION_ID] [nvarchar](100) NOT NULL,
		[REVERSED_BY_EXECUTION_ID] [nvarchar](100) NOT NULL,
		[IS_DISPUTED] [nvarchar](450) NOT NULL,
		[ARCHIVING_TIME] [bigint] NOT NULL,
		[PURGING_TIME] [bigint] NOT NULL,
		[TX_CONTEXT] [text] NOT NULL,
		[APPROVED_EXECUTION_ID] [nvarchar](100) NULL,
		[SERVICE_INSTANCES] [nvarchar](2000) NULL,
		[CHANNEL_ID] [nvarchar](100) NULL,
		[REFERENCE_ID] [nvarchar](100) NULL,
		[REFERENCE_CODE] [nvarchar](100) NULL,
		[TRANS_ID] [nvarchar](100) NULL,
		[BUSINESS_CODE] [nvarchar](100) NULL,
		[DESCRIPTION] [nvarchar](500) NULL,
	 CONSTRAINT [PK_WF_EXEC_DONE] PRIMARY KEY CLUSTERED 
	(
		[EXECUTION_ID] ASC
	))
END;

IF OBJECT_ID('[WF_FIELD]','TABLE') IS NULL
BEGIN
	CREATE TABLE [dbo].[WF_FIELD](
		[WORKFLOW_ID] [nvarchar](100) NOT NULL,
		[FIELD_CODE] [nvarchar](100) NOT NULL,
		[FIELD_KEY] [nvarchar](100) NOT NULL,
		[DATA_TYPE] [nvarchar](100) NOT NULL,
		[IS_NULL] [nvarchar](100) NOT NULL,
		[IS_REQUIRED] [nvarchar](100) NOT NULL,
		[NUM_MIN] [decimal](18, 2) NOT NULL,
		[NUM_MAX] [decimal](18, 2) NOT NULL,
		[NUM_RANGE] [text] NULL,
		[TEXT_MIN] [text] NULL,
		[TEXT_MAX] [text] NULL,
		[TEXT_RANGE] [text] NULL,
		[TEXT_MAXLENGTH] [int] NOT NULL,
		[DATE_MIN] [decimal](18, 2) NOT NULL,
		[DATE_MAX] [decimal](18, 2) NOT NULL,
		[DATE_RANGE] [text] NULL,
		[BASE64_ICON] [text] NULL,
		[OPENAPI_EXAMPLE] [nvarchar](max) NULL,
		[OPENAPI_DESCRIPTION] [nvarchar](max) NULL,
	 CONSTRAINT [PK_WF_FIELD] PRIMARY KEY CLUSTERED 
	(
		[WORKFLOW_ID] ASC,
		[FIELD_CODE] ASC
	))
END;

IF OBJECT_ID('[WF_GROUP_EXEC]','TABLE') IS NULL
BEGIN
	CREATE TABLE [dbo].[WF_GROUP_EXEC](
		[EXECUTION_ID] [nvarchar](100) NOT NULL,
		[STEP_GROUP] [int] NOT NULL,
		[P1_STATUS] [nvarchar](100) NOT NULL,
		[P2_STATUS] [nvarchar](100) NOT NULL,
		[P1_START] [bigint] NOT NULL,
		[P1_FINISH] [bigint] NOT NULL,
		[P1_ERROR] [text] NULL,
	 CONSTRAINT [PK_WF_GROUP_EXEC] PRIMARY KEY CLUSTERED 
	(
		[EXECUTION_ID] ASC,
		[STEP_GROUP] ASC
	))
END;

IF OBJECT_ID('[WF_GROUP_EXEC_DONE]','TABLE') IS NULL
BEGIN
	CREATE TABLE [dbo].[WF_GROUP_EXEC_DONE](
		[EXECUTION_ID] [nvarchar](100) NOT NULL,
		[STEP_GROUP] [int] NOT NULL,
		[P1_STATUS] [nvarchar](100) NOT NULL,
		[P2_STATUS] [nvarchar](100) NOT NULL,
		[P1_START] [bigint] NOT NULL,
		[P1_FINISH] [bigint] NOT NULL,
		[P1_ERROR] [text] NULL,
	 CONSTRAINT [PK_WF_GROUP_EXEC_DONE] PRIMARY KEY CLUSTERED 
	(
		[EXECUTION_ID] ASC,
		[STEP_GROUP] ASC
	))
END;

IF OBJECT_ID('[WF_STEP_DEF]','TABLE') IS NULL
BEGIN
	CREATE TABLE [dbo].[WF_STEP_DEF](
		[WFID] [nvarchar](100) NOT NULL,
		[STEP_ORDER] [int] NOT NULL,
		[STEP_GROUP] [int] NOT NULL,
		[STEP_CODE] [nvarchar](100) NULL,
		[STATUS] [nvarchar](100) NOT NULL,
		[DESCRIPTION] [nvarchar](4000) NULL,
		[SERVICE_ID] [nvarchar](100) NULL,
		[SENDING_TEMPLATE] [text] NULL,
		[SUCCESS_CONDITION] [text] NULL,
		[REQUEST_PROTOCOL] [nvarchar](1000) NULL,
		[REQUEST_SERVER_IP] [nvarchar](100) NULL,
		[REQUEST_SERVER_PORT] [nvarchar](100) NULL,
		[REQUEST_URI] [nvarchar](100) NULL,
		[SEND_BY_BROKER] [nvarchar](100) NOT NULL,
		[STEP_TIMEOUT] [nvarchar](100) NULL,
		[STEP_MODE] [nvarchar](20) NOT NULL,
		[BASE64_ICON] [text] NULL,
		[SENDING_CONDITION] [text] NULL,
		[ON_COMPENSATING] [nvarchar](100) NOT NULL,
		[PROCESSING_NUMBER] [varchar](100) NULL,
	 CONSTRAINT [PK_WF_STEP_DEF] PRIMARY KEY CLUSTERED 
	(
		[WFID] ASC,
		[STEP_ORDER] ASC
	))
END;

IF OBJECT_ID('[WF_STEP_EXEC]','TABLE') IS NULL
BEGIN
	CREATE TABLE [dbo].[WF_STEP_EXEC](
		[STEP_EXECUTION_ID] [nvarchar](100) NOT NULL,
		[EXECUTION_ID] [nvarchar](100) NOT NULL,
		[WORKFLOW_ID] [nvarchar](100) NULL,
		[STEP_GROUP] [int] NOT NULL,
		[STEP_ORDER] [int] NOT NULL,
		[STEP_CODE] [nvarchar](100) NULL,
		[P1_REQUEST_ID] [nvarchar](100) NULL,
		[P1_START] [bigint] NOT NULL,
		[P1_FINISH] [bigint] NOT NULL,
		[P1_STATUS] [nvarchar](100) NOT NULL,
		[P1_ERROR] [text] NOT NULL,
		[P1_CONTENT] [text] NOT NULL,
		[P2_REQUEST_ID] [nvarchar](100) NULL,
		[P2_START] [bigint] NOT NULL,
		[P2_FINISH] [bigint] NOT NULL,
		[P2_STATUS] [nvarchar](100) NOT NULL,
		[P2_RESPONSE_STATUS] [nvarchar](100) NULL,
		[P2_ERROR] [text] NULL,
		[P2_CONTENT] [text] NULL,
		[IS_SUCCESS] [nvarchar](100) NOT NULL,
		[IS_TIMEOUT] [nvarchar](100) NOT NULL,
		[P3_START] [bigint] NOT NULL,
		[P3_FINISH] [bigint] NOT NULL,
		[P3_STATUS] [nvarchar](100) NOT NULL,
		[P3_CONTENT] [text] NULL,
		[P3_ERROR] [text] NULL,
		[SENDING_CONDITION] [text] NULL,
		[P4_STATUS] [nvarchar](max) NOT NULL,
		[IS_DISPUTED] [nvarchar](450) NOT NULL,
		[P4_CONTENT] [text] NULL,
		[P2_ERROR_CODE] [varchar](400) NULL,
	 CONSTRAINT [PK_WF_STEP_EXEC] PRIMARY KEY CLUSTERED 
	(
		[STEP_EXECUTION_ID] ASC
	))
END;

IF OBJECT_ID('[WF_STEP_EXEC_DONE]','TABLE') IS NULL
BEGIN
	CREATE TABLE [dbo].[WF_STEP_EXEC_DONE](
		[STEP_EXECUTION_ID] [nvarchar](100) NOT NULL,
		[EXECUTION_ID] [nvarchar](100) NOT NULL,
		[WORKFLOW_ID] [nvarchar](100) NULL,
		[STEP_GROUP] [int] NOT NULL,
		[STEP_ORDER] [int] NOT NULL,
		[STEP_CODE] [nvarchar](100) NULL,
		[P1_REQUEST_ID] [nvarchar](100) NULL,
		[P1_START] [bigint] NOT NULL,
		[P1_FINISH] [bigint] NOT NULL,
		[P1_STATUS] [nvarchar](100) NOT NULL,
		[P1_ERROR] [text] NOT NULL,
		[P1_CONTENT] [text] NOT NULL,
		[P2_REQUEST_ID] [nvarchar](100) NULL,
		[P2_START] [bigint] NOT NULL,
		[P2_FINISH] [bigint] NOT NULL,
		[P2_STATUS] [nvarchar](100) NOT NULL,
		[P2_RESPONSE_STATUS] [nvarchar](100) NULL,
		[P2_ERROR] [text] NULL,
		[P2_CONTENT] [text] NULL,
		[IS_SUCCESS] [nvarchar](100) NOT NULL,
		[IS_TIMEOUT] [nvarchar](100) NOT NULL,
		[P3_START] [bigint] NOT NULL,
		[P3_FINISH] [bigint] NOT NULL,
		[P3_STATUS] [nvarchar](100) NOT NULL,
		[P3_CONTENT] [text] NULL,
		[P3_ERROR] [text] NULL,
		[SENDING_CONDITION] [text] NULL,
		[P4_STATUS] [nvarchar](max) NOT NULL,
		[IS_DISPUTED] [nvarchar](450) NOT NULL,
		[P4_CONTENT] [text] NULL,
		[P2_ERROR_CODE] [varchar](400) NULL,
	 CONSTRAINT [PK_WF_STEP_EXEC_DONE] PRIMARY KEY CLUSTERED 
	(
		[STEP_EXECUTION_ID] ASC
	))
END

GO
ALTER TABLE [dbo].[AUTH_USER] ADD  DEFAULT ((50)) FOR [ConcurrentMaximumRequests]
GO
ALTER TABLE [dbo].[WF_STEP_DEF] ADD  DEFAULT ('Version1') FOR [PROCESSING_NUMBER]
GO

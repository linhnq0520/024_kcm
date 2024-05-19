DECLARE
V_COUNT INTEGER;
BEGIN
SELECT COUNT(TABLE_NAME) INTO V_COUNT from USER_TABLES where TABLE_NAME = '__EFMigrationsHistory';
IF V_COUNT = 0 THEN
Begin
BEGIN 
EXECUTE IMMEDIATE 'CREATE TABLE 
"__EFMigrationsHistory" (
    "MigrationId" NVARCHAR2(150) NOT NULL,
    "ProductVersion" NVARCHAR2(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
)';
END;

End;

END IF;
EXCEPTION
WHEN OTHERS THEN
    IF(SQLCODE != -942)THEN
        RAISE;
    END IF;
END;
/

DECLARE
    USEREXIST INTEGER;
    USER_NOT_EXIST EXCEPTION;
    PRAGMA EXCEPTION_INIT( USER_NOT_EXIST, -01435 );
BEGIN
SELECT COUNT(*) INTO USEREXIST FROM ALL_USERS WHERE USERNAME='NeptuneDB';
IF (USEREXIST = 0) THEN
    RAISE USER_NOT_EXIST;
END IF;
END;
/

BEGIN 
EXECUTE IMMEDIATE 'CREATE TABLE 
"NeptuneDB"."AUTH_ORGANIZATION" (
    "OrganizationID" NVARCHAR2(100) NOT NULL,
    "OrganizationCode" NVARCHAR2(100) NOT NULL,
    "OrganizationName" NVARCHAR2(500) NOT NULL,
    "Phone" NVARCHAR2(50),
    "Status" NVARCHAR2(10) NOT NULL,
    "Email" NVARCHAR2(1000),
    "Website" NVARCHAR2(1000),
    "welcome_logo" clob,
    "login_background" clob,
    CONSTRAINT "PK_AUTH_ORGANIZATION" PRIMARY KEY ("OrganizationID")
)';
END;
/

BEGIN 
EXECUTE IMMEDIATE 'CREATE TABLE 
"NeptuneDB"."AUTH_ROLE" (
    "RoleID" NVARCHAR2(100) NOT NULL,
    "RoleCode" NVARCHAR2(100) NOT NULL,
    "RoleName" NVARCHAR2(500) NOT NULL,
    CONSTRAINT "PK_AUTH_ROLE" PRIMARY KEY ("RoleID")
)';
END;
/

BEGIN 
EXECUTE IMMEDIATE 'CREATE TABLE 
"NeptuneDB"."AUTH_ROLE_USER" (
    "RoleID" NVARCHAR2(100) NOT NULL,
    "UserID" NVARCHAR2(100) NOT NULL,
    CONSTRAINT "PK_AUTH_ROLE_USER" PRIMARY KEY ("RoleID", "UserID")
)';
END;
/

BEGIN 
EXECUTE IMMEDIATE 'CREATE TABLE 
"NeptuneDB"."AUTH_ROLE_WF" (
    "RoleID" NVARCHAR2(100) NOT NULL,
    "WorflowID" NVARCHAR2(100) NOT NULL,
    CONSTRAINT "PK_AUTH_ROLE_WF" PRIMARY KEY ("RoleID", "WorflowID")
)';
END;
/

BEGIN 
EXECUTE IMMEDIATE 'CREATE TABLE 
"NeptuneDB"."AUTH_USER" (
    "UserID" NVARCHAR2(100) NOT NULL,
    "UserCode" NVARCHAR2(100) NOT NULL,
    "OrganizationID" NVARCHAR2(100) NOT NULL,
    "UserName" NVARCHAR2(500),
    "FullName" NVARCHAR2(500),
    "Status" NVARCHAR2(10) NOT NULL,
    "LanguageCode" NVARCHAR2(2) NOT NULL,
    "SessionExpirationInMinutes" NUMBER(10) NOT NULL,
    "HashPassword" NVARCHAR2(500),
    "PastHashPassword1" NVARCHAR2(500),
    "PastHashPassword2" NVARCHAR2(500),
    "PastHashPassword3" NVARCHAR2(500),
    "PastHashPassword4" NVARCHAR2(500),
    "PastHashPassword5" NVARCHAR2(500),
    "PastHashPassword6" NVARCHAR2(500),
    "PastHashPassword7" NVARCHAR2(500),
    "PastHashPassword8" NVARCHAR2(500),
    "PastHashPassword9" NVARCHAR2(500),
    "PastHashPassword10" NVARCHAR2(500),
    "FailureCount" NUMBER(10) NOT NULL,
    "PasswordCreatedDate" NUMBER(19) NOT NULL,
    "TimeZone" DECIMAL(18, 2),
    CONSTRAINT "PK_AUTH_USER" PRIMARY KEY ("UserID")
)';
END;
/

BEGIN 
EXECUTE IMMEDIATE 'CREATE TABLE 
"NeptuneDB"."CONFIGURATION" (
    "PARA_CODE" NVARCHAR2(500) NOT NULL,
    "PARA_VALUE" NCLOB,
    CONSTRAINT "PK_CONFIGURATION" PRIMARY KEY ("PARA_CODE")
)';
END;
/

BEGIN 
EXECUTE IMMEDIATE 'CREATE TABLE 
"NeptuneDB"."ENVIRONMENT_VARIABLE" (
    "VARIABLE_NAME" NVARCHAR2(500) NOT NULL,
    "E1" clob,
    "E2" clob,
    "E3" clob,
    "E4" clob,
    "E5" clob,
    "E6" clob,
    "E7" clob,
    "E8" clob,
    "E9" clob,
    CONSTRAINT "PK_ENVIRONMENT_VARIABLE" PRIMARY KEY ("VARIABLE_NAME")
)';
END;
/

BEGIN 
EXECUTE IMMEDIATE 'CREATE TABLE 
"NeptuneDB"."EVENT_DEF" (
    "EVENT_NAME" NVARCHAR2(500) NOT NULL,
    "STATUS" NVARCHAR2(50) NOT NULL,
    "TYPE" NVARCHAR2(50) NOT NULL,
    "DESCRIPTION" NVARCHAR2(500),
    CONSTRAINT "PK_EVENT_DEF" PRIMARY KEY ("EVENT_NAME")
)';
END;
/

BEGIN 
EXECUTE IMMEDIATE 'CREATE TABLE 
"NeptuneDB"."INSTANCE" (
    "INSTANCE_ID" NVARCHAR2(50) NOT NULL,
    "GRPC_URL" NVARCHAR2(500) NOT NULL,
    "UTC_TIME" NUMBER(19) NOT NULL,
    "UTC_EXP_TIME" NUMBER(19) NOT NULL,
    "SERVICE_ID" NVARCHAR2(100),
    "EVENT_QUEUE_NAME" NVARCHAR2(500),
    "COMMAND_QUEUE_NAME" NVARCHAR2(500),
    CONSTRAINT "PK_INSTANCE" PRIMARY KEY ("INSTANCE_ID")
)';
END;
/

BEGIN 
EXECUTE IMMEDIATE 'CREATE TABLE 
"NeptuneDB"."JWT" (
    "ID" NVARCHAR2(1000) NOT NULL,
    "token" NVARCHAR2(1000) NOT NULL,
    "valid_from" NUMBER(19) NOT NULL,
    "valid_to" NUMBER(19) NOT NULL,
    "user_id" NVARCHAR2(1000) NOT NULL,
    "user_code" NVARCHAR2(1000) NOT NULL,
    "user_name" NVARCHAR2(1000) NOT NULL,
    "organization_id" NVARCHAR2(1000) NOT NULL,
    "organization_code" NVARCHAR2(1000) NOT NULL,
    "organization_name" NVARCHAR2(1000) NOT NULL,
    CONSTRAINT "PK_JWT" PRIMARY KEY ("ID")
)';
END;
/

BEGIN 
EXECUTE IMMEDIATE 'CREATE TABLE 
"NeptuneDB"."JWT_STATIC" (
    "ID" NVARCHAR2(1000) NOT NULL,
    "token" NVARCHAR2(1000) NOT NULL,
    "valid_from" NUMBER(19) NOT NULL,
    "valid_to" NUMBER(19) NOT NULL,
    "user_id" NVARCHAR2(1000) NOT NULL,
    "user_code" NVARCHAR2(1000) NOT NULL,
    "user_name" NVARCHAR2(1000) NOT NULL,
    "organization_id" NVARCHAR2(1000) NOT NULL,
    "organization_code" NVARCHAR2(1000) NOT NULL,
    "organization_name" NVARCHAR2(1000) NOT NULL,
    CONSTRAINT "PK_JWT_STATIC" PRIMARY KEY ("ID")
)';
END;
/

BEGIN 
EXECUTE IMMEDIATE 'CREATE TABLE 
"NeptuneDB"."LANGUAGE_RESOURCE" (
    "RESOURCE_CODE" NVARCHAR2(500) NOT NULL,
    "ID" NVARCHAR2(100) NOT NULL,
    "EN" clob NOT NULL,
    "VI" clob,
    "LA" clob,
    "KR" clob,
    "MM" clob,
    "TH" clob,
    CONSTRAINT "PK_LANGUAGE_RESOURCE" PRIMARY KEY ("RESOURCE_CODE")
)';
END;
/

BEGIN 
EXECUTE IMMEDIATE 'CREATE TABLE 
"NeptuneDB"."LOG_API" (
    "AUDIT_ID" NVARCHAR2(100) NOT NULL,
    "UTC_TIME" NUMBER(19) NOT NULL,
    "REQUEST_SCHEME" NVARCHAR2(100),
    "REQUEST_SERVER_IP" NVARCHAR2(100),
    "REQUEST_PATH" NCLOB,
    "REQUEST_HOST" NCLOB,
    "REQUEST_BODY" clob,
    "LOGIN_USER_ID" NVARCHAR2(100),
    "LOGIN_ORGANIZATION_ID" NVARCHAR2(100),
    "RESPONSE_EXECUTION_ID" NVARCHAR2(100),
    "RESPONSE_DESCRIPTION" NCLOB,
    "RESPONSE_STATUS" NVARCHAR2(100),
    "RESPONSE_DATA" clob,
    "TRACK_CHANGE" clob,
    CONSTRAINT "PK_LOG_API" PRIMARY KEY ("AUDIT_ID")
)';
END;
/

BEGIN 
EXECUTE IMMEDIATE 'CREATE TABLE 
"NeptuneDB"."LOG_EVENT" (
    "EVENT_ID" NVARCHAR2(50) NOT NULL,
    "INSTANCE_ID" NVARCHAR2(500) NOT NULL,
    "RUNNING_ID" NVARCHAR2(500) NOT NULL,
    "EVENT_TYPE" NVARCHAR2(100) NOT NULL,
    "UTC_TIME" NUMBER(19) NOT NULL,
    "DESCS" clob NOT NULL,
    "EVENT_DATA" clob,
    CONSTRAINT "PK_LOG_EVENT" PRIMARY KEY ("EVENT_ID")
)';
END;
/

BEGIN 
EXECUTE IMMEDIATE 'CREATE TABLE 
"NeptuneDB"."LOG_GRPC" (
    "ID" NVARCHAR2(50) NOT NULL,
    "INSTANCE_ID" NVARCHAR2(500) NOT NULL,
    "RUNNING_ID" NVARCHAR2(500) NOT NULL,
    "SERVER_TIME" NUMBER(19) NOT NULL,
    "FROM_SERVICE_ID" NVARCHAR2(100),
    "TO_SERVICE_ID" NVARCHAR2(100),
    "METHOD_SPEC" NCLOB,
    "METHOD_RESULT" clob,
    CONSTRAINT "PK_LOG_GRPC" PRIMARY KEY ("ID")
)';
END;
/

BEGIN 
EXECUTE IMMEDIATE 'CREATE TABLE 
"NeptuneDB"."LOG_HTTP_REQUEST" (
    "REQUEST_ID" NVARCHAR2(100) NOT NULL,
    "TIME_IN" NUMBER(19) NOT NULL,
    "TIME_OUT" NUMBER(19) NOT NULL,
    "DATA" clob,
    CONSTRAINT "PK_LOG_HTTP_REQUEST" PRIMARY KEY ("REQUEST_ID")
)';
END;
/

BEGIN 
EXECUTE IMMEDIATE 'CREATE TABLE 
"NeptuneDB"."LOG_INCOMING_QUEUE_MESSAGE" (
    "MESSAGE_ID" NVARCHAR2(100) NOT NULL,
    "COMING_TIME" NUMBER(19) NOT NULL,
    "COMING_STATUS" NVARCHAR2(50) NOT NULL,
    "COMING_CONTENT" clob,
    "PROCESSING_ERROR" clob,
    "REQUEST_EXEC_STEP_ID" NVARCHAR2(100),
    "RESPONSE_STATUS" NVARCHAR2(100),
    "RESPONSE_OUTPUT" clob,
    CONSTRAINT "PK_LOG_INCOMING_QUEUE_MESSAGE" PRIMARY KEY ("MESSAGE_ID")
)';
END;
/

BEGIN 
EXECUTE IMMEDIATE 'CREATE TABLE 
"NeptuneDB"."LOG_RECEIVING_HTTP" (
    "HTTP_ID" NVARCHAR2(100) NOT NULL,
    "TIME_START" NUMBER(19) NOT NULL,
    "TIME_FINISH" NUMBER(19) NOT NULL,
    "RECEIVING_DATA" clob,
    "SENDING_DATA" clob,
    "ERROR_DATA" clob,
    CONSTRAINT "PK_LOG_RECEIVING_HTTP" PRIMARY KEY ("HTTP_ID")
)';
END;
/

BEGIN 
EXECUTE IMMEDIATE 'CREATE TABLE 
"NeptuneDB"."SENDING_HTTP" (
    "HTTP_ID" NVARCHAR2(100) NOT NULL,
    "TIME_START" NUMBER(19) NOT NULL,
    "TIME_FINISH" NUMBER(19) NOT NULL,
    "SENDING_DATA" clob,
    "RECEIVING_DATA" clob,
    "ERROR_DATA" clob,
    CONSTRAINT "PK_SENDING_HTTP" PRIMARY KEY ("HTTP_ID")
)';
END;
/

BEGIN 
EXECUTE IMMEDIATE 'CREATE TABLE 
"NeptuneDB"."SERVICE_DEF" (
    "SERVICE_ID" NVARCHAR2(100) NOT NULL,
    "SERVICE_CODE" NVARCHAR2(100) NOT NULL,
    "SERVICE_NAME" NCLOB NOT NULL,
    "STATUS" NVARCHAR2(50) NOT NULL,
    "QUEUE_NAME" NVARCHAR2(100) NOT NULL,
    "ACCEPT_TIME" NUMBER(19) NOT NULL,
    "GRPC_STATUS" NVARCHAR2(50) NOT NULL,
    "GRPC_TIMEOUT" NUMBER(19) NOT NULL,
    "GRPC_URL" NVARCHAR2(500),
    "EVENT_REGISTRATION" NVARCHAR2(50) NOT NULL,
    "IMPORT_EXPORT_STEP_CODE" NVARCHAR2(50) NOT NULL,
    "CONCURRENT_THREADS" NUMBER(19) NOT NULL,
    "SERVICE_INSTANCE_TYPE" NVARCHAR2(50) NOT NULL,
    CONSTRAINT "PK_SERVICE_DEF" PRIMARY KEY ("SERVICE_ID")
)';
END;
/

BEGIN 
EXECUTE IMMEDIATE 'CREATE TABLE 
"NeptuneDB"."WF_DEF" (
    "WFID" NVARCHAR2(100) NOT NULL,
    "Code" NVARCHAR2(100),
    "Name" NVARCHAR2(500),
    "Status" NVARCHAR2(100) NOT NULL,
    "AllowReversal" NVARCHAR2(100) NOT NULL,
    "Description" NVARCHAR2(500),
    "TimeoutInMiliseconds" NUMBER(19) NOT NULL,
    "KeepExecSeconds" NUMBER(19) NOT NULL,
    "EventWorkflowRegistered" NVARCHAR2(50) NOT NULL,
    "EventWorkflowCompleted" NVARCHAR2(50) NOT NULL,
    "EventWorkflowError" NVARCHAR2(50) NOT NULL,
    "EventWorkflowTimeout" NVARCHAR2(50) NOT NULL,
    "EventWorkflowCompensated" NVARCHAR2(50) NOT NULL,
    "EventWorkflowReversed" NVARCHAR2(50) NOT NULL,
    "EventWorkflowStepStart" NVARCHAR2(50) NOT NULL,
    "EventWorkflowStepCompleted" NVARCHAR2(50) NOT NULL,
    "EventWorkflowStepError" NVARCHAR2(50) NOT NULL,
    "EventWorkflowStepTimeout" NVARCHAR2(50) NOT NULL,
    "EventWorkflowStepCompensated" NVARCHAR2(50) NOT NULL,
    CONSTRAINT "PK_WF_DEF" PRIMARY KEY ("WFID")
)';
END;
/

BEGIN 
EXECUTE IMMEDIATE 'CREATE TABLE 
"NeptuneDB"."WF_EXEC" (
    "EXECUTION_ID" NVARCHAR2(100) NOT NULL,
    "USER_ID" NVARCHAR2(100) NOT NULL,
    "ORGANIZATION_ID" NVARCHAR2(100) NOT NULL,
    "INPUT" clob NOT NULL,
    "WFID" NVARCHAR2(100) NOT NULL,
    "LANG" NVARCHAR2(2) NOT NULL,
    "CREATED_ON" NUMBER(19) NOT NULL,
    "STATUS" NVARCHAR2(100) NOT NULL,
    "FINISH_ON" NUMBER(19) NOT NULL,
    "IS_SUCCESS" NVARCHAR2(100) NOT NULL,
    "IS_TIMEOUT" NVARCHAR2(100) NOT NULL,
    "IS_PROCESSING" NVARCHAR2(100) NOT NULL,
    "STOP_ERROR" clob,
    "WORKFLOW_TYPE" NVARCHAR2(100) NOT NULL,
    "REVERSED_EXECUTION_ID" NVARCHAR2(100),
    "REVERSED_BY_EXECUTION_ID" NVARCHAR2(100),
    "IS_DISPUTED" NVARCHAR2(450) NOT NULL,
    "ARCHIVING_TIME" NUMBER(19) NOT NULL,
    "PURGING_TIME" NUMBER(19) NOT NULL,
    "TX_CONTEXT" clob,
    "APPROVED_EXECUTION_ID" NVARCHAR2(100),
    "SERVICE_INSTANCES" NVARCHAR2(2000),
    CONSTRAINT "PK_WF_EXEC" PRIMARY KEY ("EXECUTION_ID")
)';
END;
/

BEGIN 
EXECUTE IMMEDIATE 'CREATE TABLE 
"NeptuneDB"."WF_EXEC_DONE" (
    "EXECUTION_ID" NVARCHAR2(100) NOT NULL,
    "USER_ID" NVARCHAR2(100) NOT NULL,
    "ORGANIZATION_ID" NVARCHAR2(100) NOT NULL,
    "INPUT" clob NOT NULL,
    "WFID" NVARCHAR2(100) NOT NULL,
    "LANG" NVARCHAR2(2) NOT NULL,
    "CREATED_ON" NUMBER(19) NOT NULL,
    "STATUS" NVARCHAR2(100) NOT NULL,
    "FINISH_ON" NUMBER(19) NOT NULL,
    "IS_SUCCESS" NVARCHAR2(100) NOT NULL,
    "IS_TIMEOUT" NVARCHAR2(100) NOT NULL,
    "IS_PROCESSING" NVARCHAR2(100) NOT NULL,
    "STOP_ERROR" clob,
    "WORKFLOW_TYPE" NVARCHAR2(100) NOT NULL,
    "REVERSED_EXECUTION_ID" NVARCHAR2(100),
    "REVERSED_BY_EXECUTION_ID" NVARCHAR2(100),
    "IS_DISPUTED" NVARCHAR2(450) NOT NULL,
    "ARCHIVING_TIME" NUMBER(19) NOT NULL,
    "PURGING_TIME" NUMBER(19) NOT NULL,
    "TX_CONTEXT" clob,
    "APPROVED_EXECUTION_ID" NVARCHAR2(100),
    "SERVICE_INSTANCES" NVARCHAR2(2000),
    CONSTRAINT "PK_WF_EXEC_DONE" PRIMARY KEY ("EXECUTION_ID")
)';
END;
/

BEGIN 
EXECUTE IMMEDIATE 'CREATE TABLE 
"NeptuneDB"."WF_FIELD" (
    "WORKFLOW_ID" NVARCHAR2(100) NOT NULL,
    "FIELD_CODE" NVARCHAR2(100) NOT NULL,
    "FIELD_KEY" NVARCHAR2(100) NOT NULL,
    "DATA_TYPE" NVARCHAR2(100) NOT NULL,
    "IS_NULL" NVARCHAR2(100) NOT NULL,
    "IS_REQUIRED" NVARCHAR2(100) NOT NULL,
    "NUM_MIN" DECIMAL(18, 2) NOT NULL,
    "NUM_MAX" DECIMAL(18, 2) NOT NULL,
    "NUM_RANGE" clob,
    "TEXT_MIN" clob,
    "TEXT_MAX" clob,
    "TEXT_RANGE" clob,
    "TEXT_MAXLENGTH" NUMBER(10) NOT NULL,
    "DATE_MIN" DECIMAL(18, 2) NOT NULL,
    "DATE_MAX" DECIMAL(18, 2) NOT NULL,
    "DATE_RANGE" clob,
    "BASE64_ICON" clob,
    "OPENAPI_EXAMPLE" NVARCHAR2(2000),
    "OPENAPI_DESCRIPTION" NVARCHAR2(2000),
    CONSTRAINT "PK_WF_FIELD" PRIMARY KEY ("WORKFLOW_ID", "FIELD_CODE")
)';
END;
/

BEGIN 
EXECUTE IMMEDIATE 'CREATE TABLE 
"NeptuneDB"."WF_GROUP_EXEC" (
    "EXECUTION_ID" NVARCHAR2(100) NOT NULL,
    "STEP_GROUP" NUMBER(10) NOT NULL,
    "P1_STATUS" NVARCHAR2(100) NOT NULL,
    "P2_STATUS" NVARCHAR2(100) NOT NULL,
    "P1_START" NUMBER(19) NOT NULL,
    "P1_FINISH" NUMBER(19) NOT NULL,
    "P1_ERROR" clob,
    CONSTRAINT "PK_WF_GROUP_EXEC" PRIMARY KEY ("EXECUTION_ID", "STEP_GROUP")
)';
END;
/

BEGIN 
EXECUTE IMMEDIATE 'CREATE TABLE 
"NeptuneDB"."WF_GROUP_EXEC_DONE" (
    "EXECUTION_ID" NVARCHAR2(100) NOT NULL,
    "STEP_GROUP" NUMBER(10) NOT NULL,
    "P1_STATUS" NVARCHAR2(100) NOT NULL,
    "P2_STATUS" NVARCHAR2(100) NOT NULL,
    "P1_START" NUMBER(19) NOT NULL,
    "P1_FINISH" NUMBER(19) NOT NULL,
    "P1_ERROR" clob,
    CONSTRAINT "PK_WF_GROUP_EXEC_DONE" PRIMARY KEY ("EXECUTION_ID", "STEP_GROUP")
)';
END;
/

BEGIN 
EXECUTE IMMEDIATE 'CREATE TABLE 
"NeptuneDB"."WF_STEP_DEF" (
    "WFID" NVARCHAR2(100) NOT NULL,
    "STEP_ORDER" NUMBER(10) NOT NULL,
    "STEP_GROUP" NUMBER(10) NOT NULL,
    "STEP_CODE" NVARCHAR2(100),
    "STATUS" NVARCHAR2(100) NOT NULL,
    "DESCRIPTION" NCLOB,
    "SERVICE_ID" NVARCHAR2(100),
    "SENDING_TEMPLATE" clob,
    "SUCCESS_CONDITION" clob,
    "REQUEST_PROTOCOL" NVARCHAR2(1000),
    "REQUEST_SERVER_IP" NVARCHAR2(100),
    "REQUEST_SERVER_PORT" NVARCHAR2(100),
    "REQUEST_URI" NVARCHAR2(100),
    "SEND_BY_BROKER" NVARCHAR2(100) NOT NULL,
    "STEP_TIMEOUT" NVARCHAR2(100),
    "STEP_MODE" NVARCHAR2(20) NOT NULL,
    "BASE64_ICON" clob,
    "SENDING_CONDITION" clob,
    "ON_COMPENSATING" NVARCHAR2(100) NOT NULL,
    CONSTRAINT "PK_WF_STEP_DEF" PRIMARY KEY ("WFID", "STEP_ORDER")
)';
END;
/

BEGIN 
EXECUTE IMMEDIATE 'CREATE TABLE 
"NeptuneDB"."WF_STEP_EXEC" (
    "STEP_EXECUTION_ID" NVARCHAR2(100) NOT NULL,
    "EXECUTION_ID" NVARCHAR2(100) NOT NULL,
    "WORKFLOW_ID" NVARCHAR2(100),
    "STEP_GROUP" NUMBER(10) NOT NULL,
    "STEP_ORDER" NUMBER(10) NOT NULL,
    "STEP_CODE" NVARCHAR2(100),
    "P1_REQUEST_ID" NVARCHAR2(100),
    "P1_START" NUMBER(19) NOT NULL,
    "P1_FINISH" NUMBER(19) NOT NULL,
    "P1_STATUS" NVARCHAR2(100) NOT NULL,
    "P1_ERROR" clob,
    "P1_CONTENT" clob,
    "P2_REQUEST_ID" NVARCHAR2(100),
    "P2_START" NUMBER(19) NOT NULL,
    "P2_FINISH" NUMBER(19) NOT NULL,
    "P2_STATUS" NVARCHAR2(100) NOT NULL,
    "P2_RESPONSE_STATUS" NVARCHAR2(100),
    "P2_ERROR" clob,
    "P2_CONTENT" clob,
    "IS_SUCCESS" NVARCHAR2(100) NOT NULL,
    "IS_TIMEOUT" NVARCHAR2(100) NOT NULL,
    "P3_START" NUMBER(19) NOT NULL,
    "P3_FINISH" NUMBER(19) NOT NULL,
    "P3_STATUS" NVARCHAR2(100) NOT NULL,
    "P3_CONTENT" clob,
    "P3_ERROR" clob,
    "SENDING_CONDITION" clob,
    "P4_STATUS" NVARCHAR2(2000) NOT NULL,
    "IS_DISPUTED" NVARCHAR2(450) NOT NULL,
    "P4_CONTENT" clob,
    CONSTRAINT "PK_WF_STEP_EXEC" PRIMARY KEY ("STEP_EXECUTION_ID")
)';
END;
/

BEGIN 
EXECUTE IMMEDIATE 'CREATE TABLE 
"NeptuneDB"."WF_STEP_EXEC_DONE" (
    "STEP_EXECUTION_ID" NVARCHAR2(100) NOT NULL,
    "EXECUTION_ID" NVARCHAR2(100) NOT NULL,
    "WORKFLOW_ID" NVARCHAR2(100),
    "STEP_GROUP" NUMBER(10) NOT NULL,
    "STEP_ORDER" NUMBER(10) NOT NULL,
    "STEP_CODE" NVARCHAR2(100),
    "P1_REQUEST_ID" NVARCHAR2(100),
    "P1_START" NUMBER(19) NOT NULL,
    "P1_FINISH" NUMBER(19) NOT NULL,
    "P1_STATUS" NVARCHAR2(100) NOT NULL,
    "P1_ERROR" clob,
    "P1_CONTENT" clob,
    "P2_REQUEST_ID" NVARCHAR2(100),
    "P2_START" NUMBER(19) NOT NULL,
    "P2_FINISH" NUMBER(19) NOT NULL,
    "P2_STATUS" NVARCHAR2(100) NOT NULL,
    "P2_RESPONSE_STATUS" NVARCHAR2(100),
    "P2_ERROR" clob,
    "P2_CONTENT" clob,
    "IS_SUCCESS" NVARCHAR2(100) NOT NULL,
    "IS_TIMEOUT" NVARCHAR2(100) NOT NULL,
    "P3_START" NUMBER(19) NOT NULL,
    "P3_FINISH" NUMBER(19) NOT NULL,
    "P3_STATUS" NVARCHAR2(100) NOT NULL,
    "P3_CONTENT" clob,
    "P3_ERROR" clob,
    "SENDING_CONDITION" clob,
    "P4_STATUS" NVARCHAR2(2000) NOT NULL,
    "IS_DISPUTED" NVARCHAR2(450) NOT NULL,
    "P4_CONTENT" clob,
    CONSTRAINT "PK_WF_STEP_EXEC_DONE" PRIMARY KEY ("STEP_EXECUTION_ID")
)';
END;
/

CREATE UNIQUE INDEX "NeptuneDB"."IX_AUTH_ORGANIZATION_OrganizationCode" ON "NeptuneDB"."AUTH_ORGANIZATION" ("OrganizationCode")
/

CREATE UNIQUE INDEX "NeptuneDB"."IX_AUTH_ROLE_RoleCode" ON "NeptuneDB"."AUTH_ROLE" ("RoleCode")
/

CREATE UNIQUE INDEX "NeptuneDB"."IX_AUTH_USER_UserCode" ON "NeptuneDB"."AUTH_USER" ("UserCode")
/

CREATE INDEX "NeptuneDB"."IX_INSTANCE_SERVICE_ID" ON "NeptuneDB"."INSTANCE" ("SERVICE_ID")
/

CREATE INDEX "NeptuneDB"."IX_JWT_token" ON "NeptuneDB"."JWT" ("token")
/

CREATE UNIQUE INDEX "NeptuneDB"."IX_LANGUAGE_RESOURCE_RESOURCE_CODE" ON "NeptuneDB"."LANGUAGE_RESOURCE" ("RESOURCE_CODE")
/

CREATE INDEX "NeptuneDB"."IX_LOG_API_LOGIN_ORGANIZATION_ID" ON "NeptuneDB"."LOG_API" ("LOGIN_ORGANIZATION_ID")
/

CREATE INDEX "NeptuneDB"."IX_LOG_API_LOGIN_USER_ID" ON "NeptuneDB"."LOG_API" ("LOGIN_USER_ID")
/

CREATE INDEX "NeptuneDB"."IX_LOG_API_RESPONSE_STATUS" ON "NeptuneDB"."LOG_API" ("RESPONSE_STATUS")
/

CREATE INDEX "NeptuneDB"."IX_LOG_API_UTC_TIME" ON "NeptuneDB"."LOG_API" ("UTC_TIME")
/

CREATE INDEX "NeptuneDB"."IX_LOG_EVENT_UTC_TIME" ON "NeptuneDB"."LOG_EVENT" ("UTC_TIME")
/

CREATE INDEX "NeptuneDB"."IX_LOG_GRPC_INSTANCE_ID" ON "NeptuneDB"."LOG_GRPC" ("INSTANCE_ID")
/

CREATE INDEX "NeptuneDB"."IX_LOG_GRPC_RUNNING_ID" ON "NeptuneDB"."LOG_GRPC" ("RUNNING_ID")
/

CREATE INDEX "NeptuneDB"."IX_LOG_GRPC_SERVER_TIME" ON "NeptuneDB"."LOG_GRPC" ("SERVER_TIME")
/

CREATE UNIQUE INDEX "NeptuneDB"."IX_SERVICE_DEF_SERVICE_CODE" ON "NeptuneDB"."SERVICE_DEF" ("SERVICE_CODE")
/

CREATE UNIQUE INDEX "NeptuneDB"."IX_WF_DEF_Code" ON "NeptuneDB"."WF_DEF" ("Code")
/

CREATE INDEX "NeptuneDB"."IX_WF_EXEC_ARCHIVING_TIME" ON "NeptuneDB"."WF_EXEC" ("ARCHIVING_TIME")
/

CREATE INDEX "NeptuneDB"."IX_WF_EXEC_CREATED_ON" ON "NeptuneDB"."WF_EXEC" ("CREATED_ON")
/

CREATE INDEX "NeptuneDB"."IX_WF_EXEC_FINISH_ON" ON "NeptuneDB"."WF_EXEC" ("FINISH_ON")
/

CREATE INDEX "NeptuneDB"."IX_WF_EXEC_IS_DISPUTED" ON "NeptuneDB"."WF_EXEC" ("IS_DISPUTED")
/

CREATE INDEX "NeptuneDB"."IX_WF_EXEC_IS_SUCCESS" ON "NeptuneDB"."WF_EXEC" ("IS_SUCCESS")
/

CREATE INDEX "NeptuneDB"."IX_WF_EXEC_IS_TIMEOUT" ON "NeptuneDB"."WF_EXEC" ("IS_TIMEOUT")
/

CREATE INDEX "NeptuneDB"."IX_WF_EXEC_ORGANIZATION_ID" ON "NeptuneDB"."WF_EXEC" ("ORGANIZATION_ID")
/

CREATE INDEX "NeptuneDB"."IX_WF_EXEC_PURGING_TIME" ON "NeptuneDB"."WF_EXEC" ("PURGING_TIME")
/

CREATE INDEX "NeptuneDB"."IX_WF_EXEC_STATUS" ON "NeptuneDB"."WF_EXEC" ("STATUS")
/

CREATE INDEX "NeptuneDB"."IX_WF_EXEC_USER_ID" ON "NeptuneDB"."WF_EXEC" ("USER_ID")
/

CREATE INDEX "NeptuneDB"."IX_WF_EXEC_WFID" ON "NeptuneDB"."WF_EXEC" ("WFID")
/

CREATE INDEX "NeptuneDB"."IX_WF_EXEC_WORKFLOW_TYPE" ON "NeptuneDB"."WF_EXEC" ("WORKFLOW_TYPE")
/

CREATE INDEX "NeptuneDB"."IX_WF_EXEC_DONE_ARCHIVING_TIME" ON "NeptuneDB"."WF_EXEC_DONE" ("ARCHIVING_TIME")
/

CREATE INDEX "NeptuneDB"."IX_WF_EXEC_DONE_CREATED_ON" ON "NeptuneDB"."WF_EXEC_DONE" ("CREATED_ON")
/

CREATE INDEX "NeptuneDB"."IX_WF_EXEC_DONE_FINISH_ON" ON "NeptuneDB"."WF_EXEC_DONE" ("FINISH_ON")
/

CREATE INDEX "NeptuneDB"."IX_WF_EXEC_DONE_IS_DISPUTED" ON "NeptuneDB"."WF_EXEC_DONE" ("IS_DISPUTED")
/

CREATE INDEX "NeptuneDB"."IX_WF_EXEC_DONE_IS_SUCCESS" ON "NeptuneDB"."WF_EXEC_DONE" ("IS_SUCCESS")
/

CREATE INDEX "NeptuneDB"."IX_WF_EXEC_DONE_IS_TIMEOUT" ON "NeptuneDB"."WF_EXEC_DONE" ("IS_TIMEOUT")
/

CREATE INDEX "NeptuneDB"."IX_WF_EXEC_DONE_ORGANIZATION_ID" ON "NeptuneDB"."WF_EXEC_DONE" ("ORGANIZATION_ID")
/

CREATE INDEX "NeptuneDB"."IX_WF_EXEC_DONE_PURGING_TIME" ON "NeptuneDB"."WF_EXEC_DONE" ("PURGING_TIME")
/

CREATE INDEX "NeptuneDB"."IX_WF_EXEC_DONE_STATUS" ON "NeptuneDB"."WF_EXEC_DONE" ("STATUS")
/

CREATE INDEX "NeptuneDB"."IX_WF_EXEC_DONE_USER_ID" ON "NeptuneDB"."WF_EXEC_DONE" ("USER_ID")
/

CREATE INDEX "NeptuneDB"."IX_WF_EXEC_DONE_WFID" ON "NeptuneDB"."WF_EXEC_DONE" ("WFID")
/

CREATE INDEX "NeptuneDB"."IX_WF_EXEC_DONE_WORKFLOW_TYPE" ON "NeptuneDB"."WF_EXEC_DONE" ("WORKFLOW_TYPE")
/

CREATE INDEX "NeptuneDB"."IX_WF_STEP_EXEC_EXECUTION_ID" ON "NeptuneDB"."WF_STEP_EXEC" ("EXECUTION_ID")
/

CREATE INDEX "NeptuneDB"."IX_WF_STEP_EXEC_IS_DISPUTED" ON "NeptuneDB"."WF_STEP_EXEC" ("IS_DISPUTED")
/

CREATE INDEX "NeptuneDB"."IX_WF_STEP_EXEC_IS_SUCCESS" ON "NeptuneDB"."WF_STEP_EXEC" ("IS_SUCCESS")
/

CREATE INDEX "NeptuneDB"."IX_WF_STEP_EXEC_IS_TIMEOUT" ON "NeptuneDB"."WF_STEP_EXEC" ("IS_TIMEOUT")
/

CREATE INDEX "NeptuneDB"."IX_WF_STEP_EXEC_P1_FINISH" ON "NeptuneDB"."WF_STEP_EXEC" ("P1_FINISH")
/

CREATE INDEX "NeptuneDB"."IX_WF_STEP_EXEC_P1_START" ON "NeptuneDB"."WF_STEP_EXEC" ("P1_START")
/

CREATE INDEX "NeptuneDB"."IX_WF_STEP_EXEC_P1_STATUS" ON "NeptuneDB"."WF_STEP_EXEC" ("P1_STATUS")
/

CREATE INDEX "NeptuneDB"."IX_WF_STEP_EXEC_P2_FINISH" ON "NeptuneDB"."WF_STEP_EXEC" ("P2_FINISH")
/

CREATE INDEX "NeptuneDB"."IX_WF_STEP_EXEC_P2_START" ON "NeptuneDB"."WF_STEP_EXEC" ("P2_START")
/

CREATE INDEX "NeptuneDB"."IX_WF_STEP_EXEC_P2_STATUS" ON "NeptuneDB"."WF_STEP_EXEC" ("P2_STATUS")
/

CREATE INDEX "NeptuneDB"."IX_WF_STEP_EXEC_P3_FINISH" ON "NeptuneDB"."WF_STEP_EXEC" ("P3_FINISH")
/

CREATE INDEX "NeptuneDB"."IX_WF_STEP_EXEC_P3_START" ON "NeptuneDB"."WF_STEP_EXEC" ("P3_START")
/

CREATE INDEX "NeptuneDB"."IX_WF_STEP_EXEC_P3_STATUS" ON "NeptuneDB"."WF_STEP_EXEC" ("P3_STATUS")
/

CREATE INDEX "NeptuneDB"."IX_WF_STEP_EXEC_STEP_CODE" ON "NeptuneDB"."WF_STEP_EXEC" ("STEP_CODE")
/

CREATE INDEX "NeptuneDB"."IX_WF_STEP_EXEC_WORKFLOW_ID" ON "NeptuneDB"."WF_STEP_EXEC" ("WORKFLOW_ID")
/

CREATE INDEX "NeptuneDB"."IX_WF_STEP_EXEC_DONE_EXECUTION_ID" ON "NeptuneDB"."WF_STEP_EXEC_DONE" ("EXECUTION_ID")
/

CREATE INDEX "NeptuneDB"."IX_WF_STEP_EXEC_DONE_IS_DISPUTED" ON "NeptuneDB"."WF_STEP_EXEC_DONE" ("IS_DISPUTED")
/

CREATE INDEX "NeptuneDB"."IX_WF_STEP_EXEC_DONE_IS_SUCCESS" ON "NeptuneDB"."WF_STEP_EXEC_DONE" ("IS_SUCCESS")
/

CREATE INDEX "NeptuneDB"."IX_WF_STEP_EXEC_DONE_IS_TIMEOUT" ON "NeptuneDB"."WF_STEP_EXEC_DONE" ("IS_TIMEOUT")
/

CREATE INDEX "NeptuneDB"."IX_WF_STEP_EXEC_DONE_P1_FINISH" ON "NeptuneDB"."WF_STEP_EXEC_DONE" ("P1_FINISH")
/

CREATE INDEX "NeptuneDB"."IX_WF_STEP_EXEC_DONE_P1_START" ON "NeptuneDB"."WF_STEP_EXEC_DONE" ("P1_START")
/

CREATE INDEX "NeptuneDB"."IX_WF_STEP_EXEC_DONE_P1_STATUS" ON "NeptuneDB"."WF_STEP_EXEC_DONE" ("P1_STATUS")
/

CREATE INDEX "NeptuneDB"."IX_WF_STEP_EXEC_DONE_P2_FINISH" ON "NeptuneDB"."WF_STEP_EXEC_DONE" ("P2_FINISH")
/

CREATE INDEX "NeptuneDB"."IX_WF_STEP_EXEC_DONE_P2_START" ON "NeptuneDB"."WF_STEP_EXEC_DONE" ("P2_START")
/

CREATE INDEX "NeptuneDB"."IX_WF_STEP_EXEC_DONE_P2_STATUS" ON "NeptuneDB"."WF_STEP_EXEC_DONE" ("P2_STATUS")
/

CREATE INDEX "NeptuneDB"."IX_WF_STEP_EXEC_DONE_P3_FINISH" ON "NeptuneDB"."WF_STEP_EXEC_DONE" ("P3_FINISH")
/

CREATE INDEX "NeptuneDB"."IX_WF_STEP_EXEC_DONE_P3_START" ON "NeptuneDB"."WF_STEP_EXEC_DONE" ("P3_START")
/

CREATE INDEX "NeptuneDB"."IX_WF_STEP_EXEC_DONE_P3_STATUS" ON "NeptuneDB"."WF_STEP_EXEC_DONE" ("P3_STATUS")
/

CREATE INDEX "NeptuneDB"."IX_WF_STEP_EXEC_DONE_STEP_CODE" ON "NeptuneDB"."WF_STEP_EXEC_DONE" ("STEP_CODE")
/

CREATE INDEX "NeptuneDB"."IX_WF_STEP_EXEC_DONE_WORKFLOW_ID" ON "NeptuneDB"."WF_STEP_EXEC_DONE" ("WORKFLOW_ID")
/

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES (N'20221108041825_v1', N'6.0.10')
/

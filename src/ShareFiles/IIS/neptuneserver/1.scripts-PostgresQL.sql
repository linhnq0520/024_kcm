CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM pg_namespace WHERE nspname = 'NeptuneDB') THEN
        CREATE SCHEMA "NeptuneDB";
    END IF;
END $EF$;

CREATE TABLE "NeptuneDB"."AUTH_ORGANIZATION" (
    "OrganizationID" character varying(100) NOT NULL,
    "OrganizationCode" character varying(100) NOT NULL,
    "OrganizationName" character varying(500) NOT NULL,
    "Phone" character varying(50) NULL,
    "Status" character varying(10) NOT NULL,
    "Email" character varying(1000) NULL,
    "Website" character varying(1000) NULL,
    welcome_logo text NULL,
    login_background text NULL,
    CONSTRAINT "PK_AUTH_ORGANIZATION" PRIMARY KEY ("OrganizationID")
);

CREATE TABLE "NeptuneDB"."AUTH_ROLE" (
    "RoleID" character varying(100) NOT NULL,
    "RoleCode" character varying(100) NOT NULL,
    "RoleName" character varying(500) NOT NULL,
    CONSTRAINT "PK_AUTH_ROLE" PRIMARY KEY ("RoleID")
);

CREATE TABLE "NeptuneDB"."AUTH_ROLE_USER" (
    "RoleID" character varying(100) NOT NULL,
    "UserID" character varying(100) NOT NULL,
    CONSTRAINT "PK_AUTH_ROLE_USER" PRIMARY KEY ("RoleID", "UserID")
);

CREATE TABLE "NeptuneDB"."AUTH_ROLE_WF" (
    "RoleID" character varying(100) NOT NULL,
    "WorflowID" character varying(100) NOT NULL,
    CONSTRAINT "PK_AUTH_ROLE_WF" PRIMARY KEY ("RoleID", "WorflowID")
);

CREATE TABLE "NeptuneDB"."AUTH_USER" (
    "UserID" character varying(100) NOT NULL,
    "UserCode" character varying(100) NOT NULL,
    "OrganizationID" character varying(100) NOT NULL,
    "UserName" character varying(500) NULL,
    "FullName" character varying(500) NULL,
    "Status" character varying(10) NOT NULL,
    "LanguageCode" character varying(2) NOT NULL,
    "SessionExpirationInMinutes" integer NOT NULL,
    "HashPassword" character varying(500) NULL,
    "PastHashPassword1" character varying(500) NULL,
    "PastHashPassword2" character varying(500) NULL,
    "PastHashPassword3" character varying(500) NULL,
    "PastHashPassword4" character varying(500) NULL,
    "PastHashPassword5" character varying(500) NULL,
    "PastHashPassword6" character varying(500) NULL,
    "PastHashPassword7" character varying(500) NULL,
    "PastHashPassword8" character varying(500) NULL,
    "PastHashPassword9" character varying(500) NULL,
    "PastHashPassword10" character varying(500) NULL,
    "FailureCount" integer NOT NULL,
    "PasswordCreatedDate" bigint NOT NULL,
    "TimeZone" numeric NULL,
    CONSTRAINT "PK_AUTH_USER" PRIMARY KEY ("UserID")
);

CREATE TABLE "NeptuneDB"."CONFIGURATION" (
    "PARA_CODE" character varying(500) NOT NULL,
    "PARA_VALUE" character varying(4000) NULL,
    CONSTRAINT "PK_CONFIGURATION" PRIMARY KEY ("PARA_CODE")
);

CREATE TABLE "NeptuneDB"."ENVIRONMENT_VARIABLE" (
    "VARIABLE_NAME" character varying(500) NOT NULL,
    "E1" text NULL,
    "E2" text NULL,
    "E3" text NULL,
    "E4" text NULL,
    "E5" text NULL,
    "E6" text NULL,
    "E7" text NULL,
    "E8" text NULL,
    "E9" text NULL,
    CONSTRAINT "PK_ENVIRONMENT_VARIABLE" PRIMARY KEY ("VARIABLE_NAME")
);

CREATE TABLE "NeptuneDB"."EVENT_DEF" (
    "EVENT_NAME" character varying(500) NOT NULL,
    "STATUS" character varying(50) NOT NULL,
    "TYPE" character varying(50) NOT NULL,
    "DESCRIPTION" character varying(500) NULL,
    CONSTRAINT "PK_EVENT_DEF" PRIMARY KEY ("EVENT_NAME")
);

CREATE TABLE "NeptuneDB"."INSTANCE" (
    "INSTANCE_ID" character varying(50) NOT NULL,
    "GRPC_URL" character varying(500) NOT NULL,
    "UTC_TIME" bigint NOT NULL,
    "UTC_EXP_TIME" bigint NOT NULL,
    "SERVICE_ID" character varying(100) NULL,
    "EVENT_QUEUE_NAME" character varying(500) NULL,
    "COMMAND_QUEUE_NAME" character varying(500) NULL,
    CONSTRAINT "PK_INSTANCE" PRIMARY KEY ("INSTANCE_ID")
);

CREATE TABLE "NeptuneDB"."JWT" (
    "ID" character varying(1000) NOT NULL,
    token character varying(1000) NOT NULL,
    valid_from bigint NOT NULL,
    valid_to bigint NOT NULL,
    user_id character varying(1000) NOT NULL,
    user_code character varying(1000) NOT NULL,
    user_name character varying(1000) NOT NULL,
    organization_id character varying(1000) NOT NULL,
    organization_code character varying(1000) NOT NULL,
    organization_name character varying(1000) NOT NULL,
    CONSTRAINT "PK_JWT" PRIMARY KEY ("ID")
);

CREATE TABLE "NeptuneDB"."JWT_STATIC" (
    "ID" character varying(1000) NOT NULL,
    token character varying(1000) NOT NULL,
    valid_from bigint NOT NULL,
    valid_to bigint NOT NULL,
    user_id character varying(1000) NOT NULL,
    user_code character varying(1000) NOT NULL,
    user_name character varying(1000) NOT NULL,
    organization_id character varying(1000) NOT NULL,
    organization_code character varying(1000) NOT NULL,
    organization_name character varying(1000) NOT NULL,
    CONSTRAINT "PK_JWT_STATIC" PRIMARY KEY ("ID")
);

CREATE TABLE "NeptuneDB"."LANGUAGE_RESOURCE" (
    "RESOURCE_CODE" character varying(500) NOT NULL,
    "ID" character varying(100) NOT NULL,
    "EN" text NOT NULL,
    "VI" text NULL,
    "LA" text NULL,
    "KR" text NULL,
    "MM" text NULL,
    "TH" text NULL,
    CONSTRAINT "PK_LANGUAGE_RESOURCE" PRIMARY KEY ("RESOURCE_CODE")
);

CREATE TABLE "NeptuneDB"."LOG_API" (
    "AUDIT_ID" character varying(100) NOT NULL,
    "UTC_TIME" bigint NOT NULL,
    "REQUEST_SCHEME" character varying(100) NULL,
    "REQUEST_SERVER_IP" character varying(100) NULL,
    "REQUEST_PATH" character varying(4000) NULL,
    "REQUEST_HOST" character varying(4000) NULL,
    "REQUEST_BODY" text NULL,
    "LOGIN_USER_ID" character varying(100) NULL,
    "LOGIN_ORGANIZATION_ID" character varying(100) NULL,
    "RESPONSE_EXECUTION_ID" character varying(100) NULL,
    "RESPONSE_DESCRIPTION" character varying(4000) NULL,
    "RESPONSE_STATUS" character varying(100) NULL,
    "RESPONSE_DATA" text NULL,
    "TRACK_CHANGE" text NULL,
    CONSTRAINT "PK_LOG_API" PRIMARY KEY ("AUDIT_ID")
);

CREATE TABLE "NeptuneDB"."LOG_EVENT" (
    "EVENT_ID" character varying(50) NOT NULL,
    "INSTANCE_ID" character varying(500) NOT NULL,
    "RUNNING_ID" character varying(500) NOT NULL,
    "EVENT_TYPE" character varying(100) NOT NULL,
    "UTC_TIME" bigint NOT NULL,
    "DESCS" text NOT NULL,
    "EVENT_DATA" text NULL,
    CONSTRAINT "PK_LOG_EVENT" PRIMARY KEY ("EVENT_ID")
);

CREATE TABLE "NeptuneDB"."LOG_GRPC" (
    "ID" character varying(50) NOT NULL,
    "INSTANCE_ID" character varying(500) NOT NULL,
    "RUNNING_ID" character varying(500) NOT NULL,
    "SERVER_TIME" bigint NOT NULL,
    "FROM_SERVICE_ID" character varying(100) NULL,
    "TO_SERVICE_ID" character varying(100) NULL,
    "METHOD_SPEC" character varying(4000) NULL,
    "METHOD_RESULT" text NULL,
    CONSTRAINT "PK_LOG_GRPC" PRIMARY KEY ("ID")
);

CREATE TABLE "NeptuneDB"."LOG_HTTP_REQUEST" (
    "REQUEST_ID" character varying(100) NOT NULL,
    "TIME_IN" bigint NOT NULL,
    "TIME_OUT" bigint NOT NULL,
    "DATA" text NULL,
    CONSTRAINT "PK_LOG_HTTP_REQUEST" PRIMARY KEY ("REQUEST_ID")
);

CREATE TABLE "NeptuneDB"."LOG_INCOMING_QUEUE_MESSAGE" (
    "MESSAGE_ID" character varying(100) NOT NULL,
    "COMING_TIME" bigint NOT NULL,
    "COMING_STATUS" character varying(50) NOT NULL,
    "COMING_CONTENT" text NULL,
    "PROCESSING_ERROR" text NULL,
    "REQUEST_EXEC_STEP_ID" character varying(100) NULL,
    "RESPONSE_STATUS" character varying(100) NULL,
    "RESPONSE_OUTPUT" text NULL,
    CONSTRAINT "PK_LOG_INCOMING_QUEUE_MESSAGE" PRIMARY KEY ("MESSAGE_ID")
);

CREATE TABLE "NeptuneDB"."LOG_RECEIVING_HTTP" (
    "HTTP_ID" character varying(100) NOT NULL,
    "TIME_START" bigint NOT NULL,
    "TIME_FINISH" bigint NOT NULL,
    "RECEIVING_DATA" text NULL,
    "SENDING_DATA" text NULL,
    "ERROR_DATA" text NULL,
    CONSTRAINT "PK_LOG_RECEIVING_HTTP" PRIMARY KEY ("HTTP_ID")
);

CREATE TABLE "NeptuneDB"."SENDING_HTTP" (
    "HTTP_ID" character varying(100) NOT NULL,
    "TIME_START" bigint NOT NULL,
    "TIME_FINISH" bigint NOT NULL,
    "SENDING_DATA" text NULL,
    "RECEIVING_DATA" text NULL,
    "ERROR_DATA" text NULL,
    CONSTRAINT "PK_SENDING_HTTP" PRIMARY KEY ("HTTP_ID")
);

CREATE TABLE "NeptuneDB"."SERVICE_DEF" (
    "SERVICE_ID" character varying(100) NOT NULL,
    "SERVICE_CODE" character varying(100) NOT NULL,
    "SERVICE_NAME" character varying(4000) NOT NULL,
    "STATUS" character varying(50) NOT NULL,
    "QUEUE_NAME" character varying(100) NOT NULL,
    "ACCEPT_TIME" bigint NOT NULL,
    "GRPC_STATUS" character varying(50) NOT NULL,
    "GRPC_TIMEOUT" bigint NOT NULL,
    "GRPC_URL" character varying(500) NULL,
    "EVENT_REGISTRATION" character varying(50) NOT NULL,
    "IMPORT_EXPORT_STEP_CODE" character varying(50) NOT NULL,
    "CONCURRENT_THREADS" bigint NOT NULL,
    "SERVICE_INSTANCE_TYPE" character varying(50) NOT NULL,
    CONSTRAINT "PK_SERVICE_DEF" PRIMARY KEY ("SERVICE_ID")
);

CREATE TABLE "NeptuneDB"."WF_DEF" (
    "WFID" character varying(100) NOT NULL,
    "Code" character varying(100) NULL,
    "Name" character varying(500) NULL,
    "Status" character varying(100) NOT NULL,
    "AllowReversal" character varying(100) NOT NULL,
    "Description" character varying(500) NULL,
    "TimeoutInMiliseconds" bigint NOT NULL,
    "KeepExecSeconds" bigint NOT NULL,
    "EventWorkflowRegistered" character varying(50) NOT NULL,
    "EventWorkflowCompleted" character varying(50) NOT NULL,
    "EventWorkflowError" character varying(50) NOT NULL,
    "EventWorkflowTimeout" character varying(50) NOT NULL,
    "EventWorkflowCompensated" character varying(50) NOT NULL,
    "EventWorkflowReversed" character varying(50) NOT NULL,
    "EventWorkflowStepStart" character varying(50) NOT NULL,
    "EventWorkflowStepCompleted" character varying(50) NOT NULL,
    "EventWorkflowStepError" character varying(50) NOT NULL,
    "EventWorkflowStepTimeout" character varying(50) NOT NULL,
    "EventWorkflowStepCompensated" character varying(50) NOT NULL,
    CONSTRAINT "PK_WF_DEF" PRIMARY KEY ("WFID")
);

CREATE TABLE "NeptuneDB"."WF_EXEC" (
    "EXECUTION_ID" character varying(100) NOT NULL,
    "USER_ID" character varying(100) NOT NULL,
    "ORGANIZATION_ID" character varying(100) NOT NULL,
    "INPUT" text NOT NULL,
    "WFID" character varying(100) NOT NULL,
    "LANG" character varying(2) NOT NULL,
    "CREATED_ON" bigint NOT NULL,
    "STATUS" character varying(100) NOT NULL,
    "FINISH_ON" bigint NOT NULL,
    "IS_SUCCESS" character varying(100) NOT NULL,
    "IS_TIMEOUT" character varying(100) NOT NULL,
    "IS_PROCESSING" character varying(100) NOT NULL,
    "STOP_ERROR" text NULL,
    "WORKFLOW_TYPE" character varying(100) NOT NULL,
    "REVERSED_EXECUTION_ID" character varying(100) NOT NULL,
    "REVERSED_BY_EXECUTION_ID" character varying(100) NOT NULL,
    "IS_DISPUTED" text NOT NULL,
    "ARCHIVING_TIME" bigint NOT NULL,
    "PURGING_TIME" bigint NOT NULL,
    "TX_CONTEXT" text NOT NULL,
    "APPROVED_EXECUTION_ID" character varying(100) NULL,
    "SERVICE_INSTANCES" character varying(2000) NULL,
    CONSTRAINT "PK_WF_EXEC" PRIMARY KEY ("EXECUTION_ID")
);

CREATE TABLE "NeptuneDB"."WF_EXEC_DONE" (
    "EXECUTION_ID" character varying(100) NOT NULL,
    "USER_ID" character varying(100) NOT NULL,
    "ORGANIZATION_ID" character varying(100) NOT NULL,
    "INPUT" text NOT NULL,
    "WFID" character varying(100) NOT NULL,
    "LANG" character varying(2) NOT NULL,
    "CREATED_ON" bigint NOT NULL,
    "STATUS" character varying(100) NOT NULL,
    "FINISH_ON" bigint NOT NULL,
    "IS_SUCCESS" character varying(100) NOT NULL,
    "IS_TIMEOUT" character varying(100) NOT NULL,
    "IS_PROCESSING" character varying(100) NOT NULL,
    "STOP_ERROR" text NULL,
    "WORKFLOW_TYPE" character varying(100) NOT NULL,
    "REVERSED_EXECUTION_ID" character varying(100) NOT NULL,
    "REVERSED_BY_EXECUTION_ID" character varying(100) NOT NULL,
    "IS_DISPUTED" text NOT NULL,
    "ARCHIVING_TIME" bigint NOT NULL,
    "PURGING_TIME" bigint NOT NULL,
    "TX_CONTEXT" text NOT NULL,
    "APPROVED_EXECUTION_ID" character varying(100) NULL,
    "SERVICE_INSTANCES" character varying(2000) NULL,
    CONSTRAINT "PK_WF_EXEC_DONE" PRIMARY KEY ("EXECUTION_ID")
);

CREATE TABLE "NeptuneDB"."WF_FIELD" (
    "WORKFLOW_ID" character varying(100) NOT NULL,
    "FIELD_CODE" character varying(100) NOT NULL,
    "FIELD_KEY" character varying(100) NOT NULL,
    "DATA_TYPE" character varying(100) NOT NULL,
    "IS_NULL" character varying(100) NOT NULL,
    "IS_REQUIRED" character varying(100) NOT NULL,
    "NUM_MIN" numeric NOT NULL,
    "NUM_MAX" numeric NOT NULL,
    "NUM_RANGE" text NULL,
    "TEXT_MIN" text NULL,
    "TEXT_MAX" text NULL,
    "TEXT_RANGE" text NULL,
    "TEXT_MAXLENGTH" integer NOT NULL,
    "DATE_MIN" numeric NOT NULL,
    "DATE_MAX" numeric NOT NULL,
    "DATE_RANGE" text NULL,
    "BASE64_ICON" text NULL,
    "OPENAPI_EXAMPLE" text NULL,
    "OPENAPI_DESCRIPTION" text NULL,
    CONSTRAINT "PK_WF_FIELD" PRIMARY KEY ("WORKFLOW_ID", "FIELD_CODE")
);

CREATE TABLE "NeptuneDB"."WF_GROUP_EXEC" (
    "EXECUTION_ID" character varying(100) NOT NULL,
    "STEP_GROUP" integer NOT NULL,
    "P1_STATUS" character varying(100) NOT NULL,
    "P2_STATUS" character varying(100) NOT NULL,
    "P1_START" bigint NOT NULL,
    "P1_FINISH" bigint NOT NULL,
    "P1_ERROR" text NULL,
    CONSTRAINT "PK_WF_GROUP_EXEC" PRIMARY KEY ("EXECUTION_ID", "STEP_GROUP")
);

CREATE TABLE "NeptuneDB"."WF_GROUP_EXEC_DONE" (
    "EXECUTION_ID" character varying(100) NOT NULL,
    "STEP_GROUP" integer NOT NULL,
    "P1_STATUS" character varying(100) NOT NULL,
    "P2_STATUS" character varying(100) NOT NULL,
    "P1_START" bigint NOT NULL,
    "P1_FINISH" bigint NOT NULL,
    "P1_ERROR" text NULL,
    CONSTRAINT "PK_WF_GROUP_EXEC_DONE" PRIMARY KEY ("EXECUTION_ID", "STEP_GROUP")
);

CREATE TABLE "NeptuneDB"."WF_STEP_DEF" (
    "WFID" character varying(100) NOT NULL,
    "STEP_ORDER" integer NOT NULL,
    "STEP_GROUP" integer NOT NULL,
    "STEP_CODE" character varying(100) NULL,
    "STATUS" character varying(100) NOT NULL,
    "DESCRIPTION" character varying(4000) NULL,
    "SERVICE_ID" character varying(100) NULL,
    "SENDING_TEMPLATE" text NULL,
    "SUCCESS_CONDITION" text NULL,
    "REQUEST_PROTOCOL" character varying(1000) NULL,
    "REQUEST_SERVER_IP" character varying(100) NULL,
    "REQUEST_SERVER_PORT" character varying(100) NULL,
    "REQUEST_URI" character varying(100) NULL,
    "SEND_BY_BROKER" character varying(100) NOT NULL,
    "STEP_TIMEOUT" character varying(100) NULL,
    "STEP_MODE" character varying(20) NOT NULL,
    "BASE64_ICON" text NULL,
    "SENDING_CONDITION" text NULL,
    "ON_COMPENSATING" character varying(100) NOT NULL,
    CONSTRAINT "PK_WF_STEP_DEF" PRIMARY KEY ("WFID", "STEP_ORDER")
);

CREATE TABLE "NeptuneDB"."WF_STEP_EXEC" (
    "STEP_EXECUTION_ID" character varying(100) NOT NULL,
    "EXECUTION_ID" character varying(100) NOT NULL,
    "WORKFLOW_ID" character varying(100) NULL,
    "STEP_GROUP" integer NOT NULL,
    "STEP_ORDER" integer NOT NULL,
    "STEP_CODE" character varying(100) NULL,
    "P1_REQUEST_ID" character varying(100) NULL,
    "P1_START" bigint NOT NULL,
    "P1_FINISH" bigint NOT NULL,
    "P1_STATUS" character varying(100) NOT NULL,
    "P1_ERROR" text NOT NULL,
    "P1_CONTENT" text NOT NULL,
    "P2_REQUEST_ID" character varying(100) NULL,
    "P2_START" bigint NOT NULL,
    "P2_FINISH" bigint NOT NULL,
    "P2_STATUS" character varying(100) NOT NULL,
    "P2_RESPONSE_STATUS" character varying(100) NULL,
    "P2_ERROR" text NULL,
    "P2_CONTENT" text NULL,
    "IS_SUCCESS" character varying(100) NOT NULL,
    "IS_TIMEOUT" character varying(100) NOT NULL,
    "P3_START" bigint NOT NULL,
    "P3_FINISH" bigint NOT NULL,
    "P3_STATUS" character varying(100) NOT NULL,
    "P3_CONTENT" text NULL,
    "P3_ERROR" text NULL,
    "SENDING_CONDITION" text NULL,
    "P4_STATUS" text NOT NULL,
    "IS_DISPUTED" text NOT NULL,
    "P4_CONTENT" text NULL,
    CONSTRAINT "PK_WF_STEP_EXEC" PRIMARY KEY ("STEP_EXECUTION_ID")
);

CREATE TABLE "NeptuneDB"."WF_STEP_EXEC_DONE" (
    "STEP_EXECUTION_ID" character varying(100) NOT NULL,
    "EXECUTION_ID" character varying(100) NOT NULL,
    "WORKFLOW_ID" character varying(100) NULL,
    "STEP_GROUP" integer NOT NULL,
    "STEP_ORDER" integer NOT NULL,
    "STEP_CODE" character varying(100) NULL,
    "P1_REQUEST_ID" character varying(100) NULL,
    "P1_START" bigint NOT NULL,
    "P1_FINISH" bigint NOT NULL,
    "P1_STATUS" character varying(100) NOT NULL,
    "P1_ERROR" text NOT NULL,
    "P1_CONTENT" text NOT NULL,
    "P2_REQUEST_ID" character varying(100) NULL,
    "P2_START" bigint NOT NULL,
    "P2_FINISH" bigint NOT NULL,
    "P2_STATUS" character varying(100) NOT NULL,
    "P2_RESPONSE_STATUS" character varying(100) NULL,
    "P2_ERROR" text NULL,
    "P2_CONTENT" text NULL,
    "IS_SUCCESS" character varying(100) NOT NULL,
    "IS_TIMEOUT" character varying(100) NOT NULL,
    "P3_START" bigint NOT NULL,
    "P3_FINISH" bigint NOT NULL,
    "P3_STATUS" character varying(100) NOT NULL,
    "P3_CONTENT" text NULL,
    "P3_ERROR" text NULL,
    "SENDING_CONDITION" text NULL,
    "P4_STATUS" text NOT NULL,
    "IS_DISPUTED" text NOT NULL,
    "P4_CONTENT" text NULL,
    CONSTRAINT "PK_WF_STEP_EXEC_DONE" PRIMARY KEY ("STEP_EXECUTION_ID")
);

CREATE UNIQUE INDEX "IX_AUTH_ORGANIZATION_OrganizationCode" ON "NeptuneDB"."AUTH_ORGANIZATION" ("OrganizationCode");

CREATE UNIQUE INDEX "IX_AUTH_ROLE_RoleCode" ON "NeptuneDB"."AUTH_ROLE" ("RoleCode");

CREATE UNIQUE INDEX "IX_AUTH_USER_UserCode" ON "NeptuneDB"."AUTH_USER" ("UserCode");

CREATE INDEX "IX_INSTANCE_SERVICE_ID" ON "NeptuneDB"."INSTANCE" ("SERVICE_ID");

CREATE INDEX "IX_JWT_token" ON "NeptuneDB"."JWT" (token);

CREATE UNIQUE INDEX "IX_LANGUAGE_RESOURCE_RESOURCE_CODE" ON "NeptuneDB"."LANGUAGE_RESOURCE" ("RESOURCE_CODE");

CREATE INDEX "IX_LOG_API_LOGIN_ORGANIZATION_ID" ON "NeptuneDB"."LOG_API" ("LOGIN_ORGANIZATION_ID");

CREATE INDEX "IX_LOG_API_LOGIN_USER_ID" ON "NeptuneDB"."LOG_API" ("LOGIN_USER_ID");

CREATE INDEX "IX_LOG_API_RESPONSE_STATUS" ON "NeptuneDB"."LOG_API" ("RESPONSE_STATUS");

CREATE INDEX "IX_LOG_API_UTC_TIME" ON "NeptuneDB"."LOG_API" ("UTC_TIME");

CREATE INDEX "IX_LOG_EVENT_UTC_TIME" ON "NeptuneDB"."LOG_EVENT" ("UTC_TIME");

CREATE INDEX "IX_LOG_GRPC_INSTANCE_ID" ON "NeptuneDB"."LOG_GRPC" ("INSTANCE_ID");

CREATE INDEX "IX_LOG_GRPC_RUNNING_ID" ON "NeptuneDB"."LOG_GRPC" ("RUNNING_ID");

CREATE INDEX "IX_LOG_GRPC_SERVER_TIME" ON "NeptuneDB"."LOG_GRPC" ("SERVER_TIME");

CREATE UNIQUE INDEX "IX_SERVICE_DEF_SERVICE_CODE" ON "NeptuneDB"."SERVICE_DEF" ("SERVICE_CODE");

CREATE UNIQUE INDEX "IX_WF_DEF_Code" ON "NeptuneDB"."WF_DEF" ("Code");

CREATE INDEX "IX_WF_EXEC_ARCHIVING_TIME" ON "NeptuneDB"."WF_EXEC" ("ARCHIVING_TIME");

CREATE INDEX "IX_WF_EXEC_CREATED_ON" ON "NeptuneDB"."WF_EXEC" ("CREATED_ON");

CREATE INDEX "IX_WF_EXEC_FINISH_ON" ON "NeptuneDB"."WF_EXEC" ("FINISH_ON");

CREATE INDEX "IX_WF_EXEC_IS_DISPUTED" ON "NeptuneDB"."WF_EXEC" ("IS_DISPUTED");

CREATE INDEX "IX_WF_EXEC_IS_SUCCESS" ON "NeptuneDB"."WF_EXEC" ("IS_SUCCESS");

CREATE INDEX "IX_WF_EXEC_IS_TIMEOUT" ON "NeptuneDB"."WF_EXEC" ("IS_TIMEOUT");

CREATE INDEX "IX_WF_EXEC_ORGANIZATION_ID" ON "NeptuneDB"."WF_EXEC" ("ORGANIZATION_ID");

CREATE INDEX "IX_WF_EXEC_PURGING_TIME" ON "NeptuneDB"."WF_EXEC" ("PURGING_TIME");

CREATE INDEX "IX_WF_EXEC_STATUS" ON "NeptuneDB"."WF_EXEC" ("STATUS");

CREATE INDEX "IX_WF_EXEC_USER_ID" ON "NeptuneDB"."WF_EXEC" ("USER_ID");

CREATE INDEX "IX_WF_EXEC_WFID" ON "NeptuneDB"."WF_EXEC" ("WFID");

CREATE INDEX "IX_WF_EXEC_WORKFLOW_TYPE" ON "NeptuneDB"."WF_EXEC" ("WORKFLOW_TYPE");

CREATE INDEX "IX_WF_EXEC_DONE_ARCHIVING_TIME" ON "NeptuneDB"."WF_EXEC_DONE" ("ARCHIVING_TIME");

CREATE INDEX "IX_WF_EXEC_DONE_CREATED_ON" ON "NeptuneDB"."WF_EXEC_DONE" ("CREATED_ON");

CREATE INDEX "IX_WF_EXEC_DONE_FINISH_ON" ON "NeptuneDB"."WF_EXEC_DONE" ("FINISH_ON");

CREATE INDEX "IX_WF_EXEC_DONE_IS_DISPUTED" ON "NeptuneDB"."WF_EXEC_DONE" ("IS_DISPUTED");

CREATE INDEX "IX_WF_EXEC_DONE_IS_SUCCESS" ON "NeptuneDB"."WF_EXEC_DONE" ("IS_SUCCESS");

CREATE INDEX "IX_WF_EXEC_DONE_IS_TIMEOUT" ON "NeptuneDB"."WF_EXEC_DONE" ("IS_TIMEOUT");

CREATE INDEX "IX_WF_EXEC_DONE_ORGANIZATION_ID" ON "NeptuneDB"."WF_EXEC_DONE" ("ORGANIZATION_ID");

CREATE INDEX "IX_WF_EXEC_DONE_PURGING_TIME" ON "NeptuneDB"."WF_EXEC_DONE" ("PURGING_TIME");

CREATE INDEX "IX_WF_EXEC_DONE_STATUS" ON "NeptuneDB"."WF_EXEC_DONE" ("STATUS");

CREATE INDEX "IX_WF_EXEC_DONE_USER_ID" ON "NeptuneDB"."WF_EXEC_DONE" ("USER_ID");

CREATE INDEX "IX_WF_EXEC_DONE_WFID" ON "NeptuneDB"."WF_EXEC_DONE" ("WFID");

CREATE INDEX "IX_WF_EXEC_DONE_WORKFLOW_TYPE" ON "NeptuneDB"."WF_EXEC_DONE" ("WORKFLOW_TYPE");

CREATE INDEX "IX_WF_STEP_EXEC_EXECUTION_ID" ON "NeptuneDB"."WF_STEP_EXEC" ("EXECUTION_ID");

CREATE INDEX "IX_WF_STEP_EXEC_IS_DISPUTED" ON "NeptuneDB"."WF_STEP_EXEC" ("IS_DISPUTED");

CREATE INDEX "IX_WF_STEP_EXEC_IS_SUCCESS" ON "NeptuneDB"."WF_STEP_EXEC" ("IS_SUCCESS");

CREATE INDEX "IX_WF_STEP_EXEC_IS_TIMEOUT" ON "NeptuneDB"."WF_STEP_EXEC" ("IS_TIMEOUT");

CREATE INDEX "IX_WF_STEP_EXEC_P1_FINISH" ON "NeptuneDB"."WF_STEP_EXEC" ("P1_FINISH");

CREATE INDEX "IX_WF_STEP_EXEC_P1_START" ON "NeptuneDB"."WF_STEP_EXEC" ("P1_START");

CREATE INDEX "IX_WF_STEP_EXEC_P1_STATUS" ON "NeptuneDB"."WF_STEP_EXEC" ("P1_STATUS");

CREATE INDEX "IX_WF_STEP_EXEC_P2_FINISH" ON "NeptuneDB"."WF_STEP_EXEC" ("P2_FINISH");

CREATE INDEX "IX_WF_STEP_EXEC_P2_START" ON "NeptuneDB"."WF_STEP_EXEC" ("P2_START");

CREATE INDEX "IX_WF_STEP_EXEC_P2_STATUS" ON "NeptuneDB"."WF_STEP_EXEC" ("P2_STATUS");

CREATE INDEX "IX_WF_STEP_EXEC_P3_FINISH" ON "NeptuneDB"."WF_STEP_EXEC" ("P3_FINISH");

CREATE INDEX "IX_WF_STEP_EXEC_P3_START" ON "NeptuneDB"."WF_STEP_EXEC" ("P3_START");

CREATE INDEX "IX_WF_STEP_EXEC_P3_STATUS" ON "NeptuneDB"."WF_STEP_EXEC" ("P3_STATUS");

CREATE INDEX "IX_WF_STEP_EXEC_STEP_CODE" ON "NeptuneDB"."WF_STEP_EXEC" ("STEP_CODE");

CREATE INDEX "IX_WF_STEP_EXEC_WORKFLOW_ID" ON "NeptuneDB"."WF_STEP_EXEC" ("WORKFLOW_ID");

CREATE INDEX "IX_WF_STEP_EXEC_DONE_EXECUTION_ID" ON "NeptuneDB"."WF_STEP_EXEC_DONE" ("EXECUTION_ID");

CREATE INDEX "IX_WF_STEP_EXEC_DONE_IS_DISPUTED" ON "NeptuneDB"."WF_STEP_EXEC_DONE" ("IS_DISPUTED");

CREATE INDEX "IX_WF_STEP_EXEC_DONE_IS_SUCCESS" ON "NeptuneDB"."WF_STEP_EXEC_DONE" ("IS_SUCCESS");

CREATE INDEX "IX_WF_STEP_EXEC_DONE_IS_TIMEOUT" ON "NeptuneDB"."WF_STEP_EXEC_DONE" ("IS_TIMEOUT");

CREATE INDEX "IX_WF_STEP_EXEC_DONE_P1_FINISH" ON "NeptuneDB"."WF_STEP_EXEC_DONE" ("P1_FINISH");

CREATE INDEX "IX_WF_STEP_EXEC_DONE_P1_START" ON "NeptuneDB"."WF_STEP_EXEC_DONE" ("P1_START");

CREATE INDEX "IX_WF_STEP_EXEC_DONE_P1_STATUS" ON "NeptuneDB"."WF_STEP_EXEC_DONE" ("P1_STATUS");

CREATE INDEX "IX_WF_STEP_EXEC_DONE_P2_FINISH" ON "NeptuneDB"."WF_STEP_EXEC_DONE" ("P2_FINISH");

CREATE INDEX "IX_WF_STEP_EXEC_DONE_P2_START" ON "NeptuneDB"."WF_STEP_EXEC_DONE" ("P2_START");

CREATE INDEX "IX_WF_STEP_EXEC_DONE_P2_STATUS" ON "NeptuneDB"."WF_STEP_EXEC_DONE" ("P2_STATUS");

CREATE INDEX "IX_WF_STEP_EXEC_DONE_P3_FINISH" ON "NeptuneDB"."WF_STEP_EXEC_DONE" ("P3_FINISH");

CREATE INDEX "IX_WF_STEP_EXEC_DONE_P3_START" ON "NeptuneDB"."WF_STEP_EXEC_DONE" ("P3_START");

CREATE INDEX "IX_WF_STEP_EXEC_DONE_P3_STATUS" ON "NeptuneDB"."WF_STEP_EXEC_DONE" ("P3_STATUS");

CREATE INDEX "IX_WF_STEP_EXEC_DONE_STEP_CODE" ON "NeptuneDB"."WF_STEP_EXEC_DONE" ("STEP_CODE");

CREATE INDEX "IX_WF_STEP_EXEC_DONE_WORKFLOW_ID" ON "NeptuneDB"."WF_STEP_EXEC_DONE" ("WORKFLOW_ID");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20221031010855_v1', '6.0.10');

COMMIT;


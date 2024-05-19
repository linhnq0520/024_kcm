## 1. Modify settings.json (src/ShareFiles/{service-name}/settings.json)
Example:
```json
...
"ConnectionStrings": {
      "ConnectionString": "host=neptune_postgresql;database=o9admin;user id=o9admin;password=o9admin;port=5432",
      "DataProvider": "postgresql",
      "SQLCommandTimeout": null
    }
...
```
## 2. Deploy Portainer/Phpmyadmin/NeptuneServer
At Directory `src/ShareFiles` run:
```
docker compose -f ./docker-compose.postgresql.yml up -d --build portainer
docker compose -f ./docker-compose.postgresql.yml up -d --build phppgadmin
docker compose -f ./docker-compose.postgresql.yml up -d --build neptunedb_postgresql
```
## 3. Create User and Database
```sql
DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM pg_namespace WHERE nspname = 'neptune') THEN
        CREATE SCHEMA "neptune";
    END IF;
END $EF$;
CREATE USER neptune WITH PASSWORD 'neptune';
GRANT ALL  PRIVILEGES ON DATABASE postgres TO neptune;
GRANT ALL ON ALL TABLES IN SCHEMA neptune TO neptune ;
GRANT ALL ON ALL FUNCTIONS IN SCHEMA neptune TO neptune ;
GRANT usage ON SCHEMA neptune TO neptune ;

CREATE USER o9accounting WITH PASSWORD 'o9accounting';
CREATE DATABASE o9accounting
    WITH
    OWNER = o9accounting
    ENCODING = 'UTF8'
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;

CREATE USER o9admin WITH PASSWORD 'o9admin';
CREATE DATABASE o9admin
    WITH
    OWNER = o9admin
    ENCODING = 'UTF8'
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;

CREATE USER o9batch WITH PASSWORD 'o9batch';
CREATE DATABASE o9batch
    WITH
    OWNER = o9batch
    ENCODING = 'UTF8'
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;

CREATE USER o9cms WITH PASSWORD 'o9cms';
CREATE DATABASE o9cms
    WITH
    OWNER = o9cms
    ENCODING = 'UTF8'
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;

CREATE USER o9cash WITH PASSWORD 'o9cash';
CREATE DATABASE o9cash
    WITH
    OWNER = o9cash
    ENCODING = 'UTF8'
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;

CREATE USER o9credit WITH PASSWORD 'o9credit';
CREATE DATABASE o9credit
    WITH
    OWNER = o9credit
    ENCODING = 'UTF8'
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;

CREATE USER o9customer WITH PASSWORD 'o9customer';
CREATE DATABASE o9customer
    WITH
    OWNER = o9customer
    ENCODING = 'UTF8'
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;

CREATE USER o9deposit WITH PASSWORD 'o9deposit';
CREATE DATABASE o9deposit
    WITH
    OWNER = o9deposit
    ENCODING = 'UTF8'
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;

CREATE USER o9fx WITH PASSWORD 'o9fx';
CREATE DATABASE o9fx
    WITH
    OWNER = o9fx
    ENCODING = 'UTF8'
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;

CREATE USER o9fixedasset WITH PASSWORD 'o9fixedasset';
CREATE DATABASE o9fixedasset
    WITH
    OWNER = o9fixedasset
    ENCODING = 'UTF8'
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;

CREATE USER o9ifc WITH PASSWORD 'o9ifc';
CREATE DATABASE o9ifc
    WITH
    OWNER = o9ifc
    ENCODING = 'UTF8'
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;

CREATE USER o9mortgage WITH PASSWORD 'o9mortgage';
CREATE DATABASE o9mortgage
    WITH
    OWNER = o9mortgage
    ENCODING = 'UTF8'
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;

CREATE USER o9payment WITH PASSWORD 'o9payment';
CREATE DATABASE o9payment
    WITH
    OWNER = o9payment
    ENCODING = 'UTF8'
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;

CREATE USER o9voucher WITH PASSWORD 'o9voucher';
CREATE DATABASE o9voucher
    WITH
    OWNER = o9voucher
    ENCODING = 'UTF8'
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;

CREATE USER o9report WITH PASSWORD 'o9report';
CREATE DATABASE o9report
    WITH
    OWNER = o9report
    ENCODING = 'UTF8'
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;
```

## 4. Import structure database `neptune`
```sql
CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM pg_namespace WHERE nspname = 'neptune') THEN
        CREATE SCHEMA "neptune";
    END IF;
END $EF$;

CREATE TABLE "neptune"."AUTH_ORGANIZATION" (
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

CREATE TABLE "neptune"."AUTH_ROLE" (
    "RoleID" character varying(100) NOT NULL,
    "RoleCode" character varying(100) NOT NULL,
    "RoleName" character varying(500) NOT NULL,
    CONSTRAINT "PK_AUTH_ROLE" PRIMARY KEY ("RoleID")
);

CREATE TABLE "neptune"."AUTH_ROLE_USER" (
    "RoleID" character varying(100) NOT NULL,
    "UserID" character varying(100) NOT NULL,
    CONSTRAINT "PK_AUTH_ROLE_USER" PRIMARY KEY ("RoleID", "UserID")
);

CREATE TABLE "neptune"."AUTH_ROLE_WF" (
    "RoleID" character varying(100) NOT NULL,
    "WorflowID" character varying(100) NOT NULL,
    CONSTRAINT "PK_AUTH_ROLE_WF" PRIMARY KEY ("RoleID", "WorflowID")
);

CREATE TABLE "neptune"."AUTH_USER" (
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

CREATE TABLE "neptune"."CONFIGURATION" (
    "PARA_CODE" character varying(500) NOT NULL,
    "PARA_VALUE" character varying(4000) NULL,
    CONSTRAINT "PK_CONFIGURATION" PRIMARY KEY ("PARA_CODE")
);

CREATE TABLE "neptune"."ENVIRONMENT_VARIABLE" (
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

CREATE TABLE "neptune"."EVENT_DEF" (
    "EVENT_NAME" character varying(500) NOT NULL,
    "STATUS" character varying(50) NOT NULL,
    "TYPE" character varying(50) NOT NULL,
    "DESCRIPTION" character varying(500) NULL,
    CONSTRAINT "PK_EVENT_DEF" PRIMARY KEY ("EVENT_NAME")
);

CREATE TABLE "neptune"."INSTANCE" (
    "INSTANCE_ID" character varying(50) NOT NULL,
    "GRPC_URL" character varying(500) NOT NULL,
    "UTC_TIME" bigint NOT NULL,
    "UTC_EXP_TIME" bigint NOT NULL,
    "SERVICE_ID" character varying(100) NULL,
    "EVENT_QUEUE_NAME" character varying(500) NULL,
    "COMMAND_QUEUE_NAME" character varying(500) NULL,
    CONSTRAINT "PK_INSTANCE" PRIMARY KEY ("INSTANCE_ID")
);

CREATE TABLE "neptune"."JWT" (
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

CREATE TABLE "neptune"."JWT_STATIC" (
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

CREATE TABLE "neptune"."LANGUAGE_RESOURCE" (
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

CREATE TABLE "neptune"."LOG_API" (
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

CREATE TABLE "neptune"."LOG_EVENT" (
    "EVENT_ID" character varying(50) NOT NULL,
    "INSTANCE_ID" character varying(500) NOT NULL,
    "RUNNING_ID" character varying(500) NOT NULL,
    "EVENT_TYPE" character varying(100) NOT NULL,
    "UTC_TIME" bigint NOT NULL,
    "DESCS" text NOT NULL,
    "EVENT_DATA" text NULL,
    CONSTRAINT "PK_LOG_EVENT" PRIMARY KEY ("EVENT_ID")
);

CREATE TABLE "neptune"."LOG_GRPC" (
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

CREATE TABLE "neptune"."LOG_HTTP_REQUEST" (
    "REQUEST_ID" character varying(100) NOT NULL,
    "TIME_IN" bigint NOT NULL,
    "TIME_OUT" bigint NOT NULL,
    "DATA" text NULL,
    CONSTRAINT "PK_LOG_HTTP_REQUEST" PRIMARY KEY ("REQUEST_ID")
);

CREATE TABLE "neptune"."LOG_INCOMING_QUEUE_MESSAGE" (
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

CREATE TABLE "neptune"."LOG_RECEIVING_HTTP" (
    "HTTP_ID" character varying(100) NOT NULL,
    "TIME_START" bigint NOT NULL,
    "TIME_FINISH" bigint NOT NULL,
    "RECEIVING_DATA" text NULL,
    "SENDING_DATA" text NULL,
    "ERROR_DATA" text NULL,
    CONSTRAINT "PK_LOG_RECEIVING_HTTP" PRIMARY KEY ("HTTP_ID")
);

CREATE TABLE "neptune"."SENDING_HTTP" (
    "HTTP_ID" character varying(100) NOT NULL,
    "TIME_START" bigint NOT NULL,
    "TIME_FINISH" bigint NOT NULL,
    "SENDING_DATA" text NULL,
    "RECEIVING_DATA" text NULL,
    "ERROR_DATA" text NULL,
    CONSTRAINT "PK_SENDING_HTTP" PRIMARY KEY ("HTTP_ID")
);

CREATE TABLE "neptune"."SERVICE_DEF" (
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

CREATE TABLE "neptune"."WF_DEF" (
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

CREATE TABLE "neptune"."WF_EXEC" (
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

CREATE TABLE "neptune"."WF_EXEC_DONE" (
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

CREATE TABLE "neptune"."WF_FIELD" (
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

CREATE TABLE "neptune"."WF_GROUP_EXEC" (
    "EXECUTION_ID" character varying(100) NOT NULL,
    "STEP_GROUP" integer NOT NULL,
    "P1_STATUS" character varying(100) NOT NULL,
    "P2_STATUS" character varying(100) NOT NULL,
    "P1_START" bigint NOT NULL,
    "P1_FINISH" bigint NOT NULL,
    "P1_ERROR" text NULL,
    CONSTRAINT "PK_WF_GROUP_EXEC" PRIMARY KEY ("EXECUTION_ID", "STEP_GROUP")
);

CREATE TABLE "neptune"."WF_GROUP_EXEC_DONE" (
    "EXECUTION_ID" character varying(100) NOT NULL,
    "STEP_GROUP" integer NOT NULL,
    "P1_STATUS" character varying(100) NOT NULL,
    "P2_STATUS" character varying(100) NOT NULL,
    "P1_START" bigint NOT NULL,
    "P1_FINISH" bigint NOT NULL,
    "P1_ERROR" text NULL,
    CONSTRAINT "PK_WF_GROUP_EXEC_DONE" PRIMARY KEY ("EXECUTION_ID", "STEP_GROUP")
);

CREATE TABLE "neptune"."WF_STEP_DEF" (
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

CREATE TABLE "neptune"."WF_STEP_EXEC" (
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

CREATE TABLE "neptune"."WF_STEP_EXEC_DONE" (
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

CREATE UNIQUE INDEX "IX_AUTH_ORGANIZATION_OrganizationCode" ON "neptune"."AUTH_ORGANIZATION" ("OrganizationCode");

CREATE UNIQUE INDEX "IX_AUTH_ROLE_RoleCode" ON "neptune"."AUTH_ROLE" ("RoleCode");

CREATE UNIQUE INDEX "IX_AUTH_USER_UserCode" ON "neptune"."AUTH_USER" ("UserCode");

CREATE INDEX "IX_INSTANCE_SERVICE_ID" ON "neptune"."INSTANCE" ("SERVICE_ID");

CREATE INDEX "IX_JWT_token" ON "neptune"."JWT" (token);

CREATE UNIQUE INDEX "IX_LANGUAGE_RESOURCE_RESOURCE_CODE" ON "neptune"."LANGUAGE_RESOURCE" ("RESOURCE_CODE");

CREATE INDEX "IX_LOG_API_LOGIN_ORGANIZATION_ID" ON "neptune"."LOG_API" ("LOGIN_ORGANIZATION_ID");

CREATE INDEX "IX_LOG_API_LOGIN_USER_ID" ON "neptune"."LOG_API" ("LOGIN_USER_ID");

CREATE INDEX "IX_LOG_API_RESPONSE_STATUS" ON "neptune"."LOG_API" ("RESPONSE_STATUS");

CREATE INDEX "IX_LOG_API_UTC_TIME" ON "neptune"."LOG_API" ("UTC_TIME");

CREATE INDEX "IX_LOG_EVENT_UTC_TIME" ON "neptune"."LOG_EVENT" ("UTC_TIME");

CREATE INDEX "IX_LOG_GRPC_INSTANCE_ID" ON "neptune"."LOG_GRPC" ("INSTANCE_ID");

CREATE INDEX "IX_LOG_GRPC_RUNNING_ID" ON "neptune"."LOG_GRPC" ("RUNNING_ID");

CREATE INDEX "IX_LOG_GRPC_SERVER_TIME" ON "neptune"."LOG_GRPC" ("SERVER_TIME");

CREATE UNIQUE INDEX "IX_SERVICE_DEF_SERVICE_CODE" ON "neptune"."SERVICE_DEF" ("SERVICE_CODE");

CREATE UNIQUE INDEX "IX_WF_DEF_Code" ON "neptune"."WF_DEF" ("Code");

CREATE INDEX "IX_WF_EXEC_ARCHIVING_TIME" ON "neptune"."WF_EXEC" ("ARCHIVING_TIME");

CREATE INDEX "IX_WF_EXEC_CREATED_ON" ON "neptune"."WF_EXEC" ("CREATED_ON");

CREATE INDEX "IX_WF_EXEC_FINISH_ON" ON "neptune"."WF_EXEC" ("FINISH_ON");

CREATE INDEX "IX_WF_EXEC_IS_DISPUTED" ON "neptune"."WF_EXEC" ("IS_DISPUTED");

CREATE INDEX "IX_WF_EXEC_IS_SUCCESS" ON "neptune"."WF_EXEC" ("IS_SUCCESS");

CREATE INDEX "IX_WF_EXEC_IS_TIMEOUT" ON "neptune"."WF_EXEC" ("IS_TIMEOUT");

CREATE INDEX "IX_WF_EXEC_ORGANIZATION_ID" ON "neptune"."WF_EXEC" ("ORGANIZATION_ID");

CREATE INDEX "IX_WF_EXEC_PURGING_TIME" ON "neptune"."WF_EXEC" ("PURGING_TIME");

CREATE INDEX "IX_WF_EXEC_STATUS" ON "neptune"."WF_EXEC" ("STATUS");

CREATE INDEX "IX_WF_EXEC_USER_ID" ON "neptune"."WF_EXEC" ("USER_ID");

CREATE INDEX "IX_WF_EXEC_WFID" ON "neptune"."WF_EXEC" ("WFID");

CREATE INDEX "IX_WF_EXEC_WORKFLOW_TYPE" ON "neptune"."WF_EXEC" ("WORKFLOW_TYPE");

CREATE INDEX "IX_WF_EXEC_DONE_ARCHIVING_TIME" ON "neptune"."WF_EXEC_DONE" ("ARCHIVING_TIME");

CREATE INDEX "IX_WF_EXEC_DONE_CREATED_ON" ON "neptune"."WF_EXEC_DONE" ("CREATED_ON");

CREATE INDEX "IX_WF_EXEC_DONE_FINISH_ON" ON "neptune"."WF_EXEC_DONE" ("FINISH_ON");

CREATE INDEX "IX_WF_EXEC_DONE_IS_DISPUTED" ON "neptune"."WF_EXEC_DONE" ("IS_DISPUTED");

CREATE INDEX "IX_WF_EXEC_DONE_IS_SUCCESS" ON "neptune"."WF_EXEC_DONE" ("IS_SUCCESS");

CREATE INDEX "IX_WF_EXEC_DONE_IS_TIMEOUT" ON "neptune"."WF_EXEC_DONE" ("IS_TIMEOUT");

CREATE INDEX "IX_WF_EXEC_DONE_ORGANIZATION_ID" ON "neptune"."WF_EXEC_DONE" ("ORGANIZATION_ID");

CREATE INDEX "IX_WF_EXEC_DONE_PURGING_TIME" ON "neptune"."WF_EXEC_DONE" ("PURGING_TIME");

CREATE INDEX "IX_WF_EXEC_DONE_STATUS" ON "neptune"."WF_EXEC_DONE" ("STATUS");

CREATE INDEX "IX_WF_EXEC_DONE_USER_ID" ON "neptune"."WF_EXEC_DONE" ("USER_ID");

CREATE INDEX "IX_WF_EXEC_DONE_WFID" ON "neptune"."WF_EXEC_DONE" ("WFID");

CREATE INDEX "IX_WF_EXEC_DONE_WORKFLOW_TYPE" ON "neptune"."WF_EXEC_DONE" ("WORKFLOW_TYPE");

CREATE INDEX "IX_WF_STEP_EXEC_EXECUTION_ID" ON "neptune"."WF_STEP_EXEC" ("EXECUTION_ID");

CREATE INDEX "IX_WF_STEP_EXEC_IS_DISPUTED" ON "neptune"."WF_STEP_EXEC" ("IS_DISPUTED");

CREATE INDEX "IX_WF_STEP_EXEC_IS_SUCCESS" ON "neptune"."WF_STEP_EXEC" ("IS_SUCCESS");

CREATE INDEX "IX_WF_STEP_EXEC_IS_TIMEOUT" ON "neptune"."WF_STEP_EXEC" ("IS_TIMEOUT");

CREATE INDEX "IX_WF_STEP_EXEC_P1_FINISH" ON "neptune"."WF_STEP_EXEC" ("P1_FINISH");

CREATE INDEX "IX_WF_STEP_EXEC_P1_START" ON "neptune"."WF_STEP_EXEC" ("P1_START");

CREATE INDEX "IX_WF_STEP_EXEC_P1_STATUS" ON "neptune"."WF_STEP_EXEC" ("P1_STATUS");

CREATE INDEX "IX_WF_STEP_EXEC_P2_FINISH" ON "neptune"."WF_STEP_EXEC" ("P2_FINISH");

CREATE INDEX "IX_WF_STEP_EXEC_P2_START" ON "neptune"."WF_STEP_EXEC" ("P2_START");

CREATE INDEX "IX_WF_STEP_EXEC_P2_STATUS" ON "neptune"."WF_STEP_EXEC" ("P2_STATUS");

CREATE INDEX "IX_WF_STEP_EXEC_P3_FINISH" ON "neptune"."WF_STEP_EXEC" ("P3_FINISH");

CREATE INDEX "IX_WF_STEP_EXEC_P3_START" ON "neptune"."WF_STEP_EXEC" ("P3_START");

CREATE INDEX "IX_WF_STEP_EXEC_P3_STATUS" ON "neptune"."WF_STEP_EXEC" ("P3_STATUS");

CREATE INDEX "IX_WF_STEP_EXEC_STEP_CODE" ON "neptune"."WF_STEP_EXEC" ("STEP_CODE");

CREATE INDEX "IX_WF_STEP_EXEC_WORKFLOW_ID" ON "neptune"."WF_STEP_EXEC" ("WORKFLOW_ID");

CREATE INDEX "IX_WF_STEP_EXEC_DONE_EXECUTION_ID" ON "neptune"."WF_STEP_EXEC_DONE" ("EXECUTION_ID");

CREATE INDEX "IX_WF_STEP_EXEC_DONE_IS_DISPUTED" ON "neptune"."WF_STEP_EXEC_DONE" ("IS_DISPUTED");

CREATE INDEX "IX_WF_STEP_EXEC_DONE_IS_SUCCESS" ON "neptune"."WF_STEP_EXEC_DONE" ("IS_SUCCESS");

CREATE INDEX "IX_WF_STEP_EXEC_DONE_IS_TIMEOUT" ON "neptune"."WF_STEP_EXEC_DONE" ("IS_TIMEOUT");

CREATE INDEX "IX_WF_STEP_EXEC_DONE_P1_FINISH" ON "neptune"."WF_STEP_EXEC_DONE" ("P1_FINISH");

CREATE INDEX "IX_WF_STEP_EXEC_DONE_P1_START" ON "neptune"."WF_STEP_EXEC_DONE" ("P1_START");

CREATE INDEX "IX_WF_STEP_EXEC_DONE_P1_STATUS" ON "neptune"."WF_STEP_EXEC_DONE" ("P1_STATUS");

CREATE INDEX "IX_WF_STEP_EXEC_DONE_P2_FINISH" ON "neptune"."WF_STEP_EXEC_DONE" ("P2_FINISH");

CREATE INDEX "IX_WF_STEP_EXEC_DONE_P2_START" ON "neptune"."WF_STEP_EXEC_DONE" ("P2_START");

CREATE INDEX "IX_WF_STEP_EXEC_DONE_P2_STATUS" ON "neptune"."WF_STEP_EXEC_DONE" ("P2_STATUS");

CREATE INDEX "IX_WF_STEP_EXEC_DONE_P3_FINISH" ON "neptune"."WF_STEP_EXEC_DONE" ("P3_FINISH");

CREATE INDEX "IX_WF_STEP_EXEC_DONE_P3_START" ON "neptune"."WF_STEP_EXEC_DONE" ("P3_START");

CREATE INDEX "IX_WF_STEP_EXEC_DONE_P3_STATUS" ON "neptune"."WF_STEP_EXEC_DONE" ("P3_STATUS");

CREATE INDEX "IX_WF_STEP_EXEC_DONE_STEP_CODE" ON "neptune"."WF_STEP_EXEC_DONE" ("STEP_CODE");

CREATE INDEX "IX_WF_STEP_EXEC_DONE_WORKFLOW_ID" ON "neptune"."WF_STEP_EXEC_DONE" ("WORKFLOW_ID");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20221031010855_v1', '6.0.10');

COMMIT;

```
## 5. Insert data `neptune`
```sql
UPDATE "ENVIRONMENT_VARIABLE" SET "E1" = 'rabbitmq' WHERE "ENVIRONMENT_VARIABLE"."VARIABLE_NAME" = 'MESSAGE_BROKER_HOSTNAME';
UPDATE "ENVIRONMENT_VARIABLE" SET "E1" = 'guest' WHERE "ENVIRONMENT_VARIABLE"."VARIABLE_NAME" = 'MESSAGE_BROKER_USERNAME';
UPDATE "ENVIRONMENT_VARIABLE" SET "E1" = 'guest' WHERE "ENVIRONMENT_VARIABLE"."VARIABLE_NAME" = 'MESSAGE_BROKER_PASSWORD';

DELETE FROM "SERVICE_DEF" WHERE "SERVICE_CODE" IN ('ADM', 'ACT', 'CSH', 'CRD', 'CTM', 'DPT', 'IFC', 'FX', 'FAC', 'PMT', 'MTG', 'BCH', 'CMS', 'SPL', 'VCH');

INSERT INTO "SERVICE_DEF" ("SERVICE_ID", "SERVICE_CODE", "SERVICE_NAME", "STATUS", "QUEUE_NAME", "ACCEPT_TIME", "GRPC_URL", "GRPC_STATUS", "GRPC_TIMEOUT", "EVENT_REGISTRATION", "IMPORT_EXPORT_STEP_CODE", "CONCURRENT_THREADS", "SERVICE_INSTANCE_TYPE") VALUES ('ACT', 'ACT', 'Accounting service', 'Active', 'queue-act', '0', '', '0', '60', 'Mine', 'Yes', 8, 'Stateless');
INSERT INTO "SERVICE_DEF" ("SERVICE_ID", "SERVICE_CODE", "SERVICE_NAME", "STATUS", "QUEUE_NAME", "ACCEPT_TIME", "GRPC_URL", "GRPC_STATUS", "GRPC_TIMEOUT", "EVENT_REGISTRATION", "IMPORT_EXPORT_STEP_CODE", "CONCURRENT_THREADS", "SERVICE_INSTANCE_TYPE") VALUES ('ADM', 'ADM', 'Admin service', 'Active', 'queue-adm', '0', '', '0', '60', 'Always', 'Yes', 8, 'Stateless');
INSERT INTO "SERVICE_DEF" ("SERVICE_ID", "SERVICE_CODE", "SERVICE_NAME", "STATUS", "QUEUE_NAME", "ACCEPT_TIME", "GRPC_URL", "GRPC_STATUS", "GRPC_TIMEOUT", "EVENT_REGISTRATION", "IMPORT_EXPORT_STEP_CODE", "CONCURRENT_THREADS", "SERVICE_INSTANCE_TYPE") VALUES ('CSH', 'CSH', 'Cash service', 'Active', 'queue-csh', '0', '', '0', '60', 'Mine', 'Yes', 8, 'Stateless');
INSERT INTO "SERVICE_DEF" ("SERVICE_ID", "SERVICE_CODE", "SERVICE_NAME", "STATUS", "QUEUE_NAME", "ACCEPT_TIME", "GRPC_URL", "GRPC_STATUS", "GRPC_TIMEOUT", "EVENT_REGISTRATION", "IMPORT_EXPORT_STEP_CODE", "CONCURRENT_THREADS", "SERVICE_INSTANCE_TYPE") VALUES ('CRD', 'CRD', 'Credit service', 'Active', 'queue-crd', '0', '', '0', '60', 'Mine', 'Yes', 8, 'Stateless');
INSERT INTO "SERVICE_DEF" ("SERVICE_ID", "SERVICE_CODE", "SERVICE_NAME", "STATUS", "QUEUE_NAME", "ACCEPT_TIME", "GRPC_URL", "GRPC_STATUS", "GRPC_TIMEOUT", "EVENT_REGISTRATION", "IMPORT_EXPORT_STEP_CODE", "CONCURRENT_THREADS", "SERVICE_INSTANCE_TYPE") VALUES ('CTM', 'CTM', 'Customer service', 'Active', 'queue-ctm', '0', '', '0', '60', 'Mine', 'Yes', 8, 'Stateless');
INSERT INTO "SERVICE_DEF" ("SERVICE_ID", "SERVICE_CODE", "SERVICE_NAME", "STATUS", "QUEUE_NAME", "ACCEPT_TIME", "GRPC_URL", "GRPC_STATUS", "GRPC_TIMEOUT", "EVENT_REGISTRATION", "IMPORT_EXPORT_STEP_CODE", "CONCURRENT_THREADS", "SERVICE_INSTANCE_TYPE") VALUES ('DPT', 'DPT', 'Deposit service', 'Active', 'queue-dpt', '0', '', '0', '60', 'Mine', 'Yes', 8, 'Stateless');
INSERT INTO "SERVICE_DEF" ("SERVICE_ID", "SERVICE_CODE", "SERVICE_NAME", "STATUS", "QUEUE_NAME", "ACCEPT_TIME", "GRPC_URL", "GRPC_STATUS", "GRPC_TIMEOUT", "EVENT_REGISTRATION", "IMPORT_EXPORT_STEP_CODE", "CONCURRENT_THREADS", "SERVICE_INSTANCE_TYPE") VALUES ('FAC', 'FAC', 'Fixed Asset service', 'Active', 'queue-fac', '0', '', '0', '60', 'Mine', 'Yes', 8, 'Stateless');
INSERT INTO "SERVICE_DEF" ("SERVICE_ID", "SERVICE_CODE", "SERVICE_NAME", "STATUS", "QUEUE_NAME", "ACCEPT_TIME", "GRPC_URL", "GRPC_STATUS", "GRPC_TIMEOUT", "EVENT_REGISTRATION", "IMPORT_EXPORT_STEP_CODE", "CONCURRENT_THREADS", "SERVICE_INSTANCE_TYPE") VALUES ('FX', 'FX', 'Foreign Exchange service', 'Active', 'queue-fx', '0', '', '0', '60', 'Mine', 'Yes', 8, 'Stateless');
INSERT INTO "SERVICE_DEF" ("SERVICE_ID", "SERVICE_CODE", "SERVICE_NAME", "STATUS", "QUEUE_NAME", "ACCEPT_TIME", "GRPC_URL", "GRPC_STATUS", "GRPC_TIMEOUT", "EVENT_REGISTRATION", "IMPORT_EXPORT_STEP_CODE", "CONCURRENT_THREADS", "SERVICE_INSTANCE_TYPE") VALUES ('IFC', 'IFC', 'IFC service', 'Active', 'queue-ifc', '0', '', '0', '60', 'Mine', 'Yes', 8, 'Stateless');
INSERT INTO "SERVICE_DEF" ("SERVICE_ID", "SERVICE_CODE", "SERVICE_NAME", "STATUS", "QUEUE_NAME", "ACCEPT_TIME", "GRPC_URL", "GRPC_STATUS", "GRPC_TIMEOUT", "EVENT_REGISTRATION", "IMPORT_EXPORT_STEP_CODE", "CONCURRENT_THREADS", "SERVICE_INSTANCE_TYPE") VALUES ('MTG', 'MTG', 'Mortgage service', 'Active', 'queue-mtg', '0', '', '0', '60', 'Mine', 'Yes', 8, 'Stateless');
INSERT INTO "SERVICE_DEF" ("SERVICE_ID", "SERVICE_CODE", "SERVICE_NAME", "STATUS", "QUEUE_NAME", "ACCEPT_TIME", "GRPC_URL", "GRPC_STATUS", "GRPC_TIMEOUT", "EVENT_REGISTRATION", "IMPORT_EXPORT_STEP_CODE", "CONCURRENT_THREADS", "SERVICE_INSTANCE_TYPE") VALUES ('PMT', 'PMT', 'Payment service', 'Active', 'queue-pmt', '0', '', '0', '60', 'Mine', 'Yes', 8, 'Stateless');
INSERT INTO "SERVICE_DEF" ("SERVICE_ID", "SERVICE_CODE", "SERVICE_NAME", "STATUS", "QUEUE_NAME", "ACCEPT_TIME", "GRPC_URL", "GRPC_STATUS", "GRPC_TIMEOUT", "EVENT_REGISTRATION", "IMPORT_EXPORT_STEP_CODE", "CONCURRENT_THREADS", "SERVICE_INSTANCE_TYPE") VALUES ('BCH', 'BCH', 'Batch service', 'Active', 'queue-bch', '0', '', '0', '60', 'Mine', 'Yes', 8, 'Stateless');
INSERT INTO "SERVICE_DEF" ("SERVICE_ID", "SERVICE_CODE", "SERVICE_NAME", "STATUS", "QUEUE_NAME", "ACCEPT_TIME", "GRPC_URL", "GRPC_STATUS", "GRPC_TIMEOUT", "EVENT_REGISTRATION", "IMPORT_EXPORT_STEP_CODE", "CONCURRENT_THREADS", "SERVICE_INSTANCE_TYPE") VALUES ('CMS', 'CMS', 'CMS service', 'Active', 'queue-cms', '0', '', '0', '60', 'Always', 'Yes', 8, 'Stateless');
INSERT INTO "SERVICE_DEF" ("SERVICE_ID", "SERVICE_CODE", "SERVICE_NAME", "STATUS", "QUEUE_NAME", "ACCEPT_TIME", "GRPC_URL", "GRPC_STATUS", "GRPC_TIMEOUT", "EVENT_REGISTRATION", "IMPORT_EXPORT_STEP_CODE", "CONCURRENT_THREADS", "SERVICE_INSTANCE_TYPE") VALUES ('VCH', 'VCH', 'Voucher service', 'Active', 'queue-vch', '0', '', '0', '60', 'Mine', 'Yes', 8, 'Stateless');
INSERT INTO "SERVICE_DEF" ("SERVICE_ID", "SERVICE_CODE", "SERVICE_NAME", "STATUS", "QUEUE_NAME", "ACCEPT_TIME", "GRPC_URL", "GRPC_STATUS", "GRPC_TIMEOUT", "EVENT_REGISTRATION", "IMPORT_EXPORT_STEP_CODE", "CONCURRENT_THREADS", "SERVICE_INSTANCE_TYPE") VALUES ('SPL', 'SPL', 'Sample service', 'Active', 'queue-spl', '0', '', '0', '60', 'Mine', 'Yes', 8, 'Stateless');
```
# Note
## Import file (`WF_STEP_DEF.csv`,...) to Postgres
Set `Quote` = `"`, `Escape` = `"`, `NULL Strings` = `NULL` to maintain json and null format
## Exception: Fluentmigrator found `MessageText: type "citext" does not exist`
```sql
CREATE EXTENSION IF NOT EXISTS citext WITH SCHEMA public;
```
## Set `pg_settings` [parameters](https://postgresqlco.nf/doc/en/param/)
```sql
SELECT * FROM pg_settings;
ALTER SYSTEM SET max_connections TO 20000;
```
Then restart container.
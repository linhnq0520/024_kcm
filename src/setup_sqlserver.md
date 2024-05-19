## 1. Modify Dockerfile_deploy, add globalization support (src/ShareFiles/neptuneserver/Dockerfile_deploy)

```yml
FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS base
WORKDIR /app
EXPOSE 100
EXPOSE 105
EXPOSE 109

# add globalization support
RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

FROM base AS final
WORKDIR /app
COPY ["neptuneserver/publish", "."]
COPY ["neptuneserver/NT.pfx", "."]

ENTRYPOINT ["dotnet", "JITS.Neptune.dll"]
```

## 2. Modify settings.json (src/ShareFiles/{service-name}/settings.json)

Example:

```json
"ConnectionStrings": {
  "ConnectionString": "server=neptunedb_sqlserver,1433;database=o9admin;user id=o9admin;password=o9admin;TrustServerCertificate=true",
  "DataProvider": "sqlserver",
  "SQLCommandTimeout": null
}
```

## 3. Deploy Portainer/Phpmyadmin/NeptuneServer

At Directory `src/ShareFiles` run:

```
docker compose -f ./docker-compose.sqlserver.yml up -d --build portainer
docker compose -f ./docker-compose.sqlserver.yml up -d --build neptunedb_sqlserver
```

## 4. Create User and DB

```sql
CREATE DATABASE [neptune]
 CONTAINMENT = NONE
 ON  PRIMARY
( NAME = N'neptune', FILENAME = N'/var/opt/mssql/data/neptune.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB );
Go
Use master
Go
CREATE LOGIN [neptune] WITH PASSWORD=N'neptune', DEFAULT_DATABASE=[neptune], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
Go
Use neptune
Go
Create user neptune for login neptune

CREATE DATABASE [neptune_archive]
 CONTAINMENT = NONE
 ON  PRIMARY
( NAME = N'neptune_archive', FILENAME = N'/var/opt/mssql/data/neptune_archive.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB );
Go
Use master
Go
CREATE LOGIN [neptune_archive] WITH PASSWORD=N'neptune_archive', DEFAULT_DATABASE=[neptune_archive], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
Go
Use neptune_archive
Go
Create user neptune_archive for login neptune_archive

CREATE DATABASE [o9admin]
 CONTAINMENT = NONE
 ON  PRIMARY
( NAME = N'o9admin', FILENAME = N'/var/opt/mssql/data/o9admin.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB );
Go
Use master
Go
CREATE LOGIN [o9admin] WITH PASSWORD=N'o9admin', DEFAULT_DATABASE=[o9admin], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
Go
Use o9admin
Go
Create user o9admin for login o9admin

CREATE DATABASE [o9accounting]
 CONTAINMENT = NONE
 ON  PRIMARY
( NAME = N'o9accounting', FILENAME = N'/var/opt/mssql/data/o9accounting.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB );
Go
Use master
Go
CREATE LOGIN [o9accounting] WITH PASSWORD=N'o9accounting', DEFAULT_DATABASE=[o9accounting], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
Go
Use o9accounting
Go
Create user o9accounting for login o9accounting

CREATE DATABASE [o9batch]
 CONTAINMENT = NONE
 ON  PRIMARY
( NAME = N'o9batch', FILENAME = N'/var/opt/mssql/data/o9batch.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB );
Go
Use master
Go
CREATE LOGIN [o9batch] WITH PASSWORD=N'o9batch', DEFAULT_DATABASE=[o9batch], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
Go
Use o9batch
Go
Create user o9batch for login o9batch

CREATE DATABASE [o9cms]
 CONTAINMENT = NONE
 ON  PRIMARY
( NAME = N'o9cms', FILENAME = N'/var/opt/mssql/data/o9cms.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB );
Go
Use master
Go
CREATE LOGIN [o9cms] WITH PASSWORD=N'o9cms', DEFAULT_DATABASE=[o9cms], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
Go
Use o9cms
Go
Create user o9cms for login o9cms

CREATE DATABASE [o9cash]
 CONTAINMENT = NONE
 ON  PRIMARY
( NAME = N'o9cash', FILENAME = N'/var/opt/mssql/data/o9cash.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB );
Go
Use master
Go
CREATE LOGIN [o9cash] WITH PASSWORD=N'o9cash', DEFAULT_DATABASE=[o9cash], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
Go
Use o9cash
Go
Create user o9cash for login o9cash

CREATE DATABASE [o9credit]
 CONTAINMENT = NONE
 ON  PRIMARY
( NAME = N'o9credit', FILENAME = N'/var/opt/mssql/data/o9credit.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB );
Go
Use master
Go
CREATE LOGIN [o9credit] WITH PASSWORD=N'o9credit', DEFAULT_DATABASE=[o9credit], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
Go
Use o9credit
Go
Create user o9credit for login o9credit

CREATE DATABASE [o9customer]
 CONTAINMENT = NONE
 ON  PRIMARY
( NAME = N'o9customer', FILENAME = N'/var/opt/mssql/data/o9customer.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB );
Go
Use master
Go
CREATE LOGIN [o9customer] WITH PASSWORD=N'o9customer', DEFAULT_DATABASE=[o9customer], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
Go
Use o9customer
Go
Create user o9customer for login o9customer

CREATE DATABASE [o9deposit]
 CONTAINMENT = NONE
 ON  PRIMARY
( NAME = N'o9deposit', FILENAME = N'/var/opt/mssql/data/o9deposit.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB );
Go
Use master
Go
CREATE LOGIN [o9deposit] WITH PASSWORD=N'o9deposit', DEFAULT_DATABASE=[o9deposit], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
Go
Use o9deposit
Go
Create user o9deposit for login o9deposit

CREATE DATABASE [o9fx]
 CONTAINMENT = NONE
 ON  PRIMARY
( NAME = N'o9fx', FILENAME = N'/var/opt/mssql/data/o9fx.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB );
Go
Use master
Go
CREATE LOGIN [o9fx] WITH PASSWORD=N'o9fx', DEFAULT_DATABASE=[o9fx], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
Go
Use o9fx
Go
Create user o9fx for login o9fx

CREATE DATABASE [o9fixedasset]
 CONTAINMENT = NONE
 ON  PRIMARY
( NAME = N'o9fixedasset', FILENAME = N'/var/opt/mssql/data/o9fixedasset.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB );
Go
Use master
Go
CREATE LOGIN [o9fixedasset] WITH PASSWORD=N'o9fixedasset', DEFAULT_DATABASE=[o9fixedasset], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
Go
Use o9fixedasset
Go
Create user o9fixedasset for login o9fixedasset

CREATE DATABASE [o9ifc]
 CONTAINMENT = NONE
 ON  PRIMARY
( NAME = N'o9ifc', FILENAME = N'/var/opt/mssql/data/o9ifc.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB );
Go
Use master
Go
CREATE LOGIN [o9ifc] WITH PASSWORD=N'o9ifc', DEFAULT_DATABASE=[o9ifc], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
Go
Use o9ifc
Go
Create user o9ifc for login o9ifc

CREATE DATABASE [o9mortgage]
 CONTAINMENT = NONE
 ON  PRIMARY
( NAME = N'o9mortgage', FILENAME = N'/var/opt/mssql/data/o9mortgage.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB );
Go
Use master
Go
CREATE LOGIN [o9mortgage] WITH PASSWORD=N'o9mortgage', DEFAULT_DATABASE=[o9mortgage], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
Go
Use o9mortgage
Go
Create user o9mortgage for login o9mortgage

CREATE DATABASE [o9payment]
 CONTAINMENT = NONE
 ON  PRIMARY
( NAME = N'o9payment', FILENAME = N'/var/opt/mssql/data/o9payment.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB );
Go
Use master
Go
CREATE LOGIN [o9payment] WITH PASSWORD=N'o9payment', DEFAULT_DATABASE=[o9payment], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
Go
Use o9payment
Go
Create user o9payment for login o9payment

CREATE DATABASE [o9voucher]
 CONTAINMENT = NONE
 ON  PRIMARY
( NAME = N'o9voucher', FILENAME = N'/var/opt/mssql/data/o9voucher.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB );
Go
Use master
Go
CREATE LOGIN [o9voucher] WITH PASSWORD=N'o9voucher', DEFAULT_DATABASE=[o9voucher], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
Go
Use o9voucher
Go
Create user o9voucher for login o9voucher

CREATE DATABASE [o9report]
 CONTAINMENT = NONE
 ON  PRIMARY
( NAME = N'o9report', FILENAME = N'/var/opt/mssql/data/o9report.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB );
Go
Use master
Go
CREATE LOGIN [o9report] WITH PASSWORD=N'o9report', DEFAULT_DATABASE=[o9report], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
Go
Use o9report
Go
Create user o9report for login o9report

CREATE DATABASE [o9email]
 CONTAINMENT = NONE
 ON  PRIMARY
( NAME = N'o9email', FILENAME = N'/var/opt/mssql/data/o9email.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB );
Go
Use master
Go
CREATE LOGIN [o9email] WITH PASSWORD=N'o9email', DEFAULT_DATABASE=[o9email], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
Go
Use o9email
Go
Create user o9email for login o9email

CREATE DATABASE [o9ems]
 CONTAINMENT = NONE
 ON  PRIMARY
( NAME = N'o9ems', FILENAME = N'/var/opt/mssql/data/o9ems.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB );
Go
Use master
Go
CREATE LOGIN [o9ems] WITH PASSWORD=N'o9ems', DEFAULT_DATABASE=[o9ems], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
Go
Use o9ems
Go
Create user o9ems for login o9ems

CREATE DATABASE [o9sample]
 CONTAINMENT = NONE
 ON  PRIMARY
( NAME = N'o9sample', FILENAME = N'/var/opt/mssql/data/o9sample.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB );
Go
Use master
Go
CREATE LOGIN [o9sample] WITH PASSWORD=N'o9sample', DEFAULT_DATABASE=[o9sample], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
Go
Use o9sample
Go
Create user o9sample for login o9sample

CREATE DATABASE [o9import]
 CONTAINMENT = NONE
 ON  PRIMARY
( NAME = N'o9import', FILENAME = N'/var/opt/mssql/data/o9import.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB );
Go
Use master
Go
CREATE LOGIN [o9import] WITH PASSWORD=N'o9import', DEFAULT_DATABASE=[o9import], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
Go
Use o9import
Go
Create user o9import for login o9import

```

```sql
Use master
Go
GRANT CONTROL SERVER TO neptune;
GRANT CONTROL SERVER TO neptune_archive;
GRANT CONTROL SERVER TO o9accounting;
GRANT CONTROL SERVER TO o9admin;
GRANT CONTROL SERVER TO o9batch;
GRANT CONTROL SERVER TO o9cash;
GRANT CONTROL SERVER TO o9cms;
GRANT CONTROL SERVER TO o9ems;
GRANT CONTROL SERVER TO o9credit;
GRANT CONTROL SERVER TO o9customer;
GRANT CONTROL SERVER TO o9deposit;
GRANT CONTROL SERVER TO o9fixedasset;
GRANT CONTROL SERVER TO o9fx;
GRANT CONTROL SERVER TO o9ifc;
GRANT CONTROL SERVER TO o9mortgage;
GRANT CONTROL SERVER TO o9payment;
GRANT CONTROL SERVER TO o9voucher;
GRANT CONTROL SERVER TO o9report;
GRANT CONTROL SERVER TO o9email;
GRANT CONTROL SERVER TO o9sample;
GRANT CONTROL SERVER TO o9import;
GRANT CONTROL SERVER TO o9party;
GRANT CONTROL SERVER TO o9card;
```

## 5. Create structure database `neptune`

```sql
IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

Use neptune
Go
BEGIN TRANSACTION;
GO

IF SCHEMA_ID(N'neptune') IS NULL EXEC(N'CREATE SCHEMA [neptune];');
GO

CREATE TABLE [neptune].[AUTH_ORGANIZATION] (
    [OrganizationID] nvarchar(100) NOT NULL,
    [OrganizationCode] nvarchar(100) NOT NULL,
    [OrganizationName] nvarchar(500) NOT NULL,
    [Phone] nvarchar(50) NULL,
    [Status] nvarchar(10) NOT NULL,
    [Email] nvarchar(1000) NULL,
    [Website] nvarchar(1000) NULL,
    [welcome_logo] text NULL,
    [login_background] text NULL,
    CONSTRAINT [PK_AUTH_ORGANIZATION] PRIMARY KEY ([OrganizationID])
);
GO

CREATE TABLE [neptune].[AUTH_ROLE] (
    [RoleID] nvarchar(100) NOT NULL,
    [RoleCode] nvarchar(100) NOT NULL,
    [RoleName] nvarchar(500) NOT NULL,
    CONSTRAINT [PK_AUTH_ROLE] PRIMARY KEY ([RoleID])
);
GO

CREATE TABLE [neptune].[AUTH_ROLE_USER] (
    [RoleID] nvarchar(100) NOT NULL,
    [UserID] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_AUTH_ROLE_USER] PRIMARY KEY ([RoleID], [UserID])
);
GO

CREATE TABLE [neptune].[AUTH_ROLE_WF] (
    [RoleID] nvarchar(100) NOT NULL,
    [WorflowID] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_AUTH_ROLE_WF] PRIMARY KEY ([RoleID], [WorflowID])
);
GO

CREATE TABLE [neptune].[AUTH_USER] (
    [UserID] nvarchar(100) NOT NULL,
    [UserCode] nvarchar(100) NOT NULL,
    [OrganizationID] nvarchar(100) NOT NULL,
    [UserName] nvarchar(500) NULL,
    [FullName] nvarchar(500) NULL,
    [Status] nvarchar(10) NOT NULL,
    [LanguageCode] nvarchar(2) NOT NULL,
    [SessionExpirationInMinutes] int NOT NULL,
    [HashPassword] nvarchar(500) NULL,
    [PastHashPassword1] nvarchar(500) NULL,
    [PastHashPassword2] nvarchar(500) NULL,
    [PastHashPassword3] nvarchar(500) NULL,
    [PastHashPassword4] nvarchar(500) NULL,
    [PastHashPassword5] nvarchar(500) NULL,
    [PastHashPassword6] nvarchar(500) NULL,
    [PastHashPassword7] nvarchar(500) NULL,
    [PastHashPassword8] nvarchar(500) NULL,
    [PastHashPassword9] nvarchar(500) NULL,
    [PastHashPassword10] nvarchar(500) NULL,
    [FailureCount] int NOT NULL,
    [PasswordCreatedDate] bigint NOT NULL,
    [TimeZone] decimal(18,2) NULL,
    [ChannelID] nvarchar(100) NULL,
    CONSTRAINT [PK_AUTH_USER] PRIMARY KEY ([UserID])
);
GO

CREATE TABLE [neptune].[CONFIGURATION] (
    [PARA_CODE] nvarchar(500) NOT NULL,
    [PARA_VALUE] nvarchar(4000) NULL,
    CONSTRAINT [PK_CONFIGURATION] PRIMARY KEY ([PARA_CODE])
);
GO

CREATE TABLE [neptune].[ENVIRONMENT_VARIABLE] (
    [VARIABLE_NAME] nvarchar(500) NOT NULL,
    [E1] text NULL,
    [E2] text NULL,
    [E3] text NULL,
    [E4] text NULL,
    [E5] text NULL,
    [E6] text NULL,
    [E7] text NULL,
    [E8] text NULL,
    [E9] text NULL,
    CONSTRAINT [PK_ENVIRONMENT_VARIABLE] PRIMARY KEY ([VARIABLE_NAME])
);
GO

CREATE TABLE [neptune].[EVENT_DEF] (
    [EVENT_NAME] nvarchar(500) NOT NULL,
    [STATUS] nvarchar(50) NOT NULL,
    [TYPE] nvarchar(50) NOT NULL,
    [DESCRIPTION] nvarchar(500) NULL,
    CONSTRAINT [PK_EVENT_DEF] PRIMARY KEY ([EVENT_NAME])
);
GO

CREATE TABLE [neptune].[INSTANCE] (
    [INSTANCE_ID] nvarchar(50) NOT NULL,
    [GRPC_URL] nvarchar(500) NOT NULL,
    [UTC_TIME] bigint NOT NULL,
    [UTC_EXP_TIME] bigint NOT NULL,
    [SERVICE_ID] nvarchar(100) NULL,
    [EVENT_QUEUE_NAME] nvarchar(500) NULL,
    [COMMAND_QUEUE_NAME] nvarchar(500) NULL,
    CONSTRAINT [PK_INSTANCE] PRIMARY KEY ([INSTANCE_ID])
);
GO

CREATE TABLE [neptune].[JWT] (
    [ID] nvarchar(1000) NOT NULL,
    [token] nvarchar(1000) NOT NULL,
    [valid_from] bigint NOT NULL,
    [valid_to] bigint NOT NULL,
    [user_id] nvarchar(1000) NOT NULL,
    [user_code] nvarchar(1000) NOT NULL,
    [user_name] nvarchar(1000) NOT NULL,
    [organization_id] nvarchar(1000) NOT NULL,
    [organization_code] nvarchar(1000) NOT NULL,
    [organization_name] nvarchar(1000) NOT NULL,
    CONSTRAINT [PK_JWT] PRIMARY KEY ([ID])
);
GO

CREATE TABLE [neptune].[JWT_STATIC] (
    [ID] nvarchar(1000) NOT NULL,
    [token] nvarchar(1000) NOT NULL,
    [valid_from] bigint NOT NULL,
    [valid_to] bigint NOT NULL,
    [user_id] nvarchar(1000) NOT NULL,
    [user_code] nvarchar(1000) NOT NULL,
    [user_name] nvarchar(1000) NOT NULL,
    [organization_id] nvarchar(1000) NOT NULL,
    [organization_code] nvarchar(1000) NOT NULL,
    [organization_name] nvarchar(1000) NOT NULL,
    CONSTRAINT [PK_JWT_STATIC] PRIMARY KEY ([ID])
);
GO

CREATE TABLE [neptune].[LANGUAGE_RESOURCE] (
    [RESOURCE_CODE] nvarchar(500) NOT NULL,
    [ID] nvarchar(100) NOT NULL,
    [EN] text NOT NULL,
    [VI] text NULL,
    [LA] text NULL,
    [KR] text NULL,
    [MM] text NULL,
    [TH] text NULL,
    CONSTRAINT [PK_LANGUAGE_RESOURCE] PRIMARY KEY ([RESOURCE_CODE])
);
GO

CREATE TABLE [neptune].[LOG_API] (
    [AUDIT_ID] nvarchar(100) NOT NULL,
    [UTC_TIME] bigint NOT NULL,
    [REQUEST_SCHEME] nvarchar(100) NULL,
    [REQUEST_SERVER_IP] nvarchar(100) NULL,
    [REQUEST_PATH] nvarchar(4000) NULL,
    [REQUEST_HOST] nvarchar(4000) NULL,
    [REQUEST_BODY] text NULL,
    [LOGIN_USER_ID] nvarchar(100) NULL,
    [LOGIN_ORGANIZATION_ID] nvarchar(100) NULL,
    [RESPONSE_EXECUTION_ID] nvarchar(100) NULL,
    [RESPONSE_DESCRIPTION] nvarchar(4000) NULL,
    [RESPONSE_STATUS] nvarchar(100) NULL,
    [RESPONSE_DATA] text NULL,
    [TRACK_CHANGE] text NULL,
    CONSTRAINT [PK_LOG_API] PRIMARY KEY ([AUDIT_ID])
);
GO

CREATE TABLE [neptune].[LOG_EVENT] (
    [EVENT_ID] nvarchar(50) NOT NULL,
    [INSTANCE_ID] nvarchar(500) NOT NULL,
    [RUNNING_ID] nvarchar(500) NOT NULL,
    [EVENT_TYPE] nvarchar(100) NOT NULL,
    [UTC_TIME] bigint NOT NULL,
    [DESCS] text NOT NULL,
    [EVENT_DATA] text NULL,
    CONSTRAINT [PK_LOG_EVENT] PRIMARY KEY ([EVENT_ID])
);
GO

CREATE TABLE [neptune].[LOG_GRPC] (
    [ID] nvarchar(50) NOT NULL,
    [INSTANCE_ID] nvarchar(500) NOT NULL,
    [RUNNING_ID] nvarchar(500) NOT NULL,
    [SERVER_TIME] bigint NOT NULL,
    [FROM_SERVICE_ID] nvarchar(100) NULL,
    [TO_SERVICE_ID] nvarchar(100) NULL,
    [METHOD_SPEC] nvarchar(4000) NULL,
    [METHOD_RESULT] text NULL,
    CONSTRAINT [PK_LOG_GRPC] PRIMARY KEY ([ID])
);
GO

CREATE TABLE [neptune].[LOG_HTTP_REQUEST] (
    [REQUEST_ID] nvarchar(100) NOT NULL,
    [TIME_IN] bigint NOT NULL,
    [TIME_OUT] bigint NOT NULL,
    [DATA] text NULL,
    CONSTRAINT [PK_LOG_HTTP_REQUEST] PRIMARY KEY ([REQUEST_ID])
);
GO

CREATE TABLE [neptune].[LOG_INCOMING_QUEUE_MESSAGE] (
    [MESSAGE_ID] nvarchar(100) NOT NULL,
    [COMING_TIME] bigint NOT NULL,
    [COMING_STATUS] nvarchar(50) NOT NULL,
    [COMING_CONTENT] text NULL,
    [PROCESSING_ERROR] text NULL,
    [REQUEST_EXEC_STEP_ID] nvarchar(100) NULL,
    [RESPONSE_STATUS] nvarchar(100) NULL,
    [RESPONSE_OUTPUT] text NULL,
    CONSTRAINT [PK_LOG_INCOMING_QUEUE_MESSAGE] PRIMARY KEY ([MESSAGE_ID])
);
GO

CREATE TABLE [neptune].[LOG_RECEIVING_HTTP] (
    [HTTP_ID] nvarchar(100) NOT NULL,
    [TIME_START] bigint NOT NULL,
    [TIME_FINISH] bigint NOT NULL,
    [RECEIVING_DATA] text NULL,
    [SENDING_DATA] text NULL,
    [ERROR_DATA] text NULL,
    CONSTRAINT [PK_LOG_RECEIVING_HTTP] PRIMARY KEY ([HTTP_ID])
);
GO

CREATE TABLE [neptune].[SENDING_HTTP] (
    [HTTP_ID] nvarchar(100) NOT NULL,
    [TIME_START] bigint NOT NULL,
    [TIME_FINISH] bigint NOT NULL,
    [SENDING_DATA] text NULL,
    [RECEIVING_DATA] text NULL,
    [ERROR_DATA] text NULL,
    CONSTRAINT [PK_SENDING_HTTP] PRIMARY KEY ([HTTP_ID])
);
GO

CREATE TABLE [neptune].[SERVICE_DEF] (
    [SERVICE_ID] nvarchar(100) NOT NULL,
    [SERVICE_CODE] nvarchar(100) NOT NULL,
    [SERVICE_NAME] nvarchar(4000) NOT NULL,
    [STATUS] nvarchar(50) NOT NULL,
    [QUEUE_NAME] nvarchar(100) NOT NULL,
    [ACCEPT_TIME] bigint NOT NULL,
    [GRPC_STATUS] nvarchar(50) NOT NULL,
    [GRPC_TIMEOUT] bigint NOT NULL,
    [GRPC_URL] nvarchar(500) NULL,
    [EVENT_REGISTRATION] nvarchar(50) NOT NULL,
    [IMPORT_EXPORT_STEP_CODE] nvarchar(50) NOT NULL,
    [CONCURRENT_THREADS] bigint NOT NULL,
    [SERVICE_INSTANCE_TYPE] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_SERVICE_DEF] PRIMARY KEY ([SERVICE_ID])
);
GO

CREATE TABLE [neptune].[WF_DEF] (
    [WFID] nvarchar(100) NOT NULL,
    [Code] nvarchar(100) NULL,
    [Name] nvarchar(500) NULL,
    [Status] nvarchar(100) NOT NULL,
    [AllowReversal] nvarchar(100) NOT NULL,
    [Description] nvarchar(500) NULL,
    [TimeoutInMiliseconds] bigint NOT NULL,
    [KeepExecSeconds] bigint NOT NULL,
    [OpenAPITags] nvarchar(500) NULL,
    [OpenAPIResponse] nvarchar(max) NULL,
    [OpenAPIResponseSpec] nvarchar(max) NULL,
    [EventWorkflowRegistered] nvarchar(50) NOT NULL,
    [EventWorkflowCompleted] nvarchar(50) NOT NULL,
    [EventWorkflowError] nvarchar(50) NOT NULL,
    [EventWorkflowTimeout] nvarchar(50) NOT NULL,
    [EventWorkflowCompensated] nvarchar(50) NOT NULL,
    [EventWorkflowReversed] nvarchar(50) NOT NULL,
    [EventWorkflowStepStart] nvarchar(50) NOT NULL,
    [EventWorkflowStepCompleted] nvarchar(50) NOT NULL,
    [EventWorkflowStepError] nvarchar(50) NOT NULL,
    [EventWorkflowStepTimeout] nvarchar(50) NOT NULL,
    [EventWorkflowStepCompensated] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_WF_DEF] PRIMARY KEY ([WFID])
);
GO

CREATE TABLE [neptune].[WF_EXEC] (
    [EXECUTION_ID] nvarchar(100) NOT NULL,
    [USER_ID] nvarchar(100) NOT NULL,
    [ORGANIZATION_ID] nvarchar(100) NOT NULL,
    [INPUT] text NOT NULL,
    [WFID] nvarchar(100) NOT NULL,
    [LANG] nvarchar(2) NOT NULL,
    [CREATED_ON] bigint NOT NULL,
    [STATUS] nvarchar(100) NOT NULL,
    [FINISH_ON] bigint NOT NULL,
    [IS_SUCCESS] nvarchar(100) NOT NULL,
    [IS_TIMEOUT] nvarchar(100) NOT NULL,
    [IS_PROCESSING] nvarchar(100) NOT NULL,
    [STOP_ERROR] text NULL,
    [WORKFLOW_TYPE] nvarchar(100) NOT NULL,
    [REVERSED_EXECUTION_ID] nvarchar(100) NOT NULL,
    [REVERSED_BY_EXECUTION_ID] nvarchar(100) NOT NULL,
    [IS_DISPUTED] nvarchar(450) NOT NULL,
    [ARCHIVING_TIME] bigint NOT NULL,
    [PURGING_TIME] bigint NOT NULL,
    [TX_CONTEXT] text NOT NULL,
    [APPROVED_EXECUTION_ID] nvarchar(100) NULL,
    [SERVICE_INSTANCES] nvarchar(2000) NULL,
    CONSTRAINT [PK_WF_EXEC] PRIMARY KEY ([EXECUTION_ID])
);
GO

CREATE TABLE [neptune].[WF_EXEC_DONE] (
    [EXECUTION_ID] nvarchar(100) NOT NULL,
    [USER_ID] nvarchar(100) NOT NULL,
    [ORGANIZATION_ID] nvarchar(100) NOT NULL,
    [INPUT] text NOT NULL,
    [WFID] nvarchar(100) NOT NULL,
    [LANG] nvarchar(2) NOT NULL,
    [CREATED_ON] bigint NOT NULL,
    [STATUS] nvarchar(100) NOT NULL,
    [FINISH_ON] bigint NOT NULL,
    [IS_SUCCESS] nvarchar(100) NOT NULL,
    [IS_TIMEOUT] nvarchar(100) NOT NULL,
    [IS_PROCESSING] nvarchar(100) NOT NULL,
    [STOP_ERROR] text NULL,
    [WORKFLOW_TYPE] nvarchar(100) NOT NULL,
    [REVERSED_EXECUTION_ID] nvarchar(100) NOT NULL,
    [REVERSED_BY_EXECUTION_ID] nvarchar(100) NOT NULL,
    [IS_DISPUTED] nvarchar(450) NOT NULL,
    [ARCHIVING_TIME] bigint NOT NULL,
    [PURGING_TIME] bigint NOT NULL,
    [TX_CONTEXT] text NOT NULL,
    [APPROVED_EXECUTION_ID] nvarchar(100) NULL,
    [SERVICE_INSTANCES] nvarchar(2000) NULL,
    CONSTRAINT [PK_WF_EXEC_DONE] PRIMARY KEY ([EXECUTION_ID])
);
GO

CREATE TABLE [neptune].[WF_FIELD] (
    [WORKFLOW_ID] nvarchar(100) NOT NULL,
    [FIELD_CODE] nvarchar(100) NOT NULL,
    [FIELD_KEY] nvarchar(100) NOT NULL,
    [DATA_TYPE] nvarchar(100) NOT NULL,
    [IS_NULL] nvarchar(100) NOT NULL,
    [IS_REQUIRED] nvarchar(100) NOT NULL,
    [NUM_MIN] decimal(18,2) NOT NULL,
    [NUM_MAX] decimal(18,2) NOT NULL,
    [NUM_RANGE] text NULL,
    [TEXT_MIN] text NULL,
    [TEXT_MAX] text NULL,
    [TEXT_RANGE] text NULL,
    [TEXT_MAXLENGTH] int NOT NULL,
    [DATE_MIN] decimal(18,2) NOT NULL,
    [DATE_MAX] decimal(18,2) NOT NULL,
    [DATE_RANGE] text NULL,
    [BASE64_ICON] text NULL,
    [OPENAPI_EXAMPLE] nvarchar(max) NULL,
    [OPENAPI_DESCRIPTION] nvarchar(max) NULL,
    CONSTRAINT [PK_WF_FIELD] PRIMARY KEY ([WORKFLOW_ID], [FIELD_CODE])
);
GO

CREATE TABLE [neptune].[WF_GROUP_EXEC] (
    [EXECUTION_ID] nvarchar(100) NOT NULL,
    [STEP_GROUP] int NOT NULL,
    [P1_STATUS] nvarchar(100) NOT NULL,
    [P2_STATUS] nvarchar(100) NOT NULL,
    [P1_START] bigint NOT NULL,
    [P1_FINISH] bigint NOT NULL,
    [P1_ERROR] text NULL,
    CONSTRAINT [PK_WF_GROUP_EXEC] PRIMARY KEY ([EXECUTION_ID], [STEP_GROUP])
);
GO

CREATE TABLE [neptune].[WF_GROUP_EXEC_DONE] (
    [EXECUTION_ID] nvarchar(100) NOT NULL,
    [STEP_GROUP] int NOT NULL,
    [P1_STATUS] nvarchar(100) NOT NULL,
    [P2_STATUS] nvarchar(100) NOT NULL,
    [P1_START] bigint NOT NULL,
    [P1_FINISH] bigint NOT NULL,
    [P1_ERROR] text NULL,
    CONSTRAINT [PK_WF_GROUP_EXEC_DONE] PRIMARY KEY ([EXECUTION_ID], [STEP_GROUP])
);
GO

CREATE TABLE [neptune].[WF_STEP_DEF] (
    [WFID] nvarchar(100) NOT NULL,
    [STEP_ORDER] int NOT NULL,
    [STEP_GROUP] int NOT NULL,
    [STEP_CODE] nvarchar(100) NULL,
    [STATUS] nvarchar(100) NOT NULL,
    [DESCRIPTION] nvarchar(4000) NULL,
    [SERVICE_ID] nvarchar(100) NULL,
    [SENDING_TEMPLATE] text NULL,
    [SUCCESS_CONDITION] text NULL,
    [REQUEST_PROTOCOL] nvarchar(1000) NULL,
    [REQUEST_SERVER_IP] nvarchar(100) NULL,
    [REQUEST_SERVER_PORT] nvarchar(100) NULL,
    [REQUEST_URI] nvarchar(100) NULL,
    [SEND_BY_BROKER] nvarchar(100) NOT NULL,
    [STEP_TIMEOUT] nvarchar(100) NULL,
    [STEP_MODE] nvarchar(20) NOT NULL,
    [BASE64_ICON] text NULL,
    [SENDING_CONDITION] text NULL,
    [ON_COMPENSATING] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_WF_STEP_DEF] PRIMARY KEY ([WFID], [STEP_ORDER])
);
GO

CREATE TABLE [neptune].[WF_STEP_EXEC] (
    [STEP_EXECUTION_ID] nvarchar(100) NOT NULL,
    [EXECUTION_ID] nvarchar(100) NOT NULL,
    [WORKFLOW_ID] nvarchar(100) NULL,
    [STEP_GROUP] int NOT NULL,
    [STEP_ORDER] int NOT NULL,
    [STEP_CODE] nvarchar(100) NULL,
    [P1_REQUEST_ID] nvarchar(100) NULL,
    [P1_START] bigint NOT NULL,
    [P1_FINISH] bigint NOT NULL,
    [P1_STATUS] nvarchar(100) NOT NULL,
    [P1_ERROR] text NOT NULL,
    [P1_CONTENT] text NOT NULL,
    [P2_REQUEST_ID] nvarchar(100) NULL,
    [P2_START] bigint NOT NULL,
    [P2_FINISH] bigint NOT NULL,
    [P2_STATUS] nvarchar(100) NOT NULL,
    [P2_RESPONSE_STATUS] nvarchar(100) NULL,
    [P2_ERROR] text NULL,
    [P2_ERROR_CODE] nvarchar(400) NULL,
    [P2_CONTENT] text NULL,
    [IS_SUCCESS] nvarchar(100) NOT NULL,
    [IS_TIMEOUT] nvarchar(100) NOT NULL,
    [P3_START] bigint NOT NULL,
    [P3_FINISH] bigint NOT NULL,
    [P3_STATUS] nvarchar(100) NOT NULL,
    [P3_CONTENT] text NULL,
    [P3_ERROR] text NULL,
    [SENDING_CONDITION] text NULL,
    [P4_STATUS] nvarchar(max) NOT NULL,
    [IS_DISPUTED] nvarchar(450) NOT NULL,
    [P4_CONTENT] text NULL,
    CONSTRAINT [PK_WF_STEP_EXEC] PRIMARY KEY ([STEP_EXECUTION_ID])
);
GO

CREATE TABLE [neptune].[WF_STEP_EXEC_DONE] (
    [STEP_EXECUTION_ID] nvarchar(100) NOT NULL,
    [EXECUTION_ID] nvarchar(100) NOT NULL,
    [WORKFLOW_ID] nvarchar(100) NULL,
    [STEP_GROUP] int NOT NULL,
    [STEP_ORDER] int NOT NULL,
    [STEP_CODE] nvarchar(100) NULL,
    [P1_REQUEST_ID] nvarchar(100) NULL,
    [P1_START] bigint NOT NULL,
    [P1_FINISH] bigint NOT NULL,
    [P1_STATUS] nvarchar(100) NOT NULL,
    [P1_ERROR] text NOT NULL,
    [P1_CONTENT] text NOT NULL,
    [P2_REQUEST_ID] nvarchar(100) NULL,
    [P2_START] bigint NOT NULL,
    [P2_FINISH] bigint NOT NULL,
    [P2_STATUS] nvarchar(100) NOT NULL,
    [P2_RESPONSE_STATUS] nvarchar(100) NULL,
    [P2_ERROR] text NULL,
    [P2_ERROR_CODE] nvarchar(400) NULL,
    [P2_CONTENT] text NULL,
    [IS_SUCCESS] nvarchar(100) NOT NULL,
    [IS_TIMEOUT] nvarchar(100) NOT NULL,
    [P3_START] bigint NOT NULL,
    [P3_FINISH] bigint NOT NULL,
    [P3_STATUS] nvarchar(100) NOT NULL,
    [P3_CONTENT] text NULL,
    [P3_ERROR] text NULL,
    [SENDING_CONDITION] text NULL,
    [P4_STATUS] nvarchar(max) NOT NULL,
    [IS_DISPUTED] nvarchar(450) NOT NULL,
    [P4_CONTENT] text NULL,
    CONSTRAINT [PK_WF_STEP_EXEC_DONE] PRIMARY KEY ([STEP_EXECUTION_ID])
);
GO

CREATE UNIQUE INDEX [IX_AUTH_ORGANIZATION_OrganizationCode] ON [neptune].[AUTH_ORGANIZATION] ([OrganizationCode]);
GO

CREATE UNIQUE INDEX [IX_AUTH_ROLE_RoleCode] ON [neptune].[AUTH_ROLE] ([RoleCode]);
GO

CREATE UNIQUE INDEX [IX_AUTH_USER_UserCode] ON [neptune].[AUTH_USER] ([UserCode]);
GO

CREATE INDEX [IX_INSTANCE_SERVICE_ID] ON [neptune].[INSTANCE] ([SERVICE_ID]);
GO

CREATE INDEX [IX_JWT_token] ON [neptune].[JWT] ([token]);
GO

CREATE UNIQUE INDEX [IX_LANGUAGE_RESOURCE_RESOURCE_CODE] ON [neptune].[LANGUAGE_RESOURCE] ([RESOURCE_CODE]);
GO

CREATE INDEX [IX_LOG_API_LOGIN_ORGANIZATION_ID] ON [neptune].[LOG_API] ([LOGIN_ORGANIZATION_ID]);
GO

CREATE INDEX [IX_LOG_API_LOGIN_USER_ID] ON [neptune].[LOG_API] ([LOGIN_USER_ID]);
GO

CREATE INDEX [IX_LOG_API_RESPONSE_STATUS] ON [neptune].[LOG_API] ([RESPONSE_STATUS]);
GO

CREATE INDEX [IX_LOG_API_UTC_TIME] ON [neptune].[LOG_API] ([UTC_TIME]);
GO

CREATE INDEX [IX_LOG_EVENT_UTC_TIME] ON [neptune].[LOG_EVENT] ([UTC_TIME]);
GO

CREATE INDEX [IX_LOG_GRPC_INSTANCE_ID] ON [neptune].[LOG_GRPC] ([INSTANCE_ID]);
GO

CREATE INDEX [IX_LOG_GRPC_RUNNING_ID] ON [neptune].[LOG_GRPC] ([RUNNING_ID]);
GO

CREATE INDEX [IX_LOG_GRPC_SERVER_TIME] ON [neptune].[LOG_GRPC] ([SERVER_TIME]);
GO

CREATE UNIQUE INDEX [IX_SERVICE_DEF_SERVICE_CODE] ON [neptune].[SERVICE_DEF] ([SERVICE_CODE]);
GO

CREATE UNIQUE INDEX [IX_WF_DEF_Code] ON [neptune].[WF_DEF] ([Code]) WHERE [Code] IS NOT NULL;
GO

CREATE INDEX [IX_WF_EXEC_ARCHIVING_TIME] ON [neptune].[WF_EXEC] ([ARCHIVING_TIME]);
GO

CREATE INDEX [IX_WF_EXEC_CREATED_ON] ON [neptune].[WF_EXEC] ([CREATED_ON]);
GO

CREATE INDEX [IX_WF_EXEC_FINISH_ON] ON [neptune].[WF_EXEC] ([FINISH_ON]);
GO

CREATE INDEX [IX_WF_EXEC_IS_DISPUTED] ON [neptune].[WF_EXEC] ([IS_DISPUTED]);
GO

CREATE INDEX [IX_WF_EXEC_IS_SUCCESS] ON [neptune].[WF_EXEC] ([IS_SUCCESS]);
GO

CREATE INDEX [IX_WF_EXEC_IS_TIMEOUT] ON [neptune].[WF_EXEC] ([IS_TIMEOUT]);
GO

CREATE INDEX [IX_WF_EXEC_ORGANIZATION_ID] ON [neptune].[WF_EXEC] ([ORGANIZATION_ID]);
GO

CREATE INDEX [IX_WF_EXEC_PURGING_TIME] ON [neptune].[WF_EXEC] ([PURGING_TIME]);
GO

CREATE INDEX [IX_WF_EXEC_STATUS] ON [neptune].[WF_EXEC] ([STATUS]);
GO

CREATE INDEX [IX_WF_EXEC_USER_ID] ON [neptune].[WF_EXEC] ([USER_ID]);
GO

CREATE INDEX [IX_WF_EXEC_WFID] ON [neptune].[WF_EXEC] ([WFID]);
GO

CREATE INDEX [IX_WF_EXEC_WORKFLOW_TYPE] ON [neptune].[WF_EXEC] ([WORKFLOW_TYPE]);
GO

CREATE INDEX [IX_WF_EXEC_DONE_ARCHIVING_TIME] ON [neptune].[WF_EXEC_DONE] ([ARCHIVING_TIME]);
GO

CREATE INDEX [IX_WF_EXEC_DONE_CREATED_ON] ON [neptune].[WF_EXEC_DONE] ([CREATED_ON]);
GO

CREATE INDEX [IX_WF_EXEC_DONE_FINISH_ON] ON [neptune].[WF_EXEC_DONE] ([FINISH_ON]);
GO

CREATE INDEX [IX_WF_EXEC_DONE_IS_DISPUTED] ON [neptune].[WF_EXEC_DONE] ([IS_DISPUTED]);
GO

CREATE INDEX [IX_WF_EXEC_DONE_IS_SUCCESS] ON [neptune].[WF_EXEC_DONE] ([IS_SUCCESS]);
GO

CREATE INDEX [IX_WF_EXEC_DONE_IS_TIMEOUT] ON [neptune].[WF_EXEC_DONE] ([IS_TIMEOUT]);
GO

CREATE INDEX [IX_WF_EXEC_DONE_ORGANIZATION_ID] ON [neptune].[WF_EXEC_DONE] ([ORGANIZATION_ID]);
GO

CREATE INDEX [IX_WF_EXEC_DONE_PURGING_TIME] ON [neptune].[WF_EXEC_DONE] ([PURGING_TIME]);
GO

CREATE INDEX [IX_WF_EXEC_DONE_STATUS] ON [neptune].[WF_EXEC_DONE] ([STATUS]);
GO

CREATE INDEX [IX_WF_EXEC_DONE_USER_ID] ON [neptune].[WF_EXEC_DONE] ([USER_ID]);
GO

CREATE INDEX [IX_WF_EXEC_DONE_WFID] ON [neptune].[WF_EXEC_DONE] ([WFID]);
GO

CREATE INDEX [IX_WF_EXEC_DONE_WORKFLOW_TYPE] ON [neptune].[WF_EXEC_DONE] ([WORKFLOW_TYPE]);
GO

CREATE INDEX [IX_WF_STEP_EXEC_EXECUTION_ID] ON [neptune].[WF_STEP_EXEC] ([EXECUTION_ID]);
GO

CREATE INDEX [IX_WF_STEP_EXEC_IS_DISPUTED] ON [neptune].[WF_STEP_EXEC] ([IS_DISPUTED]);
GO

CREATE INDEX [IX_WF_STEP_EXEC_IS_SUCCESS] ON [neptune].[WF_STEP_EXEC] ([IS_SUCCESS]);
GO

CREATE INDEX [IX_WF_STEP_EXEC_IS_TIMEOUT] ON [neptune].[WF_STEP_EXEC] ([IS_TIMEOUT]);
GO

CREATE INDEX [IX_WF_STEP_EXEC_P1_FINISH] ON [neptune].[WF_STEP_EXEC] ([P1_FINISH]);
GO

CREATE INDEX [IX_WF_STEP_EXEC_P1_START] ON [neptune].[WF_STEP_EXEC] ([P1_START]);
GO

CREATE INDEX [IX_WF_STEP_EXEC_P1_STATUS] ON [neptune].[WF_STEP_EXEC] ([P1_STATUS]);
GO

CREATE INDEX [IX_WF_STEP_EXEC_P2_FINISH] ON [neptune].[WF_STEP_EXEC] ([P2_FINISH]);
GO

CREATE INDEX [IX_WF_STEP_EXEC_P2_START] ON [neptune].[WF_STEP_EXEC] ([P2_START]);
GO

CREATE INDEX [IX_WF_STEP_EXEC_P2_STATUS] ON [neptune].[WF_STEP_EXEC] ([P2_STATUS]);
GO

CREATE INDEX [IX_WF_STEP_EXEC_P3_FINISH] ON [neptune].[WF_STEP_EXEC] ([P3_FINISH]);
GO

CREATE INDEX [IX_WF_STEP_EXEC_P3_START] ON [neptune].[WF_STEP_EXEC] ([P3_START]);
GO

CREATE INDEX [IX_WF_STEP_EXEC_P3_STATUS] ON [neptune].[WF_STEP_EXEC] ([P3_STATUS]);
GO

CREATE INDEX [IX_WF_STEP_EXEC_STEP_CODE] ON [neptune].[WF_STEP_EXEC] ([STEP_CODE]);
GO

CREATE INDEX [IX_WF_STEP_EXEC_WORKFLOW_ID] ON [neptune].[WF_STEP_EXEC] ([WORKFLOW_ID]);
GO

CREATE INDEX [IX_WF_STEP_EXEC_DONE_EXECUTION_ID] ON [neptune].[WF_STEP_EXEC_DONE] ([EXECUTION_ID]);
GO

CREATE INDEX [IX_WF_STEP_EXEC_DONE_IS_DISPUTED] ON [neptune].[WF_STEP_EXEC_DONE] ([IS_DISPUTED]);
GO

CREATE INDEX [IX_WF_STEP_EXEC_DONE_IS_SUCCESS] ON [neptune].[WF_STEP_EXEC_DONE] ([IS_SUCCESS]);
GO

CREATE INDEX [IX_WF_STEP_EXEC_DONE_IS_TIMEOUT] ON [neptune].[WF_STEP_EXEC_DONE] ([IS_TIMEOUT]);
GO

CREATE INDEX [IX_WF_STEP_EXEC_DONE_P1_FINISH] ON [neptune].[WF_STEP_EXEC_DONE] ([P1_FINISH]);
GO

CREATE INDEX [IX_WF_STEP_EXEC_DONE_P1_START] ON [neptune].[WF_STEP_EXEC_DONE] ([P1_START]);
GO

CREATE INDEX [IX_WF_STEP_EXEC_DONE_P1_STATUS] ON [neptune].[WF_STEP_EXEC_DONE] ([P1_STATUS]);
GO

CREATE INDEX [IX_WF_STEP_EXEC_DONE_P2_FINISH] ON [neptune].[WF_STEP_EXEC_DONE] ([P2_FINISH]);
GO

CREATE INDEX [IX_WF_STEP_EXEC_DONE_P2_START] ON [neptune].[WF_STEP_EXEC_DONE] ([P2_START]);
GO

CREATE INDEX [IX_WF_STEP_EXEC_DONE_P2_STATUS] ON [neptune].[WF_STEP_EXEC_DONE] ([P2_STATUS]);
GO

CREATE INDEX [IX_WF_STEP_EXEC_DONE_P3_FINISH] ON [neptune].[WF_STEP_EXEC_DONE] ([P3_FINISH]);
GO

CREATE INDEX [IX_WF_STEP_EXEC_DONE_P3_START] ON [neptune].[WF_STEP_EXEC_DONE] ([P3_START]);
GO

CREATE INDEX [IX_WF_STEP_EXEC_DONE_P3_STATUS] ON [neptune].[WF_STEP_EXEC_DONE] ([P3_STATUS]);
GO

CREATE INDEX [IX_WF_STEP_EXEC_DONE_STEP_CODE] ON [neptune].[WF_STEP_EXEC_DONE] ([STEP_CODE]);
GO

CREATE INDEX [IX_WF_STEP_EXEC_DONE_WORKFLOW_ID] ON [neptune].[WF_STEP_EXEC_DONE] ([WORKFLOW_ID]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221024014636_v1', N'6.0.10');
GO

COMMIT;
GO
```

## 6. Insert data `neptune`

```sql
UPDATE [neptune].[ENVIRONMENT_VARIABLE] SET E1 = 'rabbitmq' WHERE [neptune].[ENVIRONMENT_VARIABLE].[VARIABLE_NAME] = 'MESSAGE_BROKER_HOSTNAME';
UPDATE [neptune].[ENVIRONMENT_VARIABLE] SET E1 = 'guest' WHERE [neptune].[ENVIRONMENT_VARIABLE].[VARIABLE_NAME] = 'MESSAGE_BROKER_USERNAME';
UPDATE [neptune].[ENVIRONMENT_VARIABLE] SET E1 = 'guest' WHERE [neptune].[ENVIRONMENT_VARIABLE].[VARIABLE_NAME] = 'MESSAGE_BROKER_PASSWORD';

Truncate table "neptune"."SERVICE_DEF";

INSERT INTO "neptune"."SERVICE_DEF" ("SERVICE_ID", "SERVICE_CODE", "SERVICE_NAME", "STATUS", "QUEUE_NAME", "ACCEPT_TIME", "GRPC_STATUS", "GRPC_TIMEOUT", "GRPC_URL", "EVENT_REGISTRATION", "IMPORT_EXPORT_STEP_CODE", "CONCURRENT_THREADS", "SERVICE_INSTANCE_TYPE") VALUES
('408086f63fff49099a6105f67597b79a', 'MS2', 'micro service 2', 'Active', 'queue-ms2', 0, 'Active', 60, '', 'No', 'No', 8, 'Stateless'),
('45a07163c0254ba9829cba198039f549', 'NEMS', 'Neptune Event Management System', 'Active', 'queue-NEMS', 0, 'Active', 60, '', 'Mine', 'No', 8, 'Stateless'),
('5c0306445e3a4b02974737ec15206f11', 'MS1', 'micro service 1', 'Active', 'queue-ms1', 1656563981489, 'Active', 60, 'https://192.168.3.56:44381/', 'No', 'Yes', 8, 'Stateless'),
('ACT', 'ACT', 'Accounting service', 'Active', 'queue-act', 1668068124848, 'Active', 60, 'https://accounting.api:5000', 'Mine', 'Yes', 8, 'Stateless'),
('ADM', 'ADM', 'Admin service', 'Active', 'queue-adm', 1668068088445, 'Active', 60, 'https://admin.api:5000', 'Mine', 'Yes', 8, 'Stateless'),
('BCH', 'BCH', 'Batch service', 'Active', 'queue-bch', 1668068099585, 'Active', 60, 'https://batch.api:5000', 'Mine', 'Yes', 8, 'Stateless'),
('CMS', 'CMS', 'CMS service', 'Active', 'queue-cms', 1668068130686, 'Active', 60, 'https://cms.api:5000', 'Always', 'Yes', 8, 'Stateful'),
('CRD', 'CRD', 'Credit service', 'Active', 'queue-crd', 1668068100537, 'Active', 60, 'https://credit.api:5000', 'Mine', 'Yes', 8, 'Stateless'),
('CSH', 'CSH', 'Cash service', 'Active', 'queue-csh', 1668068096890, 'Active', 60, 'https://cash.api:5000', 'Mine', 'Yes', 8, 'Stateless'),
('CTM', 'CTM', 'Customer service', 'Active', 'queue-ctm', 1668068095290, 'Active', 60, 'https://customer.api:5000', 'Mine', 'Yes', 8, 'Stateless'),
('DPT', 'DPT', 'Deposit service', 'Active', 'queue-dpt', 1668068098204, 'Active', 60, 'https://deposit.api:5000', 'Mine', 'Yes', 8, 'Stateless'),
('FAC', 'FAC', 'Fixed Asset service', 'Active', 'queue-fac', 1668068100665, 'Active', 60, 'https://fixedasset.api:5000', 'Mine', 'Yes', 8, 'Stateless'),
('FX', 'FX', 'Foreign Exchange service', 'Active', 'queue-fx', 1668068096771, 'Active', 60, 'https://fx.api:5000', 'Mine', 'Yes', 8, 'Stateless'),
('IFC', 'IFC', 'IFC service', 'Active', 'queue-ifc', 1668068099174, 'Active', 60, 'https://ifc.api:5000', 'Mine', 'Yes', 8, 'Stateless'),
('MTG', 'MTG', 'Mortgage service', 'Active', 'queue-mtg', 1668068099805, 'Active', 60, 'https://mortgage.api:5000', 'Mine', 'Yes', 8, 'Stateless'),
('PMT', 'PMT', 'Payment service', 'Active', 'queue-pmt', 1668068098374, 'Active', 60, 'https://payment.api:5000', 'Mine', 'Yes', 8, 'Stateless'),
('SPL', 'SPL', 'Sample service', 'Active', 'queue-spl', 0, 'Active', 60, '', 'Mine', 'Yes', 8, 'Stateless'),
('VCH', 'VCH', 'Voucher service', 'Active', 'queue-vch', 1668068095098, 'Active', 60, 'https://voucher.api:5000', 'Mine', 'Yes', 8, 'Stateless');
```

## Exception

### Unhandled exception. System.AggregateException: One or more errors occurred. (SqlDateTime overflow. Must be between 1/1/1753 12:00:00 AM and 12/31/9999 11:59:59 PM.)

Change `datetime` to `datetime2`

### Give full access to mssql volume

Check id for mssql user on docker image

```
sudo docker run -it mcr.microsoft.com/mssql/server id mssql
```

gives: uid=10001(mssql) gid=0(root) groups=0(root)
Change folder’s owner

```
sudo chown 10001 VOLUME_DIRECTORY
```

VOLUME_DIRECTORY: /home/sqlserver-data/

Source in Spanish: https://www.eiximenis.dev/posts/2020-06-26-sql-server-docker-no-se-ejecuta-en-root/ 3. Give a full access (not recommended)
Give full access to db files on host

```
sudo chmod 777 -R VOLUME_DIRECTORY
```

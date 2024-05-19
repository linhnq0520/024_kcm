# 1. Prepare file for first time

## A. Get source code at local

```cmd
git pull
```

## B. Build dotnet

Build dotnet publish to the path

```cmd
dotnet publish Jits.Neptune.Web.Accounting/Jits.Neptune.Web.Accounting.csproj -c Release -o ShareFiles/accounting/publish
dotnet publish Jits.Neptune.Web.Admin/Jits.Neptune.Web.Admin.csproj -c Release -o ShareFiles/admin/publish
dotnet publish Jits.Neptune.Web.Batch/Jits.Neptune.Web.Batch.csproj -c Release -o ShareFiles/batch/publish
dotnet publish Jits.Neptune.Web.Cash/Jits.Neptune.Web.Cash.csproj -c Release -o ShareFiles/cash/publish
dotnet publish Jits.Neptune.Web.Credit/Jits.Neptune.Web.Credit.csproj -c Release -o ShareFiles/credit/publish
dotnet publish Jits.Neptune.Web.Customer/Jits.Neptune.Web.Customer.csproj -c Release -o ShareFiles/customer/publish
dotnet publish Jits.Neptune.Web.Deposit/Jits.Neptune.Web.Deposit.csproj -c Release -o ShareFiles/deposit/publish
dotnet publish Jits.Neptune.Web.FixedAsset/Jits.Neptune.Web.FixedAsset.csproj -c Release -o ShareFiles/fixedasset/publish
dotnet publish Jits.Neptune.Web.FX/Jits.Neptune.Web.FX.csproj -c Release -o ShareFiles/fx/publish
dotnet publish Jits.Neptune.Web.Mortgage/Jits.Neptune.Web.Mortgage.csproj -c Release -o ShareFiles/mortgage/publish
dotnet publish Jits.Neptune.Web.Payment/Jits.Neptune.Web.Payment.csproj -c Release -o ShareFiles/payment/publish
dotnet publish Jits.Neptune.Web.Voucher/Jits.Neptune.Web.Voucher.csproj -c Release -o ShareFiles/voucher/publish
dotnet publish Jits.Neptune.Web.CMS/Jits.Neptune.Web.CMS.csproj -c Release -o ShareFiles/cms/publish
dotnet publish Jits.Neptune.Web.Report/Jits.Neptune.Web.Report.csproj -c Release -o ShareFiles/report/publish
dotnet publish Jits.Neptune.Web.EMS/Jits.Neptune.Web.EMS.csproj -c Release -o ShareFiles/ems/publish
dotnet publish Jits.Neptune.Web.Email/Jits.Neptune.Web.Email.csproj -c Release -o ShareFiles/email/publish
dotnet publish Jits.Neptune.Web.Import/Jits.Neptune.Web.Import.csproj -c Release -o ShareFiles/import/publish
dotnet publish Jits.Neptune.Web.Card/Jits.Neptune.Web.Card.csproj -c Release -o ShareFiles/card/publish
dotnet publish Jits.Neptune.Web.Party/Jits.Neptune.Web.Party.csproj -c Release -o ShareFiles/party/publish

```

## C. Config, copy and zip

### Config (/ShareFiles/docker-compose.sqlserver.yml)

- Config note <b>neptunedb_sqlserver</b> (if using docker image sqlserver)
- Config note <b>neptuneserver:</b> <b>environment:</b> <b>NEPTUNE_DB_ONLINE_SERVER_NAME:</b>

ex1: NEPTUNE_DB_ONLINE_SERVER_NAME=neptunedb_sqlserver (if using docker image sqlserver)

ex2: NEPTUNE_DB_ONLINE_SERVER_NAME=192.168.1.178 (if using seperate db sqlserver)

- Config note <b>depends_on:</b> if dont using docker image sqlserver, delete row <b>neptunedb_sqlserver</b>

- Config services notes <b>accounting.api:</b> , <b>admin.api:</b> , <b>cash.api:</b> , .... etc : Config note <b>enviroment:</b> and remember delete on note <b>depends_on:</b> :

```
### Remember setup right port and right database
- ConnectionStrings:ConnectionString=server=192.168.1.178,1433;database=o9accounting;user id=o9accounting;password=o9accounting;TrustServerCertificate=true
- ConnectionStrings:DataProvider=sqlserver
```

### Copy file and zip

Copy ShareFiles and zip to a file

## D. Build mcr tar file

On your computer run cmd

```cmd
docker pull mcr.microsoft.com/dotnet/aspnet:6.0-alpine
docker save --output aspnet6.tar mcr.microsoft.com/dotnet/aspnet:6.0-alpine
```

And then we have file <aspnet6.tar>

# 2. Deploy files

Must have 2 file:

- Zip of Share File
- <aspnet6.tar>

## A. Copy files to server

On your computer, run cmd
ex:

```cmd
scp "E:\File\ShareFiles.zip" jits@192.168.1.179:/root
scp "E:\File\aspnet6.tar" jits@192.168.1.179:/root
```

On server, remove ShareFiles than unzip
unzip ShareFiles:

```cmd
rm -r -f /ShareFiles
unzip ShareFiles.zip
```

unzip aspnet6 then tag:

```cmd
docker load --input aspnet6.tar
docker tag mcr.microsoft.com/dotnet/aspnet:6.0-alpine aspnet6
```

- check image must have aspnet6

## B. Deploy

Go to ShareFiles
run neptuneserver first

```cmd
docker compose -f ./docker-compose.sqlserver.yml up -d --build neptuneserver
```

run other service

```cmd
docker compose -f ./docker-compose.sqlserver.yml up -d --build accounting.api admin.api batch.api cash.api  customer.api deposit.api fixedasset.api fx.api ifc.api mortgage.api payment.api voucher.api report.api ems.api email.api credit.api redis cms.api redis
```

# 3. Deploy, build

## A. Check version deploy

Build new version service

- Make sure that service run normally by running unit test first
- Git pull and dotnet publish (https://hcm.jits.com.vn:8062/rndhcm/cbs-shwe/-/tree/develop/src/ShareFiles)

Deploy publish file to update service version
Ex: Update admin service to server
Step1: build pushlish file
Step2: transfer to .zip file
Step3: copy right path on server: ~./ShareFiles/admin
Step4: remove publish rm -r -f /publish
Step5: check /publish file exist use 'ls' command
Step6: unzip file publish use 'unzip + {filezipname}' command. Ex: unzip shwebank_v1.1.zip
Step7: go out side admin use 'cd ..'
Step8: build docker admin. Ex: 'docker compose -f ./docker-compose.sqlserver.yml up -d --build admin.api'
Step9: check portainer on port 9040 to make sure that service is start

## B. Migrate Data

Migrate data in CMS, Report, Admin
Go swagger like:
https://192.168.1.170:8066/api/index.html
Choose migration table that you want to copy data
Export data

Go swagger on server
Import that file and run

## C. Config Quick CMS After Start

Go table ParaServer, change Value at row:

| Code          | Value                                        |
| ------------- | -------------------------------------------- |
| REPORT_URL    | https://{ip_address}:{port}/View/Reports/    |
| VOUCHER_URL   | https://{ip_address}:{port}/View/Vouchers/   |
| DASHBOARD_URL | https://{ip_address}:{port}/View/Dashboards/ |

Go table Setting, change Value at row:

| Code                       | Value                             |
| -------------------------- | --------------------------------- |
| CMSSetting.Hostport        | :8066                             |
| CMSSetting.TemplateHostDev | https://{ip_address}:{port}/fwcss |

Note:
{port} : 8066 -> cms
{port} : 8067 -> Reports, Vouchers, Dashboards

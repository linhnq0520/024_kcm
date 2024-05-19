## Quy trình build deploy server test

### Chuẩn bị Database

#### Neptune Database

```note
Dành cho project Neptune, không nằm trong nhóm source code của CBS.
```

- Chuyển tới thư mục Workflow, chỉnh lại file `appsettings.json`, cấu hình kết nối tới đúng database.
- Chạy lệnh sau để tạo script tạo database. File script sẽ có tên `1.scripts.sql`

```
dotnet ef migrations script -c OrchestrationDBContext -o 1.scripts.sql
```

#### Create Database

Chạy lần lượt theo thứ tự các script trong thư mục ShareFiles/neptuneserver

- `0.schema_scripts.sql`: dùng cho trường hợp chưa tạo User, cũng như các database.
- `1.scripts.sql`: dùng đề tạo các bảng & dữ liệu cho Neptune, và Neptune Archive.
- `2.data_scripts.sql`: chạy sau khi đã start Neptune server, dùng để setup các service, update lại các thông số tương thích việc chạy theo docker.
- `3.role_scripts.sql`: gán quyền thực thi toàn bộ Workflow cho group Administrator (chạy sau khi setup các service, workflow).

### Clear Nuget

Clear nuget khi update framework

```
dotnet nuget locals all --clear
```

### Build các project Service

- Tại thư mục `src`, run `git pull` để lấy source code mới nhất về.
- Chạy build tuần tự các project.

```
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
dotnet publish Jits.Neptune.Web.Party/Jits.Neptune.Web.Party.csproj -c Release -o ShareFiles/party/publish
dotnet publish Jits.Neptune.Web.Card/Jits.Neptune.Web.Card.csproj -c Release -o ShareFiles/card/publish
dotnet publish Jits.Neptune.Web.ReportManagement/Jits.Neptune.Web.ReportManagement.csproj -c Release -o ShareFiles/reportmanagement/publish
```

- Commit lên git (nếu build không phải tại máy server).
- Tại thư mục ShareFiles, run `docker compose up -d --build <service_name>`.
- Chạy api install các database để đảm bảo các DB connection được thiết lập.

### Chạy recreate cho Service

Trường hợp cần buộc tạo lại container để reset lại config, chạy tạo lại các container:
`docker compose up -d --force-recreate admin.api accounting.api cash.api customer.api deposit.api credit.api fixedasset.api payment.api fx.api mortgage.api voucher.api cms.api report.api ems.api email.api import.api card.api party.api`

USE [o9import]
GO
SET IDENTITY_INSERT [dbo].[Setting] ON 

INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (1, N'WebApiSettings.DeveloperMode', N'true', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (2, N'WebApiSettings.TokenLifetimeDays', N'7', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (3, N'WebApiSettings.SecretKey', N'igTLDRYrrjV88ZAXvF+nSw', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (4, N'ImportSetting.PortalUser', N'neptune', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (5, N'ImportSetting.PortalPassword', N'123456', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (6, N'ImportSetting.MaximumTemplatesPerProcessing', N'2', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (7, N'ImportSetting.MaximumTransactionsPerTemplate', N'200', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (8, N'ImportSetting.ApiUrl', N'{
  "Accounting": "https://localhost:5011/api/MasterTable/Import",
  "Admin": "https://localhost:5013/api/MasterTable/Import",
  "Cash": "https://localhost:5021/api/MasterTable/Import",
  "Credit": "https://localhost:5019/api/MasterTable/Import",
  "Customer": "https://localhost:5023/api/MasterTable/Import",
  "Deposit": "https://localhost:5025/api/MasterTable/Import",
  "Email": "https://localhost:5027/api/MasterTable/Import",
  "EMS": "https://localhost:5029/api/MasterTable/Import",
  "FixedAsset": "https://localhost:5031/api/MasterTable/Import",
  "FX": "https://localhost:5033/api/MasterTable/Import",
  "Mortgage": "https://localhost:5037/api/MasterTable/Import",
  "Payment": "https://localhost:5039/api/MasterTable/Import",
  "Report": "https://localhost:5041/api/MasterTable/Import",
  "Voucher": "https://localhost:5045/api/MasterTable/Import",
  "Card": "https://localhost:5051/api/MasterTable/Import",
  "Party": "https://localhost:5049/api/MasterTable/Import"
}', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (9, N'ImportSetting.UsingGrpc', N'true', 0)
SET IDENTITY_INSERT [dbo].[Setting] OFF
GO

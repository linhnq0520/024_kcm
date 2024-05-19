USE [o9accounting]
GO
SET IDENTITY_INSERT [dbo].[Setting] ON 

INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (1, N'WebApiSettings.DeveloperMode', N'true', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (2, N'WebApiSettings.TokenLifetimeDays', N'7', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (3, N'WebApiSettings.SecretKey', N'igTLDRYrrjV88ZAXvF+nSw', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (4, N'AccountingSettings.DeveloperMode', N'true', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (5, N'AccountingSettings.TokenLifetimeDays', N'7', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (6, N'AccountingSettings.SecretKey', N'abc', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (7, N'AccountingSettings.AccountLeaveLevel', N'9', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (8, N'AccountingSettings.SystemAccountNumberFormat', N'5B3RZ', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (9, N'AccountingSettings.LengthBranch', N'3', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (10, N'AccountingSettings.LengthCurrency', N'3', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (11, N'AccountingSettings.LengthAccountNumber', N'18', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (12, N'AccountingSettings.LengthDepositAccountNumber', N'12', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (13, N'AccountingSettings.AllAccountLevel', N'5', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (14, N'AccountingSettings.AllCurrencyCode', N'AAA', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (15, N'AccountingSettings.CurrentBaseCurrency', N'MMK', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (16, N'AccountingSettings.FormatDate', N'MM/dd/yyyy', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (17, N'AccountingSettings.FX_IBT', N'true', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (18, N'AccountingSettings.EnableBalance', N'true', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (19, N'AccountingSettings.AutoOpenAccount', N'true', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (20, N'AccountingSettings.DurationBackDateNumber', N'0', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (21, N'AccountingSettings.DurationBackDateUnit', N'D', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (22, N'AccountingSettings.SystemLanguage', N'en', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (23, N'AccountingSettings.BackupDirectory', N'/var/opt/mssql/backupdata/', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (24, N'AccountingSettings.AllowPostingWithLevel', N'[9]', 0)
SET IDENTITY_INSERT [dbo].[Setting] OFF
GO

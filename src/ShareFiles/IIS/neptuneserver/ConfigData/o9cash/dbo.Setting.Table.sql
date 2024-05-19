USE [o9cash]
GO
SET IDENTITY_INSERT [dbo].[Setting] ON 

INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (1, N'WebApiSettings.DeveloperMode', N'true', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (2, N'WebApiSettings.TokenLifetimeDays', N'7', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (3, N'WebApiSettings.SecretKey', N'igTLDRYrrjV88ZAXvF+nSw', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (4, N'CashSettings.DeveloperMode', N'true', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (5, N'CashSettings.TokenLifetimeDays', N'7', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (6, N'CashSettings.SecretKey', N'abc', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (7, N'CashSettings.HostBranch', N'999', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (8, N'CashSettings.BackupDirectory', N'/var/opt/mssql/backupdata/', 0)
SET IDENTITY_INSERT [dbo].[Setting] OFF
GO

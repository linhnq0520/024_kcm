USE [o9customer]
GO
SET IDENTITY_INSERT [dbo].[Setting] ON 

INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (1, N'WebApiSettings.DeveloperMode', N'true', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (2, N'WebApiSettings.TokenLifetimeDays', N'7', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (3, N'WebApiSettings.SecretKey', N'igTLDRYrrjV88ZAXvF+nSw', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (4, N'CustomerSettings.DeveloperMode', N'true', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (5, N'CustomerSettings.TokenLifetimeDays', N'7', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (6, N'CustomerSettings.SecretKey', N'abc', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (7, N'CustomerSettings.HostBranch', N'001', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (8, N'CustomerSettings.BaseCurrency', N'MMK', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (9, N'CustomerSettings.CurrentDate', N'09/12/2022', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (10, N'CustomerSettings.CountryCode', N'KH', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (11, N'CustomerSettings.FormatCustomerSingle', N'1A1B6Z', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (12, N'CustomerSettings.FormatCustomerGroup', N'1A1B6Z', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (13, N'CustomerSettings.FormatCustomerLinkage', N'1A1B6Z', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (14, N'CustomerSettings.NullObject', N'XX', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (15, N'CustomerSettings.MediaLimitFileSize', N'2', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (16, N'CustomerSettings.MediaLimitFile', N'30', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (17, N'CustomerSettings.MediaAllowType', N'.img;.png;.jpg;.pdf;', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (18, N'CustomerSettings.BackupDirectory', N'/var/opt/mssql/backupdata/', 0)
SET IDENTITY_INSERT [dbo].[Setting] OFF
GO

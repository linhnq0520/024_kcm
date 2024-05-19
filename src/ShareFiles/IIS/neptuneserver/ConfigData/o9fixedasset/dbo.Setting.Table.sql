USE [o9fixedasset]
GO
SET IDENTITY_INSERT [dbo].[Setting] ON 

INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (1, N'WebApiSettings.DeveloperMode', N'true', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (2, N'WebApiSettings.TokenLifetimeDays', N'7', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (3, N'WebApiSettings.SecretKey', N'igTLDRYrrjV88ZAXvF+nSw', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (4, N'FixedAssetSettings.CatcdFmt', N'10Z', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (5, N'FixedAssetSettings.AcnoFmt', N'3B1T2A2C6Z1K', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (6, N'FixedAssetSettings.DefAcnoFmt', N'5B3R3M8Z', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (7, N'FixedAssetSettings.FACBaseCurrency', N'MMK', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (8, N'FixedAssetSettings.BackupDirectory', N'/var/opt/mssql/backupdata/', 0)
SET IDENTITY_INSERT [dbo].[Setting] OFF
GO

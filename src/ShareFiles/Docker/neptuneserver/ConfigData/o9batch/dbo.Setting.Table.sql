USE [o9batch]
GO
SET IDENTITY_INSERT [dbo].[Setting] ON 

INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (1, N'WebApiSettings.DeveloperMode', N'true', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (2, N'WebApiSettings.TokenLifetimeDays', N'7', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (3, N'WebApiSettings.SecretKey', N'igTLDRYrrjV88ZAXvF+nSw', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (4, N'BatchSettings.DenomCheckAmount', N'1', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (5, N'BatchSettings.BatchMode', N'0', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (6, N'BatchSettings.CheckBranchesClosed', N'0', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (7, N'BatchSettings.CheckPendingTrans', N'1', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (8, N'BatchSettings.CheckDenomAtBranch', N'0', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (9, N'BatchSettings.CheckDenomAtHo', N'0', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (10, N'BatchSettings.PortalUser', N'admin', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (11, N'BatchSettings.PortalPassword', N'123456', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (12, N'BatchSettings.CoreUser', N'admin', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (13, N'BatchSettings.CorePassword', N'123456', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (14, N'SecuritySetting.EncryptionKey', N'273ece6f97dd844d', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (15, N'WebApiSettings.DeveloperMode', N'true', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (16, N'WebApiSettings.TokenLifetimeDays', N'7', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (17, N'WebApiSettings.SecretKey', N'igTLDRYrrjV88ZAXvF+nSw', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (18, N'BatchSettings.StaticTokenPortal', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJOZXB0dW5lIGFkbWluaXN0cmF0b3IiLCJqdGkiOiIyYmY5OTYzYS1kZDY1LTRiYjYtYWMzZS1jZTRhZTUyMTYyM2UiLCJhdXRoX3RpbWUiOiIxNjcxMTU5OTMzODM0IiwidWlkIjoiZTI2MTAxOGY0NzAzNGRiOWIwZjM5NGI4OWFkYmIyMTQiLCJvaWQiOiIxODliZTk5NzU5ZDU0NDZjODAwZTZiNjIwNjUyZTMxYSIsImxhbmciOiJlbiIsInJvbGVzIjoiQURNSU5JU1RSQVRPUiIsImV4cCI6MjAzMTE1OTkzMywiaXNzIjoiSnVzdC1Jbi1UaW1lIFNvbHV0aW9ucyBKU0MiLCJhdWQiOiJOZXB0dW5lIn0.axY5XALntvQmGLEbtIUiwpFC7rMMD7wECSLPvX5s1fQ', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (19, N'BatchSettings.StaticTokenCore', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYmYiOiIxNjc5ODg5NDY0IiwiZXhwIjoiMTcxMTQyNTQ2NCIsIlVzZXJJZCI6IjIiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYWMwMSJ9.zUXr9_Ycr1J1kB-X2D7-c4n5yFqXqrOHDblrt4Pbemc', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (20, N'BatchSettings.UsingStaticToken', N'false', 0)
INSERT [dbo].[Setting] ([Id], [Name], [Value], [OrganizationId]) VALUES (21, N'BatchSettings.CheckBankClose', N'true', 0)
SET IDENTITY_INSERT [dbo].[Setting] OFF
GO

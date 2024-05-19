USE [o9voucher]
GO
SET IDENTITY_INSERT [dbo].[ScheduleTask] ON 

INSERT [dbo].[ScheduleTask] ([Id], [Name], [Type], [Seconds], [LastEnabledUtc], [Enabled], [StopOnError], [LastStartUtc], [LastEndUtc], [LastSuccessUtc]) VALUES (1, N'Check queue connection', N'Jits.Neptune.Web.Framework.Services.Queue.KeepConnectionTask, Jits.Neptune.Web.Framework', 60, NULL, 1, 0, CAST(N'2023-09-08T05:58:00.6228190' AS DateTime2), CAST(N'2023-09-08T05:58:00.6302200' AS DateTime2), CAST(N'2023-09-08T05:58:00.6302200' AS DateTime2))
INSERT [dbo].[ScheduleTask] ([Id], [Name], [Type], [Seconds], [LastEnabledUtc], [Enabled], [StopOnError], [LastStartUtc], [LastEndUtc], [LastSuccessUtc]) VALUES (3, N'Clear log', N'Jits.Neptune.Web.Framework.Services.Logging.ClearLogTask, Jits.Neptune.Web.Framework', 3600, NULL, 1, 0, CAST(N'2023-09-08T05:28:24.0073620' AS DateTime2), CAST(N'2023-09-08T05:28:24.2139830' AS DateTime2), CAST(N'2023-09-08T05:28:24.2139830' AS DateTime2))
INSERT [dbo].[ScheduleTask] ([Id], [Name], [Type], [Seconds], [LastEnabledUtc], [Enabled], [StopOnError], [LastStartUtc], [LastEndUtc], [LastSuccessUtc]) VALUES (4, N'Clear cache', N'Jits.Neptune.Web.Framework.Services.Caching.ClearCacheTask, Jits.Neptune.Web.Framework', 3600, NULL, 1, 0, CAST(N'2023-09-08T05:32:37.0070770' AS DateTime2), CAST(N'2023-09-08T05:32:37.0213520' AS DateTime2), CAST(N'2023-09-08T05:32:37.0213520' AS DateTime2))
SET IDENTITY_INSERT [dbo].[ScheduleTask] OFF
GO

USE [o9report]
GO
SET IDENTITY_INSERT [dbo].[ScheduleTask] ON 

INSERT [dbo].[ScheduleTask] ([Id], [Name], [Type], [Seconds], [LastEnabledUtc], [Enabled], [StopOnError], [LastStartUtc], [LastEndUtc], [LastSuccessUtc]) VALUES (1, N'Check queue connection', N'Jits.Neptune.Web.Framework.Services.Queue.KeepConnectionTask, Jits.Neptune.Web.Framework', 60, NULL, 1, 0, CAST(N'2023-09-08T05:57:48.0478780' AS DateTime2), CAST(N'2023-09-08T05:57:48.0523650' AS DateTime2), CAST(N'2023-09-08T05:57:48.0523650' AS DateTime2))
INSERT [dbo].[ScheduleTask] ([Id], [Name], [Type], [Seconds], [LastEnabledUtc], [Enabled], [StopOnError], [LastStartUtc], [LastEndUtc], [LastSuccessUtc]) VALUES (2, N'Clear cache', N'Jits.Neptune.Web.Framework.Services.Caching.ClearCacheTask, Jits.Neptune.Web.Framework', 60, NULL, 1, 0, CAST(N'2023-09-08T05:57:47.5377090' AS DateTime2), CAST(N'2023-09-08T05:57:47.5396970' AS DateTime2), CAST(N'2023-09-08T05:57:47.5396970' AS DateTime2))
INSERT [dbo].[ScheduleTask] ([Id], [Name], [Type], [Seconds], [LastEnabledUtc], [Enabled], [StopOnError], [LastStartUtc], [LastEndUtc], [LastSuccessUtc]) VALUES (3, N'Clear log', N'Jits.Neptune.Web.Framework.Services.Logging.ClearLogTask, Jits.Neptune.Web.Framework', 3600, NULL, 1, 0, CAST(N'2023-09-08T05:41:56.2545040' AS DateTime2), CAST(N'2023-09-08T05:41:56.7181830' AS DateTime2), CAST(N'2023-09-08T05:41:56.7181830' AS DateTime2))
INSERT [dbo].[ScheduleTask] ([Id], [Name], [Type], [Seconds], [LastEnabledUtc], [Enabled], [StopOnError], [LastStartUtc], [LastEndUtc], [LastSuccessUtc]) VALUES (4, N'Sync schedule task data', N'Jits.Neptune.Web.Report.Services.ScheduleTasks.SyncScheduleTasks, Jits.Neptune.Web.Report', 60, NULL, 1, 0, CAST(N'2023-05-11T11:28:52.0393770' AS DateTime2), CAST(N'2023-09-08T05:57:44.3586850' AS DateTime2), CAST(N'2023-05-11T11:27:52.0356260' AS DateTime2))
SET IDENTITY_INSERT [dbo].[ScheduleTask] OFF
GO

USE [o9customer]
GO
SET IDENTITY_INSERT [dbo].[ScheduleTask] ON 

INSERT [dbo].[ScheduleTask] ([Id], [Name], [Type], [Seconds], [LastEnabledUtc], [Enabled], [StopOnError], [LastStartUtc], [LastEndUtc], [LastSuccessUtc]) VALUES (1, N'Check queue connection', N'Jits.Neptune.Web.Framework.Services.Queue.KeepConnectionTask, Jits.Neptune.Web.Framework', 60, NULL, 1, 0, CAST(N'2023-09-08T05:42:46.7748950' AS DateTime2), CAST(N'2023-09-08T05:42:46.7809230' AS DateTime2), CAST(N'2023-09-08T05:42:46.7809230' AS DateTime2))
INSERT [dbo].[ScheduleTask] ([Id], [Name], [Type], [Seconds], [LastEnabledUtc], [Enabled], [StopOnError], [LastStartUtc], [LastEndUtc], [LastSuccessUtc]) VALUES (3, N'Clear log', N'Jits.Neptune.Web.Framework.Services.Logging.ClearLogTask, Jits.Neptune.Web.Framework', 3600, NULL, 1, 0, CAST(N'2023-09-08T05:28:10.8845440' AS DateTime2), CAST(N'2023-09-08T05:28:11.1775660' AS DateTime2), CAST(N'2023-09-08T05:28:11.1775660' AS DateTime2))
INSERT [dbo].[ScheduleTask] ([Id], [Name], [Type], [Seconds], [LastEnabledUtc], [Enabled], [StopOnError], [LastStartUtc], [LastEndUtc], [LastSuccessUtc]) VALUES (4, N'Sync data', N'Jits.Neptune.Web.Customer.Services.ScheduleTasks.SyncTask, Jits.Neptune.Web.Customer', 60, NULL, 1, 0, CAST(N'2023-09-08T05:43:05.8070140' AS DateTime2), CAST(N'2023-09-08T05:43:05.8121720' AS DateTime2), CAST(N'2023-09-08T05:43:05.8121720' AS DateTime2))
INSERT [dbo].[ScheduleTask] ([Id], [Name], [Type], [Seconds], [LastEnabledUtc], [Enabled], [StopOnError], [LastStartUtc], [LastEndUtc], [LastSuccessUtc]) VALUES (5, N'Clear cache', N'Jits.Neptune.Web.Framework.Services.Caching.ClearCacheTask, Jits.Neptune.Web.Framework', 3600, NULL, 1, 0, CAST(N'2023-09-08T05:32:08.8881930' AS DateTime2), CAST(N'2023-09-08T05:32:08.8986180' AS DateTime2), CAST(N'2023-09-08T05:32:08.8986180' AS DateTime2))
SET IDENTITY_INSERT [dbo].[ScheduleTask] OFF
GO

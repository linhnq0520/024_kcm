USE [o9deposit]
GO
SET IDENTITY_INSERT [dbo].[ScheduleTask] ON 

INSERT [dbo].[ScheduleTask] ([Id], [Name], [Type], [Seconds], [LastEnabledUtc], [Enabled], [StopOnError], [LastStartUtc], [LastEndUtc], [LastSuccessUtc]) VALUES (1, N'Check queue connection', N'Jits.Neptune.Web.Framework.Services.Queue.KeepConnectionTask, Jits.Neptune.Web.Framework', 60, NULL, 1, 0, CAST(N'2023-09-08T05:45:23.4508440' AS DateTime2), CAST(N'2023-09-08T05:45:23.4562990' AS DateTime2), CAST(N'2023-09-08T05:45:23.4562990' AS DateTime2))
INSERT [dbo].[ScheduleTask] ([Id], [Name], [Type], [Seconds], [LastEnabledUtc], [Enabled], [StopOnError], [LastStartUtc], [LastEndUtc], [LastSuccessUtc]) VALUES (3, N'Clear log', N'Jits.Neptune.Web.Framework.Services.Logging.ClearLogTask, Jits.Neptune.Web.Framework', 3600, NULL, 1, 0, CAST(N'2023-09-08T05:28:16.8701510' AS DateTime2), CAST(N'2023-09-08T05:28:17.1122280' AS DateTime2), CAST(N'2023-09-08T05:28:17.1122280' AS DateTime2))
INSERT [dbo].[ScheduleTask] ([Id], [Name], [Type], [Seconds], [LastEnabledUtc], [Enabled], [StopOnError], [LastStartUtc], [LastEndUtc], [LastSuccessUtc]) VALUES (4, N'Process fund transfer', N'Jits.Neptune.Web.Deposit.Services.ScheduleTasks.ProccessBatchTransferTask, Jits.Neptune.Web.Deposit', 10, NULL, 1, 0, CAST(N'2023-09-08T05:45:33.9716160' AS DateTime2), CAST(N'2023-09-08T05:45:33.9778710' AS DateTime2), CAST(N'2023-09-08T05:45:33.9778710' AS DateTime2))
INSERT [dbo].[ScheduleTask] ([Id], [Name], [Type], [Seconds], [LastEnabledUtc], [Enabled], [StopOnError], [LastStartUtc], [LastEndUtc], [LastSuccessUtc]) VALUES (5, N'Clear cache', N'Jits.Neptune.Web.Framework.Services.Caching.ClearCacheTask, Jits.Neptune.Web.Framework', 3600, NULL, 1, 0, CAST(N'2023-09-08T05:32:11.8708530' AS DateTime2), CAST(N'2023-09-08T05:32:11.8982140' AS DateTime2), CAST(N'2023-09-08T05:32:11.8982140' AS DateTime2))
SET IDENTITY_INSERT [dbo].[ScheduleTask] OFF
GO

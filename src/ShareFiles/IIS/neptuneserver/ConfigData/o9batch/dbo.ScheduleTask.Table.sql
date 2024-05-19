USE [o9batch]
GO
SET IDENTITY_INSERT [dbo].[ScheduleTask] ON 

INSERT [dbo].[ScheduleTask] ([Id], [Name], [Type], [Seconds], [LastEnabledUtc], [Enabled], [StopOnError], [LastStartUtc], [LastEndUtc], [LastSuccessUtc]) VALUES (1, N'Check queue connection', N'Jits.Neptune.Web.Framework.Services.Queue.KeepConnectionTask, Jits.Neptune.Web.Framework', 60, NULL, 1, 0, CAST(N'2023-09-08T05:34:34.5856590' AS DateTime2), CAST(N'2023-09-08T05:34:34.5918810' AS DateTime2), CAST(N'2023-09-08T05:34:34.5918810' AS DateTime2))
INSERT [dbo].[ScheduleTask] ([Id], [Name], [Type], [Seconds], [LastEnabledUtc], [Enabled], [StopOnError], [LastStartUtc], [LastEndUtc], [LastSuccessUtc]) VALUES (3, N'Clear log', N'Jits.Neptune.Web.Framework.Services.Logging.ClearLogTask, Jits.Neptune.Web.Framework', 3600, NULL, 1, 0, CAST(N'2023-09-08T05:07:21.0569440' AS DateTime2), CAST(N'2023-09-08T05:07:21.2659450' AS DateTime2), CAST(N'2023-09-08T05:07:21.2659450' AS DateTime2))
INSERT [dbo].[ScheduleTask] ([Id], [Name], [Type], [Seconds], [LastEnabledUtc], [Enabled], [StopOnError], [LastStartUtc], [LastEndUtc], [LastSuccessUtc]) VALUES (13, N'Clear cache', N'Jits.Neptune.Web.Framework.Services.Caching.ClearCacheTask, Jits.Neptune.Web.Framework', 3600, NULL, 1, 0, CAST(N'2023-09-08T05:32:01.0571510' AS DateTime2), CAST(N'2023-09-08T05:32:01.0636040' AS DateTime2), CAST(N'2023-09-08T05:32:01.0636040' AS DateTime2))
INSERT [dbo].[ScheduleTask] ([Id], [Name], [Type], [Seconds], [LastEnabledUtc], [Enabled], [StopOnError], [LastStartUtc], [LastEndUtc], [LastSuccessUtc]) VALUES (14, N'Run batch instance', N'Jits.Neptune.Web.Batch.Services.RunBatchTask, Jits.Neptune.Web.Batch', 10, NULL, 1, 0, CAST(N'2023-09-08T05:34:56.3443730' AS DateTime2), CAST(N'2023-09-08T05:34:56.3473960' AS DateTime2), CAST(N'2023-09-08T05:34:56.3473960' AS DateTime2))
SET IDENTITY_INSERT [dbo].[ScheduleTask] OFF
GO

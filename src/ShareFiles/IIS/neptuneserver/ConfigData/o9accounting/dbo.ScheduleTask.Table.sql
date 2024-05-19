USE [o9accounting]
GO
SET IDENTITY_INSERT [dbo].[ScheduleTask] ON 

INSERT [dbo].[ScheduleTask] ([Id], [Name], [Type], [Seconds], [LastEnabledUtc], [Enabled], [StopOnError], [LastStartUtc], [LastEndUtc], [LastSuccessUtc]) VALUES (1, N'Check queue connection', N'Jits.Neptune.Web.Framework.Services.Queue.KeepConnectionTask, Jits.Neptune.Web.Framework', 60, NULL, 1, 0, CAST(N'2023-09-06T05:22:18.8804940' AS DateTime2), CAST(N'2023-09-06T05:22:18.9751590' AS DateTime2), CAST(N'2023-09-06T05:22:18.9751590' AS DateTime2))
INSERT [dbo].[ScheduleTask] ([Id], [Name], [Type], [Seconds], [LastEnabledUtc], [Enabled], [StopOnError], [LastStartUtc], [LastEndUtc], [LastSuccessUtc]) VALUES (2, N'Clear cache', N'Jits.Neptune.Web.Framework.Services.Caching.ClearCacheTask, Jits.Neptune.Web.Framework', 60, NULL, 1, 0, CAST(N'2023-09-06T05:22:14.2792180' AS DateTime2), CAST(N'2023-09-06T05:22:14.2821770' AS DateTime2), CAST(N'2023-09-06T05:22:14.2821770' AS DateTime2))
INSERT [dbo].[ScheduleTask] ([Id], [Name], [Type], [Seconds], [LastEnabledUtc], [Enabled], [StopOnError], [LastStartUtc], [LastEndUtc], [LastSuccessUtc]) VALUES (3, N'Clear log', N'Jits.Neptune.Web.Framework.Services.Logging.ClearLogTask, Jits.Neptune.Web.Framework', 3600, NULL, 1, 0, CAST(N'2023-09-06T05:12:43.2697460' AS DateTime2), CAST(N'2023-09-06T05:12:43.2740300' AS DateTime2), CAST(N'2023-09-06T05:12:43.2740300' AS DateTime2))
SET IDENTITY_INSERT [dbo].[ScheduleTask] OFF
GO

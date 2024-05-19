USE [o9cash]
GO
SET IDENTITY_INSERT [dbo].[ScheduleTask] ON 

INSERT [dbo].[ScheduleTask] ([Id], [Name], [Type], [Seconds], [LastEnabledUtc], [Enabled], [StopOnError], [LastStartUtc], [LastEndUtc], [LastSuccessUtc]) VALUES (1, N'Check queue connection', N'Jits.Neptune.Web.Framework.Services.Queue.KeepConnectionTask, Jits.Neptune.Web.Framework', 60, NULL, 1, 0, CAST(N'2023-09-08T05:36:46.3166900' AS DateTime2), CAST(N'2023-09-08T05:36:46.3207640' AS DateTime2), CAST(N'2023-09-08T05:36:46.3207640' AS DateTime2))
INSERT [dbo].[ScheduleTask] ([Id], [Name], [Type], [Seconds], [LastEnabledUtc], [Enabled], [StopOnError], [LastStartUtc], [LastEndUtc], [LastSuccessUtc]) VALUES (3, N'Clear log', N'Jits.Neptune.Web.Framework.Services.Logging.ClearLogTask, Jits.Neptune.Web.Framework', 3600, NULL, 1, 0, CAST(N'2023-09-08T05:28:04.8226400' AS DateTime2), CAST(N'2023-09-08T05:28:04.9754810' AS DateTime2), CAST(N'2023-09-08T05:28:04.9754810' AS DateTime2))
INSERT [dbo].[ScheduleTask] ([Id], [Name], [Type], [Seconds], [LastEnabledUtc], [Enabled], [StopOnError], [LastStartUtc], [LastEndUtc], [LastSuccessUtc]) VALUES (4, N'Clear cache', N'Jits.Neptune.Web.Framework.Services.Caching.ClearCacheTask, Jits.Neptune.Web.Framework', 3600, NULL, 1, 0, CAST(N'2023-09-08T05:32:05.3284180' AS DateTime2), CAST(N'2023-09-08T05:32:05.3336520' AS DateTime2), CAST(N'2023-09-08T05:32:05.3336520' AS DateTime2))
SET IDENTITY_INSERT [dbo].[ScheduleTask] OFF
GO

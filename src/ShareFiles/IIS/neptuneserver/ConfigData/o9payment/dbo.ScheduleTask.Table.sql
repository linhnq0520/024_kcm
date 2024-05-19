USE [o9payment]
GO
SET IDENTITY_INSERT [dbo].[ScheduleTask] ON 

INSERT [dbo].[ScheduleTask] ([Id], [Name], [Type], [Seconds], [LastEnabledUtc], [Enabled], [StopOnError], [LastStartUtc], [LastEndUtc], [LastSuccessUtc]) VALUES (1, N'Check queue connection', N'Jits.Neptune.Web.Framework.Services.Queue.KeepConnectionTask, Jits.Neptune.Web.Framework', 60, NULL, 1, 0, CAST(N'2023-09-08T05:55:51.7549050' AS DateTime2), CAST(N'2023-09-08T05:55:51.7618560' AS DateTime2), CAST(N'2023-09-08T05:55:51.7618560' AS DateTime2))
INSERT [dbo].[ScheduleTask] ([Id], [Name], [Type], [Seconds], [LastEnabledUtc], [Enabled], [StopOnError], [LastStartUtc], [LastEndUtc], [LastSuccessUtc]) VALUES (3, N'Clear log', N'Jits.Neptune.Web.Framework.Services.Logging.ClearLogTask, Jits.Neptune.Web.Framework', 3600, NULL, 1, 0, CAST(N'2023-09-08T05:28:17.8296510' AS DateTime2), CAST(N'2023-09-08T05:28:18.0346160' AS DateTime2), CAST(N'2023-09-08T05:28:18.0346160' AS DateTime2))
INSERT [dbo].[ScheduleTask] ([Id], [Name], [Type], [Seconds], [LastEnabledUtc], [Enabled], [StopOnError], [LastStartUtc], [LastEndUtc], [LastSuccessUtc]) VALUES (4, N'Clear cache', N'Jits.Neptune.Web.Framework.Services.Caching.ClearCacheTask, Jits.Neptune.Web.Framework', 3600, NULL, 1, 0, CAST(N'2023-09-08T05:32:29.5805650' AS DateTime2), CAST(N'2023-09-08T05:32:29.6026450' AS DateTime2), CAST(N'2023-09-08T05:32:29.6026450' AS DateTime2))
SET IDENTITY_INSERT [dbo].[ScheduleTask] OFF
GO

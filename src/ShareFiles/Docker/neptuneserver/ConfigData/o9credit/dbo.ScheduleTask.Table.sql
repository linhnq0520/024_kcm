USE [o9credit]
GO
SET IDENTITY_INSERT [dbo].[ScheduleTask] ON 

INSERT [dbo].[ScheduleTask] ([Id], [Name], [Type], [Seconds], [LastEnabledUtc], [Enabled], [StopOnError], [LastStartUtc], [LastEndUtc], [LastSuccessUtc]) VALUES (1, N'Check queue connection', N'Jits.Neptune.Web.Framework.Services.Queue.KeepConnectionTask, Jits.Neptune.Web.Framework', 60, NULL, 1, 0, CAST(N'2023-09-08T07:13:28.4608490' AS DateTime2), CAST(N'2023-09-08T07:13:28.4645370' AS DateTime2), CAST(N'2023-09-08T07:13:28.4645370' AS DateTime2))
INSERT [dbo].[ScheduleTask] ([Id], [Name], [Type], [Seconds], [LastEnabledUtc], [Enabled], [StopOnError], [LastStartUtc], [LastEndUtc], [LastSuccessUtc]) VALUES (3, N'Clear log', N'Jits.Neptune.Web.Framework.Services.Logging.ClearLogTask, Jits.Neptune.Web.Framework', 3600, NULL, 1, 0, CAST(N'2023-09-08T06:28:06.1952600' AS DateTime2), CAST(N'2023-09-08T06:28:06.2654450' AS DateTime2), CAST(N'2023-09-08T06:28:06.2654450' AS DateTime2))
INSERT [dbo].[ScheduleTask] ([Id], [Name], [Type], [Seconds], [LastEnabledUtc], [Enabled], [StopOnError], [LastStartUtc], [LastEndUtc], [LastSuccessUtc]) VALUES (4, N'Clear cache', N'Jits.Neptune.Web.Framework.Services.Caching.ClearCacheTask, Jits.Neptune.Web.Framework', 3600, NULL, 1, 0, CAST(N'2023-09-08T06:32:03.0705730' AS DateTime2), CAST(N'2023-09-08T06:32:03.0735730' AS DateTime2), CAST(N'2023-09-08T06:32:03.0735730' AS DateTime2))
SET IDENTITY_INSERT [dbo].[ScheduleTask] OFF
GO

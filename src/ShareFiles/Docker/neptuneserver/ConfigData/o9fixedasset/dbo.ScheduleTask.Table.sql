USE [o9fixedasset]
GO
SET IDENTITY_INSERT [dbo].[ScheduleTask] ON 

INSERT [dbo].[ScheduleTask] ([Id], [Name], [Type], [Seconds], [LastEnabledUtc], [Enabled], [StopOnError], [LastStartUtc], [LastEndUtc], [LastSuccessUtc]) VALUES (1, N'Check queue connection', N'Jits.Neptune.Web.Framework.Services.Queue.KeepConnectionTask, Jits.Neptune.Web.Framework', 60, NULL, 1, 0, CAST(N'2023-09-08T05:50:21.1332950' AS DateTime2), CAST(N'2023-09-08T05:50:21.1389610' AS DateTime2), CAST(N'2023-09-08T05:50:21.1389610' AS DateTime2))
INSERT [dbo].[ScheduleTask] ([Id], [Name], [Type], [Seconds], [LastEnabledUtc], [Enabled], [StopOnError], [LastStartUtc], [LastEndUtc], [LastSuccessUtc]) VALUES (3, N'Clear log', N'Jits.Neptune.Web.Framework.Services.Logging.ClearLogTask, Jits.Neptune.Web.Framework', 3600, NULL, 1, 0, CAST(N'2023-09-08T05:28:16.2422810' AS DateTime2), CAST(N'2023-09-08T05:28:16.4703620' AS DateTime2), CAST(N'2023-09-08T05:28:16.4703620' AS DateTime2))
INSERT [dbo].[ScheduleTask] ([Id], [Name], [Type], [Seconds], [LastEnabledUtc], [Enabled], [StopOnError], [LastStartUtc], [LastEndUtc], [LastSuccessUtc]) VALUES (4, N'Clear cache', N'Jits.Neptune.Web.Framework.Services.Caching.ClearCacheTask, Jits.Neptune.Web.Framework', 3600, NULL, 1, 0, CAST(N'2023-09-08T05:32:21.2336420' AS DateTime2), CAST(N'2023-09-08T05:32:21.2468300' AS DateTime2), CAST(N'2023-09-08T05:32:21.2468300' AS DateTime2))
SET IDENTITY_INSERT [dbo].[ScheduleTask] OFF
GO

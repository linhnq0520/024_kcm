USE [o9import]
GO
SET IDENTITY_INSERT [dbo].[ScheduleTask] ON 

INSERT [dbo].[ScheduleTask] ([Id], [Name], [Type], [Seconds], [LastEnabledUtc], [Enabled], [StopOnError], [LastStartUtc], [LastEndUtc], [LastSuccessUtc]) VALUES (1, N'Check queue connection', N'Jits.Neptune.Web.Framework.Services.Queue.KeepConnectionTask, Jits.Neptune.Web.Framework', 60, NULL, 1, 0, CAST(N'2023-09-08T05:51:43.1954030' AS DateTime2), CAST(N'2023-09-08T05:51:43.2008070' AS DateTime2), CAST(N'2023-09-08T05:51:43.2008070' AS DateTime2))
INSERT [dbo].[ScheduleTask] ([Id], [Name], [Type], [Seconds], [LastEnabledUtc], [Enabled], [StopOnError], [LastStartUtc], [LastEndUtc], [LastSuccessUtc]) VALUES (3, N'Clear log', N'Jits.Neptune.Web.Framework.Services.Logging.ClearLogTask, Jits.Neptune.Web.Framework', 3600, NULL, 1, 0, CAST(N'2023-09-08T05:28:26.4596630' AS DateTime2), CAST(N'2023-09-08T05:28:26.5745470' AS DateTime2), CAST(N'2023-09-08T05:28:26.5745470' AS DateTime2))
INSERT [dbo].[ScheduleTask] ([Id], [Name], [Type], [Seconds], [LastEnabledUtc], [Enabled], [StopOnError], [LastStartUtc], [LastEndUtc], [LastSuccessUtc]) VALUES (4, N'Process Template', N'Jits.Neptune.Web.Import.Services.ScheduleTasks.ProcessTemplateTask, Jits.Neptune.Web.Import', 60, NULL, 1, 0, CAST(N'2023-09-08T05:51:49.8175170' AS DateTime2), CAST(N'2023-09-08T05:51:50.0375440' AS DateTime2), CAST(N'2023-09-08T05:51:50.0375440' AS DateTime2))
INSERT [dbo].[ScheduleTask] ([Id], [Name], [Type], [Seconds], [LastEnabledUtc], [Enabled], [StopOnError], [LastStartUtc], [LastEndUtc], [LastSuccessUtc]) VALUES (5, N'Clear cache', N'Jits.Neptune.Web.Framework.Services.Caching.ClearCacheTask, Jits.Neptune.Web.Framework', 3600, NULL, 1, 0, CAST(N'2023-09-08T05:32:42.4483040' AS DateTime2), CAST(N'2023-09-08T05:32:42.4549170' AS DateTime2), CAST(N'2023-09-08T05:32:42.4549170' AS DateTime2))
SET IDENTITY_INSERT [dbo].[ScheduleTask] OFF
GO

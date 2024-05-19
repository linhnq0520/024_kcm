USE [o9admin]
GO
SET IDENTITY_INSERT [dbo].[ScheduleTask] ON 

INSERT [dbo].[ScheduleTask] ([Id], [Name], [Type], [Seconds], [LastEnabledUtc], [Enabled], [StopOnError], [LastStartUtc], [LastEndUtc], [LastSuccessUtc]) VALUES (1, N'Check queue connection', N'Jits.Neptune.Web.Framework.Services.Queue.KeepConnectionTask, Jits.Neptune.Web.Framework', 60, NULL, 1, 0, CAST(N'2023-09-08T05:32:04.6007630' AS DateTime2), CAST(N'2023-09-08T05:32:04.6070530' AS DateTime2), CAST(N'2023-09-08T05:32:04.6070530' AS DateTime2))
INSERT [dbo].[ScheduleTask] ([Id], [Name], [Type], [Seconds], [LastEnabledUtc], [Enabled], [StopOnError], [LastStartUtc], [LastEndUtc], [LastSuccessUtc]) VALUES (3, N'Clear log', N'Jits.Neptune.Web.Framework.Services.Logging.ClearLogTask, Jits.Neptune.Web.Framework', 3600, NULL, 1, 0, CAST(N'2023-09-08T05:08:56.0900950' AS DateTime2), CAST(N'2023-09-08T05:08:56.3343380' AS DateTime2), CAST(N'2023-09-08T05:08:56.3343380' AS DateTime2))
INSERT [dbo].[ScheduleTask] ([Id], [Name], [Type], [Seconds], [LastEnabledUtc], [Enabled], [StopOnError], [LastStartUtc], [LastEndUtc], [LastSuccessUtc]) VALUES (4, N'Sync ForeignExchangeRate data', N'Jits.Neptune.Web.Admin.Services.ScheduleTasks.SyncForeignExchangeRateTask, Jits.Neptune.Web.Admin', 60, NULL, 1, 0, CAST(N'2023-09-08T05:32:24.4118590' AS DateTime2), CAST(N'2023-09-08T05:32:25.4372830' AS DateTime2), CAST(N'2023-09-08T05:32:25.4372830' AS DateTime2))
INSERT [dbo].[ScheduleTask] ([Id], [Name], [Type], [Seconds], [LastEnabledUtc], [Enabled], [StopOnError], [LastStartUtc], [LastEndUtc], [LastSuccessUtc]) VALUES (5, N'Clear cache', N'Jits.Neptune.Web.Framework.Services.Caching.ClearCacheTask, Jits.Neptune.Web.Framework', 3600, NULL, 1, 0, CAST(N'2023-09-08T05:31:59.0900170' AS DateTime2), CAST(N'2023-09-08T05:31:59.1090340' AS DateTime2), CAST(N'2023-09-08T05:31:59.1090340' AS DateTime2))
SET IDENTITY_INSERT [dbo].[ScheduleTask] OFF
GO

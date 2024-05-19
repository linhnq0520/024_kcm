USE [o9batch]
GO
SET IDENTITY_INSERT [dbo].[NeptuneService] ON 

INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (91, N'JOB_CREATE_BATCH_INSTANCE', N'Jits.Neptune.Web.Batch.Services.Workflow.BatchQueueService', N'CreateBatchInstance', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (92, N'JOB_LIST_ALL_INSTANCES', N'Jits.Neptune.Web.Batch.Services.Workflow.BatchQueueService', N'ListAllJobIntances', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (93, N'JOB_LIST_JOB_DETAILS', N'Jits.Neptune.Web.Batch.Services.Workflow.BatchQueueService', N'ListJobDetails', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (94, N'JOB_LIST_ERROR_DETAILS', N'Jits.Neptune.Web.Batch.Services.Workflow.BatchQueueService', N'ListErrorDetails', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (95, N'JOB_START_JOB', N'Jits.Neptune.Web.Batch.Services.Workflow.BatchQueueService', N'StartJob', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (96, N'JOB_STOP_JOB', N'Jits.Neptune.Web.Batch.Services.Workflow.BatchQueueService', N'StopJob', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (97, N'BATCH_JOB_STOP_AT', N'Jits.Neptune.Web.Batch.Services.Workflow.BatchQueueService', N'BatchJobStopAt', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (98, N'BATCH_JOB_RUNNING', N'Jits.Neptune.Web.Batch.Services.Workflow.BatchQueueService', N'BatchJobRunning', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (99, N'BCH_CHECK_RUN_BATCH', N'Jits.Neptune.Web.Batch.Services.Workflow.BatchQueueService', N'CheckRunBatch', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (100, N'BCH_SET_STEP_NAME_CHECKED', N'Jits.Neptune.Web.Batch.Services.Workflow.BatchQueueService', N'SetStepNameChecked', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (101, N'SQL_SIMPLE_SEARCH_CODE_LIST', N'Jits.Neptune.Web.Batch.Services.Workflow.CodeListQueueService', N'SimpleSearch', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (102, N'SQL_ADVANCED_SEARCH_CODE_LIST', N'Jits.Neptune.Web.Batch.Services.Workflow.CodeListQueueService', N'AdvancedSearch', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (103, N'SQL_INSERT_CODE_LIST', N'Jits.Neptune.Web.Batch.Services.Workflow.CodeListQueueService', N'Insert', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (104, N'SQL_VIEW_CODE_LIST_BY_PRIMARY_KEY', N'Jits.Neptune.Web.Batch.Services.Workflow.CodeListQueueService', N'ViewByPrimaryKey', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (105, N'SQL_UPDATE_CODE_LIST_BY_PRIMARY_KEY', N'Jits.Neptune.Web.Batch.Services.Workflow.CodeListQueueService', N'UpdateByPrimaryKey', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (106, N'SQL_DELETE_CODE_LIST_BY_PRIMARY_KEY', N'Jits.Neptune.Web.Batch.Services.Workflow.CodeListQueueService', N'DeleteByPrimaryKey', 0)
SET IDENTITY_INSERT [dbo].[NeptuneService] OFF
GO

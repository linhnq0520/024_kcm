USE [o9import]
GO
SET IDENTITY_INSERT [dbo].[NeptuneService] ON 

INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (1, N'IMP_SIMPLE_SEARCH_TRANSACTION_TEMPLATE', N'Jits.Neptune.Web.Import.Services.Workflow.TemplateQueueService', N'SimpleSearchTransactionTemplate', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (2, N'IMP_VIEW_TRANSACTION_TEMPLATE_DETAIL', N'Jits.Neptune.Web.Import.Services.Workflow.TemplateQueueService', N'ViewTransactionTemplateDetail', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (3, N'IMP_VIEW_TRANSACTION_TEMPLATE', N'Jits.Neptune.Web.Import.Services.Workflow.TemplateQueueService', N'ViewTransactionTemplate', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (4, N'IMP_SAVE_TRANSACTION_TEMPLATE', N'Jits.Neptune.Web.Import.Services.Workflow.TemplateQueueService', N'SaveTransactionTemplate', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (5, N'IMP_APPROVE_TRANSACTION_TEMPLATE', N'Jits.Neptune.Web.Import.Services.Workflow.TemplateQueueService', N'ApproveTransactionTemplate', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (6, N'IMP_REJECT_TRANSACTION_TEMPLATE', N'Jits.Neptune.Web.Import.Services.Workflow.TemplateQueueService', N'RejectTransactionTemplate', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (7, N'IMP_DELETE_TRANSACTION_TEMPLATE', N'Jits.Neptune.Web.Import.Services.Workflow.TemplateQueueService', N'DeleteTransactionTemplate', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (8, N'IMP_REVIEW_TRANSACTION_TEMPLATE ', N'Jits.Neptune.Web.Import.Services.Workflow.TemplateQueueService', N'ReviewTransactionTemplate', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (9, N'IMP_SIMPLE_SEARCH_MASTER_TABLE_TEMPLATE ', N'Jits.Neptune.Web.Import.Services.Workflow.TemplateQueueService', N'SimpleSearchMasterTableTemplate', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (10, N'IMP_VIEW_MASTER_TABLE_TEMPLATE', N'Jits.Neptune.Web.Import.Services.Workflow.TemplateQueueService', N'ViewMasterTableTemplate', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (11, N'IMP_IMPORT_MASTER_TABLE_TEMPLATE', N'Jits.Neptune.Web.Import.Services.Workflow.TemplateQueueService', N'ImportMasterTableTemplate', 0)
SET IDENTITY_INSERT [dbo].[NeptuneService] OFF
GO

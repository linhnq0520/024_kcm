USE [o9cms]
GO
SET IDENTITY_INSERT [dbo].[NeptuneService] ON 

INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (1, N'CMS_SETTING_ADD', N'Jits.Neptune.Web.CMS.Services.Workflow.CMSSettingQueueService', N'Create', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (2, N'CMS_SETTING_UPDATE', N'Jits.Neptune.Web.CMS.Services.Workflow.CMSSettingQueueService', N'Update', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (3, N'CMS_SETTING_DELETE', N'Jits.Neptune.Web.CMS.Services.Workflow.CMSSettingQueueService', N'Delete', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (4, N'CMS_SETTING_VIEW', N'Jits.Neptune.Web.CMS.Services.Workflow.CMSSettingQueueService', N'View', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (5, N'CMS_SETTING_SEARCH', N'Jits.Neptune.Web.CMS.Services.Workflow.CMSSettingQueueService', N'SimpleSearch', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (6, N'CMS_SETTING_ADSEARCH', N'Jits.Neptune.Web.CMS.Services.Workflow.CMSSettingQueueService', N'AdvanceSearch', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (1006, N'CMS_LIST_AUDIT_SETTING', N'Jits.Neptune.Web.CMS.Services.Workflow.CMSSettingQueueService', N'GetListAuditSetting', 0)
SET IDENTITY_INSERT [dbo].[NeptuneService] OFF
GO

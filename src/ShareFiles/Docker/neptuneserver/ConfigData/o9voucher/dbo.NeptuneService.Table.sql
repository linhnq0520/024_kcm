USE [o9voucher]
GO
SET IDENTITY_INSERT [dbo].[NeptuneService] ON 

INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (1, N'VOUCHER', N'Jits.Neptune.Web.Voucher.Services.VoucherQueueService', N'Voucher', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (2, N'VCH_SETTING_ADD', N'Jits.Neptune.Web.Voucher.Services.VoucherSettingQueueService', N'Create', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (3, N'VCH_SETTING_UPDATE', N'Jits.Neptune.Web.Voucher.Services.VoucherSettingQueueService', N'Update', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (4, N'VCH_SETTING_DELETE', N'Jits.Neptune.Web.Voucher.Services.VoucherSettingQueueService', N'Delete', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (5, N'VCH_SETTING_VIEW', N'Jits.Neptune.Web.Voucher.Services.VoucherSettingQueueService', N'View', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (6, N'VCH_SETTING_SEARCH', N'Jits.Neptune.Web.Voucher.Services.VoucherSettingQueueService', N'SimpleSearch', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (7, N'VCH_SETTING_ADSEARCH', N'Jits.Neptune.Web.Voucher.Services.VoucherSettingQueueService', N'AdvanceSearch', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (8, N'VCH_LIST_AUDIT_SETTING', N'Jits.Neptune.Web.Voucher.Services.VoucherSettingQueueService', N'GetListAuditSetting', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (9, N'VOUCHER_A4', N'Jits.Neptune.Web.Voucher.Services.VoucherQueueService', N'GetVoucherA4', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (10, N'VOUCHER_A5', N'Jits.Neptune.Web.Voucher.Services.VoucherQueueService', N'GetVoucherA5', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (11, N'SQL_INSERT_CODE_LIST', N'Jits.Neptune.Web.Voucher.Services.CodeListQueueService', N'Insert', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (12, N'SQL_VIEW_CODE_LIST', N'Jits.Neptune.Web.Voucher.Services.CodeListQueueService', N'View', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (13, N'SQL_DELETE_CODE_LIST', N'Jits.Neptune.Web.Voucher.Services.CodeListQueueService', N'Delete', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (14, N'SQL_UPDATE_CODE_LIST', N'Jits.Neptune.Web.Voucher.Services.CodeListQueueService', N'Update', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (15, N'SQL_SIMPLE_SEARCH_CODE_LIST', N'Jits.Neptune.Web.Voucher.Services.CodeListQueueService', N'SimpleSearch', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (16, N'SQL_ADVANCED_SEARCH_CODE_LIST', N'Jits.Neptune.Web.Voucher.Services.CodeListQueueService', N'AdvancedSearch', 0)
SET IDENTITY_INSERT [dbo].[NeptuneService] OFF
GO

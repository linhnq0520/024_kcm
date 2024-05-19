USE [o9accounting]
GO
SET IDENTITY_INSERT [dbo].[NeptuneService] ON 

INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (1, N'ACT_SETTING_ADD', N'Jits.Neptune.Web.Accounting.Services.AccountingSettingQueueService', N'Create', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (2, N'ACT_SETTING_UPDATE', N'Jits.Neptune.Web.Accounting.Services.AccountingSettingQueueService', N'Update', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (3, N'ACT_SETTING_DELETE', N'Jits.Neptune.Web.Accounting.Services.AccountingSettingQueueService', N'Delete', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (4, N'ACT_SETTING_VIEW', N'Jits.Neptune.Web.Accounting.Services.AccountingSettingQueueService', N'View', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (5, N'ACT_SETTING_SEARCH', N'Jits.Neptune.Web.Accounting.Services.AccountingSettingQueueService', N'SimpleSearch', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (6, N'ACT_SETTING_ADSEARCH', N'Jits.Neptune.Web.Accounting.Services.AccountingSettingQueueService', N'AdvanceSearch', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (7, N'ACT_LIST_AUDIT_SETTING', N'Jits.Neptune.Web.Accounting.Services.AccountingSettingQueueService', N'GetListAuditSetting', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (8, N'SQL_INSERT_ACCOM', N'Jits.Neptune.Web.Accounting.Services.AccountCommonQueueService', N'Create', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (9, N'SQL_UPDATE_ACCOM', N'Jits.Neptune.Web.Accounting.Services.AccountCommonQueueService', N'Update', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (10, N'SQL_DELETE_ACCOM', N'Jits.Neptune.Web.Accounting.Services.AccountCommonQueueService', N'Delete', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (11, N'SQL_VIEW_ACCOM', N'Jits.Neptune.Web.Accounting.Services.AccountCommonQueueService', N'View', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (12, N'SQL_SER_SIMPLE_ACCOM', N'Jits.Neptune.Web.Accounting.Services.AccountCommonQueueService', N'SimpleSearch', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (13, N'SQL_SER_ADVANCE_ACCOM', N'Jits.Neptune.Web.Accounting.Services.AccountCommonQueueService', N'AdvanceSearch', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (14, N'ACT_ACCOM_ACTIVITY', N'Jits.Neptune.Web.Accounting.Services.AccountCommonQueueService', N'GetListAuditAccount', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (15, N'SQL_INSERT_ACCHRT', N'Jits.Neptune.Web.Accounting.Services.AccountChartQueueService', N'Create', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (16, N'SQL_UPDATE_ACCHRT', N'Jits.Neptune.Web.Accounting.Services.AccountChartQueueService', N'Update', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (17, N'SQL_DELETE_ACCHRT', N'Jits.Neptune.Web.Accounting.Services.AccountChartQueueService', N'Delete', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (18, N'SQL_VIEW_ACCHRT', N'Jits.Neptune.Web.Accounting.Services.AccountChartQueueService', N'View', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (19, N'SQL_SER_SIMPLE_ACCHRT', N'Jits.Neptune.Web.Accounting.Services.AccountChartQueueService', N'SimpleSearch', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (20, N'SQL_SER_ADVANCE_ACCHRT', N'Jits.Neptune.Web.Accounting.Services.AccountChartQueueService', N'AdvanceSearch', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (21, N'SQL_ACCHRT_LOOKUP', N'Jits.Neptune.Web.Accounting.Services.AccountChartQueueService', N'Lookup', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (22, N'SQL_ACCHRT_RULEFUNC_BANKACNO', N'Jits.Neptune.Web.Accounting.Services.AccountChartQueueService', N'GetInforByBankAccountNumber', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (23, N'SQL_ACCHRT_RULEFUNC_BANKACNO_BRANCHID', N'Jits.Neptune.Web.Accounting.Services.AccountChartQueueService', N'GetInforByBankAccountNumber1', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (24, N'SQL_ACCHRT_LOOKUP_BY_CURRENCY', N'Jits.Neptune.Web.Accounting.Services.AccountChartQueueService', N'LookupByCurrency', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (25, N'SQL_ACCHRT_LOOKUP_BY_BRANCHID', N'Jits.Neptune.Web.Accounting.Services.AccountChartQueueService', N'LookupByBranchCode', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (26, N'SQL_ACCHRT_LOOKUP_BY_BRANCHID_DEPOSITACC', N'Jits.Neptune.Web.Accounting.Services.AccountChartQueueService', N'LookupByBranchCodeDepositAccount', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (27, N'SQL_ACCHRT_LOOKUP_BY_BRANCHID_CURRENCY', N'Jits.Neptune.Web.Accounting.Services.AccountChartQueueService', N'LookupByBranchCodeCurrencyCode', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (28, N'ACT_ACCHRT_ACTIVITY', N'Jits.Neptune.Web.Accounting.Services.AccountChartQueueService', N'GetListAuditAccount', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (29, N'ACT_GET_AVAILABLE_BALANCE', N'Jits.Neptune.Web.Accounting.Services.AccountChartQueueService', N'GetAccountBalanceInquiry', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (30, N'PMT_GET_INFO_ACT_SACNO', N'Jits.Neptune.Web.Accounting.Services.AccountChartQueueService', N'GetInforAccountingByBankAccounntAndBrandId', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (31, N'PMT_GET_INFO_ACT_RACNO', N'Jits.Neptune.Web.Accounting.Services.AccountChartQueueService', N'GetInforAccountingByBankAccounntAndBrandId2', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (32, N'SQL_INSERT_ACCLR', N'Jits.Neptune.Web.Accounting.Services.AccountClearingQueueService', N'Create', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (33, N'SQL_UPDATE_ACCLR', N'Jits.Neptune.Web.Accounting.Services.AccountClearingQueueService', N'Update', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (34, N'SQL_DELETE_ACCLR', N'Jits.Neptune.Web.Accounting.Services.AccountClearingQueueService', N'Delete', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (35, N'SQL_VIEW_ACCLR', N'Jits.Neptune.Web.Accounting.Services.AccountClearingQueueService', N'View', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (36, N'SQL_SER_SIMPLE_ACCLR', N'Jits.Neptune.Web.Accounting.Services.AccountClearingQueueService', N'SimpleSearch', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (37, N'SQL_SER_ADVANCE_ACCLR', N'Jits.Neptune.Web.Accounting.Services.AccountClearingQueueService', N'AdvanceSearch', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (38, N'ACT_ACCLR_ACTIVITY', N'Jits.Neptune.Web.Accounting.Services.AccountClearingQueueService', N'GetListAuditAccount', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (39, N'SQL_INSERT_ACGRP', N'Jits.Neptune.Web.Accounting.Services.GroupOfAccountQueueService', N'Create', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (40, N'SQL_UPDATE_ACGRP', N'Jits.Neptune.Web.Accounting.Services.GroupOfAccountQueueService', N'Update', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (41, N'SQL_DELETE_ACGRP', N'Jits.Neptune.Web.Accounting.Services.GroupOfAccountQueueService', N'Delete', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (42, N'SQL_VIEW_ACGRP', N'Jits.Neptune.Web.Accounting.Services.GroupOfAccountQueueService', N'View', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (43, N'SQL_SER_SIMPLE_ACGRP', N'Jits.Neptune.Web.Accounting.Services.GroupOfAccountQueueService', N'SimpleSearch', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (44, N'SQL_SER_ADVANCE_ACGRP', N'Jits.Neptune.Web.Accounting.Services.GroupOfAccountQueueService', N'AdvanceSearch', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (45, N'ACT_ACGRP_ACTIVITY', N'Jits.Neptune.Web.Accounting.Services.GroupOfAccountQueueService', N'GetListAuditAccount', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (46, N'SQL_INSERT_ACGRPDEF', N'Jits.Neptune.Web.Accounting.Services.AccountGroupDefinitionQueueService', N'Create', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (47, N'SQL_UPDATE_ACGRPDEF', N'Jits.Neptune.Web.Accounting.Services.AccountGroupDefinitionQueueService', N'Update', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (48, N'SQL_DELETE_ACGRPDEF', N'Jits.Neptune.Web.Accounting.Services.AccountGroupDefinitionQueueService', N'Delete', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (49, N'SQL_VIEW_ACGRPDEF', N'Jits.Neptune.Web.Accounting.Services.AccountGroupDefinitionQueueService', N'View', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (50, N'SQL_SER_SIMPLE_ACGRPDEF', N'Jits.Neptune.Web.Accounting.Services.AccountGroupDefinitionQueueService', N'SimpleSearch', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (51, N'SQL_SER_ADVANCE_ACGRPDEF', N'Jits.Neptune.Web.Accounting.Services.AccountGroupDefinitionQueueService', N'AdvanceSearch', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (52, N'SQL_RULE_FUNC_GET_INFO_ACTGRP_ACGRPDEF', N'Jits.Neptune.Web.Accounting.Services.AccountGroupDefinitionQueueService', N'GetByGroupId', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (53, N'ACT_ACGRPDEF_ACTIVITY', N'Jits.Neptune.Web.Accounting.Services.AccountGroupDefinitionQueueService', N'GetListAuditAccount', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (54, N'SQL_INSERT_ACGRPDEFDTL', N'Jits.Neptune.Web.Accounting.Services.AccountGroupDefinitionDetailQueueService', N'Create', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (55, N'SQL_UPDATE_ACGRPDEFDTL', N'Jits.Neptune.Web.Accounting.Services.AccountGroupDefinitionDetailQueueService', N'Update', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (56, N'SQL_DELETE_ACGRPDEFDTL', N'Jits.Neptune.Web.Accounting.Services.AccountGroupDefinitionDetailQueueService', N'Delete', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (57, N'SQL_VIEW_ACGRPDEFDTL', N'Jits.Neptune.Web.Accounting.Services.AccountGroupDefinitionDetailQueueService', N'View', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (58, N'SQL_SER_SIMPLE_ACGRPDEFDTL', N'Jits.Neptune.Web.Accounting.Services.AccountGroupDefinitionDetailQueueService', N'SimpleSearch', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (59, N'SQL_SER_ADVANCE_ACGRPDEFDTL', N'Jits.Neptune.Web.Accounting.Services.AccountGroupDefinitionDetailQueueService', N'AdvanceSearch', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (60, N'ACT_ACGRPDEFDTL_ACTIVITY', N'Jits.Neptune.Web.Accounting.Services.AccountGroupDefinitionDetailQueueService', N'GetListAuditAccount', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (61, N'SQL_INSERT_ACMAP', N'Jits.Neptune.Web.Accounting.Services.AccountMappingQueueService', N'Create', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (62, N'SQL_UPDATE_ACMAP', N'Jits.Neptune.Web.Accounting.Services.AccountMappingQueueService', N'Update', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (63, N'SQL_DELETE_ACMAP', N'Jits.Neptune.Web.Accounting.Services.AccountMappingQueueService', N'Delete', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (64, N'SQL_VIEW_ACMAP', N'Jits.Neptune.Web.Accounting.Services.AccountMappingQueueService', N'View', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (65, N'SQL_SER_SIMPLE_ACMAP', N'Jits.Neptune.Web.Accounting.Services.AccountMappingQueueService', N'SimpleSearch', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (66, N'SQL_SER_ADVANCE_ACMAP', N'Jits.Neptune.Web.Accounting.Services.AccountMappingQueueService', N'AdvanceSearch', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (67, N'ACT_ACMAP_ACTIVITY', N'Jits.Neptune.Web.Accounting.Services.AccountMappingQueueService', N'GetListAuditAccount', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (68, N'SQL_INSERT_ACGLDEF', N'Jits.Neptune.Web.Accounting.Services.ExtensionAccountOfGroupDefinitionQueueService', N'Create', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (69, N'SQL_UPDATE_ACGLDEF', N'Jits.Neptune.Web.Accounting.Services.ExtensionAccountOfGroupDefinitionQueueService', N'Update', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (70, N'SQL_DELETE_ACGLDEF', N'Jits.Neptune.Web.Accounting.Services.ExtensionAccountOfGroupDefinitionQueueService', N'Delete', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (71, N'SQL_VIEW_ACGLDEF', N'Jits.Neptune.Web.Accounting.Services.ExtensionAccountOfGroupDefinitionQueueService', N'View', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (72, N'SQL_SER_SIMPLE_ACGLDEF', N'Jits.Neptune.Web.Accounting.Services.ExtensionAccountOfGroupDefinitionQueueService', N'SimpleSearch', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (73, N'SQL_SER_ADVANCE_ACGLDEF', N'Jits.Neptune.Web.Accounting.Services.ExtensionAccountOfGroupDefinitionQueueService', N'AdvanceSearch', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (74, N'ACT_ACGLDEF_ACTIVITY', N'Jits.Neptune.Web.Accounting.Services.ExtensionAccountOfGroupDefinitionQueueService', N'GetListAuditAccount', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (75, N'SQL_INSERT_FXCLR', N'Jits.Neptune.Web.Accounting.Services.ForeignExchangeAccountDefinitionQueueService', N'Create', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (76, N'SQL_UPDATE_FXCLR', N'Jits.Neptune.Web.Accounting.Services.ForeignExchangeAccountDefinitionQueueService', N'Update', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (77, N'SQL_DELETE_FXCLR', N'Jits.Neptune.Web.Accounting.Services.ForeignExchangeAccountDefinitionQueueService', N'Delete', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (78, N'SQL_VIEW_FXCLR', N'Jits.Neptune.Web.Accounting.Services.ForeignExchangeAccountDefinitionQueueService', N'View', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (79, N'SQL_SER_SIMPLE_FXCLR', N'Jits.Neptune.Web.Accounting.Services.ForeignExchangeAccountDefinitionQueueService', N'SimpleSearch', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (80, N'SQL_SER_ADVANCE_FXCLR', N'Jits.Neptune.Web.Accounting.Services.ForeignExchangeAccountDefinitionQueueService', N'AdvanceSearch', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (81, N'ACT_FXCLR_ACTIVITY', N'Jits.Neptune.Web.Accounting.Services.ForeignExchangeAccountDefinitionQueueService', N'GetListAuditAccount', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (82, N'SQL_INSERT_ACTX', N'Jits.Neptune.Web.Accounting.Services.AccountingRuleDefinitionQueueService', N'Create', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (83, N'SQL_UPDATE_ACTX', N'Jits.Neptune.Web.Accounting.Services.AccountingRuleDefinitionQueueService', N'Update', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (84, N'SQL_DELETE_ACTX', N'Jits.Neptune.Web.Accounting.Services.AccountingRuleDefinitionQueueService', N'Delete', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (85, N'SQL_VIEW_ACTX', N'Jits.Neptune.Web.Accounting.Services.AccountingRuleDefinitionQueueService', N'View', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (86, N'SQL_SER_SIMPLE_ACTX', N'Jits.Neptune.Web.Accounting.Services.AccountingRuleDefinitionQueueService', N'SimpleSearch', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (87, N'SQL_SER_ADVANCE_ACTX', N'Jits.Neptune.Web.Accounting.Services.AccountingRuleDefinitionQueueService', N'AdvanceSearch', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (88, N'SQL_GET_GLACCOUNT_POSTING', N'Jits.Neptune.Web.Accounting.Services.FOTransactionQueueService', N'GetGLAccountInfor', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (89, N'SQL_GET_GLACCOUNT_POSTING_AMOUNT_FEE', N'Jits.Neptune.Web.Accounting.Services.FOTransactionQueueService', N'GetGLAccountInforAmountFee', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (90, N'SQL_GET_GLACCOUNT_POSTING_ALL_SIDE', N'Jits.Neptune.Web.Accounting.Services.FOTransactionQueueService', N'GetGLAccountInforAllSide', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (91, N'SQL_GET_GLACCOUNT_POSTING_TWO_SIDE', N'Jits.Neptune.Web.Accounting.Services.FOTransactionQueueService', N'GetGLAccountInforTwoSideSameAccount', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (92, N'ACT_EXECUTE_POSTING', N'Jits.Neptune.Web.Accounting.Services.FOTransactionQueueService', N'ExcuteAccountingRule', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (93, N'SQL_ACT_POSTING', N'Jits.Neptune.Web.Accounting.Services.AccountingQueueService', N'ExcuteAccountingRule', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (94, N'SQL_ACT_REVERSAL_POSTING', N'Jits.Neptune.Web.Accounting.Services.FOTransactionQueueService', N'ReversalEntryPosting', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (95, N'ACT_MAN', N'Jits.Neptune.Web.Accounting.Services.FOTransactionQueueService', N'ACT_MAN', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (96, N'ACT_GFEE', N'Jits.Neptune.Web.Accounting.Services.FOTransactionQueueService', N'ACT_GFEE', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (97, N'ACT_FEE', N'Jits.Neptune.Web.Accounting.Services.FOTransactionQueueService', N'ACT_FEE', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (98, N'ACT_POSTING_FUND_TRANSFER', N'Jits.Neptune.Web.Accounting.Services.FOTransactionQueueService', N'PostingFundTransfer', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (99, N'ACT_DEPOSIT_PAYMENT', N'Jits.Neptune.Web.Accounting.Services.FOTransactionQueueService', N'DepositPayment', 0)
GO
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (100, N'ACT_PAYMENT_CHEQUE', N'Jits.Neptune.Web.Accounting.Services.FOTransactionQueueService', N'PaymentCheque', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (101, N'ACT_IMPORT_MASTER_TABLE_TEMPLATE', N'Jits.Neptune.Web.Accounting.Services.AccountingTemplateQueueService', N'ImportMasterTableTemplate', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (102, N'ACT_PAYMENT_PO', N'Jits.Neptune.Web.Accounting.Services.FOTransactionQueueService', N'PaymentOrder', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (103, N'POSTING_CSH_BMOV', N'Jits.Neptune.Web.Accounting.Services.FOTransactionQueueService', N'PostingCshBmov', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (104, N'SQL_OPENACCOUNTPOSTING_ACCHRT', N'Jits.Neptune.Web.Accounting.Services.AccountChartQueueService', N'OpenAccountPosting', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (105, N'ACT_ACT_CARDZONE_POSTING', N'Jits.Neptune.Web.Accounting.Services.FOTransactionQueueService', N'AccountingToAccountingCardzone', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (106, N'SQL_INSERT_CODE_LIST', N'Jits.Neptune.Web.Accounting.Services.Workflow.CodeListQueueService', N'Insert', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (107, N'SQL_VIEW_CODE_LIST', N'Jits.Neptune.Web.Accounting.Services.Workflow.CodeListQueueService', N'View', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (108, N'SQL_DELETE_CODE_LIST', N'Jits.Neptune.Web.Accounting.Services.Workflow.CodeListQueueService', N'Delete', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (109, N'SQL_UPDATE_CODE_LIST', N'Jits.Neptune.Web.Accounting.Services.Workflow.CodeListQueueService', N'Update', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (110, N'SQL_SIMPLE_SEARCH_CODE_LIST', N'Jits.Neptune.Web.Accounting.Services.Workflow.CodeListQueueService', N'SimpleSearch', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (111, N'SQL_ADVANCED_SEARCH_CODE_LIST', N'Jits.Neptune.Web.Accounting.Services.Workflow.CodeListQueueService', N'AdvancedSearch', 0)
INSERT [dbo].[NeptuneService] ([Id], [StepCode], [FullClassName], [MethodName], [Async]) VALUES (112, N'ACT_VERIFY_TRANSACTION_RULE', N'Jits.Neptune.Web.Accounting.Services.FOTransactionQueueService', N'VerifyTransactionRule', 0)
SET IDENTITY_INSERT [dbo].[NeptuneService] OFF
GO

USE [o9customer]
GO
SET IDENTITY_INSERT [dbo].[TransactionRules] ON 

INSERT [dbo].[TransactionRules] ([Id], [WorkflowId], [RuleName], [Parameter], [RuleOrder], [IsEnable], [Spec], [Example], [Caption], [UpdatedOnUtc]) VALUES (1, N'SQL_CTM_APR', N'CheckMustBeSameBranch', N'{"customer_code":"customer_code","branch_approve":"current_branch_code"}', 1, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[TransactionRules] ([Id], [WorkflowId], [RuleName], [Parameter], [RuleOrder], [IsEnable], [Spec], [Example], [Caption], [UpdatedOnUtc]) VALUES (2, N'SQL_CTM_REJ', N'CheckMustBeSameBranch', N'{"customer_code":"customer_code","branch_approve":"current_branch_code"}', 1, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[TransactionRules] ([Id], [WorkflowId], [RuleName], [Parameter], [RuleOrder], [IsEnable], [Spec], [Example], [Caption], [UpdatedOnUtc]) VALUES (3, N'CTM_LINKAGEAPR_APR', N'CheckMustBeSameBranch', N'{"customer_code":"linkage_code","branch_approve":"current_branch_code"}', 1, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[TransactionRules] ([Id], [WorkflowId], [RuleName], [Parameter], [RuleOrder], [IsEnable], [Spec], [Example], [Caption], [UpdatedOnUtc]) VALUES (4, N'CTM_LINKAGEAPR_REJ', N'CheckMustBeSameBranch', N'{"customer_code":"linkage_code","branch_approve":"current_branch_code"}', 1, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[TransactionRules] ([Id], [WorkflowId], [RuleName], [Parameter], [RuleOrder], [IsEnable], [Spec], [Example], [Caption], [UpdatedOnUtc]) VALUES (5, N'CTM_GROUPAPR_APR', N'CheckMustBeSameBranch', N'{"customer_code":"group_code","branch_approve":"current_branch_code"}', 1, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[TransactionRules] ([Id], [WorkflowId], [RuleName], [Parameter], [RuleOrder], [IsEnable], [Spec], [Example], [Caption], [UpdatedOnUtc]) VALUES (6, N'CTM_GROUPAPR_REJ', N'CheckMustBeSameBranch', N'{"customer_code":"group_code","branch_approve":"current_branch_code"}', 1, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[TransactionRules] ([Id], [WorkflowId], [RuleName], [Parameter], [RuleOrder], [IsEnable], [Spec], [Example], [Caption], [UpdatedOnUtc]) VALUES (9, N'CTM_APR', N'CheckMustBeSameBranch', N'{"customer_code":"customer_code","branch_approve":"current_branch_code"}', 1, 1, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[TransactionRules] OFF
GO

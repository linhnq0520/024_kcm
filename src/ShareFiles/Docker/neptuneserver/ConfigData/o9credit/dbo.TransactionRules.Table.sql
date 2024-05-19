USE [o9credit]
GO
SET IDENTITY_INSERT [dbo].[TransactionRules] ON 

INSERT [dbo].[TransactionRules] ([Id], [WorkflowId], [RuleName], [Parameter], [RuleOrder], [IsEnable], [Spec], [Example], [Caption], [UpdatedOnUtc]) VALUES (7, N'CRD_APR', N'CheckInterestComputationMode', N'{"account_number":"account_number"}', 1, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[TransactionRules] ([Id], [WorkflowId], [RuleName], [Parameter], [RuleOrder], [IsEnable], [Spec], [Example], [Caption], [UpdatedOnUtc]) VALUES (8, N'CRD_IFC', N'CheckInterestComputationMode', N'{"account_number":"account_number"}', 1, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[TransactionRules] ([Id], [WorkflowId], [RuleName], [Parameter], [RuleOrder], [IsEnable], [Spec], [Example], [Caption], [UpdatedOnUtc]) VALUES (9, N'CRD_CLA', N'CheckInterestComputationMode', N'{"account_number":"credit_account"}', 1, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[TransactionRules] ([Id], [WorkflowId], [RuleName], [Parameter], [RuleOrder], [IsEnable], [Spec], [Example], [Caption], [UpdatedOnUtc]) VALUES (10, N'CRD_CDR', N'CheckInterestComputationMode', N'{"account_number":"credit_account"}', 1, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[TransactionRules] ([Id], [WorkflowId], [RuleName], [Parameter], [RuleOrder], [IsEnable], [Spec], [Example], [Caption], [UpdatedOnUtc]) VALUES (11, N'CRD_MDR', N'CheckInterestComputationMode', N'{"account_number":"credit_account"}', 1, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[TransactionRules] ([Id], [WorkflowId], [RuleName], [Parameter], [RuleOrder], [IsEnable], [Spec], [Example], [Caption], [UpdatedOnUtc]) VALUES (12, N'CRD_TDR', N'CheckInterestComputationMode', N'{"account_number":"credit_account"}', 1, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[TransactionRules] ([Id], [WorkflowId], [RuleName], [Parameter], [RuleOrder], [IsEnable], [Spec], [Example], [Caption], [UpdatedOnUtc]) VALUES (23, N'CRD_OPN', N'CheckFieldRequiredWithSubType', N'{"RequiredFields":["DealerName","TypeOfCommodity"], "AllowSubType":["F3","F4", "F5"], "CreditSubType":"credit_sub_type"}', 1, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[TransactionRules] ([Id], [WorkflowId], [RuleName], [Parameter], [RuleOrder], [IsEnable], [Spec], [Example], [Caption], [UpdatedOnUtc]) VALUES (24, N'CRD_OPN', N'CheckFieldRequiredWithCatalogStartWith', N'{"RequiredFields":["CompanyName"], "StartingString":"CPLAP", "CatalogCode":"catalog_code"}', 2, 1, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[TransactionRules] OFF
GO

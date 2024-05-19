USE [o9deposit]
GO
SET IDENTITY_INSERT [dbo].[RuleDefinition] ON 

INSERT [dbo].[RuleDefinition] ([Id], [RuleName], [FullClassName], [MethodName], [UpdatedOnUtc]) VALUES (1, N'CatalogAllowTransaction', N'Jits.Neptune.Web.Deposit.Services.ValidatorService', N'CatalogAllowTransaction', NULL)
INSERT [dbo].[RuleDefinition] ([Id], [RuleName], [FullClassName], [MethodName], [UpdatedOnUtc]) VALUES (2, N'CheckDepositType', N'Jits.Neptune.Web.Deposit.Services.ValidatorService', N'CheckDepositType', NULL)
INSERT [dbo].[RuleDefinition] ([Id], [RuleName], [FullClassName], [MethodName], [UpdatedOnUtc]) VALUES (3, N'HandleDormant', N'Jits.Neptune.Web.Deposit.Services.ValidatorService', N'HandleDormant', NULL)
INSERT [dbo].[RuleDefinition] ([Id], [RuleName], [FullClassName], [MethodName], [UpdatedOnUtc]) VALUES (4, N'CheckDepositSubType', N'Jits.Neptune.Web.Deposit.Services.ValidatorService', N'CheckDepositSubType', NULL)
INSERT [dbo].[RuleDefinition] ([Id], [RuleName], [FullClassName], [MethodName], [UpdatedOnUtc]) VALUES (5, N'CheckNotAllowedDepositSubType', N'Jits.Neptune.Web.Deposit.Services.ValidatorService', N'CheckNotAllowedDepositSubType', NULL)
INSERT [dbo].[RuleDefinition] ([Id], [RuleName], [FullClassName], [MethodName], [UpdatedOnUtc]) VALUES (6, N'CheckAllowedDepositStatus', N'Jits.Neptune.Web.Deposit.Services.ValidatorService', N'CheckAllowedDepositStatus', NULL)
INSERT [dbo].[RuleDefinition] ([Id], [RuleName], [FullClassName], [MethodName], [UpdatedOnUtc]) VALUES (7, N'CheckNotAllowedDepositStatus', N'Jits.Neptune.Web.Deposit.Services.ValidatorService', N'CheckNotAllowedDepositStatus', NULL)
INSERT [dbo].[RuleDefinition] ([Id], [RuleName], [FullClassName], [MethodName], [UpdatedOnUtc]) VALUES (8, N'CardzoneValidate', N'Jits.Neptune.Web.Deposit.Services.ValidatorService', N'CardzoneValidate', NULL)
INSERT [dbo].[RuleDefinition] ([Id], [RuleName], [FullClassName], [MethodName], [UpdatedOnUtc]) VALUES (9, N'TransferMomoneyValidate', N'Jits.Neptune.Web.Deposit.Services.ValidatorService', N'TransferMomoneyValidate', NULL)
INSERT [dbo].[RuleDefinition] ([Id], [RuleName], [FullClassName], [MethodName], [UpdatedOnUtc]) VALUES (10, N'CheckNotAllowedDepositType', N'Jits.Neptune.Web.Deposit.Services.ValidatorService', N'CheckNotAllowedDepositType', NULL)
INSERT [dbo].[RuleDefinition] ([Id], [RuleName], [FullClassName], [MethodName], [UpdatedOnUtc]) VALUES (11, N'CheckAllowedDepositCurrecy', N'Jits.Neptune.Web.Deposit.Services.ValidatorService', N'CheckAllowedDepositCurrecy', NULL)
INSERT [dbo].[RuleDefinition] ([Id], [RuleName], [FullClassName], [MethodName], [UpdatedOnUtc]) VALUES (12, N'ValidateDepositAccount', N'Jits.Neptune.Web.Deposit.Services.ValidatorService', N'ValidateDepositAccount', NULL)
INSERT [dbo].[RuleDefinition] ([Id], [RuleName], [FullClassName], [MethodName], [UpdatedOnUtc]) VALUES (13, N'CheckDepositAccountIsLinked', N'Jits.Neptune.Web.Deposit.Services.ValidatorService', N'CheckDepositAccountIsLinked', NULL)
INSERT [dbo].[RuleDefinition] ([Id], [RuleName], [FullClassName], [MethodName], [UpdatedOnUtc]) VALUES (14, N'CheckAllowBranch', N'Jits.Neptune.Web.Deposit.Services.ValidatorService', N'CheckAllowBranch', NULL)
INSERT [dbo].[RuleDefinition] ([Id], [RuleName], [FullClassName], [MethodName], [UpdatedOnUtc]) VALUES (15, N'ValidateListDepositAccount', N'Jits.Neptune.Web.Deposit.Services.ValidatorService', N'ValidateListDepositAccount', NULL)
SET IDENTITY_INSERT [dbo].[RuleDefinition] OFF
GO

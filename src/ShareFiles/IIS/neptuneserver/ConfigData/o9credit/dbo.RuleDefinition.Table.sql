USE [o9credit]
GO
SET IDENTITY_INSERT [dbo].[RuleDefinition] ON 

INSERT [dbo].[RuleDefinition] ([Id], [RuleName], [FullClassName], [MethodName], [UpdatedOnUtc]) VALUES (2, N'CheckInterestComputationMode', N'Jits.Neptune.Web.Credit.Services.ValidatorService', N'CheckInterestComputationMode', NULL)
INSERT [dbo].[RuleDefinition] ([Id], [RuleName], [FullClassName], [MethodName], [UpdatedOnUtc]) VALUES (7, N'CheckFieldRequiredWithCatalogContains', N'Jits.Neptune.Web.Credit.Services.ValidatorService', N'CheckFieldRequiredWithCatalogContains', NULL)
INSERT [dbo].[RuleDefinition] ([Id], [RuleName], [FullClassName], [MethodName], [UpdatedOnUtc]) VALUES (8, N'CheckFieldRequiredWithSubType', N'Jits.Neptune.Web.Credit.Services.ValidatorService', N'CheckFieldRequiredWithSubType', NULL)
INSERT [dbo].[RuleDefinition] ([Id], [RuleName], [FullClassName], [MethodName], [UpdatedOnUtc]) VALUES (9, N'CheckFieldRequiredWithCatalogStartWith', N'Jits.Neptune.Web.Credit.Services.ValidatorService', N'CheckFieldRequiredWithCatalogStartWith', NULL)
SET IDENTITY_INSERT [dbo].[RuleDefinition] OFF
GO

USE [o9customer]
GO
SET IDENTITY_INSERT [dbo].[RuleDefinition] ON 

INSERT [dbo].[RuleDefinition] ([Id], [RuleName], [FullClassName], [MethodName], [UpdatedOnUtc]) VALUES (1, N'CheckMustBeSameBranch', N'Jits.Neptune.Web.Customer.Services.ValidatorService', N'CheckMustBeSameBranch', NULL)
SET IDENTITY_INSERT [dbo].[RuleDefinition] OFF
GO

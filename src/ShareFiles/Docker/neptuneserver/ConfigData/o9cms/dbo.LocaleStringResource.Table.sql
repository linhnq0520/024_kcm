USE [o9cms]
GO
SET IDENTITY_INSERT [dbo].[LocaleStringResource] ON 

INSERT [dbo].[LocaleStringResource] ([Id], [ResourceName], [ResourceValue], [Language]) VALUES (1, N'Common.LocaleStringResource.Language.Value.Required', N'Locale string resource language is required', N'en')
INSERT [dbo].[LocaleStringResource] ([Id], [ResourceName], [ResourceValue], [Language]) VALUES (2, N'Common.Value.Required', N'{0} is required', N'en')
INSERT [dbo].[LocaleStringResource] ([Id], [ResourceName], [ResourceValue], [Language]) VALUES (3, N'Common.Value.Unique', N'{0} is unique', N'en')
INSERT [dbo].[LocaleStringResource] ([Id], [ResourceName], [ResourceValue], [Language]) VALUES (4, N'Common.Value.MaximumLength', N'{0} should not exceed the max length than {1}', N'en')
INSERT [dbo].[LocaleStringResource] ([Id], [ResourceName], [ResourceValue], [Language]) VALUES (1003, N'CMS.String.OverLimit', N'Officer Approval Require', N'en')
INSERT [dbo].[LocaleStringResource] ([Id], [ResourceName], [ResourceValue], [Language]) VALUES (1004, N'CMS.String.ApprovalRequired', N'Approval Require', N'en')
INSERT [dbo].[LocaleStringResource] ([Id], [ResourceName], [ResourceValue], [Language]) VALUES (1005, N'Common.Value.NotExist', N'{0} [{1}] doest not exist', N'en')
SET IDENTITY_INSERT [dbo].[LocaleStringResource] OFF
GO

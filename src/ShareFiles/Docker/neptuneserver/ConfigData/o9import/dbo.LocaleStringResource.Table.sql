USE [o9import]
GO
SET IDENTITY_INSERT [dbo].[LocaleStringResource] ON 

INSERT [dbo].[LocaleStringResource] ([Id], [ResourceName], [ResourceValue], [Language]) VALUES (1, N'Common.LocaleStringResource.Language.Value.Required', N'Locale string resource language is required', N'en')
INSERT [dbo].[LocaleStringResource] ([Id], [ResourceName], [ResourceValue], [Language]) VALUES (2, N'Common.Value.Required', N'{0} is required', N'en')
INSERT [dbo].[LocaleStringResource] ([Id], [ResourceName], [ResourceValue], [Language]) VALUES (3, N'Common.Value.Unique', N'{0} is unique', N'en')
INSERT [dbo].[LocaleStringResource] ([Id], [ResourceName], [ResourceValue], [Language]) VALUES (4, N'Common.Value.MaximumLength', N'{0} should not exceed the max length than {1}', N'en')
INSERT [dbo].[LocaleStringResource] ([Id], [ResourceName], [ResourceValue], [Language]) VALUES (5, N'Common.Value.NotExist', N'{0} [{1}] doest not exist', N'en')
SET IDENTITY_INSERT [dbo].[LocaleStringResource] OFF
GO

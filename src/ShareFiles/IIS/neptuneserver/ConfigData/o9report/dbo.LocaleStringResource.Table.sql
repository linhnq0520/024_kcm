USE [o9report]
GO
SET IDENTITY_INSERT [dbo].[LocaleStringResource] ON 

INSERT [dbo].[LocaleStringResource] ([Id], [ResourceName], [ResourceValue], [Language]) VALUES (1, N'Common.LocaleStringResource.Language.Value.Required', N'Locale string resource language is required', N'en')
INSERT [dbo].[LocaleStringResource] ([Id], [ResourceName], [ResourceValue], [Language]) VALUES (2, N'Common.Value.Required', N'{0} is required', N'en')
INSERT [dbo].[LocaleStringResource] ([Id], [ResourceName], [ResourceValue], [Language]) VALUES (3, N'Common.Value.Unique', N'{0} is unique', N'en')
INSERT [dbo].[LocaleStringResource] ([Id], [ResourceName], [ResourceValue], [Language]) VALUES (4, N'Common.Value.MaximumLength', N'{0} should not exceed the max length than {1}', N'en')
INSERT [dbo].[LocaleStringResource] ([Id], [ResourceName], [ResourceValue], [Language]) VALUES (5, N'Report.Code.Existed', N'This {0} code already existed', N'en')
INSERT [dbo].[LocaleStringResource] ([Id], [ResourceName], [ResourceValue], [Language]) VALUES (6, N'Report.TemplateReport.Value.NotFound', N'This TemplateReport not found', N'en')
INSERT [dbo].[LocaleStringResource] ([Id], [ResourceName], [ResourceValue], [Language]) VALUES (7, N'Report.ViewerSetting.Value.NotFound', N'This ViewerSetting not found', N'en')
INSERT [dbo].[LocaleStringResource] ([Id], [ResourceName], [ResourceValue], [Language]) VALUES (8, N'Report.MailOption.Value.NotFound', N'This MailOption not found', N'en')
INSERT [dbo].[LocaleStringResource] ([Id], [ResourceName], [ResourceValue], [Language]) VALUES (9, N'Report.ReportConfig.Value.NotFound', N'This ReportConfig not found', N'en')
INSERT [dbo].[LocaleStringResource] ([Id], [ResourceName], [ResourceValue], [Language]) VALUES (10, N'Report.CodeTemplate.Existed', N'This {0} CodeTemplate already existed', N'en')
INSERT [dbo].[LocaleStringResource] ([Id], [ResourceName], [ResourceValue], [Language]) VALUES (11, N'Common.Value.NotExist', N'{0} [{1}] does not exist', N'en')
SET IDENTITY_INSERT [dbo].[LocaleStringResource] OFF
GO

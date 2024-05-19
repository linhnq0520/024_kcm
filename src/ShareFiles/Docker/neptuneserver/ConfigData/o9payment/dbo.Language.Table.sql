USE [o9payment]
GO
SET IDENTITY_INSERT [dbo].[Language] ON 

INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [DisplayOrder]) VALUES (1, N'Cambodia', N'kh-KH', N'kh', 2)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [DisplayOrder]) VALUES (2, N'English', N'en-US', N'en', 1)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [DisplayOrder]) VALUES (3, N'Lao', N'la-LA', N'la', 3)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [DisplayOrder]) VALUES (4, N'Thailand', N'th-TH', N'th', 4)
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [DisplayOrder]) VALUES (5, N'Vietnam', N'vi-VN', N'vn', 5)
SET IDENTITY_INSERT [dbo].[Language] OFF
GO

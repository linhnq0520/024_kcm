USE [o9cms]
GO
SET IDENTITY_INSERT [dbo].[DesignGroup] ON 

INSERT [dbo].[DesignGroup] ([Id], [GroupId], [isActive], [Title], [DisplayOrder]) VALUES (1, N'layout_fields', 1, N'{"en":"Layout Fields","vi":"Mẫu bố trí"}', N'1')
INSERT [dbo].[DesignGroup] ([Id], [GroupId], [isActive], [Title], [DisplayOrder]) VALUES (2, N'ultra_advanced_fields', 1, N'{"en":"Ultra Advanced Fields","vi":"Mẫu cực kì nâng cao"}', N'2')
INSERT [dbo].[DesignGroup] ([Id], [GroupId], [isActive], [Title], [DisplayOrder]) VALUES (3, N'advanced_fields', 1, N'{"en":"Advanced Fields","vi":"Mẫu nâng cao"}', N'3')
INSERT [dbo].[DesignGroup] ([Id], [GroupId], [isActive], [Title], [DisplayOrder]) VALUES (4, N'basic_fields', 1, N'{"en":"Basic Fields","vi":"Đối tượng cơ bản"}', N'4')
SET IDENTITY_INSERT [dbo].[DesignGroup] OFF
GO

USE [neptune]
GO
INSERT [dbo].[EVENT_DEF] ([EVENT_NAME], [STATUS], [TYPE], [DESCRIPTION]) VALUES (N'WorkflowCompleted', N'Active', N'SystemDefine', N'WorkflowCompleted')
INSERT [dbo].[EVENT_DEF] ([EVENT_NAME], [STATUS], [TYPE], [DESCRIPTION]) VALUES (N'WorkflowRegistered', N'Active', N'SystemDefine', N'WorkflowRegistered')
INSERT [dbo].[EVENT_DEF] ([EVENT_NAME], [STATUS], [TYPE], [DESCRIPTION]) VALUES (N'WorkflowStart', N'Active', N'SystemDefine', N'WorkflowStart')
GO

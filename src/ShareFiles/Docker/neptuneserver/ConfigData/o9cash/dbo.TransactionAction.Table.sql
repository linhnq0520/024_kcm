USE [o9cash]
GO
SET IDENTITY_INSERT [dbo].[TransactionAction] ON 

INSERT [dbo].[TransactionAction] ([Id], [TransCode], [FieldNames], [Action], [HasStatement]) VALUES (1, N'CSH_CREDIT_BALANCE', N'CurrentBalance', N'D', 0)
INSERT [dbo].[TransactionAction] ([Id], [TransCode], [FieldNames], [Action], [HasStatement]) VALUES (2, N'CSH_DEBIT_BALANCE', N'CurrentBalance', N'C', 0)
SET IDENTITY_INSERT [dbo].[TransactionAction] OFF
GO

USE [o9accounting]
GO
SET IDENTITY_INSERT [dbo].[TransactionAction] ON 

INSERT [dbo].[TransactionAction] ([Id], [TransCode], [FieldNames], [Action], [HasStatement]) VALUES (4, N'C', N'Balance,DailyCredit,WeeklyCredit,MonthlyCredit,QuarterlyCredit,HalfYearlyCredit,YearlyCredit', N'C', 1)
INSERT [dbo].[TransactionAction] ([Id], [TransCode], [FieldNames], [Action], [HasStatement]) VALUES (5, N'D', N'Balance', N'D', 1)
INSERT [dbo].[TransactionAction] ([Id], [TransCode], [FieldNames], [Action], [HasStatement]) VALUES (6, N'D', N'DailyDebit,WeeklyDebit,MonthlyDebit,QuarterlyDebit,HalfYearlyDebit,YearlyDebit', N'C', 0)
SET IDENTITY_INSERT [dbo].[TransactionAction] OFF
GO

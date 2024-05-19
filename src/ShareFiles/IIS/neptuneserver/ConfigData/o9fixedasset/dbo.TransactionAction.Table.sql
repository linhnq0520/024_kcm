USE [o9fixedasset]
GO
SET IDENTITY_INSERT [dbo].[TransactionAction] ON 

INSERT [dbo].[TransactionAction] ([Id], [TransCode], [FieldNames], [Action], [HasStatement]) VALUES (1, N'FAC_CREDIT_BALANCE', N'WeekCredit,MonthCredit,QuarterCredit,SemiAnnualCredit,YearCredit', N'C', 0)
INSERT [dbo].[TransactionAction] ([Id], [TransCode], [FieldNames], [Action], [HasStatement]) VALUES (2, N'FAC_DEBIT_BALANCE', N'WeekCredit,MonthCredit,QuarterCredit,SemiAnnualCredit,YearCredit', N'D', 0)
INSERT [dbo].[TransactionAction] ([Id], [TransCode], [FieldNames], [Action], [HasStatement]) VALUES (3, N'FAC_CREDIT_BOOKING_AMOUNT', N'BookingAmount', N'D', 0)
INSERT [dbo].[TransactionAction] ([Id], [TransCode], [FieldNames], [Action], [HasStatement]) VALUES (4, N'FAC_CREDIT_BOOKING_AMOUNT', N'WeekCredit,MonthCredit,QuarterCredit,SemiAnnualCredit,YearCredit', N'C', 0)
INSERT [dbo].[TransactionAction] ([Id], [TransCode], [FieldNames], [Action], [HasStatement]) VALUES (5, N'FAC_DEBIT_BOOKING_AMOUNT', N'BookingAmount', N'C', 0)
INSERT [dbo].[TransactionAction] ([Id], [TransCode], [FieldNames], [Action], [HasStatement]) VALUES (6, N'FAC_DEBIT_BOOKING_AMOUNT', N'WeekDebit,MonthDebit,QuarterDebit,SemiAnnualDebit,YearDebit', N'C', 0)
INSERT [dbo].[TransactionAction] ([Id], [TransCode], [FieldNames], [Action], [HasStatement]) VALUES (7, N'FAC_DEBIT_NETBOOKVALUE', N'NetBookingValue', N'D', 0)
INSERT [dbo].[TransactionAction] ([Id], [TransCode], [FieldNames], [Action], [HasStatement]) VALUES (8, N'FAC_CREDIT_ACCUMULATE', N'AccummulateAmount', N'C', 0)
SET IDENTITY_INSERT [dbo].[TransactionAction] OFF
GO

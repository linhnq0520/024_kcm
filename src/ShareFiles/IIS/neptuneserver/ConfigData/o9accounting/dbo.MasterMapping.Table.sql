USE [o9accounting]
GO
SET IDENTITY_INSERT [dbo].[MasterMapping] ON 

INSERT [dbo].[MasterMapping] ([Id], [MasterClass], [MasterTransClass], [StatementClass], [GLEntriesClass], [MasterFields], [MasterBranchCodeField], [MasterCurrencyCodeField], [MasterGLClass], [GLConfigClass], [MasterGLFields]) VALUES (1, N'Jits.Neptune.Web.Accounting.Domain.AccountBalance', N'', N'Jits.Neptune.Web.Accounting.Domain.AccountStatement', N'Jits.Neptune.Core.Domain.Neptune.GLEntries', N'AccountNumber:AccountNumber', N'BranchCode', N'CurrencyCode', N'', N'', N'')
SET IDENTITY_INSERT [dbo].[MasterMapping] OFF
GO

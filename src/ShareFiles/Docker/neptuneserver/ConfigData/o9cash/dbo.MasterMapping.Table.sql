USE [o9cash]
GO
SET IDENTITY_INSERT [dbo].[MasterMapping] ON 

INSERT [dbo].[MasterMapping] ([Id], [MasterClass], [MasterTransClass], [StatementClass], [GLEntriesClass], [MasterFields], [MasterBranchCodeField], [MasterCurrencyCodeField], [MasterGLClass], [GLConfigClass], [MasterGLFields]) VALUES (1, N'Jits.Neptune.Web.Cash.Domain.CashList', N'Jits.Neptune.Web.Cash.Domain.CashTransaction', N'Jits.Neptune.Web.Cash.Domain.CashStatement', N'Jits.Neptune.Core.Domain.Neptune.GLEntries', N'CashierCode:CashierCode#CurrencyCode:CurrencyCode', N'', N'CurrencyCode', N'', N'', N'')
SET IDENTITY_INSERT [dbo].[MasterMapping] OFF
GO

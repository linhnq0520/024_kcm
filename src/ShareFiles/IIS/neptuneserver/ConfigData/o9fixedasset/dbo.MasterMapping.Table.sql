USE [o9fixedasset]
GO
SET IDENTITY_INSERT [dbo].[MasterMapping] ON 

INSERT [dbo].[MasterMapping] ([Id], [MasterClass], [MasterTransClass], [StatementClass], [GLEntriesClass], [MasterFields], [MasterBranchCodeField], [MasterCurrencyCodeField], [MasterGLClass], [GLConfigClass], [MasterGLFields]) VALUES (1, N'Jits.Neptune.Web.FixedAsset.Domain.FixedAssetAccount', N'Jits.Neptune.Web.FixedAsset.Domain.FixedAssetAccountTrans', N'', N'Jits.Neptune.Core.Domain.Neptune.GLEntries', N'FixedAssetAccount:AccountNumber', N'BranchCode', N'CurrencyCode', N'Jits.Neptune.Web.FixedAsset.Domain.FixedAssetAccountGLs', N'Jits.Neptune.Web.FixedAsset.Domain.FixedAssetAccountGLConfig', N'')
SET IDENTITY_INSERT [dbo].[MasterMapping] OFF
GO

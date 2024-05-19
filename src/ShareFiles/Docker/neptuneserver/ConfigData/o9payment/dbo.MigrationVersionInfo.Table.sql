USE [o9payment]
GO
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (637134696000000000, CAST(N'2023-05-05T07:14:09.000' AS DateTime), N'Core data base schema')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (637134792000000000, CAST(N'2023-05-05T07:14:10.000' AS DateTime), N'Payment data base schema')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (637134858000000000, CAST(N'2023-05-05T07:14:10.000' AS DateTime), N'Core data required data')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (637134864000000005, CAST(N'2023-05-05T07:14:11.000' AS DateTime), N'Neptune version Localization installed. Update Data')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (637134936000000005, CAST(N'2023-05-05T07:14:11.000' AS DateTime), N'Neptune version Payment data. Update Data')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (637397514000000000, CAST(N'2023-05-05T07:14:10.000' AS DateTime), N'Core data required data indexes')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (637478538042000000, CAST(N'2023-05-05T07:14:11.000' AS DateTime), N'IFC GLs base schema')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (637981440000000000, CAST(N'2023-05-05T07:14:11.000' AS DateTime), N'Add last update date for tables')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638035848000000000, CAST(N'2023-05-05T07:14:10.000' AS DateTime), N'Add Sync Data table')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638072136000000000, CAST(N'2023-05-05T07:14:10.000' AS DateTime), N'Add Entity Field table')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638087688000000000, CAST(N'2023-05-05T07:14:10.000' AS DateTime), N'Add Transaction Number Field to Transaction table')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638125752610000005, CAST(N'2023-05-05T07:14:12.000' AS DateTime), N'Neptune version Alter Id To Code Migration. Update Data')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638133473400000005, CAST(N'2023-05-05T07:14:12.000' AS DateTime), N'Neptune version Add neptune service. Update Data')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638145540000000000, CAST(N'2023-05-05T07:14:10.000' AS DateTime), N'Add Sync Registry table')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638149059600000005, CAST(N'2023-05-05T07:14:12.000' AS DateTime), N'Neptune version PaymentDataUpdateBackupDir. Update Data')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638155950600000000, CAST(N'2023-05-05T07:14:12.000' AS DateTime), N'Add Ifc Table')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638156103000000000, CAST(N'2023-05-05T07:14:12.000' AS DateTime), N'Add PaymentIFC NeptuneService')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638161092000000000, CAST(N'2023-05-05T07:14:10.000' AS DateTime), N'Add more Transaction fields')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638173188000000000, CAST(N'2023-05-05T07:14:10.000' AS DateTime), N'Add Ref TransId Channeld Transaction fields')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638175796800000005, CAST(N'2023-05-05T07:14:12.000' AS DateTime), N'Neptune version Add pmt fee neptune service. Update Data')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638187876000000000, CAST(N'2023-05-06T07:39:43.000' AS DateTime), N'Add UserCode BranchCode Transaction fields')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638200254000000000, CAST(N'2023-05-27T07:59:46.000' AS DateTime), N'Remove UserId field in Transaction')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638207184000000000, CAST(N'2023-05-27T07:59:46.000' AS DateTime), N'Remove Transaction details ReferenceId field')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638209810910000005, CAST(N'2023-06-09T05:35:39.000' AS DateTime), N'Neptune version Updated Code List. Update Data')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638209959220000005, CAST(N'2023-05-05T07:14:12.000' AS DateTime), N'Neptune version Remove Tariff and Accounting Group Migration. Update Data')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638210358000000000, CAST(N'2023-05-30T04:35:56.000' AS DateTime), N'Add locale string for not exist error')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638213256000000000, CAST(N'2023-06-06T05:33:14.000' AS DateTime), N'Add more GLEntries Accounting Group field')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638247067520000005, CAST(N'2023-05-06T07:39:44.000' AS DateTime), N'Neptune version CodeList Schema. Update Data')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638254503000000000, CAST(N'2023-07-31T11:57:07.000' AS DateTime), N'Add index for Transaction, Transaction Details table')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638283837000000005, CAST(N'2023-08-25T10:42:43.000' AS DateTime), N'Neptune version Add neptune service code list. Update Data')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638294490000000000, CAST(N'2023-09-06T03:32:22.000' AS DateTime), N'Increase interval clear cache time')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638316082910000005, CAST(N'2023-05-06T07:39:44.000' AS DateTime), N'Neptune version Updated Code List. Update Data')
GO

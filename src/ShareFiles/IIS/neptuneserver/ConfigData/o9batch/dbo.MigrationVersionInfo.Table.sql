USE [o9batch]
GO
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (637134696000000000, CAST(N'2023-05-27T08:08:22.000' AS DateTime), N'Core data base schema')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (637134792600000000, CAST(N'2023-05-27T08:08:23.000' AS DateTime), N'Batch data base schema')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (637134858000000000, CAST(N'2023-05-27T08:08:23.000' AS DateTime), N'Core data required data')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (637134864900000005, CAST(N'2023-05-27T08:08:24.000' AS DateTime), N'Neptune version Batch data install. Update Data')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (637397514000000000, CAST(N'2023-05-27T08:08:23.000' AS DateTime), N'Core data required data indexes')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638001450900000005, CAST(N'2023-05-27T08:08:24.000' AS DateTime), N'Neptune version Batch configuration installed. Update Data')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638035848000000000, CAST(N'2023-05-27T08:08:23.000' AS DateTime), N'Add Sync Data table')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638072136000000000, CAST(N'2023-05-27T08:08:23.000' AS DateTime), N'Add Entity Field table')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638087688000000000, CAST(N'2023-05-27T08:08:23.000' AS DateTime), N'Add Transaction Number Field to Transaction table')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638142216600000000, CAST(N'2023-05-27T08:08:24.000' AS DateTime), N'Batch thread history create')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638145540000000000, CAST(N'2023-05-27T08:08:23.000' AS DateTime), N'Add Sync Registry table')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638161092000000000, CAST(N'2023-05-27T08:08:23.000' AS DateTime), N'Add more Transaction fields')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638173188000000000, CAST(N'2023-05-27T08:08:23.000' AS DateTime), N'Add Ref TransId Channeld Transaction fields')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638187876000000000, CAST(N'2023-05-27T08:08:23.000' AS DateTime), N'Add UserCode BranchCode Transaction fields')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638200254000000000, CAST(N'2023-05-27T08:08:23.000' AS DateTime), N'Remove UserId field in Transaction')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638205486900000005, CAST(N'2023-05-27T08:08:24.000' AS DateTime), N'Neptune version Batch step add Credit Provisioning. Update Data')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638205492910000005, CAST(N'2023-05-27T08:08:24.000' AS DateTime), N'Neptune version Batch step add Credit Provisioning. Update Data')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638205492950000005, CAST(N'2023-05-27T08:08:25.000' AS DateTime), N'Neptune version Batch step add AddBatchStepMigration3. Update Data')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638205493590000005, CAST(N'2023-05-30T04:35:10.000' AS DateTime), N'Neptune version Batch step add AddBatchStepMigration3. Update Data')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638205565590000005, CAST(N'2023-05-31T04:14:32.000' AS DateTime), N'Neptune version Batch step add AddBatchStepMigration4. Update Data')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638206429590000005, CAST(N'2023-06-06T05:32:51.000' AS DateTime), N'Neptune version Batch step add AddBatchStepMigration5. Update Data')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638207184000000000, CAST(N'2023-05-27T08:08:23.000' AS DateTime), N'Remove Transaction details ReferenceId field')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638209597590000005, CAST(N'2023-05-30T04:35:10.000' AS DateTime), N'Neptune version Update data batch. Update Data')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638210358000000000, CAST(N'2023-05-30T04:35:09.000' AS DateTime), N'Add locale string for not exist error')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638213256000000000, CAST(N'2023-06-06T05:32:50.000' AS DateTime), N'Add more GLEntries Accounting Group field')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638225268000000005, CAST(N'2023-06-19T05:38:07.000' AS DateTime), N'Neptune version Batch data re-install. Update Data')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638231292000000005, CAST(N'2023-06-26T10:33:25.000' AS DateTime), N'Neptune version Batch data re-install. Update Data')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638237439000000005, CAST(N'2023-07-05T06:46:25.000' AS DateTime), N'Neptune version Batch data re-install. Update Data')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638253805200000005, CAST(N'2023-07-26T09:36:55.000' AS DateTime), N'Neptune version Batch data re-install. Update Data')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638254503000000000, CAST(N'2023-07-26T09:36:54.000' AS DateTime), N'Add index for Transaction, Transaction Details table')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638261546400000005, CAST(N'2023-07-31T10:57:02.000' AS DateTime), N'Neptune version Batch data re-install. Update Data')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638264223600000005, CAST(N'2023-08-02T10:33:01.000' AS DateTime), N'Neptune version Batch data re-install. Update Data')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638271034800000005, CAST(N'2023-08-15T11:30:29.000' AS DateTime), N'Neptune version Batch data re-install. Update Data')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638278810800000005, CAST(N'2023-08-18T10:42:21.000' AS DateTime), N'Neptune version Batch data re-install. Update Data')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638294490000000000, CAST(N'2023-09-06T03:31:54.000' AS DateTime), N'Increase interval clear cache time')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638295322200000005, CAST(N'2023-09-07T04:49:05.000' AS DateTime), N'Neptune version Batch data re-install. Update Data')
INSERT [dbo].[MigrationVersionInfo] ([Version], [AppliedOn], [Description]) VALUES (638296189200000000, CAST(N'2023-09-08T04:48:13.000' AS DateTime), N'Create CodeList table and Insert Workflow CodeList')
GO

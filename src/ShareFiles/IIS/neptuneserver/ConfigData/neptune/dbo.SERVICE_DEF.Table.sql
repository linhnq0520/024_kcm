USE [neptune]
GO
INSERT [dbo].[SERVICE_DEF] ([SERVICE_ID], [SERVICE_CODE], [SERVICE_NAME], [STATUS], [QUEUE_NAME], [ACCEPT_TIME], [GRPC_STATUS], [GRPC_TIMEOUT], [GRPC_URL], [EVENT_REGISTRATION], [IMPORT_EXPORT_STEP_CODE], [CONCURRENT_THREADS], [SERVICE_INSTANCE_TYPE]) VALUES (N'ACT', N'ACT', N'Accounting service', N'Active', N'queue-act', 1694151150294, N'Active', 60, N'https://localhost:5010', N'Mine', N'Yes', 8, N'Stateless')
INSERT [dbo].[SERVICE_DEF] ([SERVICE_ID], [SERVICE_CODE], [SERVICE_NAME], [STATUS], [QUEUE_NAME], [ACCEPT_TIME], [GRPC_STATUS], [GRPC_TIMEOUT], [GRPC_URL], [EVENT_REGISTRATION], [IMPORT_EXPORT_STEP_CODE], [CONCURRENT_THREADS], [SERVICE_INSTANCE_TYPE]) VALUES (N'ADM', N'ADM', N'Admin service', N'Active', N'queue-adm', 1694151145581, N'Active', 60, N'https://localhost:5012', N'Always', N'Yes', 8, N'Stateless')
INSERT [dbo].[SERVICE_DEF] ([SERVICE_ID], [SERVICE_CODE], [SERVICE_NAME], [STATUS], [QUEUE_NAME], [ACCEPT_TIME], [GRPC_STATUS], [GRPC_TIMEOUT], [GRPC_URL], [EVENT_REGISTRATION], [IMPORT_EXPORT_STEP_CODE], [CONCURRENT_THREADS], [SERVICE_INSTANCE_TYPE]) VALUES (N'BCH', N'BCH', N'Batch service', N'Active', N'queue-bch', 1694151151191, N'Active', 60, N'https://localhost:5014', N'Always', N'Yes', 8, N'Stateless')
INSERT [dbo].[SERVICE_DEF] ([SERVICE_ID], [SERVICE_CODE], [SERVICE_NAME], [STATUS], [QUEUE_NAME], [ACCEPT_TIME], [GRPC_STATUS], [GRPC_TIMEOUT], [GRPC_URL], [EVENT_REGISTRATION], [IMPORT_EXPORT_STEP_CODE], [CONCURRENT_THREADS], [SERVICE_INSTANCE_TYPE]) VALUES (N'CAR', N'CAR', N'Card', N'Active', N'queue-car', 1694151160689, N'Active', 60, N'https://localhost:5050', N'Always', N'Yes', 8, N'Stateless')
INSERT [dbo].[SERVICE_DEF] ([SERVICE_ID], [SERVICE_CODE], [SERVICE_NAME], [STATUS], [QUEUE_NAME], [ACCEPT_TIME], [GRPC_STATUS], [GRPC_TIMEOUT], [GRPC_URL], [EVENT_REGISTRATION], [IMPORT_EXPORT_STEP_CODE], [CONCURRENT_THREADS], [SERVICE_INSTANCE_TYPE]) VALUES (N'CMS', N'CMS', N'CMS service', N'Active', N'queue-cms', 1694151161822, N'Active', 60, N'https://localhost:5016', N'Always', N'Yes', 8, N'Stateful')
INSERT [dbo].[SERVICE_DEF] ([SERVICE_ID], [SERVICE_CODE], [SERVICE_NAME], [STATUS], [QUEUE_NAME], [ACCEPT_TIME], [GRPC_STATUS], [GRPC_TIMEOUT], [GRPC_URL], [EVENT_REGISTRATION], [IMPORT_EXPORT_STEP_CODE], [CONCURRENT_THREADS], [SERVICE_INSTANCE_TYPE]) VALUES (N'CRD', N'CRD', N'Credit service', N'Active', N'queue-crd', 1694151152012, N'Active', 60, N'https://localhost:5018', N'Mine', N'Yes', 8, N'Stateless')
INSERT [dbo].[SERVICE_DEF] ([SERVICE_ID], [SERVICE_CODE], [SERVICE_NAME], [STATUS], [QUEUE_NAME], [ACCEPT_TIME], [GRPC_STATUS], [GRPC_TIMEOUT], [GRPC_URL], [EVENT_REGISTRATION], [IMPORT_EXPORT_STEP_CODE], [CONCURRENT_THREADS], [SERVICE_INSTANCE_TYPE]) VALUES (N'CSH', N'CSH', N'Cash service', N'Active', N'queue-csh', 1694151152453, N'Active', 60, N'https://localhost:5020', N'Mine', N'Yes', 8, N'Stateless')
INSERT [dbo].[SERVICE_DEF] ([SERVICE_ID], [SERVICE_CODE], [SERVICE_NAME], [STATUS], [QUEUE_NAME], [ACCEPT_TIME], [GRPC_STATUS], [GRPC_TIMEOUT], [GRPC_URL], [EVENT_REGISTRATION], [IMPORT_EXPORT_STEP_CODE], [CONCURRENT_THREADS], [SERVICE_INSTANCE_TYPE]) VALUES (N'CTM', N'CTM', N'Customer service', N'Active', N'queue-ctm', 1694151153388, N'Active', 60, N'https://localhost:5022', N'Mine', N'Yes', 8, N'Stateless')
INSERT [dbo].[SERVICE_DEF] ([SERVICE_ID], [SERVICE_CODE], [SERVICE_NAME], [STATUS], [QUEUE_NAME], [ACCEPT_TIME], [GRPC_STATUS], [GRPC_TIMEOUT], [GRPC_URL], [EVENT_REGISTRATION], [IMPORT_EXPORT_STEP_CODE], [CONCURRENT_THREADS], [SERVICE_INSTANCE_TYPE]) VALUES (N'DPT', N'DPT', N'Deposit service', N'Active', N'queue-dpt', 1694151154046, N'Active', 60, N'https://localhost:5024', N'Always', N'Yes', 8, N'Stateless')
INSERT [dbo].[SERVICE_DEF] ([SERVICE_ID], [SERVICE_CODE], [SERVICE_NAME], [STATUS], [QUEUE_NAME], [ACCEPT_TIME], [GRPC_STATUS], [GRPC_TIMEOUT], [GRPC_URL], [EVENT_REGISTRATION], [IMPORT_EXPORT_STEP_CODE], [CONCURRENT_THREADS], [SERVICE_INSTANCE_TYPE]) VALUES (N'EML', N'EML', N'Email  service', N'Active', N'queue-eml', 1694151155491, N'Active', 60, N'https://localhost:5026', N'Mine', N'Yes', 8, N'Stateless')
INSERT [dbo].[SERVICE_DEF] ([SERVICE_ID], [SERVICE_CODE], [SERVICE_NAME], [STATUS], [QUEUE_NAME], [ACCEPT_TIME], [GRPC_STATUS], [GRPC_TIMEOUT], [GRPC_URL], [EVENT_REGISTRATION], [IMPORT_EXPORT_STEP_CODE], [CONCURRENT_THREADS], [SERVICE_INSTANCE_TYPE]) VALUES (N'EMS', N'EMS', N'Event Management service', N'Active', N'queue-ems', 1694151157297, N'Active', 60, N'https://localhost:5028', N'Always', N'Yes', 8, N'Stateless')
INSERT [dbo].[SERVICE_DEF] ([SERVICE_ID], [SERVICE_CODE], [SERVICE_NAME], [STATUS], [QUEUE_NAME], [ACCEPT_TIME], [GRPC_STATUS], [GRPC_TIMEOUT], [GRPC_URL], [EVENT_REGISTRATION], [IMPORT_EXPORT_STEP_CODE], [CONCURRENT_THREADS], [SERVICE_INSTANCE_TYPE]) VALUES (N'FAC', N'FAC', N'Fixed Asset service', N'Active', N'queue-fac', 1694151157588, N'Active', 60, N'https://localhost:5030', N'Mine', N'Yes', 8, N'Stateless')
INSERT [dbo].[SERVICE_DEF] ([SERVICE_ID], [SERVICE_CODE], [SERVICE_NAME], [STATUS], [QUEUE_NAME], [ACCEPT_TIME], [GRPC_STATUS], [GRPC_TIMEOUT], [GRPC_URL], [EVENT_REGISTRATION], [IMPORT_EXPORT_STEP_CODE], [CONCURRENT_THREADS], [SERVICE_INSTANCE_TYPE]) VALUES (N'FX', N'FX', N'Foreign Exchange service', N'Active', N'queue-fx', 1694151160639, N'Active', 60, N'https://localhost:5032', N'Mine', N'Yes', 8, N'Stateless')
INSERT [dbo].[SERVICE_DEF] ([SERVICE_ID], [SERVICE_CODE], [SERVICE_NAME], [STATUS], [QUEUE_NAME], [ACCEPT_TIME], [GRPC_STATUS], [GRPC_TIMEOUT], [GRPC_URL], [EVENT_REGISTRATION], [IMPORT_EXPORT_STEP_CODE], [CONCURRENT_THREADS], [SERVICE_INSTANCE_TYPE]) VALUES (N'IFC', N'IFC', N'IFC service', N'Active', N'queue-ifc', 1681882046890, N'Active', 60, N'https://ifc.api:5000', N'Mine', N'Yes', 8, N'Stateless')
INSERT [dbo].[SERVICE_DEF] ([SERVICE_ID], [SERVICE_CODE], [SERVICE_NAME], [STATUS], [QUEUE_NAME], [ACCEPT_TIME], [GRPC_STATUS], [GRPC_TIMEOUT], [GRPC_URL], [EVENT_REGISTRATION], [IMPORT_EXPORT_STEP_CODE], [CONCURRENT_THREADS], [SERVICE_INSTANCE_TYPE]) VALUES (N'IMP', N'IMP', N'Import service', N'Active', N'queue-imp', 1694151166989, N'Active', 60, N'https://localhost:5046', N'Always', N'Yes', 8, N'Stateless')
INSERT [dbo].[SERVICE_DEF] ([SERVICE_ID], [SERVICE_CODE], [SERVICE_NAME], [STATUS], [QUEUE_NAME], [ACCEPT_TIME], [GRPC_STATUS], [GRPC_TIMEOUT], [GRPC_URL], [EVENT_REGISTRATION], [IMPORT_EXPORT_STEP_CODE], [CONCURRENT_THREADS], [SERVICE_INSTANCE_TYPE]) VALUES (N'MS1', N'MS1', N'micro service 1', N'Active', N'queue-ms1', 1663849970012, N'Active', 60, N'https://localhost:44381/', N'Mine', N'No', 8, N'Stateless')
INSERT [dbo].[SERVICE_DEF] ([SERVICE_ID], [SERVICE_CODE], [SERVICE_NAME], [STATUS], [QUEUE_NAME], [ACCEPT_TIME], [GRPC_STATUS], [GRPC_TIMEOUT], [GRPC_URL], [EVENT_REGISTRATION], [IMPORT_EXPORT_STEP_CODE], [CONCURRENT_THREADS], [SERVICE_INSTANCE_TYPE]) VALUES (N'MS2', N'MS2', N'micro service 2', N'Active', N'queue-ms2', 0, N'Active', 60, N'', N'No', N'No', 8, N'Stateless')
INSERT [dbo].[SERVICE_DEF] ([SERVICE_ID], [SERVICE_CODE], [SERVICE_NAME], [STATUS], [QUEUE_NAME], [ACCEPT_TIME], [GRPC_STATUS], [GRPC_TIMEOUT], [GRPC_URL], [EVENT_REGISTRATION], [IMPORT_EXPORT_STEP_CODE], [CONCURRENT_THREADS], [SERVICE_INSTANCE_TYPE]) VALUES (N'MTG', N'MTG', N'Mortgage service', N'Active', N'queue-mtg', 1694151162783, N'Active', 60, N'https://localhost:5036', N'Mine', N'Yes', 8, N'Stateless')
INSERT [dbo].[SERVICE_DEF] ([SERVICE_ID], [SERVICE_CODE], [SERVICE_NAME], [STATUS], [QUEUE_NAME], [ACCEPT_TIME], [GRPC_STATUS], [GRPC_TIMEOUT], [GRPC_URL], [EVENT_REGISTRATION], [IMPORT_EXPORT_STEP_CODE], [CONCURRENT_THREADS], [SERVICE_INSTANCE_TYPE]) VALUES (N'NEMS', N'NEMS', N'Neptune Event Management System', N'Active', N'queue-NEMS', 0, N'Active', 60, N'', N'Mine', N'No', 8, N'Stateless')
INSERT [dbo].[SERVICE_DEF] ([SERVICE_ID], [SERVICE_CODE], [SERVICE_NAME], [STATUS], [QUEUE_NAME], [ACCEPT_TIME], [GRPC_STATUS], [GRPC_TIMEOUT], [GRPC_URL], [EVENT_REGISTRATION], [IMPORT_EXPORT_STEP_CODE], [CONCURRENT_THREADS], [SERVICE_INSTANCE_TYPE]) VALUES (N'PMT', N'PMT', N'Payment service', N'Active', N'queue-pmt', 1694151163189, N'Active', 60, N'https://localhost:5038', N'Mine', N'Yes', 8, N'Stateless')
INSERT [dbo].[SERVICE_DEF] ([SERVICE_ID], [SERVICE_CODE], [SERVICE_NAME], [STATUS], [QUEUE_NAME], [ACCEPT_TIME], [GRPC_STATUS], [GRPC_TIMEOUT], [GRPC_URL], [EVENT_REGISTRATION], [IMPORT_EXPORT_STEP_CODE], [CONCURRENT_THREADS], [SERVICE_INSTANCE_TYPE]) VALUES (N'PTY', N'PTY', N'Party', N'Active', N'queue-pty', 1694151166592, N'Active', 60, N'https://localhost:5048', N'Always', N'Yes', 8, N'Stateless')
INSERT [dbo].[SERVICE_DEF] ([SERVICE_ID], [SERVICE_CODE], [SERVICE_NAME], [STATUS], [QUEUE_NAME], [ACCEPT_TIME], [GRPC_STATUS], [GRPC_TIMEOUT], [GRPC_URL], [EVENT_REGISTRATION], [IMPORT_EXPORT_STEP_CODE], [CONCURRENT_THREADS], [SERVICE_INSTANCE_TYPE]) VALUES (N'RPT', N'RPT', N'Report service', N'Active', N'queue-rpt', 1694151159781, N'Active', 60, N'https://192.168.101.64:5040', N'Mine', N'Yes', 8, N'Stateless')
INSERT [dbo].[SERVICE_DEF] ([SERVICE_ID], [SERVICE_CODE], [SERVICE_NAME], [STATUS], [QUEUE_NAME], [ACCEPT_TIME], [GRPC_STATUS], [GRPC_TIMEOUT], [GRPC_URL], [EVENT_REGISTRATION], [IMPORT_EXPORT_STEP_CODE], [CONCURRENT_THREADS], [SERVICE_INSTANCE_TYPE]) VALUES (N'SPL', N'SPL', N'Sample service', N'Active', N'queue-spl', 1681464564235, N'Active', 60, N'https://sample.api:5000', N'Mine', N'Yes', 8, N'Stateless')
INSERT [dbo].[SERVICE_DEF] ([SERVICE_ID], [SERVICE_CODE], [SERVICE_NAME], [STATUS], [QUEUE_NAME], [ACCEPT_TIME], [GRPC_STATUS], [GRPC_TIMEOUT], [GRPC_URL], [EVENT_REGISTRATION], [IMPORT_EXPORT_STEP_CODE], [CONCURRENT_THREADS], [SERVICE_INSTANCE_TYPE]) VALUES (N'VCH', N'VCH', N'Voucher service', N'Active', N'queue-vch', 1694151166152, N'Active', 60, N'https://localhost:5044', N'Mine', N'Yes', 8, N'Stateless')
GO

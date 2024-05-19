USE [o9cms]
GO
SET IDENTITY_INSERT [dbo].[DesignItem] ON 

INSERT [dbo].[DesignItem] ([Id], [GroupId], [isActive], [Title], [DisplayOrder], [AttId], [Img], [KeyNew], [Type], [Template]) VALUES (1, N'basic_fields', 1, N'{"en":"Checkbox","vi":"Hộp kiểm tra"}', N'6', N'defaut_check_box', N'check_box_outline_blank', NULL, NULL, N'{"default":{"name":"Check Box New","code":"a439df36155169f7","codeHidden":"","class":"col-sm-1 col-md-1","condition":"","ofgroup":"","class_ofgroup":"col-sm-1 col-md-1","role":""},"config":{"action":"","txFoActions":"[\n    {\n        \"function\": \"\",\n        \"status\": \"A\",\n        \"para\": []\n    }\n]","txFo":"[\n    {\n        \"txcode\": \"\",\n        \"input\": {}\n    }\n]","useAction":"true","icon":"fa-floppy-o","color":"info","onTable":"","isMasterData":"false","tableMasterData":"","privateKeyTableMasterData":""},"role":{"visible":"","disabled":""},"property":{"danger":"","warning":"true"},"validate":{},"lang":{},"configAVD":{},"inputtype":"jCheckbox"}')
INSERT [dbo].[DesignItem] ([Id], [GroupId], [isActive], [Title], [DisplayOrder], [AttId], [Img], [KeyNew], [Type], [Template]) VALUES (2, N'basic_fields', 1, N'{"en":"Mask Input","vi":""}', N'7', N'defaut_mask_input', N'space_bar', NULL, NULL, N'{"default":{"name":"Default component","code":"4a563edde0f0558f","codeHidden":"","class":"col-xl-4 col-lg-4 col-md-5 col-sm-5 offset-1-right","condition":"","ofgroup":"","class_ofgroup":"col-sm-12 col-md-12","role":""},"config":{"structable":"table.col","structable_read":"","data_default":"","data_type":"edit","component_title":"","mask_format":"","mask_data_format":"","value_type":"all","auto_delete":"true","mask_mode":"default","isLookup":"false","callform":"","callform_detail":"","callform_detail_mode":"modal","data_view":"","data_value":""},"role":{"disabled":"","visible":""},"property":{},"validate":{"request":false,"condistion":[]},"lang":{"ui":{"vi":{"Mẫu component":"Default component"},"en":{"Mẫu component":"Default component"}},"mask_format":{},"validate":{}},"configAVD":{},"inputtype":"jMaskInput"}')
INSERT [dbo].[DesignItem] ([Id], [GroupId], [isActive], [Title], [DisplayOrder], [AttId], [Img], [KeyNew], [Type], [Template]) VALUES (3, N'basic_fields', 1, N'{"en":"Table Default","vi":"Bảng mẫu"}', N'13', N'default_table', N'table_chart', NULL, NULL, N'{"default":{"name":"Default component","code":"4a563edde0f0558f","codeHidden":"","class":"col-sm-12 col-md-12","condition":"","ofgroup":"","class_ofgroup":"col-sm-12 col-md-12","role":""},"config":{"structable":"table.col","query_data":"","paging_record":"5","columns":"[\n    {\n        \"code\": \"table.name\",\n        \"title\": \"Tên\",\n        \"inputtype\": \"ColumnString\",\n        \"config\": {}\n    }\n]"},"role":{},"property":{},"validate":{},"lang":{},"configAVD":{},"inputtype":"cTableDefault"}')
INSERT [dbo].[DesignItem] ([Id], [GroupId], [isActive], [Title], [DisplayOrder], [AttId], [Img], [KeyNew], [Type], [Template]) VALUES (4, N'layout_fields', 1, N'{"en":"Layout","vi":"Mẫu bố trí"}', N'1', N'defaut_layout', N'view_compact', NULL, N'layout', N'{"name":"","des":"","class":"","codeHidden":"","inputtype":"cLayout"}')
INSERT [dbo].[DesignItem] ([Id], [GroupId], [isActive], [Title], [DisplayOrder], [AttId], [Img], [KeyNew], [Type], [Template]) VALUES (5, N'advanced_fields', 1, N'{"en":"Same Main","vi":"Same Main"}', N'17', N'default_samemain', N'ballot', NULL, NULL, N'{"default":{"name":"Mẫu component","code":"4a563edde0f0558f","codeHidden":"","class":"col-sm-12 col-md-12","condition":"","ofgroup":"","class_ofgroup":"col-sm-12 col-md-12","role":""},"config":{"action":"","structable":"table.col","structable_read":"","data_default":"{}","callform":"","callData":""},"role":{"visible":"","disabled":""},"property":{},"validate":{},"lang":{"ui":{"vi":{},"en":{}}},"configAVD":{},"inputtype":"jSameMain"}')
INSERT [dbo].[DesignItem] ([Id], [GroupId], [isActive], [Title], [DisplayOrder], [AttId], [Img], [KeyNew], [Type], [Template]) VALUES (6, N'basic_fields', 1, N'{"en":"Button","vi":"Nút bấm"}', N'4', N'defaut_button', N'panorama_wide_angle', NULL, NULL, N'{"config":{"useAction":"false","action":"","structable":"","structable_read":"","data_default":"","color":"primary","icon":"fa-search","txFo":"","onTable":""},"role":{"visible":"","disabled":""},"property":{},"validate":{"request":false},"lang":{},"configAVD":{},"inputtype":"cButton","default":{"name":"Default Component","code":"default","codeHidden":"","class":"","condition":"","role":""}}')
INSERT [dbo].[DesignItem] ([Id], [GroupId], [isActive], [Title], [DisplayOrder], [AttId], [Img], [KeyNew], [Type], [Template]) VALUES (7, N'basic_fields', 1, N'{"en":"Select","vi":"Hộp chọn"}', N'12', N'default_select', N'expand_more', NULL, NULL, N'{"default":{"name":"Default component","code":"4a563edde0f0558f","codeHidden":"","class":"col-sm-12 col-md-12","condition":"","ofgroup":"","class_ofgroup":"col-sm-12 col-md-12","role":""},"config":{"structable":"","structable_read":"","cdlist":{},"data_default":"","data_mode":"query","query_data":"","is_multi_select":"false","is_multi_col":"false","get_data_format":"c_cdlist.cdid","selected_view_format":"@c_cdlist.caption","table_format":"[\n        {\n            \"title\": \"Name\",\n            \"code\": \"col.col_name\"\n        },\n        {\n            \"title\": \"ID\",\n            \"code\": \"col.col_id\"\n        }\n    ]","col_format":"@c_cdlist.caption","json_data":"[\n        {\n            \"c_cdlist\": {\n                \"cdid\": \"id_1\",\n                \"caption\": \"val_1\"\n            }\n        },\n        {\n            \"c_cdlist\": {\n                \"cdid\": \"id_2\",\n                \"caption\": \"val_2\"\n            }\n        }\n        ,\n        {\n            \"c_cdlist\": {\n                \"cdid\": \"id_3\",\n                \"caption\": \"val_3\"\n            }\n        }\n    ]","key_selected":"c_cdlist.cdid","useAction":"false","isAutoDefault":"true"},"role":{"disabled":"","visible":"","other":"","other2":""},"property":{},"validate":{"request":false},"lang":{"ui":{"vi":{"Mẫu component":"Mẫu component"},"en":{"Mẫu component":"Mẫu component"}}},"configAVD":{},"inputtype":"jSelect"}')
INSERT [dbo].[DesignItem] ([Id], [GroupId], [isActive], [Title], [DisplayOrder], [AttId], [Img], [KeyNew], [Type], [Template]) VALUES (8, N'advanced_fields', 1, N'{"en":"Currency","vi":"Đơn vị tiền tệ"}', N'16', N'default_currency', N'attach_money', NULL, NULL, N'{"default":{"name":"Default component","code":"4a563edde0f0558f","codeHidden":"","class":"col-sm-12 col-md-12","condition":"","ofgroup":"","class_ofgroup":"col-sm-12 col-md-12","role":""},"config":{"structable":"table.col","structable_read":"table.col","data_default":"","format":"#,###.00","decimal_length":2},"role":{"visible":"","disabled":""},"property":{},"validate":{"request":false,"min":0},"lang":{},"configAVD":{},"inputtype":"jCurrency"}')
INSERT [dbo].[DesignItem] ([Id], [GroupId], [isActive], [Title], [DisplayOrder], [AttId], [Img], [KeyNew], [Type], [Template]) VALUES (9, N'basic_fields', 1, N'{"en":"Text Input","vi":"Nhập văn bản"}', N'3', N'defaut_text_input', N'font_download', NULL, NULL, N'{"default":{"name":"","code":"","codeHidden":"","class":"col-xl-4 col-lg-4 col-md-5 col-sm-5 offset-1-right","condition":"","ofgroup":"","class_ofgroup":"col-sm-12 col-md-12","role":""},"config":{"action":"","structable":"","structable_read":"","data_default":"","isLookup":"false","callform":"","callform_detail":"","callform_detail_mode":"modal","data_view":"","data_value":"","is_disabled":"false"},"role":{"visible":"","disabled":""},"property":{},"validate":{"request":false},"lang":{},"configAVD":{},"inputtype":"cTextInput"}')
INSERT [dbo].[DesignItem] ([Id], [GroupId], [isActive], [Title], [DisplayOrder], [AttId], [Img], [KeyNew], [Type], [Template]) VALUES (10, N'basic_fields', 1, N'{"en":"Button Upload","vi":"Nút bấm tải file lên"}', N'23', N'defaut_button_upload', N'upload', NULL, NULL, N'{
      "config": {
         "useAction": "false",
         "action": "",
         "structable": "",
         "structable_read": "",
         "data_default": "",
         "color": "primary",
         "icon": "upload",
         "txFo": "",
         "onTable": ""
      },
      "role": {
         "visible": "",
         "disabled": ""
      },
      "property": {},
      "validate": {
         "request": false
      },
      "lang": {},
      "configAVD": {},
      "inputtype": "jUploadFile",
      "default": {
         "name": "Default Component",
         "code": "default",
         "codeHidden": "",
         "class": "",
         "condition": "",
         "role": ""
      }
   }')
INSERT [dbo].[DesignItem] ([Id], [GroupId], [isActive], [Title], [DisplayOrder], [AttId], [Img], [KeyNew], [Type], [Template]) VALUES (11, N'advanced_fields', 1, N'{"en":"Multivalue","vi":"Đa giá trị"}', N'15', N'default_multivalue', N'featured_play_list', NULL, NULL, N'{"default":{"name":"Mẫu component","code":"4a563edde0f0558f","codeHidden":"","class":"col-sm-12 col-md-12","condition":"","ofgroup":"","class_ofgroup":"col-sm-12 col-md-12","role":""},"config":{"action":"","structable":"table.col","structable_read":"","data_default":"{}","callform":"","hidden":"","is_open":"true","has_default":"false","value_default":"","address_default":""},"role":{"visible":"","disabled":""},"property":{},"validate":{},"lang":{"ui":{"vi":{"Mẫu component":"Mẫu component"},"en":{"Mẫu component":"Mẫu component"}},"mask_format":{},"validate":{}},"configAVD":{},"inputtype":"jMutiValue"}')
INSERT [dbo].[DesignItem] ([Id], [GroupId], [isActive], [Title], [DisplayOrder], [AttId], [Img], [KeyNew], [Type], [Template]) VALUES (12, N'basic_fields', 1, N'{"en":"Button Print","vi":"Nút bấm in"}', N'19', N'defaut_button_print', N'print', NULL, NULL, N'{"config":{"useAction":"false","action":"","structable":"","structable_read":"","data_default":"","color":"primary","icon":"print","txFo":"[\n    {\n        \"txcode\": \"#sys:fo-print-voucher\",\n        \"input\": {}\n    }\n]","onTable":""},"role":{"visible":"","disabled":""},"property":{},"validate":{"request":false},"lang":{},"configAVD":{},"inputtype":"jPrintVoucher","default":{"name":"Default Component","code":"default","codeHidden":"","class":"","condition":"","role":""}}')
INSERT [dbo].[DesignItem] ([Id], [GroupId], [isActive], [Title], [DisplayOrder], [AttId], [Img], [KeyNew], [Type], [Template]) VALUES (13, N'advanced_fields', 1, N'{"en":"Table Form","vi":"Bảng mẫu"}', N'8', N'defaut_table_form', N'list_alt', NULL, NULL, N'{"default":{"name":"Default component","code":"4a563edde0f0558f","codeHidden":"","class":"col-sm-12 col-md-12","condition":"","ofgroup":"","class_ofgroup":"col-sm-12 col-md-12","role":""},"config":{"structable":"","query_data":"","paging_record":"5","columns":"[\n    {\n        \"code\": \"table.name\",\n        \"title\": \"Tên\",\n        \"inputtype\": \"ColumnString\",\n        \"config\": {}\n    }\n]"},"role":{},"property":{},"validate":{},"lang":{},"configAVD":{},"inputtype":"jTableForm"}')
INSERT [dbo].[DesignItem] ([Id], [GroupId], [isActive], [Title], [DisplayOrder], [AttId], [Img], [KeyNew], [Type], [Template]) VALUES (14, N'basic_fields', 1, N'{"en":"Calendar","vi":"Lịch"}', N'21', N'defaut_calendar', N'print', NULL, NULL, N'{"config":{"structable":"","structable_read":"","data_default":"","color":"primary","icon":"print","eventFoStart":"","eventFoStart_config":"","eventClick":"","eventClick_config":""},"role":{"visible":"","disabled":""},"property":{},"validate":{"request":false},"lang":{},"configAVD":{},"inputtype":"jFullCalendar","default":{"name":"Default Component","code":"default","codeHidden":"","class":"","condition":"","role":""}}')
INSERT [dbo].[DesignItem] ([Id], [GroupId], [isActive], [Title], [DisplayOrder], [AttId], [Img], [KeyNew], [Type], [Template]) VALUES (15, N'basic_fields', 1, N'{"en":"Chart","vi":"Biểu đồ"}', N'14', N'default_chart', N'insert_chart', NULL, NULL, N'{"default":{"name":"Default component","code":"4a563edde0f0558f","codeHidden":"","class":"col-sm-12 col-md-12","condition":"","ofgroup":"","class_ofgroup":"col-sm-12 col-md-12","role":""},"config":{"query_data":"","chartType":"ColumnChart","chart_width":"","chart_height":"600","columns":"[\n    {\n        \"columnName\": \"Không cần tên\",\n        \"tableColumnGroup\": \"table1.recname\"\n    },\n    {\n        \"columnName\": \"Tổng của tableColumn 1\",\n        \"tableColumn\": \"table1.recvalue\"\n    },\n    {\n        \"columnName\": \"Tổng của tableColumn 2\",\n        \"tableColumn\": \"table1.recvalue\"\n    }\n]","options":"{\n    \"title\": \"Population of Largest U.S. Cities\",\n    \"chartArea\": {\n        \"width\": \"30%\"\n    },\n    \"hAxis\": {\n        \"title\": \"Total Population\",\n        \"minValue\": 0\n    },\n    \"vAxis\": {\n        \"title\": \"City\"\n    }\n}"},"role":{},"property":{},"validate":{},"lang":{},"configAVD":{},"inputtype":"jChart"}')
INSERT [dbo].[DesignItem] ([Id], [GroupId], [isActive], [Title], [DisplayOrder], [AttId], [Img], [KeyNew], [Type], [Template]) VALUES (16, N'basic_fields', 1, N'{"en":"Image","vi":"Hình ảnh"}', N'22', N'defaut_button_image', N'panorama_wide_angle', NULL, NULL, N'{"config":{"useAction":"false","action":"","structable":"","structable_read":"","data_default":"","color":"","icon":"fa-files-o","txFo":"","onTable":""},"role":{"visible":"","disabled":""},"property":{},"validate":{"request":false},"lang":{},"configAVD":{},"inputtype":"jImage","default":{"name":"","code":"default","codeHidden":"","class":"","condition":"","role":""}}')
INSERT [dbo].[DesignItem] ([Id], [GroupId], [isActive], [Title], [DisplayOrder], [AttId], [Img], [KeyNew], [Type], [Template]) VALUES (17, N'basic_fields', 1, N'{"en":"Radio Button","vi":"Nút chọn"}', N'10', N'radio_button_checked', N'article', NULL, NULL, N'{"default":{"name":"Mẫu component","code":"","class":"","condition":"","codeHidden":"facfa9b90cd6694f","role":""},"inputtype":"jRadioBox","config":{"structable":"table.col"},"validate":{},"lang":{"ui":{"vi":{},"en":{}}},"role":{},"property":{},"configAVD":{}}')
INSERT [dbo].[DesignItem] ([Id], [GroupId], [isActive], [Title], [DisplayOrder], [AttId], [Img], [KeyNew], [Type], [Template]) VALUES (18, N'layout_fields', 1, N'{"en":"View","vi":"Mẫu quan sát"}', N'2', N'defaut_view', N'preview', NULL, N'view', N'{"name":"","code":"","codeHidden":"","inputtype":"cView","isTab":"false"}')
INSERT [dbo].[DesignItem] ([Id], [GroupId], [isActive], [Title], [DisplayOrder], [AttId], [Img], [KeyNew], [Type], [Template]) VALUES (19, N'basic_fields', 1, N'{"en":"Label","vi":"Nhãn hiệu"}', N'11', N'default_label', N'label', NULL, NULL, N'{"default":{"name":"Label","code":"","codeHidden":"","class":"col-sm-2","condition":"","ofgroup":"","class_ofgroup":"col-sm-2","role":""},"config":{"action":"","structable":"","structable_read":"","data_default":"","isLookup":"false","callform":"","callform_detail":"","callform_detail_mode":"","data_view":"","data_value":""},"role":{"visible":"","disabled":""},"property":{},"validate":{"request":false},"lang":{},"configAVD":{},"inputtype":"jLabel"}')
INSERT [dbo].[DesignItem] ([Id], [GroupId], [isActive], [Title], [DisplayOrder], [AttId], [Img], [KeyNew], [Type], [Template]) VALUES (20, N'basic_fields', 1, N'{"en":"Text Area","vi":"Vùng văn bản to"}', N'9', N'default_text_area', N'article', NULL, NULL, N'{"default":{"name":"Mẫu component","code":"a439df36155169f7","codeHidden":"","class":"col-sm-12 col-md-12","condition":"","ofgroup":"","class_ofgroup":"col-sm-12 col-md-12","role":""},"config":{"action":"","txFoActions":"[\n    {\n        \"function\": \"\",\n        \"status\": \"A\",\n        \"para\": []\n    }\n]","txFo":"[\n    {\n        \"txcode\": \"\",\n        \"input\": {}\n    }\n]","useAction":"true","icon":"fa-floppy-o","color":"info","onTable":"","isMasterData":"false","tableMasterData":"","privateKeyTableMasterData":""},"role":{"visible":"","disabled":""},"property":{"danger":"","warning":"true"},"validate":{},"lang":{},"configAVD":{},"inputtype":"cTextArea"}')
INSERT [dbo].[DesignItem] ([Id], [GroupId], [isActive], [Title], [DisplayOrder], [AttId], [Img], [KeyNew], [Type], [Template]) VALUES (21, N'basic_fields', 1, N'{"en":"Table Search","vi":"Bảng mẫu"}', N'25', N'search_table', N'table_chart', NULL, NULL, N'{"default":{"name":"Default component","code":"4a563edde0f0558f","codeHidden":"","class":"col-sm-12 col-md-12","condition":"","ofgroup":"","class_ofgroup":"col-sm-12 col-md-12","role":""},"config":{"structable":"table.col","query_data":"","paging_record":"5","columns":"[\n    {\n        \"code\": \"table.name\",\n        \"title\": \"Tên\",\n        \"inputtype\": \"ColumnString\",\n        \"config\": {}\n    }\n]"},"role":{},"property":{},"validate":{},"lang":{},"configAVD":{},"inputtype":"jTableSearch"}')
INSERT [dbo].[DesignItem] ([Id], [GroupId], [isActive], [Title], [DisplayOrder], [AttId], [Img], [KeyNew], [Type], [Template]) VALUES (22, N'basic_fields', 1, N'{
		"en": "Get Signature",
		"vi": "Nút bấm tải file lên"
	}', N'42', N'defaut_button_signature', N'data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjgiIGhlaWdodD0iMjgiIHZpZXdCb3g9IjAgMCAyOCAyOCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4KPGcgY2xpcC1wYXRoPSJ1cmwoI2NsaXAwKSI+CjxwYXRoIG', N'24', NULL, N'{
		"config": {
			"useAction": "false",
			"action": "",
			"structable": "",
			"structable_read": "",
			"data_default": "",
			"color": "primary",
			"icon": "data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjgiIGhlaWdodD0iMjgiIHZpZXdCb3g9IjAgMCAyOCAyOCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4KPGcgY2xpcC1wYXRoPSJ1cmwoI2NsaXAwKSI+CjxwYXRoIGQ9Ik0yMC40ODkgMTAuODM2NUwyNC43MDc0IDEyLjM4NkwyMS4xOTkyIDIxLjkzNzhDMjAuODcwOSAyMi44MzYyIDE5LjA5MDUgMjUuNjQ3MyAxNy44NTA3IDI2LjIyMDdMMTcuNTQ5OCAyNy4wNDE0QzE3LjQ3MzIgMjcuMjQ5MyAxNy4yNzYzIDI3LjM3OTYgMTcuMDY3MyAyNy4zNzk2QzE3LjAwODIgMjcuMzc5NiAxNi45NDkxIDI3LjM2ODYgMTYuODkgMjcuMzQ3OEMxNi42MjQxIDI3LjI0OTMgMTYuNDg2MiAyNi45NTUgMTYuNTg0NyAyNi42ODY5TDE2Ljg2OTIgMjUuOTExMUMxNi4yNCAyNC42ODg4IDE2LjcwOTQgMjEuMTM5IDE2Ljk4NTIgMjAuMzg4M0wyMC40ODkgMTAuODM2NVpNMjYuNTkzOSAwLjcyOTg3NkMyNS40MzQgMC4zMDUzMDIgMjQuMDc2IDEuMTgyOSAyMy42ODc1IDIuMjQzMjRMMjEuMTQ2NyA5LjE2NTU1TDI1LjM2NCAxMC43MTI4TDI3LjkwMTYgMy43OTE2MkMyOC4yMjExIDIuOTI0OTcgMjcuNzU2IDEuMTU1NTQgMjYuNTkzOSAwLjcyOTg3NlpNMTguOTYxNCAxMC40Nzg3QzE5LjA3OTYgMTAuNTIyNCAxOS4yMDExIDEwLjU0MzIgMTkuMzE5MyAxMC41NDMyQzE5LjczNzMgMTAuNTQzMiAyMC4xMzAxIDEwLjI4NzIgMjAuMjg0NCA5Ljg3MTM1TDIyLjk2NTMgMi42NDA0NkMyMy4xNjM0IDIuMTA3NTUgMjIuODkwOSAxLjUxNTU2IDIyLjM1OCAxLjMxODU5QzIxLjgyMDcgMS4xMjM4MSAyMS4yMzMxIDEuMzkzIDIxLjAzNTEgMS45MjU5MUwxOC4zNTQxIDkuMTU2NzlDMTguMTU2IDkuNjg5NyAxOC40Mjg1IDEwLjI4MTcgMTguOTYxNCAxMC40Nzg3Wk0xNC42NDU3IDI0LjAzNzdDMTQuMzY4OCAyMy43NzYxIDE0LjAyNDEgMjMuNDUwMSAxMy40NjYgMjMuMjAxN0MxMy4wMDY0IDIyLjk5NyAxMi41NTg5IDIyLjk4NzIgMTIuMjMxNyAyMi45Nzk1QzEyLjE5NzggMjIuOTc5NSAxMi4xNTg0IDIyLjk3ODQgMTIuMTE5IDIyLjk3NzNDMTEuOTE0NCAyMi40MTcxIDExLjQ5OTYgMjIuMDY0NyAxMC44NzcgMjEuOTI2OEMxMC4wNTMgMjEuNzUyOSA5LjM5NTM4IDIyLjE0MTMgOC45MzkwNyAyMi40NDExQzguOTc5NTYgMjIuMjExNCA5LjA0NjMxIDIxLjkzNzggOS4wOTU1NSAyMS43NDA4QzkuMjUzMTMgMjEuMTA2MSA5LjQxNTA4IDIwLjQ0OTYgOS4yOTQ3MSAxOS44MzQ2QzkuMTk5NTEgMTkuMzQ4OCA4Ljc4OTE2IDE4Ljk4NzcgOC4yOTQ1NSAxOC45NTI2QzcuMDE5NzMgMTguODgxNSA1Ljk3OCAxOS41Njc2IDUuMDU5OTEgMjAuMTg4MUM0LjA5NTg2IDIwLjgzOTEgMy40Nzc2MSAyMS4yMjc2IDIuODYyNjMgMjEuMDA3N0MyLjExMTk2IDIwLjc0MDcgMi4wMzY0NiAxOC43MDg2IDIuMzk3NTcgMTYuODk4N0MyLjcyMDM4IDE1LjI2ODMgMy4zMjExMyAxMi4yMzI4IDQuODYwNzUgMTAuODU0QzUuMzc5NDMgMTAuMzkgNi4xMzAxIDkuODg3NzYgNi43NDcyNiAxMC4xMzE4QzcuNDcyNzYgMTAuNDE2MyA4LjA3MjQyIDExLjYxMTIgOC4yMDU5MiAxMy4wMzQ5QzguMjYxNzIgMTMuNjM1NiA4Ljc4NTg4IDE0LjA3NjYgOS4zOTc1NyAxNC4wMjE5QzkuOTk5NDEgMTMuOTY2MSAxMC40NDE1IDEzLjQzMjEgMTAuMzg0NiAxMi44MzAyQzEwLjE2NzkgMTAuNTEwNCA5LjA4MDIzIDguNjk2MTEgNy41NDcxNyA4LjA5MzE3QzYuNjI5MDggNy43MzY0NCA1LjE2OTM0IDcuNjQwMTUgMy4zOTk5MSA5LjIyMzU1QzEuNDc1MSAxMC45NDcgMC43NjM4MzMgMTMuODY5OCAwLjI0ODQzNSAxNi40NzNDLTAuMDA5ODEwODUgMTcuNzczIC0wLjYzOTAxMiAyMi4wODY2IDIuMTI3MjggMjMuMDcwM0MzLjgxMjQ1IDIzLjY3MTEgNS4xODEzNyAyMi43NDQzIDYuMjgxMTEgMjIuMDAyM0M2LjQ4MjQ1IDIxLjg2NjcgNi42ODA1MSAyMS43MzMyIDYuODczMSAyMS42MTM5QzYuNjkwMzYgMjIuNDA3MiA2LjU3NjU2IDIzLjI1NjQgNy4wNTU4NSAyMy45NzJDNy43NzA0IDI1LjA0NjYgOC43ODA0IDI1LjE2MzcgMTAuMDU2MyAyNC4zMjMzQzEwLjEwNTYgMjQuMjkxNSAxMC4xNjI1IDI0LjI1NDMgMTAuMjE2MSAyNC4yMTcxQzEwLjMzNDMgMjQuNDY0NCAxMC41NDMzIDI0LjczNjkgMTAuOTIzIDI0LjkyMjlDMTEuMzgyNiAyNS4xNDg0IDExLjg0MjIgMjUuMTU5MyAxMi4xNzcgMjUuMTY4MUMxMi4zMjAzIDI1LjE3MTMgMTIuNTE2MiAyNS4xNzU3IDEyLjU3NTMgMjUuMjAyQzEyLjc4MSAyNS4yOTI4IDEyLjkwMjUgMjUuNDA0NCAxMy4xMzg5IDI1LjYyNzZDMTMuMzE2MSAyNS43OTUxIDEzLjUwMzIgMjUuOTY5MSAxMy43NDA3IDI2LjE0ODVDMTMuOTM3NyAyNi4yOTYyIDE0LjE2NzUgMjYuMzY2MyAxNC4zOTUxIDI2LjM2NjNDMTQuNzI3NyAyNi4zNjYzIDE1LjA1NzEgMjYuMjE0MiAxNS4yNzE2IDI1LjkyODZDMTUuNjMzOCAyNS40NDQ5IDE1LjUzNTMgMjQuNzU4OCAxNS4wNTE2IDI0LjM5NjZDMTQuODkzIDI0LjI3NCAxNC43NjcxIDI0LjE1MjYgMTQuNjQ1NyAyNC4wMzc3WiIgZmlsbD0iIzQ5NEY1OSIvPgo8L2c+CjxkZWZzPgo8Y2xpcFBhdGggaWQ9ImNsaXAwIj4KPHJlY3Qgd2lkdGg9IjI4IiBoZWlnaHQ9IjI4IiBmaWxsPSJ3aGl0ZSIvPgo8L2NsaXBQYXRoPgo8L2RlZnM+Cjwvc3ZnPgo=",
			"txFo": "",
			"apiId": "",
			"onTable": ""
		},
		"role": {
			"visible": "",
			"disabled": ""
		},
		"property": {},
		"validate": {
			"request": false
		},
		"lang": {},
		"configAVD": {},
		"inputtype": "jButtonSignature",
		"default": {
			"name": "Default Component",
			"code": "default",
			"codeHidden": "",
			"class": "",
			"condition": "",
			"role": ""
		}
	}')
INSERT [dbo].[DesignItem] ([Id], [GroupId], [isActive], [Title], [DisplayOrder], [AttId], [Img], [KeyNew], [Type], [Template]) VALUES (23, N'advanced_fields', 1, N'{
		"en": "List CheckBox",
		"vi": "Danh sách checkbox"
}', N'12', N'list_check_box', N'check_box_outline_blank', N'12', NULL, N'{
		"default": {
			"name": "Default component",
			"code": "4a563edde0f0558f",
			"codeHidden": "",
			"class": "col-sm-12 col-md-12",
			"condition": "",
			"ofgroup": "",
			"class_ofgroup": "col-sm-12 col-md-12",
			"role": ""
		},
		"config": {
			"structable": "",
			"structable_read": "",
			"query_data": "",
			"is_multi_col": "false",
			"get_data_format": "c_cdlist.cdid",
			"selected_view_format": "@c_cdlist.caption",
			"col_format": "@c_cdlist.caption",
			"key_selected": "c_cdlist.cdid",
			"useAction": "false",
			"isAutoDefault": "true"
		},
		"role": {
			"disabled": "",
			"visible": "",
			"other": "",
			"other2": ""
		},
		"property": {},
		"validate": {
			"request": false
		},
		"lang": {
			"ui": {
				"vi": {
					"Mẫu component": "Mẫu component"
				},
				"en": {
					"Mẫu component": "Mẫu component"
				}
			}
		},
		"configAVD": {},
		"inputtype": "jListCheckBox"
	}')
INSERT [dbo].[DesignItem] ([Id], [GroupId], [isActive], [Title], [DisplayOrder], [AttId], [Img], [KeyNew], [Type], [Template]) VALUES (24, N'basic_fields', 1, N'{"en":"Report","vi":"Report"}', N'30', N'default_report', N'report', NULL, NULL, N'{"default":{"name":"Default component","code":"","codeHidden":"","class":"col-sm-12 col-md-12","condition":"","ofgroup":"","class_ofgroup":"col-sm-12 col-md-12","role":""},"config":{"query_data":"","file_report":"","file_report_name":"","config_data":"{\n    \"key_parent\":[{\n        \"key_1\": \"key_parent.key_1\",\n        \"key_2\": \"key_parent.key_2\"\n    }]}"},"role":{},"property":{},"validate":{},"lang":{},"configAVD":{},"inputtype":"jReport"}')
INSERT [dbo].[DesignItem] ([Id], [GroupId], [isActive], [Title], [DisplayOrder], [AttId], [Img], [KeyNew], [Type], [Template]) VALUES (25, N'basic_fields', 1, N'{"en":"Iframe Report","vi":"Iframe Report"}', N'31', N'default_iframeReport', N'code', NULL, NULL, N'{"default":{"name":"Report","code":"","codeHidden":"","class":"col-sm-12 col-md-12","condition":"","ofgroup":"","class_ofgroup":"col-sm-12 col-md-12","role":""},"config":{"file_report":"","more_config":"{}"},"role":{},"property":{},"validate":{},"lang":{},"configAVD":{},"inputtype":"jIframeReport"}')
SET IDENTITY_INSERT [dbo].[DesignItem] OFF
GO

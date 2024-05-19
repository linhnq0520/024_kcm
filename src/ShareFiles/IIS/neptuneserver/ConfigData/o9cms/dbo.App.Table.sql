USE [o9cms]
GO
SET IDENTITY_INSERT [dbo].[App] ON 

INSERT [dbo].[App] ([Id], [ListApplicationId], [ListApplicationName], [ListApplicationDes], [ListApplicationImg], [ListApplicationBo], [ListApplicationBoLogout], [ListApplicationBoLogoutAll], [ConnectOtherSystemStatus], [ListApplicationOrder], [ConfigTemplate], [status]) VALUES (1, N'sys', N'Systemm', N'App System', N'../rs/global/img/jwebui.png', N'bo-login-sys', N'#sys:bo-delete-session', N'#sys:bo-logout-all-default', NULL, N'2', N'{"mobile":{"template":"malibu","screen_working":"desktop_sys","theme":"Green_Pigment"},"desktop":{"template":"malibu","screen_working":"desktop_sys","theme":"Green_Pigment"},"tablet":{"template":"malibu","screen_working":"desktop_sys","theme":"Green_Pigment"},"desktop_small":{"template":"malibu","screen_working":"desktop_o9","theme":"krungthai"}}', N'I')
INSERT [dbo].[App] ([Id], [ListApplicationId], [ListApplicationName], [ListApplicationDes], [ListApplicationImg], [ListApplicationBo], [ListApplicationBoLogout], [ListApplicationBoLogoutAll], [ConnectOtherSystemStatus], [ListApplicationOrder], [ConfigTemplate], [status]) VALUES (2, N'ncbs', N'Neptune Portal', N'Neptune Portal', N'../rs/global/img/neptune_portal.png', N'bo-login-ncbs', N'#sys:bo-delete-session', N'#sys:bo-logout-all-default', NULL, N'2', N'{"mobile":{"template":"malibu","screen_working":"desktop_ncbs","theme":"shwebank"},"desktop":{"template":"malibu","screen_working":"desktop_ncbs","theme":"shwebank"},"tablet":{"template":"malibu","screen_working":"desktop_ncbs","theme":"shwebank"},"desktop_small":{"template":"malibu","screen_working":"desktop_ncbs","theme":"shwebank"}}', N'A')
INSERT [dbo].[App] ([Id], [ListApplicationId], [ListApplicationName], [ListApplicationDes], [ListApplicationImg], [ListApplicationBo], [ListApplicationBoLogout], [ListApplicationBoLogoutAll], [ConnectOtherSystemStatus], [ListApplicationOrder], [ConfigTemplate], [status]) VALUES (3, N'designform', N'Design Form', N'Design Form', N'../rs/global/img/APP_ICON_DESIGNFORM.png', N'bo-login-ncbs', NULL, NULL, NULL, N'10', N'{"mobile":{"isFwCss":false,"template":"malibu","screen_working":"desktop_designForm"},"desktop":{"isFwCss":false,"template":"designForm","screen_working":"desktop_designForm"},"tablet":{"isFwCss":false,"template":"malibu","screen_working":"desktop_designForm"}}', N'A')
INSERT [dbo].[App] ([Id], [ListApplicationId], [ListApplicationName], [ListApplicationDes], [ListApplicationImg], [ListApplicationBo], [ListApplicationBoLogout], [ListApplicationBoLogoutAll], [ConnectOtherSystemStatus], [ListApplicationOrder], [ConfigTemplate], [status]) VALUES (4, N'ncbsCbs', N'Shwebank', N'Neptune Core CBS', N'../rs/global/img/shwebank.png', N'bo-login-ncbsCbs', N'#sys:bo-delete-session', N'#sys:bo-logout-all-default', NULL, N'1', N'{
	"mobile": {
		"template": "malibu",
		"screen_working": "desktop_ncbsCbs",
		"theme": "shwebank"
	},
	"desktop": {
		"template": "malibu",
		"screen_working": "desktop_ncbsCbs",
		"theme": "shwebank"
	},
	"tablet": {
		"template": "malibu",
		"screen_working": "desktop_ncbsCbs",
		"theme": "shwebank"
	},
	"desktop_small": {
		"template": "malibu",
		"screen_working": "desktop_ncbsCbs",
		"theme": "shwebank"
	}
}', N'A')
INSERT [dbo].[App] ([Id], [ListApplicationId], [ListApplicationName], [ListApplicationDes], [ListApplicationImg], [ListApplicationBo], [ListApplicationBoLogout], [ListApplicationBoLogoutAll], [ConnectOtherSystemStatus], [ListApplicationOrder], [ConfigTemplate], [status]) VALUES (5, N'ncbsAdmin', N'Neptune Admin', N'Neptune Admin', N'../rs/global/img/jwebui.png', N'bo-login-ncbs', N'#sys:bo-delete-session', N'#sys:bo-logout-all-default', NULL, N'2', N'{"mobile":{"template":"malibu","screen_working":"desktop_ncbs","theme":"shwebank"},"desktop":{"template":"malibu","screen_working":"desktop_ncbs","theme":"shwebank"},"tablet":{"template":"malibu","screen_working":"desktop_ncbs","theme":"shwebank"},"desktop_small":{"template":"malibu","screen_working":"desktop_ncbs","theme":"shwebank"}}', N'A')
INSERT [dbo].[App] ([Id], [ListApplicationId], [ListApplicationName], [ListApplicationDes], [ListApplicationImg], [ListApplicationBo], [ListApplicationBoLogout], [ListApplicationBoLogoutAll], [ConnectOtherSystemStatus], [ListApplicationOrder], [ConfigTemplate], [status]) VALUES (7, N'ncbsReport', N'Neptune Report', N'Neptune Report', N'../rs/global/img/neptune_report.png', N'bo-login-ncbs', N'#sys:bo-delete-session', N'#sys:bo-logout-all-default', NULL, N'7', N'{"mobile":{"template":"malibu","screen_working":"desktop_ncbs","theme":"shwebank"},"desktop":{"template":"malibu","screen_working":"desktop_ncbs","theme":"shwebank"},"tablet":{"template":"malibu","screen_working":"desktop_ncbs","theme":"shwebank"},"desktop_small":{"template":"malibu","screen_working":"desktop_ncbs","theme":"shwebank"}}', N'A')
INSERT [dbo].[App] ([Id], [ListApplicationId], [ListApplicationName], [ListApplicationDes], [ListApplicationImg], [ListApplicationBo], [ListApplicationBoLogout], [ListApplicationBoLogoutAll], [ConnectOtherSystemStatus], [ListApplicationOrder], [ConfigTemplate], [status]) VALUES (1002, N'ncbsEvent', N'Neptune Event', N'Neptune Event', N'../rs/global/img/neptune_event.png', N'bo-login-ncbs', N'#sys:bo-delete-session', N'', NULL, N'1', N'{"mobile":{"template":"malibu","screen_working":"desktop_ncbs","theme":"shwebank"},"desktop":{"template":"malibu","screen_working":"desktop_ncbs","theme":"shwebank"},"tablet":{"template":"malibu","screen_working":"desktop_ncbs","theme":"shwebank"},"desktop_small":{"template":"malibu","screen_working":"desktop_ncbs","theme":"shwebank"}}', N'A')
SET IDENTITY_INSERT [dbo].[App] OFF
GO

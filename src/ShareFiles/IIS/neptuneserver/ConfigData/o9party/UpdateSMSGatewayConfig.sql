UPDATE o9party.[dbo].[Setting] SET  [Value] = N'http://192.168.120.171:8080/MessagingGateway/msggateway', [OrganizationId] = 0 WHERE [Name] = N'PartySettings.RequestOTPThirdPartyUrl';
UPDATE o9party.[dbo].[Setting] SET  [Value] = N'fcdb123', [OrganizationId] = 0 WHERE [Name] = N'PartySettings.ThirdPartyLoginName';
UPDATE o9party.[dbo].[Setting] SET [Value] = N'fcdb', [OrganizationId] = 0 WHERE [Name] = N'PartySettings.ThirdPartyPassword';
UPDATE o9party.[dbo].[Setting] SET  [Value] = N'2', [OrganizationId] = 0 WHERE [Name] = N'PartySettings.OTPExpirationMinutes';
UPDATE o9party.[dbo].[Setting] SET [Value] = N'4', [OrganizationId] = 0 WHERE [Name] = N'PartySettings.OTPLength';

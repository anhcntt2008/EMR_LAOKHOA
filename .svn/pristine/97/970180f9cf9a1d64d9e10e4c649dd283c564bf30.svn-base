
DELETE FROM [dbo].[ADSystemConfigs] where [ADSystemConfigGroup] = 'ESIGN_CA'

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT ISNULL(MAX([ADSystemConfigID]),0)+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'ESIGN_CA', 'ESIGN_CA_URL', N'https://trusted-hub.com:8443/eSignCloud/Services?wsdl', N'Địa chỉ Sign Server', N'');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'ESIGN_CA', 'ESIGN_CA_X509CERTIFICATE2', N'ca-configs\esign_ssl.p12', N'Đường dẫn file .p12', N'Đường dẫn tương đối');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'ESIGN_CA', 'ESIGN_CA_X509CERTIFICATE2_PW', N'auc9aj3uGNTWhbk1sw9Jkg==', N'Password file .p12', N'');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'ESIGN_CA', 'ESIGN_CA_PARTY', N'LKHOSPITAL', N'Relying Party', N'');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'ESIGN_CA', 'ESIGN_CA_PARTY_USER', N'lkhospital', N'User theo Relying Party', N'');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'ESIGN_CA', 'ESIGN_CA_PARTY_PW', N'XSQ6QQ/Ag4LLGnD0qSqfLJKt/qCBCm4WXYWsjAohUGQ=', N'Relying Party Password', N'');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'ESIGN_CA', 'ESIGN_CA_PARTY_SIGNATURE', N'aCiPiDxEIfoWajqE+k4CCnf0pUcLi7NxgNGq5hQYC26RtD+oauzwYblLU5oRTUM7YhLsfzXlCJ6VSgTFQze8vYw5x0ct4ReB5jP+1kb1RoCP+BT4rjQYxWhsWlF5h6RhER24CzFLUx4hv4TssxuHNq9WtDcEIZww17qe8KkMGPjTy7xQPkxJLIaf9c1ZPymrhfINa0wytDSSYY4NZH5YvuJfoAGZsRfuoyRbwxxoDteVRl5eQ/QyJtrHNRVMYBEkg+ONzsS4KRX9dnmk0A1oJYPA63m6ppXHsx3TZtxGieS0uYUyYfMTQlySo65TwlM7ZsH+hu5twqYv4kio3jPSpQ==', N'Relying Party Signature', N'');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'ESIGN_CA', 'ESIGN_CA_COORDINATE_X', N'300', N'Tọa độ X góc Dưới-Trái', N'Có thể cấu hình tùy theo mẫu bệnh án');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'ESIGN_CA', 'ESIGN_CA_COORDINATE_Y', N'300', N'Tọa độ Y góc Dưới-Trái', N'Có thể cấu hình tùy theo mẫu bệnh án');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'ESIGN_CA', 'ESIGN_CA_SIGNATURE_WIDTH', N'300', N'Chiều rộng stamp', N'Có thể cấu hình tùy theo mẫu bệnh án');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'ESIGN_CA', 'ESIGN_CA_SIGNATURE_HEIGHT', N'70', N'Chiều cao stamp', N'Có thể cấu hình tùy theo mẫu bệnh án');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'ESIGN_CA', 'ESIGN_CA_LOCATION', N'Hà Nội, Việt Nam', N'Địa điểm', N'');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'ESIGN_CA', 'ESIGN_CA_CONTACT', N'Bệnh viện Phụ sản Hà Nội', N'Địa chỉ hiển thị trên chữ ký', N'');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'ESIGN_CA', 'ESIGN_CA_TEXT_COLOR', N'black', N'Màu chữ', N'');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'ESIGN_CA', 'ESIGN_CA_FONT_SIZE', N'13', N'Cỡ chữ', N'');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'ESIGN_CA', 'ESIGN_CA_DEFAULT_REASON', N'Đóng bệnh án', N'Lý do mặc định', N'Có thể cấu hình tùy theo mẫu bệnh án');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'ESIGN_CA', 'ESIGN_CA_TEXT_DIRECTION', N'RIGHTTOLEFT', N'Canh chữ', N'RIGHTTOLEFT hay LEFTTORIGHT');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'ESIGN_CA', 'ESIGN_CA_VISIBLE_SIGNATURE', N'True', N'Hiển thị trạng thái INVALID/VALID (dấu hỏi vàng/check xanh)', N'True hay False');
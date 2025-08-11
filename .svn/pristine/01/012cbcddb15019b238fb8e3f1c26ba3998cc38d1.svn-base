
DELETE FROM [dbo].[ADSystemConfigs] where [ADSystemConfigGroup] = 'BKAV_CA'

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT ISNULL(MAX([ADSystemConfigID]),0)+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'BKAV_CA', 'BKAV_CA_URL', N'https://103.237.99.76//EAServer/services/EAService?wsdl', N'Địa chỉ Sign Server', N'');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'BKAV_CA', 'BKAV_CA_X509CERTIFICATE2', N'ca-configs\bkav_ssl.p12', N'Đường dẫn file .p12', N'Đường dẫn tương đối');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'BKAV_CA', 'BKAV_CA_X509CERTIFICATE2_PW', N'aKqt43aNJWaCSgBnXVBALg==', N'Password file .p12', N'');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'BKAV_CA', 'BKAV_CA_PARTNER_NAME', N'BkavCA', N'Partner name', N'');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'BKAV_CA', 'BKAV_CA_VERIFY_DEFAULT_USER', N'UserTest', N'User mặc định dùng để verify dữ liệu', N'');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'BKAV_CA', 'BKAV_CA_TAG_NAME', N'CKDT', N'Tên thẻ chứa nội dung chữ ký', N'Dùng cho ký file XML');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'BKAV_CA', 'BKAV_CA_COORDINATE_X', N'300', N'Tọa độ X góc Dưới-Trái', N'Có thể cấu hình tùy theo mẫu bệnh án');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'BKAV_CA', 'BKAV_CA_COORDINATE_Y', N'300', N'Tọa độ Y góc Dưới-Trái', N'Có thể cấu hình tùy theo mẫu bệnh án');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'BKAV_CA', 'BKAV_CA_SIGNATURE_WIDTH', N'300', N'Chiều rộng stamp', N'Có thể cấu hình tùy theo mẫu bệnh án');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'BKAV_CA', 'BKAV_CA_SIGNATURE_HEIGHT', N'70', N'Chiều cao stamp', N'Có thể cấu hình tùy theo mẫu bệnh án');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'BKAV_CA', 'BKAV_CA_LOCATION', N'Hà Nội, Việt Nam', N'Địa điểm', N'');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'BKAV_CA', 'BKAV_CA_CONTACT', N'Bệnh viện Phụ sản Hà Nội', N'Địa chỉ hiển thị trên chữ ký', N'');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'BKAV_CA', 'BKAV_CA_TEXT_COLOR', N'black', N'Màu chữ', N'');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'BKAV_CA', 'BKAV_CA_FONT_SIZE', N'13', N'Cỡ chữ', N'');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'BKAV_CA', 'BKAV_CA_DEFAULT_REASON', N'Đóng bệnh án', N'Lý do mặc định', N'Có thể cấu hình tùy theo mẫu bệnh án');
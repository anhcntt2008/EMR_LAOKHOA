
DELETE FROM [dbo].[ADSystemConfigs] where [ADSystemConfigGroup] = 'VNPT_CA'

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT ISNULL(MAX([ADSystemConfigID]),0)+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'VNPT_CA', 'VNPT_CA_URL', N'', N'Địa chỉ Sign Server', N'');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'VNPT_CA', 'VNPT_CA_COORDINATE_X', N'300', N'Tọa độ X góc Dưới-Trái', N'Có thể cấu hình tùy theo mẫu bệnh án');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'VNPT_CA', 'VNPT_CA_COORDINATE_Y', N'300', N'Tọa độ Y góc Dưới-Trái', N'Có thể cấu hình tùy theo mẫu bệnh án');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'VNPT_CA', 'VNPT_CA_SIGNATURE_WIDTH', N'300', N'Chiều rộng stamp', N'Có thể cấu hình tùy theo mẫu bệnh án');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'VNPT_CA', 'VNPT_CA_SIGNATURE_HEIGHT', N'70', N'Chiều cao stamp', N'Có thể cấu hình tùy theo mẫu bệnh án');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'VNPT_CA', 'VNPT_CA_LOCATION', N'Hà Nội, Việt Nam', N'Địa điểm', N'');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'VNPT_CA', 'VNPT_CA_CONTACT', N'Bệnh viện Phụ sản Hà Nội', N'Địa chỉ hiển thị trên chữ ký', N'');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'VNPT_CA', 'VNPT_CA_FONT_COLOR', N'000000', N'Màu chữ theo định dạng HEX', N'');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'VNPT_CA', 'VNPT_CA_FONT_SIZE', N'13', N'Cỡ chữ', N'');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'VNPT_CA', 'VNPT_CA_FONT_STYLE', N'Normal', N'Định dạng chữ', N'');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'VNPT_CA', 'VNPT_CA_FONT_NAME', N'Times_New_Roman', N'Kiểu chữ', N'');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'VNPT_CA', 'VNPT_CA_DEFAULT_REASON', N'Đóng bệnh án', N'Lý do mặc định', N'Có thể cấu hình tùy theo mẫu bệnh án');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'VNPT_CA', 'VNPT_CA_PAGE', N'1', N'Trang hiện chữ ký', N'Có thể cấu hình tùy theo mẫu bệnh án');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'VNPT_CA', 'VNPT_CA_RENDER_MODE', N'TEXT_WITH_BACKGROUND', N'Kiểu hiển thị chữ ký', N'');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'VNPT_CA', 'VNPT_CA_LAYER2_TEXT', N'', N'Layer 2 text', N'');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'VNPT_CA', 'VNPT_CA_SIGNATURE_BORDER_TYPE', N'DASHED', N'Đường viền chữ ký', N'');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'VNPT_CA', 'VNPT_CA_COUNT_GET_TRAN_INFO', N'24', N'Số lần gọi GetTranInfo', N'');

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'VNPT_CA', 'VNPT_CA_SHOW_REASON', N'True', N'Hiển thị lý do ký', N'');
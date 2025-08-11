DELETE FROM [dbo].[ADSystemConfigs] where [ADSystemConfigGroup] = 'BKAV_CA' and ADSystemConfigKey = 'BKAV_CA_VERSION'

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT ISNULL(MAX([ADSystemConfigID]),0)+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'BKAV_CA', 'BKAV_CA_VERSION', N'BVPS', N'Hiển thị thông tin trên stamp theo yêu cầu của BV', N'Để trống hoặc theo yêu cầu của BKAV');
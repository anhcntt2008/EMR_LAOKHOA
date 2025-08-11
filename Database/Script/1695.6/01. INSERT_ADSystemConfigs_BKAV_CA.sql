DELETE FROM [dbo].[ADSystemConfigs] where [ADSystemConfigGroup] = 'BKAV_CA' and ADSystemConfigKey = 'BKAV_CA_USE_EXTENSION_FILE_OFFICE'

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT ISNULL(MAX([ADSystemConfigID]),0)+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'BKAV_CA', 'BKAV_CA_USE_EXTENSION_FILE_OFFICE', N'True', N'Sử dụng extension file là office hay cho docx', N'True: office, False: docx');
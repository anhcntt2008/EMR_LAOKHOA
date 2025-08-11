DELETE FROM [dbo].[ADSystemConfigs] where [ADSystemConfigGroup] = 'BKAV_CA' AND [ADSystemConfigKey] = 'BKAV_CA_SHOW_REASON'

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'BKAV_CA', 'BKAV_CA_SHOW_REASON', N'False',  N'Hiển thị lý do trên stamp', N'True hay False. BKAV không tự xóa dòng lý do');

DELETE FROM [dbo].[ADSystemConfigs] where [ADSystemConfigGroup] = 'ESIGN_CA' AND [ADSystemConfigKey] = 'ESIGN_CA_SHOW_REASON'

INSERT INTO [dbo].[ADSystemConfigs]([ADSystemConfigID], [AAStatus], [IsActive], [ADSystemConfigGroup], [ADSystemConfigKey], [ADSystemConfigValue], [ADSystemConfigText], [ADSystemConfigDesc]) VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'ESIGN_CA', 'ESIGN_CA_SHOW_REASON', N'False', N'Hiển thị lý do trên stamp', N'True hay False');
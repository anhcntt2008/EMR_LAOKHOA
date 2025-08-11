DELETE
FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'SYSTEM_CONFIGS'
	AND [ADSystemConfigKey] = 'SYSTEM_CONFIGS_SIGNAL_ENDPOINT'

INSERT INTO [dbo].[ADSystemConfigs] (
	[ADSystemConfigID]
	,[AAStatus]
	,[IsActive]
	,[ADSystemConfigGroup]
	,[ADSystemConfigKey]
	,[ADSystemConfigValue]
	,[ADSystemConfigText]
	,[ADSystemConfigDesc]
	)
VALUES (
	(
		SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1
		FROM [dbo].[ADSystemConfigs]
		)
	,'Alive'
	,'1'
	,'SYSTEM_CONFIGS'
	,'SYSTEM_CONFIGS_SIGNAL_ENDPOINT'
	,N'http://192.168.9.2:6235/signalr'
	,N'Signal endpoint'
	,N'Kết nối đến hệ thống API thông báo, tin nhắn của EMR'
	);

GO


DELETE
FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'SYSTEM_CONFIGS'
	AND [ADSystemConfigKey] = 'SYSTEM_CONFIGS_SIGNAL_HUB_NAME'

INSERT INTO [dbo].[ADSystemConfigs] (
	[ADSystemConfigID]
	,[AAStatus]
	,[IsActive]
	,[ADSystemConfigGroup]
	,[ADSystemConfigKey]
	,[ADSystemConfigValue]
	,[ADSystemConfigText]
	,[ADSystemConfigDesc]
	)
VALUES (
	(
		SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1
		FROM [dbo].[ADSystemConfigs]
		)
	,'Alive'
	,'1'
	,'SYSTEM_CONFIGS'
	,'SYSTEM_CONFIGS_SIGNAL_HUB_NAME'
	,N'emrSignalHub'
	,N'Signal hub name'
	,N'Tên của hub kết nối đến hệ thống API thông báo, tin nhắn của EMR'
	);

GO

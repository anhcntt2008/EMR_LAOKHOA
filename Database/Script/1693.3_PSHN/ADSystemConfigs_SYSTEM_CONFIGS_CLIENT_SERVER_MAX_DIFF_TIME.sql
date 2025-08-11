GO
DELETE FROM [dbo].[ADSystemConfigs] WHERE [ADSystemConfigKey] = 'SYSTEM_CONFIGS_CLIENT_SERVER_MAX_DIFF_TIME'
AND [ADSystemConfigGroup] = 'SYSTEM_CONFIGS'
GO
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
	,'SYSTEM_CONFIGS_CLIENT_SERVER_MAX_DIFF_TIME'
	,N'3'
	,N'Cấu hình số phút cho phép lệch thời gian ở máy client với server. Mặc định là 3 phút.'
	,N'Cấu hình số phút cho phép lệch thời gian ở máy client với server. Mặc định là 3 phút.'
	);
GO

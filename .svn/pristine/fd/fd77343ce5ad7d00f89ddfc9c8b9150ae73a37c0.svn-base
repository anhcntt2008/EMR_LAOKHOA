DELETE
FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'SYSTEM_CONFIGS'
	AND [ADSystemConfigKey] = 'HIS_KV_RUN_TIME'

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
	,'HIS_KV_RUN_TIME'
	,N'100000'
	,N'Số lần chạy tối đa'
	,N'Số lần chạy tối đa'
	);
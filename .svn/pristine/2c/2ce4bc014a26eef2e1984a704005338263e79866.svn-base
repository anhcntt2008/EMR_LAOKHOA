DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'SYSTEM_CONFIGS'
	AND [ADSystemConfigKey] = 'EMR_FILE_LIFE_DAY'

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
	,'EMR_FILE_LIFE_DAY'
	,N'-30'
	,N'Delete files on local base setting day.'
	,N'Delete files on local base setting day.'
	);
GO

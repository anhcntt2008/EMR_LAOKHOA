DELETE
FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'SYSTEM_CONFIGS'
	AND [ADSystemConfigKey] = 'APP_TO_APP_VB'

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
	,'APP_TO_APP_VB'
	,N'TRUE'
	,N'Tích hợp App To App cho HIS VB'
	,N'Giá trị = TRUE/FALSE'
	);

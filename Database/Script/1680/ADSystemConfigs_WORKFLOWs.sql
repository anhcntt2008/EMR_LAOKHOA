DELETE
FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'WORKFLOW_CONFIGS'
	AND [ADSystemConfigKey] = 'WORKFLOW_CONFIG_CHECK_ALLOW_ACTION_LOCAL'

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
	,'WORKFLOW_CONFIGS'
	,'WORKFLOW_CONFIG_CHECK_ALLOW_ACTION_LOCAL'
	,N'TRUE'
	,N'Cho phép kiểm tra allow action workflow ở local'
	,N'Nhằm tăng tốc độ xử lý. Không khuyến khích.'
	);

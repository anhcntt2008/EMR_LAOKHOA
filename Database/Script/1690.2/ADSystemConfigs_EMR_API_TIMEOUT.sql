DELETE
FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'EMR_API_ENDPOINT'
	AND [ADSystemConfigKey] = 'EMR_API_ENDPOINT_TIMEOUT'

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
	,'EMR_API_ENDPOINT'
	,'EMR_API_ENDPOINT_TIMEOUT'
	,N'180000'
	,N'The time to wait before the request to EMR API times out.'
	,N'The default value is 180,000 milliseconds (180 seconds = 3 minutes).'
	);

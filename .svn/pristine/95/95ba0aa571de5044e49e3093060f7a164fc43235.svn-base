
DELETE
FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'EMR_PROCESS'
	AND [ADSystemConfigKey] = 'EMR_TRANSFER_API_REQUIRED_RECEIVE_EMP_WORKING_AT_DEPT'

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
	,'EMR_PROCESS'
	,'EMR_TRANSFER_API_REQUIRED_RECEIVE_EMP_WORKING_AT_DEPT'
	,N'FALSE'
	,N'Yêu cầu người nhận phải thuộc khoa chuyển đến'
	,N''
	);


	
DELETE
FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'EMR_PROCESS'
	AND [ADSystemConfigKey] = 'EMR_TRANSFER_API_REQUIRED_SEND_EMP_WORKING_AT_MAN_DEPT'

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
	,'EMR_PROCESS'
	,'EMR_TRANSFER_API_REQUIRED_SEND_EMP_WORKING_AT_MAN_DEPT'
	,N'FALSE'
	,N'Yêu cầu người chuyển phải thuộc khoa quản lý'
	,N''
	);
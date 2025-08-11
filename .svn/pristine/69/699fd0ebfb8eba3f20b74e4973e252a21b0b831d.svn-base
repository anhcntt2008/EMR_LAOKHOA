DELETE
FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'EMR_PROCESS'
	AND [ADSystemConfigKey] = 'EMR_TYPE_MAX_COUNT_IN'

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
	,'EMR_TYPE_MAX_COUNT_IN'
	,N'0'
	,N'Số bệnh án NỘI TRÚ tối đa ĐANG MỞ của 1 bệnh nhân'
	,N'Số bệnh án NỘI TRÚ tối đa ĐANG MỞ của 1 bệnh nhân. Giá trị = 0 là không giới hạn'
	);

DELETE
FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'EMR_PROCESS'
	AND [ADSystemConfigKey] = 'EMR_TYPE_MAX_COUNT_OUT'

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
	,'EMR_TYPE_MAX_COUNT_OUT'
	,N'0'
	,N'Số bệnh án NGOẠI TRÚ tối đa ĐANG MỞ của 1 bệnh nhân'
	,N'Số bệnh án NGOẠI TRÚ tối đa ĐANG MỞ của 1 bệnh nhân. Giá trị = 0 là không giới hạn'
	);

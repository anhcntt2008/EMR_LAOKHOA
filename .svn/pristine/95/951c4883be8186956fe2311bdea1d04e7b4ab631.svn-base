DELETE
FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'EMR_PROCESS'
	AND [ADSystemConfigKey] = 'EMR_TYPE_MAX_COUNT_ALL'

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
	,'EMR_TYPE_MAX_COUNT_ALL'
	,N'1'
	,N'Số bệnh án NỘI TRÚ + NGOẠI TRÚ tối đa ĐANG MỞ của 1 bệnh nhân'
	,N'Số bệnh án NỘI TRÚ + NGOẠI TRÚ tối đa ĐANG MỞ của 1 bệnh nhân. Giá trị = 0 là không giới hạn. Ngoại trừ các loại bệnh án có cấu hình ''Số bệnh án tối đa/bệnh nhân'''
	);

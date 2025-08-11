DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'EMR_PROCESS'
	AND [ADSystemConfigKey] = 'MIDDLE_EMR_DOC_MISS_ENABLE'

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
	,'MIDDLE_EMR_DOC_MISS_ENABLE'
	,N'TRUE'
	,N'Sau khi khởi tạo bệnh án xong, nếu DB trung gian có các tờ bị DISCARDED thì UPDATE cho chạy lại'
	,N'Sau khi khởi tạo bệnh án xong, nếu DB trung gian có các tờ bị DISCARDED thì UPDATE cho chạy lại'
	);
GO

DELETE
FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'EMR_API_ENDPOINT'
	AND [ADSystemConfigKey] = 'EMR_DOCUMENTS_BACKGROUND_ALL_BY_EMR'

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
	,'EMR_DOCUMENTS_BACKGROUND_ALL_BY_EMR'
	,N'middbs/GetAllTreatingDocumentsByEmr'
	,N'[DB trung gian] Lấy tất cả tờ bệnh án đang/đã được tạo ngầm của một bệnh án'
	,N'middbs/GetAllTreatingDocumentsByEmr'
	);

GO
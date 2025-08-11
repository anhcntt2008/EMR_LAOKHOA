
DELETE
FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'EMR_API_ENDPOINT'
	AND [ADSystemConfigKey] = 'EMR_PDF_EXPORT'

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
	,'EMR_PDF_EXPORT'
	,N'documents/EmrExportPdf'
	,N'Chỉ chuyển đổi docx sang pdf'
	,N''
	);

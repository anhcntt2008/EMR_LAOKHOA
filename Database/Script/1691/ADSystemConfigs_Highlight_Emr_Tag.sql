DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'DOCUMENT_PROCESS'
	AND [ADSystemConfigKey] = 'HIGHLIGHT_MODE_EMR_TAG_BORDER'

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
	,'DOCUMENT_PROCESS'
	,'HIGHLIGHT_MODE_EMR_TAG_BORDER'
	,N'TRUE'
	,N'Bật/tắt chế độ BORDER của chức năng highlight thẻ'
	,N''
	);
GO


DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'DOCUMENT_PROCESS'
	AND [ADSystemConfigKey] = 'HIGHLIGHT_MODE_EMR_TAG_FILL'

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
	,'DOCUMENT_PROCESS'
	,'HIGHLIGHT_MODE_EMR_TAG_FILL'
	,N'TRUE'
	,N'Bật/tắt chế độ FILL của chức năng highlight thẻ'
	,N''
	);
GO

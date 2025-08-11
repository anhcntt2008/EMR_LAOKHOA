DELETE
FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'SYSTEM_CONFIGS'
	AND [ADSystemConfigKey] = 'EMR_DOCUMENT_TDT_DIENBIENVAYLENH_ROW'

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
	,'EMR_DOCUMENT_TDT_DIENBIENVAYLENH_ROW'
	,N'2'
	,N'Value = 0 : Không áp dụng. Value = number là số dòng tối đa.'
	,N'Hạn chế số lần ghi Diễn biến, Y lệnh trong tờ điều trị'
	);

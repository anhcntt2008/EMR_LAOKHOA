DELETE
FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'SYSTEM_CONFIGS'
	AND [ADSystemConfigKey] = 'EMR_DOCUMENT_TDT_DIENBIENVAYLENH_INIT_ROW'

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
	,'EMR_DOCUMENT_TDT_DIENBIENVAYLENH_INIT_ROW'
	,N'1'
	,N'Value = 1 : Số dòng diễn biến y lệnh lúc khởi tạo TDT.'
	,N'Số dòng diễn biến y lệnh lúc khởi tạo TDT.'
	);

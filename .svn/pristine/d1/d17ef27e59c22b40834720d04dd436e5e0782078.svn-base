DELETE
FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'SYSTEM_CONFIGS'
	AND [ADSystemConfigKey] = 'SYSTEM_CONFIGS_PAGE_PAINTER_VER'

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
	,'SYSTEM_CONFIGS_PAGE_PAINTER_VER'
	,N'V1'
	,N'Thuật toán dàn trang nâng cao'
	,N'Fix các lỗi thuộc core devexpress. V1: Dùng cho ký hiệu thuốc dùng ảnh có nền trắng, V2: Dùng cho ký hiệu thuốc dùng ảnh không nền'
	);

GO

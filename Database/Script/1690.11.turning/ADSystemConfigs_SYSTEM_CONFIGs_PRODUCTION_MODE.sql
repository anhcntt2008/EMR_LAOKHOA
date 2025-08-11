DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'SYSTEM_CONFIGS'
	AND [ADSystemConfigKey] = 'SYSTEM_CONFIGS_RUNNING_MODE'

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
	,'SYSTEM_CONFIGS_RUNNING_MODE'
	,N'PRODUCTION'
	,N'Hệ thống đang chạy ở mode PRODUCTION hay DESIGN'
	,N'Chuyển sang chế độ DESIGN khi thực hiện cấu hình để đảm không có lỗi xảy ra. Chế độ DESIGN sẽ tắt chế độ bộ nhớ đệm của client.'
	);
GO

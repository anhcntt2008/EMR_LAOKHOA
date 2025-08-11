DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'EMR_PROCESS'
	AND [ADSystemConfigKey] = 'EMR_UPDATE_INPROGRESS_WHEN_FAIL'

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
	,'EMR_UPDATE_INPROGRESS_WHEN_FAIL'
	,N'true'
	,N'true/false. True: Cập nhật trạng thái Đang được khởi tạo nếu phát sinh lỗi khi tạo ba = api.'
	,N'true/false. True: Cập nhật trạng thái Đang được khởi tạo nếu phát sinh lỗi khi tạo ba = api.'
	);
GO

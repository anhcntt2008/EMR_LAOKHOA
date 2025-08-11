DELETE
FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'EMR_PROCESS'
	AND [ADSystemConfigKey] = 'EMR_TYPE_TEMPORARY_PREFIX_NO'

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
	,'EMR_TYPE_TEMPORARY_PREFIX_NO'
	,N'TEMP-'
	,N'Tiền tố mã bệnh án tạm'
	,N'Tiền tố tự động thêm vào nếu là bệnh án TẠM và cắt đi khi tương tác dữ liệu với HIS'
	);

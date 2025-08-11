DELETE
FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'DOCUMENT_PROCESS'
	AND [ADSystemConfigKey] = 'FINGER_PRINT_HASH_WATERMARK'

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
	,'FINGER_PRINT_HASH_WATERMARK'
	,N'TRUE'
	,N'Chèn mã toàn vẹn (băm) thành watermark trên vân tay'
	,N'Giá trị = TRUE/FALSE. Không dùng watermark sẽ không đảm bảo giá trị pháp lý của xác nhận bằng vân tay'
	);

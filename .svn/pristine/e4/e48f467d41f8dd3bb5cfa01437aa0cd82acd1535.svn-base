DELETE
FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'DOCUMENT_PROCESS'
	AND [ADSystemConfigKey] = 'AUTO_HIDE_DISCARDED_DOCUMENT'

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
	,'AUTO_HIDE_DISCARDED_DOCUMENT'
	,N'HIDE'
	,N'Tự động Ẩn các tờ bệnh án bị Hủy khi gọi API từ HIS'
	,N'Tính năng tự động "Ẩn" các phiếu kết quả CLS tạo từ HIS có trạng thái "Đã hủy". Giá trị = HIDE/NONE'
	);

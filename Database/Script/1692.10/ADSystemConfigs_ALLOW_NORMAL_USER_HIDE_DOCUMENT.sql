
/********************************************************************

LƯU Ý: ĐỐI VỚI BV LK THÌ SET TRUE, CÁC BV KHÁC THÌ SET FALSE MẶC ĐỊNH

*********************************************************************/


DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'DOCUMENT_PROCESS'
	AND [ADSystemConfigKey] = 'ALLOW_NORMAL_USER_HIDE_DOCUMENT'

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
	,'ALLOW_NORMAL_USER_HIDE_DOCUMENT'
	,N'TRUE'
	,N'Cho phép người dùng thông thường có thể thấy và ẩn tờ bệnh án'
	,N'Dùng cho DKKVLK = TRUE'
	);
GO

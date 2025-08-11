

/********************************************************************

LƯU Ý: ĐỐI VỚI BV LK THÌ SET FALSE, CÁC BV KHÁC THÌ SET TRUE MẶC ĐỊNH

*********************************************************************/


DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'DOCUMENT_PROCESS'
	AND [ADSystemConfigKey] = 'NOT_ALLOW_COPY_EMR_TAG'

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
	,'NOT_ALLOW_COPY_EMR_TAG'
	,N'FALSE'
	,N'Không cho phép copy nguyên thẻ dữ liệu'
	,N'Chức năng sẽ chỉ cho phép copy nội dung của thẻ dữ liệu'
	);
GO

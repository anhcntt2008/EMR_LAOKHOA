DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'EMR_PROCESS'
	AND [ADSystemConfigKey] = 'EMR_BACKUP_FILE_STORAGE_PATH'

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
	,'EMR_BACKUP_FILE_STORAGE_PATH'
	,N'C:\EmrWeb\Storage\CHCEMR\CLOUD;D:\EMR\CLOUD'
	,N'Thư mục chứa lưu trữ dự phòng bệnh án, thư mục phân biệt = dấu {;}'
	,N'Thư mục chứa lưu trữ dự phòng bệnh án, thư mục phân biệt = dấu {;}'
	);
GO

--select * from [ADSystemConfigs]  WHERE [ADSystemConfigGroup] = 'EMR_PROCESS' AND [ADSystemConfigKey] = 'EMR_BACKUP_FILE_STORAGE_PATH'
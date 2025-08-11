DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'EMR_PROCESS'
	AND [ADSystemConfigKey] = 'ALLOW_SHARING_THE_CLOSED_EMR'

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
	,'ALLOW_SHARING_THE_CLOSED_EMR'
	,N'TRUE'
	,N'Cho phép chia sẻ bệnh án đã đóng'
	,N'Phải có đủ 3 điều kiện: [Vai trò = Quản trị] + [Quyền truy xuất = Toàn bộ] + [Phân quyền theo trạng thái Xem = Closed] thì mới có thể chia sẻ'
	);
GO


DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'EMR_PROCESS'
	AND [ADSystemConfigKey] = 'ALLOW_MANAGE_DEPT_ACCESS_ALL_THE_EMRS_OF_PATIENT'

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
	,'ALLOW_MANAGE_DEPT_ACCESS_ALL_THE_EMRS_OF_PATIENT'
	,N'TRUE'
	,N'Cho phép các khoa quản lý bệnh án thấy được tất cả các bệnh án của bệnh nhân'
	,N'Khoa quản lý = khoa đang điều trị. Ngoại trú chỉ thấy ngoại trú. Nội trú thấy tất cả.'
	);
GO

DELETE
FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'EMR_PROCESS'
	AND [ADSystemConfigKey] = 'EMR_BACKUP_FILE_STORAGE_ENABLE'

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
	,'EMR_BACKUP_FILE_STORAGE_ENABLE'
	,N'TRUE'
	,N'Tắt mở lưu trữ dự phòng bệnh án.'
	,N'Tắt mở lưu trữ dự phòng bệnh án.'
	);
GO

DELETE
FROM [dbo].[ADSystemConfigs]
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
	,N'D:\emr\Healthcare_EMR\Storage\CHCEMR\BackupFileCloud'
	,N'Thư mục chứa lưu trữ dự phòng bệnh án, đã ánh xạ với cloud'
	,N'Thư mục chứa lưu trữ dự phòng bệnh án, đã ánh xạ với cloud'
	);

GO
DELETE
FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'EMR_PROCESS'
	AND [ADSystemConfigKey] = 'EMR_BACKUP_FILE_STORAGE_TYPE'

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
	,'EMR_BACKUP_FILE_STORAGE_TYPE'
	,N'DigitalSigned'
	,N'Loại lưu trữ dự phòng bệnh án. Archived | DigitalSigned | <để trống>: Tất cả'
	,N'Loại lưu trữ dự phòng bệnh án. Archived | DigitalSigned | <để trống>: Tất cả'
	);


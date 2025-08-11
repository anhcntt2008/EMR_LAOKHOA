-- Xóa các config không dùng nữa
DELETE
FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'EMR_PROCESS'
	AND [ADSystemConfigKey] = 'EMR_BACKUP_FILE_STORAGE_PATH'

DELETE
FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'EMR_PROCESS'
	AND [ADSystemConfigKey] = 'EMR_BACKUP_FILE_STORAGE_ENABLE'

DELETE
FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'EMR_PROCESS'
	AND [ADSystemConfigKey] = 'EMR_BACKUP_FILE_STORAGE_TYPE'

-- NEW JOB CONFIG
DELETE
FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'SYSTEM_CONFIGS'
	AND [ADSystemConfigKey] = 'BACKUP_EMR_ARCHIVE_STORAGE_LOCATIONS'

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
	,'BACKUP_EMR_ARCHIVE_STORAGE_LOCATIONS'
	,N'\\DESKTOP-9MT4GNS\TestBK; D:\ArchiveBackups2'
	,N'[Sao lưu dự phòng bệnh án đã lưu trữ] Thư mục chứa. Cấu hình 1-n phân biệt bởi dấu [;]'
	,N'Ví dụ: E:\ArchiveBackups; D:\ArchiveBackups'
	);
GO

DELETE
FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'SYSTEM_CONFIGS'
	AND [ADSystemConfigKey] = 'BACKUP_EMR_ARCHIVE_ENABLE'

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
	,'BACKUP_EMR_ARCHIVE_ENABLE'
	,N'TRUE'
	,N'[Sao lưu dự phòng bệnh án đã lưu trữ] Bật/tắt'
	,N'TRUE hay FALSE'
	);
GO


DELETE
FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'SYSTEM_CONFIGS'
	AND [ADSystemConfigKey] = 'BACKUP_EMR_ARCHIVE_TYPE'

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
	,'BACKUP_EMR_ARCHIVE_TYPE'
	,N'Archived;DigitalSigned'
	,N'[Sao lưu dự phòng bệnh án đã lưu trữ] Trạng thái file lưu trữ sẽ được lọc khi sao lưu dự phòng. Cách nhau bởi dấu [;]'
	,N'Ví dụ: Archived;DigitalSigned hoặc <để trống>. Trong đó: Archived: chỉ cần được lưu trữ, không cần ký số, DigitalSigned: đã được ký số, <để trống>: Tất cả'
	);
GO

DELETE FROM [dbo].[ADSystemConfigs] where [ADSystemConfigGroup] = 'SYSTEM_CONFIGS' AND [ADSystemConfigKey] = 'BACKUP_EMR_ARCHIVE_CHECK_INTEGRITY'
INSERT INTO [dbo].[ADSystemConfigs] VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'SYSTEM_CONFIGS', 'BACKUP_EMR_ARCHIVE_CHECK_INTEGRITY', N'TRUE', N'[Sao lưu dự phòng bệnh án đã lưu trữ] Kiếm tra toàn vẹn sau khi sao lưu', 
N'TRUE/FALSE: Tốc độ sao lưu sẽ chậm khi thực hiện kiểm tra toàn vẹn');

DELETE FROM [dbo].[ADSystemConfigs] where [ADSystemConfigGroup] = 'SYSTEM_CONFIGS' AND [ADSystemConfigKey] = 'BACKUP_EMR_ARCHIVE_CHECK_INTEGRITY_ALGO'
INSERT INTO [dbo].[ADSystemConfigs] VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'SYSTEM_CONFIGS', 'BACKUP_EMR_ARCHIVE_CHECK_INTEGRITY_ALGO', N'SHA1', N'[Sao lưu dự phòng bệnh án đã lưu trữ] Thuật toán kiểm tra toàn vẹn', 
N'Thuật toán dùng sinh mã băm kiểm tra toàn vẹn. Mặc định CRC32. Có thể cấu hình MD5/SHA1');

DELETE FROM [dbo].[ADSystemConfigs] where [ADSystemConfigGroup] = 'SYSTEM_CONFIGS' AND [ADSystemConfigKey] = 'BACKUP_EMR_ARCHIVE_RETRY_WHEN_CHECK_INTEGRITY_TIMES'
INSERT INTO [dbo].[ADSystemConfigs] VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'SYSTEM_CONFIGS', 'BACKUP_EMR_ARCHIVE_RETRY_WHEN_CHECK_INTEGRITY_TIMES', N'3', N'[Sao lưu dự phòng bệnh án đã lưu trữ] Số lần thử lại khi kiểm tra toàn vẹn không thành công', 
N'Mặc định sẽ thử backup lại 1 file 3 lần nếu quá trình sao lưu thất bại đối với file này. Giá trị = 1 nếu không muốn thử lại.');

DELETE FROM [dbo].[ADSystemConfigs] where [ADSystemConfigGroup] = 'SYSTEM_CONFIGS' AND [ADSystemConfigKey] = 'BACKUP_EMR_ARCHIVE_MAINTAIN_DIR_STRUCT'
INSERT INTO [dbo].[ADSystemConfigs] VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'SYSTEM_CONFIGS', 'BACKUP_EMR_ARCHIVE_MAINTAIN_DIR_STRUCT', N'TRUE', N'[Sao lưu dự phòng bệnh án đã lưu trữ] quản lý theo cây thư mục "Năm/Khoa/Tháng/Ngày/File"', 
N'TRUE/FALSE. FALSE: toàn bộ file được lưu trữ vào 01 thư mục duy nhất. TRUE: Năm/Tháng/Ngày ưu tiên lấy ngày theo thứ tự Ngày ra viện > Ngày đóng > Ngày lưu trữ. Khoa = Mã viết tắt > Mã khoa');
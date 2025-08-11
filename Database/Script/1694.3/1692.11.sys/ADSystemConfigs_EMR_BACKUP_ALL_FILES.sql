
DELETE FROM [dbo].[ADSystemConfigs] where [ADSystemConfigGroup] = 'SYSTEM_CONFIGS' AND [ADSystemConfigKey] = 'EMR_BACKUP_ALL_FILES_ENABLE'
INSERT INTO [dbo].[ADSystemConfigs] VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'SYSTEM_CONFIGS', 'EMR_BACKUP_ALL_FILES_ENABLE', N'FALSE', N'[Backup tự động files] Tác vụ ngầm tự động backup dữ liệu các files bệnh án đến vùng nhớ khác', 
N'TRUE hay FALSE');

DELETE FROM [dbo].[ADSystemConfigs] where [ADSystemConfigGroup] = 'SYSTEM_CONFIGS' AND [ADSystemConfigKey] = 'EMR_BACKUP_ALL_FILES_STORAGE_LOCATIONS'
INSERT INTO [dbo].[ADSystemConfigs] VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'SYSTEM_CONFIGS', 'EMR_BACKUP_ALL_FILES_STORAGE_LOCATIONS', N'Z:\ut test\BackupEmrFiles;Z:\ut test\BackupEmrFiles2', 
N'[Backup tự động files] Địa chỉ các vùng nhớ khác', N'');

DELETE FROM [dbo].[ADSystemConfigs] where [ADSystemConfigGroup] = 'SYSTEM_CONFIGS' AND [ADSystemConfigKey] = 'EMR_BACKUP_ALL_FILES_CHECK_INTEGRITY'
INSERT INTO [dbo].[ADSystemConfigs] VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'SYSTEM_CONFIGS', 'EMR_BACKUP_ALL_FILES_CHECK_INTEGRITY', N'TRUE', N'[Backup tự động files] Kiếm tra toàn vẹn sau khi backup', 
N'TRUE/FALSE: Tốc độ backup sẽ chậm khi thực hiện kiểm tra toàn vẹn');

DELETE FROM [dbo].[ADSystemConfigs] where [ADSystemConfigGroup] = 'SYSTEM_CONFIGS' AND [ADSystemConfigKey] = 'EMR_BACKUP_ALL_FILES_CHECK_INTEGRITY_ALGO'
INSERT INTO [dbo].[ADSystemConfigs] VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'SYSTEM_CONFIGS', 'EMR_BACKUP_ALL_FILES_CHECK_INTEGRITY_ALGO', N'SHA1', N'[Backup tự động files] Thuật toán kiểm tra toàn vẹn', 
N'Thuật toán dùng sinh mã băm kiểm tra toàn vẹn. Mặc định CRC32. Có thể cấu hình MD5/SHA1');

DELETE FROM [dbo].[ADSystemConfigs] where [ADSystemConfigGroup] = 'SYSTEM_CONFIGS' AND [ADSystemConfigKey] = 'EMR_BACKUP_ALL_FILES_RETRY_WHEN_CHECK_INTEGRITY_TIMES'
INSERT INTO [dbo].[ADSystemConfigs] VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'SYSTEM_CONFIGS', 'EMR_BACKUP_ALL_FILES_RETRY_WHEN_CHECK_INTEGRITY_TIMES', N'3', N'[Backup tự động files] Số lần thử lại khi kiểm tra toàn vẹn không thành công', 
N'Mặc định sẽ thử backup lại 1 file 3 lần nếu quá trình backup thất bại đối với file này. Giá trị = 1 nếu không muốn thử lại.');

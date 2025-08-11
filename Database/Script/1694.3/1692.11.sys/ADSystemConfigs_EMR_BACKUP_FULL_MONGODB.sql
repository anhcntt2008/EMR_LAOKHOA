DELETE FROM [dbo].[ADSystemConfigs] where [ADSystemConfigGroup] = 'SYSTEM_CONFIGS' AND [ADSystemConfigKey] = 'EMR_BACKUP_MONGODB_FULL_ENABLE'
INSERT INTO [dbo].[ADSystemConfigs] VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'SYSTEM_CONFIGS', 'EMR_BACKUP_MONGODB_FULL_ENABLE', N'FALSE', N'[Backup Full tự động MongoDB] Tác vụ ngầm tự động backup MongoDB', 
N'TRUE hay FALSE');

DELETE FROM [dbo].[ADSystemConfigs] where [ADSystemConfigGroup] = 'SYSTEM_CONFIGS' AND [ADSystemConfigKey] = 'EMR_BACKUP_MONGODB_FULL_MAX_COUNT_FILE'
INSERT INTO [dbo].[ADSystemConfigs] VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'SYSTEM_CONFIGS', 'EMR_BACKUP_MONGODB_FULL_MAX_COUNT_FILE', N'3', N'[Backup Full tự động MongoDB] Số file backup tối đa được giữ lại', 
N'Giá trị [0-n] 0: không xoá file cũ, n: khi số file = n+1, file cũ nhất sẽ bị xoá.');

DELETE FROM [dbo].[ADSystemConfigs] where [ADSystemConfigGroup] = 'SYSTEM_CONFIGS' AND [ADSystemConfigKey] = 'EMR_BACKUP_MONGODB_STORAGE_LOCATIONS'
INSERT INTO [dbo].[ADSystemConfigs] VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'SYSTEM_CONFIGS', 'EMR_BACKUP_MONGODB_STORAGE_LOCATIONS', N'', N'[Backup tự động MongoDB] Địa chỉ vùng nhớ lưu trữ', 
N'Địa chỉ vùng nhớ lưu trữ. Được cấu hình 1 hay nhiều. Mỗi thư mục cách nhau bởi dấu [;]. Ví dụ: D:\MongoDB\Backups; E:\MongoDB\Backups');

DELETE FROM [dbo].[ADSystemConfigs] where [ADSystemConfigGroup] = 'SYSTEM_CONFIGS' AND [ADSystemConfigKey] = 'EMR_BACKUP_MONGODB_EXE_BIN_LOCATION'
INSERT INTO [dbo].[ADSystemConfigs] VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'SYSTEM_CONFIGS', 'EMR_BACKUP_MONGODB_EXE_BIN_LOCATION', N'D:\MongoDB\Bin', N'[Backup tự động MongoDB] Thư mục chứa mongodump.exe', 
N'Copy nguyên thư mục bin từ MongoDB version đang chạy trên máy chủ Database');

DELETE FROM [dbo].[ADSystemConfigs] where [ADSystemConfigGroup] = 'SYSTEM_CONFIGS' AND [ADSystemConfigKey] = 'EMR_BACKUP_MONGODB_FULL_EXE_ARGUMENTS'
INSERT INTO [dbo].[ADSystemConfigs] VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'SYSTEM_CONFIGS', 'EMR_BACKUP_MONGODB_FULL_EXE_ARGUMENTS', N'', N'[Backup tự động MongoDB] tham số cấu hình chạy mongodump', 
N'Ví dụ: --host=10.0.1.26 --port=27017 --authenticationDatabase=emr --username=emr --password=emr123 --db=emr. Tham số này phải cấu hình thủ công vì sẽ được mã hoá khi lưu vào DB');

DELETE FROM [dbo].[ADSystemConfigs] where [ADSystemConfigGroup] = 'SYSTEM_CONFIGS' AND [ADSystemConfigKey] = 'EMR_BACKUP_MONGODB_FULL_DELETE_INCREMENTAL'
INSERT INTO [dbo].[ADSystemConfigs] VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'SYSTEM_CONFIGS', 'EMR_BACKUP_MONGODB_FULL_DELETE_INCREMENTAL', N'TRUE', N'[Backup Full tự động MongoDB] Xóa các backup Incremental khi đã tạo Full thành công', 
N'TRUE hay FALSE');

DELETE FROM [dbo].[ADSystemConfigs] where [ADSystemConfigGroup] = 'SYSTEM_CONFIGS' AND [ADSystemConfigKey] = 'EMR_BACKUP_MONGODB_CHECK_INTEGRITY'
INSERT INTO [dbo].[ADSystemConfigs] VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'SYSTEM_CONFIGS', 'EMR_BACKUP_MONGODB_CHECK_INTEGRITY', N'TRUE', N'[Backup Full tự động MongoDB] Kiếm tra toàn vẹn khi copy backup sang các vùng nhớ khác', 
N'TRUE/FALSE: Tốc độ backup sẽ chậm khi thực hiện kiểm tra toàn vẹn');

DELETE FROM [dbo].[ADSystemConfigs] where [ADSystemConfigGroup] = 'SYSTEM_CONFIGS' AND [ADSystemConfigKey] = 'EMR_BACKUP_MONGODB_CHECK_INTEGRITY_ALGO'
INSERT INTO [dbo].[ADSystemConfigs] VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'SYSTEM_CONFIGS', 'EMR_BACKUP_MONGODB_CHECK_INTEGRITY_ALGO', N'SHA1', N'[Backup Full tự động MongoDB] Thuật toán kiểm tra toàn vẹn', 
N'Thuật toán dùng sinh mã băm kiểm tra toàn vẹn. Mặc định CRC32. Có thể cấu hình MD5/SHA1');

DELETE FROM [dbo].[ADSystemConfigs] where [ADSystemConfigGroup] = 'SYSTEM_CONFIGS' AND [ADSystemConfigKey] = 'EMR_BACKUP_MONGODB_RETRY_WHEN_CHECK_INTEGRITY_TIMES'
INSERT INTO [dbo].[ADSystemConfigs] VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'SYSTEM_CONFIGS', 'EMR_BACKUP_MONGODB_RETRY_WHEN_CHECK_INTEGRITY_TIMES', N'3', N'[Backup Full tự động MongoDB] Số lần thử lại khi kiểm tra toàn vẹn không thành công', 
N'Mặc định sẽ thử backup lại 1 file 3 lần nếu quá trình backup thất bại đối với file này. Giá trị = 1 nếu không muốn thử lại.');

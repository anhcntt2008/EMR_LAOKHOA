DELETE FROM [dbo].[ADSystemConfigs] where [ADSystemConfigGroup] = 'SYSTEM_CONFIGS' AND [ADSystemConfigKey] = 'EMR_BACKUP_MONGODB_INCREMENTAL_ENABLE'
INSERT INTO [dbo].[ADSystemConfigs] VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'SYSTEM_CONFIGS', 'EMR_BACKUP_MONGODB_INCREMENTAL_ENABLE', N'FALSE', N'[Backup Incremental tự động MongoDB] Tác vụ ngầm tự động backup MongoDB', 
N'TRUE hay FALSE. Incremental yêu cầu MongoDB phải chạy ở mode Replication. Tức là có từ 2 server MongoDB trở lên. Job chạy backup thực hiện trên PRIMARY');

DELETE FROM [dbo].[ADSystemConfigs] where [ADSystemConfigGroup] = 'SYSTEM_CONFIGS' AND [ADSystemConfigKey] = 'EMR_BACKUP_MONGODB_INCREMENTAL_EXE_ARGUMENTS'
INSERT INTO [dbo].[ADSystemConfigs] VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'SYSTEM_CONFIGS', 'EMR_BACKUP_MONGODB_INCREMENTAL_EXE_ARGUMENTS', N'', N'[Backup Incremental tự động MongoDB] tham số cấu hình chạy mongodump', 
N'Ví dụ: --host=10.0.1.26 --port=27017 --authenticationDatabase=admin --username=admin --password=admin123. Tham số này phải cấu hình thủ công vì sẽ được mã hoá khi lưu vào DB. Lưu ý: User phải có quyền đọc trên db local của MongoDB');


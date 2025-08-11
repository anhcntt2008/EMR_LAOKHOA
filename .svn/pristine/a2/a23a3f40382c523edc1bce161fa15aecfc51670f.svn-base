DELETE FROM [dbo].[ADSystemConfigs] where [ADSystemConfigGroup] = 'SYSTEM_CONFIGS' AND [ADSystemConfigKey] = 'EMR_CONNECTION_FILE_SHARED_HOSTS'
INSERT INTO [dbo].[ADSystemConfigs] VALUES (
(SELECT MAX([ADSystemConfigID])+1 FROM [dbo].[ADSystemConfigs])
, 'Alive', '1', 'SYSTEM_CONFIGS', 'EMR_CONNECTION_FILE_SHARED_HOSTS', N'', N'Cấu hình danh sách các server shared file và tài khoản kết nối', 
N'Ví dụ: user:password@192.168.9.2;user:password@backup-pc Mỗi server cách nhau bởi dấu; Username và password không chứa "@" và ":" Tham số này phải cấu hình thủ công vì sẽ được mã hoá khi lưu vào DB.');




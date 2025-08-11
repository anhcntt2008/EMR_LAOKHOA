DELETE
FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigKey] = 'SYSTEM_CONFIGS_USERS_SYSTEM'

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
	,'SYSTEM_CONFIGS_USERS_SYSTEM'
	,N'emr'
	,N'User hệ thống không thể sửa hoặc xóa'
	,N'Mỗi user cách nhau bởi ;. VD: abc;xyz'
	);

-----------------------------------------
DELETE
FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigKey] = 'SYSTEM_CONFIGS_USERS_SYSTEM_DISPLAY'

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
	,'SYSTEM_CONFIGS_USERS_SYSTEM_DISPLAY'
	,N'true'
	,N'User hệ thống hiển thị trên Danh sách người dùng'
	,N'TRUE: hiển thị, FALSE: không hiển thị'
	);

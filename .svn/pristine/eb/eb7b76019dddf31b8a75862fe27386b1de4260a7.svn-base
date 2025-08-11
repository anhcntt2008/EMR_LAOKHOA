DELETE FROM [dbo].[ADSystemConfigs] WHERE [ADSystemConfigKey] = 'EMR_TEMPLATE_SUMMARY_TEMPLATE'
GO
INSERT INTO [dbo].[ADSystemConfigs] (
	[ADSystemConfigID],[AAStatus],[IsActive],
	[ADSystemConfigGroup],
	[ADSystemConfigKey],
	[ADSystemConfigValue],
	[ADSystemConfigText],
	[ADSystemConfigDesc])
VALUES (
	(SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),'Alive','1'
	,'SYSTEM_CONFIGS'
	,'EMR_TEMPLATE_SUMMARY_TEMPLATE'
	,N'TTBA'
	,N'Mã mẫu bệnh án.'
	,N'Để trống nếu không sử dụng Tóm tắt bệnh án.');
GO

DELETE FROM [dbo].[ADSystemConfigs] WHERE [ADSystemConfigKey] = 'EMR_TEMPLATE_SUMMARY_TYPE_EXCEPT'
GO
INSERT INTO [dbo].[ADSystemConfigs] (
	[ADSystemConfigID],[AAStatus],[IsActive],
	[ADSystemConfigGroup],
	[ADSystemConfigKey],
	[ADSystemConfigValue],
	[ADSystemConfigText],
	[ADSystemConfigDesc])
VALUES (
	(SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),'Alive','1'
	,'SYSTEM_CONFIGS'
	,'EMR_TEMPLATE_SUMMARY_TYPE_EXCEPT'
	,N''
	,N'ID loại bệnh án không dùng Tóm tắt bệnh án.'
	,N'Cách nhau bằng dấu ;');
GO

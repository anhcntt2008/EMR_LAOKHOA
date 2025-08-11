DELETE FROM [dbo].[ADSystemConfigs] WHERE [ADSystemConfigKey] = 'EMR_TEMPLATE_SUMMARY_FOLDER_COMBINE'
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
	,'EMR_TEMPLATE_SUMMARY_FOLDER_COMBINE'
	,N'TRUE'
	,N'Dùng chung thư mục'
	,N'TRUE: dùng chung. FALSE: mỗi bệnh án 1 thư mục');
GO

DELETE FROM [dbo].[ADSystemConfigs] WHERE [ADSystemConfigKey] = 'EMR_TEMPLATE_SUMMARY_TEMPLATE_XML_NAME'
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
	,'EMR_TEMPLATE_SUMMARY_TEMPLATE_XML_NAME'
	,N'TOMTATHOSOBENHAN'
	,N'Thẻ đầu của file XML'
	,N'Thẻ đầu của file XML, cập nhật theo văn bản qui định.');
GO
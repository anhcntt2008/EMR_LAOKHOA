DELETE
FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'EMR_API_ENDPOINT'
	AND [ADSystemConfigKey] = 'EMR_DOCUMENTS_BACKGROUND'

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
	,'EMR_API_ENDPOINT'
	,'EMR_DOCUMENTS_BACKGROUND'
	,N'middbs/GetTreatingDocumentsByEmr'
	,N'[DB trung gian] Lấy danh sách tờ bệnh đang SCHEDULED/RETRYING/CREATING'
	,N''
	);

GO
DELETE
FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'EMR_API_ENDPOINT'
	AND [ADSystemConfigKey] = 'MD_AUTO_GEN_DOCUMENTS_GET'

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
	,'EMR_API_ENDPOINT'
	,'MD_AUTO_GEN_DOCUMENTS_GET'
	,N'middbs/GetAutoGenDocumentsByCondition'
	,N'[DB trung gian] Lấy danh sách tạo tờ bệnh'
	,N''
	);

GO
DELETE
FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'EMR_API_ENDPOINT'
	AND [ADSystemConfigKey] = 'MD_AUTO_SIGN_DOCUMENTS_GET'

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
	,'EMR_API_ENDPOINT'
	,'MD_AUTO_SIGN_DOCUMENTS_GET'
	,N'middbs/GetAutoSignDocumentsByCondition'
	,N'[DB trung gian] Lấy danh sách ký tờ bệnh'
	,N''
	);
GO
DELETE
FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'EMR_API_ENDPOINT'
	AND [ADSystemConfigKey] = 'MD_AUTO_GEN_DOCUMENTS_UPDATE'

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
	,'EMR_API_ENDPOINT'
	,'MD_AUTO_GEN_DOCUMENTS_UPDATE'
	,N'middbs/UpdateAutoGenDocuments'
	,N'[DB trung gian] Cập nhật tạo tờ bệnh'
	,N''
	);
GO
DELETE
FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'EMR_API_ENDPOINT'
	AND [ADSystemConfigKey] = 'MD_AUTO_SIGN_DOCUMENTS_UPDATE'

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
	,'EMR_API_ENDPOINT'
	,'MD_AUTO_SIGN_DOCUMENTS_UPDATE'
	,N'middbs/UpdateAutoSignDocuments'
	,N'[DB trung gian] Cập nhật ký tờ bệnh'
	,N''
	);
GO
DELETE
FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'EMR_API_ENDPOINT'
	AND [ADSystemConfigKey] = 'EMR_ARCHIVES_SCHEDULED'

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
	,'EMR_API_ENDPOINT'
	,'EMR_ARCHIVES_SCHEDULED'
	,N'documents/updateEmrArchives'
	,N'Cập nhật trạng thái lưu trữ dự phòng bệnh án'
	,N''
	);

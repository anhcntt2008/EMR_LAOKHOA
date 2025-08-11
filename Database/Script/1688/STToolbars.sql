DELETE
FROM [dbo].[STToolbarFunctions]
WHERE STToolbarFunctionName = 'ReleaseEmrDocuments'
	AND STToolbarFunctionClass = 'BOSERP.Modules.MEDocumentManage.MEDocumentManageModule'

DELETE
FROM [dbo].[STToolbars]
WHERE STToolbarName = 'fld_barbtnDocumentManageReleaseEmrDocuments'
	AND STModuleID = (SELECT TOP 1 [STModuleID] FROM [STModules] WHERE [STModuleName] = 'MEDocumentManage')

INSERT INTO [dbo].[STToolbars]
VALUES (
	(
		SELECT MAX(STToolbarID) + 1
		FROM [STToolbars]
		)
	,'Alive'
	,(
		SELECT TOP 1 [STModuleID]
		FROM [STModules]
		WHERE [STModuleName] = 'MEDocumentManage'
		)
	,1
	,N'fld_barbtnDocumentManageReleaseEmrDocuments'
	,N''
	,'DocumentManageReleaseEmrDocuments'
	,'Default'
	,N'Giải phóng tờ bệnh án'
	,N'Action'
	,11
	,'0'
	,N''
	,0
	,N'images/actions/refresh2_16x16.png'
	);

INSERT INTO [dbo].[STToolbarFunctions]
VALUES (
	(
		SELECT MAX(STToolbarFunctionID) + 1
		FROM [STToolbarFunctions]
		)
	,'0'
	,(
		SELECT STToolbarID
		FROM [STToolbars]
		WHERE STToolbarName = 'fld_barbtnDocumentManageReleaseEmrDocuments'
		)
	,'ReleaseEmrDocuments'
	,'Void ReleaseEmrDocuments()'
	,'BOSERP.Modules.MEDocumentManage.MEDocumentManageModule'
	,1
	);

/* Cập nhật gáy Module MEEmrType */
DELETE
FROM [dbo].[STToolbarFunctions]
WHERE STToolbarFunctionName = 'UpdateTemplate'
	AND STToolbarFunctionClass = 'BOSERP.Modules.MEEmrType.MEEmrTypeModule'

DELETE
FROM [dbo].[STToolbars]
WHERE STToolbarName = 'fld_barbtnUpdateTemplateMEEmrType'
	AND STModuleID = (SELECT TOP 1 [STModuleID] FROM [STModules] WHERE [STModuleName] = 'MEEmrType')

INSERT INTO [dbo].[STToolbars]
VALUES (
	(SELECT MAX(STToolbarID) + 1 FROM [STToolbars])
	,'Alive'
	,(SELECT TOP 1 [STModuleID] FROM [STModules] WHERE [STModuleName] = 'MEEmrType')
	,1
	,N'fld_barbtnUpdateTemplateMEEmrType'
	,N''
	,'UpdateTemplate'
	,'Default'
	,N'Cập nhật gáy'
	,N'Action'
	,11
	,'0'
	,N''
	,0
	,N'images/actions/convert_16x16.png'
	);

INSERT INTO [dbo].[STToolbarFunctions]
VALUES (
	(SELECT MAX(STToolbarFunctionID) + 1 FROM [STToolbarFunctions])
	,'0'
	,(SELECT STToolbarID FROM [STToolbars] WHERE STToolbarName = 'fld_barbtnUpdateTemplateMEEmrType')
	,'UpdateTemplate'
	,'Void UpdateTemplate()'
	,'BOSERP.Modules.MEEmrType.MEEmrTypeModule'
	,1
	);

/* Cập nhật gáy Module MEEmr */
DELETE
FROM [dbo].[STToolbarFunctions]
WHERE STToolbarFunctionName = 'UpdateEmrTemplate'
	AND STToolbarFunctionClass = 'BOSERP.Modules.MEEmr.MEEmrModule'

DELETE
FROM [dbo].[STToolbars]
WHERE STToolbarName = 'fld_barbtnUpdateEmrTemplate'
	AND STModuleID = (SELECT TOP 1 [STModuleID] FROM [STModules] WHERE [STModuleName] = 'MEEmr')

INSERT INTO [dbo].[STToolbars]
VALUES (
	(SELECT MAX(STToolbarID) + 1 FROM [STToolbars])
	,'Alive'
	,(SELECT TOP 1 [STModuleID] FROM [STModules] WHERE [STModuleName] = 'MEEmr')
	,1
	,N'fld_barbtnUpdateEmrTemplate'
	,N''
	,'UpdateEmrTemplate'
	,'Default'
	,N'Cập nhật gáy'
	,N'Action'
	,11
	,'0'
	,N''
	,0
	,N'images/actions/convert_16x16.png'
	);

INSERT INTO [dbo].[STToolbarFunctions]
VALUES (
	(SELECT MAX(STToolbarFunctionID) + 1 FROM [STToolbarFunctions])
	,'0'
	,(SELECT STToolbarID FROM [STToolbars] WHERE STToolbarName = 'fld_barbtnUpdateEmrTemplate')
	,'UpdateEmrTemplate'
	,'Void UpdateEmrTemplate()'
	,'BOSERP.Modules.MEEmr.MEEmrModule'
	,1
	);

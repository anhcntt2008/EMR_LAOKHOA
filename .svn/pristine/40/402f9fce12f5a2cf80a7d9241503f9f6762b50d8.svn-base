DELETE
FROM [dbo].[STToolbarFunctions]
WHERE STToolbarFunctionName = 'RefreshDocument'
	AND STToolbarFunctionClass = 'BOSERP.Modules.MEDocumentManage.MEDocumentManageModule'

DELETE
FROM [dbo].[STToolbars]
WHERE STModuleID = 2274 AND STToolbarName = 'fld_barbtnDocumentManageRefreshDocument'

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
	,N'fld_barbtnDocumentManageRefreshDocument'
	,N''
	,'RefreshDocument'
	,'Default'
	,N'Làm mới tờ BA'
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
		WHERE STToolbarName = 'fld_barbtnDocumentManageRefreshDocument'
		)
	,'RefreshDocument'
	,'Void RefreshDocument()'
	,'BOSERP.Modules.MEDocumentManage.MEDocumentManageModule'
	,1
	);
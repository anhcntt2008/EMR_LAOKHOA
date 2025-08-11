DELETE
FROM [dbo].[STToolbarFunctions]
WHERE STToolbarFunctionName = 'CheckEmrDocuments'
	AND STToolbarFunctionClass = 'BOSERP.Modules.MEDocumentManage.MEDocumentManageModule'

DELETE
FROM [dbo].[STToolbars]
WHERE STToolbarName = 'fld_barbtnDocumentManageCheckEmrDocuments'


DELETE
FROM [dbo].[STToolbarFunctions]
WHERE STToolbarFunctionName = 'ReleaseEmrDocuments'
	AND STToolbarFunctionClass = 'BOSERP.Modules.MEDocumentManage.MEDocumentManageModule'

DELETE
FROM [dbo].[STToolbars]
WHERE STToolbarName = 'fld_barbtnDocumentManageReleaseEmrDocuments'
	AND STModuleID = (SELECT TOP 1 [STModuleID] FROM [STModules] WHERE [STModuleName] = 'MEDocumentManage')

DELETE
FROM [dbo].[STToolbarFunctions]
WHERE STToolbarFunctionName = 'MergeEmrRollback'
	AND STToolbarFunctionClass = 'BOSERP.Modules.MEEmr.MEEmrModule'

DELETE
FROM [dbo].[STToolbars]
WHERE STToolbarName = 'fld_barbtnMergeEmrRollback' and STModuleID = (SELECT TOP 1 [STModuleID] FROM [STModules] WHERE [STModuleName] = 'MEEmr')

INSERT INTO [dbo].[STToolbars]
VALUES (
	(SELECT MAX(STToolbarID) + 1 FROM [STToolbars])
	,'Alive'
	,(SELECT TOP 1 [STModuleID] FROM [STModules] WHERE [STModuleName] = 'MEEmr')
	,1
	,N'fld_barbtnMergeEmrRollback'
	,N''
	,'MergeEmrRollback'
	,'Default'
	,N'Khôi phục trộn'
	,N'Action'
	,11
	,'0'
	,N''
	,0
	,N'images/actions/reset_16x16.png'
	);

INSERT INTO [dbo].[STToolbarFunctions]
VALUES (
	(SELECT MAX(STToolbarFunctionID) + 1 FROM [STToolbarFunctions])
	,'0'
	,(SELECT STToolbarID FROM [STToolbars] WHERE STToolbarName = 'fld_barbtnMergeEmrRollback' and STModuleID = (SELECT TOP 1 [STModuleID] FROM [STModules] WHERE [STModuleName] = 'MEEmr'))
	,'MergeEmrRollback'
	,'Void MergeEmrRollback()'
	,'BOSERP.Modules.MEEmr.MEEmrModule'
	,1
	);
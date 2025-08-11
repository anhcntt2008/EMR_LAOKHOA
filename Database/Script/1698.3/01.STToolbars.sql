DELETE
FROM [dbo].[STToolbarFunctions]
WHERE STToolbarFunctionName = 'ViewEmrSum'
	AND STToolbarFunctionClass = 'BOSERP.Modules.MEEmr.MEEmrModule'

DELETE
FROM [dbo].[STToolbars]
WHERE STToolbarName = 'fld_barbtnViewEmrSum' AND STModuleID=2221

INSERT INTO [dbo].[STToolbars]
VALUES (
	(SELECT MAX(STToolbarID) + 1FROM [STToolbars])
	,'Alive'
	,(SELECT TOP 1 [STModuleID] FROM [STModules] WHERE [STModuleName] = 'MEEmr')
	,1
	,N'fld_barbtnViewEmrSum'
	,N''
	,'ViewEmrSum'
	,'Default'
	,N'Xem Tóm Tắt Bệnh Án'
	,N'Action'
	,11
	,'0'
	,N''
	,0
	,N'images/export/exporttopdf_16x16.png'
	);

INSERT INTO [dbo].[STToolbarFunctions]
VALUES (
	(SELECT MAX(STToolbarFunctionID) + 1FROM [STToolbarFunctions])
	,'0'
	,(SELECT STToolbarID FROM [STToolbars] WHERE STToolbarName = 'fld_barbtnViewEmrSum')
	,'ViewEmrSum'
	,'Void ViewEmrSum()'
	,'BOSERP.Modules.MEEmr.MEEmrModule'
	,1
	);

GO



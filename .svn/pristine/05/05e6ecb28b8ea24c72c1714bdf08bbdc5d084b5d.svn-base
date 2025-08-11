DELETE
FROM [dbo].[STToolbarFunctions]
WHERE STToolbarFunctionName = 'PdfExport'
	AND STToolbarFunctionClass = 'BOSERP.Modules.MEEmrManage.MEEmrManageModule'

DELETE
FROM [dbo].[STToolbars]
WHERE STToolbarName = 'fld_barbtnEmrManagePdfExport'

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
		WHERE [STModuleName] = 'MEEmrManage'
		)
	,1
	,N'fld_barbtnEmrManagePdfExport'
	,N''
	,'EmrManagePdfExport'
	,'Default'
	,N'Xuất pdf'
	,N'Action'
	,11
	,'0'
	,N''
	,0
	,N'images/export/exporttopdf_16x16.png'
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
		WHERE STToolbarName = 'fld_barbtnEmrManagePdfExport'
		)
	,'PdfExport'
	,'Void PdfExport()'
	,'BOSERP.Modules.MEEmrManage.MEEmrManageModule'
	,1
	);

DELETE FROM [dbo].[STToolbarFunctions] WHERE STToolbarFunctionName = 'EmrSumXML' AND STToolbarFunctionClass = 'BOSERP.Modules.MEEmr.MEEmrManage'
DELETE FROM [dbo].[STToolbars] WHERE STToolbarName = 'fld_barbtnEmrSumXML'

DELETE FROM [dbo].[STToolbarFunctions] WHERE STToolbarFunctionName = 'XmlExport' AND STToolbarFunctionClass = 'BOSERP.Modules.MEEmrManage.MEEmrManageModule'
DELETE FROM [dbo].[STToolbars] WHERE STToolbarName = 'fld_barbtnEmrManageXmlExport'

INSERT INTO [dbo].[STToolbars]
VALUES (
	(SELECT MAX(STToolbarID) + 1 FROM [STToolbars])
	,'Alive'
	,(SELECT TOP 1 [STModuleID] FROM [STModules] WHERE [STModuleName] = 'MEEmrManage')
	,1
	,N'fld_barbtnEmrManageXmlExport'
	,N''
	,'EmrManageXmlExport'
	,'Default'
	,N'Xuất XML'
	,N'Action'
	,11
	,'0'
	,N''
	,0
	,N'images/export/exporttoxml_16x16.png'
	);

INSERT INTO [dbo].[STToolbarFunctions]
VALUES (
	(SELECT MAX(STToolbarFunctionID) + 1 FROM [STToolbarFunctions])
	,'0'
	,(SELECT STToolbarID FROM [STToolbars] WHERE STToolbarName = 'fld_barbtnEmrManageXmlExport')
	,'XmlExport'
	,'Void XmlExport()'
	,'BOSERP.Modules.MEEmrManage.MEEmrManageModule'
	,1
	);


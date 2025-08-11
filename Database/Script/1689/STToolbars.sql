DELETE
FROM [dbo].[STToolbarFunctions]
WHERE STToolbarFunctionName = 'CheckEmrDocuments'
	AND STToolbarFunctionClass = 'BOSERP.Modules.MEDocumentManage.MEDocumentManageModule'

DELETE
FROM [dbo].[STToolbars]
WHERE STToolbarName = 'fld_barbtnDocumentManageCheckEmrDocuments'

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
	,N'fld_barbtnDocumentManageCheckEmrDocuments'
	,N''
	,'DocumentManageCheckEmrDocuments'
	,'Default'
	,N'Tờ bệnh án mất FTP'
	,N'Action'
	,11
	,'0'
	,N''
	,0
	,N'images/zoom/zoom_16x16.png'
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
		WHERE STToolbarName = 'fld_barbtnDocumentManageCheckEmrDocuments'
		)
	,'CheckEmrDocuments'
	,'Void CheckEmrDocuments()'
	,'BOSERP.Modules.MEDocumentManage.MEDocumentManageModule'
	,1
	);


--EMRS--
GO
DELETE FROM [dbo].[STToolbarFunctions] 
	WHERE STToolbarFunctionName = 'GroupEmrDocuments'
	AND STToolbarFunctionClass = 'BOSERP.Modules.MEEmr.MEEmrModule'

DELETE FROM [dbo].[STToolbars] 
	WHERE STToolbarName = 'fld_barbtnEmrModuleGroupEmrDocuments'
	AND STModuleID = 2221

INSERT INTO [dbo].[STToolbars]
VALUES (
	(SELECT MAX(STToolbarID) + 1 FROM [STToolbars])
	,'Alive'
	,2221
	,1
	,N'fld_barbtnEmrModuleGroupEmrDocuments'
	,N''
	,'EmrModuleGroupEmrDocuments'
	,'Default'
	,N'Sắp xếp tờ bệnh án trong gáy'
	,N'Action'
	,11
	,'0'
	,N''
	,0
	,N'images/actions/merge_16x16.png'
	);

INSERT INTO [dbo].[STToolbarFunctions]
VALUES (
	(SELECT MAX(STToolbarFunctionID) + 1 FROM [STToolbarFunctions])
	,'0'
	,(
		SELECT STToolbarID
		FROM [STToolbars]
		WHERE STToolbarName = 'fld_barbtnEmrModuleGroupEmrDocuments'
		)
	,'GroupEmrDocuments'
	,'Void GroupEmrDocuments()'
	,'BOSERP.Modules.MEEmr.MEEmrModule'
	,1
	);

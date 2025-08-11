--Mở lại Tờ + BA
DELETE
FROM [dbo].[STToolbarFunctions]
WHERE STToolbarFunctionName = 'ReOpenEmrDocumentEmr'
	AND STToolbarFunctionClass = 'BOSERP.Modules.MEEmr.MEEmrModule'

DELETE
FROM [dbo].[STToolbars]
WHERE STToolbarName = 'fld_barbtnReOpenEmrDocumentEmr'
	AND STModuleID = (SELECT TOP 1 [STModuleID] FROM [STModules] WHERE [STModuleName] = 'MEEmr')

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
		WHERE [STModuleName] = 'MEEmr'
		)
	,1
	,N'fld_barbtnReOpenEmrDocumentEmr'
	,N''
	,'ReOpenEmrDocumentEmr'
	,'Default'
	,N'Mở lại Tờ, BA'
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
		WHERE STToolbarName = 'fld_barbtnReOpenEmrDocumentEmr'
		)
	,'ReOpenEmrDocumentEmr'
	,'Void ReOpenEmrDocumentEmr()'
	,'BOSERP.Modules.MEEmr.MEEmrModule'
	,1
	);


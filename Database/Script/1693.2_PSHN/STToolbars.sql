DELETE
FROM [dbo].[STToolbarFunctions]
WHERE STToolbarFunctionName = 'EmrRelation'
	AND STToolbarFunctionClass = 'BOSERP.Modules.MEEmr.MEEmrModule'

DELETE
FROM [dbo].[STToolbars]
WHERE STToolbarName = 'fld_barbtnEmrRelation'

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
	,N'fld_barbtnEmrRelation'
	,N''
	,'EmrRelation'
	,'Default'
	,N'Liên kết'
	,N'Action'
	,11
	,'0'
	,N''
	,0
	,N'images/richedit/reviewers_16x16.png'
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
		WHERE STToolbarName = 'fld_barbtnEmrRelation'
		)
	,'EmrRelation'
	,'Void EmrRelation()'
	,'BOSERP.Modules.MEEmr.MEEmrModule'
	,1
	);

DELETE FROM [dbo].[STToolbarFunctions] WHERE STToolbarFunctionName = 'ChangeEmrTemplate'

DELETE FROM [dbo].[STToolbars] WHERE STToolbarName = 'fld_barbtnEmrModuleChangeEmrTemplate'

INSERT INTO [dbo].[STToolbars]
VALUES (
	(SELECT MAX(STToolbarID) + 1 FROM [STToolbars])
	,'Alive'
	,2221
	,1
	,N'fld_barbtnEmrModuleChangeEmrTemplate'
	,N''
	,'EmrModuleChangeEmrTemplate'
	,'Default'
	,N'Chuyển gáy'
	,N'Action'
	,11
	,'0'
	,N''
	,0
	,N'images/format/replace_16x16.png'
	);

INSERT INTO [dbo].[STToolbarFunctions]
VALUES (
	(SELECT MAX(STToolbarFunctionID) + 1 FROM [STToolbarFunctions])
	,'0'
	,(
		SELECT STToolbarID
		FROM [STToolbars]
		WHERE STToolbarName = 'fld_barbtnEmrModuleChangeEmrTemplate'
		)
	,'ChangeEmrTemplate'
	,'Void ChangeEmrTemplate()'
	,'BOSERP.Modules.MEEmr.MEEmrModule'
	,1
	);

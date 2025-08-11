DELETE
FROM [dbo].[STToolbarFunctions]
WHERE STToolbarFunctionName = 'EmrRenameEmrNo'
	AND STToolbarFunctionClass = 'BOSERP.Modules.MEEmr.MEEmrModule'

DELETE
FROM [dbo].[STToolbars]
WHERE STToolbarName = 'fld_barbtnEmrRenameEmrNo'

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
	,N'fld_barbtnEmrRenameEmrNo'
	,N''
	,'EmrRenameEmrNo'
	,'Default'
	,N'Sửa mã bệnh án'
	,N'Action'
	,11
	,'0'
	,N''
	,0
	,N'images/edit/edit_16x16.png'
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
		WHERE STToolbarName = 'fld_barbtnEmrRenameEmrNo'
		)
	,'EmrRenameEmrNo'
	,'Void EmrRenameEmrNo()'
	,'BOSERP.Modules.MEEmr.MEEmrModule'
	,1
	);

GO
DELETE
FROM [dbo].[STToolbarFunctions]
WHERE STToolbarFunctionName = 'EmrRenamePatientNo'
	AND STToolbarFunctionClass = 'BOSERP.Modules.MEEmr.MEEmrModule'

DELETE
FROM [dbo].[STToolbars]
WHERE STToolbarName = 'fld_barbtnEmrRenamePatientNo'

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
	,N'fld_barbtnEmrRenamePatientNo'
	,N''
	,'EmrRenamePatientNo'
	,'Default'
	,N'Sửa mã bệnh nhân'
	,N'Action'
	,11
	,'0'
	,N''
	,0
	,N'images/edit/edit_16x16.png'
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
		WHERE STToolbarName = 'fld_barbtnEmrRenamePatientNo'
		)
	,'EmrRenamePatientNo'
	,'Void EmrRenamePatientNo()'
	,'BOSERP.Modules.MEEmr.MEEmrModule'
	,1
	);


DELETE
FROM [dbo].[STToolbarFunctions]
WHERE STToolbarFunctionName = 'CheckupEmr'

DELETE
FROM [dbo].[STToolbars]
WHERE STToolbarName = 'fld_barbtnEmrModuleCheckupEmr'

INSERT INTO [dbo].[STToolbars]
VALUES (
	(
		SELECT MAX(STToolbarID) + 1
		FROM [STToolbars]
		)
	,'Alive'
	,2221
	,1
	,N'fld_barbtnEmrModuleCheckupEmr'
	,N''
	,'EmrModuleCheckupEmr'
	,'Default'
	,N'Kiểm duyệt'
	,N'Action'
	,11
	,'0'
	,N''
	,0
	,N'images/programming/showtestreport_16x16.png'
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
		WHERE STToolbarName = 'fld_barbtnEmrModuleCheckupEmr'
		)
	,'CheckupEmr'
	,'Void CheckupEmr()'
	,'BOSERP.Modules.MEEmr.MEEmrModule'
	,1
	);

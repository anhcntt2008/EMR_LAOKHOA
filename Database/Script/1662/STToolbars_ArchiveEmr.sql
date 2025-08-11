DELETE
FROM [dbo].[STToolbarFunctions]
WHERE STToolbarFunctionName = 'ArchiveEmr'

DELETE
FROM [dbo].[STToolbars]
WHERE STToolbarName = 'fld_barbtnEmrModuleArchiveEmr'

INSERT INTO [dbo].[STToolbars]
VALUES (
	(
		SELECT MAX(STToolbarID) + 1
		FROM [STToolbars]
		)
	,'Alive'
	,2221
	,1
	,N'fld_barbtnEmrModuleArchiveEmr'
	,N''
	,'EmrModuleArchiveEmr'
	,'Default'
	,N'Lưu trữ bệnh án'
	,N'Action'
	,11
	,'0'
	,N''
	,0
	,N'images/support/packageproduct_16x16.png'
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
		WHERE STToolbarName = 'fld_barbtnEmrModuleArchiveEmr'
		)
	,'ArchiveEmr'
	,'Void ArchiveEmr()'
	,'BOSERP.Modules.MEEmr.MEEmrModule'
	,1
	);

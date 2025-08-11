DELETE
FROM [dbo].[STToolbarFunctions]
WHERE STToolbarFunctionName = 'FilterEmrsByRoom'

DELETE
FROM [dbo].[STToolbars]
WHERE STToolbarName = 'fld_barbtnEmrModuleFilterEmrsByRoom'

INSERT INTO [dbo].[STToolbars]
VALUES (
	(
		SELECT MAX(STToolbarID) + 1
		FROM [STToolbars]
		)
	,'Alive'
	,2221
	,1
	,N'fld_barbtnEmrModuleFilterEmrsByRoom'
	,N''
	,'FilterEmrsByRoom'
	,'Default'
	,N'Chọn phòng'
	,N'Action'
	,-1
	,'0'
	,N''
	,0
	,N'images/filter/filter_16x16.png'
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
		WHERE STToolbarName = 'fld_barbtnEmrModuleFilterEmrsByRoom'
		)
	,'FilterEmrsByRoom'
	,'Void FilterEmrsByRoom()'
	,'BOSERP.Modules.MEEmr.MEEmrModule'
	,1
	);

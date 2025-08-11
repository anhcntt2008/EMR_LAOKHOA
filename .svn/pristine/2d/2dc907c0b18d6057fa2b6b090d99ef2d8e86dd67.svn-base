DELETE
FROM [dbo].[STToolbarFunctions]
WHERE STToolbarFunctionName = 'DeleteEmrs'
	AND STToolbarFunctionClass = 'BOSERP.Modules.MEEmrManage.MEEmrManageModule'

DELETE
FROM [dbo].[STToolbars]
WHERE STToolbarName = 'fld_barbtnEmrManageDeleteEmrs'

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
	,N'fld_barbtnEmrManageDeleteEmrs'
	,N''
	,'EmrManageDeleteEmrs'
	,'Default'
	,N'Xóa bệnh án'
	,N'Action'
	,11
	,'0'
	,N''
	,0
	,N'images/actions/deletelist_16x16.png'
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
		WHERE STToolbarName = 'fld_barbtnEmrManageDeleteEmrs'
		)
	,'DeleteEmrs'
	,'Void DeleteEmrs()'
	,'BOSERP.Modules.MEEmrManage.MEEmrManageModule'
	,1
	);

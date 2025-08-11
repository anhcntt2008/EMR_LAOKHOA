DELETE
FROM [dbo].[STToolbarFunctions]
WHERE STToolbarFunctionName = 'CloseAllEmr' and STToolbarID = (SELECT STToolbarID
		FROM [STToolbars]
		WHERE STToolbarName = 'fld_barbtnCloseEmr' and STModuleID = (SELECT STModuleID FROM STModules WHERE AAStatus = 'alive' and STModuleName = 'MEEmrManage'))

DELETE
FROM [dbo].[STToolbars]
WHERE STToolbarName = 'fld_barbtnCloseEmr' and STModuleID = (SELECT STModuleID FROM STModules WHERE AAStatus = 'alive' and STModuleName = 'MEEmrManage')

INSERT INTO [dbo].[STToolbars]
VALUES (
	(
		SELECT MAX(STToolbarID) + 1
		FROM [STToolbars]
		)
	,'Alive'
	,2273
	,1
	,N'fld_barbtnCloseEmr'
	,N''
	,'EmrManageClose'
	,'Default'
	,N'Đóng bệnh án'
	,N'Action'
	,11
	,'0'
	,N''
	,0
	,N'images/spreadsheet/encrypt_16x16.png'
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
		WHERE STToolbarName = 'fld_barbtnCloseEmr' and STModuleID = 2273
		)
	,'CloseAllEmr'
	,'Void CloseAllEmr()'
	,'BOSERP.Modules.MEEmrManage.MEEmrManageModule'
	,1
	);

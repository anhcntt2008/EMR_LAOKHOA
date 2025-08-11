DELETE
FROM [dbo].[STToolbarFunctions]
WHERE STToolbarFunctionName = 'ReCloseEmrs'
	AND STToolbarFunctionClass = 'BOSERP.Modules.MEEmrManage.MEEmrManageModule'

DELETE
FROM [dbo].[STToolbars]
WHERE STToolbarName = 'fld_barbtnEmrManageReCloseEmrs'

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
	,N'fld_barbtnEmrManageReCloseEmrs'
	,N''
	,'ReCloseEmrs'
	,'Default'
	,N'Đóng lại TDT'
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
		WHERE STToolbarName = 'fld_barbtnEmrManageReCloseEmrs'
		)
	,'ReCloseEmrs'
	,'Void ReCloseEmrs()'
	,'BOSERP.Modules.MEEmrManage.MEEmrManageModule'
	,1
	);

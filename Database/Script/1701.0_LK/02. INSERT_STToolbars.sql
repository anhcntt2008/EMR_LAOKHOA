DECLARE @STModuleID int
SET @STModuleID = (SELECT STModuleID FROM STModules WHERE AAStatus = 'alive' and STModuleName = 'MEEmrManage')

DELETE
FROM [dbo].[STToolbarFunctions]
WHERE STToolbarFunctionName = 'RestoreEmr' and STToolbarID = (SELECT STToolbarID
		FROM [STToolbars]
		WHERE STToolbarName = 'fld_barbtnRestore' and STModuleID = @STModuleID)

DELETE
FROM [dbo].[STToolbars]
WHERE STToolbarName = 'fld_barbtnRestore' and STModuleID = @STModuleID

INSERT INTO [dbo].[STToolbars]
VALUES (
	(
		SELECT MAX(STToolbarID) + 1
		FROM [STToolbars]
		)
	,'Alive'
	,2273
	,1
	,N'fld_barbtnRestore'
	,N''
	,'EmrManageRestore'
	,'Default'
	,N'Khôi phục BA'
	,N'Action'
	,11
	,'0'
	,N''
	,0
	,N'images/actions/reset_16x16.png'
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
		WHERE STToolbarName = 'fld_barbtnRestore' and STModuleID = @STModuleID
		)
	,'RestoreEmr'
	,'Void RestoreEmr()'
	,'BOSERP.Modules.MEEmrManage.MEEmrManageModule'
	,1
	);

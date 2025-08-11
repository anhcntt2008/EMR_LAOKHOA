DECLARE @STModuleID int
SET @STModuleID = (SELECT STModuleID FROM STModules WHERE AAStatus = 'alive' and STModuleName = 'MEEmr')

DELETE
FROM [dbo].[STToolbarFunctions]
WHERE STToolbarFunctionName = 'ActionDelete' and STToolbarID = (SELECT STToolbarID
		FROM [STToolbars]
		WHERE STToolbarName = 'fld_barbtnDeleteNote' and STModuleID = @STModuleID)

DELETE
FROM [dbo].[STToolbars]
WHERE STToolbarName = 'fld_barbtnDeleteNote' and STModuleID = @STModuleID

INSERT INTO [dbo].[STToolbars]
VALUES (
	(
		SELECT MAX(STToolbarID) + 1
		FROM [STToolbars]
		)
	,'Alive'
	,@STModuleID
	,1
	,N'fld_barbtnDeleteNote'
	,N''
	,'DeleteNote'
	,'Default'
	,N'Xóa ghi chú'
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
		WHERE STToolbarName = 'fld_barbtnDeleteNote' and STModuleID = @STModuleID
		)
	,'DeleteNote'
	,'Void DeleteNote()'
	,'BOSERP.Modules.MEEmr.MEEmrModule'
	,1
	);


DELETE FROM [dbo].[STToolbars] where STToolbarName = 'fld_barbtnTakeInitPermission'
INSERT INTO [dbo].[STToolbars] VALUES (
(SELECT MAX(STToolbarID)+1 FROM [STToolbars])
, 'Alive', 2221, 1, N'fld_barbtnTakeInitPermission', N'', 'TakeInitPermission', 'Default', N'Lấy quyền khởi tạo', N'Action', 11, '0', N'', 0, N'images/richedit/editrangepermission_16x16.png');


DELETE FROM [dbo].[STToolbarFunctions] where STToolbarFunctionName = 'TakeInitPermission'
INSERT INTO [dbo].[STToolbarFunctions] VALUES (
(SELECT MAX(STToolbarFunctionID)+1 FROM [STToolbarFunctions])
, '0', 
(SELECT STToolbarID FROM [STToolbars] WHERE STToolbarName = 'fld_barbtnTakeInitPermission')
, 'TakeInitPermission', 'Void TakeInitPermission()', 'BOSERP.Modules.MEEmr.MEEmrModule', 1);

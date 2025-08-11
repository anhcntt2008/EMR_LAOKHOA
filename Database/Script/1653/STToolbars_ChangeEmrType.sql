DELETE FROM [dbo].[STToolbarFunctions] where STToolbarFunctionName = 'ChangeEmrType'
DELETE FROM [dbo].[STToolbars] where STToolbarName = 'fld_barbtnChangeEmrType'

INSERT INTO [dbo].[STToolbars] VALUES (
(SELECT MAX(STToolbarID)+1 FROM [STToolbars])
, 'Alive', 2221, 1, N'fld_barbtnChangeEmrType', N'', 'ChangeEmrType', 'Default', N'Đổi loại bệnh án', N'Action', 11, '0', N'', 0, N'images/format/replace_16x16.png');

INSERT INTO [dbo].[STToolbarFunctions] VALUES (
(SELECT MAX(STToolbarFunctionID)+1 FROM [STToolbarFunctions])
, '0', 
(SELECT STToolbarID FROM [STToolbars] WHERE STToolbarName = 'fld_barbtnChangeEmrType')
, 'ChangeEmrType', 'Void ChangeEmrType()', 'BOSERP.Modules.MEEmr.MEEmrModule', 1);

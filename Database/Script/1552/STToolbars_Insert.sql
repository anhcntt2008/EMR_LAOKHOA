
INSERT INTO [dbo].[STToolbars] VALUES (
(SELECT MAX(STToolbarID)+1 FROM [STToolbars])
, 'Alive', 2221, 1, N'fld_barbtnUpdateHisChanges', N'', 'UpdateHisChanges', 'Default', N'Cập nhật mới từ HIS',
 N'Action', 9, '1', N'', 0, N'images/actions/convert_16x16.png');

INSERT INTO [dbo].[STToolbarFunctions] VALUES (
(SELECT MAX(STToolbarFunctionID)+1 FROM [STToolbarFunctions])
, '0', 
(SELECT STToolbarID FROM [STToolbars] WHERE STToolbarName = 'fld_barbtnUpdateHisChanges')
, 'UpdateHisChanges', 'Void UpdateHisChanges()', 'BOSERP.Modules.MEEmr.MEEmrModule', 1);
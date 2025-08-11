UPDATE [STToolbars] set STToolbarVisible = 1 where STToolbarName = 'fld_barbtnNewTempEmr'

INSERT INTO [dbo].[STToolbars] VALUES (
(SELECT MAX(STToolbarID)+1 FROM [STToolbars])
, 'Alive', 2221, 1, N'fld_barbtnMergeEmr', N'', 'Merge', 'Default', N'Trộn bệnh án', N'Action', 6, '1', N'', 0, N'images/actions/merge_16x16.png');

INSERT INTO [dbo].[STToolbarFunctions] VALUES (
(SELECT MAX(STToolbarFunctionID)+1 FROM [STToolbarFunctions])
, '0', 
(SELECT STToolbarID FROM [STToolbars] WHERE STToolbarName = 'fld_barbtnMergeEmr')
, 'MergeEmr', 'Void MergeEmr()', 'BOSERP.Modules.MEEmr.MEEmrModule', 1);


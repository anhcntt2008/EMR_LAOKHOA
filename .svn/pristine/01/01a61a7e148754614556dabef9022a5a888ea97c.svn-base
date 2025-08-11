DELETE [STToolbars] WHERE STModuleID = 2270
INSERT INTO [dbo].[STToolbars] VALUES ((SELECT MAX(STToolbarID)+1 FROM [STToolbars]), 'Alive', 2270, 1, N'fld_barbtnSaveList', N'', 'Save', 'Default', N'Lưu', N'Action', 4, '1', N'', 0, N'');
INSERT INTO [dbo].[STToolbars] VALUES ((SELECT MAX(STToolbarID)+1 FROM [STToolbars]), 'Alive', 2270, 1, N'fld_barbtnCancelList', N'', 'Cancel', 'Default', N'Hủy', N'Action', 5, '1', N'', 0, N'');
INSERT INTO [dbo].[STToolbars] VALUES ((SELECT MAX(STToolbarID)+1 FROM [STToolbars]), 'Alive', 2270, 1, N'fld_barbtnCreateFromShared', N'', 'New', 'Default', N'Tạo mới từ danh mục chia sẻ', N'Action', 6, '1', N'', 0, N'');

DELETE [STToolbarFunctions] WHERE STToolbarFunctionClass = 'BOSERP.Modules.MEEmr.EmrAbbrev'
DELETE [STToolbarFunctions] WHERE STToolbarFunctionClass = 'BOSERP.Modules.MEEmr.EmrAbbrevModule'
INSERT INTO [dbo].[STToolbarFunctions] VALUES ((SELECT MAX(STToolbarFunctionID)+1 FROM STToolbarFunctions), '0', 
(SELECT STToolbarID FROM [STToolbars] WHERE STToolbarName = 'fld_barbtnCreateFromShared'
AND STModuleID = 2270), 'CreateFromShared', 'Void CreateFromShared()', 'BOSERP.Modules.EmrAbbrev.EmrAbbrevModule', 1);

INSERT INTO [dbo].[STToolbarFunctions] VALUES ((SELECT MAX(STToolbarFunctionID)+1 FROM STToolbarFunctions), '0', 
(SELECT STToolbarID FROM [STToolbars] WHERE STToolbarName = 'fld_barbtnSaveList' AND STModuleID = 2270), 'ActionSaveList', 'Void ActionSaveList()', 'BOSERP.Modules.EmrAbbrev.EmrAbbrevModule', 1);

INSERT INTO [dbo].[STToolbarFunctions] VALUES ((SELECT MAX(STToolbarFunctionID)+1 FROM STToolbarFunctions), '0', 
(SELECT STToolbarID FROM [STToolbars] WHERE STToolbarName = 'fld_barbtnCancelList' AND STModuleID = 2270), 'ActionInvalidateList', 'Void ActionInvalidateList()', 'BOSERP.Modules.EmrAbbrev.EmrAbbrevModule', 1);


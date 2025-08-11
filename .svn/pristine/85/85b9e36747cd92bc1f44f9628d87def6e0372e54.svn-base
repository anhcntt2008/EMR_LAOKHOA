INSERT INTO [dbo].[STModules]([STModuleID], [AAStatus], [STModuleName], [STModuleCode], [STModuleMain], [IsVisible]) VALUES (2270, 'Alive', 'EmrAbbrev', 'EAB', 0, 0);
INSERT INTO [dbo].[STModuleDescriptions]([STModuleDescriptionID], [STModuleID], [STLanguageID], [STModuleDescriptionDescription]) VALUES (185, 2270, 1, N'Thư viện mã tắt');
INSERT INTO [dbo].[STScreens]([STScreenID], [STScreenNumber], [STScreenText], [STScreenName], [STModuleID], [STUserGroupID], [STScreenBackColor], [STScreenForeColor], [STScreenFontName], [STScreenFontSize], [STScreenFontStyle], [STScreenTag], [STScreenSizeWidth], [STScreenSizeHeight], [STScreenLocationX], [STScreenLocationY], [STScreenShowModal], [STScreenTopMost], [STScreenMatchCode01], [STScreenShowInfoPanel], [STScreenSortOrder], [STScreenPrivilege], [STScreenVisible]) VALUES (1005, 'DMEAB100', N'Danh sách từ viết tắt', 'guiEmrAbbrev', 2270, 1, -526863, -16777216, N'Tahoma', 8.250000000000000, 'Regular', 'DM', 0, 0, 0, 0, '1', '1', NULL, '0', 0, NULL, '1');

DELETE [STToolbars] WHERE STModuleID = 2270
INSERT INTO [dbo].[STToolbars] VALUES ((SELECT MAX(STToolbarID)+1 FROM [STToolbars]), 'Alive', 2270, 1, N'fld_barbtnSaveList', N'', 'SaveList', 'Default', N'Lưu', N'Extra', 4, '1', N'', 0, N'');
INSERT INTO [dbo].[STToolbars] VALUES ((SELECT MAX(STToolbarID)+1 FROM [STToolbars]), 'Alive', 2270, 1, N'fld_barbtnCancelList', N'', 'CancelList', 'Default', N'Hủy', N'Extra', 5, '1', N'', 0, N'');
INSERT INTO [dbo].[STToolbars] VALUES ((SELECT MAX(STToolbarID)+1 FROM [STToolbars]), 'Alive', 2270, 1, N'fld_barbtnCreateFromShared', N'', 'NewList', 'Default', N'Tạo mới từ danh mục chia sẻ', N'Extra', 6, '1', N'', 0, N'');

DELETE [STToolbarFunctions] WHERE STToolbarFunctionClass = 'BOSERP.Modules.MEEmr.EmrAbbrev'
DELETE [STToolbarFunctions] WHERE STToolbarFunctionClass = 'BOSERP.Modules.MEEmr.EmrAbbrevModule'
INSERT INTO [dbo].[STToolbarFunctions] VALUES ((SELECT MAX(STToolbarFunctionID)+1 FROM STToolbarFunctions), '0', 
(SELECT STToolbarID FROM [STToolbars] WHERE STToolbarName = 'fld_barbtnCreateFromShared'
AND STModuleID = 2270), 'CreateFromShared', 'Void CreateFromShared()', 'BOSERP.Modules.MEEmr.EmrAbbrevModule', 1);

INSERT INTO [dbo].[STToolbarFunctions] VALUES ((SELECT MAX(STToolbarFunctionID)+1 FROM STToolbarFunctions), '0', 
(SELECT STToolbarID FROM [STToolbars] WHERE STToolbarName = 'fld_barbtnSaveList' AND STModuleID = 2270), 'ActionSaveList', 'Void ActionSaveList()', 'BOSERP.Modules.MEEmr.EmrAbbrevModule', 1);

INSERT INTO [dbo].[STToolbarFunctions] VALUES ((SELECT MAX(STToolbarFunctionID)+1 FROM STToolbarFunctions), '0', 
(SELECT STToolbarID FROM [STToolbars] WHERE STToolbarName = 'fld_barbtnCancelList' AND STModuleID = 2270), 'ActionInvalidateList', 'Void ActionInvalidateList()', 'BOSERP.Modules.MEEmr.EmrAbbrevModule', 1);


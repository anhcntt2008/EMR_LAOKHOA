INSERT INTO [dbo].[STModules]([STModuleID], [AAStatus], [STModuleName], [STModuleCode], [STModuleMain], [IsVisible]) VALUES (
(SELECT MAX([STModuleID])+1 FROM STModules)
, 'Alive', 'EmrSymbol', 'ESB', 0, 0);

INSERT INTO [dbo].[STModuleDescriptions]([STModuleDescriptionID], [STModuleID], [STLanguageID], [STModuleDescriptionDescription]) VALUES (
(SELECT MAX([STModuleDescriptionID])+1 FROM [STModuleDescriptions])
, 
(SELECT [STModuleID] FROM STModules WHERE STModuleName = 'EmrSymbol')
, 1, N'Ký tự đặc biệt');

INSERT INTO [dbo].[STScreens] VALUES (
 (SELECT MAX([STScreenID])+1 FROM [STScreens])
 , 'DMESB100', N'Ký tự đặc biệt', 'guiEmrSymbol', (SELECT [STModuleID] FROM STModules WHERE STModuleName = 'EmrSymbol'), 1, -526863, -16777216, N'Tahoma', 8.250000000000000, 'Regular', 'DM', 0, 0, 0, 0, '1', '1', NULL, '0', 0, NULL, '1');


INSERT INTO [dbo].[STToolbars] VALUES ((SELECT MAX([STToolbarID])+1 FROM [STToolbars]), 'Alive', (SELECT [STModuleID] FROM STModules WHERE STModuleName = 'EmrSymbol'), 1, N'fld_barbtnCancelEmrSymbol', N'', 'Cancel', 'Default', N'Hủy (F7)', N'Action', 5, '1', N'', 0, N'');

INSERT INTO [dbo].[STToolbars] VALUES ((SELECT MAX([STToolbarID])+1 FROM [STToolbars]), 'Alive', 
(SELECT [STModuleID] FROM STModules WHERE STModuleName = 'EmrSymbol'), 1,
 N'fld_barbtnSaveEmrSymbol', N'', 'Save', 'Default', N'Lưu (F8)', N'Action', 4, '1', N'', 0, N'');


 INSERT INTO [dbo].[STToolbarFunctions] VALUES (
(SELECT MAX(STToolbarFunctionID)+1 FROM [STToolbarFunctions])
, '0', 
(SELECT STToolbarID FROM [STToolbars] WHERE STToolbarName = 'fld_barbtnSaveEmrSymbol')
, 'ActionSaveList', 'Void ActionSaveList()', 'BOSERP.Modules.EmrSymbol.EmrSymbolModule', 1);

 INSERT INTO [dbo].[STToolbarFunctions] VALUES (
(SELECT MAX(STToolbarFunctionID)+1 FROM [STToolbarFunctions])
, '0', 
(SELECT STToolbarID FROM [STToolbars] WHERE STToolbarName = 'fld_barbtnCancelEmrSymbol')
, 'InvalidateModuleObjects', 'Void InvalidateModuleObjects()', 'BOSERP.Modules.EmrSymbol.EmrSymbolModule', 1);
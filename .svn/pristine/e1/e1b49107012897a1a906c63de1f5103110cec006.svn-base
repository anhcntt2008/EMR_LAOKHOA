INSERT INTO [dbo].[STModules]([STModuleID], [AAStatus], [STModuleName], [STModuleCode], [STModuleMain], [IsVisible]) VALUES (
(SELECT MAX([STModuleID])+1 FROM STModules)
, 'Alive', 'EmrShared', 'ESD', 0, 0);

INSERT INTO [dbo].[STModuleDescriptions]([STModuleDescriptionID], [STModuleID], [STLanguageID], [STModuleDescriptionDescription]) VALUES (
(SELECT MAX([STModuleDescriptionID])+1 FROM [STModuleDescriptions])
, 
(SELECT [STModuleID] FROM STModules WHERE STModuleName = 'EmrShared')
, 1, N'Bệnh án đang chia sẻ');

INSERT INTO [dbo].[STScreens] VALUES (
 (SELECT MAX([STScreenID])+1 FROM [STScreens])
 , 'DMESD100', N'Bệnh án đang chia sẻ', 'guiEmrShared', (SELECT [STModuleID] FROM STModules WHERE STModuleName = 'EmrShared'), 1, -526863, -16777216, N'Tahoma', 8.250000000000000, 'Regular', 'DM', 0, 0, 0, 0, '1', '1', NULL, '0', 0, NULL, '1');

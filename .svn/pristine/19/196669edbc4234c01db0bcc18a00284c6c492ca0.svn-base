
SET XACT_ABORT ON
BEGIN TRAN
INSERT INTO [dbo].[STModules]([STModuleID], [AAStatus], [STModuleName], [STModuleCode], [STModuleMain], [IsVisible]) VALUES (2262, 'Alive', 'MEParamLookup', 'MEPL', 0, 0);

INSERT INTO [dbo].[STScreens] VALUES ((SELECT MAX([STScreenID])+1 FROM [STScreens]), 'SMMEPL100', N'Tìm kiếm', 'guiMEParamLookUpSearch', 2262, 1, -526863, -16777216, N'Tahoma', 8.250000000000000, 'Regular', 'SM', 0, 0, 0, 0, '1', '1', NULL, '0', 0, NULL, '1');
INSERT INTO [dbo].[STScreens] VALUES ((SELECT MAX([STScreenID])+1 FROM [STScreens]), 'DMMEPL100', N'Thông tin', 'guiMEParamLookUp', 2262, 1, -526863, -16777216, N'Tahoma', 8.250000000000000, 'Regular', 'DM', 0, 0, 0, 0, '1', '1', NULL, '0', 0, NULL, '1');

INSERT INTO [dbo].[STModuleDescriptions]([STModuleDescriptionID], [STModuleID], [STLanguageID], [STModuleDescriptionDescription]) VALUES (183, 2262, 1, N'Danh mục dữ liệu');

INSERT INTO [dbo].[STToolbars] VALUES ((SELECT MAX([STToolbarID])+1 FROM [STToolbars]), 'Alive', 2262, 1, N'fld_barbtnNew', N'', 'New', 'Default', N'Tạo mới', N'Action', 0, '1', N'', 0, N'');
INSERT INTO [dbo].[STToolbars] VALUES ((SELECT MAX([STToolbarID])+1 FROM [STToolbars]), 'Alive', 2262, 1, N'fld_barbtnEdit', N'', 'Edit', 'Default', N'Sửa', N'Action', 0, '1', N'', 0, N'');
INSERT INTO [dbo].[STToolbars] VALUES ((SELECT MAX([STToolbarID])+1 FROM [STToolbars]), 'Alive', 2262, 1, N'fld_barbtnSave', N'', 'Save', 'Default', N'Lưu', N'Action', 0, '1', N'', 0, N'');
INSERT INTO [dbo].[STToolbars] VALUES ((SELECT MAX([STToolbarID])+1 FROM [STToolbars]), 'Alive', 2262, 1, N'fld_barbtnDelete', N'', 'Delete', 'Default', N'Xóa', N'Action', 0, '1', N'', 0, N'');
INSERT INTO [dbo].[STToolbars] VALUES ((SELECT MAX([STToolbarID])+1 FROM [STToolbars]), 'Alive', 2262, 1, N'fld_barbtnCancel', N'', 'Cancel', 'Default', N'Hủy', N'Action', 0, '1', N'', 0, N'');
COMMIT TRAN
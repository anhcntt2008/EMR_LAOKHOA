--delete STToolbars where STToolbarName = 'fld_barbtnImportSignatureImage'
INSERT INTO [dbo].[STToolbars] VALUES (
(SELECT MAX(STToolbarID)+1 FROM [STToolbars])
, 'Alive', 69, 1, N'fld_barbtnImportSignatureImage', N'', 'SignatureImage', 'Default', N'Import hình chữ ký', N'Action', 6, '1', N'', 0, N'images/content/image_16x16.png');

INSERT INTO [dbo].[STToolbarFunctions] VALUES (
(SELECT MAX(STToolbarFunctionID)+1 FROM [STToolbarFunctions])
, '0', 
(SELECT STToolbarID FROM [STToolbars] WHERE STToolbarName = 'fld_barbtnImportSignatureImage')
, 'ImportSignatureImage', 'Void ImportSignatureImage()', 'BOSERP.Modules.SellStaff.SellStaffModule', 1);
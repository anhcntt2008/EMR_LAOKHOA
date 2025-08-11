
INSERT INTO [dbo].[STToolbars] VALUES (
(SELECT MAX(STToolbarID)+1 FROM [STToolbars])
, 'Alive', 2221, 1, N'fld_barbtnUnsignEmr', N'', 'Unsign', 'Default', N'Hủy ký', N'Action', 7, '1', N'', 0, N'images/actions/reset2_16x16.png');

INSERT INTO [dbo].[STToolbarFunctions] VALUES (
(SELECT MAX(STToolbarFunctionID)+1 FROM [STToolbarFunctions])
, '0', 
(SELECT STToolbarID FROM [STToolbars] WHERE STToolbarName = 'fld_barbtnUnsignEmr')
, 'UnsignEmrDocument', 'Void UnsignEmrDocument()', 'BOSERP.Modules.MEEmr.MEEmrModule', 1);

select * from [dbo].[STToolbars] where STModuleID = 2221

UPDATE [dbo].[STToolbars] SET AAStatus = 'Delete' where STToolbarID = 3913
UPDATE [dbo].[STToolbars] SET STToolbarImage = 'images/richedit/protectdocument_16x16.png' where STToolbarID = 3912
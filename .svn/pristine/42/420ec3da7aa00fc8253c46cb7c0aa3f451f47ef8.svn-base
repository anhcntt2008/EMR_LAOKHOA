
INSERT INTO [dbo].[STToolbars] VALUES (
(SELECT MAX(STToolbarID)+1 FROM [STToolbars])
, 'Alive', 1045, 1, N'fld_barbtnDuplicateTemplate', N'', 'Duplicate', 'Default', N'Tạo bản sao', N'Action', 6, '1', N'', 0, N'images/edit/copy_16x16.png');

INSERT INTO [dbo].[STToolbarFunctions] VALUES (
(SELECT MAX(STToolbarFunctionID)+1 FROM [STToolbarFunctions])
, '0', 
(SELECT STToolbarID FROM [STToolbars] WHERE STToolbarName = 'fld_barbtnDuplicateTemplate')
, 'Duplicate', 'Void Duplicate()', 'BOSERP.Modules.METemplate.METemplateModule', 1);

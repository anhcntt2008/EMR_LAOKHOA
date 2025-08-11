INSERT INTO [dbo].[STToolbars] VALUES ((SELECT MAX(STToolbarID)+1 FROM [STToolbars]), 'Alive', 2221, 1, N'fld_barbtnUnsignEmrGroup', N'', 
'UnsignGroup', 'Default', N'Hủy ký', N'Action', 7, '1', N'', 0, N'images/actions/reset2_16x16.png');

INSERT INTO [dbo].[STToolbars] VALUES ((SELECT MAX(STToolbarID)+1 FROM [STToolbars]), 'Alive', 2221, 1, N'fld_barbtnUnsignEmrStrikeThrough', N'', 
'UnsignEmrStrikeThrough', 'Default', N'Hủy ký gạch ngang', N'Action', 7, '1', N'', 
(SELECT STToolbarID FROM [STToolbars] where STToolbarName = 'fld_barbtnUnsignEmrGroup')
, N'images/format/strikeoutdouble_16x16.png');

UPDATE [dbo].[STToolbars] 
set STToolbarParentID = (SELECT STToolbarID FROM [STToolbars] where STToolbarName = 'fld_barbtnUnsignEmrGroup'),
STToolbarCaption = N'Hủy ký điều chỉnh',
STToolbarGroup = 'Action'
WHERE STToolbarName = 'fld_barbtnUnsignEmr'

INSERT INTO [dbo].[STToolbarFunctions] VALUES ((SELECT MAX(STToolbarFunctionID)+1 FROM [STToolbarFunctions])
, '0', 
(SELECT STToolbarID FROM [STToolbars] where STToolbarName = 'fld_barbtnUnsignEmrStrikeThrough'), 
'UnsignEmrDocumentStrikeThrough', 'Void UnsignEmrDocumentStrikeThrough()', 'BOSERP.Modules.MEEmr.MEEmrModule', 1);

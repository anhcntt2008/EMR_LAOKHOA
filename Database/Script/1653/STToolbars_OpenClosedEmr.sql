DELETE FROM [dbo].[STToolbarFunctions] where STToolbarFunctionName = 'OpenTheClosedEmr'
DELETE FROM [dbo].[STToolbars] where STToolbarName = 'fld_barbtnOpenTheClosedEmr'

INSERT INTO [dbo].[STToolbars] VALUES (
(SELECT MAX(STToolbarID)+1 FROM [STToolbars])
, 'Alive', 2221, 1, N'fld_barbtnOpenTheClosedEmr', N'', 'OpenTheClosedEmr', 'Default', N'Mở lại bệnh án', N'Action', 11, '0', N'', 0, N'images/mail/outbox_16x16.png');

INSERT INTO [dbo].[STToolbarFunctions] VALUES (
(SELECT MAX(STToolbarFunctionID)+1 FROM [STToolbarFunctions])
, '0', 
(SELECT STToolbarID FROM [STToolbars] WHERE STToolbarName = 'fld_barbtnOpenTheClosedEmr')
, 'OpenTheClosedEmr', 'Void OpenTheClosedEmr()', 'BOSERP.Modules.MEEmr.MEEmrModule', 1);

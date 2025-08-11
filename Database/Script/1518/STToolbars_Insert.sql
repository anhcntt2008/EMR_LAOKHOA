INSERT INTO [dbo].[STToolbars] VALUES (
(SELECT MAX(STToolbarID)+1 FROM [STToolbars])
, 'Alive', 2221, 1, N'fld_barbtnNewTempEmr', N'', 'New', 'Default', N'Tạo bệnh án tạm', N'Action', 1, '0', N'', 0, N'images/actions/additem_16x16.png');


INSERT INTO [dbo].[STToolbarFunctions] VALUES (
(SELECT MAX(STToolbarFunctionID)+1 FROM [STToolbarFunctions])
, '0', 
(SELECT STToolbarID FROM [STToolbars] WHERE STToolbarName = 'fld_barbtnNewTempEmr')
, 'CreateEmrTemp', 'Void CreateEmrTemp()', 'BOSERP.Modules.MEEmr.MEEmrModule', 1);

INSERT INTO [dbo].[ADConfigValues] VALUES (
(SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues])
, 'Alive', N'PatientTypeTemp', N'Temp', N'Tạm', N'PatientTypeTemp', N'PatientType', '1');


DELETE [dbo].[ADConfigValues] where ADConfigKey = N'MEEmrActionTypeDataPlugin'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 'Alive', 
N'MEEmrActionTypeDataPlugin', N'DataPlugin', N'Trình cắm dữ liệu', NULL, N'EmrActionType', '1');

DELETE [dbo].[ADConfigValues] where ADConfigKey = N'MEEmrActionTypeCalcPlugin'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 'Alive', 
N'MEEmrActionTypeCalcPlugin', N'CalcPlugin', N'Trình cắm tính toán', NULL, N'EmrActionType', '1');
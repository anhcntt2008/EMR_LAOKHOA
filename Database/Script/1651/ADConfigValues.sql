DELETE FROM ADConfigValues where ADConfigKeyGroup = 'EmrTemplateActionWhen' and ADConfigKey = 'EmrTemplateActionWhenHisInit'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
'Alive', N'EmrTemplateActionWhenHisInit', N'HisInit', N'Khởi tạo tờ từ HIS', N'Khởi tạo tờ từ HIS', N'EmrTemplateActionWhen', '1');

DELETE FROM ADConfigValues where ADConfigKeyGroup = 'EmrActionType' and ADConfigKey = 'MEEmrActionTypeTransformPlugin'
INSERT INTO [dbo].[ADConfigValues] VALUES ((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues])
, 'Alive', N'MEEmrActionTypeTransformPlugin', N'TransformPlugin', N'Trình cắm chuyển đổi', NULL, N'EmrActionType', '1');


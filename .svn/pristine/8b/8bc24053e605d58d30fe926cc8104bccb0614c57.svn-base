DELETE FROM [dbo].[ADConfigValues] WHERE ADConfigKeyGroup = 'EmrTemplateActionWhen' AND ADConfigKey = 'EmrTemplateActionWhenCheckup'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
'Alive', N'EmrTemplateActionWhenCheckup', N'Checkup', N'Kiểm duyệt', N'Kiểm duyệt bệnh án', N'EmrTemplateActionWhen', '1');

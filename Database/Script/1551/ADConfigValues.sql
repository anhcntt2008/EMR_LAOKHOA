DELETE FROM ADConfigValues where ADConfigKeyGroup = 'EmrTemplateActionWhen'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
'Alive', N'EmrTemplateActionWhenInit', N'Init', N'Khởi tạo', N'Khởi tạo tờ bệnh án', N'EmrTemplateActionWhen', '1');
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
'Alive', N'EmrTemplateActionWhenOpen', N'Open', N'Mở', N'Mở tờ bệnh án', N'EmrTemplateActionWhen', '1');
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
'Alive', N'EmrTemplateActionWhenSave', N'Save', N'Lưu', N'Lưu tờ bệnh án', N'EmrTemplateActionWhen', '1');
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
'Alive', N'EmrTemplateActionWhenPrint', N'Print', N'In', N'In tờ bệnh án', N'EmrTemplateActionWhen', '1');
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
'Alive', N'EmrTemplateActionWhenHisUpdated', N'HisUpdated', N'Thay đổi trên HIS', N'Thay đổi trên HIS', N'EmrTemplateActionWhen', '1');

DELETE FROM ADConfigValues where ADConfigKeyGroup = 'EmrTemplateActionDo'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
'Alive', N'EmrTemplateActionDoUpdateDoc', N'UpdateDoc', N'Cập nhật tờ bệnh án', N'Cập nhật tờ bệnh án', N'EmrTemplateActionDo', '1');
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
'Alive', N'EmrTemplateActionDoAskUpdateDoc', N'AskUpdateDoc', N'Hỏi và cập nhật tờ bệnh án', N'Hỏi và cập nhật tờ bệnh án', N'EmrTemplateActionDo', '1');
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
'Alive', N'EmrTemplateActionDoNotify', N'Notify', N'Chỉ thông báo', N'Chỉ thông báo', N'EmrTemplateActionDo', '1');

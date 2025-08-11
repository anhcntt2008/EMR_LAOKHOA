DELETE FROM ADConfigValues where ADConfigKeyGroup = 'ObjectStatePermissionTable' and ADConfigKey = 'ObjectStatePermissionTableEmrs'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'ObjectStatePermissionTableEmrs', N'MEEmrs', N'Bệnh án', NULL, N'ObjectStatePermissionTable', '1');

 DELETE FROM ADConfigValues where ADConfigKeyGroup = 'ObjectStatePermissionTable' and ADConfigKey = 'ObjectStatePermissionTableEmrDocuments'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'ObjectStatePermissionTableEmrDocuments', N'MEEmrDocuments', N'Tờ bệnh án', NULL, N'ObjectStatePermissionTable', '1');

  DELETE FROM ADConfigValues where ADConfigKeyGroup = 'ObjectStatePermissionTable' and ADConfigKey = 'ObjectStatePermissionTableTemplates'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'ObjectStatePermissionTableTemplates', N'METemplates', N'Mẫu bệnh án', NULL, N'ObjectStatePermissionTable', '1');
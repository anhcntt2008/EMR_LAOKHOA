
DELETE [dbo].[ADConfigValues] where ADConfigKey = N'MEEmrActionTypeAddExtFileSharedDoc'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 'Alive', 
N'MEEmrActionTypeAddExtFileSharedDoc', N'AddExtFileSharedDoc', N'Thêm tờ từ File Shared', NULL, N'EmrActionType', '1');

SELECT * FROM ADConfigValues where ADConfigKeyGroup = 'EmrActionType'
INSERT INTO [dbo].[ADConfigValues] VALUES ((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
'Alive', N'EmrActionTypeAddImageFileShared', N'AddImageFileShared', N'Chèn ảnh từ File Shared', N'Chèn ảnh từ File Shared', N'EmrActionType', '1');
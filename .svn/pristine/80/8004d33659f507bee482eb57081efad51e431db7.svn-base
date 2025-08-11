SELECT * FROM ADConfigValues where ADConfigKeyGroup = 'EmrActionType'
INSERT INTO [dbo].[ADConfigValues] VALUES ((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]),
 'Alive', N'EmrActionTypeAutoValue', N'AutoValue', N'Giá trị tự động', N'Giá trị tự động', N'EmrActionType', '1');
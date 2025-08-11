--Run từng dòng
ALTER TABLE [dbo].[MEEmrTemplateActions] add MEEmrTemplateActionCacheExpire int

UPDATE [dbo].[MEEmrTemplateActions] set MEEmrTemplateActionCacheExpire = 0

DELETE FROM [AAColumnAlias] where AAColumnAliasName =  'MEEmrTemplateActionCacheExpire' AND AATableName = 'MEEmrTemplateActions'
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'MEEmrTemplateActionCacheExpire', N'Cache hết hạn trong (ms)', 'MEEmrTemplateActions');
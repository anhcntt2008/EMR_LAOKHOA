--Run từng dòng
ALTER TABLE [dbo].[MEEmrTemplateActions] add MEEmrTemplateActionWhen varchar(100)
ALTER TABLE [dbo].[MEEmrTemplateActions] add MEEmrTemplateActionDo varchar(100)

UPDATE [dbo].[MEEmrTemplateActions] set MEEmrTemplateActionWhen = 'Init'
UPDATE [dbo].[MEEmrTemplateActions] set MEEmrTemplateActionDo = 'UpdateDoc'

INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'MEEmrTemplateActionWhen', N'Tự động chạy khi', 'MEEmrTemplateActions');
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'MEEmrTemplateActionDo', N'Thực thi', 'MEEmrTemplateActions');
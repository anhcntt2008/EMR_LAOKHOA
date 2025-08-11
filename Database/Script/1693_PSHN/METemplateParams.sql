ALTER TABLE [dbo].[METemplateParams] ADD [METemplateParamSignAsGroup] varchar(10) DEFAULT ''

UPDATE [dbo].[METemplateParams] set [METemplateParamSignAsGroup] = ''

ALTER TABLE [dbo].[METemplateParams] ALTER COLUMN METemplateParamSignAsGroup varchar(10) NOT NULL
GO

DELETE FROM [AAColumnAlias] WHERE [AATableName] = 'METemplateParams' AND [AAColumnAliasName] IN ('METemplateParamSignAsGroup')

INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive',N'METemplateParamSignAsGroup',N'Phải ký cả cụm','METemplateParams');
GO
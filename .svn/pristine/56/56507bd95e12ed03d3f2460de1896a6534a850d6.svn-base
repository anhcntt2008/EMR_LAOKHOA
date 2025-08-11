ALTER TABLE [dbo].[METemplateParams] ADD [METemplateParamRequired] BIT DEFAULT 0

UPDATE [dbo].[METemplateParams] set [METemplateParamRequired] = 0

ALTER TABLE [dbo].[METemplateParams] ALTER COLUMN METemplateParamRequired BIT NOT NULL
GO
DELETE FROM [AAColumnAlias] WHERE [AATableName] = 'METemplateParams' AND [AAColumnAliasName] IN ('METemplateParamRequired')

INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive',N'METemplateParamRequired',N'Bắt buộc','METemplateParams');
GO
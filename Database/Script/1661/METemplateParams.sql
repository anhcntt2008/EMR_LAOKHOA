ALTER TABLE [dbo].[METemplateParams] ADD [METemplateParamDisabled] BIT

INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive',N'METemplateParamDisabled',N'Chặn sửa thủ công','METemplateParams');
GO

UPDATE [dbo].[METemplateParams] set [METemplateParamDisabled] = 0

ALTER TABLE [dbo].[METemplateParams] ALTER COLUMN METemplateParamDisabled BIT NOT NULL
ALTER TABLE [dbo].[METemplates] ADD METemplateMaximumPage int

INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive',N'METemplateMaximumPage',N'Số trang tối đa','METemplates');
	GO
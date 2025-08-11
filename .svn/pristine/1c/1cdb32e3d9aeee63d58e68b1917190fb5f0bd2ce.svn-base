ALTER TABLE [dbo].[METemplateParams] ADD METemplateParamOrder int

INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive',N'METemplateParamOrder',N'Số thứ tự','METemplateParams');
	GO
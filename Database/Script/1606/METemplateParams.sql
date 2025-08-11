ALTER TABLE [dbo].[METemplateParams] ADD [MEParamFormatType] varchar(50)
ALTER TABLE [dbo].[METemplateParams] ADD [MEParamFormatString] nvarchar(200)

INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive',N'MEParamFormatType',N'Định dạng dữ liệu','METemplateParams');
GO

INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive',N'MEParamFormatString',N'Định dạng','METemplateParams');
GO
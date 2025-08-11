
DELETE [dbo].[AAColumnAlias] where AATableName = 'METemplateParams' AND AAColumnAliasName = 'MEParamImageHeight'
INSERT INTO [dbo].[AAColumnAlias]
VALUES (
	(
		SELECT MAX([AAColumnAliasID]) + 1
		FROM [dbo].[AAColumnAlias]
		)
	,0
	,''
	,'Alive'
	,N'MEParamImageHeight'
	,N'Chiều cao ảnh'
	,'METemplateParams'
	);
GO


DELETE [dbo].[AAColumnAlias] where AATableName = 'METemplateParams' AND AAColumnAliasName = 'MEParamImageWidth'
INSERT INTO [dbo].[AAColumnAlias]
VALUES (
	(
		SELECT MAX([AAColumnAliasID]) + 1
		FROM [dbo].[AAColumnAlias]
		)
	,0
	,''
	,'Alive'
	,N'MEParamImageWidth'
	,N'Chiều rộng ảnh'
	,'METemplateParams'
	);
GO
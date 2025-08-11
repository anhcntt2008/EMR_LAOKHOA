ALTER TABLE [dbo].[METemplateParams] ADD [METemplateParamUpdToEmr] VARCHAR(50)
GO

UPDATE [dbo].[METemplateParams] SET [METemplateParamUpdToEmr] = ''
GO

DELETE [dbo].[AAColumnAlias] where AATableName = 'METemplateParams' AND AAColumnAliasName = 'METemplateParamUpdToEmr'
INSERT INTO [dbo].[AAColumnAlias]
VALUES (
	(
		SELECT MAX([AAColumnAliasID]) + 1
		FROM [dbo].[AAColumnAlias]
		)
	,0
	,''
	,'Alive'
	,N'METemplateParamUpdToEmr'
	,N'Cập nhật dữ liệu cho bệnh án'
	,'METemplateParams'
	);
GO
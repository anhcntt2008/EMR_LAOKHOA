BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION

GO
IF NOT EXISTS (SELECT * FROM   sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[METemplateParams]') AND name = 'METemplateParamAlternativeSign')
BEGIN
	ALTER TABLE [dbo].[METemplateParams] ADD  [METemplateParamAlternativeSign] BIT NULL
	ALTER TABLE [dbo].[METemplateParams] ADD  CONSTRAINT [DF_METemplateParams_METemplateParamAlternativeSign]  DEFAULT ((0)) FOR [METemplateParamAlternativeSign]
END
GO

UPDATE [dbo].[METemplateParams] SET [METemplateParamAlternativeSign] = 0
GO

ALTER TABLE [dbo].[METemplateParams] ALTER COLUMN  [METemplateParamAlternativeSign] BIT NOT NULL
GO

DELETE
FROM [AAColumnAlias]
WHERE [AATableName] = 'METemplateParams' AND AAColumnAliasName = 'METemplateParamAlternativeSign'

INSERT INTO [dbo].[AAColumnAlias] (
	[AAColumnAliasID]
	,[AANumberInt]
	,[AANumberString]
	,[AAStatus]
	,[AAColumnAliasName]
	,[AAColumnAliasCaption]
	,[AATableName]
	)
VALUES (
	(
		SELECT MAX([AAColumnAliasID]) + 1
		FROM [dbo].[AAColumnAlias]
		)
	,0
	,''
	,'Alive'
	,'METemplateParamAlternativeSign'
	,N'Ký thay'
	,'METemplateParams'
	);

COMMIT

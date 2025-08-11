ALTER TABLE [dbo].[METemplateParams] ADD [MEParamRelationAllowMerge] BIT

INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive',N'MEParamRelationAllowMerge',N'Trộn xuống dòng cùng cấp','METemplateParams');
GO

UPDATE [dbo].[METemplateParams] set MEParamRelationAllowMerge = 0

ALTER TABLE [dbo].[METemplateParams] ALTER COLUMN MEParamRelationAllowMerge BIT NOT NULL
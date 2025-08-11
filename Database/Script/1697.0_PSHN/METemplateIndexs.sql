-- Gom gay manual
GO
IF NOT EXISTS (SELECT * FROM sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[METemplateIndexs]') AND name = 'METemplateIndexRelationOrder')
BEGIN
	ALTER TABLE [dbo].[METemplateIndexs] ADD METemplateIndexRelationOrder int NULL
END
IF NOT EXISTS (SELECT * FROM sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[METemplateIndexs]') AND name = 'METemplateIndexRelationOrder')
BEGIN
	UPDATE [dbo].[METemplateIndexs] SET METemplateIndexRelationOrder=0
END
IF NOT EXISTS (SELECT * FROM sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[METemplateIndexs]') AND name = 'METemplateIndexRelationOrder')
BEGIN
	ALTER TABLE [dbo].[METemplateIndexs] ADD  CONSTRAINT [DF_METemplateIndexs_METemplateIndexRelationOrder]  DEFAULT ((0)) FOR [METemplateIndexRelationOrder]
END
GO
IF NOT EXISTS (SELECT * FROM sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[METemplateIndexs]') AND name = 'METemplateIndexRelationName')
BEGIN
	ALTER TABLE [dbo].[METemplateIndexs] ADD METemplateIndexRelationName nvarchar(250) NULL
END
GO
IF NOT EXISTS (SELECT * FROM sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[METemplateIndexs]') AND name = 'METemplateIndexRelationName')
BEGIN
	UPDATE [dbo].[METemplateIndexs] SET METemplateIndexRelationName=''
END
GO
IF NOT EXISTS (SELECT * FROM sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[METemplateIndexs]') AND name = 'METemplateIndexRelationName')
BEGIN
	ALTER TABLE [dbo].[METemplateIndexs] ADD  CONSTRAINT [DF_METemplateIndexs_METemplateIndexRelationName]  DEFAULT (('')) FOR [METemplateIndexRelationName]
END

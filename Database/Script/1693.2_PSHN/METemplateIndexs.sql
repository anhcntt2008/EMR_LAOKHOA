-- Gom gay khi copy
GO
IF NOT EXISTS (SELECT * FROM sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[METemplateIndexs]') AND name = 'METemplateIndexRelationCombine')
BEGIN
	ALTER TABLE [dbo].[METemplateIndexs] ADD METemplateIndexRelationCombine bit NULL
	UPDATE [dbo].[METemplateIndexs] SET METemplateIndexRelationCombine=0
	ALTER TABLE [dbo].[METemplateIndexs] ADD  CONSTRAINT [DF_METemplateIndexs_METemplateIndexRelationCombine]  DEFAULT ((0)) FOR [METemplateIndexRelationCombine]
END
GO

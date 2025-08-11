ALTER TABLE [MEEmrTypeTemplates] ADD FK_METemplateIndexID INT

ALTER TABLE [dbo].[MEEmrTypeTemplates]  WITH CHECK ADD  CONSTRAINT [FK_MEEmrTypeTemplate_METemplateIndexs] FOREIGN KEY(FK_METemplateIndexID)
REFERENCES [dbo].[METemplateIndexs] (METemplateIndexID)
GO

ALTER TABLE [dbo].[MEEmrTypeTemplates] CHECK CONSTRAINT [FK_MEEmrTypeTemplate_METemplateIndexs]
GO

IF NOT EXISTS (SELECT * FROM sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[MEEmrDocumentNotes]') AND name = 'FK_MEEmrID')
BEGIN
	ALTER TABLE [dbo].[MEEmrDocumentNotes] ADD FK_MEEmrID int NULL
END
GO

ALTER TABLE [dbo].[MEEmrDocumentNotes]  WITH CHECK ADD  CONSTRAINT [FK_MEEmrDocumentNote_MEEmrs] FOREIGN KEY([FK_MEEmrID])
REFERENCES [dbo].[MEEmrs] ([MEEmrID])
GO

ALTER TABLE [dbo].[MEEmrDocumentNotes] CHECK CONSTRAINT [FK_MEEmrDocumentNote_MEEmrs]
GO

UPDATE MEEmrDocumentNotes
SET FK_MEEmrID = emr.MEEmrID
FROM MEEmrDocumentNotes note 
INNER JOIN MEEmrDocuments doc on doc.MEEmrDocumentID = note.FK_MEEmrDocumentID
INNER JOIN MEEmrs emr on emr.MEEmrID = doc.FK_MEEmrID
GO 

ALTER TABLE [dbo].[MEEmrDocumentNotes] ALTER COLUMN FK_MEEmrID int NOT NULL
GO

IF NOT EXISTS (SELECT * FROM sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[MEEmrDocumentNotes]') AND name = 'FK_METemplateID')
BEGIN
	ALTER TABLE [dbo].[MEEmrDocumentNotes] ADD FK_METemplateID int  NULL 
END
GO

ALTER TABLE [dbo].[MEEmrDocumentNotes]  WITH CHECK ADD  CONSTRAINT [FK_MEEmrDocumentNote_METemplates] FOREIGN KEY([FK_METemplateID])
REFERENCES [dbo].[METemplates] ([METemplateID])
GO

ALTER TABLE [dbo].[MEEmrDocumentNotes] CHECK CONSTRAINT [FK_MEEmrDocumentNote_METemplates]
GO

UPDATE MEEmrDocumentNotes
SET FK_METemplateID = doc.FK_METemplateID
FROM MEEmrDocumentNotes note 
INNER JOIN MEEmrDocuments doc on doc.MEEmrDocumentID = note.FK_MEEmrDocumentID
GO 

ALTER TABLE [dbo].[MEEmrDocumentNotes] ALTER COLUMN FK_METemplateID int NOT NULL
GO

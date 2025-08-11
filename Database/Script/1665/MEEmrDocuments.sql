ALTER TABLE MEEmrDocuments ADD [MEEmrDocumentPageCount] int NULL
ALTER TABLE MEEmrDocuments ADD [MEEmrDocumentDuplexCount] int NULL

UPDATE MEEmrDocuments SET MEEmrDocumentPageCount = 0
UPDATE MEEmrDocuments SET MEEmrDocumentDuplexCount = 0

ALTER TABLE [dbo].[MEEmrDocuments] ALTER COLUMN MEEmrDocumentPageCount int NOT NULL
GO

ALTER TABLE [dbo].[MEEmrDocuments] ALTER COLUMN MEEmrDocumentDuplexCount int NOT NULL
GO

ALTER TABLE dbo.[MEEmrDocuments]
  ADD CONSTRAINT MEEmrDocuments_DF_MEEmrDocumentPageCount
  DEFAULT 0 FOR MEEmrDocumentPageCount;
GO

ALTER TABLE dbo.[MEEmrDocuments]
  ADD CONSTRAINT MEEmrDocuments_DF_MEEmrDocumentDuplexCount
  DEFAULT 0 FOR MEEmrDocumentDuplexCount;
GO
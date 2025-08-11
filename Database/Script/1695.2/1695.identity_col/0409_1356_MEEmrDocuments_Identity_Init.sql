SET IDENTITY_INSERT dbo.MEEmrDocuments_Identity ON;
GO
INSERT INTO dbo.MEEmrDocuments_Identity (ID, AT) VALUES((SELECT MAX(MEEmrDocumentID) FROM dbo.MEEmrDocuments), GETDATE())
GO
SET IDENTITY_INSERT dbo.MEEmrDocuments_Identity OFF;
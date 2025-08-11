SET IDENTITY_INSERT dbo.MEEmrDocumentSigns_Identity ON;
GO
INSERT INTO dbo.MEEmrDocumentSigns_Identity (ID, AT) VALUES((SELECT MAX(MEEmrDocumentSignID) FROM dbo.MEEmrDocumentSigns), GETDATE())
GO
SET IDENTITY_INSERT dbo.MEEmrDocumentSigns_Identity OFF;
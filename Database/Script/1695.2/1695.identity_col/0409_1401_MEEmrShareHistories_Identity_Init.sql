SET IDENTITY_INSERT dbo.MEEmrShareHistories_Identity ON;
GO
INSERT INTO dbo.MEEmrShareHistories_Identity (ID, AT) VALUES((SELECT MAX(MEEmrShareHistoryID) FROM dbo.MEEmrShareHistories), GETDATE())
GO
SET IDENTITY_INSERT dbo.MEEmrShareHistories_Identity OFF;
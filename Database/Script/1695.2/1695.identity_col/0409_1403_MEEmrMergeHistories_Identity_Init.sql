SET IDENTITY_INSERT dbo.MEEmrMergeHistories_Identity ON;
GO
INSERT INTO dbo.MEEmrMergeHistories_Identity (ID, AT) VALUES((SELECT MAX(MEEmrMergeHistoryID) FROM dbo.MEEmrMergeHistories), GETDATE())
GO
SET IDENTITY_INSERT dbo.MEEmrMergeHistories_Identity OFF;
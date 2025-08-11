SET IDENTITY_INSERT dbo.MEEmrMergeHistoryDetails_Identity ON;
GO
INSERT INTO dbo.MEEmrMergeHistoryDetails_Identity (ID, AT) VALUES((SELECT MAX(MEEmrMergeHistoryDetailID) FROM dbo.MEEmrMergeHistoryDetails), GETDATE())
GO
SET IDENTITY_INSERT dbo.MEEmrMergeHistoryDetails_Identity OFF;
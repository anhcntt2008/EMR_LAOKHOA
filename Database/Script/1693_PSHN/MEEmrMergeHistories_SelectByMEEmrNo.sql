GO

/****** Object:  StoredProcedure [dbo].[MEEmrMergeHistories_SelectByMEEmrNo]    Script Date: 1/15/2021 1:24:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE OR ALTER PROCEDURE[dbo].[MEEmrMergeHistories_SelectByMEEmrNo]
	@MEEmrFromNo varchar(50),
	@MEEmrToNo varchar(50)
AS
BEGIN
SET NOCOUNT ON
SELECT * FROM [dbo].[MEEmrMergeHistories]
WHERE [AAStatus]='Alive' AND [MEEmrFromNo] = @MEEmrFromNo AND [MEEmrToNo] = @MEEmrToNo
	
END 

GO

IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'IX_AAStatus_MEEmrFromNo_MEEmrToNo' AND object_id = OBJECT_ID('MEEmrMergeHistories'))
BEGIN
	CREATE NONCLUSTERED INDEX IX_AAStatus_MEEmrFromNo_MEEmrToNo ON MEEmrMergeHistories(AAStatus, MEEmrFromNo, MEEmrToNo);
END
GO



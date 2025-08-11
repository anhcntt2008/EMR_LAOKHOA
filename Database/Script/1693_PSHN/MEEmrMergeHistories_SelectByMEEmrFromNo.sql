GO

/****** Object:  StoredProcedure [dbo].[MEEmrMergeHistories_SelectByMEEmrFromNo]    Script Date: 1/15/2021 1:24:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE OR ALTER PROCEDURE[dbo].[MEEmrMergeHistories_SelectByMEEmrFromNo]
	@MEEmrFromNo varchar(50)
AS
BEGIN
SET NOCOUNT ON
SELECT * FROM [dbo].[MEEmrMergeHistories]
WHERE [AAStatus]='Alive' AND [MEEmrFromNo] = @MEEmrFromNo
END 

GO
-- sp_helpindex '[dbo].[MEEmrMergeHistories]'
IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'IX_AAStatus_MEEmrFromNo' AND object_id = OBJECT_ID('MEEmrMergeHistories'))
BEGIN
	CREATE NONCLUSTERED INDEX IX_AAStatus_MEEmrFromNo ON MEEmrMergeHistories(AAStatus, MEEmrFromNo);
END
GO
INSERT INTO [dbo].[GENumbering] (
	[GENumberingID]
	,[AACreatedUser]
	,[AACreatedDate]
	,[AAUpdatedUser]
	,[AAUpdatedDate]
	,[AAStatus]
	,[GENumberingName]
	,[GENumberingPrefix]
	,[GENumberingLength]
	,[GENumberingStart]
	,[GENumberingDesc]
	,[GENumberingPrefixHaveYear]
	,[GENumberingLockNo]
	,[FK_BRBranchID]
	)
VALUES (
		(
		SELECT MAX(GENumberingID) + 1
		FROM [GENumbering]
		)
	,N'uthv'
	,'2019-09-06 19:15:18.497'
	,N'uthv'
	,'2019-08-29 19:15:18.497'
	,'Alive'
	,N'Report'
	,N'RPT'
	,4
	,1000
	,N'Mã báo cáo'
	,'1'
	,'0'
	,0
	);

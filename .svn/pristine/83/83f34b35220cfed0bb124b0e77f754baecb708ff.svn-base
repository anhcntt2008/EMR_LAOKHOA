DELETE [GENumbering] WHERE GENumberingName = 'MEEmrSum'
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
	,N'emr'
	,'2019-09-06 19:15:18.497'
	,N'emr'
	,'2019-08-29 19:15:18.497'
	,'Alive'
	,N'MEEmrSum'
	,N'BATT'
	,8
	,1
	,N'Mã BATT'
	,'1'
	,'0'
	,0
	);
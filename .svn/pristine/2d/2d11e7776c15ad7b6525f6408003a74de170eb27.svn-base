DELETE
FROM [AAColumnAlias]
WHERE [AATableName] = 'MEEmrs' 
AND [AAColumnAliasName] IN ('MEEmrICDCodeIn', 'MEEmrICDStrIn', 'MEEmrICDCodeOut', 'MEEmrICDStrOut')

INSERT INTO [dbo].[AAColumnAlias] (
	[AAColumnAliasID]
	,[AANumberInt]
	,[AANumberString]
	,[AAStatus]
	,[AAColumnAliasName]
	,[AAColumnAliasCaption]
	,[AATableName]
	)
VALUES (
	(
		SELECT MAX([AAColumnAliasID]) + 1
		FROM [dbo].[AAColumnAlias]
		)
	,0
	,''
	,'Alive'
	,'MEEmrICDCodeIn'
	,N'Mã chẩn đoán vào viện'
	,'MEEmrs'
	);
GO

INSERT INTO [dbo].[AAColumnAlias] (
	[AAColumnAliasID]
	,[AANumberInt]
	,[AANumberString]
	,[AAStatus]
	,[AAColumnAliasName]
	,[AAColumnAliasCaption]
	,[AATableName]
	)
VALUES (
	(
		SELECT MAX([AAColumnAliasID]) + 1
		FROM [dbo].[AAColumnAlias]
		)
	,0
	,''
	,'Alive'
	,'MEEmrICDStrIn'
	,N'Chẩn đoán vào viện'
	,'MEEmrs'
	);
GO

INSERT INTO [dbo].[AAColumnAlias] (
	[AAColumnAliasID]
	,[AANumberInt]
	,[AANumberString]
	,[AAStatus]
	,[AAColumnAliasName]
	,[AAColumnAliasCaption]
	,[AATableName]
	)
VALUES (
	(
		SELECT MAX([AAColumnAliasID]) + 1
		FROM [dbo].[AAColumnAlias]
		)
	,0
	,''
	,'Alive'
	,'MEEmrICDCodeOut'
	,N'Mã chẩn đoán ra viện'
	,'MEEmrs'
	);
GO

INSERT INTO [dbo].[AAColumnAlias] (
	[AAColumnAliasID]
	,[AANumberInt]
	,[AANumberString]
	,[AAStatus]
	,[AAColumnAliasName]
	,[AAColumnAliasCaption]
	,[AATableName]
	)
VALUES (
	(
		SELECT MAX([AAColumnAliasID]) + 1
		FROM [dbo].[AAColumnAlias]
		)
	,0
	,''
	,'Alive'
	,'MEEmrICDStrOut'
	,N'Chẩn đoán ra viện'
	,'MEEmrs'
	);
GO
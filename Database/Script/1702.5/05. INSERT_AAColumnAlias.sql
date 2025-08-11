DELETE
FROM [AAColumnAlias]
WHERE [AATableName] = 'MEEmrs' 
AND [AAColumnAliasName]  = 'MEEmrUserAssigned'

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
	,'MEEmrUserAssigned'
	,N'Bác sĩ điều trị'
	,'MEEmrs'
	);
GO

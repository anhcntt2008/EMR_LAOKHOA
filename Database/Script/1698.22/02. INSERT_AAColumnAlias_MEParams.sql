DELETE AAColumnAlias WHERE AATableName='MEParams' AND AAColumnAliasName='MEParamExtend'
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
	,'MEParamExtend'
	,N'Mở rộng'
	,'MEParams'
	);
DELETE FROM [AAColumnAlias] WHERE [AATableName] = 'MEParamLookupDatas' and AAColumnAliasName = 'MEParamLookupDataEmrType'
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
	(SELECT MAX([AAColumnAliasID]) + 1 FROM [dbo].[AAColumnAlias])
	,0
	,''
	,'Alive'
	,'MEParamLookupDataEmrType'
	,N'Loại bệnh án'
	,'MEParamLookupDatas'
	);
GO
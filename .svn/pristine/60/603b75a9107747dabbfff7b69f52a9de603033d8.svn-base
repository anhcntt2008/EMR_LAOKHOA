DELETE
FROM [AAColumnAlias]
WHERE [AAColumnAliasName] = 'FK_HREmployeeStateID'
and [AATableName] = 'HREmployees' 

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
	,'FK_HREmployeeStateID'
	,N'Tình trạng'
	,'HREmployees'
	);
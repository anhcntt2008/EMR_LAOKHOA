DELETE
FROM [AAColumnAlias]
WHERE [AATableName] = 'MEEmrDocumentNotes' 
AND [AAColumnAliasName]  = 'FK_METemplateID'

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
	,'FK_METemplateID'
	,N'Mẫu'
	,'MEEmrDocumentNotes'
	);
GO

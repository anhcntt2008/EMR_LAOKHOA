ALTER TABLE MEEmrDocuments ADD MEEmrDocumentHash varchar(100)
GO

DELETE FROM [AAColumnAlias] WHERE [AATableName] = 'MEEmrDocuments' AND [AAColumnAliasName] IN ('MEEmrDocumentHash')

INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive',N'MEEmrDocumentHash',N'Mã toàn vẹn','MEEmrDocuments');
GO
ALTER TABLE MEEmrDocuments ADD MEEmrDocumentBgJobStatus varchar(100)
GO

DELETE FROM [AAColumnAlias] WHERE [AATableName] = 'MEEmrDocuments' AND [AAColumnAliasName] IN ('MEEmrDocumentBgJobStatus')

INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive',N'MEEmrDocumentBgJobStatus',N'Tác vụ ngầm','MEEmrDocuments');
GO
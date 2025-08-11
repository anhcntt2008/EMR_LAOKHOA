ALTER TABLE MEEmrSymbols ADD MEEmrSymbolStr nvarchar(100)

INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive',N'MEEmrSymbolStr',N'Character string','MEEmrSymbols');
GO
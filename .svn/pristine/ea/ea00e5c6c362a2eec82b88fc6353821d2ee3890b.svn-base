ALTER TABLE [dbo].[MEEmrDocumentSigns] ADD MEEmrDocumentSignHash varchar(256)
ALTER TABLE [dbo].[MEEmrDocumentSigns] ADD MEEmrDocumentSignUser varchar(256)
ALTER TABLE [dbo].[MEEmrDocumentSigns] ADD MEEmrDocumentSignBlockAddr nvarchar(2048)

INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'MEEmrDocumentSignHash', N'Hash', 'MEEmrDocumentSigns');
GO


INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'MEEmrDocumentSignUser', N'User Name', 'MEEmrDocumentSigns');
GO


INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'MEEmrDocumentSignBlockAddr', N'Block', 'MEEmrDocumentSigns');
GO
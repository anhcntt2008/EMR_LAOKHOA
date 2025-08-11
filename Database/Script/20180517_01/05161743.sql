ALTER TABLE [dbo].[MEEmrActionParams] ADD [MEEmrActionParamRequest] bit null;
GO

INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'MEEmrActionParamRequest', N'Tham số gởi đi', 'MEEmrActionParams');
GO

ALTER TABLE MEEmrActionParams ADD MEEmrActionParamEditFromEnd bit

INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive',N'MEEmrActionParamEditFromEnd',N'Điều chỉnh từ cuối','MEEmrActionParams');
GO
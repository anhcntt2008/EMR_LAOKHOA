GO
ALTER TABLE MEParams ADD MEParamMap nvarchar(128)
GO
----
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'MEParamMap', N'Cột dữ liệu', 'MEParams');

GO
----
UPDATE MEParams set MEParamMap = ''

GO
----
ALTER TABLE dbo.MEParams
  ADD CONSTRAINT MEParams_DF_MEParamMap
  DEFAULT '' FOR [MEParamMap];
GO


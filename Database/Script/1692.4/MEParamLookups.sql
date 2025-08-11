-- CHAY TUNG LINE
ALTER TABLE MEParamLookups ADD MEParamLookupSort bit

GO
----
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'MEParamLookupSort', N'Sắp xếp', 'MEParamLookups');

GO
----
UPDATE MEParamLookups set MEParamLookupSort = 1

GO
----
ALTER TABLE dbo.MEParamLookups
  ADD CONSTRAINT MEParamLookups_DF_MEParamLookupSort
  DEFAULT 1 FOR [MEParamLookupSort];
GO


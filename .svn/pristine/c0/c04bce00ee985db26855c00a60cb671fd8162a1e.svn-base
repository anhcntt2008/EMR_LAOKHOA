GO
ALTER TABLE MEParamLookups ADD MEParamLookupPart bit
GO
----
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'MEParamLookupPart', N'Dữ liệu theo thẻ', 'MEParamLookups');

GO
----
UPDATE MEParamLookups set MEParamLookupPart = 0

GO
----
ALTER TABLE dbo.MEParamLookups
  ADD CONSTRAINT MEParamLookups_DF_MEParamLookupPart
  DEFAULT 0 FOR [MEParamLookupPart];
GO

UPDATE MEParamLookups set MEParamLookupPart = 1 WHERE MEParamLookupNo='ICD10'
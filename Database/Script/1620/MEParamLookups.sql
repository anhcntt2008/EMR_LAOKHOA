--chay tung dong
ALTER TABLE [dbo].[MEParamLookups] add [MEParamLookupAutoGroupLevel] int

INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'MEParamLookupAutoGroupLevel', N'Nhóm đến cấp', 'MEParamLookups');
GO

UPDATE [dbo].MEParamLookups set MEParamLookupAutoGroupLevel = 1 where [MEParamLookupAutoGroup] = 1

ALTER TABLE [dbo].MEParamLookups DROP COLUMN [MEParamLookupAutoGroup]

DELETE [dbo].[AAColumnAlias] where AATableName = 'MEParamLookups' and AAColumnAliasName = 'MEParamLookupAutoGroup'
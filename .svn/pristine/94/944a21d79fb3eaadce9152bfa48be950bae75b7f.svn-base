--chay tung dong
ALTER TABLE [dbo].[MEParamLookupDatas] add [MEParamLookupDataGroup1] nvarchar(200)
ALTER TABLE [dbo].[MEParamLookupDatas] add [MEParamLookupDataGroup2] nvarchar(200)

INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'MEParamLookupDataGroup1', N'Nhóm cấp 2', 'MEParamLookupDatas');
GO

INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'MEParamLookupDataGroup2', N'Nhóm cấp 3', 'MEParamLookupDatas');
GO

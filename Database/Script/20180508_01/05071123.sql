ALTER TABLE [dbo].[MEEmrActionParams] ADD MEEmrActionParamSourcePath varchar(1000) null;
GO
INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'MEEmrActionParamSourcePath', N'Dữ liệu nguồn', 'MEEmrActionParams');
GO

INSERT INTO [dbo].[ADConfigValues] VALUES ((SELECT MAX([ADConfigValueID])+1 FROM [dbo].[ADConfigValues]) , 'Alive', N'MEEmrActionTypeLookup', N'Lookup', N'Truy vấn từ bệnh án', NULL, N'EmrActionType', '1');

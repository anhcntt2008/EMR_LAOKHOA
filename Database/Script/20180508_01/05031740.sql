ALTER TABLE [dbo].[MEEmrDocuments] ADD MEEmrDocumentMongoID varchar(50) null;
GO
INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'MEEmrDocumentMongoID', N'Mã dữ liệu', 'MEEmrDocuments');
GO

ALTER TABLE [dbo].[MEEmrActions] ADD FK_MESourceTemplateID int null;
GO
ALTER TABLE [dbo].[MEEmrActions]  WITH CHECK ADD  CONSTRAINT [FK_MEEmrActions_MESourceTemplates] FOREIGN KEY(FK_MESourceTemplateID)
REFERENCES [dbo].[METemplates] ([METemplateID])
GO

ALTER TABLE [dbo].[MEEmrActions] CHECK CONSTRAINT [FK_MEEmrActions_MESourceTemplates]
GO

INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'FK_MESourceTemplateID', N'Dữ liệu nguồn', 'MEEmrActions');
GO

ALTER TABLE [dbo].[MEEmrActions] ADD MEEmrActionScope varchar(50) null;
GO
INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'MEEmrActionScope', N'Phạm vi truy xuất dữ liệu', 'MEEmrActions');
GO

UPDATE [dbo].[ADConfigValues] SET [AAStatus] = 'Alive', [ADConfigKey] = N'MEEmrActionScopeDocument', [ADConfigKeyValue] = N'Document', [ADConfigText] = N'Tập tin bệnh án', [ADConfigKeyDesc] = NULL, [ADConfigKeyGroup] = N'EmrActionScope', [IsActive] = '1' WHERE [ADConfigValueID] = 1413;
UPDATE [dbo].[ADConfigValues] SET [AAStatus] = 'Alive', [ADConfigKey] = N'MEEmrActionScopeEmr', [ADConfigKeyValue] = N'Emr', [ADConfigText] = N'Bệnh án', [ADConfigKeyDesc] = NULL, [ADConfigKeyGroup] = N'EmrActionScope', [IsActive] = '1' WHERE [ADConfigValueID] = 1414;
UPDATE [dbo].[ADConfigValues] SET [AAStatus] = 'Alive', [ADConfigKey] = N'MEEmrActionScopePatient', [ADConfigKeyValue] = N'Patient', [ADConfigText] = N'Bệnh nhân', [ADConfigKeyDesc] = NULL, [ADConfigKeyGroup] = N'EmrActionScope', [IsActive] = '1' WHERE [ADConfigValueID] = 1415;
UPDATE [dbo].[ADConfigValues] SET [AAStatus] = 'Alive', [ADConfigKey] = N'MEEmrActionScopeDepartment', [ADConfigKeyValue] = N'Department', [ADConfigText] = N'Khoa', [ADConfigKeyDesc] = NULL, [ADConfigKeyGroup] = N'EmrActionScope', [IsActive] = '1' WHERE [ADConfigValueID] = 1416;
UPDATE [dbo].[ADConfigValues] SET [AAStatus] = 'Alive', [ADConfigKey] = N'MEEmrActionScopeAll', [ADConfigKeyValue] = N'All', [ADConfigText] = N'Tất cả kho', [ADConfigKeyDesc] = NULL, [ADConfigKeyGroup] = N'EmrActionScope', [IsActive] = '1' WHERE [ADConfigValueID] = 1417;


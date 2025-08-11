ALTER TABLE METemplates ADD FK_HREmployeeShareID int
ALTER TABLE METemplates ADD FK_HRDepartmentShareID int
ALTER TABLE METemplates ADD METemplateShareMode varchar(100)
ALTER TABLE METemplates ADD FK_METemplateID int

ALTER TABLE [dbo].METemplates  WITH CHECK ADD  CONSTRAINT [FK_METemplates_HREmployeeShareID] FOREIGN KEY(FK_HREmployeeShareID)
REFERENCES [dbo].[HREmployees] ([HREmployeeID])
GO

ALTER TABLE [dbo].METemplates CHECK CONSTRAINT [FK_METemplates_HREmployeeShareID]
GO

ALTER TABLE [dbo].METemplates  WITH CHECK ADD  CONSTRAINT [FK_METemplates_FK_HRDepartmentShareID] FOREIGN KEY(FK_HRDepartmentShareID)
REFERENCES [dbo].[HRDepartments] ([HRDepartmentID])
GO

ALTER TABLE [dbo].METemplates CHECK CONSTRAINT [FK_METemplates_FK_HRDepartmentShareID]
GO

ALTER TABLE [dbo].METemplates  WITH CHECK ADD  CONSTRAINT [FK_METemplates_METemplateID] FOREIGN KEY(FK_METemplateID)
REFERENCES [dbo].METemplates ([METemplateID])
GO

ALTER TABLE [dbo].METemplates CHECK CONSTRAINT [FK_METemplates_METemplateID]
GO

UPDATE METemplates SET FK_HREmployeeShareID = 0
UPDATE METemplates SET FK_METemplateID = 0
UPDATE METemplates SET FK_HRDepartmentShareID = 0
UPDATE METemplates SET METemplateShareMode = 'open'

ALTER TABLE METemplates ALTER COLUMN FK_HREmployeeShareID int not null
ALTER TABLE METemplates ALTER COLUMN FK_HRDepartmentShareID int  not null
ALTER TABLE METemplates ALTER COLUMN METemplateShareMode varchar(100)  not null
ALTER TABLE METemplates ALTER COLUMN FK_METemplateID int  not null

INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'FK_HREmployeeShareID', N'Trực thuộc nhân viên', 'METemplates');
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'FK_HRDepartmentShareID', N'Trực thuộc khoa', 'METemplates');
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'METemplateShareMode', N'Quyền', 'METemplates');
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'FK_METemplateID', N'Mẫu cha', 'METemplates');

INSERT INTO [dbo].[ADConfigValues] VALUES ((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 'Alive', N'TemplateShareModePrivated', N'privated', N'Riêng tư', N'', N'TemplateShareMode', '1');
INSERT INTO [dbo].[ADConfigValues] VALUES ((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 'Alive', N'TemplateShareModeDepartment', N'department', N'Công khai cho khoa', N'', N'TemplateShareMode', '1');
INSERT INTO [dbo].[ADConfigValues] VALUES ((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 'Alive', N'TemplateShareModeOpen', N'open', N'Công khai', N'', N'TemplateShareMode', '1');
INSERT INTO [dbo].[ADConfigValues] VALUES ((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 'Alive', N'TemplateTypeSub', N'Sub', N'Mẫu con', N'TemplateTypeSub', N'TemplateType', '1');

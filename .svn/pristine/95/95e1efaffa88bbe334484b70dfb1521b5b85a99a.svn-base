ALTER TABLE [dbo].[MEEmrTypeTemplates] ADD MEEmrTypeTemplateGroup nvarchar(200) null;
GO

INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'MEEmrTypeTemplateGroup', N'Gáy', 'MEEmrTypeTemplates');
GO

ALTER TABLE [dbo].[MEEmrDocuments] ADD MEEmrDocumentGroup nvarchar(200) null;
GO

INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'MEEmrDocumentGroup', N'Gáy', 'MEEmrDocuments');
GO
-- LUU Y
-- cac benh an cu se ko bi loi
UPDATE [MEEmrTypeTemplates] SET MEEmrTypeTemplateGroup = (SELECT t.METemplateName FROM METemplates t where t.METemplateID = [MEEmrTypeTemplates].FK_METemplateID)
select * from [dbo].[MEEmrTypeTemplates]

UPDATE [MEEmrDocuments] SET MEEmrDocumentGroup = (SELECT t.METemplateName FROM METemplates t where t.METemplateID = [MEEmrDocuments].FK_METemplateID)
select * from [dbo].[MEEmrDocuments]
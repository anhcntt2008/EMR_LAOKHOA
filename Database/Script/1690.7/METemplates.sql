ALTER TABLE METemplates ADD METemplateNightlyPdfExport bit
GO
UPDATE METemplates SET METemplateNightlyPdfExport = 0
GO
ALTER TABLE METemplates ALTER COLUMN METemplateNightlyPdfExport bit not null
GO
ALTER TABLE METemplates ADD CONSTRAINT DF_METemplates_METemplateNightlyPdfExport DEFAULT 0 FOR METemplateNightlyPdfExport
GO
DELETE FROM [dbo].[AAColumnAlias] where AATableName = 'METemplates' AND  AAColumnAliasName = 'METemplateNightlyPdfExport'
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'METemplateNightlyPdfExport', N'Tự động xuất PDF hàng ngày', 'METemplates');

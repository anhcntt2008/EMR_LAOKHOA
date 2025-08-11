ALTER TABLE METemplates ADD METemplateHighlightDataTag bit
GO
UPDATE METemplates SET METemplateHighlightDataTag = 0
GO
ALTER TABLE METemplates ALTER COLUMN METemplateHighlightDataTag bit not null

DELETE FROM [dbo].[AAColumnAlias] where AATableName = 'METemplates' AND  AAColumnAliasName = 'METemplateHighlightDataTag'
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'METemplateHighlightDataTag', N'Tô màu thẻ dữ liệu', 'METemplates');

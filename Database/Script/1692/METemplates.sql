ALTER TABLE METemplates ADD METemplateRemoveEmptyParagraph bit
GO
UPDATE METemplates SET METemplateRemoveEmptyParagraph = 0
GO
ALTER TABLE METemplates ALTER COLUMN METemplateRemoveEmptyParagraph bit not null
GO
ALTER TABLE [dbo].[METemplates] ADD  CONSTRAINT [METemplates_DF_METemplateRemoveEmptyParagraph]  DEFAULT ((0)) FOR [METemplateRemoveEmptyParagraph]
GO

DELETE FROM [dbo].[AAColumnAlias] where AATableName = 'METemplates' AND  AAColumnAliasName = 'METemplateRemoveEmptyParagraph'
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'METemplateRemoveEmptyParagraph', N'Xóa dòng trống khi in', 'METemplates');

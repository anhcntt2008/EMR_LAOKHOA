ALTER TABLE METemplates ADD METemplateSignatureNotAlone bit
GO
UPDATE METemplates SET METemplateSignatureNotAlone = 0
GO
ALTER TABLE METemplates ALTER COLUMN METemplateSignatureNotAlone bit not null

DELETE FROM [dbo].[AAColumnAlias] where AATableName = 'METemplates' AND  AAColumnAliasName = 'METemplateSignatureNotAlone'
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'METemplateSignatureNotAlone', N'Chữ ký gần nội dung', 'METemplates');

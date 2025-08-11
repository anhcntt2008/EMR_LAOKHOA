ALTER TABLE METemplates ADD METemplateDgtSignatureX int
ALTER TABLE METemplates ADD METemplateDgtSignatureY int
ALTER TABLE METemplates ADD METemplateDgtSignatureWidth int
ALTER TABLE METemplates ADD METemplateDgtSignatureHeight int
ALTER TABLE METemplates ADD METemplateDgtSignatureFontSize int
ALTER TABLE METemplates ADD METemplateDgtSignatureTextColor int
ALTER TABLE METemplates ADD METemplateDgtSignaturePage int
ALTER TABLE METemplates ADD METemplateDgtSignatureImage bit
ALTER TABLE METemplates ADD METemplateDgtSignatureVisible bit
ALTER TABLE METemplates ADD METemplateDgtSignatureReason nvarchar(250)

UPDATE METemplates SET METemplateDgtSignatureX = 0
UPDATE METemplates SET METemplateDgtSignatureY = 0
UPDATE METemplates SET METemplateDgtSignatureWidth = 0
UPDATE METemplates SET METemplateDgtSignatureHeight = 0
UPDATE METemplates SET METemplateDgtSignatureFontSize = 0
UPDATE METemplates SET METemplateDgtSignaturePage = 1
UPDATE METemplates SET METemplateDgtSignatureImage = 1
UPDATE METemplates SET METemplateDgtSignatureVisible = 1
UPDATE METemplates SET METemplateDgtSignatureTextColor = 0

ALTER TABLE METemplates ALTER COLUMN METemplateDgtSignatureX int not null
ALTER TABLE METemplates ALTER COLUMN METemplateDgtSignatureY int  not null
ALTER TABLE METemplates ALTER COLUMN METemplateDgtSignatureWidth int not null
ALTER TABLE METemplates ALTER COLUMN METemplateDgtSignatureHeight int  not null
ALTER TABLE METemplates ALTER COLUMN METemplateDgtSignatureTextColor int not null
ALTER TABLE METemplates ALTER COLUMN METemplateDgtSignatureFontSize int not null
ALTER TABLE METemplates ALTER COLUMN METemplateDgtSignaturePage int not null
ALTER TABLE METemplates ALTER COLUMN METemplateDgtSignatureImage bit not null
ALTER TABLE METemplates ALTER COLUMN METemplateDgtSignatureVisible bit not null

DELETE FROM [dbo].[AAColumnAlias] where AATableName = 'METemplates' AND  AAColumnAliasName = 'METemplateDgtSignatureX'
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'METemplateDgtSignatureX', N'Ký số - Tọa độ X góc Dưới-Trái', 'METemplates');

DELETE FROM [dbo].[AAColumnAlias] where AATableName = 'METemplates' AND  AAColumnAliasName = 'METemplateDgtSignatureY'
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'METemplateDgtSignatureY', N'Ký số - Tọa độ Y góc Dưới-Trái', 'METemplates');

DELETE FROM [dbo].[AAColumnAlias] where AATableName = 'METemplates' AND  AAColumnAliasName = 'METemplateDgtSignatureWidth'
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'METemplateDgtSignatureWidth', N'Ký số - Chiều rộng stamp', 'METemplates');

DELETE FROM [dbo].[AAColumnAlias] where AATableName = 'METemplates' AND  AAColumnAliasName = 'METemplateDgtSignatureHeight'
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'METemplateDgtSignatureHeight', N'Ký số - Chiều cao stamp', 'METemplates');

DELETE FROM [dbo].[AAColumnAlias] where AATableName = 'METemplates' AND  AAColumnAliasName = 'METemplateDgtSignatureFontSize'
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'METemplateDgtSignatureFontSize', N'Ký số - Cỡ chữ', 'METemplates');

DELETE FROM [dbo].[AAColumnAlias] where AATableName = 'METemplates' AND  AAColumnAliasName = 'METemplateDgtSignatureTextColor'
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'METemplateDgtSignatureTextColor', N'Ký số - Màu chữ', 'METemplates');

DELETE FROM [dbo].[AAColumnAlias] where AATableName = 'METemplates' AND  AAColumnAliasName = 'METemplateDgtSignaturePage'
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'METemplateDgtSignaturePage', N'Ký số - Ký ở trang', 'METemplates');

DELETE FROM [dbo].[AAColumnAlias] where AATableName = 'METemplates' AND  AAColumnAliasName = 'METemplateDgtSignatureImage'
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'METemplateDgtSignatureImage', N'Ký số - Chèn ảnh chữ ký', 'METemplates');

DELETE FROM [dbo].[AAColumnAlias] where AATableName = 'METemplates' AND  AAColumnAliasName = 'METemplateDgtSignatureReason'
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'METemplateDgtSignatureReason', N'Ký số - Lý do', 'METemplates');

DELETE FROM [dbo].[AAColumnAlias] where AATableName = 'METemplates' AND  AAColumnAliasName = 'METemplateDgtSignatureVisible'
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'METemplateDgtSignatureVisible', N'Ký số - Hiện stamp chữ ký', 'METemplates');
ALTER TABLE MEEmrTypes ADD MEEmrTypeDgtSignatureX int
ALTER TABLE MEEmrTypes ADD MEEmrTypeDgtSignatureY int
ALTER TABLE MEEmrTypes ADD MEEmrTypeDgtSignatureWidth int
ALTER TABLE MEEmrTypes ADD MEEmrTypeDgtSignatureHeight int
ALTER TABLE MEEmrTypes ADD MEEmrTypeDgtSignatureFontSize int
ALTER TABLE MEEmrTypes ADD MEEmrTypeDgtSignatureTextColor int
ALTER TABLE MEEmrTypes ADD MEEmrTypeDgtSignaturePage int
ALTER TABLE MEEmrTypes ADD MEEmrTypeDgtSignatureImage bit
ALTER TABLE MEEmrTypes ADD MEEmrTypeDgtSignatureVisible bit
ALTER TABLE MEEmrTypes ADD MEEmrTypeDgtSignatureReason nvarchar(250)

UPDATE MEEmrTypes SET MEEmrTypeDgtSignatureX = 0
UPDATE MEEmrTypes SET MEEmrTypeDgtSignatureY = 0
UPDATE MEEmrTypes SET MEEmrTypeDgtSignatureWidth = 0
UPDATE MEEmrTypes SET MEEmrTypeDgtSignatureHeight = 0
UPDATE MEEmrTypes SET MEEmrTypeDgtSignatureFontSize = 0
UPDATE MEEmrTypes SET MEEmrTypeDgtSignaturePage = 1
UPDATE MEEmrTypes SET MEEmrTypeDgtSignatureImage = 1
UPDATE MEEmrTypes SET MEEmrTypeDgtSignatureVisible = 1
UPDATE MEEmrTypes SET MEEmrTypeDgtSignatureTextColor = 0

ALTER TABLE MEEmrTypes ALTER COLUMN MEEmrTypeDgtSignatureX int not null
ALTER TABLE MEEmrTypes ALTER COLUMN MEEmrTypeDgtSignatureY int  not null
ALTER TABLE MEEmrTypes ALTER COLUMN MEEmrTypeDgtSignatureWidth int not null
ALTER TABLE MEEmrTypes ALTER COLUMN MEEmrTypeDgtSignatureHeight int  not null
ALTER TABLE MEEmrTypes ALTER COLUMN MEEmrTypeDgtSignatureTextColor int not null
ALTER TABLE MEEmrTypes ALTER COLUMN MEEmrTypeDgtSignatureFontSize int not null
ALTER TABLE MEEmrTypes ALTER COLUMN MEEmrTypeDgtSignaturePage int not null
ALTER TABLE MEEmrTypes ALTER COLUMN MEEmrTypeDgtSignatureImage bit not null
ALTER TABLE MEEmrTypes ALTER COLUMN MEEmrTypeDgtSignatureVisible bit not null

DELETE FROM [dbo].[AAColumnAlias] where AATableName = 'MEEmrTypes' AND  AAColumnAliasName = 'MEEmrTypeDgtSignatureX'
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'MEEmrTypeDgtSignatureX', N'Ký số - Tọa độ X góc Dưới-Trái', 'MEEmrTypes');

DELETE FROM [dbo].[AAColumnAlias] where AATableName = 'MEEmrTypes' AND  AAColumnAliasName = 'MEEmrTypeDgtSignatureY'
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'MEEmrTypeDgtSignatureY', N'Ký số - Tọa độ Y góc Dưới-Trái', 'MEEmrTypes');

DELETE FROM [dbo].[AAColumnAlias] where AATableName = 'MEEmrTypes' AND  AAColumnAliasName = 'MEEmrTypeDgtSignatureWidth'
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'MEEmrTypeDgtSignatureWidth', N'Ký số - Chiều rộng stamp', 'MEEmrTypes');

DELETE FROM [dbo].[AAColumnAlias] where AATableName = 'MEEmrTypes' AND  AAColumnAliasName = 'MEEmrTypeDgtSignatureHeight'
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'MEEmrTypeDgtSignatureHeight', N'Ký số - Chiều cao stamp', 'MEEmrTypes');

DELETE FROM [dbo].[AAColumnAlias] where AATableName = 'MEEmrTypes' AND  AAColumnAliasName = 'MEEmrTypeDgtSignatureFontSize'
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'MEEmrTypeDgtSignatureFontSize', N'Ký số - Cỡ chữ', 'MEEmrTypes');

DELETE FROM [dbo].[AAColumnAlias] where AATableName = 'MEEmrTypes' AND  AAColumnAliasName = 'MEEmrTypeDgtSignatureTextColor'
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'MEEmrTypeDgtSignatureTextColor', N'Ký số - Màu chữ', 'MEEmrTypes');

DELETE FROM [dbo].[AAColumnAlias] where AATableName = 'MEEmrTypes' AND  AAColumnAliasName = 'MEEmrTypeDgtSignaturePage'
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'MEEmrTypeDgtSignaturePage', N'Ký số - Ký ở trang', 'MEEmrTypes');

DELETE FROM [dbo].[AAColumnAlias] where AATableName = 'MEEmrTypes' AND  AAColumnAliasName = 'MEEmrTypeDgtSignatureImage'
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'MEEmrTypeDgtSignatureImage', N'Ký số - Chèn ảnh chữ ký', 'MEEmrTypes');

DELETE FROM [dbo].[AAColumnAlias] where AATableName = 'MEEmrTypes' AND  AAColumnAliasName = 'MEEmrTypeDgtSignatureReason'
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'MEEmrTypeDgtSignatureReason', N'Ký số - Lý do', 'MEEmrTypes');

DELETE FROM [dbo].[AAColumnAlias] where AATableName = 'MEEmrTypes' AND  AAColumnAliasName = 'MEEmrTypeDgtSignatureVisible'
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'MEEmrTypeDgtSignatureVisible', N'Ký số - Hiện stamp chữ ký', 'MEEmrTypes');
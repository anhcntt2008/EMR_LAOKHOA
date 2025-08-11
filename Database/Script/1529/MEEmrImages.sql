-- CHAY THEO THU TU
--1
ALTER TABLE MEEmrImages ADD MEEmrImageWidth int 
ALTER TABLE MEEmrImages ADD MEEmrImageHeight int 

--2
UPDATE MEEmrImages SET MEEmrImageWidth = 0, MEEmrImageHeight = 0

--3
ALTER TABLE MEEmrImages 
ALTER COLUMN MEEmrImageWidth int  NOT NULL

ALTER TABLE MEEmrImages 
ALTER COLUMN MEEmrImageHeight int  NOT NULL

--4
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'MEEmrImageWidth', N'Chiều rộng', 'MEEmrImages');
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'MEEmrImageHeight', N'Chiều cao', 'MEEmrImages');
ALTER TABLE MEParams ADD MEParamImageHeight int
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, 
'', 'Alive', 'MEParamImageHeight', N'Chiều cao ảnh', 'MEParams');

ALTER TABLE MEParams ADD MEParamImageWidth int
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, 
'', 'Alive', 'MEParamImageWidth', N'Chiều rộng ảnh', 'MEParams');
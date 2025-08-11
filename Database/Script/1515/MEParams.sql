ALTER TABLE MEParams ADD MEParamPrintHidden bit
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'MEParamPrintHidden', N'Không in ra', 'MEParams');

ALTER TABLE [dbo].[METemplateParams] ADD METemplateParamPrintHidden bit
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'METemplateParamPrintHidden', N'Không in ra', 'METemplateParams');

ALTER TABLE [dbo].[METemplateParams] ADD METemplateParamManualAdded bit
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'METemplateParamManualAdded', N'Được thêm thủ công', 'METemplateParams');
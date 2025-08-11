INSERT INTO [dbo].[AAColumnAlias]([AAColumnAliasID], [AANumberInt], [AANumberString], [AAStatus], [AAColumnAliasName], [AAColumnAliasCaption], [AATableName]) VALUES (
(SELECT MAX(AAColumnAliasID)+ 1 FROM [AAColumnAlias]), 0, '', 'Alive', 'FK_METemplateIndexID', N'Gáy bệnh án', 'MEEmrTypeTemplates');

INSERT INTO [dbo].[AAColumnAlias]([AAColumnAliasID], [AANumberInt], [AANumberString], [AAStatus], [AAColumnAliasName], [AAColumnAliasCaption], [AATableName]) VALUES (
(SELECT MAX(AAColumnAliasID)+ 1 FROM [AAColumnAlias]), 0, '', 'Alive', 'MEEmrDocumentRefNo', N'Số tham chiếu', 'MEEmrDocuments');

DELETE FROM AAColumnAlias WHERE [AATableName] = 'METemplateIndexs'
INSERT INTO [dbo].[AAColumnAlias]([AAColumnAliasID], [AANumberInt], [AANumberString], [AAStatus], [AAColumnAliasName], [AAColumnAliasCaption], [AATableName]) VALUES (
(SELECT MAX(AAColumnAliasID)+ 1 FROM [AAColumnAlias]), 0, '', 'Alive', 'FK_MEEmrTypeID', N'Loại bệnh án', 'METemplateIndexs');
INSERT INTO [dbo].[AAColumnAlias]([AAColumnAliasID], [AANumberInt], [AANumberString], [AAStatus], [AAColumnAliasName], [AAColumnAliasCaption], [AATableName]) VALUES (
(SELECT MAX(AAColumnAliasID)+ 1 FROM [AAColumnAlias]), 0, '', 'Alive', 'METemplateIndexOrder', N'Thứ tự', 'METemplateIndexs');
INSERT INTO [dbo].[AAColumnAlias]([AAColumnAliasID], [AANumberInt], [AANumberString], [AAStatus], [AAColumnAliasName], [AAColumnAliasCaption], [AATableName]) VALUES (
(SELECT MAX(AAColumnAliasID)+ 1 FROM [AAColumnAlias]), 0, '', 'Alive', 'METemplateIndexName', N'Tên gáy', 'METemplateIndexs');
INSERT INTO [dbo].[AAColumnAlias]([AAColumnAliasID], [AANumberInt], [AANumberString], [AAStatus], [AAColumnAliasName], [AAColumnAliasCaption], [AATableName]) VALUES (
(SELECT MAX(AAColumnAliasID)+ 1 FROM [AAColumnAlias]), 0, '', 'Alive', 'METemplateIndexDesc', N'Xếp ngược', 'METemplateIndexs');
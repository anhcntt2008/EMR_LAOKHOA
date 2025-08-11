
DELETE FROM [dbo].[AAColumnAlias] where [AATableName] = 'MEEmrDocuments'

INSERT INTO [dbo].[AAColumnAlias]([AAColumnAliasID], [AANumberInt], [AANumberString], [AAStatus], [AAColumnAliasName], [AAColumnAliasCaption], [AATableName]) VALUES (2492, 0, '', 'Alive', 'MEEmrDocumentNo', N'Mã tài liệu', 'MEEmrDocuments');
INSERT INTO [dbo].[AAColumnAlias]([AAColumnAliasID], [AANumberInt], [AANumberString], [AAStatus], [AAColumnAliasName], [AAColumnAliasCaption], [AATableName]) VALUES (2493, 0, '', 'Alive', 'MEEmrDocumentFile', N'File', 'MEEmrDocuments');
INSERT INTO [dbo].[AAColumnAlias]([AAColumnAliasID], [AANumberInt], [AANumberString], [AAStatus], [AAColumnAliasName], [AAColumnAliasCaption], [AATableName]) VALUES (2494, 0, '', 'Alive', 'MEEmrDocumentDesc', N'Mô tả', 'MEEmrDocuments');
INSERT INTO [dbo].[AAColumnAlias]([AAColumnAliasID], [AANumberInt], [AANumberString], [AAStatus], [AAColumnAliasName], [AAColumnAliasCaption], [AATableName]) VALUES (2495, 0, '', 'Alive', 'FK_MEEmrID', N'Bệnh án', 'MEEmrDocuments');
INSERT INTO [dbo].[AAColumnAlias]([AAColumnAliasID], [AANumberInt], [AANumberString], [AAStatus], [AAColumnAliasName], [AAColumnAliasCaption], [AATableName]) VALUES (2496, 0, '', 'Alive', 'FK_METemplateID', N'Mẫu', 'MEEmrDocuments');
INSERT INTO [dbo].[AAColumnAlias]([AAColumnAliasID], [AANumberInt], [AANumberString], [AAStatus], [AAColumnAliasName], [AAColumnAliasCaption], [AATableName]) VALUES (2497, 0, '', 'Alive', 'MEEmrDocumentCreatedDate', N'Ngày tạo', 'MEEmrDocuments');
INSERT INTO [dbo].[AAColumnAlias]([AAColumnAliasID], [AANumberInt], [AANumberString], [AAStatus], [AAColumnAliasName], [AAColumnAliasCaption], [AATableName]) VALUES (2498, 0, '', 'Alive', 'MEEmrDocumentEndDate', N'Ngày đóng', 'MEEmrDocuments');
INSERT INTO [dbo].[AAColumnAlias]([AAColumnAliasID], [AANumberInt], [AANumberString], [AAStatus], [AAColumnAliasName], [AAColumnAliasCaption], [AATableName]) VALUES (2499, 0, '', 'Alive', 'MEEmrDocumentStatus', N'Trạng thái', 'MEEmrDocuments');
INSERT INTO [dbo].[AAColumnAlias]([AAColumnAliasID], [AANumberInt], [AANumberString], [AAStatus], [AAColumnAliasName], [AAColumnAliasCaption], [AATableName]) VALUES (2529, 0, '', 'Alive', 'MEEmrDocumentOrder', N'Thứ tự', 'MEEmrDocuments');

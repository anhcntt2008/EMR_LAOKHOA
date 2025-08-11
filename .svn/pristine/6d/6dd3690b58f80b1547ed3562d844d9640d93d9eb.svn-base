
--chạy từng dòng
ALTER TABLE MEEmrDocuments ADD MEEmrDocumentCode varchar (200)

INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'MEEmrDocumentCode', N'Tờ số', 'MEEmrDocuments');

ALTER TABLE [dbo].[MEEmrDocuments] ADD [MEEmrDocumentSubOrder] int

UPDATE [dbo].[AAColumnAlias] SET AAColumnAliasCaption = N'Thứ tự nhóm' WHERE AATableName = 'MEEmrDocuments' and AAColumnAliasName ='MEEmrDocumentOrder'

INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'MEEmrDocumentSubOrder', N'Thứ tự', 'MEEmrDocuments');
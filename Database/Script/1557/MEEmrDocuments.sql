
--chạy từng dòng
ALTER TABLE MEEmrDocuments ADD MEEmrDocumentHoldFrom datetime

INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'MEEmrDocumentHoldFrom', N'Giữ tờ bệnh án từ', 'MEEmrDocuments');
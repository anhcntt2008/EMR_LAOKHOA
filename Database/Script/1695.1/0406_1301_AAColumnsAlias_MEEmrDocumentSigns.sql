select * from AAColumnAlias where AATableName = 'MEEmrDocumentSigns'
UPDATE AAColumnAlias SET AAColumnAliasCaption = N'Nhân viên' where AATableName = 'MEEmrDocumentSigns' AND AAColumnAliasName = 'FK_HREmployeeID'
UPDATE AAColumnAlias SET AAColumnAliasCaption = N'Mã băm toàn vẹn' where AATableName = 'MEEmrDocumentSigns' AND AAColumnAliasName = 'MEEmrDocumentSignHash'
UPDATE AAColumnAlias SET AAColumnAliasCaption = N'Mã người ký' where AATableName = 'MEEmrDocumentSigns' AND AAColumnAliasName = 'MEEmrDocumentSignUser'
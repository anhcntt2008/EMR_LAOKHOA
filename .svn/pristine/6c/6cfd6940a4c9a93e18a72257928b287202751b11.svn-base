ALTER TABLE MEEmrDocumentSigns ADD MEEmrDocumentSignType varchar(50)
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'MEEmrDocumentSignType', N'Phân loại', 'MEEmrDocumentSigns');

UPDATE MEEmrDocumentSigns SET MEEmrDocumentSignType ='Signed'

INSERT INTO [dbo].[ADConfigValues] VALUES ((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 'Alive', N'EmrDocumentSignTypeSigned', N'Signed', N'Đã ký', N'', N'EmrDocumentSignType', '1');
INSERT INTO [dbo].[ADConfigValues] VALUES ((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 'Alive', N'EmrDocumentSignTypeUnsigned', N'Unsigned', N'Hủy ký', N'', N'EmrDocumentSignType', '1');


ALTER TABLE MEEmrDocumentSigns ADD MEEmrDocumentSignRemark nvarchar(500)
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'MEEmrDocumentSignRemark', N'Lý do', 'MEEmrDocumentSigns');
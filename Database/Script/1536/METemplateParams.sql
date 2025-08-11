ALTER TABLE [dbo].[METemplateParams] ADD METemplateParamUpdateTo varchar (100)
INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'METemplateParamUpdateTo', N'Cập nhật dữ liệu cho', 'METemplateParams');

DELETE FROM [dbo].[ADConfigValues] where ADConfigKeyGroup = 'TemplateParamUpdateTo'

INSERT INTO [dbo].[ADConfigValues] VALUES ((SELECT MAX([ADConfigValueID])+ 1 FROM [ADConfigValues]), 
'Alive', N'TemplateParamUpdateToMEEmrDocumentDesc', N'MEEmrDocumentDesc', N'Mô tả tờ bệnh án', NULL, N'TemplateParamUpdateTo', '1');

INSERT INTO [dbo].[ADConfigValues] VALUES ((SELECT MAX([ADConfigValueID])+ 1 FROM [ADConfigValues]), 
'Alive', N'TemplateParamUpdateToMEEmrDocumentCreatedDate', N'MEEmrDocumentCreatedDate', N'Ngày tạo tờ bệnh án', NULL, N'TemplateParamUpdateTo', '1');

INSERT INTO [dbo].[ADConfigValues] VALUES ((SELECT MAX([ADConfigValueID])+ 1 FROM [ADConfigValues]), 
'Alive', N'TemplateParamUpdateToMEEmrDocumentEndDate', N'MEEmrDocumentEndDate', N'Ngày kết thúc tờ bệnh án', NULL, N'TemplateParamUpdateTo', '1');

INSERT INTO [dbo].[ADConfigValues] VALUES ((SELECT MAX([ADConfigValueID])+ 1 FROM [ADConfigValues]), 
'Alive', N'TemplateParamUpdateToMEEmrDocumentOrder', N'MEEmrDocumentOrder', N'Thứ tự gáy', NULL, N'TemplateParamUpdateTo', '1');

INSERT INTO [dbo].[ADConfigValues] VALUES ((SELECT MAX([ADConfigValueID])+ 1 FROM [ADConfigValues]), 
'Alive', N'TemplateParamUpdateToMEEmrDocumentGroup', N'MEEmrDocumentGroup', N'Tên gáy', NULL, N'TemplateParamUpdateTo', '1');

INSERT INTO [dbo].[ADConfigValues] VALUES ((SELECT MAX([ADConfigValueID])+ 1 FROM [ADConfigValues]), 
'Alive', N'TemplateParamUpdateToMEEmrDocumentCode', N'MEEmrDocumentCode', N'Số tờ', NULL, N'TemplateParamUpdateTo', '1');

INSERT INTO [dbo].[ADConfigValues] VALUES ((SELECT MAX([ADConfigValueID])+ 1 FROM [ADConfigValues]), 
'Alive', N'TemplateParamUpdateToMEEmrDocumentSubOrder', N'MEEmrDocumentSubOrder', N'Thứ tự trong gáy', NULL, N'TemplateParamUpdateTo', '1');
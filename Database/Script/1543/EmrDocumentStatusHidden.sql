INSERT INTO [dbo].[ADConfigValues] VALUES ((SELECT MAX([ADConfigValueID])+1 FROM [ADConfigValues]), 'Alive', N'EmrDocumentStatusHidden', N'Hidden', N'Đã ẩn', NULL, N'EmrDocumentStatus', '1');

DELETE FROM ADConfigValues where ADConfigKeyGroup = 'EmrDocumentBgJobStatus' and ADConfigKey = 'EmrDocumentBgJobStatusIniting'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'EmrDocumentBgJobStatusIniting', N'Initing', N'Đang khởi tạo ngầm', NULL, N'EmrDocumentBgJobStatus', '1');
GO

DELETE FROM ADConfigValues where ADConfigKeyGroup = 'EmrDocumentBgJobStatus' and ADConfigKey = 'EmrDocumentBgJobStatusCreated'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'EmrDocumentBgJobStatusCreated', N'Created', N'Tạo thành công', NULL, N'EmrDocumentBgJobStatus', '1');
GO

DELETE FROM ADConfigValues where ADConfigKeyGroup = 'EmrDocumentBgJobStatus' and ADConfigKey = 'EmrDocumentBgJobStatusCreatedWithErr'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'EmrDocumentBgJobStatusCreatedWithErr', N'CreatedWithErr', N'Lỗi khi tạo', N'Có lỗi khi tạo nhưng vẫn giữ lại tờ', N'EmrDocumentBgJobStatus', '1');
GO

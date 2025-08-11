DELETE FROM ADConfigValues where ADConfigKeyGroup = 'TemplateType' and ADConfigKey = 'TemplateTypeReport'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'TemplateTypeReport', N'Report', N'Báo cáo', N'TemplateTypeReport', N'TemplateType', '1');
GO

DELETE FROM ADConfigValues where ADConfigKeyGroup = 'ParamMode' and ADConfigKey = 'ParamModeReport'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'ParamModeReport', N'Report', N'Báo cáo', N'ParamModeReport', N'ParamMode', '1');
GO
--select * from ADConfigValues where ADConfigKeyGroup like '%ParamMode%'

DELETE FROM ADConfigValues where ADConfigKeyGroup = 'EmrSumStatus' and ADConfigKey = 'EmrSumStatusHide'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'EmrSumStatusHide', N'Hide', N'Ẩn', N'EmrSumStatusHide', N'EmrSumStatus', '1');
GO

DELETE FROM ADConfigValues where ADConfigKeyGroup = 'EmrSumStatus' and ADConfigKey = 'EmrSumStatusActive'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'EmrSumStatusActive', N'Active', N'Hiệu lực', N'EmrSumStatusActive', N'EmrSumStatus', '1');
GO

DELETE FROM ADConfigValues where ADConfigKeyGroup = 'EmrSumXMLStatus' and ADConfigKey = 'EmrSumXMLStatusNone'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'EmrSumXMLStatusNone', N'None', N'Chưa xuất', N'EmrSumXMLStatusNone', N'EmrSumXMLStatus', '1');
GO

DELETE FROM ADConfigValues where ADConfigKeyGroup = 'EmrSumXMLStatus' and ADConfigKey = 'EmrSumXMLStatusExported'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'EmrSumXMLStatusExported', N'Exported', N'Đã xuất', N'EmrSumXMLStatusExported', N'EmrSumXMLStatus', '1');
GO

DELETE FROM ADConfigValues where ADConfigKeyGroup = 'EmrSumXMLStatus' and ADConfigKey = 'EmrSumXMLStatusError'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'EmrSumXMLStatusError', N'Error', N'Lỗi', N'EmrSumXMLStatusError', N'EmrSumXMLStatus', '1');
GO

DELETE FROM ADConfigValues where ADConfigKeyGroup = 'EmrSumXMLStatus' and ADConfigKey = 'EmrSumXMLStatusSent'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'EmrSumXMLStatusSent', N'Sent', N'Đã gửi', N'EmrSumXMLStatusSent', N'EmrSumXMLStatus', '1');
GO

DELETE FROM ADConfigValues where ADConfigKeyGroup = 'EmrSumXMLStatus' and ADConfigKey = 'EmrSumXMLStatusFail'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'EmrSumXMLStatusFail', N'Fail', N'Gửi lỗi', N'EmrSumXMLStatusFail', N'EmrSumXMLStatus', '1');
GO
DELETE FROM ADConfigValues where ADConfigKeyGroup = 'EmrActionScope' and ADConfigKey = 'MEEmrActionScopeDocumentBeforeSaving'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'MEEmrActionScopeDocumentBeforeSaving', N'DocumentBeforeSaving', N'Tập tin BA trước khi lưu', null, N'EmrActionScope', '1');
GO


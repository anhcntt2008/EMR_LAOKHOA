DELETE FROM ADConfigValues where ADConfigKeyGroup = 'TemplateParamSignAsGroup' and ADConfigKey = 'TemplateParamSignAsGroup01'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'TemplateParamSignAsGroup01', N'G1', N'Cụm 01', NULL, N'TemplateParamSignAsGroup', '1');
GO

DELETE FROM ADConfigValues where ADConfigKeyGroup = 'TemplateParamSignAsGroup' and ADConfigKey = 'TemplateParamSignAsGroup02'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'TemplateParamSignAsGroup02', N'G2', N'Cụm 02', NULL, N'TemplateParamSignAsGroup', '1');
GO

DELETE FROM ADConfigValues where ADConfigKeyGroup = 'TemplateParamSignAsGroup' and ADConfigKey = 'TemplateParamSignAsGroup03'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'TemplateParamSignAsGroup03', N'G3', N'Cụm 03', NULL, N'TemplateParamSignAsGroup', '1');
GO

DELETE FROM ADConfigValues where ADConfigKeyGroup = 'TemplateParamSignAsGroup' and ADConfigKey = 'TemplateParamSignAsGroup04'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'TemplateParamSignAsGroup04', N'G4', N'Cụm 04', NULL, N'TemplateParamSignAsGroup', '1');
GO

DELETE FROM ADConfigValues where ADConfigKeyGroup = 'TemplateParamSignAsGroup' and ADConfigKey = 'TemplateParamSignAsGroup05'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'TemplateParamSignAsGroup05', N'G5', N'Cụm 05', NULL, N'TemplateParamSignAsGroup', '1');
GO

DELETE FROM ADConfigValues where ADConfigKeyGroup = 'TemplateParamSignAsGroup' and ADConfigKey = 'TemplateParamSignAsGroup06'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'TemplateParamSignAsGroup06', N'G6', N'Cụm 06', NULL, N'TemplateParamSignAsGroup', '1');
GO

DELETE FROM ADConfigValues where ADConfigKeyGroup = 'TemplateParamSignAsGroup' and ADConfigKey = 'TemplateParamSignAsGroup07'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'TemplateParamSignAsGroup07', N'G7', N'Cụm 07', NULL, N'TemplateParamSignAsGroup', '1');
GO

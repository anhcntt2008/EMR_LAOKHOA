DELETE FROM ADConfigValues where ADConfigKeyGroup = 'CompanyCaProvider' and ADConfigKey = 'CSCompanyCaProviderVNPT'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'CSCompanyCaProviderVNPT', N'VNPT_CA', N'VNPT-CA', N'', N'CompanyCaProvider', '1');
GO
DELETE FROM ADConfigValues where ADConfigKeyGroup = 'EmrPatientGroup' and ADConfigKey = 'EmrPatientGroupBHYT'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'EmrPatientGroupBHYT', N'BHYT', N'BHYT', NULL, N'EmrPatientGroup', '1');
GO

DELETE FROM ADConfigValues where ADConfigKeyGroup = 'EmrPatientGroup' and ADConfigKey = 'EmrPatientGroupFee'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'EmrPatientGroupFee', N'Thu phí', N'Thu phí', NULL, N'EmrPatientGroup', '1');
GO

DELETE FROM ADConfigValues where ADConfigKeyGroup = 'EmrPatientGroup' and ADConfigKey = 'EmrPatientGroupFree'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'EmrPatientGroupFree', N'Miễn', N'Miễn', NULL, N'EmrPatientGroup', '1');
GO

DELETE FROM ADConfigValues where ADConfigKeyGroup = 'EmrPatientGroup' and ADConfigKey = 'EmrPatientGroupOther'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'EmrPatientGroupOther', N'Khác', N'Khác', NULL, N'EmrPatientGroup', '1');
GO
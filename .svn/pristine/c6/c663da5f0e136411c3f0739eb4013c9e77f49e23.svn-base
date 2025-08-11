DELETE FROM ADConfigValues where ADConfigKeyGroup = 'EmrStatus' and ADConfigKey = 'EmrStatusApproved'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'EmrStatusApproved', N'Approved', N'Duyệt BHYT', N'', N'EmrStatus', '1');
GO

DELETE FROM ADConfigValues where ADConfigKeyGroup = 'EmrStatus' and ADConfigKey = 'EmrStatusWaitApprove'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'EmrStatusWaitApprove', N'WaitApprove', N'Chờ duyệt BHYT', N'', N'EmrStatus', '1');
GO

DELETE FROM ADConfigValues where ADConfigKeyGroup = 'EmrStatus' and ADConfigKey = 'EmrStatusReturn'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'EmrStatusReturn', N'Return', N'Trả hồ sơ', N'', N'EmrStatus', '1');
GO
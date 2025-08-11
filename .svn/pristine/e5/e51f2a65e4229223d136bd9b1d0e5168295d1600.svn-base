DELETE FROM ADConfigValues where ADConfigKeyGroup = 'EmrStatus' and ADConfigKey = 'EmrStatusReturn'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'EmrStatusReturn', N'Return', N'Trả về khoa', NULL, N'EmrStatus', '1');
GO

DELETE FROM ADConfigValues where ADConfigKeyGroup = 'ObjectHistoryAction' and ADConfigKey = 'ObjectHistoryActionToWaitClose'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'ObjectHistoryActionToWaitClose', N'ToWaitClose', N'Chờ đóng bệnh án', NULL, N'ObjectHistoryAction', '1');
GO

DELETE FROM ADConfigValues where ADConfigKeyGroup = 'ObjectHistoryAction' and ADConfigKey = 'ObjectHistoryActionBackToDept'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'ObjectHistoryActionBackToDept', N'BackToDept', N'Trả bệnh án về khoa', NULL, N'ObjectHistoryAction', '1');
GO

DELETE FROM ADConfigValues where ADConfigKeyGroup = 'ObjectHistoryStatus' and ADConfigKey = 'ObjectHistoryStatusReturn'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'ObjectHistoryStatusReturn', N'Return', N'Trả về khoa', NULL, N'ObjectHistoryStatus', '1');
GO

DELETE FROM ADConfigValues where ADConfigKeyGroup = 'ObjectHistoryStatus' and ADConfigKey = 'ObjectHistoryStatusWaitClose'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'ObjectHistoryStatusWaitClose', N'WaitClose', N'Chờ đóng', NULL, N'ObjectHistoryStatus', '1');
GO

--EMR

DELETE FROM ADConfigValues where ADConfigKeyGroup = 'EmrNotifyType' and ADConfigKey = 'EmrNotifyTypeReturn'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'EmrNotifyTypeReturn', N'Return', N'Trả về khoa', NULL, N'EmrNotifyType', '1');
GO
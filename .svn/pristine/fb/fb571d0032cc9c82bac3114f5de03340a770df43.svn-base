GO
DELETE FROM ADConfigValues where ADConfigKeyGroup = 'ObjectHistoryStatus' 
and ADConfigKey in ('ObjectHistoryStatusInProgress','ObjectHistoryStatusInactive','ObjectHistoryStatusNew')
GO
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'ObjectHistoryStatusInProgress', N'InProgress', N'Xử lý', NULL, N'ObjectHistoryStatus', '1');
GO
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'ObjectHistoryStatusInactive', N'Inactive', N'Không hoạt động', NULL, N'ObjectHistoryStatus', '1');
GO
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'ObjectHistoryStatusNew', N'New', N'Mới', NULL, N'ObjectHistoryStatus', '1');
GO
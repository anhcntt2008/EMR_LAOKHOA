DELETE FROM ADConfigValues where ADConfigKeyGroup = 'ObjectHistoryAction' and ADConfigKey = 'ObjectHistoryActionAll'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'ObjectHistoryActionAll', N'', N'Tất cả', N'ObjectHistoryActionAll', N'ObjectHistoryAction', '1');
GO
DELETE FROM ADConfigValues where ADConfigKeyGroup = 'ObjectHistoryAction' and ADConfigKey = 'ObjectHistoryActionChange'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'ObjectHistoryActionChange', N'Change', N'Thay đổi', N'ObjectHistoryActionChange', N'ObjectHistoryAction', '1');
GO
DELETE FROM ADConfigValues where ADConfigKeyGroup = 'ObjectHistoryAction' and ADConfigKey = 'ObjectHistoryActionNew'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'ObjectHistoryActionNew', N'New', N'Mới', NULL, N'ObjectHistoryAction', '1');
GO
DELETE FROM ADConfigValues where ADConfigKeyGroup = 'ObjectHistoryAction' and ADConfigKey = 'ObjectHistoryActionDelete'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'ObjectHistoryActionDelete', N'Delete', N'Xóa', NULL, N'ObjectHistoryAction', '1');
GO
DELETE FROM ADConfigValues where ADConfigKeyGroup = 'ObjectHistoryAction' and ADConfigKey = 'ObjectHistoryActionToWaitClose'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'ObjectHistoryActionToWaitClose', N'ToWaitClose', N'Chờ đóng bệnh án', N'ObjectHistoryActionToWaitClose', N'ObjectHistoryAction', '1');
GO
DELETE FROM ADConfigValues where ADConfigKeyGroup = 'ObjectHistoryAction' and ADConfigKey = 'ObjectHistoryActionBackToDept'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'ObjectHistoryActionBackToDept', N'BackToDept', N'Trả bệnh án về khoa', N'ObjectHistoryActionBackToDept', N'ObjectHistoryAction', '1');
GO
DELETE FROM ADConfigValues where ADConfigKeyGroup = 'ObjectHistoryAction' and ADConfigKey = 'ObjectHistoryActionReOpen'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'ObjectHistoryActionReOpen', N'ReOpen', N'Mở lại', NULL, N'ObjectHistoryAction', '1');
GO
DELETE FROM ADConfigValues where ADConfigKeyGroup = 'ObjectHistoryAction' and ADConfigKey = 'ObjectHistoryActionError'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'ObjectHistoryActionError', N'Error', N'Lỗi', NULL, N'ObjectHistoryAction', '1');
GO

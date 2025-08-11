DELETE FROM ADConfigValues where ADConfigKeyGroup = 'NotificationType' and ADConfigKey = 'NotificationTypeAll'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'NotificationTypeAll', N'All', N'Toàn Viện', NULL, N'NotificationType', '1');
GO
DELETE FROM ADConfigValues where ADConfigKeyGroup = 'NotificationType' and ADConfigKey = 'NotificationTypeDeparment'
DELETE FROM ADConfigValues where ADConfigKeyGroup = 'NotificationType' and ADConfigKey = 'NotificationTypeDepartment'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'NotificationTypeDepartment', N'Department', N'Khoa Phòng', NULL, N'NotificationType', '1');
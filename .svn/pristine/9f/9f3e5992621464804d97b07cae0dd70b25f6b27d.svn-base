DELETE FROM ADConfigValues where ADConfigKeyGroup = 'NotificationType' and ADConfigKey = 'NotificationTypeAll'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'NotificationTypeAll', N'All', N'Toàn Viện', NULL, N'NotificationType', '1');
GO

DELETE FROM ADConfigValues where ADConfigKeyGroup = 'NotificationType' and ADConfigKey = 'NotificationTypeDeparment'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'NotificationTypeDeparment', N'Deparment', N'Khoa Phòng', NULL, N'NotificationType', '1');
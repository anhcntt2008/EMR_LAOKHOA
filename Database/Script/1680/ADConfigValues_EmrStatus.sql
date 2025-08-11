DELETE FROM ADConfigValues where ADConfigKeyGroup = 'EmrStatus' and ADConfigKey = 'EmrStatusWaitClose'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'EmrStatusWaitClose', N'WaitClose', N'Chờ đóng', NULL, N'EmrStatus', '1');

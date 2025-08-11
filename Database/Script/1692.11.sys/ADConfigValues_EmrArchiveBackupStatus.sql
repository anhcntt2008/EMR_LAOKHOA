DELETE FROM ADConfigValues where ADConfigKeyGroup = 'EmrArchiveBackupStatus' and ADConfigKey = 'EmrArchiveBackupStatusSkipped'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'EmrArchiveBackupStatusSkipped', N'Skipped', N'Bỏ qua', NULL, N'EmrArchiveBackupStatus', '1');
GO

DELETE FROM [dbo].[ADConfigValues] where ADConfigKey = 'EmrArchiveStatusArchived' and ADConfigKeyGroup = 'EmrArchiveStatus'
INSERT INTO [dbo].[ADConfigValues] (
	[ADConfigValueID]
	,[AAStatus]
	,[ADConfigKey]
	,[ADConfigKeyValue]
	,[ADConfigText]
	,[ADConfigKeyDesc]
	,[ADConfigKeyGroup]
	,[IsActive]
	)
VALUES (
	(SELECT MAX(ADConfigValueID)+1 FROM [dbo].[ADConfigValues])
	,'Alive'
	,N'EmrArchiveStatusArchived'
	,N'Archived'
	,N'Lưu trữ'
	,NULL
	,N'EmrArchiveStatus'
	,'1'
	);

DELETE FROM [dbo].[ADConfigValues] where ADConfigKey = 'EmrArchiveStatusDigitalSigned' and ADConfigKeyGroup = 'EmrArchiveStatus'
INSERT INTO [dbo].[ADConfigValues] (
	[ADConfigValueID]
	,[AAStatus]
	,[ADConfigKey]
	,[ADConfigKeyValue]
	,[ADConfigText]
	,[ADConfigKeyDesc]
	,[ADConfigKeyGroup]
	,[IsActive]
	)
VALUES (
	(SELECT MAX(ADConfigValueID)+1 FROM [dbo].[ADConfigValues])
	,'Alive'
	,N'EmrArchiveStatusDigitalSigned'
	,N'DigitalSigned'
	,N'Ký số CA'
	,NULL
	,N'EmrArchiveStatus'
	,'1'
	);

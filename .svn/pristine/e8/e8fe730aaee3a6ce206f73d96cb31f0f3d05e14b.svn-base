
DELETE FROM [dbo].[ADConfigValues] where ADConfigKey = 'CSCompanyCaProviderBKAV' and ADConfigKeyGroup = 'CompanyCaProvider'
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
	,N'CSCompanyCaProviderBKAV'
	,N'BKAV_CA'
	,N'BKAV-CA'
	,NULL
	,N'CompanyCaProvider'
	,'1'
	);


DELETE FROM [dbo].[ADConfigValues] where ADConfigKey = 'CSCompanyCaProviderESIGN' and ADConfigKeyGroup = 'CompanyCaProvider'
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
	,N'CSCompanyCaProviderESIGN'
	,N'ESIGN_CA'
	,N'eSign-CA'
	,NULL
	,N'CompanyCaProvider'
	,'1'
	);

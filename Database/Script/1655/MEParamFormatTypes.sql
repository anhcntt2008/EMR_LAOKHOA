
DELETE FROM [dbo].[ADConfigValues] where ADConfigKey = 'MEParamFormatTypeRtf' and ADConfigKeyGroup = 'ParamFormatType'
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
	,N'MEParamFormatTypeRtf'
	,N'Rtf'
	,N'Rtf'
	,NULL
	,N'ParamFormatType'
	,'1'
	);

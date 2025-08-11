
DELETE FROM [dbo].[ADConfigValues] where ADConfigKey = 'MEParamFormatTypeImage' and ADConfigKeyGroup = 'ParamFormatType'
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
	,N'MEParamFormatTypeImage'
	,N'Image'
	,N'Hình ảnh'
	,NULL
	,N'ParamFormatType'
	,'1'
	);

DELETE FROM [dbo].[ADConfigValues] where ADConfigKey = 'MEParamFormatTypeImageRotate90' and ADConfigKeyGroup = 'ParamFormatType'
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
	,N'MEParamFormatTypeImageRotate90'
	,N'ImageRotate90'
	,N'Hình ảnh xoay 90 độ'
	,NULL
	,N'ParamFormatType'
	,'1'
	);

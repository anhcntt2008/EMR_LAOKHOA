DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'SYSTEM_CONFIGS'
	AND [ADSystemConfigKey] = 'MAX_STUCK_AT_INITING_STATE_INTERVAL'

INSERT INTO [dbo].[ADSystemConfigs] (
	[ADSystemConfigID]
	,[AAStatus]
	,[IsActive]
	,[ADSystemConfigGroup]
	,[ADSystemConfigKey]
	,[ADSystemConfigValue]
	,[ADSystemConfigText]
	,[ADSystemConfigDesc]
	)
VALUES (
	(
		SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1
		FROM [dbo].[ADSystemConfigs]
		)
	,'Alive'
	,'1'
	,'SYSTEM_CONFIGS'
	,'MAX_STUCK_AT_INITING_STATE_INTERVAL'
	,N'15'
	,N'Đơn vị phút. Giá trị 0: tắt tính năng. Mặc định 15 phút'
	,N'Đơn vị phút. Giá trị 0: tắt tính năng. Mặc định 15 phút'
	);
GO

DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'SYSTEM_CONFIGS'
	AND [ADSystemConfigKey] = 'SYSTEM_CONFIGS_FTP_CONNECT_TIMEOUT'

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
	,'SYSTEM_CONFIGS_FTP_CONNECT_TIMEOUT'
	,N'15000'
	,N'Time to wait (in milliseconds) for a connection attempt to succeed, before giving up. Default: 15000 (15 seconds)'
	,N'Time to wait (in milliseconds) for a connection attempt to succeed, before giving up. Default: 15000 (15 seconds)'
	);
GO

DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'SYSTEM_CONFIGS'
	AND [ADSystemConfigKey] = 'SYSTEM_CONFIGS_FTP_READ_TIMEOUT'

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
	,'SYSTEM_CONFIGS_FTP_READ_TIMEOUT'
	,N'15000'
	,N'Time to wait (in milliseconds) for data to be read from the underlying stream, before giving up. Honored by all asynchronous methods as well. Default: 15000 (15 seconds)'
	,N'Time to wait (in milliseconds) for data to be read from the underlying stream, before giving up. Honored by all asynchronous methods as well. Default: 15000 (15 seconds)'
	);

GO
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'SYSTEM_CONFIGS'
	AND [ADSystemConfigKey] = 'SYSTEM_CONFIGS_FTP_DATACONNECTIONCONNECT_TIMEOUT'

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
	,'SYSTEM_CONFIGS_FTP_DATACONNECTIONCONNECT_TIMEOUT'
	,N'15000'
	,N'Time to wait (in milliseconds) for a data connection to be established, before giving up. Default: 15000 (15 seconds)'
	,N'Time to wait (in milliseconds) for a data connection to be established, before giving up. Default: 15000 (15 seconds)'
	);

GO
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'SYSTEM_CONFIGS'
	AND [ADSystemConfigKey] = 'SYSTEM_CONFIGS_FTP_DATACONNECTIONREAD_TIMEOUT'

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
	,'SYSTEM_CONFIGS_FTP_DATACONNECTIONREAD_TIMEOUT'
	,N'15000'
	,N'Time to wait (in milliseconds) for the server to send data on the data channel, before giving up. Default: 15000 (15 seconds)'
	,N'Time to wait (in milliseconds) for the server to send data on the data channel, before giving up. Default: 15000 (15 seconds)'
	);
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'MONGO_HOST'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'MONGO_HOST', N'vrnejW7iFQ/EuicMh7IAmQ==', N'mongo host', N'mongo host');
GO

DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'MONGO_PORT'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'MONGO_PORT', N'DlH23KQqAGQ=', N'mongo port', N'mongo port');
GO

DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'MONGO_USER'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'MONGO_USER', N'XgtQTlEfjpc=', N'mongo user', N'mongo user');
GO

DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'MONGO_PW'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'MONGO_PW', N'By9NkKk8X5w=', N'mongo pw', N'mongo pw');
GO

DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'MONGO_AUTH_SOURCE'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'MONGO_AUTH_SOURCE', N'XgtQTlEfjpc=', N'mongo auth source', N'mongo auth source');
GO

DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'MONGO_DB'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'MONGO_DB', N'XgtQTlEfjpc=', N'mongo db', N'mongo db');
GO

DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'SYSTEM_CONFIGS' AND [ADSystemConfigKey] = 'SYSTEM_CONFIGS_FTP_HOST'
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'SYSTEM_CONFIGS' AND [ADSystemConfigKey] = 'SYSTEM_CONFIGS_FTP_PORT'
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'SYSTEM_CONFIGS' AND [ADSystemConfigKey] = 'SYSTEM_CONFIGS_FTP_USER'
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'SYSTEM_CONFIGS' AND [ADSystemConfigKey] = 'SYSTEM_CONFIGS_FTP_PASSWORD'
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'SYSTEM_CONFIGS' AND [ADSystemConfigKey] = 'SYSTEM_CONFIGS_FTP_ROOT_PATH'
GO
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'FTP_HOST'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'FTP_HOST', N'vrnejW7iFQ/EuicMh7IAmQ==', '', '');
GO

DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'FTP_PORT'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'FTP_PORT', N'jnFLpvlpPAk=', '', '');
GO

DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'FTP_USER'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'FTP_USER', N'kYoV3dBtqGU=', '', '');
GO

DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'FTP_PASSWORD'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'FTP_PASSWORD', N'aoHcGUSmbic=', '', '');
GO

DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'FTP_ROOT_PATH'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'FTP_ROOT_PATH', N'EVdz9P///s1gunJ6ake/YJlRiEPDInG3', '', '');
GO

DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'FTP_APP_DIR'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'FTP_APP_DIR', N'EQ8YyyqLdO4=', '', '');
GO
--
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'FTP_REPORT_DIR'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'FTP_REPORT_DIR', N'QbaBszJPw78=', '', '');
GO

DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'FTP_CONNECT_TIMEOUT'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'FTP_CONNECT_TIMEOUT', N'1500', '', '');
GO
--
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'FTP_READ_TIMEOUT'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'FTP_READ_TIMEOUT', N'1500', '', '');
GO

DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'FTP_DATACONNECTIONCONNECT_TIMEOUT'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'FTP_DATACONNECTIONCONNECT_TIMEOUT', N'1500', '', '');
GO

DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'FTP_DATACONNECTIONREAD_TIMEOUT'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'FTP_DATACONNECTIONREAD_TIMEOUT', N'1500', '', '');
GO

------------------ MOVE ALL ---------------------
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'COMPANY_NAME'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'COMPANY_NAME', N'CLAS HEALTHCARE', '', '');
GO

--CSCompanyID
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'CS_COMPANY_ID'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'CS_COMPANY_ID', N'1', '', '');
GO

--TemplateServerPath
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'TEMPLATE_SERVER_PATH'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'TEMPLATE_SERVER_PATH', N'Templates', '', '');
GO

--DOCTOR_24X7_HOST
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'DOCTOR_24X7_HOST'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'DOCTOR_24X7_HOST', N'https://healthcare.clas.mobi:8445/clas-healthcare-v2/', '', '');
GO

--drug_info_host
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'DRUG_INFO_HOST'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'DRUG_INFO_HOST', N'https://thongtinthuoc.com:8443/', '', '');
GO

--drug_info_token
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'PRIVATE_DRUG_INFO_TOKEN'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'PRIVATE_DRUG_INFO_TOKEN', '', '', '');
GO

--drug_info_owner_id
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'DRUG_INFO_OWNER_ID'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'DRUG_INFO_OWNER_ID', '', '', '');
GO

--emr_send_to_channel
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'EMR_SEND_TO_CHANNEL'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'EMR_SEND_TO_CHANNEL', '', '', '');
GO

--emr_receive_channel
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'EMR_RECEIVE_CHANNEL'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'EMR_RECEIVE_CHANNEL', '', '', '');
GO

--his_api_endpoint
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'HIS_API_ENDPOINT'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'HIS_API_ENDPOINT', N'http://api.hl7.vn:56196/api', '', '');
GO

--his_api_token
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'HIS_API_TOKEN'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'HIS_API_TOKEN', N'7628cbf6_70a6_d82a_a024_dc5b775ab799', '', '');
GO

--his-api-login
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'HIS_API_LOGIN'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'HIS_API_LOGIN', '', N'empty for login local', N'empty for login local');
GO

--his-sp-login
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'HIS_SP_LOGIN'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'HIS_SP_LOGIN', '', N'empty for login local', N'empty for login local');
GO

--his-db-type
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'HIS_DB_TYPE'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'HIS_DB_TYPE', N'MSSQL', N'ORA for Oracle or MSSQL for SQL server', N'HIS SQL CONNECTION FOR EMR');
GO

--his-db-server
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'HIS_DB_SERVER'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'HIS_DB_SERVER', N'vrnejW7iFQ/EuicMh7IAmQ==', '', '');
GO

--HIS_DB_PORT
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'HIS_DB_PORT'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'HIS_DB_PORT', N'1433', '', '');
GO
--HIS_DB_PROTOCOL
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'HIS_DB_PROTOCOL'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'HIS_DB_PROTOCOL', N'tcp', '', '');
GO
--HIS_DB_NAME
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'HIS_DB_NAME'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'HIS_DB_NAME', N'Me9ciHcMoaPGiYhXJFR2xw==', '', '');
GO
--HIS_DB_USER
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'HIS_DB_USER'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'HIS_DB_USER', N'qF8yeSOSbwI=', '', '');
GO
--HIS_DB_PASSWORD
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'HIS_DB_PASSWORD'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'HIS_DB_PASSWORD', N'aoHcGUSmbic=', '', '');
GO
--HIS_DB_LOWERCASE
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'HIS_DB_LOWERCASE'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'HIS_DB_LOWERCASE', N'true', '', '');
GO
--CACHE_PLUGINS
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'CACHE_PLUGINS'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'CACHE_PLUGINS', N'false', '', '');
GO
--RC_API_ENDPOINT
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'RC_API_ENDPOINT'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'RC_API_ENDPOINT', N'https://medcubes.clas.mobi', '', '');
GO
--RC_CUSTOMER_ID
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'RC_CUSTOMER_ID'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'RC_CUSTOMER_ID', N'1', '', '');
GO
--RC_TENAN_ID
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'RC_TENAN_ID'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'RC_TENAN_ID', N'1', '', '');
GO
--BLOCK_WRITE_URL
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'BLOCK_WRITE_URL'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'BLOCK_WRITE_URL', N'', '', '');
GO
--BLOCK_VERIFY_URL
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'BLOCK_VERIFY_URL'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'BLOCK_VERIFY_URL', N'', '', '');
GO
--HASH_ALGORITHM
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'HASH_ALGORITHM'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'HASH_ALGORITHM', N'SHA-512', '', '');
GO
--USE_MESSAGE_BOX_FOR_ALERT
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'USE_MESSAGE_BOX_FOR_ALERT'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'USE_MESSAGE_BOX_FOR_ALERT', N'false', '', '');
GO
--SIGNAL_HUB
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'SIGNAL_HUB'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'SIGNAL_HUB', N'http://localhost:64734/', '', '');
GO
--ALLOW_MULTI_PROCESS
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'ALLOW_MULTI_PROCESS'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'ALLOW_MULTI_PROCESS', N'true', '', '');
GO
--
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'ALLOW_CHECK_SYSTEM'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'ALLOW_CHECK_SYSTEM', N'true', '', '');
GO
--CHECK_MEMORY
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'CHECK_MEMORY'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'CHECK_MEMORY', N'true', '', '');
GO
--FREE_MEMORY_THREAD
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'FREE_MEMORY_THREAD'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'FREE_MEMORY_THREAD', N'512', '', '');
GO

--EMR_API_ENDPOINT
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'EMR_API_ENDPOINT'
GO
DECLARE @ADSystemConfigValue NVARCHAR(512) = (select ADSystemConfigValue from ADSystemConfigs where ADSystemConfigGroup='API_ENDPOINTS' AND ADSystemConfigKey='EMR_API_ENDPOINT')
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'EMR_API_ENDPOINT', @ADSystemConfigValue, '', '');
GO
--EMR_API_ENDPOINT
DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'EMR_API_ENDPOINT_TIMEOUT'
GO
DECLARE @ADSystemConfigValue NVARCHAR(512) = (select ADSystemConfigValue from ADSystemConfigs where ADSystemConfigGroup='API_ENDPOINTS' AND ADSystemConfigKey='EMR_API_ENDPOINT_TIMEOUT')
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'EMR_API_ENDPOINT_TIMEOUT', @ADSystemConfigValue, '', '');
GO
DELETE FROM [dbo].[ADSystemConfigs] WHERE [ADSystemConfigGroup] = 'API_ENDPOINTS'
GO
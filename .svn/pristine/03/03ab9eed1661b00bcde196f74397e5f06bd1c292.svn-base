ALTER TABLE MEEmrDocuments ADD [MEEmrDocumentHoldMachineMac] [varchar] (20) NULL
ALTER TABLE MEEmrDocuments ADD [MEEmrDocumentHoldMachineIp] [varchar] (50) NULL


DELETE
FROM [dbo].[AAColumnAlias]
WHERE AATableName = 'MEEmrDocuments'
	AND AAColumnAliasName = 'FK_EditingUserID'
DELETE
FROM [dbo].[AAColumnAlias]
WHERE AATableName = 'MEEmrDocuments'
	AND AAColumnAliasName = 'MEEmrDocumentHoldMachineMac'
	DELETE
FROM [dbo].[AAColumnAlias]
WHERE AATableName = 'MEEmrDocuments'
	AND AAColumnAliasName = 'MEEmrDocumentHoldMachineIp'

INSERT INTO [dbo].[AAColumnAlias]
VALUES (
	(
		SELECT MAX([AAColumnAliasID]) + 1
		FROM [dbo].[AAColumnAlias]
		)
	,0
	,''
	,'Alive'
	,N'FK_EditingUserID'
	,N'Đang sửa bởi'
	,'MEEmrDocuments'
	);
GO
INSERT INTO [dbo].[AAColumnAlias]
VALUES (
	(
		SELECT MAX([AAColumnAliasID]) + 1
		FROM [dbo].[AAColumnAlias]
		)
	,0
	,''
	,'Alive'
	,N'MEEmrDocumentHoldMachineMac'
	,N'Đang sửa bởi (MAC)'
	,'MEEmrDocuments'
	);
GO

INSERT INTO [dbo].[AAColumnAlias]
VALUES (
	(
		SELECT MAX([AAColumnAliasID]) + 1
		FROM [dbo].[AAColumnAlias]
		)
	,0
	,''
	,'Alive'
	,N'MEEmrDocumentHoldMachineIp'
	,N'Đang sửa bởi (IP/PC)'
	,'MEEmrDocuments'
	);
GO

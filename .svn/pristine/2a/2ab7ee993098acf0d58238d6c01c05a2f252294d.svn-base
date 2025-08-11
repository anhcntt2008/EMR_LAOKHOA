ALTER TABLE MEEmrDocuments ADD [MEEmrDocumentPreStatus] [varchar] (50) NULL

DELETE
FROM [dbo].[AAColumnAlias]
WHERE AATableName = 'MEEmrDocuments'
	AND AAColumnAliasName = 'MEEmrDocumentPreStatus'

INSERT INTO [dbo].[AAColumnAlias]
VALUES (
	(
		SELECT MAX([AAColumnAliasID]) + 1
		FROM [dbo].[AAColumnAlias]
		)
	,0
	,''
	,'Alive'
	,N'MEEmrDocumentPreStatus'
	,N'Trạng thái trước'
	,'MEEmrDocuments'
	);
GO

-- EmrDocumentPreStatus [ADConfigValues]
DELETE
FROM [dbo].[ADConfigValues]
WHERE [ADConfigKeyGroup] = 'EmrDocumentPreStatus'

INSERT INTO [dbo].[ADConfigValues]
VALUES (
	(
		SELECT MAX([ADConfigValueID]) + 1
		FROM [dbo].[ADConfigValues]
		)
	,'Alive'
	,N'EmrDocumentPreStatusInProgress'
	,N'InProgress'
	,N'Đang nhập'
	,NULL
	,N'EmrDocumentPreStatus'
	,'1'
	);

INSERT INTO [dbo].[ADConfigValues]
VALUES (
	(
		SELECT MAX([ADConfigValueID]) + 1
		FROM [dbo].[ADConfigValues]
		)
	,'Alive'
	,N'EmrDocumentPreStatusSigned'
	,N'Signed'
	,N'Đã ký'
	,NULL
	,N'EmrDocumentPreStatus'
	,'1'
	);

INSERT INTO [dbo].[ADConfigValues]
VALUES (
	(
		SELECT MAX([ADConfigValueID]) + 1
		FROM [dbo].[ADConfigValues]
		)
	,'Alive'
	,N'EmrDocumentPreStatusClosed'
	,N'Closed'
	,N'Đã đóng'
	,NULL
	,N'EmrDocumentPreStatus'
	,'1'
	);

INSERT INTO [dbo].[ADConfigValues]
VALUES (
	(
		SELECT MAX([ADConfigValueID]) + 1
		FROM [dbo].[ADConfigValues]
		)
	,'Alive'
	,N'EmrDocumentPreStatusHidden'
	,N'Hidden'
	,N'Đã ẩn'
	,NULL
	,N'EmrDocumentPreStatus'
	,'1'
	);

INSERT INTO [dbo].[ADConfigValues]
VALUES (
	(
		SELECT MAX([ADConfigValueID]) + 1
		FROM [dbo].[ADConfigValues]
		)
	,'Alive'
	,N'EmrDocumentPreStatusDiscarded'
	,N'Discarded'
	,N'Đã hủy'
	,NULL
	,N'EmrDocumentPreStatus'
	,'1'
	);

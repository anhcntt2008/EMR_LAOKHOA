
DELETE FROM [ADConfigValues] WHERE ADConfigKey = 'EmrDocumentStatusDiscarded'
INSERT INTO [dbo].[ADConfigValues]
VALUES (
	(
		SELECT MAX([ADConfigValueID]) + 1
		FROM [ADConfigValues]
		)
	,'Alive'
	,N'EmrDocumentStatusDiscarded'
	,N'Discarded'
	,N'Đã hủy'
	,NULL
	,N'EmrDocumentStatus'
	,'1'
	);
DELETE
FROM ADConfigValues
WHERE ADConfigKeyGroup = 'EmrActionType'
	AND ADConfigKey = 'EmrActionTypeOpenWebBrowser'

INSERT INTO [dbo].[ADConfigValues]
VALUES (
	(
		SELECT MAX(ADConfigValueID) + 1
		FROM [ADConfigValues]
		)
	,'Alive'
	,N'EmrActionTypeOpenWebBrowser'
	,N'OpenWebBrowser'
	,N'Mở trình duyệt web'
	,N'Mở trình duyệt web'
	,N'EmrActionType'
	,'1'
	);

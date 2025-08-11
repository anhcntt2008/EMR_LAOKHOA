DELETE
FROM [STModules]
WHERE [STModuleName] = 'MEDocumentManage'

INSERT INTO [dbo].[STModules] (
	[STModuleID]
	,[AAStatus]
	,[STModuleName]
	,[STModuleCode]
	,[STModuleMain]
	,[IsVisible]
	)
VALUES (
	(
		SELECT MAX([STModuleID]) + 1
		FROM [STModules]
		)
	,'Alive'
	,'MEDocumentManage'
	,'MEDocumentManage'
	,0
	,0
	);

DELETE
FROM [STModuleDescriptions]
WHERE [STModuleID] = (
		SELECT TOP 1 [STModuleID]
		FROM [STModules]
		WHERE [STModuleName] = 'MEDocumentManage'
		)

INSERT INTO [dbo].[STModuleDescriptions] (
	[STModuleDescriptionID]
	,[STModuleID]
	,[STLanguageID]
	,[STModuleDescriptionDescription]
	)
VALUES (
	(
		SELECT MAX([STModuleDescriptionID]) + 1
		FROM [STModuleDescriptions]
		)
	,(
		SELECT TOP 1 [STModuleID]
		FROM [STModules]
		WHERE [STModuleName] = 'MEDocumentManage'
		)
	,1
	,N'Quản lý tờ bệnh án'
	);

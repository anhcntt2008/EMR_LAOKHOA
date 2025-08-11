DELETE
FROM [STModules]
WHERE [STModuleName] = 'MEDocumentBackground'

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
	,'MEDocumentBackground'
	,'MEDocumentBackground'
	,0
	,0
	);

GO
DELETE
FROM [STModuleDescriptions]
WHERE [STModuleID] = (
		SELECT TOP 1 [STModuleID]
		FROM [STModules]
		WHERE [STModuleName] = 'MEDocumentBackground'
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
		WHERE [STModuleName] = 'MEDocumentBackground'
		)
	,1
	,N'Quản lý tác vụ tạo ngầm'
	);

DELETE
FROM [STModules]
WHERE [STModuleName] = 'MENotification'

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
	,'MENotification'
	,'MENotification'
	,0
	,0
	);

DELETE
FROM [STModuleDescriptions]
WHERE [STModuleID] = (
		SELECT TOP 1 [STModuleID]
		FROM [STModules]
		WHERE [STModuleName] = 'MENotification'
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
		WHERE [STModuleName] = 'MENotification'
		)
	,1
	,N'Danh mục bảng tin'
	);

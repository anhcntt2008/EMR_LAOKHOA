DELETE
FROM [STModules]
WHERE [STModuleName] = 'MEEmrStore'

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
	,'MEEmrStore'
	,'MEEmrStore'
	,0
	,0
	);

GO
DELETE
FROM [STModuleDescriptions]
WHERE [STModuleID] = (
		SELECT TOP 1 [STModuleID]
		FROM [STModules]
		WHERE [STModuleName] = 'MEEmrStore'
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
		WHERE [STModuleName] = 'MEEmrStore'
		)
	,1
	,N'Lưu trữ dự phòng bệnh án'
	);

DELETE
FROM [dbo].[STToolbarFunctions]
WHERE STToolbarFunctionName = 'UpdateEmrStore'
	AND STToolbarFunctionClass = 'BOSERP.Modules.MEEmrStore.MEEmrStoreModule'

DELETE
FROM [dbo].[STToolbars]
WHERE STToolbarName = 'fld_barbtnEmrStoreUpdate'

INSERT INTO [dbo].[STToolbars]
VALUES (
	(
		SELECT MAX(STToolbarID) + 1
		FROM [STToolbars]
		)
	,'Alive'
	,(
		SELECT TOP 1 [STModuleID]
		FROM [STModules]
		WHERE [STModuleName] = 'MEEmrStore'
		)
	,1
	,N'fld_barbtnEmrStoreUpdate'
	,N''
	,'EmrStoreUpdate'
	,'Default'
	,N'Lên lịch lưu trữ'
	,N'Action'
	,11
	,'0'
	,N''
	,0
	,N'images/scheduling/time_16x16.png'
	);

INSERT INTO [dbo].[STToolbarFunctions]
VALUES (
	(
		SELECT MAX(STToolbarFunctionID) + 1
		FROM [STToolbarFunctions]
		)
	,'0'
	,(
		SELECT STToolbarID
		FROM [STToolbars]
		WHERE STToolbarName = 'fld_barbtnEmrStoreUpdate'
		)
	,'UpdateEmrStore'
	,'Void UpdateEmrStore()'
	,'BOSERP.Modules.MEEmrStore.MEEmrStoreModule'
	,1
	);
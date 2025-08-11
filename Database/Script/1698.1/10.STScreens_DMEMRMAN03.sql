DELETE
FROM [STScreens]
WHERE [STScreenNumber] = 'DMEMRMAN03'

INSERT INTO [dbo].[STScreens] (
	[STScreenID]
	,[STScreenNumber]
	,[STScreenText]
	,[STScreenName]
	,[STModuleID]
	,[STUserGroupID]
	,[STScreenBackColor]
	,[STScreenForeColor]
	,[STScreenFontName]
	,[STScreenFontSize]
	,[STScreenFontStyle]
	,[STScreenTag]
	,[STScreenSizeWidth]
	,[STScreenSizeHeight]
	,[STScreenLocationX]
	,[STScreenLocationY]
	,[STScreenShowModal]
	,[STScreenTopMost]
	,[STScreenMatchCode01]
	,[STScreenShowInfoPanel]
	,[STScreenSortOrder]
	,[STScreenPrivilege]
	,[STScreenVisible]
	)
VALUES (
	(
		SELECT MAX([STScreenID]) + 1
		FROM [STScreens]
		)
	,'DMEMRMAN03'
	,N'Tóm tắt bệnh án'
	,'DMEMRMAN03'
	,(
		SELECT TOP 1 [STModuleID]
		FROM [STModules]
		WHERE [STModuleName] = 'MEEmrManage'
		)
	,1
	,- 526863
	,- 16777216
	,N'Tahoma'
	,8.250000000000000
	,'Regular'
	,'DM'
	,0
	,0
	,0
	,0
	,'1'
	,'1'
	,NULL
	,'0'
	,0
	,NULL
	,'1'
	);
GO
UPDATE [STScreens] SET STScreenSortOrder=3 
WHERE STModuleID=(SELECT TOP 1 [STModuleID] FROM [STModules] WHERE [STModuleName] = 'MEEmrManage')
AND STScreenNumber = 'DMEMRMAN99'
UPDATE [STScreens] SET STScreenSortOrder=2 
WHERE STModuleID=(SELECT TOP 1 [STModuleID] FROM [STModules] WHERE [STModuleName] = 'MEEmrManage')
AND STScreenNumber = 'DMEMRMAN03'

DELETE
FROM [STScreens]
WHERE [STScreenNumber] = 'DMEMRDOCBGSIGN02'

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
	,'DMEMRDOCBGSIGN02'
	,N'Ký tờ bệnh án'
	,'DMEMRDOCBGSIGN02'
	,(
		SELECT TOP 1 [STModuleID]
		FROM [STModules]
		WHERE [STModuleName] = 'MEDocumentBackground'
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

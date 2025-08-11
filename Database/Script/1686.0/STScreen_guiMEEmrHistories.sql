-- SELECT * FROM [STScreens] WHERE STScreenNumber like '%DMMEEMR10%'

DELETE FROM [dbo].[STScreens] where [STScreenNumber] = 'DMMEEMR103'
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
	(SELECT MAX(STScreenID)+1 FROM [dbo].[STScreens])
	,'DMMEEMR103'
	,N'Lịch sử'
	,'guiMEEmrHistories'
	,2221
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

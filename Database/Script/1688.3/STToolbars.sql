GO
DELETE
FROM [dbo].[STToolbarFunctions]
WHERE STToolbarFunctionName = 'GroupArchiveEmrs'
	AND STToolbarFunctionClass = 'BOSERP.Modules.MEEmrManage.MEEmrManageModule'

DELETE
FROM [dbo].[STToolbars]
WHERE STToolbarName = 'fld_barbtnEmrManageGroupArchiveEmrs'
	AND STModuleID = 2273

INSERT INTO [dbo].[STToolbars]
VALUES (
	(
		SELECT MAX(STToolbarID) + 1
		FROM [STToolbars]
		)
	,'Alive'
	,2273
	,1
	,N'fld_barbtnEmrManageGroupArchiveEmrs'
	,N''
	,'EmrManageGroupArchiveEmrs'
	,'Default'
	,N'Tổng hợp bệnh án'
	,N'Action'
	,11
	,'0'
	,N''
	,0
	,N'images/actions/group2_16x16.png'
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
		WHERE STToolbarName = 'fld_barbtnEmrManageGroupArchiveEmrs'
		)
	,'GroupArchiveEmrs'
	,'Void GroupArchiveEmrs()'
	,'BOSERP.Modules.MEEmrManage.MEEmrManageModule'
	,1
	);

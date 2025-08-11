INSERT INTO [dbo].[STToolbars] (
	[STToolbarID]
	,[AAStatus]
	,[STModuleID]
	,[STUserGroupID]
	,[STToolbarName]
	,[STToolbarDesc]
	,[STToolbarTag]
	,[STToolbarStyle]
	,[STToolbarCaption]
	,[STToolbarGroup]
	,[STToolbarOrder]
	,[STToolbarVisible]
	,[STToolbarPrivilege]
	,[STToolbarParentID]
	,[STToolbarImage]
	)
VALUES (
		(
		SELECT MAX(STToolbarID) + 1
		FROM [STToolbars]
		)
	,'Alive'
	,13
	,1
	,N'fld_barbtnNew'
	,N'Tạo mới'
	,'New'
	,'Check'
	,N'Tạo mới (F4)'
	,N'Action'
	,0
	,'1'
	,N''
	,0
	,N''
	);

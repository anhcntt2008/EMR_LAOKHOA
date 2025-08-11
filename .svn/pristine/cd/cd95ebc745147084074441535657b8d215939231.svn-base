ALTER TABLE ADUserGroups ADD ADUserGroupEmrView varchar(100)
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive',N'ADUserGroupEmrView',N'Quyền xem bệnh án','ADUserGroups');
GO

ALTER TABLE ADUsers ADD ADUserEmrView varchar(100)
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive',N'ADUserEmrView',N'Quyền xem bệnh án','ADUsers');
GO

INSERT INTO [dbo].[ADConfigValues] VALUES ((SELECT MAX([ADConfigValueID])+1 FROM [ADConfigValues]), 'Alive', N'UserGroupEmrViewAll', N'All', N'Toàn bộ', NULL, N'UserGroupEmrView', '1');
INSERT INTO [dbo].[ADConfigValues] VALUES ((SELECT MAX([ADConfigValueID])+1 FROM [ADConfigValues]), 'Alive', N'UserGroupEmrViewDepartment', N'Department', N'Theo khoa', NULL, N'UserGroupEmrView', '1');

INSERT INTO [dbo].[ADConfigValues] VALUES ((SELECT MAX([ADConfigValueID])+1 FROM [ADConfigValues]), 'Alive', N'UserEmrViewAll', N'All', N'Toàn bộ', NULL, N'UserEmrView', '1');
INSERT INTO [dbo].[ADConfigValues] VALUES ((SELECT MAX([ADConfigValueID])+1 FROM [ADConfigValues]), 'Alive', N'UserEmrViewDepartment', N'Department', N'Theo khoa', NULL, N'UserEmrView', '1');

INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive',N'FK_HRDepartmentID',N'Khoa','HREmpWorkingDepts');
GO
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive',N'FK_HREmployeeID',N'Nhân viên','HREmpWorkingDepts');
GO
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive',N'HREmpWorkingDeptFrom',N'Làm việc từ ngày','HREmpWorkingDepts');
GO
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive',N'HREmpWorkingDeptRemark',N'Ghi chú','HREmpWorkingDepts');
GO
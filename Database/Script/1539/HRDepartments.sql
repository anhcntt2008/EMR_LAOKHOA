ALTER TABLE HRDepartments ADD HRDepartmentAbbrev nvarchar(100)

INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias])
,0,'','Alive',N'HRDepartmentAbbrev',N'Tên tắt','HRDepartments');
GO

ALTER TABLE HRDepartments ADD HRDepartmentAutoShareAfterTranf float

INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias])
,0,'','Alive',N'HRDepartmentAutoShareAfterTranf',N'Tự chia sẻ sau chuyển','HRDepartments');
GO


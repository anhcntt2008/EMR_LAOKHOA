ALTER TABLE [dbo].[HRDepartments] ADD [HRDepartmentEmrShared] bit
INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'HRDepartmentEmrShared', N'Chia sẻ bệnh án', 'HRDepartments');
GO
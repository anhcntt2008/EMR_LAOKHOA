ALTER TABLE [dbo].[HREmployees] ADD [HREmployeeSignature] [varbinary](max) NULL
GO

INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'HREmployeeSignature', N'Chữ ký', 'HREmployees');
GO
ALTER TABLE [dbo].[HREmployees] ADD [HREmployeeShortSignature] nvarchar(200) NULL
GO

INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'HREmployeeShortSignature', N'Chữ ký viết tắt', 'HREmployees');
GO



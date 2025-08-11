ALTER TABLE [dbo].[MEEmrDocuments] ADD [FK_HRDepartmentID] int null;
GO
INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'FK_HRDepartmentID', N'Khoa tạo', 'MEEmrDocuments');
GO


ALTER TABLE [dbo].[MEEmrDocuments]  WITH CHECK ADD  CONSTRAINT [FK_MEEmrDocument_HRDepartments] FOREIGN KEY([FK_HRDepartmentID])
REFERENCES [dbo].[HRDepartments] ([HRDepartmentID])
GO

ALTER TABLE [dbo].[MEEmrDocuments] CHECK CONSTRAINT [FK_MEEmrDocument_HRDepartments]
GO



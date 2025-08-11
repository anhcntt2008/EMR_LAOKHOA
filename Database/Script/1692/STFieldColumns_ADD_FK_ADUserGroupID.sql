
IF OBJECT_ID('dbo.[STFieldColumns_DF_FK_ADUserGroupID]') IS NOT NULL 
ALTER TABLE [dbo].[STFieldColumns] DROP CONSTRAINT [STFieldColumns_DF_FK_ADUserGroupID]
IF OBJECT_ID('dbo.[FK_STFieldColumns_ADUserGroups]') IS NOT NULL 
ALTER TABLE [dbo].[STFieldColumns] DROP CONSTRAINT [FK_STFieldColumns_ADUserGroups]
IF COL_LENGTH('[dbo].[STFieldColumns]', 'FK_ADUserGroupID') IS NOT NULL
ALTER TABLE [dbo].[STFieldColumns] DROP COLUMN FK_ADUserGroupID
GO

ALTER TABLE [dbo].[STFieldColumns] ADD FK_ADUserGroupID INT
GO
ALTER TABLE [dbo].[STFieldColumns] ADD  CONSTRAINT [STFieldColumns_DF_FK_ADUserGroupID]  DEFAULT ((0)) FOR [FK_ADUserGroupID]
GO
UPDATE [dbo].[STFieldColumns] SET FK_ADUserGroupID = 0 
GO
ALTER TABLE [dbo].[STFieldColumns] ALTER COLUMN FK_ADUserGroupID INT NOT NULL
GO

ALTER TABLE [dbo].[STFieldColumns]  WITH CHECK ADD  CONSTRAINT [FK_STFieldColumns_ADUserGroups] FOREIGN KEY(FK_ADUserGroupID)
REFERENCES [dbo].[ADUserGroups] ([ADUserGroupID])
GO

ALTER TABLE [dbo].[STFieldColumns] CHECK CONSTRAINT [FK_STFieldColumns_ADUserGroups]
GO



IF OBJECT_ID('dbo.[STFieldColumns_DF_FK_ADUserID]') IS NOT NULL 
ALTER TABLE [dbo].[STFieldColumns] DROP CONSTRAINT [STFieldColumns_DF_FK_ADUserID]
IF OBJECT_ID('dbo.[FK_STFieldColumns_ADUsers]') IS NOT NULL 
ALTER TABLE [dbo].[STFieldColumns] DROP CONSTRAINT [FK_STFieldColumns_ADUsers]
IF COL_LENGTH('[dbo].[STFieldColumns]', 'FK_ADUserID') IS NOT NULL
ALTER TABLE [dbo].[STFieldColumns] DROP COLUMN FK_ADUserID
GO

ALTER TABLE [dbo].[STFieldColumns] ADD FK_ADUserID INT
GO

ALTER TABLE [dbo].[STFieldColumns] ADD CONSTRAINT [STFieldColumns_DF_FK_ADUserID] DEFAULT((0))
FOR [FK_ADUserID]
GO

UPDATE [dbo].[STFieldColumns]
SET FK_ADUserID = 0
GO

ALTER TABLE [dbo].[STFieldColumns]

ALTER COLUMN FK_ADUserID INT NOT NULL
GO

ALTER TABLE [dbo].[STFieldColumns]
	WITH CHECK ADD CONSTRAINT [FK_STFieldColumns_ADUsers] FOREIGN KEY (FK_ADUserID) REFERENCES [dbo].[ADUsers]([ADUserID])
GO

ALTER TABLE [dbo].[STFieldColumns] CHECK CONSTRAINT [FK_STFieldColumns_ADUsers]
GO



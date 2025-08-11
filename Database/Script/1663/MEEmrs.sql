-- [FK_HREmployeeClosedID]
ALTER TABLE [dbo].[MEEmrs] ADD [FK_HREmployeeClosedID] INT
GO

ALTER TABLE [dbo].[MEEmrs]
	WITH CHECK ADD CONSTRAINT [FK_MEEmrs_HREmployeeClosed] FOREIGN KEY ([FK_HREmployeeClosedID]) REFERENCES [dbo].[HREmployees]([HREmployeeID])
GO

ALTER TABLE [dbo].[MEEmrs] CHECK CONSTRAINT [FK_MEEmrs_HREmployeeClosed]
GO

------------------------
ALTER TABLE [dbo].[MEEmrs] ADD [MEEmrPatientAddr] NVARCHAR(250)
GO

------------------------
ALTER TABLE [dbo].[MEEmrs] ADD [MEEmrDateIn] DATETIME
GO

------------------------
ALTER TABLE [dbo].[MEEmrs] ADD [MEEmrDateOut] DATETIME
GO

------------------------
ALTER TABLE [dbo].[MEEmrs] ADD [MEEmrRoomNo] NVARCHAR(100)
GO

------------------------
ALTER TABLE [dbo].[MEEmrs] ADD [MEEmrBedNo] NVARCHAR(100)
GO

------------------------
ALTER TABLE [dbo].[MEEmrs] ADD [MEEmrArchiveNo] NVARCHAR(100)
GO

------------------------
UPDATE [dbo].[MEEmrs]
SET [MEEmrDateIn] = '9999-12-31 23:59:59.000'

UPDATE [dbo].[MEEmrs]
SET [MEEmrDateOut] = '9999-12-31 23:59:59.000'

UPDATE [dbo].[MEEmrs]
SET [FK_HREmployeeClosedID] = 0

------------------------
ALTER TABLE [dbo].[MEEmrs]

ALTER COLUMN [MEEmrDateIn] DATETIME NOT NULL
GO

------------------------
ALTER TABLE [dbo].[MEEmrs]

ALTER COLUMN [MEEmrDateOut] DATETIME NOT NULL
GO

------------------------
ALTER TABLE [dbo].[MEEmrs]

ALTER COLUMN [FK_HREmployeeClosedID] INT NOT NULL

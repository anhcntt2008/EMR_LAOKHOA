ALTER TABLE GEObjectHistory DROP COLUMN IF EXISTS GEObjectHistoryRemarkNo
GO
ALTER TABLE GEObjectHistory DROP COLUMN IF EXISTS GEObjectHistoryRemarkValue
GO
ALTER TABLE GEObjectHistory ADD GEObjectHistoryStatus varchar(50) NULL
GO
ALTER TABLE GEObjectHistory ADD FK_HREmployeeFromID INT NULL
GO
ALTER TABLE GEObjectHistory ADD FK_HREmployeeToID INT NULL
GO
ALTER TABLE GEObjectHistory ADD FK_HRDepartmentFromID INT NULL
GO
ALTER TABLE GEObjectHistory ADD FK_HRDepartmentToID INT NULL
GO
ALTER TABLE GEObjectHistory ADD GEObjectHistoryRemark nvarchar(4000) NULL
GO
UPDATE GEObjectHistory SET FK_HREmployeeFromID = 0
UPDATE GEObjectHistory SET FK_HREmployeeToID = 0
UPDATE GEObjectHistory SET FK_HRDepartmentFromID = 0
UPDATE GEObjectHistory SET FK_HRDepartmentToID = 0
GO
ALTER TABLE GEObjectHistory ALTER COLUMN FK_HREmployeeFromID INT NOT NULL
GO
ALTER TABLE GEObjectHistory ALTER COLUMN FK_HREmployeeToID INT NOT NULL
GO
ALTER TABLE GEObjectHistory ALTER COLUMN FK_HRDepartmentFromID INT NOT NULL
GO
ALTER TABLE GEObjectHistory ALTER COLUMN FK_HRDepartmentToID INT NOT NULL
GO
ALTER TABLE GEObjectHistory ADD CONSTRAINT GEObjectHistory_DF_FK_HREmployeeFromID DEFAULT 0 FOR FK_HREmployeeFromID
GO
ALTER TABLE GEObjectHistory ADD CONSTRAINT GEObjectHistory_DF_FK_HREmployeeToID DEFAULT 0 FOR FK_HREmployeeToID;
GO
ALTER TABLE GEObjectHistory ADD CONSTRAINT GEObjectHistory_DF_FK_HRDepartmentFromID DEFAULT 0 FOR FK_HRDepartmentFromID;
GO
ALTER TABLE GEObjectHistory ADD CONSTRAINT GEObjectHistory_DF_FK_HRDepartmentToID DEFAULT 0 FOR FK_HRDepartmentToID;
GO
ALTER TABLE [dbo].[GEObjectHistory]  WITH CHECK ADD  CONSTRAINT [FK_GEObjectHistory_HRDepartmentFrom] FOREIGN KEY([FK_HRDepartmentFromID])
REFERENCES [dbo].[HRDepartments] ([HRDepartmentID])
GO
ALTER TABLE [dbo].[GEObjectHistory] CHECK CONSTRAINT [FK_GEObjectHistory_HRDepartmentFrom]
GO

ALTER TABLE [dbo].[GEObjectHistory]  WITH CHECK ADD  CONSTRAINT [FK_GEObjectHistory_HRDepartmentTo] FOREIGN KEY([FK_HRDepartmentToID])
REFERENCES [dbo].[HRDepartments] ([HRDepartmentID])
GO
ALTER TABLE [dbo].[GEObjectHistory] CHECK CONSTRAINT [FK_GEObjectHistory_HRDepartmentTo]
GO

ALTER TABLE [dbo].[GEObjectHistory]  WITH CHECK ADD  CONSTRAINT [FK_GEObjectHistory_HREmployeeFrom] FOREIGN KEY([FK_HREmployeeFromID])
REFERENCES [dbo].[HREmployees] ([HREmployeeID])
GO
ALTER TABLE [dbo].[GEObjectHistory] CHECK CONSTRAINT [FK_GEObjectHistory_HREmployeeFrom]
GO

ALTER TABLE [dbo].[GEObjectHistory]  WITH CHECK ADD  CONSTRAINT [FK_GEObjectHistory_HREmployeeTo] FOREIGN KEY([FK_HREmployeeToID])
REFERENCES [dbo].[HREmployees] ([HREmployeeID])
GO
ALTER TABLE [dbo].[GEObjectHistory] CHECK CONSTRAINT [FK_GEObjectHistory_HREmployeeTo]
GO
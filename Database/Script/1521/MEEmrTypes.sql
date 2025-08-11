
--chay tung dong de ko co loi
ALTER TABLE MEEmrTypes ADD MEEmrTypeIsTmp bit
UPDATE MEEmrTypes SET MEEmrTypeIsTmp = 0
ALTER TABLE MEEmrTypes ALTER COLUMN MEEmrTypeIsTmp bit not null
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'MEEmrTypeIsTmp', N'Bệnh án tạm', 'MEEmrTypes');

ALTER TABLE MEEmrTypes ADD FK_HRDepartmentID int
UPDATE MEEmrTypes SET FK_HRDepartmentID = 0
ALTER TABLE MEEmrTypes ALTER COLUMN FK_HRDepartmentID int not null

ALTER TABLE [dbo].MEEmrTypes  WITH CHECK ADD  CONSTRAINT [FK_MEEmrTypes_FK_HRDepartmentID] FOREIGN KEY(FK_HRDepartmentID)
REFERENCES [dbo].[HRDepartments] ([HRDepartmentID])
GO

ALTER TABLE [dbo].MEEmrTypes CHECK CONSTRAINT [FK_MEEmrTypes_FK_HRDepartmentID]
GO
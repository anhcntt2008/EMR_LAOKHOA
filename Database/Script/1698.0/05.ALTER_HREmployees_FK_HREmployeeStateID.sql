ALTER TABLE [dbo].[HREmployees]
ADD [FK_HREmployeeStateID] int NULL

ALTER TABLE [dbo].[HREmployees]  WITH CHECK ADD  CONSTRAINT [FK_HREmployees_HREmployeeStates] FOREIGN KEY([FK_HREmployeeStateID])
REFERENCES [dbo].[HREmployeeStates] ([HREmployeeStateID])
GO


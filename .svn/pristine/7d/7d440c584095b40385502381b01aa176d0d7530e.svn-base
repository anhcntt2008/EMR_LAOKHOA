ALTER TABLE HREmployees ADD HREmployeeStatusTKCombo nvarchar(50) 
GO
UPDATE HREmployees SET HREmployeeStatusTKCombo = 'Active'
GO
ALTER TABLE HREmployees ADD CONSTRAINT DF_HREmployees_HREmployeeStatusTKCombo DEFAULT '' FOR HREmployeeStatusTKCombo 


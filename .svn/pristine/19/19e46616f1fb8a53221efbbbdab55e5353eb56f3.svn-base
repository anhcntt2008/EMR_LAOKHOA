ALTER TABLE HRDepartments ADD HRDepartmentStatusCombo nvarchar(50) 
GO
UPDATE HRDepartments SET HRDepartmentStatusCombo = 'Active'
GO
ALTER TABLE HRDepartments ADD CONSTRAINT DF_HRDepartments_HRDepartmentStatusCombo DEFAULT '' FOR HRDepartmentStatusCombo 


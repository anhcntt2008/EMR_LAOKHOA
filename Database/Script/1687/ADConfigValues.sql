DELETE FROM ADConfigValues where ADConfigKeyGroup = 'EmployeeStatusTK' and ADConfigKey = 'EmployeeStatusTKActive'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'EmployeeStatusTKActive', N'Active', N'Hoạt động', NULL, N'EmployeeStatusTK', '1');
GO

DELETE FROM ADConfigValues where ADConfigKeyGroup = 'EmployeeStatusTK' and ADConfigKey = 'EmployeeStatusTKInActive'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'EmployeeStatusTKInActive', N'InActive', N'Không hoạt động', NULL, N'EmployeeStatusTK', '1');
GO

DELETE FROM ADConfigValues where ADConfigKeyGroup = 'DepartmentStatus' and ADConfigKey = 'DepartmentStatusActive'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'DepartmentStatusActive', N'Active', N'Hoạt động', NULL, N'DepartmentStatus', '1');
GO

DELETE FROM ADConfigValues where ADConfigKeyGroup = 'DepartmentStatus' and ADConfigKey = 'DepartmentStatusInActive'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'DepartmentStatusInActive', N'InActive', N'Không hoạt động', NULL, N'DepartmentStatus', '1');
GO
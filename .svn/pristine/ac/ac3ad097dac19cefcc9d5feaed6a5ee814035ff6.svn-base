GO
/****** Object:  StoredProcedure [dbo].[HREmployees_GetEmployeesForLookupEdit]    Script Date: 5/4/2020 11:21:19 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE OR ALTER PROCEDURE [dbo].[HREmployees_GetEmployeesForLookupEdit]
AS
BEGIN
  -- routine body goes here, e.g.
  -- SELECT 'Navicat for SQL Server'
SET NOCOUNT ON
SELECT HREmployeeID, HREmployeeNo, HREmployeeName, 
			HREmployeeContactAddressLine1, HREmployeeTel1, HREmployeeTaxNumber, 
			FK_HRDepartmentID, FK_HRDepartmentRoomID, FK_MESpecialismID
FROM HREmployees
WHERE AAStatus = 'Alive' AND HREmployeeStatusTKCombo = 'Active'
END

GO






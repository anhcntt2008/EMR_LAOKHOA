GO
/****** Object:  StoredProcedure [dbo].[HRDepartments_GetDepartmentsForLookupEdit]    Script Date: 5/4/2020 11:21:19 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE OR ALTER PROCEDURE [dbo].[HRDepartments_GetDepartmentsForLookupEdit]
AS
BEGIN
  -- routine body goes here, e.g.
  -- SELECT 'Navicat for SQL Server'
SET NOCOUNT ON
SELECT *
FROM HRDepartments
WHERE AAStatus = 'Alive' AND HRDepartmentStatusCombo = 'Active'
END

GO



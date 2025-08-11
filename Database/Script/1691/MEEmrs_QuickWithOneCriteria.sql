GO

/****** Object:  StoredProcedure [dbo].[MEEmrs_QuickWithOneCriteria]    Script Date: 9/10/2020 2:28:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- ======================================================================
-- Created By: UtHV
-- Latest update: 18/02/2020 - Them @StateConditions
-- Last update: XuanTM 10/09/2020 - @MEEmrArchiveStatus
-- ======================================================================
CREATE OR ALTER PROCEDURE [dbo].[MEEmrs_QuickWithOneCriteria] @FK_MEEmrNo VARCHAR(50)
	,@FK_MEPatientID [int]
	,@FK_HREmployeeID [int]
	,-- id cua tôi
	@FK_HRDepartmentID INT
	,-- khoa cua tôi
	@MEEmrStatus VARCHAR(50) NULL
	,@MEEmrArchiveStatus INT
	,@ViewPermission VARCHAR(100), -- All, Department
	@StateConditions NVARCHAR(4000)
AS
BEGIN
	EXEC MEEmrs_QuickWithOneCriteriaPaging @FK_MEEmrNo
		,@FK_MEPatientID
		,@FK_HREmployeeID
		,@FK_HRDepartmentID
		,@MEEmrStatus
		,@MEEmrArchiveStatus
		,@ViewPermission
		,@StateConditions
		,0
		,100000
END
GO



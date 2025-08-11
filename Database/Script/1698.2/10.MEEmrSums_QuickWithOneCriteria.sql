GO

/****** Object:  StoredProcedure [dbo].[MEEmrSums_QuickWithOneCriteria]    Script Date: 9/5/2021 8:32:14 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE OR ALTER PROCEDURE [dbo].[MEEmrSums_QuickWithOneCriteria]
	@FK_MEPatientID [int]
AS
BEGIN
	SELECT es.*
		, e.MEEmrNo
		, p.MEPatientNo
		, p.MEPatientName
		, p.MEPatientBirthday
		, e.MEEmrDateIn
		, e.MEEmrDateOut
		, t.MEEmrTypeName
		, d.HRDepartmentName
		, e.MEEmrICDStrOut
	FROM MEEmrSums es
	INNER JOIN MEEmrs e ON e.MEEmrID = es.FK_MEEmrID
	INNER JOIN [dbo].[MEPatients] p ON e.FK_MEPatientID = p.MEPatientID
	INNER JOIN [dbo].[MEEmrTypes] t ON e.FK_MEEmrTypeID = t.MEEmrTypeID
	INNER JOIN [dbo].[HRDepartments] d ON d.HRDepartmentID = e.FK_HRDepartmentID
	WHERE es.AAStatus='Alive' AND e.AAStatus = 'Alive' AND p.AAStatus = 'Alive'
	AND e.FK_MEPatientID = @FK_MEPatientID
END
GO


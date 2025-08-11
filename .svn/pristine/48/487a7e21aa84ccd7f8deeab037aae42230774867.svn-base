GO

/****** Object:  StoredProcedure [dbo].[MEEmrs_WithRelation]    Script Date: 10/03/2021 2:51:48 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO


CREATE OR ALTER PROCEDURE [dbo].[MEEmrs_WithRelation]
	@MEEmrID INT
AS
BEGIN
	SELECT
				e.*
				, p.MEPatientNo
				, p.MEPatientName
				, p.MEPatientContactCellPhone
				, e.FK_HRDepartmentID as FK_HRDepartmentShortID
				, p.MEPatientBirthday
				, DATEPART(year, p.MEPatientBirthday) as MEPatientBirthYear
				, '' AS MEEmrArchiveStatus	
				, ROW_NUMBER() OVER (ORDER BY e.MEEmrID DESC) AS RowIndex
				FROM
					[dbo].[MEEmrs] e INNER JOIN [dbo].[MEPatients] p ON e.FK_MEPatientID = p.MEPatientID
					INNER JOIN (SELECT FK_MEEmrFromID AS MEEmrID FROM MEEmrRelations WHERE FK_MEEmrToID = @MEEmrID
						UNION SELECT FK_MEEmrToID AS MEEmrID FROM MEEmrRelations WHERE FK_MEEmrFromID = @MEEmrID) re ON re.MEEmrID = e.MEEmrID
				WHERE
					e.[AAStatus]='Alive'
					AND p.[AAStatus]='Alive'
END
GO

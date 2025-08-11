
-- ======================================================================
-- Created By: UtHV
-- ======================================================================
CREATE PROCEDURE [dbo].[MEEmrs_QuickByPatient]
	@FK_MEPatientID [int],
	@FK_HREmployeeID [int], -- id cua tôi
	@FK_HRDepartmentID int-- khoa cua tôi
AS
BEGIN
	SET NOCOUNT ON
	SELECT e.*
	FROM
		[dbo].[MEEmrs] e
	WHERE e.FK_MEPatientID = @FK_MEPatientID
		AND e.[AAStatus]='Alive'
		-- khoa muon xem la khoa cua toi
		AND  e.MEEmrID IN (SELECT s.FK_MEEmrID
								FROM [dbo].[MEEmrShareHistories] s 
								WHERE s.[AAStatus]='Alive' 
								AND s.MEEmrShareHistoryActive = 1
								AND (GETDATE() BETWEEN s.MEEmrShareHistoryFromDate AND s.MEEmrShareHistoryToDate)
								AND (s.FK_HRDepartmentID = 0 OR s.FK_HRDepartmentID = @FK_HRDepartmentID) -- =0 là chia sẻ cho mọi khoa
								AND (s.FK_HREmployeeID = 0 OR s.FK_HREmployeeID = @FK_HREmployeeID) -- =0 là chia sẻ cho mọi nhân viên
			)
END
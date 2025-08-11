
-- ======================================================================
-- Created By: UtHV
-- ======================================================================
ALTER PROCEDURE [dbo].[MEEmrs_Quick]
    @MEEmrCreatedDateFrom date,
    @MEEmrCreatedDateTo date,
	@FK_HRDepartmentID int,-- khoa cua tôi
	@FK_HRDepartmentSearchID varchar(1000),-- khoa muon xem
	@FK_HREmployeeID [int] -- id cua tôi
AS
BEGIN
	SET NOCOUNT ON
	SELECT e.*
	FROM
		[dbo].[MEEmrs] e
	WHERE (CONVERT(date,e.MEEmrCreatedDate) BETWEEN @MEEmrCreatedDateFrom AND @MEEmrCreatedDateTo)
		AND e.[AAStatus]='Alive'
		-- khoa muon xem la khoa cua toi
		AND (( e.FK_HRDepartmentID = @FK_HRDepartmentID AND CHARINDEX(CONCAT( ', ', e.FK_HRDepartmentID, ', '), @FK_HRDepartmentSearchID ) > 0)
			-- khoa muon xem chia se cho toi
			OR e.MEEmrID IN (SELECT s.FK_MEEmrID
								FROM [dbo].[MEEmrShareHistories] s 
								WHERE s.[AAStatus]='Alive' 
								AND s.MEEmrShareHistoryActive = 1
								AND (GETDATE() BETWEEN s.MEEmrShareHistoryFromDate AND s.MEEmrShareHistoryToDate)
								AND (CHARINDEX(CONCAT( ', ', e.FK_HRDepartmentID, ', '), @FK_HRDepartmentSearchID ) > 0)
								AND (s.FK_HRDepartmentID = 0 OR s.FK_HRDepartmentID = @FK_HRDepartmentID) -- =0 là chia sẻ cho mọi khoa
								AND (s.FK_HREmployeeID = 0 OR s.FK_HREmployeeID = @FK_HREmployeeID) -- =0 là chia sẻ cho mọi nhân viên
							)
			)
END
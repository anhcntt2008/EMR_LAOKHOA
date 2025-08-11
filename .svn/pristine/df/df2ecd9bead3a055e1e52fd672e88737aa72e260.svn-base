SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[MEEmrs_GetEmrByPatientWithSharedConds] @FK_MEPatientID INT
	,@MEEmrTypeProfile VARCHAR(100)
	,@FK_HRDepartmentID INT
	,@FK_HREmployeeID INT
	,@StateConditions NVARCHAR(4000)
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @view VARCHAR(50);

	SELECT @view = [dbo].[ADUser_GetEmployeeEmrView](@FK_HREmployeeID)

	DECLARE @sql NVARCHAR(max)

	IF @view = 'All'
	BEGIN
		EXEC MEEmrs_GetEmrByPatientWithoutPatientProfile @FK_MEPatientID
			,NULL
	END
	ELSE
	BEGIN
		SET @sql = 
			'
		SELECT *
			,p.MEPatientNo
			,p.MEPatientName
			,e.FK_HRDepartmentID AS FK_HRDepartmentShortID
		FROM [dbo].[MEEmrs] e
		INNER JOIN [dbo].[MEPatients] p ON e.FK_MEPatientID = p.MEPatientID
		WHERE e.[FK_MEPatientID] = @FK_MEPatientID
			AND e.[AAStatus] = ''Alive''
			AND p.[AAStatus] = ''Alive''
			AND e.MEEmrTypeProfile <> ''Patient''
			AND (
				@MEEmrTypeProfile IS NULL
				OR e.MEEmrTypeProfile = @MEEmrTypeProfile
				)
			AND (	e.FK_HRDepartmentID = @FK_HRDepartmentID -- khoa muon xem la khoa cua toi
					OR e.MEEmrID IN (
						SELECT s.FK_MEEmrID
						FROM [dbo].[MEEmrShareHistories] s
						WHERE s.[AAStatus] = ''Alive''
							AND s.MEEmrShareHistoryActive = 1
							AND (
								GETDATE() BETWEEN s.MEEmrShareHistoryFromDate
									AND s.MEEmrShareHistoryToDate
								)
							AND (
								s.FK_HRDepartmentID = 0
								OR s.FK_HRDepartmentID = @FK_HRDepartmentID
								) -- =0 là chia sẻ cho mọi khoa
							AND (
								s.FK_HREmployeeID = 0
								OR s.FK_HREmployeeID = @FK_HREmployeeID
								) -- =0 là chia sẻ cho mọi nhân viên
						)
				)
			' 
			+ ISNULL(@StateConditions, '')

		EXEC sys.sp_executesql @sql
			,N'@FK_MEPatientID int, @MEEmrTypeProfile VARCHAR(100), @FK_HRDepartmentID int, @FK_HREmployeeID int, @StateConditions NVARCHAR(4000)'
			,@FK_MEPatientID
			,@MEEmrTypeProfile
			,@FK_HRDepartmentID
			,@FK_HREmployeeID
			,@StateConditions
	END
END

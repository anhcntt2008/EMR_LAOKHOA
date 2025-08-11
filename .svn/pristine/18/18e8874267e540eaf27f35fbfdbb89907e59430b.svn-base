GO
/****** Object:  StoredProcedure [dbo].[MEEmrs_QuickPaging]    Script Date: 8/7/2020 4:18:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ======================================================================
-- Created By: UtHV
-- [dbo].[MEEmrs_QuickPaging] '2018-01-01', '2018-12-31', 0, '119', 0, 0, 10, 10
-- Update: 22/01/2020 - Them cot MEPatientBirthday, MEPatientBirthYear
-- update: 18/02/2020 - Them @StateConditions
-- Latest update: 05/05/2020 - Them IS NULL @StateConditions
-- ======================================================================
ALTER PROCEDURE [dbo].[MEEmrs_QuickPaging]
    @MEEmrCreatedDateFrom date,
    @MEEmrCreatedDateTo date,
	@FK_HRDepartmentID int,-- khoa cua tôi
	@FK_HRDepartmentSearchID varchar(1000),-- khoa muon xem
	@FK_HREmployeeID [int], -- id cua tôi
	@ViewPermission varchar(100), -- All, Department
	@StateConditions NVARCHAR(4000),
	@Skip INT = 0,
	@Take INT = 100000
AS
BEGIN
	SET NOCOUNT ON
	SET @FK_HRDepartmentSearchID = ISNULL( @FK_HRDepartmentSearchID,'-1')
	DECLARE @sql nvarchar(max)
	SET @sql = '
			WITH query AS (
				SELECT
				e.*
				, p.MEPatientNo
				, p.MEPatientName
				, p.MEPatientContactCellPhone
				, e.FK_HRDepartmentID as FK_HRDepartmentShortID
				, p.MEPatientBirthday
				, DATEPART(year, p.MEPatientBirthday) as MEPatientBirthYear
				, ROW_NUMBER() OVER (ORDER BY e.MEEmrID DESC) AS RowIndex
				FROM
					[dbo].[MEEmrs] e INNER JOIN [dbo].[MEPatients] p ON e.FK_MEPatientID = p.MEPatientID
				WHERE (CONVERT(date,e.MEEmrCreatedDate) BETWEEN @MEEmrCreatedDateFrom AND @MEEmrCreatedDateTo)
					AND e.[AAStatus]=''Alive''
					AND p.[AAStatus]=''Alive''
					AND (
						-- khoa muon xem la khoa cua toi
						(e.FK_HRDepartmentID = @FK_HRDepartmentID AND e.FK_HRDepartmentID IN ( '+ @FK_HRDepartmentSearchID + ' ))
						-- quyen truy xuat tat ca
						OR (@ViewPermission = ''All'' AND e.FK_HRDepartmentID IN ( '+  @FK_HRDepartmentSearchID + ' ))
						-- khoa muon xem chia se cho toi
						OR e.MEEmrID IN (SELECT s.FK_MEEmrID
											FROM [dbo].[MEEmrShareHistories] s 
											WHERE s.[AAStatus]=''Alive'' 
											AND s.MEEmrShareHistoryActive = 1
											AND (GETDATE() >= s.MEEmrShareHistoryFromDate AND GETDATE() <= s.MEEmrShareHistoryToDate)
											AND (e.FK_HRDepartmentID IN ( '+  @FK_HRDepartmentSearchID + ' ) OR s.FK_HRDepartmentID = @FK_HRDepartmentID)
											AND (s.FK_HRDepartmentID = 0 OR s.FK_HRDepartmentID = @FK_HRDepartmentID) -- =0 là chia sẻ cho mọi khoa
											AND (s.FK_HREmployeeID = 0 OR s.FK_HREmployeeID = @FK_HREmployeeID) -- =0 là chia sẻ cho mọi nhân viên
										)
					)' + ISNULL(@StateConditions, '') + '
				)
				
				SELECT *
				FROM query
				CROSS APPLY
				(
					SElECT COUNT (*) AS TotalRows FROM query
				)  tmp
				WHERE RowIndex > @Skip
				AND RowIndex <= (@Skip + @Take)
				'

	EXEC sys.sp_executesql @sql
	,N'@MEEmrCreatedDateFrom date, @MEEmrCreatedDateTo date, @FK_HRDepartmentID int, @FK_HREmployeeID int, @ViewPermission varchar(100), @StateConditions NVARCHAR(4000), @Skip int, @Take int'
	,@MEEmrCreatedDateFrom
	,@MEEmrCreatedDateTo
	,@FK_HRDepartmentID
	,@FK_HREmployeeID
	,@ViewPermission
	,@StateConditions
	,@Skip
	,@Take
END
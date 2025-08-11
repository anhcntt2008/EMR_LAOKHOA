GO
/****** Object:  StoredProcedure [dbo].[MEEmrs_Search]    Script Date: 5/19/2020 2:57:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
-- ======================================================================
-- Create By: UtHV
-- Search Emr theo phan quyen
-- update: 22/01/2020 - Them cot MEPatientBirthday, MEPatientBirthYear
-- update: 18/02/2020 - Them @StateConditions
-- update: 19/05/2020 - Edit MEEmrCreatedDateFrom, MEEmrCreatedDateTo [date]
-- Latest update: 19/05/2020
-- ======================================================================

CREATE OR ALTER PROCEDURE [dbo].[MEEmrs_Search]
	@MEEmrNo [varchar](50) ,
	@MEEmrStatus [varchar](50) ,
	@MEEmrCreatedDateFrom [datetime] ,
	@MEEmrCreatedDateTo [datetime] ,
	@FK_MEPatientID [int] ,
	@FK_MEEmrTypeID [int] ,
	@FK_HRDepartmentSearchID varchar(1000),-- khoa muon xem
	@FK_HRDepartmentID [int], -- khoa cua tôi
	@FK_HREmployeeID [int], -- id cua tôi
	@ViewPermission varchar(100), -- All, Department
	@StateConditions NVARCHAR(4000)

AS
BEGIN
SET NOCOUNT ON
	SET @FK_HRDepartmentSearchID = ISNULL( @FK_HRDepartmentSearchID,'-1')
	DECLARE @sql nvarchar(max)
	SET @sql = 'SELECT TOP 100000 e.*
	, p.MEPatientNo
	, p.MEPatientName
	, e.FK_HRDepartmentID as FK_HRDepartmentShortID
	, p.MEPatientBirthday
	, DATEPART(year, p.MEPatientBirthday) as MEPatientBirthYear
	FROM
		[dbo].[MEEmrs] e INNER JOIN [dbo].[MEPatients] p ON e.FK_MEPatientID = p.MEPatientID
	WHERE  (@MEEmrNo IS NULL OR e.MEEmrNo LIKE ''%'' + @MEEmrNo + ''%'')
		AND (@MEEmrStatus IS NULL OR e.MEEmrStatus = @MEEmrStatus)
		AND (@FK_MEPatientID IS NULL OR e.FK_MEPatientID = @FK_MEPatientID)
		AND (@FK_MEEmrTypeID IS NULL OR e.FK_MEEmrTypeID = @FK_MEEmrTypeID)
		AND (CONVERT(date,e.MEEmrCreatedDate) BETWEEN @MEEmrCreatedDateFrom AND @MEEmrCreatedDateTo)
		AND e.[AAStatus]=''Alive''
		AND p.[AAStatus]=''Alive''
		AND (
			-- khoa muon xem la khoa cua toi
			( e.FK_HRDepartmentID = @FK_HRDepartmentID AND e.FK_HRDepartmentID IN ( '+ @FK_HRDepartmentSearchID + ' ))
			-- quyen truy xuat tat ca
			OR (@ViewPermission = ''All'' AND e.FK_HRDepartmentID IN ( '+  @FK_HRDepartmentSearchID + ' ))
			-- khoa muon xem chia se cho toi
			OR e.MEEmrID IN (SELECT s.FK_MEEmrID
								FROM [dbo].[MEEmrShareHistories] s 
								WHERE s.[AAStatus]=''Alive'' 
								AND s.MEEmrShareHistoryActive = 1
								AND (GETDATE() BETWEEN s.MEEmrShareHistoryFromDate AND s.MEEmrShareHistoryToDate)
								AND e.FK_HRDepartmentID IN ( '+  @FK_HRDepartmentSearchID + ' )
								AND (s.FK_HRDepartmentID = 0 OR s.FK_HRDepartmentID = @FK_HRDepartmentID) -- =0 là chia sẻ cho mọi khoa
								AND (s.FK_HREmployeeID = 0 OR s.FK_HREmployeeID = @FK_HREmployeeID) -- =0 là chia sẻ cho mọi nhân viên
							)
			) ' + ISNULL( @StateConditions,'') +'
		'
	EXEC sys.sp_executesql @sql
	,N'@MEEmrNo [varchar](50) ,
		@MEEmrStatus [varchar](50) ,
		@MEEmrCreatedDateFrom [date] ,
		@MEEmrCreatedDateTo [date] ,
		@FK_MEPatientID [int] ,
		@FK_MEEmrTypeID [int] ,
		@FK_HRDepartmentID [int],
		@FK_HREmployeeID [int],
		@ViewPermission varchar(100)'
	,@MEEmrNo,
		@MEEmrStatus,
		@MEEmrCreatedDateFrom,
		@MEEmrCreatedDateTo,
		@FK_MEPatientID,
		@FK_MEEmrTypeID,
		@FK_HRDepartmentID,
		@FK_HREmployeeID,
		@ViewPermission

END 
GO



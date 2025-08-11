GO

/****** Object:  StoredProcedure [dbo].[MEEmrs_Search]    Script Date: 9/10/2020 1:36:15 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
-- ======================================================================
-- Last update: XuanTM 10/09/2020 - @MEEmrArchiveStatus
-- ======================================================================

CREATE OR ALTER   PROCEDURE [dbo].[MEEmrs_Search]
	@MEEmrNo [varchar](50) ,
	@MEEmrStatus [varchar](50) ,
	@MEEmrCreatedDateFrom [datetime] ,
	@MEEmrCreatedDateTo [datetime] ,
	@FK_MEPatientID [int] ,
	@FK_MEEmrTypeID [int] ,
	@MEEmrPatientGroup [nvarchar](100) ,
	@MEEmrDateOutFrom [datetime],
	@MEEmrDateOutTo [datetime],
	@FK_HRDepartmentSearchID varchar(1000),-- khoa muon xem
	@FK_HRDepartmentID [int], -- khoa cua tôi
	@FK_HREmployeeID [int], -- id cua tôi
	@MEEmrArchiveStatus INT, -- 0-1,... query tbl MEEmrArchives
	@ViewPermission varchar(100), -- All, Department
	@StateConditions NVARCHAR(4000)

AS
BEGIN
SET NOCOUNT ON
	SET @FK_HRDepartmentSearchID = ISNULL( @FK_HRDepartmentSearchID,'-1')
	-- MEEmrArchives
	DECLARE @sqlSelectMEEmrArchives nvarchar(128) = ' '''''
	DECLARE @sqlMEEmrArchives nvarchar(1024) = ''
	if (@MEEmrArchiveStatus = 1)  
	begin
		set @sqlSelectMEEmrArchives = ' ISNULL(arcap.MEEmrArchiveStatus,'''')'
		set @sqlMEEmrArchives = ' OUTER APPLY (SELECT TOP 1 MEEmrArchiveStatus FROM MEEmrArchives arc WHERE arc.AAStatus=''Alive'' AND arc.FK_MEEmrID = e.MEEmrID) arcap'
	end
	-- End MEEmrArchives
	DECLARE @sql nvarchar(max)
	SET @sql = 'SELECT TOP 100000 e.*
	, p.MEPatientNo
	, p.MEPatientName
	, e.FK_HRDepartmentID as FK_HRDepartmentShortID
	, p.MEPatientBirthday
	, DATEPART(year, p.MEPatientBirthday) as MEPatientBirthYear
	, '+ @sqlSelectMEEmrArchives +' AS MEEmrArchiveStatus	
	FROM
		[dbo].[MEEmrs] e INNER JOIN [dbo].[MEPatients] p ON e.FK_MEPatientID = p.MEPatientID' 
					+ @sqlMEEmrArchives +
	' WHERE  (@MEEmrNo IS NULL OR e.MEEmrNo LIKE ''%'' + @MEEmrNo + ''%'')
		AND (@MEEmrStatus IS NULL OR e.MEEmrStatus = @MEEmrStatus)
		AND (@FK_MEPatientID IS NULL OR e.FK_MEPatientID = @FK_MEPatientID)
		AND (@FK_MEEmrTypeID IS NULL OR e.FK_MEEmrTypeID = @FK_MEEmrTypeID)
		AND (CONVERT(date,e.MEEmrCreatedDate) BETWEEN @MEEmrCreatedDateFrom AND @MEEmrCreatedDateTo)
		AND (@MEEmrDateOutFrom IS NULL OR (CONVERT(date,e.MEEmrDateOut) >= @MEEmrDateOutFrom AND CONVERT(date,e.MEEmrDateOut) < @MEEmrDateOutTo))
		AND (@MEEmrPatientGroup IS NULL OR e.MEEmrPatientGroup = @MEEmrPatientGroup)
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
		@MEEmrPatientGroup [nvarchar](100) ,
		@MEEmrDateOutFrom [datetime] ,
		@MEEmrDateOutTo [datetime] ,
		@FK_HRDepartmentID [int] ,
		@FK_HREmployeeID [int] ,
		@MEEmrArchiveStatus [int],
		@ViewPermission varchar(100)'
	,@MEEmrNo,
		@MEEmrStatus,
		@MEEmrCreatedDateFrom,
		@MEEmrCreatedDateTo,
		@FK_MEPatientID,
		@FK_MEEmrTypeID,
		@MEEmrPatientGroup,
		@MEEmrDateOutFrom,
		@MEEmrDateOutTo,
		@FK_HRDepartmentID,
		@FK_HREmployeeID,
		@MEEmrArchiveStatus,
		@ViewPermission

END 
GO



GO

/****** Object:  StoredProcedure [dbo].[MEEmrs_QuickWithOneCriteriaPaging]    Script Date: 9/10/2020 2:31:45 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- ======================================================================
-- Created By: tiennm
-- [dbo].[MEEmrs_QuickWithOneCriteriaPaging] null, 283, 1329, 19, null, 'All', 0, 10 
-- Latest update: 22/01/2020 - Them cot MEPatientBirthday, MEPatientBirthYear
-- Latest update: 18/02/2020 - Them @StateConditions
-- Last update: XuanTM 10/09/2020 - @MEEmrArchiveStatus
-- ======================================================================
CREATE OR ALTER PROCEDURE [dbo].[MEEmrs_QuickWithOneCriteriaPaging]
	@FK_MEEmrNo varchar(50),
	@FK_MEPatientID [int],
	@FK_HREmployeeID [int], -- id cua tôi
	@FK_HRDepartmentID int,-- khoa cua tôi
	@MEEmrStatus varchar(50) null,
	@MEEmrArchiveStatus INT, -- 0-1,... query tbl MEEmrArchives
	@ViewPermission varchar(100), -- All, Department
	@StateConditions NVARCHAR(4000),
	@Skip INT = 0,
	@Take INT = 100000
AS
BEGIN
	SET NOCOUNT ON;
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
	SET @sql = '
	WITH query
	AS
	(
		SELECT 
		e.*
		, p.MEPatientNo
		, p.MEPatientName
		, p.MEPatientContactCellPhone
		, e.FK_HRDepartmentID as FK_HRDepartmentShortID
		, p.MEPatientBirthday
		, DATEPART(year, p.MEPatientBirthday) as MEPatientBirthYear
		, '+ @sqlSelectMEEmrArchives +' AS MEEmrArchiveStatus
		, ROW_NUMBER() OVER (ORDER BY e.MEEmrID DESC) AS RowIndex
		FROM
			[dbo].[MEEmrs] e
			INNER JOIN [dbo].[MEPatients] p ON e.FK_MEPatientID = p.MEPatientID' 
					+ @sqlMEEmrArchives +
				' INNER JOIN [dbo].[MEEmrTypes] t ON e.FK_MEEmrTypeID = t.MEEmrTypeID
		WHERE (e.MEEmrNo IS NULL OR e.MEEmrNo like CONCAT( ''%'' , @FK_MEEmrNo , ''%''))
			AND (@FK_MEPatientID IS NULL or e.FK_MEPatientID = @FK_MEPatientID)
			AND e.[AAStatus]=''Alive''
			AND p.[AAStatus]=''Alive''
			AND t.[AAStatus]=''Alive''
			AND (@MEEmrStatus IS NULL OR e.MEEmrStatus = @MEEmrStatus)
			AND ( e.FK_HRDepartmentID = @FK_HRDepartmentID -- khoa muon xem la khoa cua toi
				-- ho so benh nhan
				OR  t.MEEmrTypeProfile = ''Patient''
				-- quyen truy xuat tat ca
				OR (@ViewPermission = ''All'')
				OR  e.MEEmrID IN (SELECT s.FK_MEEmrID
									FROM [dbo].[MEEmrShareHistories] s 
									WHERE s.[AAStatus]=''Alive'' 
									AND s.MEEmrShareHistoryActive = 1
									AND (GETDATE() BETWEEN s.MEEmrShareHistoryFromDate AND s.MEEmrShareHistoryToDate)
									AND (s.FK_HRDepartmentID = 0 OR s.FK_HRDepartmentID = @FK_HRDepartmentID) -- =0 là chia sẻ cho mọi khoa
									AND (s.FK_HREmployeeID = 0 OR s.FK_HREmployeeID = @FK_HREmployeeID) -- =0 là chia sẻ cho mọi nhân viên
						)
			)' + ISNULL(@StateConditions, '')+ '
	)

	SELECT * FROM query
	CROSS APPLY 
	(
		SELECT COUNT(*) AS TotalRows
	) tmp
	WHERE RowIndex > @Skip
	AND RowIndex <= (@Skip + @Take)
	'
	EXEC sys.sp_executesql @sql
	,N'@FK_MEEmrNo varchar(100), @FK_MEPatientID int, @FK_HREmployeeID int, @FK_HRDepartmentID int, @MEEmrStatus varchar(100),@MEEmrArchiveStatus [int], @ViewPermission varchar(100), @Skip int, @Take int'
	,@FK_MEEmrNo
	,@FK_MEPatientID
	,@FK_HREmployeeID
	,@FK_HRDepartmentID
	,@MEEmrStatus
	,@MEEmrArchiveStatus
	,@ViewPermission
	,@Skip
	,@Take
END
GO



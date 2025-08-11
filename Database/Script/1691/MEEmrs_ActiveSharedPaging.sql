GO

/****** Object:  StoredProcedure [dbo].[MEEmrs_ActiveSharedPaging]    Script Date: 9/10/2020 2:37:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- ======================================================================
-- Created By: UtHV
-- Latest update: 18/02/2020 - Them @StateConditions
-- Last update: XuanTM 10/09/2020 - @MEEmrArchiveStatus
-- ======================================================================
CREATE OR ALTER PROCEDURE [dbo].[MEEmrs_ActiveSharedPaging] 
	@FK_HRDepartmentID INT
	,@MEEmrArchiveStatus INT -- 0-1,... query tbl MEEmrArchives
	,@StateConditions NVARCHAR(4000)
	,@Skip INT = 0
	,@Take INT = 100000
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
		AS (
			SELECT e.*
				,p.MEPatientNo
				,p.MEPatientName
				,p.MEPatientBirthday
				, p.MEPatientContactCellPhone
				,DATEPART(year, p.MEPatientBirthday) as MEPatientBirthYear
				, '+ @sqlSelectMEEmrArchives +' AS MEEmrArchiveStatus
				,ROW_NUMBER() OVER (
					ORDER BY e.MEEmrID DESC
					) AS RowIndex
			FROM [dbo].[MEEmrs] e
			INNER JOIN [dbo].[MEPatients] p ON e.FK_MEPatientID = p.MEPatientID' 
					+ @sqlMEEmrArchives +
				' WHERE e.[AAStatus] = ''Alive''
				AND (e.FK_HRDepartmentID = @FK_HRDepartmentID)
				AND e.MEEmrID IN (
					SELECT s.FK_MEEmrID
					FROM [dbo].[MEEmrShareHistories] s
					WHERE s.[AAStatus] = ''Alive''
						AND s.MEEmrShareHistoryActive = 1
						AND (
							GETDATE() BETWEEN s.MEEmrShareHistoryFromDate
								AND s.MEEmrShareHistoryToDate
							)
					)
				' + @StateConditions + '
			)
		SELECT *
		FROM query
		CROSS APPLY (
			SELECT COUNT(*) AS TotalRows
			FROM query
			) AS tmp
		WHERE RowIndex > @Skip
			AND RowIndex <= (@Skip + @Take)
	'
	EXEC sys.sp_executesql @sql
	,N'@FK_HRDepartmentID int,@MEEmrArchiveStatus int, @Skip int, @Take int'
	,@FK_HRDepartmentID
	,@MEEmrArchiveStatus
	,@Skip
	,@Take

END
GO



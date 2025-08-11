GO
/****** Object:  StoredProcedure [dbo].[MEEmrArchives_Search]    Script Date: 7/22/2020 9:43:10 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- ======================================================================
-- Create By: XuanTM	
-- Search emr archives
-- ======================================================================

CREATE OR ALTER   PROCEDURE [dbo].[MEEmrArchives_Search]
	@MEEmrArchiveStatus varchar(50),
	@MEEmrArchiveBackupStatus varchar(50),
	@MEEmrCreatedDateFrom [date],
	@MEEmrCreatedDateTo [date],
	@MEEmrArchiveBackupDateFrom [date],
	@MEEmrArchiveBackupDateTo [date]
AS
BEGIN
SET NOCOUNT ON
	SELECT arc.* -- ect...
	FROM [dbo].[MEEmrArchives] arc
	INNER JOIN [dbo].[MEEmrs] emr ON arc.FK_MEEmrID = emr.MEEmrID
	WHERE arc.AAStatus='Alive' -- AND emr.AAStatus ='Alive'
	AND (@MEEmrArchiveStatus IS NULL OR arc.MEEmrArchiveStatus = @MEEmrArchiveStatus)
	AND (@MEEmrArchiveBackupStatus IS NULL OR arc.MEEmrArchiveBackupStatus = @MEEmrArchiveBackupStatus)
	AND (CONVERT(date, emr.MEEmrCreatedDate) BETWEEN @MEEmrCreatedDateFrom AND @MEEmrCreatedDateTo) -- default value min - max
	AND (CONVERT(date,arc.MEEmrArchiveBackupDate) BETWEEN @MEEmrArchiveBackupDateFrom AND @MEEmrArchiveBackupDateTo) -- default value min - max
END 
GO



GO

/****** Object:  StoredProcedure [dbo].[MEEmrs_ActiveShared]    Script Date: 9/10/2020 2:35:54 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- ======================================================================
-- Created By: UtHV
-- Latest update: 18/02/2020 - Them @StateConditions
-- Last update: XuanTM 10/09/2020 - @MEEmrArchiveStatus
-- ======================================================================
CREATE OR ALTER PROCEDURE [dbo].[MEEmrs_ActiveShared] 
	@FK_HRDepartmentID INT,
	@MEEmrArchiveStatus INT, -- 0-1,... query tbl MEEmrArchives
	@StateConditions NVARCHAR(4000)
AS
BEGIN

	EXEC MEEmrs_ActiveSharedPaging @FK_HRDepartmentID
		,@MEEmrArchiveStatus
		,@StateConditions
		,0
		,100000

END
GO



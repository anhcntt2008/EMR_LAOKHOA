
/****** Object:  StoredProcedure [dbo].[MEEmrs_QuickShared]    Script Date: 09/10/2023 9:44:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[MEEmrs_UserAssigned] 
	@MEEmrCreatedDateFrom DATE
	,@MEEmrCreatedDateTo DATE
	,@UserAssignName NVARCHAR(124)
AS
BEGIN
	EXEC MEEmrs_UserAssignedPaging 
		@MEEmrCreatedDateFrom
		,@MEEmrCreatedDateTo
		,@UserAssignName
		,0
		,100000
END
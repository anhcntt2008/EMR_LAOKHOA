GO

/****** Object:  StoredProcedure [dbo].[METemplateUserGroups_GetFirstByUserGroupAndTemplate]    Script Date: 7/31/2020 5:21:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		XuanTM
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[METemplateUserGroups_GetFirstByUserGroupAndTemplate] 
	@FK_ADUserGroupID INT
	,@FK_METemplateID INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP 1 *
	FROM [dbo].[METemplateUserGroups]
	WHERE FK_ADUserGroupID = @FK_ADUserGroupID
		AND FK_METemplateID = @FK_METemplateID
END
GO



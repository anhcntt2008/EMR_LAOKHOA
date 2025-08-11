GO
/****** Object:  StoredProcedure [dbo].[STToolbars_SelectBySTModuleIDAndName]    Script Date: 4/22/2020 4:04:52 PM ******/
DROP PROCEDURE [dbo].[STToolbars_SelectBySTModuleIDAndName]
GO
/****** Object:  StoredProcedure [dbo].[STToolbars_SelectBySTModuleIDAndName]    Script Date: 4/22/2020 4:04:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<XuanTM>
-- Create date: <22/04/2020>
-- Description:	<US 264 Get Toolbar base on Module and Name>
-- =============================================

CREATE PROCEDURE [dbo].[STToolbars_SelectBySTModuleIDAndName]
	@STModuleID int,
	@STToolbarName nvarchar(50)

AS
BEGIN
SET NOCOUNT ON
SELECT
	*
FROM
	[dbo].[STToolbars]
WHERE
	([STModuleID]=@STModuleID)
	AND
	([STToolbarName]=@STToolbarName)
END
GO



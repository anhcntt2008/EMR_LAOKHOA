GO
/****** Object:  StoredProcedure [dbo].[METemplates_GetTemplatesByTypeOnly]    Script Date: 7/31/2020 1:30:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		XuanTM
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[METemplates_GetTemplatesByTypeOnly] @METemplateType VARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM [dbo].[METemplates]
	WHERE AAStatus = 'Alive'
		AND METemplateType = @METemplateType
END
GO



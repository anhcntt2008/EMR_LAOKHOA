GO

/****** Object:  StoredProcedure [dbo].[METemplates_GetTemplatesByEmrType]    Script Date: 1/21/2021 9:20:59 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		XuanTM
-- Created: 21/01/2021
-- Description: Get templates base emr type.
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[METemplates_GetTemplatesByEmrType] 
	@METemplateType VARCHAR(50)
	,@FK_ADUserGroupID INT
	,@FK_MEEmrTypeID INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT t.*
	FROM [dbo].[METemplates] t
	INNER JOIN [dbo].[METemplateUserGroups] tg ON t.METemplateID = tg.FK_METemplateID
	INNER JOIN [dbo].[MEEmrTypeTemplates] typeT ON typeT.FK_METemplateID = t.METemplateID
	INNER JOIN [dbo].[MEEmrTypes] typeEmr ON typeEmr.MEEmrTypeID = typeT.FK_MEEmrTypeID
	WHERE t.AAStatus = 'Alive'
		AND t.METemplateType = @METemplateType
		AND tg.FK_ADUserGroupID = @FK_ADUserGroupID
		AND tg.[AAStatus] = 'Alive'
		AND typeT.[AAStatus] = 'Alive'
		AND typeEmr.[AAStatus] = 'Alive'
		AND typeEmr.[MEEmrTypeID] = @FK_MEEmrTypeID
END
GO

-- sp_helpindex '[dbo].[METemplates]'
IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'IX_AAStatus_METemplateType' AND object_id = OBJECT_ID('METemplates'))
BEGIN
	CREATE NONCLUSTERED INDEX IX_AAStatus_METemplateType ON METemplates(AAStatus, METemplateType);
END
GO






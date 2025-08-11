GO

/****** Object:  StoredProcedure [dbo].[METemplates_GetTemplatesByTypeAndEmrType]    Script Date: 8/29/2021 10:14:46 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER     PROCEDURE [dbo].[METemplates_GetTemplatesByTypeAndEmrType] 
	@METemplateType VARCHAR(50)
	,@FK_MEEmrTypeID INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT t.*
	FROM [dbo].[METemplates] t
	INNER JOIN [dbo].[MEEmrTypeTemplates] typeT ON typeT.FK_METemplateID = t.METemplateID
	INNER JOIN [dbo].[MEEmrTypes] typeEmr ON typeEmr.MEEmrTypeID = typeT.FK_MEEmrTypeID
	WHERE t.AAStatus = 'Alive'
		AND typeT.[AAStatus] = 'Alive'
		AND typeEmr.[AAStatus] = 'Alive'
		AND t.METemplateType = @METemplateType
		AND typeEmr.[MEEmrTypeID] = @FK_MEEmrTypeID
END
GO



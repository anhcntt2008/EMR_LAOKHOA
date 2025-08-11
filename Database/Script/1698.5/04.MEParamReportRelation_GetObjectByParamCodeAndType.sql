GO

/****** Object:  StoredProcedure [dbo].[MEParamReportRelation_GetObjectByParamCodeAndType]    Script Date: 9/15/2021 10:52:25 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE OR ALTER   PROCEDURE [dbo].[MEParamReportRelation_GetObjectByParamCodeAndType] 
	@MEParamNo VARCHAR(50)
	,@FK_MEEmrTypeID INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT pr.*
	FROM [dbo].[MEParamReportRelations] pr
	INNER JOIN [dbo].[MEParams] p ON p.MEParamID = pr.FK_MEParamID
	INNER JOIN [dbo].[MEEmrTypes] te ON te.MEEmrTypeID = pr.FK_MEEmrTypeID
	WHERE pr.AAStatus = 'Alive'
		AND p.[AAStatus] = 'Alive'
		AND te.[AAStatus] = 'Alive'
		AND p.MEParamMode= 'Report'
		AND p.MEParamNo = @MEParamNo
		AND te.[MEEmrTypeID] = @FK_MEEmrTypeID
END
GO

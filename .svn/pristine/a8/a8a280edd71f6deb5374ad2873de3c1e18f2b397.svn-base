GO

/****** Object:  StoredProcedure [dbo].[MEParamLookupDatas_GetAllObjectByNo]    Script Date: 8/29/2021 10:14:46 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[MEParamLookupDatas_GetAllObjectByNo] 
	@MEParamLookupNo VARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT d.*
	FROM [dbo].[MEParamLookupDatas] d
	INNER JOIN [dbo].[MEParamLookups] l on l.MEParamLookupID = d.FK_MEParamLookupID
	WHERE d.AAStatus = 'Alive' AND l.AAStatus = 'Alive'
		AND l.MEParamLookupNo = @MEParamLookupNo
END
GO



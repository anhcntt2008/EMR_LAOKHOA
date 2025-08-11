GO

/****** Object:  StoredProcedure [dbo].[MEParams_GetAllByMode]    Script Date: 8/29/2021 10:14:46 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER     PROCEDURE [dbo].[MEParams_GetAllByMode] 
	@MEParamMode NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM [dbo].[MEParams]
	WHERE AAStatus = 'Alive'
		AND MEParamMode = @MEParamMode
END
GO



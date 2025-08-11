GO

/****** Object:  StoredProcedure [dbo].[MEEmrs_GetInactiveEmr]    Script Date: 25/01/2021 10:37:55 SA ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[MEEmrs_GetInactiveEmr] @MEEmrID INT
AS
BEGIN
	SET NOCOUNT ON
	SELECT *
	FROM [dbo].[MEEmrs]
	WHERE [AAStatus] = 'Delete'
		AND [MEEmrID] = @MEEmrID
END
GO



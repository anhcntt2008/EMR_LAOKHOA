GO

/****** Object:  StoredProcedure [dbo].[GEObjectHistory_SelectByObjectNameAndObjectID]    Script Date: 7/7/2021 8:33:00 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[GEObjectHistory_SelectByObjectNameAndUserID] 
	-- Add the parameters for the stored procedure here
	@GEObjectHistoryObjectName nvarchar(50),
	@UserID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT g.* FROM [dbo].[GEObjectHistory] g
	INNER JOIN dbo.MEEmrs e ON e.MEEmrID = g.GEObjectHistoryObjectID
	WHERE g.AAStatus='Alive' AND g.[GEObjectHistoryObjectName]=@GEObjectHistoryObjectName
		AND e.FK_MEPatientID = @UserID
END
GO



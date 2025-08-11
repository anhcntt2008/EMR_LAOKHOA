GO

/****** Object:  StoredProcedure [dbo].[MEEmrSums_GetObjectByEmr]    Script Date: 9/8/2021 7:54:30 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE OR ALTER     PROCEDURE [dbo].[MEEmrSums_GetObjectByEmr] 
	-- Add the parameters for the stored procedure here
	@FK_MEEmrID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select TOP 1 * from MEEmrSums
	WHERE AAStatus = 'Alive' and MEEmrSumStatus = 'Active'
	AND FK_MEEmrID = @FK_MEEmrID
END
GO



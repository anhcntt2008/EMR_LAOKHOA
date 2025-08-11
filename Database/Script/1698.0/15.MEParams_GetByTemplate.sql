GO

/****** Object:  StoredProcedure [dbo].[MEParams_GetByTemplate]    Script Date: 8/26/2021 9:37:06 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER   PROCEDURE [dbo].[MEParams_GetByTemplate] 
	-- Add the parameters for the stored procedure here
	@FK_METemplateID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select mp.* from MEParams mp 
	INNER JOIN METemplateParams mtp ON mp.MEParamID = mtp.FK_MEParamID
	WHERE mp.AAStatus = 'Alive' AND mtp.AAStatus = 'Alive'
	AND mtp.FK_METemplateID = @FK_METemplateID
END
GO



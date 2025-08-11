GO

/****** Object:  StoredProcedure [dbo].[MEParams_GetByTemplateAndMode]    Script Date: 9/8/2021 7:54:30 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE OR ALTER     PROCEDURE [dbo].[MEParams_GetByTemplateAndMode] 
	-- Add the parameters for the stored procedure here
	@FK_METemplateID int,
	@MEParamMode nvarchar(50)
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
	AND mp.MEParamMode = @MEParamMode
END
GO



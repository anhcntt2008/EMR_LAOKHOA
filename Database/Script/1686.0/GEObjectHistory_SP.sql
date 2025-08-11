GO
/****** Object:  StoredProcedure [dbo].[GEObjectHistory_SelectByObjectNameAndObjectID]    Script Date: 4/20/2020 10:25:59 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<XuanTM>
-- Create date: <23/04/2020>
-- Description:	<US263>
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[GEObjectHistory_SelectByObjectNameAndObjectID] 
	-- Add the parameters for the stored procedure here
	@GEObjectHistoryObjectName nvarchar(50),
	@GEObjectHistoryObjectID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM [dbo].[GEObjectHistory]
	WHERE ([GEObjectHistoryObjectName]=@GEObjectHistoryObjectName)
		AND
		([GEObjectHistoryObjectID]=@GEObjectHistoryObjectID)
END
GO



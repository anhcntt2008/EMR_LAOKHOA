GO

/****** Object:  StoredProcedure [dbo].[GEObjectHistory_GetLatestHistoryByActionStatus]    Script Date: 3/24/2021 10:11:52 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		XuanTM
-- Create date: 24/03/2021
-- Description:	Get latest history base GEObjectHistoryStatus
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[GEObjectHistory_GetLatestHistoryByActionStatus] 
	@GEObjectHistoryObjectName NVARCHAR(50)
	,@GEObjectHistoryObjectId INT
	,@action NVARCHAR(50)
	,@status NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP 1 oh.*
	FROM [dbo].[GEObjectHistory] oh
	WHERE oh.AAStatus = 'Alive'
		AND oh.GEObjectHistoryObjectName = @GEObjectHistoryObjectName
		AND oh.GEObjectHistoryObjectID = @GEObjectHistoryObjectId
		AND oh.GEObjectHistoryAction = @action
		AND oh.GEObjectHistoryStatus = @status
	ORDER BY oh.GEObjectHistoryDate DESC
END
GO



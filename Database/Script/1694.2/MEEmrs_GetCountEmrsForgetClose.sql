GO
/****** Object:  StoredProcedure [dbo].[MEEmrs_GetCountEmrsForgetClose]    Script Date: 3/19/2021 3:01:31 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER
 PROCEDURE [dbo].[MEEmrs_GetCountEmrsForgetClose] @RemainDays INT
AS
BEGIN
	SET NOCOUNT ON

	SELECT COUNT(*)
	FROM [dbo].[MEEmrs] e
	INNER JOIN [GEObjectHistory] h ON e.[MEEmrID] = h.[GEObjectHistoryObjectID]
	WHERE e.[AAStatus] = 'Alive'
		AND e.[MEEmrStatus] = 'InProgress'
		AND h.[AAStatus] = 'Alive'
		AND h.[GEObjectHistoryObjectName] = 'MEEmrs'
		AND h.[GEObjectHistoryAction] = 'ReOpen'
		AND DATEDIFF(DAY, h.[GEObjectHistoryDate], GETDATE()) >= @RemainDays
END
GO



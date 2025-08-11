GO
/****** Object:  StoredProcedure [dbo].[MEEmrShareHistories_UpdateAllInactive]    Script Date: 7/3/2020 2:38:09 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- ======================================================================
-- Author: XuanTM
-- Return 1 if take success
-- ======================================================================
CREATE OR ALTER   PROCEDURE [dbo].[MEEmrShareHistories_UpdateAllInactive]
	@FK_MEEmrID INT
AS
BEGIN
	SET NOCOUNT ON

	BEGIN TRANSACTION;

	SAVE TRANSACTION MySavePoint;

	BEGIN TRY
		UPDATE [MEEmrShareHistories]
		SET MEEmrShareHistoryActive = 0
		WHERE FK_MEEmrID = @FK_MEEmrID

		SELECT 1 AS result
	END TRY

	BEGIN CATCH
		IF @@TRANCOUNT > 0
		BEGIN
			SELECT 0 AS result
			ROLLBACK TRANSACTION MySavePoint;
		END
	END CATCH

	COMMIT TRANSACTION
END
GO



GO
/****** Object:  StoredProcedure [dbo].[MEEmrDocuments_TakeEditingPermissionV2]    Script Date: 5/13/2020 10:50:44 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- ======================================================================
-- Author: UtHV
-- Release all document, that user keep and take other document
-- Return empty string if take success, otherwise name of the doctor who keep
-- V2 28/10/2019 add @MEEmrDocumentHoldMachineMac param, add @MEEmrDocumentHoldMachineIp param,
-- ======================================================================
CREATE OR ALTER PROCEDURE [dbo].[MEEmrDocuments_TakeEditingPermissionV2] @MEEmrDocumentID INT
	,@FK_EditingUserID INT
	,@MEEmrDocumentHoldMachineMac VARCHAR(30)
	,@MEEmrDocumentHoldMachineIp VARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON

	BEGIN TRANSACTION;

	SAVE TRANSACTION MySavePoint;

	DECLARE @EditingId INT = 0;
	DECLARE @HoldFrom DATETIME;
	DECLARE @Ip VARCHAR(50);

	BEGIN TRY
		-- release all handled
		UPDATE [dbo].[MEEmrDocuments]
		SET [FK_EditingUserID] = 0
			,[MEEmrDocumentHoldFrom] = dbo.fn_max_date()
			,MEEmrDocumentHoldMachineMac = NULL
			,MEEmrDocumentHoldMachineIp = NULL
		WHERE [FK_EditingUserID] = @FK_EditingUserID
			AND ( MEEmrDocumentHoldMachineMac = @MEEmrDocumentHoldMachineMac
				--OR MEEmrDocumentHoldMachineMac IS NULL -- TODO remove after running a week
			)
			AND AAStatus = 'Alive'

		-- take permission
		SELECT @EditingId = FK_EditingUserID
			,@HoldFrom = [MEEmrDocumentHoldFrom]
			,@Ip = [MEEmrDocumentHoldMachineIp]
		FROM [dbo].[MEEmrDocuments]
		WHERE MEEmrDocumentID = @MEEmrDocumentID

		IF @EditingId = 0
			OR @EditingId IS NULL
		BEGIN
			UPDATE [dbo].[MEEmrDocuments]
			SET [FK_EditingUserID] = @FK_EditingUserID
				,[MEEmrDocumentHoldFrom] = GETDATE()
				,MEEmrDocumentHoldMachineMac = @MEEmrDocumentHoldMachineMac
				,MEEmrDocumentHoldMachineIp = @MEEmrDocumentHoldMachineIp
			WHERE MEEmrDocumentID = @MEEmrDocumentID
				AND AAStatus = 'Alive'

			SELECT NULL AS HREmployeeName
		END
		ELSE
		BEGIN
			SELECT CONCAT (
					HREmployeeName
					,' ('
					,@Ip
					,N') từ lúc '
					,CONVERT(VARCHAR(5), @HoldFrom, 8)
					,' '
					,CONVERT(VARCHAR, @HoldFrom, 101)
					)
			FROM HREmployees
			WHERE HREmployeeID = @EditingId
		END
	END TRY

	BEGIN CATCH
		IF @@TRANCOUNT > 0
		BEGIN
			ROLLBACK TRANSACTION MySavePoint;-- rollback to MySavePoint
		END
	END CATCH

	COMMIT TRANSACTION
END
GO



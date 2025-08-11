GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- ======================================================================
-- Author: XuanTM
-- Update template name, order document by emr, template index
-- Update release document effect: FK_EditingUserID = 0, Mac/Ip null
-- Return 1 if take success
-- ======================================================================
CREATE OR ALTER PROCEDURE [dbo].[MEEmrDocuments_UpdateByEmrTemplateIndex]
	@MEEmrID INT
	,@MEEmrDocumentGroup NVARCHAR(200)
	,@MEEmrDocumentOrder INT
	,@MEEmrDocumentGroupNew NVARCHAR(200)
	,@MEEmrDocumentOrderNew INT
AS
BEGIN
	SET NOCOUNT ON

	BEGIN TRANSACTION;

	SAVE TRANSACTION MySavePoint;

	BEGIN TRY
		UPDATE doc
		SET doc.MEEmrDocumentGroup = @MEEmrDocumentGroupNew
			,doc.MEEmrDocumentOrder =@MEEmrDocumentOrderNew
			,doc.FK_EditingUserID = 0
			,doc.MEEmrDocumentHoldFrom = dbo.fn_max_date()
			,doc.MEEmrDocumentHoldMachineMac = NULL
			,doc.MEEmrDocumentHoldMachineIp = NULL
		FROM [dbo].[MEEmrDocuments] doc 
		INNER JOIN [dbo].[MEEmrs] emr ON doc.FK_MEEmrID = emr.MEEmrID
		WHERE doc.AAStatus = 'Alive' AND emr.AAStatus = 'Alive' 
		AND emr.MEEmrStatus = 'InProgress' AND emr.MEEmrID = @MEEmrID 
		AND doc.MEEmrDocumentGroup = @MEEmrDocumentGroup AND doc.MEEmrDocumentOrder = @MEEmrDocumentOrder

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



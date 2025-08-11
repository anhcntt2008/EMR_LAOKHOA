GO
/****** Object:  StoredProcedure [dbo].[MEEmrDocuments_GetObjectByEmrAndFile]    Script Date: 7/24/2020 9:50:40 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[MEEmrDocuments_GetObjectByEmrAndFile] 
@FK_MEEmrID INT,
@MEEmrDocumentFile NVARCHAR(1024),
@MEEmrDocumentFileExt VARCHAR(10)
AS
BEGIN
	SET NOCOUNT ON

	SELECT *
	FROM [dbo].[MEEmrDocuments]
	WHERE [AAStatus] = 'Alive'
		AND [FK_MEEmrID] = @FK_MEEmrID
		AND [MEEmrDocumentFile] = @MEEmrDocumentFile
		AND [MEEmrDocumentFileExt] = @MEEmrDocumentFileExt
END
GO



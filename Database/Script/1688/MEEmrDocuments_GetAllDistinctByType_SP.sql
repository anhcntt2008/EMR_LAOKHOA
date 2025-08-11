GO
/****** Object:  StoredProcedure [dbo].[MEEmrDocuments_GetAllDistinctByType]    Script Date: 5/15/2020 2:13:09 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		XuanTM
-- Create date: 15/05/2020
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[MEEmrDocuments_GetAllDistinctByType]
	@FK_MEEmrTypeID	int
AS
BEGIN
	set nocount on;
	SELECT DISTINCT doc.FK_METemplateID, doc.MEEmrDocumentGroup, doc.MEEmrDocumentOrder
	FROM [dbo].[MEEmrDocuments] doc
	INNER JOIN [dbo].[MEEmrs] emr ON doc.FK_MEEmrID = emr.MEEmrID
	WHERE doc.AAStatus = 'Alive' AND emr.AAStatus = 'Alive' AND emr.MEEmrStatus = 'InProgress'
	AND doc.MEEmrDocumentGroup !='' AND	emr.FK_MEEmrTypeID = @FK_MEEmrTypeID
END
GO



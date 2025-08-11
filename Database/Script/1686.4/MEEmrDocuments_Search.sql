GO

/****** Object:  StoredProcedure [dbo].[MEEmrDocuments_Search]    Script Date: 6/1/2020 1:57:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- ======================================================================
-- Create By: XuanTM	
-- Search documents by created date
-- ======================================================================

CREATE OR ALTER PROCEDURE [dbo].[MEEmrDocuments_Search]
	@MEEmrDocumentCreatedDateFrom [datetime] ,
	@MEEmrDocumentCreatedDateTo [datetime]
AS
BEGIN
SET NOCOUNT ON
	SELECT * FROM [dbo].[MEEmrDocuments]
	WHERE [AAStatus]='Alive' AND (CONVERT(date,MEEmrDocumentCreatedDate) BETWEEN @MEEmrDocumentCreatedDateFrom AND @MEEmrDocumentCreatedDateTo)
END 
GO




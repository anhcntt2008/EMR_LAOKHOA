GO
/****** Object:  StoredProcedure [dbo].[MEEmrDocuments_GetByEmrAndStatus]    Script Date: 6/5/2020 1:57:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ======================================================================
-- Create By: XuanTM	
-- Search documents by emrid and status
-- ======================================================================

CREATE OR ALTER   PROCEDURE [dbo].[MEEmrDocuments_GetByEmrAndStatus]
	@FK_MEEmrID int,
	@Status NVARCHAR(4000)
AS
BEGIN
SET NOCOUNT ON
	SELECT * FROM [dbo].[MEEmrDocuments]
	WHERE [AAStatus]='Alive' 
	AND [FK_MEEmrID]=@FK_MEEmrID 
	AND MEEmrDocumentStatus IN (SELECT [Name] FROM splitName2(@Status,','))
END 
GO


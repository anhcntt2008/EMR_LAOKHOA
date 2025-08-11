GO
/****** Object:  StoredProcedure [dbo].[MEEmrDocuments_SearchV2]    Script Date: 18/05/2021 8:39:19 SA ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[MEEmrDocuments_SearchV2]
	@MEEmrDocumentCreatedDateFrom [datetime] ,
	@MEEmrDocumentCreatedDateTo [datetime],
	@METemplateIDs varchar(1000)-- Mau BA
AS
BEGIN
SET NOCOUNT ON
	SET @METemplateIDs = ISNULL( @METemplateIDs,'-1')
	DECLARE @sql nvarchar(max)
	SET @sql = 'SELECT * FROM [dbo].[MEEmrDocuments]
	WHERE [AAStatus]=''Alive'' 
	AND (CONVERT(date,MEEmrDocumentCreatedDate) BETWEEN @MEEmrDocumentCreatedDateFrom AND @MEEmrDocumentCreatedDateTo)
	AND FK_METemplateID IN ( '+ @METemplateIDs + ' )
	'
	EXEC sys.sp_executesql @sql
	,N'@MEEmrDocumentCreatedDateFrom [datetime] ,
	@MEEmrDocumentCreatedDateTo [datetime]'
	,@MEEmrDocumentCreatedDateFrom,
	@MEEmrDocumentCreatedDateTo
END
GO





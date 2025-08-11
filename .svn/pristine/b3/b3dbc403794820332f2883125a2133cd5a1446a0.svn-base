GO

/****** Object:  StoredProcedure [dbo].[GEObjectHistory_SelectByObjectNameAndObjectID]    Script Date: 7/7/2021 8:34:59 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[GEObjectHistory_Search] 
	-- Add the parameters for the stored procedure here
	@GEObjectHistoryObjectName nvarchar(50),
	@GEObjectHistoryObjectNumber nvarchar(50),
    @GEObjectHistoryDateFrom date,
    @GEObjectHistoryDateTo date,
    @GEObjectHistoryAction varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @stAction nvarchar(80) = ''
	IF (@GEObjectHistoryAction != '')
	BEGIN
		SET @stAction = ' AND GEObjectHistoryAction = @GEObjectHistoryAction '
	END

	DECLARE @sql nvarchar(max)
	SET @sql = '
			WITH query AS (
				SELECT *
				, ROW_NUMBER() OVER (ORDER BY GEObjectHistoryID DESC) AS RowIndex
				FROM [dbo].[GEObjectHistory] 
				WHERE 
					(GEObjectHistoryObjectNumber IS NULL OR GEObjectHistoryObjectNumber like CONCAT( ''%'' , @GEObjectHistoryObjectNumber , ''%''))
					AND [AAStatus]=''Alive'' AND GEObjectHistoryObjectName = @GEObjectHistoryObjectName
					AND (CONVERT(date,GEObjectHistoryDate) BETWEEN @GEObjectHistoryDateFrom AND @GEObjectHistoryDateTo)
					' + @stAction +
					')

				SELECT *
				FROM query
				CROSS APPLY
				(
					SElECT COUNT (*) AS TotalRows FROM query
				)  tmp
				WHERE RowIndex > 0
				AND RowIndex <= 10000
				'

	EXEC sys.sp_executesql @sql
	,N'@GEObjectHistoryObjectName nvarchar(50), @GEObjectHistoryObjectNumber nvarchar(50), @GEObjectHistoryDateFrom date, @GEObjectHistoryDateTo date, @GEObjectHistoryAction varchar(50)'
	,@GEObjectHistoryObjectName
	,@GEObjectHistoryObjectNumber
	,@GEObjectHistoryDateFrom
	,@GEObjectHistoryDateTo
	,@GEObjectHistoryAction

END
GO



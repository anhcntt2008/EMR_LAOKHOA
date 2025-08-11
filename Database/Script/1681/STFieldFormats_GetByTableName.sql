-- =============================================
-- Author:	UTHV
-- =============================================
CREATE PROCEDURE [dbo].[STFieldFormats_GetByTableName] @TableName VARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT ff.*
	FROM [dbo].[STFieldFormats] ff
	WHERE ff.STFieldFormatTableName = @TableName
END

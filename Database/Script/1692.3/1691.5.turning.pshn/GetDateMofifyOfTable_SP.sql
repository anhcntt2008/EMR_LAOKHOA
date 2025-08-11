GO
/****** Object:  StoredProcedure [dbo].[GetDateMofifyOfTable]    Script Date: 10/23/2020 2:30:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [dbo].[GetDateMofifyOfTable]   
	@TableName VARCHAR(128)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @created DATETIME
	DECLARE @updated DATETIME

	DECLARE @template NVARCHAR(128)
	SET @template = 'SELECT @Result = MAX(AACreatedDate) FROM '+ @TableName +' WHERE AACreatedDate < ''9999-12-31'''
	EXEC sp_executesql @template, N'@Result DATETIME OUT', @created OUT

	SET @template = 'SELECT @Result = MAX(AAUpdatedDate) FROM '+ @TableName +' WHERE AAUpdatedDate < ''9999-12-31'''
	EXEC sp_executesql @template, N'@Result DATETIME OUT', @updated OUT

	IF @created >= @updated
	BEGIN
		SELECT @created
	END
	ELSE
	BEGIN
		SELECT @updated
	END
END



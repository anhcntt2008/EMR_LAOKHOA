GO
/****** Object:  StoredProcedure [dbo].[GetDateMofifyOfTableByMaxId]    Script Date: 10/23/2020 2:30:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [dbo].[GetDateMofifyOfTableByMaxId]   
	@TableName VARCHAR(128),
	@PrimaryKey VARCHAR(128),
	@MaxId INT
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @output DATETIME
	DECLARE @maxIdDb INT
	DECLARE @template NVARCHAR(128)
	SET @template = 'SELECT @Result = MAX('+ @PrimaryKey +') FROM '+ @TableName +''
	EXEC sp_executesql @template, N'@Result INT OUT', @maxIdDb OUT

	IF @MaxId = @maxIdDb
	BEGIN
		DECLARE @getDate NVARCHAR(128)
		SET @getDate = 'SELECT MAX(AAUpdatedDate) from '+ @TableName +' WHERE AAUpdatedDate < ''9999-12-31'''
		EXEC sp_executesql @getDate, N'@Result DATETIME OUT', @output OUT
	END
	ELSE
	BEGIN
		SET @output = (SELECT cast('12/31/9999 23:59:59.998' as datetime))
	END
	SELECT @output
END



GO

/****** Object:  UserDefinedFunction [dbo].[splitName2]    Script Date: 6/5/2020 2:12:16 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER FUNCTION [dbo].[splitName2](@stringToSplit NVARCHAR(MAX), @character NVARCHAR(10))
RETURNS
 @returnList TABLE ([Name] [nvarchar] (500), idx int)
AS
BEGIN

 DECLARE @name NVARCHAR(255)
 DECLARE @pos INT
 DECLARE @idx INT = 0

 WHILE CHARINDEX(@character, @stringToSplit) > 0
 BEGIN
  SET @idx= @idx + 1
  SELECT @pos  = CHARINDEX(@character, @stringToSplit)  
  SELECT @name = SUBSTRING(@stringToSplit, 1, @pos-1)

  INSERT INTO @returnList 
  SELECT @name, @idx
  SELECT @stringToSplit = SUBSTRING(@stringToSplit, @pos+1, LEN(@stringToSplit)-@pos)
 END
  SET @idx= @idx + 1
 INSERT INTO @returnList SELECT @stringToSplit, @idx

 RETURN
END

GO
--select * from splitName2('Inprocess,New',',')


GO

/****** Object:  StoredProcedure [dbo].[ADSystemConfigs_SelectByGroup]    Script Date: 8/21/2023 11:05:46 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[ADSystemConfigs_SelectByGroup] @ADSystemConfigGroup VARCHAR(100)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [dbo].[ADSystemConfigs]
	WHERE [AAStatus] = 'Alive' AND [ADSystemConfigGroup] = @ADSystemConfigGroup
END
GO



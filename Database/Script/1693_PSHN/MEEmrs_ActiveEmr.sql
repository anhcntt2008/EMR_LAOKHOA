GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[MEEmrs_ActiveEmr] @MEEmrID INT
, @AAUpdatedUser nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE [dbo].[MEEmrs]
	SET [AAStatus] = 'Alive', AAUpdatedUser = @AAUpdatedUser, AAUpdatedDate = GETDATE()
	WHERE [MEEmrID] = @MEEmrID
END
GO




/****** Object:  StoredProcedure [dbo].[MEEmrs_ActiveEmr]    Script Date: 8/11/2022 2:25:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER   PROCEDURE [dbo].[MEEmrDocuments_Active] @MEEmrID INT
, @AAUpdatedUser nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE [dbo].[MEEmrDocuments]
	SET [AAStatus] = 'Alive', AAUpdatedUser = @AAUpdatedUser, AAUpdatedDate = GETDATE()
	WHERE [FK_MEEmrID] = @MEEmrID
END

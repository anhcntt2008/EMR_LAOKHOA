GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[MEPatients_ActivePatient] @MEPatientID INT
, @AAUpdatedUser nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE [dbo].[MEPatients]
	SET [AAStatus] = 'Alive', AAUpdatedUser = @AAUpdatedUser, AAUpdatedDate = GETDATE()
	WHERE [MEPatientID] = @MEPatientID
END
GO



CREATE PROCEDURE [dbo].MEEmrs_GetEmrPatientProfile @FK_MEPatientID INT
AS
BEGIN
	SET NOCOUNT ON

	SELECT TOP 1 *
	FROM [dbo].[MEEmrs] e
	INNER JOIN MEEmrTypes t ON e.FK_MEEmrTypeID = t.MEEmrTypeID
	WHERE e.[FK_MEPatientID] = @FK_MEPatientID
		AND e.[AAStatus] = 'Alive'
		AND t.MEEmrTypeIsPatientProfile = 1
END

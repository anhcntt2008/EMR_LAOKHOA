GO

/****** Object:  StoredProcedure [dbo].[MEEmrs_GetEmrsForgetClose]    Script Date: 3/19/2021 3:02:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER
 PROCEDURE [dbo].[MEEmrs_GetEmrsForgetClose] @RemainDays INT
AS
BEGIN
	SET NOCOUNT ON

	SELECT e.*
		,p.MEPatientNo
		,p.MEPatientName
		,p.MEPatientContactCellPhone
		,e.FK_HRDepartmentID AS FK_HRDepartmentShortID
		,p.MEPatientBirthday
		,DATEPART(year, p.MEPatientBirthday) AS MEPatientBirthYear
		,'' AS MEEmrArchiveStatus
		,ROW_NUMBER() OVER (
			ORDER BY e.MEEmrID DESC
			) AS RowIndex
	FROM [dbo].[MEEmrs] e
	INNER JOIN [dbo].[MEPatients] p ON e.FK_MEPatientID = p.MEPatientID
	INNER JOIN [GEObjectHistory] h ON e.[MEEmrID] = h.[GEObjectHistoryObjectID]
	WHERE e.[AAStatus] = 'Alive'
		AND e.[MEEmrStatus] = 'InProgress'
		AND p.[AAStatus] = 'Alive'
		AND h.[AAStatus] = 'Alive'
		AND h.[GEObjectHistoryObjectName] = 'MEEmrs'
		AND h.[GEObjectHistoryAction] = 'ReOpen'
		AND DATEDIFF(DAY, h.[GEObjectHistoryDate], GETDATE()) >= @RemainDays
END
GO



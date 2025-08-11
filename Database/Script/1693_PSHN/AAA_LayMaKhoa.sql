
CREATE OR ALTER PROCEDURE [dbo].[AAA_LayMaKhoa]
@patientNo nvarchar(50),
@emrNo nvarchar(50),
@documentNo nvarchar(50),
@documentDate nvarchar(50),
@gid nvarchar(50),
@tid nvarchar(50),
@CaseNo nvarchar(50)
AS
BEGIN
	SELECT HRDepartmentNo as 'khoa_matat'
	FROM MEEmrs me
	INNER JOIN HRDepartments dept on dept.HRDepartmentID = me.FK_HRDepartmentID
	WHERE me.MEEmrNo = @emrNo
	AND me.AAStatus = 'Alive'
	AND dept.AAStatus = 'Alive'
END
GO

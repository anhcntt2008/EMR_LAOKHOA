
-- =============================================
-- Author:		UtHV
-- Create date: 13062017
-- Description:	in phieu dang ky kham benh
-- =============================================
ALTER PROCEDURE [dbo].[Report_MEPatientRegistrationByVisitID]
	@MEPatientVisitID   		int
AS
BEGIN	
	SET NOCOUNT ON;
	
	select	 pv.*
			, pt.MEPatientNo
			, pt.MEPatientName
			, pt.MEGender
			, pt.MEPatientBirthday
			, pt.MEPatientContactAddressLine1
			, CONCAT(
				dr.HRDepartmentRoomName
				, ' - '
				, d.HRDepartmentName) as HRDepartmentRoomName
			, (select UPPER(MEPatientInsNo + '-' + MEPatientInsRegisteredPlaceNo) from MEPatientInss where AAStatus = 'Alive' and MEPatientInsID = pv.FK_MEPatientInsID) as MEPatientInsNo
			, (select MEPatientInsRegisteredDate from MEPatientInss where AAStatus = 'Alive' and MEPatientInsID = pv.FK_MEPatientInsID) as MEPatientInsRegisteredDate
			, (select MEPatientInsExpiryDate from MEPatientInss where AAStatus = 'Alive' and MEPatientInsID = pv.FK_MEPatientInsID) as MEPatientInsExpiryDate
			,(case when pv.FK_MEInsLevelID > 0 then 'BHYT' else N'Dịch vụ' end) as MEPatientVisitObjectType
			, (select	il.MEInsLevelName
					from	[dbo].[MEInsLevels] il
					where	il.AAStatus = 'Alive'
					and		il.FK_MECompanyID = pv.FK_MECompanyID
					and		il.MEInsLevelID = pv.FK_MEInsLevelID						
					)	as	MEInsLevelName
	from	[dbo].[MEPatientVisits]		pv	inner join
			[dbo].[MEPatients]			pt	on pt.MEPatientID = pv.FK_MEPatientID	inner join
			[dbo].[HRDepartmentRooms]	dr	on dr.HRDepartmentRoomID = pv.FK_HRDepartmentRoomID inner join
			[dbo].[HRDepartments]		d	on dr.FK_HRDepartmentID = d.HRDepartmentID
	where	pv.AAStatus = 'Alive'
	and		pt.AAStatus = 'Alive'
	and		pv.MEPatientVisitID  = @MEPatientVisitID
END
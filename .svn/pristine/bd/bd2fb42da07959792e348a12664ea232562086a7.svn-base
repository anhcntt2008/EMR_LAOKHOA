


-- =============================================
-- Author:		Thao Tran
-- Create date: 09/27/2011
-- Description:	Get all medication items of a visit by visit medication ID
-- =============================================
ALTER PROCEDURE [dbo].[MEVisitMedicationItems_GetMedicationItemsByVisitMedicationID]
	@FK_MEVisitMedicationID		int
AS
BEGIN	
	SET NOCOUNT ON;

    select	vmi.*
		,	pro.ICProductName
		,	vm.MEVisitMedicationRemark
		,	vm.MEVisitMedicationFollowUpDate
		,	vm.MEVisitMedicationDoctorNote
		,	p.MEPatientNo
		,	p.MEPatientName
		,	p.MEPatientBirthday
		,	p.MEGender
		,	p.MEPatientContactAddressLine2
		,	e.HREmployeeName
		,	e.HREmployeeTel2
		,	mu.ICMeasureUnitName
		,	cv.ADConfigText as VisitMedicationItemRemark
		,	(	select	UPPER(pa.MEPatientInsNo)
			from	[dbo].[MEPatientInss]	pa
			where	pa.FK_MEPatientID	=	pv.FK_MEPatientID
			and		pa.FK_MECompanyID	=	pv.FK_MECompanyID
			and		pa.AAStatus			=	'Alive'
		)	as		MEPatientInsNo
		,	(	pv.MEPatientVisitICD10No + pv.MEPatientVisitDiagnosis + ' '
				+ ISNULL(pv.MEPatientVisitICD10No1,'') 
				+ ISNULL(pv.MEPatientVisitICD10Desc1,'') + ' '
				+ ISNULL(pv.MEPatientVisitICD10No2,'')
				+ ISNULL(pv.MEPatientVisitICD10Desc2,'') + ' '
				+ ISNULL(pv.MEPatientVisitICD10No3,'')
				+ ISNULL(pv.MEPatientVisitICD10Desc3,'')
			)	as		MEPatientVisitDiagnosis,
(case when pv.FK_MEInsLevelID > 0 then 'BHYT' else N'Dịch vụ' end) as MEPatientVisitType,
CONCAT(
				dp.HRDepartmentRoomName
				, ' - '
				, dr.HRDepartmentName) as MEVisitMedicationRoom
    from	[dbo].[MEVisitMedicationItems] vmi															inner join
			[dbo].[MEVisitMedications] vm		on vm.MEVisitMedicationID = vmi.FK_MEVisitMedicationID	inner join
			[dbo].[MEPatients] p				on p.MEPatientID = vm.FK_MEPatientID					inner join
			[dbo].[HREmployees] e				on e.HREmployeeID = vm.FK_HREmployeeID					left join
			[dbo].[ICProducts] pro				on pro.ICProductID = vmi.FK_ICProductID					left join
			[dbo].[ICMeasureUnits] mu			on mu.ICMeasureUnitID = pro.FK_ICProductSaleUnitID		left join
			[dbo].[MEPatientVisits] pv			on vm.FK_MEPatientVisitID = pv.MEPatientVisitID			left join
			[dbo].[ADConfigValues] cv			on cv.ADConfigKeyGroup = 'VisitMedicationItemRemark' and cv.ADConfigKeyValue = vmi.MEVisitMedicationItemRemarkCombo inner join
			[dbo].[HRDepartmentRooms]	dp	on dp.HRDepartmentRoomID = e.FK_HRDepartmentRoomID INNER JOIN
			[dbo].[HRDepartments]	dr	on dr.HRDepartmentID = e.FK_HRDepartmentID

	where	vmi.AAStatus = 'Alive'
	and		vm.AAStatus = 'Alive'
	and		vmi.FK_MEVisitMedicationID = @FK_MEVisitMedicationID
END
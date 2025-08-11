
-- =============================================
-- Author:		Toan Nguyen
-- Create date: 29/09/2011
-- Description:	Get patient's invoice
-- =============================================
ALTER PROCEDURE [dbo].[Report_GetPatientInvoiceByPatientVisitIDAndCustomerType]
	@FK_MEPatientVisitID		int		=	null	
AS
BEGIN
	set nocount on;
	
	select	ii.*
	,		i.*	
	,	(	select	p.ARPriceLevelName
			from	[dbo].[ARPriceLevels]	p
			where	p.ARPriceLevelID	=	i.FK_ARPriceLevelID
			and		p.AAStatus			=	'Alive'
		)	as		ARPriceLevelName
	--,	(	select	p.MEPatientVisitDiagnosis	
	--		from	[dbo].[MEPatientVisits]	p
	--		where	p.AAStatus	=	'Alive'
	--		and		p.MEPatientVisitID	=	@FK_MEPatientVisitID
	--	)	as		MEPatientVisitDiagnosis
	,	(	select	p.MEPatientVisitDate	
			from	[dbo].[MEPatientVisits]	p
			where	p.AAStatus	=	'Alive'
			and		p.MEPatientVisitID	=	@FK_MEPatientVisitID
		)	as		MEPatientVisitDate
	,	(	select	p.MEPatientVisitNo	
			from	[dbo].[MEPatientVisits]	p
			where	p.AAStatus	=	'Alive'
			and		p.MEPatientVisitID	=	@FK_MEPatientVisitID
		)	as		MEPatientVisitNo
	,	(	select	p.MEPatientVisitHealthInsuranceLine	
			from	[dbo].[MEPatientVisits]	p
			where	p.AAStatus	=	'Alive'
			and		p.MEPatientVisitID	=	@FK_MEPatientVisitID
		)	as		MEPatientVisitHealthInsuranceLine			
	,	(	select c.ADConfigText 
			from ADConfigValues c 
			where c.ADConfigKeyGroup = 'PatientVisitPatientInsRegion' 
			and c.ADConfigKeyValue = (select	p.MEPatientVisitPatientInsRegion 
									  from		[dbo].[MEPatientVisits] p 
									  where p.AAStatus			= 'Alive' 
									  and	p.MEPatientVisitID	=	@FK_MEPatientVisitID)
		)	as		MEPatientVisitPatientInsRegion		
	,   (	select s.MESpecialismName from MEPatientVisits v 
			inner join MESpecialisms s 
			on s.MESpecialismID = v.FK_MESpecialismID
			where v.MEPatientVisitID	=	@FK_MEPatientVisitID
		)	as		MESpecialismName
	,  (select BRBranchName from BRBranchs b where b.BRBranchID = pv.FK_BRBranchID) as HospitalName
	,	p.*
	,	(	select	c.MECompanyName
			from	[dbo].[MECompanys] c
			where	c.AAStatus = 'Alive'
			and		c.MECompanyID = i.FK_MECompanyID
		)	as	MECompanyName
	,	(	select	il.MEInsLevelNo
			from	[dbo].[MEInsLevels] il
			where	il.AAStatus = 'Alive'
			and		il.FK_MECompanyID = i.FK_MECompanyID
			and		il.MEInsLevelID = i.FK_MEInsLevelID						
		)	as	MEInsLevelNo
	,	(	select	il.MEInsLevelName
			from	[dbo].[MEInsLevels] il
			where	il.AAStatus = 'Alive'
			and		il.FK_MECompanyID = i.FK_MECompanyID
			and		il.MEInsLevelID = i.FK_MEInsLevelID						
		)	as	MEInsLevelName	
	--,	(	select	pa.MEPatientInsNo
	--		from	[dbo].[MEPatientInss]	pa
	--		where	pa.FK_MEPatientID	=	i.FK_MEPatientID
	--		and		pa.FK_MECompanyID	=	i.FK_MECompanyID
	--		--and		pa.FK_MEDefaultInsLevelID = i.FK_MEInsLevelID
	--		and		pa.AAStatus			=	'Alive'
	--	)	as		MEPatientInsNo
	,	(	select	pa.MEPatientInsNo
			from	[dbo].[MEPatientInss]	pa
			where	pa.MEPatientInsID = pv.FK_MEPatientInsID
			and		pa.AAStatus			=	'Alive'
		)	as		MEPatientInsNo
	,	(	select	pa.MEPatientInsRegisteredDate
			from	[dbo].[MEPatientInss]	pa
			where	pa.FK_MEPatientID	=	i.FK_MEPatientID
			and		pa.FK_MECompanyID	=	i.FK_MECompanyID
			--and		pa.FK_MEDefaultInsLevelID = i.FK_MEInsLevelID
			and		pa.AAStatus			=	'Alive'
		)	as		MEPatientInsRegisteredDate
	,	(	select	pa.MEPatientInsExpiryDate
			from	[dbo].[MEPatientInss]	pa
			where	pa.FK_MEPatientID	=	i.FK_MEPatientID
			and		pa.FK_MECompanyID	=	i.FK_MECompanyID
			--and		pa.FK_MEDefaultInsLevelID = i.FK_MEInsLevelID
			and		pa.AAStatus			=	'Alive'
		)	as		MEPatientInsExpiryDate
	,	(	select	pa.MEPatientInsRegisteredPlace
			from	[dbo].[MEPatientInss]	pa
			where	pa.FK_MEPatientID	=	i.FK_MEPatientID
			and		pa.FK_MECompanyID	=	i.FK_MECompanyID
			--and		pa.FK_MEDefaultInsLevelID = i.FK_MEInsLevelID
			and		pa.AAStatus			=	'Alive'
		)	as		MEPatientInsRegisteredPlace
	,	(	select	pa.MEPatientInsRegisteredPlaceNo
			from	[dbo].[MEPatientInss]	pa
			where	pa.FK_MEPatientID	=	i.FK_MEPatientID
			and		pa.FK_MECompanyID	=	i.FK_MECompanyID
			--and		pa.FK_MEDefaultInsLevelID = i.FK_MEInsLevelID
			and		pa.AAStatus			=	'Alive'
		)	as		MEPatientInsRegisteredPlaceNo		
	,	pr.ICProductNo
	,	pr.ICProductName
	,	(	select	c.ADConfigText
			from	[dbo].[ADConfigValues]	c
			where	c.ADConfigKeyValue	=	p.MEGender
			and		c.AAStatus			=	'Alive'
			and		c.ADConfigKeyGroup	=	'Gender'
		)	as		MEGenderText
	,	(	select	hr.HREmployeeName
			from	[dbo].[HREmployees]	hr
			where	hr.HREmployeeID		=	i.FK_ARSellerID
		)	as		HREmployeeName
	,	m.ICMeasureUnitName
	,	ROW_NUMBER()	over	(	order by	ii.ARInvoiceItemID	)	as	ARInvoiceItemRowNumber
	,	GETDATE()	as	InvoiceNowDate
	--,	c.ADConfigText
	,   NumOfTreatment = case DATEDIFF(day, (select p.MEPatientVisitDate from [dbo].[MEPatientVisits]	p where	p.AAStatus = 'Alive' and p.MEPatientVisitID	= @FK_MEPatientVisitID), i.ARInvoiceDate)
							when 0 then 1
							else DATEDIFF(day, (select p.MEPatientVisitDate from [dbo].[MEPatientVisits]	p where	p.AAStatus = 'Alive' and p.MEPatientVisitID	= @FK_MEPatientVisitID), i.ARInvoiceDate) end
	
	,	'ARInvoiceItemProductSubTypeGroup01BV' = case ii.ARInvoiceItemProductSubType 
											    when 'ExaminationFee' then N'1Khám bệnh' 
											    when 'ExplorationOfTheFunction' then N'2Dịch vụ kỹ thuật' 
											    when 'HighTechServices' then N'2Dịch vụ kỹ thuật' 
											    when 'Imaging' then N'3Chuẩn đoán hình ảnh'
											    when 'Lab' then N'4Xét nghiệm'
											    when 'Drugs' then N'5Thuốc, dịch truyền' 
											    when 'DrugsK' then N'5Thuốc, dịch truyền' 
											    when 'Infusion' then N'5Thuốc, dịch truyền' 
												else N'6Dịch vụ khác'
												end
	,	pv.MEPatientVisitICD10No
	,	i.ARInvoiceInsDeductRate
	,	(	pv.MEPatientVisitICD10No + pv.MEPatientVisitDiagnosis + ' '
		+ ISNULL(pv.MEPatientVisitICD10No1,'') 
		+ ISNULL(pv.MEPatientVisitICD10Desc1,'') + ' '
		+ ISNULL(pv.MEPatientVisitICD10No2,'')
		+ ISNULL(pv.MEPatientVisitICD10Desc2,'') + ' '
		+ ISNULL(pv.MEPatientVisitICD10No3,'')
		+ ISNULL(pv.MEPatientVisitICD10Desc3,'')
	)	as		MEPatientVisitDiagnosis
	from	[dbo].[ARInvoiceItems]	ii															inner join
			[dbo].[ARInvoices]		i	on	ii.FK_ARInvoiceID		=	i.ARInvoiceID			inner join
			[dbo].[MEPatientVisits] pv	on	i.FK_MEPatientVisitID	=	pv.MEPatientVisitID and i.AAStatus = 'Alive' inner join
			[dbo].[MEPatients]		p	on	i.FK_MEPatientID		=	p.MEPatientID			inner join			
			[dbo].[ICProducts]		pr	on	ii.FK_ICProductID		=	pr.ICProductID			inner join
			[dbo].[ICMeasureUnits]	m	on	ii.FK_ICMeasureUnitID	=	m.ICMeasureUnitID		left join
			[dbo].[ADConfigValues]  c   on  ii.ARInvoiceItemProductSubType	=	c.ADConfigKeyValue
										and c.ADConfigKeyGroup				=	'ProductSubType'
	where	ii.AAStatus						=	'Alive'
	and		i.AAStatus						=	'Alive'
	and		p.AAStatus						=	'Alive'	
	and		i.MECompanyType					=	'BN'
	and		i.FK_MEPatientVisitID			=	@FK_MEPatientVisitID
	and		ii.ARInvoiceItemPackageID		= 0
	and		ii.ARInvoiceItemNeedPrintOut	=	1
	and		ii.ARInvoiceItemInsDeductRate > 0
END
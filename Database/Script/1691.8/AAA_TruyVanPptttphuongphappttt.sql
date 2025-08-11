GO
/****** Object:  StoredProcedure [dbo].[AAA_TruyVanPptttphuongphappttt]    Script Date: 11/9/2020 3:08:32 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[AAA_TruyVanPptttphuongphappttt] 
	@patientNo NVARCHAR(50)
	,@emrNo NVARCHAR(50)
	,@documentNo NVARCHAR(50)
	,@documentDate NVARCHAR(50)
	,@gid NVARCHAR(50)
	,@tid NVARCHAR(50)
	,@CaseNo NVARCHAR(50)
AS
BEGIN
	
			select top 1 1 as pkey,
	'item' as type,
	year(MEPatientBirthday) as namsinh
	from MEPatients p 
	where p.AAStatus='Alive' and p.MEPatientNo=@patientNo
	
	select   'root' AS 'parent'
		,1 AS pkey
		,1 AS fkey
		,'list' AS type
		,'pptttphuongphappttt_array' AS param
		,d.MEParamLookupDataKey 
		,d.MEParamLookupDataGroup   
		,d.MEParamLookupDataGroup1
		,d.MEParamLookupDataGroup2		
		,d.MEParamLookupDataValue 
		,d.FK_METemplate1ID 
		,d.FK_METemplate2ID		
	FROM MEParamLookups l
	JOIN MEParamLookupDatas d ON l.MEParamLookupID = d.FK_MEParamLookupID
	WHERE l.AAStatus = 'Alive'
		AND d.AAStatus = 'Alive' and l.MEParamLookupNo='canh_bao_phac_do_dieu_tri_pptttphuongphappttt'
	
END
GO



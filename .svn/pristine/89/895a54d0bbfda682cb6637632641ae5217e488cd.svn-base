GO

/****** Object:  StoredProcedure [dbo].[MEEmrSums_Search]    Script Date: 9/7/2021 5:46:12 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE OR ALTER   PROCEDURE [dbo].[MEEmrSums_Search]
	@FK_HRDepartmentSearchID varchar(500),
    @MEEmrCreatedDateFrom date,
    @MEEmrCreatedDateTo date,
    @MEEmrNo varchar(50),
    @FK_MEEmrTypeID int,
    @MEEmrSumCode nvarchar(50),
    @MEEmrSumStoreCode nvarchar(50),
    @MEEmrSumStatus varchar(50)
AS
BEGIN
SET NOCOUNT ON
	SET @FK_HRDepartmentSearchID = ISNULL( @FK_HRDepartmentSearchID,'-1')
	
	DECLARE @sql nvarchar(max)
	SET @sql = 'SELECT TOP 100000 es.*
								, e.MEEmrNo
								, p.MEPatientNo
								, p.MEPatientName
								, p.MEPatientContactCellPhone
								, e.FK_HRDepartmentID as FK_HRDepartmentShortID
								, p.MEPatientBirthday
								, e.MEEmrDateIn
								, e.MEEmrDateOut
								, t.MEEmrTypeName
								, d.HRDepartmentName
								, e.MEEmrICDStrOut
				FROM MEEmrSums es
				INNER JOIN MEEmrs e ON e.MEEmrID = es.FK_MEEmrID
				INNER JOIN [dbo].[MEPatients] p ON e.FK_MEPatientID = p.MEPatientID
				INNER JOIN [dbo].[MEEmrTypes] t ON e.FK_MEEmrTypeID = t.MEEmrTypeID
				INNER JOIN [dbo].[HRDepartments] d ON d.HRDepartmentID = e.FK_HRDepartmentID
				WHERE es.AAStatus=''Alive'' AND e.AAStatus = ''Alive'' AND p.AAStatus = ''Alive''
				AND (CONVERT(date,e.MEEmrCreatedDate) BETWEEN @MEEmrCreatedDateFrom AND @MEEmrCreatedDateTo)
				AND (@MEEmrNo IS NULL OR e.MEEmrNo LIKE ''%'' + @MEEmrNo + ''%'')
				AND (@FK_MEEmrTypeID IS NULL OR e.FK_MEEmrTypeID = @FK_MEEmrTypeID)
				AND (@MEEmrSumCode IS NULL OR es.MEEmrSumCode LIKE ''%'' + @MEEmrSumCode + ''%'')
				AND (@MEEmrSumStoreCode IS NULL OR es.MEEmrSumStoreCode LIKE ''%'' + @MEEmrSumStoreCode + ''%'')
				AND (@MEEmrSumStatus IS NULL OR es.MEEmrSumStatus = @MEEmrSumStatus)
				AND (e.FK_HRDepartmentID IN ( '+ @FK_HRDepartmentSearchID + ' ))
				'
	EXEC sys.sp_executesql @sql
	,N'@MEEmrCreatedDateFrom date,
    @MEEmrCreatedDateTo date,
    @MEEmrNo varchar(50),
    @FK_MEEmrTypeID int,
    @MEEmrSumCode nvarchar(50),
    @MEEmrSumStoreCode nvarchar(50),
    @MEEmrSumStatus varchar(50)'
		,@MEEmrCreatedDateFrom,
		@MEEmrCreatedDateTo,
		@MEEmrNo,
		@FK_MEEmrTypeID,
		@MEEmrSumCode,
		@MEEmrSumStoreCode,
		@MEEmrSumStatus

END
GO



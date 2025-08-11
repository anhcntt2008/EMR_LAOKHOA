ALTER PROCEDURE[dbo].[MEEmrDocuments_GetByFK_MEEmrID]
	@FK_MEEmrID int
AS
BEGIN
SET NOCOUNT ON
SELECT
	d.*,
	/*(SELECT u.ADUserGroupName + '; ' AS [text()]
			FROM [dbo].[METemplateUserGroups] t inner join [dbo].[ADUserGroups] u on t.FK_ADUserGroupID = u.ADUserGroupID
			WHERE t.FK_METemplateID = d.FK_METemplateID and u.AAStatus = 'Alive' and t.AAStatus = 'Alive' 
			FOR XML PATH ('') ) as ADUserGroupNames,*/
	d.FK_HRDepartmentID as FK_HRDepartmentShortID, -- hien thi them cot khoa viet tat
	ISNULL(dn.Existed,0) as MEEmrDocumentHasNote
FROM
	[dbo].[MEEmrDocuments] d
	 OUTER APPLY (SELECT TOP 1 CAST(1 AS bit) AS Existed FROM MEEmrDocumentNotes n WHERE n.AAStatus='Alive' AND n.FK_MEEmrDocumentID = d.MEEmrDocumentID) dn
WHERE
	[FK_MEEmrID]=@FK_MEEmrID
	AND
		[AAStatus]='Alive'
END 

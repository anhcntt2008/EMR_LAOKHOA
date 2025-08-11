ALTER PROCEDURE [dbo].[MEEmrDocuments_GetByUserGroupWrite] @FK_MEEmrID INT
	,@FK_ADUserGroupID INT
AS
BEGIN
	SET NOCOUNT ON

	SELECT d.*
		/*,(
			SELECT u.ADUserGroupName + '; ' AS [text()]
			FROM [dbo].[METemplateUserGroups] t
			INNER JOIN [dbo].[ADUserGroups] u ON t.FK_ADUserGroupID = u.ADUserGroupID
			WHERE t.FK_METemplateID = d.FK_METemplateID
				AND u.AAStatus = 'Alive'
				AND t.AAStatus = 'Alive'
			FOR XML PATH('')
			) AS ADUserGroupNames*/
		,d.FK_HRDepartmentID AS FK_HRDepartmentShortID -- hien thi them cot khoa viet tat
		,ISNULL(dn.Existed, 0) AS MEEmrDocumentHasNote
	FROM [dbo].[MEEmrDocuments] d
	OUTER APPLY (
		SELECT TOP 1 CAST(1 AS BIT) AS Existed
		FROM MEEmrDocumentNotes n
		WHERE n.AAStatus = 'Alive'
			AND n.FK_MEEmrDocumentID = d.MEEmrDocumentID
		) dn
	WHERE [FK_MEEmrID] = @FK_MEEmrID
		AND d.[AAStatus] = 'Alive'
END

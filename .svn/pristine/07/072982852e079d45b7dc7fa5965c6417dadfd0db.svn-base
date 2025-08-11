
-- Lay template theo phan quyen de chen vao tai lieu
CREATE PROCEDURE [dbo].[METemplates_GetSubTemplateByRoleAndParentTemplate]
	@FK_METemplateID int,
	@Role varchar(100),
	@FK_HREmployeeShareID int,
	@FK_HRDepartmentShareID int

AS
BEGIN
SET NOCOUNT ON
SELECT 
	*
FROM
	[dbo].[METemplates]
WHERE
	AAStatus ='Alive'
	AND @FK_METemplateID = FK_METemplateID
	AND (@Role = 'admin'
		OR (	METemplateType = 'Sub' AND
				(FK_HREmployeeShareID = 0 OR FK_HREmployeeShareID = @FK_HREmployeeShareID)
				AND
				(FK_HRDepartmentShareID = 0 OR FK_HRDepartmentShareID = @FK_HRDepartmentShareID)
			)
	)
END

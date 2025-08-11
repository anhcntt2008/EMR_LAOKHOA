DROP PROCEDURE METemplates_GetFirstTemplateByParentAndType
GO
-- =============================================
-- Author:		UtHV
-- Created: 17/04/2020
-- =============================================
CREATE PROCEDURE [dbo].[METemplates_GetFirstTemplateByParentAndType] @METemplateType VARCHAR(50)
	,@FK_METemplateParentID INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP 1 t.*
	FROM [dbo].[METemplates] t
	WHERE t.AAStatus = 'Alive'
		AND t.METemplateType = @METemplateType
		AND t.FK_METemplateID = @FK_METemplateParentID
END

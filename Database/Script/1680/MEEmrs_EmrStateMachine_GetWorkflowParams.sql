SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<UtHV>
-- Create date: <12/02/2020>
-- Description:	<Lay params cho workflow EmrStateMachine>
-- =============================================
CREATE PROCEDURE MEEmrs_EmrStateMachine_GetWorkflowParams @TableName VARCHAR(250)
	,@ObjectID INT
	,@Action VARCHAR(250)
	,@ADUserID INT
	,@ADUserGroupID INT
	,@HREmployeeID INT
	,@FK_HRDepartmentID INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT @ADUserID AS ADUserID
		,@ADUserGroupID AS ADUserGroupID
		,@HREmployeeID AS HREmployeeID
		,@FK_HRDepartmentID AS FK_HRDepartmentID
END
GO



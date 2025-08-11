SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER FUNCTION ADUser_GetEmployeeEmrView (@FK_HREmployeeID INT)
RETURNS VARCHAR(100)
AS
BEGIN
	DECLARE @view VARCHAR(50) = 'Department';
	DECLARE @group INT = 0;

	SELECT @view = ISNULL(ADUserEmrView, 'Department')
		,@group = ADUserGroupID
	FROM ADUsers
	WHERE FK_HREmployeeID = @FK_HREmployeeID
		AND AAStatus = 'Alive'

	IF @view = 'All'
		RETURN @view

	SELECT @view = ISNULL(ADUserGroupEmrView, 'Department')
	FROM ADUserGroups
	WHERE ADUserGroupID = @group
		AND AAStatus = 'Alive'

	RETURN @view
END
GO



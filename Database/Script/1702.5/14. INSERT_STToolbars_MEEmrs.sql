--Workflow MEEmrs
DECLARE @STModuleID int
SET @STModuleID = (SELECT STModuleID FROM STModules WHERE AAStatus = 'alive' and STModuleName = 'MEEmr')
DECLARE @STToolbarParentID int
SET @STToolbarParentID = (SELECT STToolbarID FROM STToolbars WHERE AAStatus = 'alive' and STToolbarName = 'fld_barbtnEmrStateMachine')

DELETE
FROM [dbo].[STToolbarFunctions]
WHERE STToolbarFunctionName = 'TriggerWorkflow' and STToolbarID = (SELECT STToolbarID
		FROM [STToolbars]
		WHERE STToolbarName = 'fld_barbtnToWaitApprove' and STModuleID = @STModuleID)

DELETE
FROM [dbo].[STToolbars]
WHERE STToolbarName = 'fld_barbtnToWaitApprove' and STModuleID = @STModuleID

INSERT INTO [dbo].[STToolbars]
VALUES (
	(
		SELECT MAX(STToolbarID) + 1
		FROM [STToolbars]
		)
	,'Alive'
	,@STModuleID
	,1
	,N'fld_barbtnToWaitApprove'
	,N''
	,'ToWaitApprove'
	,'Default'
	,N'Chờ duyệt BHYT'
	,N'Workflow'
	,11
	,'0'
	,N''
	,@STToolbarParentID
	,N'images/scheduling/time_16x16.png'
	);

INSERT INTO [dbo].[STToolbarFunctions]
VALUES (
	(
		SELECT MAX(STToolbarFunctionID) + 1
		FROM [STToolbarFunctions]
		)
	,'0'
	,(
		SELECT STToolbarID
		FROM [STToolbars]
		WHERE STToolbarName = 'fld_barbtnToWaitApprove' and STModuleID = @STModuleID
		)
	,'TriggerWorkflow'
	,'Void TriggerWorkflow(System.Object,System.String,System.Object)'
	,'BOSERP.Modules.MEEmr.MEEmrModule'
	,1
	);

DELETE
FROM [dbo].[STToolbarFunctions]
WHERE STToolbarFunctionName = 'TriggerWorkflow' and STToolbarID = (SELECT STToolbarID
		FROM [STToolbars]
		WHERE STToolbarName = 'fld_barbtnApproved' and STModuleID = @STModuleID)

DELETE
FROM [dbo].[STToolbars]
WHERE STToolbarName = 'fld_barbtnApproved' and STModuleID = @STModuleID

INSERT INTO [dbo].[STToolbars]
VALUES (
	(
		SELECT MAX(STToolbarID) + 1
		FROM [STToolbars]
		)
	,'Alive'
	,@STModuleID
	,1
	,N'fld_barbtnApproved'
	,N''
	,'Approved'
	,'Default'
	,N'Duyệt BHYT'
	,N'Workflow'
	,11
	,'0'
	,N''
	,@STToolbarParentID
	,N'images/edit/edit_16x16.png'
	);

INSERT INTO [dbo].[STToolbarFunctions]
VALUES (
	(
		SELECT MAX(STToolbarFunctionID) + 1
		FROM [STToolbarFunctions]
		)
	,'0'
	,(
		SELECT STToolbarID
		FROM [STToolbars]
		WHERE STToolbarName = 'fld_barbtnApproved' and STModuleID = @STModuleID
		)
	,'TriggerWorkflow'
	,'Void TriggerWorkflow(System.Object,System.String,System.Object)'
	,'BOSERP.Modules.MEEmr.MEEmrModule'
	,1
	);

DELETE
FROM [dbo].[STToolbarFunctions]
WHERE STToolbarFunctionName = 'TriggerWorkflow' and STToolbarID = (SELECT STToolbarID
		FROM [STToolbars]
		WHERE STToolbarName = 'fld_barbtnReturn' and STModuleID = @STModuleID)

DELETE
FROM [dbo].[STToolbars]
WHERE STToolbarName = 'fld_barbtnReturn' and STModuleID = @STModuleID

INSERT INTO [dbo].[STToolbars]
VALUES (
	(
		SELECT MAX(STToolbarID) + 1
		FROM [STToolbars]
		)
	,'Alive'
	,@STModuleID
	,1
	,N'fld_barbtnReturn'
	,N''
	,'Return'
	,'Default'
	,N'Trả hồ sơ'
	,N'Workflow'
	,11
	,'0'
	,N''
	,@STToolbarParentID
	,N'images/actions/reset_16x16.png'
	);

INSERT INTO [dbo].[STToolbarFunctions]
VALUES (
	(
		SELECT MAX(STToolbarFunctionID) + 1
		FROM [STToolbarFunctions]
		)
	,'0'
	,(
		SELECT STToolbarID
		FROM [STToolbars]
		WHERE STToolbarName = 'fld_barbtnReturn' and STModuleID = @STModuleID
		)
	,'TriggerWorkflow'
	,'Void TriggerWorkflow(System.Object,System.String,System.Object)'
	,'BOSERP.Modules.MEEmr.MEEmrModule'
	,1
	);


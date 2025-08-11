--Workflow MEEmrManage
DECLARE @STModuleID int
SET @STModuleID = (SELECT STModuleID FROM STModules WHERE AAStatus = 'alive' and STModuleName = 'MEEmrManage')
DECLARE @STToolbarParentID int
SET @STToolbarParentID = (SELECT STToolbarID FROM STToolbars WHERE AAStatus = 'alive' and STToolbarName = 'fld_barbtnEmrManageStateMachine')

DELETE
FROM [dbo].[STToolbarFunctions]
WHERE STToolbarFunctionName = 'TriggerWorkflowMulti' and STToolbarID = (SELECT STToolbarID
		FROM [STToolbars]
		WHERE STToolbarName = 'fld_barbtnEmrManageToWaitApprove' and STModuleID = @STModuleID)

DELETE
FROM [dbo].[STToolbars]
WHERE STToolbarName = 'fld_barbtnEmrManageToWaitApprove' and STModuleID = @STModuleID

INSERT INTO [dbo].[STToolbars]
VALUES (
	(
		SELECT MAX(STToolbarID) + 1
		FROM [STToolbars]
		)
	,'Alive'
	,@STModuleID
	,1
	,N'fld_barbtnEmrManageToWaitApprove'
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
		WHERE STToolbarName = 'fld_barbtnEmrManageToWaitApprove' and STModuleID = @STModuleID
		)
	,'TriggerWorkflowMulti'
	,'Void TriggerWorkflowMulti(System.Object,System.String,System.Object)'
	,'BOSERP.Modules.MEEmrManage.MEEmrManageModule'
	,1
	);

DELETE
FROM [dbo].[STToolbarFunctions]
WHERE STToolbarFunctionName = 'TriggerWorkflowMulti' and STToolbarID = (SELECT STToolbarID
		FROM [STToolbars]
		WHERE STToolbarName = 'fld_barbtnEmrManageApproved' and STModuleID = @STModuleID)

DELETE
FROM [dbo].[STToolbars]
WHERE STToolbarName = 'fld_barbtnEmrManageApproved' and STModuleID = @STModuleID

INSERT INTO [dbo].[STToolbars]
VALUES (
	(
		SELECT MAX(STToolbarID) + 1
		FROM [STToolbars]
		)
	,'Alive'
	,@STModuleID
	,1
	,N'fld_barbtnEmrManageApproved'
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
		WHERE STToolbarName = 'fld_barbtnEmrManageApproved' and STModuleID = @STModuleID
		)
	,'TriggerWorkflowMulti'
	,'Void TriggerWorkflowMulti(System.Object,System.String,System.Object)'
	,'BOSERP.Modules.MEEmrManage.MEEmrManageModule'
	,1
	);

DELETE
FROM [dbo].[STToolbarFunctions]
WHERE STToolbarFunctionName = 'TriggerWorkflowMulti' and STToolbarID = (SELECT STToolbarID
		FROM [STToolbars]
		WHERE STToolbarName = 'fld_barbtnEmrManageReturn' and STModuleID = @STModuleID)

DELETE
FROM [dbo].[STToolbars]
WHERE STToolbarName = 'fld_barbtnEmrManageReturn' and STModuleID = @STModuleID

INSERT INTO [dbo].[STToolbars]
VALUES (
	(
		SELECT MAX(STToolbarID) + 1
		FROM [STToolbars]
		)
	,'Alive'
	,@STModuleID
	,1
	,N'fld_barbtnEmrManageReturn'
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
		WHERE STToolbarName = 'fld_barbtnEmrManageReturn' and STModuleID = @STModuleID
		)
	,'TriggerWorkflowMulti'
	,'Void TriggerWorkflowMulti(System.Object,System.String,System.Object)'
	,'BOSERP.Modules.MEEmrManage.MEEmrManageModule'
	,1
	);


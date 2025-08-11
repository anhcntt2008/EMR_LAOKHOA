DELETE FROM [dbo].[STToolbarFunctions]
WHERE STToolbarFunctionName = 'TriggerWorkflowMulti'
	AND STToolbarFunctionClass = 'BOSERP.Modules.MEEmrManage.MEEmrManageModule'
	AND STToolbarID IN (SELECT STToolbarID
							FROM [dbo].[STToolbars]
						WHERE STToolbarGroup = 'Workflow'
							AND STModuleID = (SELECT TOP 1 [STModuleID] FROM [STModules] WHERE [STModuleName] = 'MEEmrManage')
							AND STToolbarName IN ('fld_barbtnEmrManageStateMachine','fld_barbtnEmrManageWaitToCloseEmrs', 'fld_barbtnEmrManageBackToDeptEmrs')
						)
DELETE FROM [dbo].[STToolbars]
WHERE STToolbarGroup = 'Workflow'
	AND STModuleID = (SELECT TOP 1 [STModuleID] FROM [STModules] WHERE [STModuleName] = 'MEEmrManage')
	AND STToolbarName IN ('fld_barbtnEmrManageStateMachine','fld_barbtnEmrManageWaitToCloseEmrs', 'fld_barbtnEmrManageBackToDeptEmrs')


INSERT INTO [dbo].[STToolbars]
VALUES (
	(
		SELECT MAX(STToolbarID) + 1
		FROM [STToolbars]
		)
	,'Alive'
	,(SELECT TOP 1 [STModuleID] FROM [STModules] WHERE [STModuleName] = 'MEEmrManage')
	,1
	,N'fld_barbtnEmrManageStateMachine'
	,N''
	,'EmrStateMachine'
	,'Default'
	,N'Quy trình'
	,N'Workflow'
	,11
	,'0'
	,N''
	,0
	,N'images/snap/arrangegroups_16x16.png'
	);

-- Cho dong
INSERT INTO [dbo].[STToolbars]
VALUES (
	(
		SELECT MAX(STToolbarID) + 1
		FROM [STToolbars]
		)
	,'Alive'
	,(SELECT TOP 1 [STModuleID] FROM [STModules] WHERE [STModuleName] = 'MEEmrManage')
	,1
	,N'fld_barbtnEmrManageWaitToCloseEmrs'
	,N''
	,'ToWaitClose'
	,'Default'
	,N'Chờ đóng bệnh án'
	,N'Workflow'
	,11
	,'0'
	,N''
	,(
		SELECT TOP 1 STToolbarID
		FROM [STToolbars]
		WHERE STToolbarName = 'fld_barbtnEmrManageStateMachine'
			AND STModuleID = (SELECT TOP 1 [STModuleID] FROM [STModules] WHERE [STModuleName] = 'MEEmrManage')
		)
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
		WHERE STToolbarName = 'fld_barbtnEmrManageWaitToCloseEmrs'
			AND STModuleID = (SELECT TOP 1 [STModuleID] FROM [STModules] WHERE [STModuleName] = 'MEEmrManage')
		)
	,'TriggerWorkflowMulti'
	,'Void TriggerWorkflowMulti(System.Object,System.String,System.Object)'
	,'BOSERP.Modules.MEEmrManage.MEEmrManageModule'
	,1
	);

-- Tra ve khoa
INSERT INTO [dbo].[STToolbars]
VALUES (
	(
		SELECT MAX(STToolbarID) + 1
		FROM [STToolbars]
		)
	,'Alive'
	,(SELECT TOP 1 [STModuleID] FROM [STModules] WHERE [STModuleName] = 'MEEmrManage')
	,1
	,N'fld_barbtnEmrManageBackToDeptEmrs'
	,N''
	,'BackToDept'
	,'Default'
	,N'Trả bệnh án về khoa'
	,N'Workflow'
	,11
	,'0'
	,N''
	,(
		SELECT TOP 1 STToolbarID
		FROM [STToolbars]
		WHERE STToolbarName = 'fld_barbtnEmrManageStateMachine'
			AND STModuleID = (SELECT TOP 1 [STModuleID] FROM [STModules] WHERE [STModuleName] = 'MEEmrManage')
		)
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
		WHERE STToolbarName = 'fld_barbtnEmrManageBackToDeptEmrs'
			AND STModuleID = (SELECT TOP 1 [STModuleID] FROM [STModules] WHERE [STModuleName] = 'MEEmrManage')
		)
	,'TriggerWorkflowMulti'
	,'Void TriggerWorkflowMulti(System.Object,System.String,System.Object)'
	,'BOSERP.Modules.MEEmrManage.MEEmrManageModule'
	,1
	);

--DELETE
--FROM [dbo].[STToolbarFunctions]
--WHERE STToolbarFunctionName = 'WaitToCloseEmrs'
--	AND STToolbarFunctionClass = 'BOSERP.Modules.MEEmrManage.MEEmrManageModule'

--DELETE
--FROM [dbo].[STToolbars]
--WHERE STToolbarName = 'fld_barbtnEmrManageWaitToCloseEmrs'

--DELETE
--FROM [dbo].[STToolbarFunctions]
--WHERE STToolbarFunctionName = 'BackToDeptEmrs'
--	AND STToolbarFunctionClass = 'BOSERP.Modules.MEEmrManage.MEEmrManageModule'

--DELETE
--FROM [dbo].[STToolbars]
--WHERE STToolbarName = 'fld_barbtnEmrManageBackToDeptEmrs'


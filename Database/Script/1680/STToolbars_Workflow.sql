--SELECT *
--FROM [STToolbars]
--SELECT *
--FROM [STToolbarFunctions]
-- lenh nay se xoa luon ca [STToolbars]
DELETE
FROM [dbo].[STToolbarFunctions]
WHERE STToolbarFunctionName = 'TriggerWorkflow'
	AND STToolbarFunctionClass = 'BOSERP.Modules.MEEmr.MEEmrModule'
	AND STToolbarID IN (SELECT STToolbarID
							FROM [dbo].[STToolbars]
						WHERE STToolbarGroup = 'Workflow'
							AND STModuleID = 2221
							AND STToolbarName IN ('fld_barbtnEmrStateMachine', 'fld_barbtnToWaitClose', 'fld_barbtnBackToDept')
						)
DELETE
FROM [dbo].[STToolbars]
WHERE STToolbarGroup = 'Workflow'
	AND STModuleID = 2221
	AND STToolbarName IN ('fld_barbtnEmrStateMachine', 'fld_barbtnToWaitClose', 'fld_barbtnBackToDept')


INSERT INTO [dbo].[STToolbars]
VALUES (
	(
		SELECT MAX(STToolbarID) + 1
		FROM [STToolbars]
		)
	,'Alive'
	,2221
	,1
	,N'fld_barbtnEmrStateMachine'
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
	,2221
	,1
	,N'fld_barbtnToWaitClose'
	,N''
	,'ToWaitClose'
	,'Default'
	,N'Chờ đóng'
	,N'Workflow'
	,11
	,'0'
	,N''
	,(
		SELECT TOP 1 STToolbarID
		FROM [STToolbars]
		WHERE STToolbarName = 'fld_barbtnEmrStateMachine'
			AND STModuleID = 2221
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
		WHERE STToolbarName = 'fld_barbtnToWaitClose'
			AND STModuleID = 2221
		)
	,'TriggerWorkflow'
	,'Void TriggerWorkflow(System.Object,System.String,System.Object)'
	,'BOSERP.Modules.MEEmr.MEEmrModule'
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
	,2221
	,1
	,N'fld_barbtnBackToDept'
	,N''
	,'BackToDept'
	,'Default'
	,N'Trả về khoa'
	,N'Workflow'
	,11
	,'0'
	,N''
	,(
		SELECT TOP 1 STToolbarID
		FROM [STToolbars]
		WHERE STToolbarName = 'fld_barbtnEmrStateMachine'
			AND STModuleID = 2221
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
		WHERE STToolbarName = 'fld_barbtnBackToDept'
			AND STModuleID = 2221
		)
	,'TriggerWorkflow'
	,'Void TriggerWorkflow(System.Object,System.String,System.Object)'
	,'BOSERP.Modules.MEEmr.MEEmrModule'
	,1
	);

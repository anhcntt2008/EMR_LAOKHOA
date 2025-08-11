DELETE
FROM [dbo].[STToolbarFunctions]
WHERE STToolbarFunctionName = 'CallBackAction'
	AND STToolbarID = (SELECT TOP 1 [STToolbarID] FROM [STToolBars] WHERE [STToolbarTag] = 'CallBackAction')

INSERT INTO [dbo].[STToolbarFunctions]
VALUES (
	(
		SELECT MAX(STToolbarFunctionID) + 1
		FROM [STToolbarFunctions]
		)
	,0
	,(
		SELECT TOP 1 [STToolbarID]
		FROM [STToolBars]
		WHERE [STToolbarTag] = 'CallBackAction'
		)
	,N'CallBackAction'
	,N'Void CallBackAction()'
	,N'BOSERP.Modules.MEDocumentManage.MEDocumentManageModule'
	,1
	);

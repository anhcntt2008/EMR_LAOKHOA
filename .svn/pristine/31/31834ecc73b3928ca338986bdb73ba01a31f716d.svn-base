DELETE
FROM [dbo].[STToolbars]
WHERE STToolbarName = 'fld_barbtnCallBackAction'
	AND STModuleID = (SELECT TOP 1 [STModuleID] FROM [STModules] WHERE [STModuleName] = 'MEDocumentManage')

INSERT INTO [dbo].[STToolbars]
VALUES (
	(
		SELECT MAX(STToolbarID) + 1
		FROM [STToolbars]
		)
	,'Alive'
	,(
		SELECT TOP 1 [STModuleID]
		FROM [STModules]
		WHERE [STModuleName] = 'MEDocumentManage'
		)
	,1
	,N'fld_barbtnCallBackAction'
	,N''
	,'CallBackAction'
	,'Default'
	,N'Gọi lại thẻ chức năng'
	,N'Action'
	,11
	,'0'
	,N''
	,0
	,N'images/actions/refresh2_16x16.png'
	);
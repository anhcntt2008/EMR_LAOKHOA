DELETE
FROM [dbo].[STToolbars]
WHERE STModuleID =(SELECT TOP 1 [STModuleID]
		FROM [STModules]
		WHERE [STModuleName] = 'MEParamReports')

INSERT INTO [dbo].[STToolbars]
VALUES (
	(
		SELECT MAX(STToolbarID) + 1
		FROM [STToolbars]
		)
	,'Alive'
	,(SELECT TOP 1 [STModuleID] FROM [STModules] WHERE [STModuleName] = 'MEParamReports')
	,1
	,N'fld_barbtnNew'
	,N''
	,'New'
	,'Default'
	,N'Tạo mới'
	,N'Action'
	,0
	,'1'
	,N''
	,0
	,N'');

INSERT INTO [dbo].[STToolbars]
VALUES (
	(
		SELECT MAX(STToolbarID) + 1
		FROM [STToolbars]
		)
	,'Alive'
	,(SELECT TOP 1 [STModuleID] FROM [STModules] WHERE [STModuleName] = 'MEParamReports')
	,1
	,N'fld_barbtnEdit'
	,N''
	,'Edit'
	,'Default'
	,N'Sửa'
	,N'Action'
	,0
	,'1'
	,N''
	,0
	,N'');

INSERT INTO [dbo].[STToolbars]
VALUES (
	(
		SELECT MAX(STToolbarID) + 1
		FROM [STToolbars]
		)
	,'Alive'
	,(SELECT TOP 1 [STModuleID] FROM [STModules] WHERE [STModuleName] = 'MEParamReports')
	,1
	,N'fld_barbtnSave'
	,N''
	,'Save'
	,'Default'
	,N'Lưu'
	,N'Action'
	,0
	,'1'
	,N''
	,0
	,N'');

INSERT INTO [dbo].[STToolbars]
VALUES (
	(
		SELECT MAX(STToolbarID) + 1
		FROM [STToolbars]
		)
	,'Alive'
	,(SELECT TOP 1 [STModuleID] FROM [STModules] WHERE [STModuleName] = 'MEParamReports')
	,1
	,N'fld_barbtnDelete'
	,N''
	,'Delete'
	,'Default'
	,N'Xóa'
	,N'Action'
	,0
	,'1'
	,N''
	,0
	,N'');

INSERT INTO [dbo].[STToolbars]
VALUES (
	(
		SELECT MAX(STToolbarID) + 1
		FROM [STToolbars]
		)
	,'Alive'
	,(SELECT TOP 1 [STModuleID] FROM [STModules] WHERE [STModuleName] = 'MEParamReports')
	,1
	,N'fld_barbtnCancel'
	,N''
	,'Cancel'
	,'Default'
	,N'Hủy'
	,N'Action'
	,0
	,'1'
	,N''
	,0
	,N'');


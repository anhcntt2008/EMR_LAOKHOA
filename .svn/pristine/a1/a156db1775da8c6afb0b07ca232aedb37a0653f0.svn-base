DELETE
FROM [dbo].[STToolbarFunctions]
WHERE STToolbarFunctionName = 'ReCloseEmrDocuments'

DELETE
FROM [dbo].[STToolbars]
WHERE STToolbarName = 'fld_barbtnEmrModuleReCloseEmrDocuments'

INSERT INTO [dbo].[STToolbars]
VALUES (
	(
		SELECT MAX(STToolbarID) + 1
		FROM [STToolbars]
		)
	,'Alive'
	,2221
	,1
	,N'fld_barbtnEmrModuleReCloseEmrDocuments'
	,N''
	,'ReCloseEmrDocuments'
	,'Default'
	,N'Xuất lại PDF TDT'
	,N'Action'
	,11
	,'0'
	,N''
	,0
	,N'images/support/packageproduct_16x16.png'
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
		WHERE STToolbarName = 'fld_barbtnEmrModuleReCloseEmrDocuments'
		)
	,'ReCloseEmrDocuments'
	,'Void ReCloseEmrDocuments()'
	,'BOSERP.Modules.MEEmr.MEEmrModule'
	,1
	);

--XEM XET KHA NANG NGUOI DUNG CHAP NHAN DUNG THI CHAY SCRIPT NAY
DELETE
FROM [dbo].[STToolbarFunctions]
WHERE STToolbarFunctionName = 'ExportToPdf'

DELETE
FROM [dbo].[STToolbars]
WHERE STToolbarName = 'fld_barbtnEmrModuleExportToPdf'

INSERT INTO [dbo].[STToolbars]
VALUES (
	(
		SELECT MAX(STToolbarID) + 1
		FROM [STToolbars]
		)
	,'Alive'
	,2221
	,1
	,N'fld_barbtnEmrModuleExportToPdf'
	,N''
	,'ExportToPdf'
	,'Default'
	,N'Kết xuất PDF'
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
		WHERE STToolbarName = 'fld_barbtnEmrModuleExportToPdf'
		)
	,'ExportToPdf'
	,'Void ExportToPdf()'
	,'BOSERP.Modules.MEEmr.MEEmrModule'
	,1
	);

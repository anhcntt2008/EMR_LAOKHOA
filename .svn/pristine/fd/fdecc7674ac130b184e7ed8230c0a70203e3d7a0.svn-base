--chay tung dong
INSERT INTO [dbo].[STToolbars]
VALUES (
	(
		SELECT MAX(STToolbarID) + 1
		FROM [STToolbars]
		)
	,'Alive'
	,2221
	,1
	,N'fld_barbtnCloseDocument'
	,N''
	,'CloseDocument'
	,'Default'
	,N'Đóng tờ bệnh án'
	,N'Action'
	,8
	,'0'
	,N''
	,0
	,N'images/richedit/protectdocument_16x16.png'
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
		WHERE STToolbarName = 'fld_barbtnCloseDocument'
		)
	,'CloseCurrentEmrDocument'
	,'Void CloseCurrentEmrDocument()'
	,'BOSERP.Modules.MEEmr.MEEmrModule'
	,1
	);


	update [STToolbars] set STToolbarImage = 'images/spreadsheet/encrypt_16x16.png' where STModuleID = 2221 and STToolbarName = 'fld_barbtnClose'
DELETE
FROM [dbo].[STToolbarFunctions]
WHERE STToolbarFunctionName = 'ShowDocumentNotes'

DELETE
FROM [dbo].[STToolbars]
WHERE STToolbarName = 'fld_barbtnEmrModuleShowDocumentNotes'

INSERT INTO [dbo].[STToolbars]
VALUES (
	(
		SELECT MAX(STToolbarID) + 1
		FROM [STToolbars]
		)
	,'Alive'
	,2221
	,1
	,N'fld_barbtnEmrModuleShowDocumentNotes'
	,N''
	,'ShowDocumentNotes'
	,'Default'
	,N'Xem ghi chú'
	,N'Action'
	,12
	,'0'
	,N''
	,0
	,N'images/comments/insertcomment_16x16.png'
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
		WHERE STToolbarName = 'fld_barbtnEmrModuleShowDocumentNotes'
		)
	,'ShowDocumentNotes'
	,'Void ShowDocumentNotes()'
	,'BOSERP.Modules.MEEmr.MEEmrModule'
	,1
	);

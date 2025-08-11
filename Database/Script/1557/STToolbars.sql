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
	,N'fld_barbtnEmrForceReleaseDocument'
	,N''
	,'EmrForceReleaseDocument'
	,'Default'
	,N'Lấy quyền sửa'
	,N'Action'
	,10
	,'0'
	,N''
	,0
	,N'images/people/assigntome_16x16.png'
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
		WHERE STToolbarName = 'fld_barbtnEmrForceReleaseDocument'
		)
	,'ForceReleaseDocument'
	,'Void ForceReleaseDocument()'
	,'BOSERP.Modules.MEEmr.MEEmrModule'
	,1
	);

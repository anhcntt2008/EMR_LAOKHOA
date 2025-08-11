INSERT INTO [dbo].[STToolbars]
VALUES (
	(
		SELECT MAX(STToolbarID) + 1
		FROM [STToolbars]
		)
	,'Alive'
	,2221
	,1
	,N'fld_barbtnEmrOtherNewGroup'
	,N''
	,'New'
	,'Default'
	,N'Thêm mới'
	,N'Action'
	,1
	,'0'
	,N''
	,0
	,N'images/actions/additem_16x16.png'
	);

UPDATE [dbo].[STToolbars]
SET STToolbarParentID = (
		SELECT TOP 1 STToolbarID
		FROM [STToolbars]
		WHERE STToolbarName = 'fld_barbtnEmrOtherNewGroup'
		),
		STToolbarCaption = N'Bệnh án tạm'
WHERE STToolbarName = 'fld_barbtnNewTempEmr'

INSERT INTO [dbo].[STToolbars]
VALUES (
	(
		SELECT MAX(STToolbarID) + 1
		FROM [STToolbars]
		)
	,'Alive'
	,2221
	,1
	,N'fld_barbtnNewPatientProfile'
	,N''
	,'New'
	,'Default'
	,N'Hồ sơ bệnh nhân'
	,N'Action'
	,1
	,'0'
	,N''
	,(
		SELECT TOP 1 STToolbarID
		FROM [STToolbars]
		WHERE STToolbarName = 'fld_barbtnEmrOtherNewGroup'
		)
	,N'images/mail/contact_16x16.png'
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
		WHERE STToolbarName = 'fld_barbtnNewPatientProfile'
		)
	,'CreateEmrWithTypePatientProfile'
	,'Void CreateEmrWithTypePatientProfile()'
	,'BOSERP.Modules.MEEmr.MEEmrModule'
	,1
	);

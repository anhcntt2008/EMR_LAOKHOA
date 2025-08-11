
DELETE [dbo].[AAColumnAlias] where AATableName = 'MEEmrs' AND AAColumnAliasName = 'MEEmrPatientAddr'
INSERT INTO [dbo].[AAColumnAlias]
VALUES (
	(
		SELECT MAX([AAColumnAliasID]) + 1
		FROM [dbo].[AAColumnAlias]
		)
	,0
	,''
	,'Alive'
	,N'MEEmrPatientAddr'
	,N'Địa chỉ'
	,'MEEmrs'
	);
GO
DELETE [dbo].[AAColumnAlias] where AATableName = 'MEEmrs' AND AAColumnAliasName = 'MEEmrDateIn'
INSERT INTO [dbo].[AAColumnAlias]
VALUES (
	(
		SELECT MAX([AAColumnAliasID]) + 1
		FROM [dbo].[AAColumnAlias]
		)
	,0
	,''
	,'Alive'
	,N'MEEmrDateIn'
	,N'Ngày vào viện'
	,'MEEmrs'
	);
GO
DELETE [dbo].[AAColumnAlias] where AATableName = 'MEEmrs' AND AAColumnAliasName = 'MEEmrDateOut'
INSERT INTO [dbo].[AAColumnAlias]
VALUES (
	(
		SELECT MAX([AAColumnAliasID]) + 1
		FROM [dbo].[AAColumnAlias]
		)
	,0
	,''
	,'Alive'
	,N'MEEmrDateOut'
	,N'Ngày ra viện'
	,'MEEmrs'
	);
GO
DELETE [dbo].[AAColumnAlias] where AATableName = 'MEEmrs' AND AAColumnAliasName = 'MEEmrRoomNo'
INSERT INTO [dbo].[AAColumnAlias]
VALUES (
	(
		SELECT MAX([AAColumnAliasID]) + 1
		FROM [dbo].[AAColumnAlias]
		)
	,0
	,''
	,'Alive'
	,N'MEEmrRoomNo'
	,N'Số phòng'
	,'MEEmrs'
	);
GO
DELETE [dbo].[AAColumnAlias] where AATableName = 'MEEmrs' AND AAColumnAliasName = 'MEEmrBedNo'
INSERT INTO [dbo].[AAColumnAlias]
VALUES (
	(
		SELECT MAX([AAColumnAliasID]) + 1
		FROM [dbo].[AAColumnAlias]
		)
	,0
	,''
	,'Alive'
	,N'MEEmrBedNo'
	,N'Số giường'
	,'MEEmrs'
	);
GO

DELETE [dbo].[AAColumnAlias] where AATableName = 'MEEmrs' AND AAColumnAliasName = 'MEEmrArchiveNo'
INSERT INTO [dbo].[AAColumnAlias]
VALUES (
	(
		SELECT MAX([AAColumnAliasID]) + 1
		FROM [dbo].[AAColumnAlias]
		)
	,0
	,''
	,'Alive'
	,N'MEEmrArchiveNo'
	,N'Số lưu trữ'
	,'MEEmrs'
	);
GO

DELETE [dbo].[AAColumnAlias] where AATableName = 'MEEmrs' AND AAColumnAliasName = 'FK_HREmployeeClosedID'
INSERT INTO [dbo].[AAColumnAlias]
VALUES (
	(
		SELECT MAX([AAColumnAliasID]) + 1
		FROM [dbo].[AAColumnAlias]
		)
	,0
	,''
	,'Alive'
	,N'FK_HREmployeeClosedID'
	,N'Người đóng'
	,'MEEmrs'
	);
GO
DELETE [dbo].[AAColumnAlias] where AATableName = 'MEEmrs' AND AAColumnAliasName = 'MEPatientBirthday'
INSERT INTO [dbo].[AAColumnAlias]
VALUES (
	(
		SELECT MAX([AAColumnAliasID]) + 1
		FROM [dbo].[AAColumnAlias]
		)
	,0
	,''
	,'Alive'
	,N'MEPatientBirthday'
	,N'Ngày sinh'
	,'MEEmrs'
	);
GO

DELETE [dbo].[AAColumnAlias] where AATableName = 'MEEmrs' AND AAColumnAliasName = 'MEPatientBirthYear'
INSERT INTO [dbo].[AAColumnAlias]
VALUES (
	(
		SELECT MAX([AAColumnAliasID]) + 1
		FROM [dbo].[AAColumnAlias]
		)
	,0
	,''
	,'Alive'
	,N'MEPatientBirthYear'
	,N'Năm sinh'
	,'MEEmrs'
	);
GO
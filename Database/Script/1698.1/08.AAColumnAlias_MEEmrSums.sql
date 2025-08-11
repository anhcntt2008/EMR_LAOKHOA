DELETE
FROM [AAColumnAlias]
WHERE [AATableName] = 'MEEmrSums' 

INSERT INTO [dbo].[AAColumnAlias] ([AAColumnAliasID]
	,[AANumberInt],[AANumberString],[AAStatus]
	,[AAColumnAliasName]
	,[AAColumnAliasCaption]
	,[AATableName]
	)
VALUES (
	(SELECT MAX([AAColumnAliasID]) + 1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive'
	,'MEEmrSumID'
	,N'ID'
	,'MEEmrSums');

INSERT INTO [dbo].[AAColumnAlias] ([AAColumnAliasID]
	,[AANumberInt],[AANumberString],[AAStatus]
	,[AAColumnAliasName]
	,[AAColumnAliasCaption]
	,[AATableName]
	)
VALUES (
	(SELECT MAX([AAColumnAliasID]) + 1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive'
	,'MEEmrSumCode'
	,N'Mã phiếu'
	,'MEEmrSums');

INSERT INTO [dbo].[AAColumnAlias] ([AAColumnAliasID]
	,[AANumberInt],[AANumberString],[AAStatus]
	,[AAColumnAliasName]
	,[AAColumnAliasCaption]
	,[AATableName]
	)
VALUES (
	(SELECT MAX([AAColumnAliasID]) + 1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive'
	,'MEEmrSumStoreCode'
	,N'Số lưu trữ'
	,'MEEmrSums');

INSERT INTO [dbo].[AAColumnAlias] ([AAColumnAliasID]
	,[AANumberInt],[AANumberString],[AAStatus]
	,[AAColumnAliasName]
	,[AAColumnAliasCaption]
	,[AATableName]
	)
VALUES (
	(SELECT MAX([AAColumnAliasID]) + 1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive'
	,'MEEmrNo'
	,N'Mã bệnh án'
	,'MEEmrSums');

INSERT INTO [dbo].[AAColumnAlias] ([AAColumnAliasID]
	,[AANumberInt],[AANumberString],[AAStatus]
	,[AAColumnAliasName]
	,[AAColumnAliasCaption]
	,[AATableName]
	)
VALUES (
	(SELECT MAX([AAColumnAliasID]) + 1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive'
	,'MEPatientNo'
	,N'Mã bệnh nhân'
	,'MEEmrSums');

INSERT INTO [dbo].[AAColumnAlias] ([AAColumnAliasID]
	,[AANumberInt],[AANumberString],[AAStatus]
	,[AAColumnAliasName]
	,[AAColumnAliasCaption]
	,[AATableName]
	)
VALUES (
	(SELECT MAX([AAColumnAliasID]) + 1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive'
	,'MEPatientName'
	,N'Tên bệnh nhân'
	,'MEEmrSums');

INSERT INTO [dbo].[AAColumnAlias] ([AAColumnAliasID]
	,[AANumberInt],[AANumberString],[AAStatus]
	,[AAColumnAliasName]
	,[AAColumnAliasCaption]
	,[AATableName]
	)
VALUES (
	(SELECT MAX([AAColumnAliasID]) + 1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive'
	,'MEPatientBirthday'
	,N'Ngày sinh'
	,'MEEmrSums');

INSERT INTO [dbo].[AAColumnAlias] ([AAColumnAliasID]
	,[AANumberInt],[AANumberString],[AAStatus]
	,[AAColumnAliasName]
	,[AAColumnAliasCaption]
	,[AATableName]
	)
VALUES (
	(SELECT MAX([AAColumnAliasID]) + 1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive'
	,'MEEmrDateIn'
	,N'Ngày vào viện'
	,'MEEmrSums');

INSERT INTO [dbo].[AAColumnAlias] ([AAColumnAliasID]
	,[AANumberInt],[AANumberString],[AAStatus]
	,[AAColumnAliasName]
	,[AAColumnAliasCaption]
	,[AATableName]
	)
VALUES (
	(SELECT MAX([AAColumnAliasID]) + 1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive'
	,'MEEmrDateOut'
	,N'Ngày ra viện'
	,'MEEmrSums');

INSERT INTO [dbo].[AAColumnAlias] ([AAColumnAliasID]
	,[AANumberInt],[AANumberString],[AAStatus]
	,[AAColumnAliasName]
	,[AAColumnAliasCaption]
	,[AATableName]
	)
VALUES (
	(SELECT MAX([AAColumnAliasID]) + 1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive'
	,'MEEmrTypeName'
	,N'Loại bệnh án'
	,'MEEmrSums');

INSERT INTO [dbo].[AAColumnAlias] ([AAColumnAliasID]
	,[AANumberInt],[AANumberString],[AAStatus]
	,[AAColumnAliasName]
	,[AAColumnAliasCaption]
	,[AATableName]
	)
VALUES (
	(SELECT MAX([AAColumnAliasID]) + 1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive'
	,'HRDepartmentName'
	,N'Khoa'
	,'MEEmrSums');

INSERT INTO [dbo].[AAColumnAlias] ([AAColumnAliasID]
	,[AANumberInt],[AANumberString],[AAStatus]
	,[AAColumnAliasName]
	,[AAColumnAliasCaption]
	,[AATableName]
	)
VALUES (
	(SELECT MAX([AAColumnAliasID]) + 1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive'
	,'MEEmrICDStrOut'
	,N'Chẩn đoán ra viện'
	,'MEEmrSums');

INSERT INTO [dbo].[AAColumnAlias] ([AAColumnAliasID]
	,[AANumberInt],[AANumberString],[AAStatus]
	,[AAColumnAliasName]
	,[AAColumnAliasCaption]
	,[AATableName]
	)
VALUES (
	(SELECT MAX([AAColumnAliasID]) + 1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive'
	,'MEEmrSumStatus'
	,N'Trạng thái phiếu'
	,'MEEmrSums');

INSERT INTO [dbo].[AAColumnAlias] ([AAColumnAliasID]
	,[AANumberInt],[AANumberString],[AAStatus]
	,[AAColumnAliasName]
	,[AAColumnAliasCaption]
	,[AATableName]
	)
VALUES (
	(SELECT MAX([AAColumnAliasID]) + 1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive'
	,'MEEmrSumXMLStatus'
	,N'Xuất XML'
	,'MEEmrSums');

SET XACT_ABORT ON
BEGIN TRANSACTION
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive',N'MEEmrDocumentCommandDateStr',N'Ngày y lệnh','MEEmrDocuments');
	GO
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive',N'MEEmrDocumentStr1',N'Chuỗi 1','MEEmrDocuments');
	GO
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive',N'MEEmrDocumentStr2',N'Chuỗi 2','MEEmrDocuments');
	GO
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive',N'MEEmrDocumentStr3',N'Chuỗi 3','MEEmrDocuments');
	GO
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive',N'MEEmrDocumentStr4',N'Chuỗi 4','MEEmrDocuments');
	GO
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive',N'MEEmrDocumentStr5',N'Chuỗi 5','MEEmrDocuments');
	GO

INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive',N'MEEmrDocumentNum1',N'Số 1','MEEmrDocuments');
	GO
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive',N'MEEmrDocumentNum2',N'Số 2','MEEmrDocuments');
	GO
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive',N'MEEmrDocumentNum3',N'Số 3','MEEmrDocuments');
	GO
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive',N'MEEmrDocumentNum4',N'Số 4','MEEmrDocuments');
	GO
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive',N'MEEmrDocumentNum5',N'Số 5','MEEmrDocuments');
	GO

INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive',N'MEEmrDocumentDate1',N'Thời gian 1','MEEmrDocuments');
	GO
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive',N'MEEmrDocumentDate2',N'Thời gian 2','MEEmrDocuments');
	GO
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive',N'MEEmrDocumentDate3',N'Thời gian 3','MEEmrDocuments');
	GO
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive',N'MEEmrDocumentDate4',N'Thời gian 4','MEEmrDocuments');
	GO
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive',N'MEEmrDocumentDate5',N'Thời gian 5','MEEmrDocuments');
	GO

COMMIT TRANSACTION
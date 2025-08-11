-- chạy từng dòng
ALTER TABLE MEParamRelations ADD MEParamRelationGroup bit

UPDATE MEParamRelations SET MEParamRelationGroup = 0

INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive',N'MEParamRelationGroup',N'Nhóm dữ liệu','MEParamRelations');
GO
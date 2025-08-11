--chạy tùng cụm
--0--------------------------------
ALTER TABLE [dbo].[MEEmrActionRelations] ADD [FK_MEEmrActionDependOnID] int

ALTER TABLE [dbo].[MEEmrActionRelations]  WITH CHECK ADD  CONSTRAINT [FK_EmrActionRelations_MEEmrActions_DependOn] FOREIGN KEY([FK_MEEmrActionDependOnID])
REFERENCES [dbo].[MEEmrActions] ([MEEmrActionID])
GO

ALTER TABLE [dbo].[MEEmrActionRelations] CHECK CONSTRAINT [FK_EmrActionRelations_MEEmrActions_DependOn]
GO
--1---------------------------------------
INSERT INTO [dbo].[MEEmrActions] VALUES (0, 'Dummy', N'Dummy', N'Dummy', N'Dummy', 'Dummy', N'Dummy', N'Dummy', N'', N'Dummy', N'', '9999-12-31 23:59:59.997', N'Dummy', '2018-09-29 09:33:56.390', '0', 0, '');

--2---------------------------------------
UPDATE [dbo].[MEEmrActionRelations] SET [FK_MEEmrActionDependOnID] = 0
ALTER TABLE [dbo].[MEEmrActionRelations] ALTER COLUMN [FK_MEEmrActionDependOnID] int not null;
--3---------------------------------------
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive',N'FK_MEEmrActionDependOnID',N'Kế thừa từ','MEEmrActionRelations');
GO

ALTER TABLE [dbo].[MEEmrActionRelations] ADD [MEEmrActionRelationDependOnData] varchar(1000)

INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias])
	,0,'','Alive',N'MEEmrActionRelationDependOnData',N'Dữ liệu nguồn','MEEmrActionRelations');
GO

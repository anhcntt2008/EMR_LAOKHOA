ALTER TABLE [dbo].[MEParamReportRelations] ALTER COLUMN MEParamReportMap nvarchar(100) NULL
GO
IF NOT EXISTS (SELECT * FROM sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[MEParamReportRelations]') AND name = 'METemplateNo')
BEGIN
	ALTER TABLE [dbo].[MEParamReportRelations] ADD METemplateNo nvarchar(200) NULL
END
GO

IF NOT EXISTS (SELECT * FROM sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[MEParamReportRelations]') AND name = 'FK_METemplateID2')
BEGIN
	ALTER TABLE [dbo].[MEParamReportRelations] ADD FK_METemplateID2 int NULL
END
GO

IF NOT EXISTS (SELECT * FROM sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[MEParamReportRelations]') AND name = 'METemplateNo2')
BEGIN
	ALTER TABLE [dbo].[MEParamReportRelations] ADD METemplateNo2 nvarchar(200) NULL
END
GO

IF NOT EXISTS (SELECT * FROM sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[MEParamReportRelations]') AND name = 'MEParamReportMap2')
BEGIN
	ALTER TABLE [dbo].[MEParamReportRelations] ADD MEParamReportMap2 nvarchar(100) NULL
END
GO

IF NOT EXISTS (SELECT * FROM sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[MEParamReportRelations]') AND name = 'FK_METemplateID3')
BEGIN
	ALTER TABLE [dbo].[MEParamReportRelations] ADD FK_METemplateID3 int NULL
END
GO

IF NOT EXISTS (SELECT * FROM sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[MEParamReportRelations]') AND name = 'METemplateNo3')
BEGIN
	ALTER TABLE [dbo].[MEParamReportRelations] ADD METemplateNo3 nvarchar(200) NULL
END
GO

IF NOT EXISTS (SELECT * FROM sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[MEParamReportRelations]') AND name = 'MEParamReportMap3')
BEGIN
	ALTER TABLE [dbo].[MEParamReportRelations] ADD MEParamReportMap3 nvarchar(100) NULL
END
GO
UPDATE [dbo].[MEParamReportRelations] SET METemplateNo=''
UPDATE [dbo].[MEParamReportRelations] SET METemplateNo2=''
UPDATE [dbo].[MEParamReportRelations] SET METemplateNo3=''
UPDATE [dbo].[MEParamReportRelations] SET FK_METemplateID2=0
UPDATE [dbo].[MEParamReportRelations] SET MEParamReportMap2=''
UPDATE [dbo].[MEParamReportRelations] SET FK_METemplateID3=0
UPDATE [dbo].[MEParamReportRelations] SET MEParamReportMap2=''
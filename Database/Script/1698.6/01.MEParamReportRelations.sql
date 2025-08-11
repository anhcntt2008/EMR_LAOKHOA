IF NOT EXISTS (SELECT * FROM sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[MEParamReportRelations]') AND name = 'MEParamReportMapFilter')
BEGIN
	ALTER TABLE [dbo].[MEParamReportRelations] ADD MEParamReportMapFilter varchar(50) NULL
END
GO
IF NOT EXISTS (SELECT * FROM sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[MEParamReportRelations]') AND name = 'MEParamReportMapFilter2')
BEGIN
	ALTER TABLE [dbo].[MEParamReportRelations] ADD MEParamReportMapFilter2 varchar(50) NULL
END
GO
IF NOT EXISTS (SELECT * FROM sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[MEParamReportRelations]') AND name = 'MEParamReportMapFilter3')
BEGIN
	ALTER TABLE [dbo].[MEParamReportRelations] ADD MEParamReportMapFilter3 varchar(50) NULL
END
GO
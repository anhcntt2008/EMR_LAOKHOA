IF NOT EXISTS (SELECT * FROM sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[MEParamReportRelations]') AND name = 'MEParamReportRelationEncode')
BEGIN
	ALTER TABLE [dbo].[MEParamReportRelations] ADD MEParamReportRelationEncode varchar(50) NULL
END
GO
IF NOT EXISTS (SELECT * FROM sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[MEParamReportRelations]') AND name = 'MEParamReportRelationEncode2')
BEGIN
	ALTER TABLE [dbo].[MEParamReportRelations] ADD MEParamReportRelationEncode2 varchar(50) NULL
END
GO
IF NOT EXISTS (SELECT * FROM sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[MEParamReportRelations]') AND name = 'MEParamReportRelationEncode3')
BEGIN
	ALTER TABLE [dbo].[MEParamReportRelations] ADD MEParamReportRelationEncode3 varchar(50) NULL
END
GO
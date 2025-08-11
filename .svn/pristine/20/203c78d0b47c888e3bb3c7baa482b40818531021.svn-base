IF NOT EXISTS (SELECT * FROM sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[MEParams]') AND name = 'MEParamMode')
BEGIN
	ALTER TABLE [dbo].[MEParams] ADD MEParamMode nvarchar(50) NULL
	UPDATE [dbo].[MEParams] SET MEParamMode=''
END
GO

IF NOT EXISTS (SELECT * FROM sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[MEParams]') AND name = 'MEParamReportMap')
BEGIN
	ALTER TABLE [dbo].[MEParams] ADD MEParamReportMap nvarchar(512) NULL
END
GO

IF NOT EXISTS (SELECT * FROM sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[MEParams]') AND name = 'MEParamReportXML')
BEGIN
	ALTER TABLE [dbo].[MEParams] ADD MEParamReportXML bit NULL
END
GO

IF NOT EXISTS (SELECT * FROM sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[MEParams]') AND name = 'MEParamReportXMLLevel')
BEGIN
	ALTER TABLE [dbo].[MEParams] ADD MEParamReportXMLLevel int NULL
END
GO

IF NOT EXISTS (SELECT * FROM sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[MEParams]') AND name = 'MEParamReportXMLGroup')
BEGIN
	ALTER TABLE [dbo].[MEParams] ADD MEParamReportXMLGroup int NULL
END
GO

IF NOT EXISTS (SELECT * FROM sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[MEParams]') AND name = 'MEParamReportXMLOrder')
BEGIN
	ALTER TABLE [dbo].[MEParams] ADD MEParamReportXMLOrder int NULL
END
GO

ALTER TABLE [dbo].[MEParams] ADD  CONSTRAINT [DF_MEParams_MEParamReportXML]  DEFAULT ((1)) FOR [MEParamReportXML]
GO


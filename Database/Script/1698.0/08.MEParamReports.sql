GO

ALTER TABLE [dbo].[MEParamReports] DROP CONSTRAINT [FK_MEParamReports_METemplates]
GO

ALTER TABLE [dbo].[MEParamReports] DROP CONSTRAINT [FK_MEParamReports_MEParams]
GO

ALTER TABLE [dbo].[MEParamReports] DROP CONSTRAINT [DF_MEParamReports_AAUpdatedDate]
GO

ALTER TABLE [dbo].[MEParamReports] DROP CONSTRAINT [DF_MEParamReports_AACreatedDate]
GO

ALTER TABLE [dbo].[MEParamReports] DROP CONSTRAINT [DF_MEParamReports_MEParamReportRelationXML]
GO

/****** Object:  Table [dbo].[MEParamReports]    Script Date: 8/26/2021 10:36:07 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MEParamReports]') AND type in (N'U'))
DROP TABLE [dbo].[MEParamReports]
GO

/****** Object:  Table [dbo].[MEParamReports]    Script Date: 8/26/2021 10:36:07 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MEParamReports](
	[MEParamReportID] [int] NOT NULL,
	[AAStatus] [varchar](50) NULL,
	[MEParamReportKey] [nvarchar](128) NOT NULL,
	[MEParamReportName] [nvarchar](1024) NULL,
	[MEParamReportType] [int] NULL,
	[FK_METemplateID] [int] NULL,
	[FK_MEParamID] [int] NULL,
	[MEParamReportXML] [bit] NOT NULL,
	[MEParamReportXMLLevel] [int] NULL,
	[MEParamReportXMLGroup] [int] NULL,
	[MEParamReportXMLOrder] [int] NULL,
	[AACreatedUser] [nvarchar](50) NULL,
	[AACreatedDate] [datetime] NOT NULL,
	[AAUpdatedUser] [nvarchar](50) NULL,
	[AAUpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_MEParamReports] PRIMARY KEY CLUSTERED 
(
	[MEParamReportID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MEParamReports] ADD  CONSTRAINT [DF_MEParamReports_MEParamReportRelationXML]  DEFAULT ((1)) FOR [MEParamReportXML]
GO

ALTER TABLE [dbo].[MEParamReports] ADD  CONSTRAINT [DF_MEParamReports_AACreatedDate]  DEFAULT ('9999-12-31 23:59:59.997') FOR [AACreatedDate]
GO

ALTER TABLE [dbo].[MEParamReports] ADD  CONSTRAINT [DF_MEParamReports_AAUpdatedDate]  DEFAULT ('9999-12-31 23:59:59.997') FOR [AAUpdatedDate]
GO

ALTER TABLE [dbo].[MEParamReports]  WITH CHECK ADD  CONSTRAINT [FK_MEParamReports_MEParams] FOREIGN KEY([FK_MEParamID])
REFERENCES [dbo].[MEParams] ([MEParamID])
GO

ALTER TABLE [dbo].[MEParamReports] CHECK CONSTRAINT [FK_MEParamReports_MEParams]
GO

ALTER TABLE [dbo].[MEParamReports]  WITH CHECK ADD  CONSTRAINT [FK_MEParamReports_METemplates] FOREIGN KEY([FK_METemplateID])
REFERENCES [dbo].[METemplates] ([METemplateID])
GO

ALTER TABLE [dbo].[MEParamReports] CHECK CONSTRAINT [FK_MEParamReports_METemplates]
GO



GO

ALTER TABLE [dbo].[MEParamReportRelations] DROP CONSTRAINT [FK_MEParamReportRelations_METemplates]
GO

ALTER TABLE [dbo].[MEParamReportRelations] DROP CONSTRAINT [FK_MEParamReportRelations_MEParams]
GO

ALTER TABLE [dbo].[MEParamReportRelations] DROP CONSTRAINT [FK_MEParamReportRelations_MEParamReports]
GO

ALTER TABLE [dbo].[MEParamReportRelations] DROP CONSTRAINT [FK_MEParamReportRelations_MEEmrTypes]
GO

ALTER TABLE [dbo].[MEParamReportRelations] DROP CONSTRAINT [DF_MEParamReportRelations_AAUpdatedDate]
GO

ALTER TABLE [dbo].[MEParamReportRelations] DROP CONSTRAINT [DF_MEParamReportRelations_AACreatedDate]
GO

ALTER TABLE [dbo].[MEParamReportRelations] DROP CONSTRAINT [DF_MEParamReportRelations_MEParamReportRelationXML]
GO

/****** Object:  Table [dbo].[MEParamReportRelations]    Script Date: 8/26/2021 10:46:19 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MEParamReportRelations]') AND type in (N'U'))
DROP TABLE [dbo].[MEParamReportRelations]
GO

/****** Object:  Table [dbo].[MEParamReportRelations]    Script Date: 8/26/2021 10:46:19 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MEParamReportRelations](
	[MEParamReportRelationID] [int] NOT NULL,
	[AAStatus] [varchar](50) NULL,
	[FK_MEParamReportID] [int] NOT NULL,
	[FK_MEParamID] [int] NOT NULL,
	[FK_METemplateID] [int] NOT NULL,
	[FK_MEEmrTypeID] [int] NOT NULL,
	[MEParamReportRelationXML] [bit] NULL,
	[MEParamReportRelationXMLLevel] [int] NULL,
	[MEParamReportRelationXMLGroup] [int] NULL,
	[MEParamReportRelationXMLOrder] [int] NULL,
	[AACreatedUser] [nvarchar](50) NULL,
	[AACreatedDate] [datetime] NOT NULL,
	[AAUpdatedUser] [nvarchar](50) NULL,
	[AAUpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_MEParamReportRelations] PRIMARY KEY CLUSTERED 
(
	[MEParamReportRelationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MEParamReportRelations] ADD  CONSTRAINT [DF_MEParamReportRelations_MEParamReportRelationXML]  DEFAULT ((1)) FOR [MEParamReportRelationXML]
GO

ALTER TABLE [dbo].[MEParamReportRelations] ADD  CONSTRAINT [DF_MEParamReportRelations_AACreatedDate]  DEFAULT ('9999-12-31 23:59:59.997') FOR [AACreatedDate]
GO

ALTER TABLE [dbo].[MEParamReportRelations] ADD  CONSTRAINT [DF_MEParamReportRelations_AAUpdatedDate]  DEFAULT ('9999-12-31 23:59:59.997') FOR [AAUpdatedDate]
GO

ALTER TABLE [dbo].[MEParamReportRelations]  WITH CHECK ADD  CONSTRAINT [FK_MEParamReportRelations_MEEmrTypes] FOREIGN KEY([FK_MEEmrTypeID])
REFERENCES [dbo].[MEEmrTypes] ([MEEmrTypeID])
GO

ALTER TABLE [dbo].[MEParamReportRelations] CHECK CONSTRAINT [FK_MEParamReportRelations_MEEmrTypes]
GO

ALTER TABLE [dbo].[MEParamReportRelations]  WITH CHECK ADD  CONSTRAINT [FK_MEParamReportRelations_MEParamReports] FOREIGN KEY([FK_MEParamReportID])
REFERENCES [dbo].[MEParamReports] ([MEParamReportID])
GO

ALTER TABLE [dbo].[MEParamReportRelations] CHECK CONSTRAINT [FK_MEParamReportRelations_MEParamReports]
GO

ALTER TABLE [dbo].[MEParamReportRelations]  WITH CHECK ADD  CONSTRAINT [FK_MEParamReportRelations_MEParams] FOREIGN KEY([FK_MEParamID])
REFERENCES [dbo].[MEParams] ([MEParamID])
GO

ALTER TABLE [dbo].[MEParamReportRelations] CHECK CONSTRAINT [FK_MEParamReportRelations_MEParams]
GO

ALTER TABLE [dbo].[MEParamReportRelations]  WITH CHECK ADD  CONSTRAINT [FK_MEParamReportRelations_METemplates] FOREIGN KEY([FK_METemplateID])
REFERENCES [dbo].[METemplates] ([METemplateID])
GO

ALTER TABLE [dbo].[MEParamReportRelations] CHECK CONSTRAINT [FK_MEParamReportRelations_METemplates]
GO



GO

/****** Object:  Table [dbo].[MEEmrDocumentValidates]    Script Date: 7/14/2021 7:14:09 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MEEmrDocumentValidates](
	[MEEmrDocumentValidateID] [int] NOT NULL,
	[AAStatus] [varchar](50) NULL,
	[AACreatedUser] [nvarchar](50) NULL,
	[AACreatedDate] [datetime] NOT NULL,
	[AAUpdatedUser] [nvarchar](50) NULL,
	[AAUpdatedDate] [datetime] NOT NULL,
	[FK_MEEmrID] [int] NOT NULL,
	[FK_METemplateID] [int] NULL,
	[FK_MEEmrDocumentID] [int] NULL,
	[MEEmrDocumentValidateMode] [nvarchar](50) NULL,
	[MEEmrDocumentValidateValue] [nvarchar](50) NULL,
	[MEEmrDocumentValidateRemark] [nvarchar](1024) NULL,
 CONSTRAINT [PK_MEEmrDocumentValidates] PRIMARY KEY CLUSTERED 
(
	[MEEmrDocumentValidateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MEEmrDocumentValidates] ADD  CONSTRAINT [DF_MEEmrDocumentValidates_AACreatedDate]  DEFAULT ('9999-12-31 23:59:59.997') FOR [AACreatedDate]
GO

ALTER TABLE [dbo].[MEEmrDocumentValidates] ADD  CONSTRAINT [DF_MEEmrDocumentValidates_AAUpdatedDate]  DEFAULT ('9999-12-31 23:59:59.997') FOR [AAUpdatedDate]
GO

ALTER TABLE [dbo].[MEEmrDocumentValidates]  WITH CHECK ADD  CONSTRAINT [FK_MEEmrDocumentValidates_MEEmrs] FOREIGN KEY([FK_MEEmrID])
REFERENCES [dbo].[MEEmrs] ([MEEmrID])
GO

ALTER TABLE [dbo].[MEEmrDocumentValidates] CHECK CONSTRAINT [FK_MEEmrDocumentValidates_MEEmrs]
GO

ALTER TABLE [dbo].[MEEmrDocumentValidates]  WITH CHECK ADD  CONSTRAINT [FK_MEEmrDocumentValidates_METemplates] FOREIGN KEY([FK_METemplateID])
REFERENCES [dbo].[METemplates] ([METemplateID])
GO

ALTER TABLE [dbo].[MEEmrDocumentValidates] CHECK CONSTRAINT [FK_MEEmrDocumentValidates_METemplates]
GO



USE [db]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[METemplateIndexs](
	[METemplateIndexID] [int] NOT NULL,
	[FK_MEEmrTypeID] [int] NOT NULL,
	[METemplateIndexOrder] [int] NOT NULL,
	[METemplateIndexName] [nvarchar](250) NULL,
	[METemplateIndexDesc] bit NOT NULL,
	[AAStatus] [varchar](50) NULL,
	[AACreatedUser] [nvarchar](50) NULL,
	[AACreatedDate] [datetime] NOT NULL,
	[AAUpdatedUser] [nvarchar](50) NULL,
	[AAUpdatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_METemplateIndexs] PRIMARY KEY CLUSTERED 
(
	[METemplateIndexID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[METemplateIndexs] ADD  CONSTRAINT [METemplateIndexs_DF_FK_MEEmrTypeID]  DEFAULT ((0)) FOR [FK_MEEmrTypeID]
GO

ALTER TABLE [dbo].[METemplateIndexs]  WITH CHECK ADD  CONSTRAINT [FK_METemplateIndex_MEEmrTypes] FOREIGN KEY([FK_MEEmrTypeID])
REFERENCES [dbo].[MEEmrTypes] ([MEEmrTypeID])
GO

ALTER TABLE [dbo].[METemplateIndexs] CHECK CONSTRAINT [FK_METemplateIndex_MEEmrTypes]
GO


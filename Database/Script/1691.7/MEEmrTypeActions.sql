/****** Object:  Table [dbo].[MEEmrTypeActions]    Script Date: 11/5/2020 10:11:59 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MEEmrTypeActions]') AND type in (N'U'))
DROP TABLE [dbo].[MEEmrTypeActions]
GO

/****** Object:  Table [dbo].[MEEmrTypeActions]    Script Date: 11/5/2020 10:11:59 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MEEmrTypeActions](
	[MEEmrTypeActionID] [int] NOT NULL,
	[AAStatus] [varchar](50) NULL,
	[MEEmrTypeActionOrder] [int] NOT NULL,
	[FK_MEEmrTypeID] [int] NOT NULL,
	[FK_MEEmrActionID] [int] NOT NULL,
	[AACreatedUser] [nvarchar](50) NULL,
	[AACreatedDate] [datetime] NOT NULL,
	[AAUpdatedUser] [nvarchar](50) NULL,
	[AAUpdatedDate] [datetime] NOT NULL,
	[MEEmrTypeActionWhen] [varchar](100) NULL,
	[MEEmrTypeActionDo] [varchar](100) NULL,
	[MEEmrTypeActionCacheExpire] [int] NULL,
 CONSTRAINT [PK_MEEmrTypeActions] PRIMARY KEY CLUSTERED 
(
	[MEEmrTypeActionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MEEmrTypeActions] ADD  CONSTRAINT [MEEmrTypeActions_DF_MEEmrTypeActionOrder]  DEFAULT ((0)) FOR [MEEmrTypeActionOrder]
GO

ALTER TABLE [dbo].[MEEmrTypeActions] ADD  CONSTRAINT [MEEmrTypeActions_DF_FK_MEEmrTypeID]  DEFAULT ((0)) FOR [FK_MEEmrTypeID]
GO

ALTER TABLE [dbo].[MEEmrTypeActions] ADD  CONSTRAINT [MEEmrTypeActions_DF_FK_MEEmrActionID]  DEFAULT ((0)) FOR [FK_MEEmrActionID]
GO

ALTER TABLE [dbo].[MEEmrTypeActions] ADD  CONSTRAINT [MEEmrTypeActions_DF_AACreatedDate]  DEFAULT ('9999-12-31 23:59:59.997') FOR [AACreatedDate]
GO

ALTER TABLE [dbo].[MEEmrTypeActions] ADD  CONSTRAINT [MEEmrTypeActions_DF_AAUpdatedDate]  DEFAULT ('9999-12-31 23:59:59.997') FOR [AAUpdatedDate]
GO

ALTER TABLE [dbo].[MEEmrTypeActions]  WITH CHECK ADD  CONSTRAINT [FK_MEEmrTypeActions_MEEmrActions] FOREIGN KEY([FK_MEEmrActionID])
REFERENCES [dbo].[MEEmrActions] ([MEEmrActionID])
GO

ALTER TABLE [dbo].[MEEmrTypeActions] CHECK CONSTRAINT [FK_MEEmrTypeActions_MEEmrActions]
GO

ALTER TABLE [dbo].[MEEmrTypeActions]  WITH CHECK ADD  CONSTRAINT [FK_MEEmrTypeActions_MEEmrTypes] FOREIGN KEY([FK_MEEmrTypeID])
REFERENCES [dbo].[MEEmrTypes] ([MEEmrTypeID])
GO

ALTER TABLE [dbo].[MEEmrTypeActions] CHECK CONSTRAINT [FK_MEEmrTypeActions_MEEmrTypes]
GO



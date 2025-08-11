GO

ALTER TABLE [dbo].[MEEmrRelations] DROP CONSTRAINT [FK_MEEmrRelations_MEEmrTo]
GO

ALTER TABLE [dbo].[MEEmrRelations] DROP CONSTRAINT [FK_MEEmrRelations_MEEmrFrom]
GO

ALTER TABLE [dbo].[MEEmrRelations] DROP CONSTRAINT [DF_MEEmrRelations_MEEmrRelationDate]
GO

ALTER TABLE [dbo].[MEEmrRelations] DROP CONSTRAINT [DF_MEEmrRelations_AAUpdatedDate]
GO

ALTER TABLE [dbo].[MEEmrRelations] DROP CONSTRAINT [DF_MEEmrRelations_AACreatedDate]
GO

/****** Object:  Table [dbo].[MEEmrRelations]    Script Date: 25/02/2021 11:18:58 SA ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MEEmrRelations]') AND type in (N'U'))
DROP TABLE [dbo].[MEEmrRelations]
GO

/****** Object:  Table [dbo].[MEEmrRelations]    Script Date: 25/02/2021 11:18:58 SA ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MEEmrRelations](
	[MEEmrRelationID] [int] NOT NULL,
	[AAStatus] [varchar](50) NULL,
	[AACreatedUser] [nvarchar](50) NULL,
	[AACreatedDate] [datetime] NOT NULL,
	[AAUpdatedUser] [nvarchar](50) NULL,
	[AAUpdatedDate] [datetime] NOT NULL,
	[FK_MEEmrFromID] [int] NOT NULL,
	[FK_MEEmrToID] [int] NOT NULL,
	[MEEmrRelationFromName] [nvarchar](50) NOT NULL,
	[MEEmrRelationToName] [nvarchar](50) NOT NULL,
	[MEEmrRelationDate] [datetime] NOT NULL,
	[MEEmrRelationRemark] [nvarchar](4000) NULL,
 CONSTRAINT [PK_MEEmrRelations] PRIMARY KEY CLUSTERED 
(
	[MEEmrRelationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MEEmrRelations] ADD  CONSTRAINT [DF_MEEmrRelations_AACreatedDate]  DEFAULT ('9999-12-31 23:59:59.997') FOR [AACreatedDate]
GO

ALTER TABLE [dbo].[MEEmrRelations] ADD  CONSTRAINT [DF_MEEmrRelations_AAUpdatedDate]  DEFAULT ('9999-12-31 23:59:59.997') FOR [AAUpdatedDate]
GO

ALTER TABLE [dbo].[MEEmrRelations] ADD  CONSTRAINT [DF_MEEmrRelations_MEEmrRelationDate]  DEFAULT (getdate()) FOR [MEEmrRelationDate]
GO

ALTER TABLE [dbo].[MEEmrRelations]  WITH CHECK ADD  CONSTRAINT [FK_MEEmrRelations_MEEmrFrom] FOREIGN KEY([FK_MEEmrFromID])
REFERENCES [dbo].[MEEmrs] ([MEEmrID])
GO

ALTER TABLE [dbo].[MEEmrRelations] CHECK CONSTRAINT [FK_MEEmrRelations_MEEmrFrom]
GO

ALTER TABLE [dbo].[MEEmrRelations]  WITH CHECK ADD  CONSTRAINT [FK_MEEmrRelations_MEEmrTo] FOREIGN KEY([FK_MEEmrToID])
REFERENCES [dbo].[MEEmrs] ([MEEmrID])
GO

ALTER TABLE [dbo].[MEEmrRelations] CHECK CONSTRAINT [FK_MEEmrRelations_MEEmrTo]
GO

-- sp_helpindex '[dbo].[MEEmrRelations]'
IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'IX_AAStatus_MEEmrRelations' AND object_id = OBJECT_ID('MEEmrRelations'))
BEGIN
	CREATE NONCLUSTERED INDEX IX_AAStatus_MEEmrRelations ON MEEmrRelations(AAStatus);
END
GO
IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'IX_FK_MEEmrRelations_MEEmrFrom' AND object_id = OBJECT_ID('MEEmrRelations'))
BEGIN
	CREATE NONCLUSTERED INDEX IX_FK_MEEmrRelations_MEEmrFrom ON MEEmrRelations(FK_MEEmrFromID);
END
GO
IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'IX_FK_MEEmrRelations_MEEmrTo' AND object_id = OBJECT_ID('MEEmrRelations'))
BEGIN
	CREATE NONCLUSTERED INDEX IX_FK_MEEmrRelations_MEEmrTo ON MEEmrRelations(FK_MEEmrToID);
END
GO

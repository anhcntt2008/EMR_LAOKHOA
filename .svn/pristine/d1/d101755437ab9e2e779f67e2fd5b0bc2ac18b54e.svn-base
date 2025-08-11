GO

ALTER TABLE [dbo].[MEEmrMergeHistoryDetails] DROP CONSTRAINT [FK_MEEmrMergeHistoryDetails_MEEmrMergeHistories]
GO

ALTER TABLE [dbo].[MEEmrMergeHistoryDetails] DROP CONSTRAINT [FK_MEEmrMergeHistoryDetails_MEEmrDocuments]
GO

ALTER TABLE [dbo].[MEEmrMergeHistoryDetails] DROP CONSTRAINT [DF_MEEmrMergeHistoryDetails_AAUpdatedDate]
GO

ALTER TABLE [dbo].[MEEmrMergeHistoryDetails] DROP CONSTRAINT [DF_MEEmrMergeHistoryDetails_AACreatedDate]
GO

/****** Object:  Table [dbo].[MEEmrMergeHistoryDetails]    Script Date: 1/15/2021 2:53:47 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MEEmrMergeHistoryDetails]') AND type in (N'U'))
DROP TABLE [dbo].[MEEmrMergeHistoryDetails]
GO

/****** Object:  Table [dbo].[MEEmrMergeHistoryDetails]    Script Date: 1/15/2021 2:53:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MEEmrMergeHistoryDetails](
	[MEEmrMergeHistoryDetailID] [int] NOT NULL,
	[AAStatus] [varchar](50) NULL,
	[AACreatedUser] [nvarchar](50) NULL,
	[AACreatedDate] [datetime] NOT NULL,
	[AAUpdatedUser] [nvarchar](50) NULL,
	[AAUpdatedDate] [datetime] NOT NULL,
	[FK_MEEmrMergeHistoryID] [int] NOT NULL,
	[FK_MEEmrDocumentID] [int] NOT NULL,
 CONSTRAINT [PK_MEEmrMergeHistoryDetails] PRIMARY KEY CLUSTERED 
(
	[MEEmrMergeHistoryDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MEEmrMergeHistoryDetails] ADD  CONSTRAINT [DF_MEEmrMergeHistoryDetails_AACreatedDate]  DEFAULT ('9999-12-31 23:59:59.997') FOR [AACreatedDate]
GO

ALTER TABLE [dbo].[MEEmrMergeHistoryDetails] ADD  CONSTRAINT [DF_MEEmrMergeHistoryDetails_AAUpdatedDate]  DEFAULT ('9999-12-31 23:59:59.997') FOR [AAUpdatedDate]
GO

ALTER TABLE [dbo].[MEEmrMergeHistoryDetails]  WITH CHECK ADD  CONSTRAINT [FK_MEEmrMergeHistoryDetails_MEEmrDocuments] FOREIGN KEY([FK_MEEmrDocumentID])
REFERENCES [dbo].[MEEmrDocuments] ([MEEmrDocumentID])
GO

ALTER TABLE [dbo].[MEEmrMergeHistoryDetails] CHECK CONSTRAINT [FK_MEEmrMergeHistoryDetails_MEEmrDocuments]
GO

ALTER TABLE [dbo].[MEEmrMergeHistoryDetails]  WITH CHECK ADD  CONSTRAINT [FK_MEEmrMergeHistoryDetails_MEEmrMergeHistories] FOREIGN KEY([FK_MEEmrMergeHistoryID])
REFERENCES [dbo].[MEEmrMergeHistories] ([MEEmrMergeHistoryID])
GO

ALTER TABLE [dbo].[MEEmrMergeHistoryDetails] CHECK CONSTRAINT [FK_MEEmrMergeHistoryDetails_MEEmrMergeHistories]
GO

-- sp_helpindex '[dbo].[MEEmrMergeHistoryDetails]'
IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'IX_AAStatus_MEEmrMergeHistoryDetails' AND object_id = OBJECT_ID('MEEmrMergeHistoryDetails'))
BEGIN
	CREATE NONCLUSTERED INDEX IX_AAStatus_MEEmrMergeHistoryDetails ON MEEmrMergeHistoryDetails(AAStatus);
END
GO
IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'IX_FK_MEEmrMergeHistoryDetails_MEEmrDocuments' AND object_id = OBJECT_ID('MEEmrMergeHistoryDetails'))
BEGIN
	CREATE NONCLUSTERED INDEX IX_FK_MEEmrMergeHistoryDetails_MEEmrDocuments ON MEEmrMergeHistoryDetails(FK_MEEmrDocumentID);
END
GO
IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'IX_FK_MEEmrMergeHistoryDetails_MEEmrMergeHistories' AND object_id = OBJECT_ID('MEEmrMergeHistoryDetails'))
BEGIN
	CREATE NONCLUSTERED INDEX IX_FK_MEEmrMergeHistoryDetails_MEEmrMergeHistories ON MEEmrMergeHistoryDetails(FK_MEEmrMergeHistoryID);
END
GO



GO

ALTER TABLE [dbo].[MEEmrMergeHistories] DROP CONSTRAINT [FK_MEEmrMergeHistory_MEEmrTo]
GO

ALTER TABLE [dbo].[MEEmrMergeHistories] DROP CONSTRAINT [FK_MEEmrMergeHistory_MEEmrFrom]
GO

ALTER TABLE [dbo].[MEEmrMergeHistories] DROP CONSTRAINT [FK_MEEmrMergeHistories_HRDepartmentTo]
GO

ALTER TABLE [dbo].[MEEmrMergeHistories] DROP CONSTRAINT [FK_MEEmrMergeHistories_HRDepartmentFrom]
GO

ALTER TABLE [dbo].[MEEmrMergeHistories] DROP CONSTRAINT [FK_MEEmrMergeHistories_HRDepartmentCreated]
GO

ALTER TABLE [dbo].[MEEmrMergeHistories] DROP CONSTRAINT [MEEmrMergeHistories_DF_AAUpdatedDate]
GO

ALTER TABLE [dbo].[MEEmrMergeHistories] DROP CONSTRAINT [MEEmrMergeHistories_DF_AACreatedDate]
GO

/****** Object:  Table [dbo].[MEEmrMergeHistories]    Script Date: 04/02/2021 3:55:41 CH ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MEEmrMergeHistories]') AND type in (N'U'))
DROP TABLE [dbo].[MEEmrMergeHistories]
GO

/****** Object:  Table [dbo].[MEEmrMergeHistories]    Script Date: 04/02/2021 3:55:41 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MEEmrMergeHistories](
	[MEEmrMergeHistoryID] [int] NOT NULL,
	[AAStatus] [varchar](50) NULL,
	[AACreatedUser] [nvarchar](50) NULL,
	[AACreatedDate] [datetime] NOT NULL,
	[AAUpdatedUser] [nvarchar](50) NULL,
	[AAUpdatedDate] [datetime] NOT NULL,
	[FK_MEEmrFromID] [int] NOT NULL,
	[MEEmrFromNo] [varchar](50) NOT NULL,
	[FK_MEEmrToID] [int] NOT NULL,
	[MEEmrToNo] [varchar](50) NOT NULL,
	[MEEmrMergeHistoryDate] [datetime] NOT NULL,
	[FK_HRDepartmentFromID] [int] NOT NULL,
	[FK_HRDepartmentToID] [int] NOT NULL,
	[MEEmrMergeHistoryStatus] [varchar](50) NULL,
	[MEEmrMergeHistoryRemark] [nvarchar](4000) NULL,
	[FK_HRDepartmentCreatedUser] [int] NULL,
 CONSTRAINT [PK_MEEmrMergeHistory] PRIMARY KEY CLUSTERED 
(
	[MEEmrMergeHistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MEEmrMergeHistories] ADD  CONSTRAINT [MEEmrMergeHistories_DF_AACreatedDate]  DEFAULT ('9999-12-31 23:59:59.997') FOR [AACreatedDate]
GO

ALTER TABLE [dbo].[MEEmrMergeHistories] ADD  CONSTRAINT [MEEmrMergeHistories_DF_AAUpdatedDate]  DEFAULT ('9999-12-31 23:59:59.997') FOR [AAUpdatedDate]
GO

ALTER TABLE [dbo].[MEEmrMergeHistories]  WITH CHECK ADD  CONSTRAINT [FK_MEEmrMergeHistories_HRDepartmentCreated] FOREIGN KEY([FK_HRDepartmentCreatedUser])
REFERENCES [dbo].[HRDepartments] ([HRDepartmentID])
GO

ALTER TABLE [dbo].[MEEmrMergeHistories] CHECK CONSTRAINT [FK_MEEmrMergeHistories_HRDepartmentCreated]
GO

ALTER TABLE [dbo].[MEEmrMergeHistories]  WITH CHECK ADD  CONSTRAINT [FK_MEEmrMergeHistories_HRDepartmentFrom] FOREIGN KEY([FK_HRDepartmentFromID])
REFERENCES [dbo].[HRDepartments] ([HRDepartmentID])
GO

ALTER TABLE [dbo].[MEEmrMergeHistories] CHECK CONSTRAINT [FK_MEEmrMergeHistories_HRDepartmentFrom]
GO

ALTER TABLE [dbo].[MEEmrMergeHistories]  WITH CHECK ADD  CONSTRAINT [FK_MEEmrMergeHistories_HRDepartmentTo] FOREIGN KEY([FK_HRDepartmentToID])
REFERENCES [dbo].[HRDepartments] ([HRDepartmentID])
GO

ALTER TABLE [dbo].[MEEmrMergeHistories] CHECK CONSTRAINT [FK_MEEmrMergeHistories_HRDepartmentTo]
GO

ALTER TABLE [dbo].[MEEmrMergeHistories]  WITH CHECK ADD  CONSTRAINT [FK_MEEmrMergeHistory_MEEmrFrom] FOREIGN KEY([FK_MEEmrFromID])
REFERENCES [dbo].[MEEmrs] ([MEEmrID])
GO

ALTER TABLE [dbo].[MEEmrMergeHistories] CHECK CONSTRAINT [FK_MEEmrMergeHistory_MEEmrFrom]
GO

ALTER TABLE [dbo].[MEEmrMergeHistories]  WITH CHECK ADD  CONSTRAINT [FK_MEEmrMergeHistory_MEEmrTo] FOREIGN KEY([FK_MEEmrToID])
REFERENCES [dbo].[MEEmrs] ([MEEmrID])
GO

ALTER TABLE [dbo].[MEEmrMergeHistories] CHECK CONSTRAINT [FK_MEEmrMergeHistory_MEEmrTo]
GO

-- sp_helpindex '[dbo].[MEEmrMergeHistories]'
IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'IX_AAStatus_MEEmrMergeHistories' AND object_id = OBJECT_ID('MEEmrMergeHistories'))
BEGIN
	CREATE NONCLUSTERED INDEX IX_AAStatus_MEEmrMergeHistories ON MEEmrMergeHistories(AAStatus);
END
GO
IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'IX_FK_MEEmrMergeHistories_HRDepartmentCreated' AND object_id = OBJECT_ID('MEEmrMergeHistories'))
BEGIN
	CREATE NONCLUSTERED INDEX IX_FK_MEEmrMergeHistories_HRDepartmentCreated ON MEEmrMergeHistories(FK_HRDepartmentCreatedUser);
END
GO
IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'IX_FK_MEEmrMergeHistories_HRDepartmentFrom' AND object_id = OBJECT_ID('MEEmrMergeHistories'))
BEGIN
	CREATE NONCLUSTERED INDEX IX_FK_MEEmrMergeHistories_HRDepartmentFrom ON MEEmrMergeHistories(FK_HRDepartmentFromID);
END
GO
IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'IX_FK_MEEmrMergeHistories_HRDepartmentTo' AND object_id = OBJECT_ID('MEEmrMergeHistories'))
BEGIN
	CREATE NONCLUSTERED INDEX IX_FK_MEEmrMergeHistories_HRDepartmentTo ON MEEmrMergeHistories(FK_HRDepartmentToID);
END
GO
IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'IX_FK_MEEmrMergeHistory_MEEmrFrom' AND object_id = OBJECT_ID('MEEmrMergeHistories'))
BEGIN
	CREATE NONCLUSTERED INDEX IX_FK_MEEmrMergeHistory_MEEmrFrom ON MEEmrMergeHistories(FK_MEEmrFromID);
END
GO
IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'IX_FK_MEEmrMergeHistory_MEEmrTo' AND object_id = OBJECT_ID('MEEmrMergeHistories'))
BEGIN
	CREATE NONCLUSTERED INDEX IX_FK_MEEmrMergeHistory_MEEmrTo ON MEEmrMergeHistories(FK_MEEmrToID);
END
GO
GO

ALTER TABLE [dbo].[MEEmrSumLogs] DROP CONSTRAINT [FK_MEEmrSumLogs_MEEmrs]
GO

/****** Object:  Table [dbo].[MEEmrSumLogs]    Script Date: 9/7/2021 7:12:49 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MEEmrSumLogs]') AND type in (N'U'))
DROP TABLE [dbo].[MEEmrSumLogs]
GO

/****** Object:  Table [dbo].[MEEmrSumLogs]    Script Date: 9/7/2021 7:12:49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MEEmrSumLogs](
	[MEEmrSumLogID] [int] NOT NULL,
	[AAStatus] [varchar](50) NULL,
	[AACreatedUser] [varchar](50) NULL,
	[AACreatedDate] [datetime] NULL,
	[AAUpdatedUser] [varchar](50) NULL,
	[AAUpdatedDate] [datetime] NULL,
	[FK_MEEmrID] [int] NOT NULL,
	[MEEmrSumCode] [nvarchar](50) NULL,
	[MEEmrSumStoreCode] [nvarchar](50) NULL,
	[MEEmrSumDate] [datetime] NULL,
	[MEEmrSumRemark] [nvarchar](4000) NULL,
	[MEEmrSumFileName] [varchar](1024) NULL,
	[MEEmrSumMongoID] [varchar](50) NULL,
	[MEEmrSumStatus] [varchar](50) NULL,
	[MEEmrSumXMLStatus] [varchar](50) NULL,
	[MEEmrSumXMLDesc] [nvarchar](4000) NULL,
	[MEEmrSumXMLDate] [datetime] NULL,
	[MEEmrSumXMLSentNum] [int] NULL,
 CONSTRAINT [PK_MEEmrSumHistorys] PRIMARY KEY CLUSTERED 
(
	[MEEmrSumLogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MEEmrSumLogs]  WITH CHECK ADD  CONSTRAINT [FK_MEEmrSumLogs_MEEmrs] FOREIGN KEY([FK_MEEmrID])
REFERENCES [dbo].[MEEmrs] ([MEEmrID])
GO

ALTER TABLE [dbo].[MEEmrSumLogs] CHECK CONSTRAINT [FK_MEEmrSumLogs_MEEmrs]
GO



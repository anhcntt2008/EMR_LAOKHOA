GO

ALTER TABLE [dbo].[MEEmrSums] DROP CONSTRAINT [FK_MEEmrSums_MEEmrs]
GO

ALTER TABLE [dbo].[MEEmrSums] DROP CONSTRAINT [DF_MEEmrSums_MEEmrSumXMLSentNum]
GO

/****** Object:  Table [dbo].[MEEmrSums]    Script Date: 9/5/2021 6:36:05 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MEEmrSums]') AND type in (N'U'))
DROP TABLE [dbo].[MEEmrSums]
GO

/****** Object:  Table [dbo].[MEEmrSums]    Script Date: 9/5/2021 6:36:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MEEmrSums](
	[MEEmrSumID] [int] NOT NULL,
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
 CONSTRAINT [PK_MEEmrSums] PRIMARY KEY CLUSTERED 
(
	[MEEmrSumID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MEEmrSums] ADD  CONSTRAINT [DF_MEEmrSums_MEEmrSumXMLSentNum]  DEFAULT ((0)) FOR [MEEmrSumXMLSentNum]
GO

ALTER TABLE [dbo].[MEEmrSums]  WITH CHECK ADD  CONSTRAINT [FK_MEEmrSums_MEEmrs] FOREIGN KEY([FK_MEEmrID])
REFERENCES [dbo].[MEEmrs] ([MEEmrID])
GO

ALTER TABLE [dbo].[MEEmrSums] CHECK CONSTRAINT [FK_MEEmrSums_MEEmrs]
GO



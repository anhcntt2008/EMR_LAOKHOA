USE [db]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MEEmrArchives](
	[MEEmrArchiveID] [int] NOT NULL,
	[AAStatus] [varchar](50) NULL,
	[AACreatedUser] [varchar](50) NULL,
	[AACreatedDate] [datetime] NOT NULL,
	[AAUpdatedUser] [varchar](50) NULL,
	[AAUpdatedDate] [datetime] NOT NULL,
	[FK_MEEmrID] [int] NOT NULL,
	[FK_HRDepartmentID] [int] NOT NULL,
	[FK_HREmployeeID] [int] NOT NULL,
	[MEEmrArchiveDate] [datetime] NOT NULL,
	[MEEmrArchiveRemark] [nvarchar](4000) NULL,
	[MEEmrArchiveSignTime] [datetime] NOT NULL,
	[MEEmrArchiveStatus] [varchar](50) NULL,
	[MEEmrArchiveFile] [varchar](1000) NOT NULL,
	[MEEmrArchiveFileExt] [varchar](10) NOT NULL,
	[MEEmrArchiveFileHash] [varchar](500) NULL,
 CONSTRAINT [PK_MEEmrArchives] PRIMARY KEY CLUSTERED 
(
	[MEEmrArchiveID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MEEmrArchives] ADD  CONSTRAINT [MEEmrArchives_DF_AACreatedDate]  DEFAULT ('9999-12-31 23:59:59.997') FOR [AACreatedDate]
GO

ALTER TABLE [dbo].[MEEmrArchives] ADD  CONSTRAINT [MEEmrArchives_DF_AAUpdatedDate]  DEFAULT ('9999-12-31 23:59:59.997') FOR [AAUpdatedDate]
GO

ALTER TABLE [dbo].[MEEmrArchives]  WITH CHECK ADD  CONSTRAINT [FK_MEEmrArchives_HRDepartment] FOREIGN KEY([FK_HRDepartmentID])
REFERENCES [dbo].[HRDepartments] ([HRDepartmentID])
GO

ALTER TABLE [dbo].[MEEmrArchives] CHECK CONSTRAINT [FK_MEEmrArchives_HRDepartment]
GO

ALTER TABLE [dbo].[MEEmrArchives]  WITH CHECK ADD  CONSTRAINT [FK_MEEmrArchives_HREmployeeID] FOREIGN KEY([FK_HREmployeeID])
REFERENCES [dbo].[HREmployees] ([HREmployeeID])
GO

ALTER TABLE [dbo].[MEEmrArchives] CHECK CONSTRAINT [FK_MEEmrArchives_HREmployeeID]
GO

ALTER TABLE [dbo].[MEEmrArchives]  WITH CHECK ADD  CONSTRAINT [FK_MEEmrArchives_MEEmrID] FOREIGN KEY([FK_MEEmrID])
REFERENCES [dbo].[MEEmrs] ([MEEmrID])
GO

ALTER TABLE [dbo].[MEEmrArchives] CHECK CONSTRAINT [FK_MEEmrArchives_MEEmrID]
GO



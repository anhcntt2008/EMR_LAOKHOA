
CREATE TABLE [dbo].[MEEmrDocumentSigns](
	[MEEmrDocumentSignID] [int] NOT NULL,
	[AAStatus] [varchar](50) NULL,
	[AACreatedUser] [nvarchar](50) NULL,
	[AACreatedDate] [datetime] NULL,
	[AAUpdatedUser] [nvarchar](50) NULL,
	[AAUpdatedDate] [datetime] NULL,
	[FK_MEEmrDocumentID] [int] NOT NULL,
	[FK_HRDepartmentID] [int] NOT NULL,
	[FK_HREmployeeID] [int] NOT NULL,
	[MEEmrDocumentSignTime] [datetime] NOT NULL,
	[MEEmrDocumentSignFile] [varchar](1000) NOT NULL,
	[MEEmrDocumentSignFileExt] [varchar](10) NOT NULL,
 CONSTRAINT [PK_MEEmrDocumentSigns] PRIMARY KEY CLUSTERED 
(
	[MEEmrDocumentSignID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MEEmrDocumentSigns]  WITH CHECK ADD  CONSTRAINT [FK_MEEmrDocumentSigns_MEEmrDocument] FOREIGN KEY([FK_MEEmrDocumentID])
REFERENCES [dbo].[MEEmrDocuments] ([MEEmrDocumentID])
GO

ALTER TABLE [dbo].[MEEmrDocumentSigns] CHECK CONSTRAINT [FK_MEEmrDocumentSigns_MEEmrDocument]
GO

ALTER TABLE [dbo].[MEEmrDocumentSigns]  WITH CHECK ADD  CONSTRAINT [FK_MEEmrDocumentSigns_HRDepartment] FOREIGN KEY([FK_HRDepartmentID])
REFERENCES [dbo].[HRDepartments] ([HRDepartmentID])
GO

ALTER TABLE [dbo].[MEEmrDocumentSigns] CHECK CONSTRAINT [FK_MEEmrDocumentSigns_HRDepartment]
GO

ALTER TABLE [dbo].[MEEmrDocumentSigns]  WITH CHECK ADD  CONSTRAINT [FK_MEEmrDocumentSigns_HREmployee] FOREIGN KEY([FK_HREmployeeID])
REFERENCES [dbo].[HREmployees] ([HREmployeeID])
GO

ALTER TABLE [dbo].[MEEmrDocumentSigns] CHECK CONSTRAINT [FK_MEEmrDocumentSigns_HREmployee]
GO

INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'FK_MEEmrDocumentID', N'Tờ bệnh án', 'MEEmrDocumentSigns');
GO

INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'FK_HRDepartmentID', N'Khoa', 'MEEmrDocumentSigns');
GO

INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'FK_HREmployeeID', N'Người ký', 'MEEmrDocumentSigns');
GO

INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'MEEmrDocumentSignTime', N'Thời điểm ký', 'MEEmrDocumentSigns');
GO

INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'MEEmrDocumentSignFile', N'Tập tin', 'MEEmrDocumentSigns');
GO

INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'MEEmrDocumentSignFileExt', N'Mở rộng', 'MEEmrDocumentSigns');
GO
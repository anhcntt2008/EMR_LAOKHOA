CREATE TABLE [dbo].[MEEmrDocumentNotes](
	[MEEmrDocumentNoteID] [int] NOT NULL,
	[AAStatus] [varchar](50) NULL,
	[AACreatedUser] [nvarchar](50) NULL,
	[AACreatedDate] [datetime] NOT NULL,
	[AAUpdatedUser] [nvarchar](50) NULL,
	[AAUpdatedDate] [datetime] NOT NULL,
	[FK_MEEmrDocumentID] [int] NOT NULL,
	[FK_HRDepartmentID] [int] NOT NULL,
	[FK_HREmployeeID] [int] NOT NULL,
	[MEEmrDocumentNoteTime] [datetime] NOT NULL,
	[MEEmrDocumentNoteText] [nvarchar](500) NULL,
	[MEEmrDocumentNoteBookmark] [varchar](256) NULL
 CONSTRAINT [PK_MEEmrDocumentNotes] PRIMARY KEY CLUSTERED 
(
	[MEEmrDocumentNoteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MEEmrDocumentNotes] ADD  CONSTRAINT [MEEmrDocumentNotes_DF_AACreatedDate]  DEFAULT ('9999-12-31 23:59:59.997') FOR [AACreatedDate]
GO

ALTER TABLE [dbo].[MEEmrDocumentNotes] ADD  CONSTRAINT [MEEmrDocumentNotes_DF_AAUpdatedDate]  DEFAULT ('9999-12-31 23:59:59.997') FOR [AAUpdatedDate]
GO

ALTER TABLE [dbo].[MEEmrDocumentNotes]  WITH CHECK ADD  CONSTRAINT [FK_MEEmrDocumentNotes_HRDepartment] FOREIGN KEY([FK_HRDepartmentID])
REFERENCES [dbo].[HRDepartments] ([HRDepartmentID])
GO

ALTER TABLE [dbo].[MEEmrDocumentNotes] CHECK CONSTRAINT [FK_MEEmrDocumentNotes_HRDepartment]
GO

ALTER TABLE [dbo].[MEEmrDocumentNotes]  WITH CHECK ADD  CONSTRAINT [FK_MEEmrDocumentNotes_HREmployee] FOREIGN KEY([FK_HREmployeeID])
REFERENCES [dbo].[HREmployees] ([HREmployeeID])
GO

ALTER TABLE [dbo].[MEEmrDocumentNotes] CHECK CONSTRAINT [FK_MEEmrDocumentNotes_HREmployee]
GO

ALTER TABLE [dbo].[MEEmrDocumentNotes]  WITH CHECK ADD  CONSTRAINT [FK_MEEmrDocumentNotes_MEEmrDocument] FOREIGN KEY([FK_MEEmrDocumentID])
REFERENCES [dbo].[MEEmrDocuments] ([MEEmrDocumentID])
GO

ALTER TABLE [dbo].[MEEmrDocumentNotes] CHECK CONSTRAINT [FK_MEEmrDocumentNotes_MEEmrDocument]
GO

CREATE INDEX IX_MEEmrDocumentNotes_FK_MEEmrDocumentID_AAStatus ON [MEEmrDocumentNotes]([FK_MEEmrDocumentID], AAStatus);
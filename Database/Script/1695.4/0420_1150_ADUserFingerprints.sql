CREATE TABLE [dbo].[ADUserFingerprints](
	[ADUserFingerprintID] [int] NOT NULL,
	[AAStatus] [varchar](50) NULL,
	[AACreatedUser] [varchar](50) NULL,
	[AACreatedDate] [datetime] NOT NULL,
	[AAUpdatedUser] [varchar](50) NULL,
	[AAUpdatedDate] [datetime] NOT NULL,
	[FK_ADUserID] [int] NOT NULL,
	[ADUserFingerprintIndex] [int] NOT NULL,
	[ADUserFingerprintXml] [ntext] NOT NULL,
 CONSTRAINT [PK_ADUserFingerprints] PRIMARY KEY CLUSTERED 
(
	[ADUserFingerprintID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [dbo].[ADUserFingerprints]  WITH CHECK ADD  CONSTRAINT [FK_ADUserFingerprints_ADUsers] FOREIGN KEY([FK_ADUserID])
REFERENCES [dbo].[ADUsers] ([ADUserID])
GO

ALTER TABLE [dbo].[ADUserFingerprints] CHECK CONSTRAINT [FK_ADUserFingerprints_ADUsers]
GO

CREATE NONCLUSTERED INDEX [IX_FK_ADUserFingerprints_ADUsers_AAStatus] ON [dbo].[ADUserFingerprints]
(
	[AAStatus] ASC,
	[FK_ADUserID] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO



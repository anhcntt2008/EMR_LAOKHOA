DROP TABLE METemplateParamRelation
CREATE TABLE [dbo].[METemplateParams](
	[METemplateParamID] [int] NOT NULL,
	[FK_METemplateID] [int] NOT NULL,
	[FK_MEParamID] [int] NOT NULL,
	[METemplateParamPath] [varchar](1000) NOT NULL,
	[AAStatus] [varchar](50) NULL,
	[AACreatedDate] [datetime] NULL,
	[AACreatedUser] [nvarchar](50) NULL,
	[AAUpdatedDate] [datetime] NOT NULL,
	[AAUpdatedUser] [nvarchar](50) NULL,
 CONSTRAINT [PK_METemplateParams] PRIMARY KEY CLUSTERED 
(
	[METemplateParamID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].METemplateParams  WITH CHECK ADD  CONSTRAINT [METemplateParams_FK_MEParamsID] FOREIGN KEY([FK_MEParamID])
REFERENCES [dbo].[MEParams] ([MEParamID])
GO

ALTER TABLE [dbo].METemplateParams CHECK CONSTRAINT [METemplateParams_FK_MEParamsID]
GO

ALTER TABLE [dbo].METemplateParams  WITH CHECK ADD  CONSTRAINT [METemplateParams_FK_METemplateID] FOREIGN KEY([FK_METemplateID])
REFERENCES [dbo].[METemplates] ([METemplateID])
GO

ALTER TABLE [dbo].METemplateParams CHECK CONSTRAINT [METemplateParams_FK_METemplateID]
GO

INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'FK_METemplateID', N'Mẫu bệnh án', 'METemplateParams');
GO

INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'FK_MEParamID', N'Thẻ dữ liệu', 'METemplateParams');
GO

INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'METemplateParamPath', N'Đường dẫn', 'METemplateParams');
GO

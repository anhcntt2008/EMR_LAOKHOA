
CREATE TABLE [dbo].[ADUserGroupExtras](
	[ADUserGroupExtraID] [int] NOT NULL,
	[AAStatus] [varchar](10) NULL,
	[FK_ADUserGroupID] [int] NOT NULL,
	[FK_ADUserID] [int] NOT NULL,
	[ADUserGroupExtraDateAdd] [datetime] NOT NULL,
	[AACreatedUser] [nvarchar](50) NULL,
	[AACreatedDate] [datetime] NOT NULL,
	[AAUpdatedUser] [nvarchar](50) NULL,
	[AAUpdatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_ADUserGroupExtras] PRIMARY KEY CLUSTERED 
(
	[ADUserGroupExtraID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ADUserGroupExtras]  WITH CHECK ADD  CONSTRAINT [FK_ADUserGroupExtras_ADUserGroups] FOREIGN KEY([FK_ADUserGroupID])
REFERENCES [dbo].[ADUserGroups] ([ADUserGroupID])
GO

ALTER TABLE [dbo].[ADUserGroupExtras] CHECK CONSTRAINT [FK_ADUserGroupExtras_ADUserGroups]
GO

ALTER TABLE [dbo].[ADUserGroupExtras]  WITH CHECK ADD  CONSTRAINT [FK_ADUserGroupExtras_ADUsers] FOREIGN KEY([FK_ADUserID])
REFERENCES [dbo].[ADUsers] ([ADUserID])
GO

ALTER TABLE [dbo].[ADUserGroupExtras] CHECK CONSTRAINT [FK_ADUserGroupExtras_ADUsers]
GO



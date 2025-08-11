USE [db]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[STObjectStatePermissions](
	[STObjectStatePermissionID] [int] NOT NULL,
	[AAStatus] [varchar](50) NOT NULL,
	[FK_ADUserGroupID] [int] NOT NULL,
	[STObjectStatePermissionTable] [varchar](255) NOT NULL,
	[STObjectStatePermissionCol] [varchar](255) NOT NULL,
	[STObjectStatePermissionVal] [nvarchar](255) NOT NULL,
	[STObjectStatePermissionView] bit NOT NULL,
	[STObjectStatePermissionEdit] bit NOT NULL,
	[STObjectStatePermissionDelete] bit NOT NULL,
	[AACreatedUser] [nvarchar](50) NOT NULL,
	[AACreatedDate] [datetime] NOT NULL,
	[AAUpdatedUser] [nvarchar](50) NOT NULL,
	[AAUpdatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_STObjectStatePermissions] PRIMARY KEY CLUSTERED 
(
	[STObjectStatePermissionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[STObjectStatePermissions]  WITH CHECK ADD  CONSTRAINT [FK_STObjectStatePermissions_ADUserGroups] FOREIGN KEY([FK_ADUserGroupID])
REFERENCES [dbo].[ADUserGroups] ([ADUserGroupID])
GO

ALTER TABLE [dbo].[STObjectStatePermissions] CHECK CONSTRAINT [FK_STObjectStatePermissions_ADUserGroups]
GO

CREATE NONCLUSTERED INDEX [IX_FK_STObjectStatePermissions_ADUserGroups] ON [dbo].[STObjectStatePermissions]
(
	[FK_ADUserGroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_STObjectStatePermissions_STObjectStatePermissionTable] ON [dbo].[STObjectStatePermissions]
(
	[STObjectStatePermissionTable] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

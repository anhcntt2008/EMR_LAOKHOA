GO

/****** Object:  Table [dbo].[MENotifications]    Script Date: 25/05/2021 10:32:00 SA ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MENotifications](
	[MENotificationID] [int] NOT NULL,
	[AAStatus] [varchar](10) NULL,
	[AACreatedUser] [nvarchar](50) NULL,
	[AACreatedDate] [datetime] NOT NULL,
	[AAUpdatedUser] [nvarchar](50) NULL,
	[AAUpdatedDate] [datetime] NOT NULL,
	[MENotificationType] [nvarchar](512) NULL,
	[MENotificationName] [nvarchar](256) NULL,
	[MENotificationNo] [nvarchar](50) NULL,
	[MENotificationContent] [nvarchar](4000) NULL,
	[MENotificationActive] [bit] NULL,
	[MENotificationDepartment] [nvarchar](1024) NULL,
 CONSTRAINT [PK_GENotifications] PRIMARY KEY CLUSTERED 
(
	[MENotificationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MENotifications] ADD  CONSTRAINT [DF_GENotifications_AACreatedDate]  DEFAULT (getdate()) FOR [AACreatedDate]
GO

ALTER TABLE [dbo].[MENotifications] ADD  CONSTRAINT [DF_GENotifications_AAUpdatedDate]  DEFAULT (getdate()) FOR [AAUpdatedDate]
GO

ALTER TABLE [dbo].[MENotifications] ADD  CONSTRAINT [DF_GENotifications_IsActive]  DEFAULT ((0)) FOR [MENotificationActive]
GO



USE [DB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ADSystemConfigs](
	[ADSystemConfigID] [int] NOT NULL,
	[AAStatus] [varchar](10) NULL,
	[IsActive] [bit] NOT NULL,
	[ADSystemConfigGroup] [varchar](100) NOT NULL,
	[ADSystemConfigKey] [varchar](100) NOT NULL,
	[ADSystemConfigValue] [ntext] NOT NULL,
	[ADSystemConfigText] [nvarchar](250) NOT NULL,
	[ADSystemConfigDesc] [nvarchar](250) NULL,
 CONSTRAINT [PK_ADSystemConfigs] PRIMARY KEY CLUSTERED 
(
	[ADSystemConfigID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ADSystemConfigs] ADD  CONSTRAINT [ADSystemConfigs_DF_IsActive]  DEFAULT ((0)) FOR [IsActive]
GO



CREATE TABLE [dbo].[AbpJobStates](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[JobType] [varchar](512) NOT NULL,
	[JobDesc] [nvarchar](512) NOT NULL,
	[JobArgs] [nvarchar](4000) NULL,
	[TryCount] [smallint] NOT NULL,
	[NextFireTime] [datetime] NOT NULL,
	[LastFireTime] [datetime] NOT NULL,
	[LastEndTime] [datetime] NOT NULL,
	[LastState] [varchar](100) NOT NULL,
	[LastMsg] [nvarchar](512) NOT NULL,
	[Priority] [tinyint] NOT NULL,
	[CreationTime] [datetime] NOT NULL,
	[CreatorUserId] [bigint] NOT NULL,
	[TenantId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.AbpJobStates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[MEEmrSymbols](
	[MEEmrSymbolID] [int] NOT NULL,
	[AAStatus] [nvarchar](50) NOT NULL,
	[AACreatedDate] [datetime] NULL,
	[AACreatedUser] [nvarchar](50) NULL,
	[AAUpdatedDate] [datetime] NULL,
	[AAUpdatedUser] [nvarchar](50) NULL,
	[MEEmrSymbolNo] [varchar](50) NOT NULL,
	[MEEmrSymbolName] [nvarchar](255) NOT NULL,
	[MEEmrSymbolOrder] [int] NOT NULL,
	[MEEmrSymbolFont] [nvarchar](255) NOT NULL,
	[MEEmrSymbolChar] [int] NOT NULL,
	[MEEmrSymbolMenu] [bit] NOT NULL,
	[MEEmrSymbolGroup] [nvarchar](255) NOT NULL,
	[MEEmrSymbolIcon] [varbinary](max) NULL,
	[MEEmrSymbolRemark] [nvarchar](512) NOT NULL,
 CONSTRAINT [PK_MEEmrSymbols] PRIMARY KEY CLUSTERED 
(
	[MEEmrSymbolID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'MEEmrSymbolNo', N'Mã ký tự', 'MEEmrSymbols');
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'MEEmrSymbolName', N'Tên ký tự', 'MEEmrSymbols');
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'MEEmrSymbolOrder', N'Thứ tự', 'MEEmrSymbols');
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'MEEmrSymbolFont', N'Font', 'MEEmrSymbols');
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'MEEmrSymbolChar', N'Character code', 'MEEmrSymbols');
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'MEEmrSymbolMenu', N'Menu', 'MEEmrSymbols');
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'MEEmrSymbolMenu', N'Menu', 'MEEmrSymbols');
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'MEEmrSymbolGroup', N'Nhóm', 'MEEmrSymbols');
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'MEEmrSymbolIcon', N'Icon', 'MEEmrSymbols');
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'MEEmrSymbolRemark', N'Ghi chú', 'MEEmrSymbols');
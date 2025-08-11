
CREATE TABLE [dbo].[MEEmrGroupImages](
	[MEEmrGroupImageID] [int] NOT NULL,
	[AAStatus] [nvarchar](50) NOT NULL,
	[MEEmrGroupImageNo] [varchar](50) NOT NULL,
	[MEEmrGroupImageOrder] int  NULL,
	[MEEmrGroupImageName] [nvarchar](200) NOT NULL,
	[AACreatedDate] [datetime] NULL,
	[AACreatedUser] [nvarchar](50) NULL,
	[AAUpdatedDate] [datetime] NULL,
	[AAUpdatedUser] [nvarchar](50) NULL,
 CONSTRAINT [PK_MEEmrGroupImages] PRIMARY KEY CLUSTERED 
(
	[MEEmrGroupImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'MEEmrGroupImageNo', N'Mã nhóm', 'MEEmrGroupImages');
GO
INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'MEEmrGroupImageOrder', N'Thứ tự', 'MEEmrGroupImages');
GO
INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'MEEmrGroupImageName', N'Tên nhóm', 'MEEmrGroupImages');
GO

CREATE TABLE [dbo].[MEEmrImages](
	[MEEmrImageID] [int] NOT NULL,
	[FK_HRDepartmentID] int NOT NULL,
	[FK_MEEmrGroupImageID] [int] NOT NULL,
	[FK_HREmployeeID] int NOT NULL,
	[AAStatus] [nvarchar](50) NOT NULL,
	[MEEmrImageNo] [varchar](50) NOT NULL,
	[MEEmrImageOrder] int  NULL,
	[MEEmrImageName] [nvarchar](200) NOT NULL,
	[MEEmrImageSmall] [varbinary](MAX) NULL,
	[MEEmrImageLarge] [varbinary](MAX) NULL,
	[MEEmrImageShared] bit NOT NULL,
	[AACreatedDate] [datetime] NULL,
	[AACreatedUser] [nvarchar](50) NULL,
	[AAUpdatedDate] [datetime] NULL,
	[AAUpdatedUser] [nvarchar](50) NULL,
 CONSTRAINT [PK_MEEmrImages] PRIMARY KEY CLUSTERED 
(
	[MEEmrImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MEEmrImages]  WITH NOCHECK ADD  CONSTRAINT [MEEmrImages_FK_HRDepartmentID] FOREIGN KEY(FK_HRDepartmentID)
REFERENCES [dbo].HRDepartments (HRDepartmentID)
GO

ALTER TABLE [dbo].[MEEmrImages] CHECK CONSTRAINT [MEEmrImages_FK_HRDepartmentID]
GO

ALTER TABLE [dbo].[MEEmrImages]  WITH NOCHECK ADD  CONSTRAINT [MEEmrImages_FK_MEEmrGroupImageID] FOREIGN KEY([FK_MEEmrGroupImageID])
REFERENCES [dbo].MEEmrGroupImages ([MEEmrGroupImageID])
GO

ALTER TABLE [dbo].[MEEmrImages] CHECK CONSTRAINT [MEEmrImages_FK_MEEmrGroupImageID]
GO

ALTER TABLE [dbo].[MEEmrImages]  WITH NOCHECK ADD  CONSTRAINT [MEEmrImages_FK_HREmployeeID] FOREIGN KEY(FK_HREmployeeID)
REFERENCES [dbo].HREmployees (HREmployeeID)
GO

ALTER TABLE [dbo].[MEEmrImages] CHECK CONSTRAINT [MEEmrImages_FK_HREmployeeID]
GO

INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'FK_HRDepartmentID', N'Khoa', 'MEEmrImages');
GO
INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'FK_MEEmrGroupImageID', N'Nhóm', 'MEEmrImages');
GO
INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'FK_HREmployeeID', N'Người tạo', 'MEEmrImages');
GO
INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'MEEmrImageNo', N'Mã hình ảnh', 'MEEmrImages');
GO
INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'MEEmrImageOrder', N'Thứ tự', 'MEEmrImages');
GO
INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'MEEmrImageName', N'Tên', 'MEEmrImages');
GO
INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'MEEmrImageLarge', N'Ảnh lớn', 'MEEmrImages');
GO
INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'MEEmrImageShared', N'Dùng chung', 'MEEmrImages');
GO

CREATE TABLE [dbo].[MEEmrImagePatterns](
	[MEEmrImagePatternID] [int] NOT NULL,
	[FK_MEEmrImageID] int NOT NULL,
	[AAStatus] [nvarchar](50) NOT NULL,
	[MEEmrImagePatternNo] [varchar](50) NOT NULL,
	[MEEmrImagePatternOrder] int  NULL,
	[MEEmrImagePatternName] [nvarchar](200) NOT NULL,
	[MEEmrImagePatternImage] [varbinary](MAX) NULL,
	[AACreatedDate] [datetime] NULL,
	[AACreatedUser] [nvarchar](50) NULL,
	[AAUpdatedDate] [datetime] NULL,
	[AAUpdatedUser] [nvarchar](50) NULL,
 CONSTRAINT [PK_MEEmrImagePatterns] PRIMARY KEY CLUSTERED 
(
	[MEEmrImagePatternID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[MEEmrImagePatterns]  WITH NOCHECK ADD  CONSTRAINT [MEEmrImagePatterns_FK_MEEmrImageID] FOREIGN KEY(FK_MEEmrImageID)
REFERENCES [dbo].[MEEmrImages] (MEEmrImageID)
GO

ALTER TABLE [dbo].[MEEmrImagePatterns] CHECK CONSTRAINT [MEEmrImagePatterns_FK_MEEmrImageID]
GO
INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'FK_MEEmrImageID', N'Hình ảnh', 'MEEmrImagePatterns');
GO
INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'MEEmrImagePatternNo', N'Mã', 'MEEmrImagePatterns');
GO
INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'MEEmrImagePatternOrder', N'Thứ tự', 'MEEmrImagePatterns');
GO
INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'MEEmrImagePatternName', N'Tên mẫu', 'MEEmrImagePatterns');
GO
INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'MEEmrImagePatternImage', N'Hình ảnh', 'MEEmrImagePatterns');
GO

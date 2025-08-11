CREATE TABLE [dbo].[MEEmrShareHistories](
	[MEEmrShareHistoryID] [int] NOT NULL,
	[AAStatus] [varchar](50) NULL,
	[AACreatedUser] [nvarchar](50) NULL,
	[AACreatedDate] [datetime] NULL,
	[AAUpdatedUser] [nvarchar](50) NULL,
	[AAUpdatedDate] [datetime] NULL,
	[FK_HREmployeeShareByID] [int] NOT NULL,
	[MEEmrShareHistoryDate] [datetime] NOT NULL,
	[FK_MEEmrID] [int] NOT NULL,
	[FK_HRDepartmentID] [int] NOT NULL,
	[FK_HREmployeeID] [int] NOT NULL,
	[MEEmrShareHistoryFromDate] [datetime] NOT NULL,
	[MEEmrShareHistoryToDate] [datetime] NOT NULL,
	[MEEmrShareHistoryActive] [bit] NOT NULL,
	[MEEmrShareHistoryRemark] [nvarchar](4000) NULL,
 CONSTRAINT [PK_MEEmrShareHistory] PRIMARY KEY CLUSTERED 
(
	MEEmrShareHistoryID ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MEEmrShareHistories]  WITH CHECK ADD  CONSTRAINT [FK_MEEmrShareHistories_HRDepartment] FOREIGN KEY([FK_HRDepartmentID])
REFERENCES [dbo].[HRDepartments] ([HRDepartmentID])
GO

ALTER TABLE [dbo].[MEEmrShareHistories] CHECK CONSTRAINT [FK_MEEmrShareHistories_HRDepartment]
GO

ALTER TABLE [dbo].[MEEmrShareHistories]  WITH CHECK ADD  CONSTRAINT [FK_MEEmrShareHistories_HREmployeeShareByID] FOREIGN KEY([FK_HREmployeeShareByID])
REFERENCES [dbo].[HREmployees] ([HREmployeeID])
GO

ALTER TABLE [dbo].[MEEmrShareHistories] CHECK CONSTRAINT [FK_MEEmrShareHistories_HREmployeeShareByID]
GO

ALTER TABLE [dbo].[MEEmrShareHistories]  WITH CHECK ADD  CONSTRAINT [FK_MEEmrShareHistories_HREmployeeID] FOREIGN KEY([FK_HREmployeeID])
REFERENCES [dbo].[HREmployees] ([HREmployeeID])
GO

ALTER TABLE [dbo].[MEEmrShareHistories] CHECK CONSTRAINT [FK_MEEmrShareHistories_HREmployeeID]
GO

ALTER TABLE [dbo].[MEEmrShareHistories]  WITH CHECK ADD  CONSTRAINT [FK_MEEmrShareHistories_MEEmrID] FOREIGN KEY(FK_MEEmrID)
REFERENCES [dbo].[MEEmrs] (MEEmrID)
GO

ALTER TABLE [dbo].[MEEmrShareHistories] CHECK CONSTRAINT [FK_MEEmrShareHistories_MEEmrID]
GO
DELETE [AAColumnAlias] where AATableName = 'MEEmrShareHistories'
INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'FK_HREmployeeShareByID', N'Chia sẻ bởi', 'MEEmrShareHistories');
GO
INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'FK_HRDepartmentID', N'Khoa được chia sẻ', 'MEEmrShareHistories');
GO
INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'FK_HREmployeeID', N'Nhân viên được chia sẻ', 'MEEmrShareHistories');
GO
INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'MEEmrShareHistoryDate', N'Ngày chia sẻ', 'MEEmrShareHistories');
GO
INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'MEEmrShareHistoryFromDate', N'Từ ngày', 'MEEmrShareHistories');
GO
INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'MEEmrShareHistoryToDate', N'Đến ngày', 'MEEmrShareHistories');
GO
INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'MEEmrShareHistoryActive', N'Hiệu lực', 'MEEmrShareHistories');
GO

INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'MEEmrShareHistoryRemark', N'Ghi chú', 'MEEmrShareHistories');
GO

INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'MEEmrShareHistoryDays', N'Số ngày', 'MEEmrShareHistories');
GO

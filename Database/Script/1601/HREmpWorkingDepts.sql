DROP TABLE [dbo].[HREmpWorkingDepts]
CREATE TABLE [dbo].[HREmpWorkingDepts](
	[HREmpWorkingDeptID] [int] NOT NULL,
	[AAStatus] [varchar](50) NULL,
	[AACreatedUser] [nvarchar](50) NULL,
	[AACreatedDate] [datetime] NULL,
	[AAUpdatedUser] [nvarchar](50) NULL,
	[AAUpdatedDate] [datetime] NULL,
	[FK_HREmployeeID] [int] NULL,
	[FK_HRDepartmentID] [int] NOT NULL,
	[HREmpWorkingDeptFrom] [datetime] NULL,
	[HREmpWorkingDeptRemark] [nvarchar](500) NULL,
 CONSTRAINT [PK_HREmpWorkingDepts] PRIMARY KEY CLUSTERED 
(
	[HREmpWorkingDeptID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].HREmpWorkingDepts  WITH CHECK ADD  CONSTRAINT [FK_HREmpWorkingDepts_HRDepartments] FOREIGN KEY([FK_HRDepartmentID])
REFERENCES [dbo].[HRDepartments] ([HRDepartmentID])
GO

ALTER TABLE [dbo].HREmpWorkingDepts CHECK CONSTRAINT [FK_HREmpWorkingDepts_HRDepartments]
GO

ALTER TABLE [dbo].HREmpWorkingDepts  WITH CHECK ADD  CONSTRAINT [FK_HREmpWorkingDepts_HREmployees] FOREIGN KEY([FK_HREmployeeID])
REFERENCES [dbo].[HREmployees] ([HREmployeeID])
GO

ALTER TABLE [dbo].HREmpWorkingDepts CHECK CONSTRAINT [FK_HREmpWorkingDepts_HREmployees]
GO
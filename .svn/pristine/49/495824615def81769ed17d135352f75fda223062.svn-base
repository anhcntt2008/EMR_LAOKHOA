--chay tung dong
ALTER TABLE MEEmrs ADD [FK_HREmployeeCreatedID] [int]

ALTER TABLE [dbo].MEEmrs
	WITH CHECK ADD CONSTRAINT [FK_MEEmrs_HREmployeeCreated] FOREIGN KEY ([FK_HREmployeeCreatedID]) REFERENCES [dbo].[HREmployees]([HREmployeeID])
GO

ALTER TABLE [dbo].MEEmrs CHECK CONSTRAINT [FK_MEEmrs_HREmployeeCreated]
GO

UPDATE MEEmrs
SET [FK_HREmployeeCreatedID] = ISNULL((
			SELECT TOP 1 FK_HREmployeeID
			FROM ADUsers
			WHERE MEEmrs.AACreatedUser = ADUsers.ADUserName
				AND ADUsers.AAStatus = 'Alive'
			), 0)

ALTER TABLE [dbo].MEEmrs ALTER COLUMN [FK_HREmployeeCreatedID] int NOT NULL

INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'FK_HREmployeeCreatedID', N'Người tạo', 'MEEmrs');
GO
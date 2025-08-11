--chay tung dong
ALTER TABLE MEEmrDocuments ADD [FK_HREmployeeCreatedID] [int]

ALTER TABLE [dbo].MEEmrDocuments
	WITH CHECK ADD CONSTRAINT [FK_MEEmrDocuments_HREmployeeCreated] FOREIGN KEY ([FK_HREmployeeCreatedID]) REFERENCES [dbo].[HREmployees]([HREmployeeID])
GO

ALTER TABLE [dbo].MEEmrDocuments CHECK CONSTRAINT [FK_MEEmrDocuments_HREmployeeCreated]
GO

UPDATE MEEmrDocuments
SET [FK_HREmployeeCreatedID] = ISNULL((
			SELECT TOP 1 FK_HREmployeeID
			FROM ADUsers
			WHERE MEEmrDocuments.AACreatedUser = ADUsers.ADUserName
				AND ADUsers.AAStatus = 'Alive'
			), 0)

ALTER TABLE [dbo].MEEmrDocuments ALTER COLUMN [FK_HREmployeeCreatedID] int NOT NULL

INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'FK_HREmployeeCreatedID', N'Người tạo', 'MEEmrDocuments');
GO
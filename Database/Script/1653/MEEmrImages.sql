USE [db]
GO

ALTER TABLE [MEEmrImages] ADD [FK_MEParamContainerID] INT NULL
GO

ALTER TABLE [dbo].[MEEmrImages]  WITH CHECK ADD  CONSTRAINT [FK_MEEmrImages_MEParamContainers] FOREIGN KEY([FK_MEParamContainerID])
REFERENCES [dbo].[MEParams] ([MEParamID])
GO
ALTER TABLE [dbo].[MEEmrImages] CHECK CONSTRAINT [FK_MEEmrImages_MEParamContainers]
GO

UPDATE [MEEmrImages] SET [FK_MEParamContainerID] = 0
GO
ALTER TABLE [MEEmrImages] ALTER COLUMN [FK_MEParamContainerID] INT NOT NULL
GO

DELETE
FROM [dbo].[AAColumnAlias]
WHERE AATableName = 'MEEmrImages'
	AND AAColumnAliasName = 'FK_MEParamContainerID'

INSERT INTO [dbo].[AAColumnAlias]
VALUES (
	(
		SELECT MAX([AAColumnAliasID]) + 1
		FROM [dbo].[AAColumnAlias]
		)
	,0
	,''
	,'Alive'
	,N'FK_MEParamContainerID'
	,N'Thẻ chứa hình'
	,'MEEmrImages'
	);
GO
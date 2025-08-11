ALTER TABLE MEEmrActions ADD MEEmrActionAllowNullResult bit
GO
UPDATE MEEmrActions SET MEEmrActionAllowNullResult = 0
GO
ALTER TABLE MEEmrActions ALTER COLUMN MEEmrActionAllowNullResult bit not null
GO
ALTER TABLE MEEmrActions ADD CONSTRAINT DF_MEEmrActions_MEEmrActionAllowNullResult DEFAULT 0 FOR MEEmrActionAllowNullResult
GO

DELETE FROM [dbo].[AAColumnAlias] where AATableName = 'MEEmrActions' AND  AAColumnAliasName = 'MEEmrActionAllowNullResult'
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0,
 '', 'Alive', 'MEEmrActionAllowNullResult', N'Gọi trình cắm khi dữ liệu rỗng', 'MEEmrActions');
GO


--chay tung dong
ALTER TABLE [dbo].[MEEmrActionParams] add MEEmrActionParamUpdateOnly bit

INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'MEEmrActionParamUpdateOnly', N'Chỉ cập nhật', 'MEEmrActionParams');
GO


UPDATE [dbo].[MEEmrActionParams] set MEEmrActionParamUpdateOnly = 0


ALTER TABLE [dbo].[MEEmrActionParams] ALTER COLUMN MEEmrActionParamUpdateOnly BIT NOT NULL

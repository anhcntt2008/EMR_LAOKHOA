--chay tung dong
ALTER TABLE [dbo].[MEEmrActionParams] add MEEmrActionParamPopupSelectChild bit

INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'MEEmrActionParamPopupSelectChild', N'Chọn dữ liệu thẻ danh sách con', 'MEEmrActionParams');
GO

UPDATE [dbo].[MEEmrActionParams] set MEEmrActionParamPopupSelectChild = 0

ALTER TABLE [dbo].[MEEmrActionParams] ALTER COLUMN MEEmrActionParamPopupSelectChild BIT NOT NULL

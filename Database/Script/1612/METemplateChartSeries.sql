--chay tung dong
ALTER TABLE [dbo].[METemplateChartSeries] add METemplateChartSerieIgnoreEmptyPoint bit

INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'METemplateChartSerieIgnoreEmptyPoint', N'Bỏ qua các điểm không có giá trị', 'METemplateChartSeries');
GO

UPDATE [dbo].[METemplateChartSeries] set METemplateChartSerieIgnoreEmptyPoint = 1

ALTER TABLE [dbo].[METemplateChartSeries] ALTER COLUMN METemplateChartSerieIgnoreEmptyPoint BIT NOT NULL

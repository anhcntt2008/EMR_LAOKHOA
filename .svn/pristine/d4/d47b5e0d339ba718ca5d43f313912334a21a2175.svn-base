DELETE FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'PRIVATE' AND [ADSystemConfigKey] = 'HOSPITAL_PROJECT'
INSERT INTO [dbo].[ADSystemConfigs]
VALUES ((SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1 FROM [dbo].[ADSystemConfigs]),
'Alive', '1', 'PRIVATE', 'HOSPITAL_PROJECT', N'ChamCuu', N'Dự án bệnh viện', N'Dự án bệnh viện');
GO
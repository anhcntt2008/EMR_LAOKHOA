SET XACT_ABORT ON
BEGIN TRANSACTION
DELETE [dbo].[ADConfigValues] WHERE ADConfigKeyGroup='TemplateParamUpdToEmr' 
AND ADConfigKey in ('TemplateParamUpdToEmrICDCodeIn', 'TemplateParamUpdToEmrICDStrIn', 'TemplateParamUpdToEmrICDCodeOut', 'TemplateParamUpdToEmrICDStrOut')

INSERT INTO [dbo].[ADConfigValues] VALUES ((SELECT MAX([ADConfigValueID])+ 1 FROM [ADConfigValues]), 
'Alive', N'TemplateParamUpdToEmrICDCodeIn', N'MEEmrICDCodeIn', N'Mã chuẩn đoán vào viện', NULL, N'TemplateParamUpdToEmr', '1');

INSERT INTO [dbo].[ADConfigValues] VALUES ((SELECT MAX([ADConfigValueID])+ 1 FROM [ADConfigValues]), 
'Alive', N'TemplateParamUpdToEmrICDStrIn', N'MEEmrICDStrIn', N'Chuẩn đoán vào viện', NULL, N'TemplateParamUpdToEmr', '1');

INSERT INTO [dbo].[ADConfigValues] VALUES ((SELECT MAX([ADConfigValueID])+ 1 FROM [ADConfigValues]), 
'Alive', N'TemplateParamUpdToEmrICDCodeOut', N'MEEmrICDCodeOut', N'Mã chuẩn đoán ra viện', NULL, N'TemplateParamUpdToEmr', '1');

INSERT INTO [dbo].[ADConfigValues] VALUES ((SELECT MAX([ADConfigValueID])+ 1 FROM [ADConfigValues]), 
'Alive', N'TemplateParamUpdToEmrICDStrOut', N'MEEmrICDStrOut', N'Chuẩn đoán ra viện', NULL, N'TemplateParamUpdToEmr', '1');

COMMIT TRANSACTION

-- MEEmrICDCodeIn
-- MEEmrICDStrIn
-- MEEmrICDCodeOut
-- MEEmrICDStrOut
--select * from [dbo].[ADConfigValues] WHERE ADConfigKeyGroup='TemplateParamUpdToEmr'
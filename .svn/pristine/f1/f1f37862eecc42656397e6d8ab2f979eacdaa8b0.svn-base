SET XACT_ABORT ON
BEGIN TRANSACTION
DELETE [dbo].[ADConfigValues] WHERE ADConfigKeyGroup='TemplateParamUpdToEmr' AND ADConfigKey='TemplateParamUpdToEmrPatientGroup'

INSERT INTO [dbo].[ADConfigValues] VALUES ((SELECT MAX([ADConfigValueID])+ 1 FROM [ADConfigValues]), 
'Alive', N'TemplateParamUpdToEmrPatientGroup', N'MEEmrPatientGroup', N'Đối tượng', NULL, N'TemplateParamUpdToEmr', '1');

COMMIT TRANSACTION

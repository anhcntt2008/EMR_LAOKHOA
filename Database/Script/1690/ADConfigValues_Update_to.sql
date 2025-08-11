SET XACT_ABORT ON
BEGIN TRANSACTION

INSERT INTO [dbo].[ADConfigValues] VALUES ((SELECT MAX([ADConfigValueID])+ 1 FROM [ADConfigValues]), 
'Alive', N'TemplateParamUpdateToMEEmrPatientGroup', N'MEEmrPatientGroup', N'Đối tượng', NULL, N'TemplateParamUpdateTo', '1');

COMMIT TRANSACTION

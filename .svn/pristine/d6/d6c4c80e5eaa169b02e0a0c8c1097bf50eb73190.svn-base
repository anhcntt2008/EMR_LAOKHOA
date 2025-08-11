
DELETE [ADConfigValues]  where ADConfigKeyGroup = 'EmrDocumentSignType' AND ADConfigKey= 'EmrDocumentSignTypeFingerPrintSigned'
INSERT INTO [dbo].[ADConfigValues] VALUES ((SELECT MAX([ADConfigValueID])+ 1 FROM [ADConfigValues]), 
'Alive', N'EmrDocumentSignTypeFingerPrintSigned', N'FingerPrintSigned', N'Xác nhận vân tay', NULL, N'EmrDocumentSignType', '1');

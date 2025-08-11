DELETE [ADConfigValues] where [ADConfigKeyGroup] = 'EmrDocumentSignType' and [ADConfigKey] = 'EmrDocumentSignTypeDigitalSigned'
INSERT INTO [dbo].[ADConfigValues]([ADConfigValueID], [AAStatus], [ADConfigKey], [ADConfigKeyValue], [ADConfigText], [ADConfigKeyDesc], [ADConfigKeyGroup], [IsActive]) VALUES 
((SELECT MAX([ADConfigValueID])+1 FROM [dbo].[ADConfigValues]), 'Alive', N'EmrDocumentSignTypeDigitalSigned', N'DigitalSigned', N'Ký số CA', N'', N'EmrDocumentSignType', '1');

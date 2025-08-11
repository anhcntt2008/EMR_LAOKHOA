INSERT INTO [dbo].[ADConfigValues]([ADConfigValueID], [AAStatus], [ADConfigKey], [ADConfigKeyValue], [ADConfigText], [ADConfigKeyDesc], [ADConfigKeyGroup], [IsActive]) 
VALUES ( (SELECT MAX([ADConfigValueID])+ 1 FROM [ADConfigValues]) , 'Alive', N'ApiOfHis-SendEmrToHis', N'emrs', N'Api gởi bệnh án qua HIS', N'Api mà EMR dùng để gởi bệnh án qua HIS', N'ApiOfHis', '1');

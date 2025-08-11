DELETE FROM ADConfigValues where ADConfigKeyGroup = 'EmrStatus' and ADConfigKey = 'EmrStatusIniting'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'EmrStatusIniting', N'Initing', N'Đang được khởi tạo', NULL, N'EmrStatus', '1');

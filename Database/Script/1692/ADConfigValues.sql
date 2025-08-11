DELETE FROM ADConfigValues where ADConfigKeyGroup = 'EmrShareHistoryMode' and ADConfigKey = 'EmrShareHistoryModeRead'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'EmrShareHistoryModeRead', N'Read', N'Xem', NULL, N'EmrShareHistoryMode', '1');
GO

DELETE FROM ADConfigValues where ADConfigKeyGroup = 'EmrShareHistoryMode' and ADConfigKey = 'EmrShareHistoryModeEdit'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'EmrShareHistoryModeEdit', N'Edit', N'Sửa', NULL, N'EmrShareHistoryMode', '1');
GO

select * from ADConfigValues where ADConfigKeyGroup like '%EmrPatientGroup%'
select * from ADConfigValues where ADConfigKeyGroup like '%EmrShareHistoryMode%'
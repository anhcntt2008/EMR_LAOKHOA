DELETE FROM [dbo].[ADConfigValues] WHERE ADConfigKeyGroup = 'EmrTemplateActionWhen' AND ADConfigKey = 'EmrTemplateActionWhenManual'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
'Alive', N'EmrTemplateActionWhenManual', N'Manual', N'Thủ công', N'Thực thi thủ công', N'EmrTemplateActionWhen', '1');

DELETE FROM [dbo].[ADConfigValues] WHERE ADConfigKeyGroup = 'EmrTemplateActionWhen' AND ADConfigKey = 'EmrTemplateActionWhenMergeBinding'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
'Alive', N'EmrTemplateActionWhenMergeBinding', N'MergeBinding', N'Cập nhật trộn', N'Thực thi khi cập nhật từ tờ bệnh án khác. VD: KQXN > Tờ bìa', N'EmrTemplateActionWhen', '1');
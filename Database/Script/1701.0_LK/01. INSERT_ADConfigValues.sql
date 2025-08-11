DELETE FROM ADConfigValues where ADConfigKeyGroup = 'ObjectHistoryAction' and ADConfigKey = 'ObjectHistoryActionMerge'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'ObjectHistoryActionMerge', N'Merge', N'Trộn', N'ObjectHistoryActionMerge', N'ObjectHistoryAction', '1');
GO
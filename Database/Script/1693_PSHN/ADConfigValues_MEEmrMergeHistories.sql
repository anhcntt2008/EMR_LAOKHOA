DELETE FROM ADConfigValues where ADConfigKeyGroup = 'EmrMergeHistoryStatus' and ADConfigKey = 'EmrMergeHistoryStatusMerge'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'EmrMergeHistoryStatusMerge', N'Merge', N'Trộn', NULL, N'EmrMergeHistoryStatus', '1');
GO
DELETE FROM ADConfigValues where ADConfigKeyGroup = 'EmrMergeHistoryStatus' and ADConfigKey = 'EmrMergeHistoryStatusRollback'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'EmrMergeHistoryStatusRollback', N'Rollback', N'Khôi phục', NULL, N'EmrMergeHistoryStatus', '1');
GO


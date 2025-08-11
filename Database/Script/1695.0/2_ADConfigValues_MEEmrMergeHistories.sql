DELETE FROM ADConfigValues where ADConfigKeyGroup = 'EmrMergeHistoryStatus' and ADConfigKey = 'EmrMergeHistoryStatusMergeError'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'EmrMergeHistoryStatusMergeError', N'MergeError', N'Lỗi trộn', NULL, N'EmrMergeHistoryStatus', '1');
GO
DELETE FROM ADConfigValues where ADConfigKeyGroup = 'EmrMergeHistoryStatus' and ADConfigKey = 'EmrMergeHistoryStatusRollbackError'
INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'EmrMergeHistoryStatusRollbackError', N'RollbackError', N'Lỗi khôi phục', NULL, N'EmrMergeHistoryStatus', '1');
GO


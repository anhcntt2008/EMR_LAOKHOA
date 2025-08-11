DELETE FROM ADConfigValues where ADConfigKeyGroup = 'MdAutoGenDocumentsStatus'

INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'MdAutoGenDocumentsStatusSCHEDULED', N'SCHEDULED', N'Chờ thực hiện', NULL, N'MdAutoGenDocumentsStatus', '1');

 INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'MdAutoGenDocumentsStatusCREATING', N'CREATING', N'Đang tạo', NULL, N'MdAutoGenDocumentsStatus', '1');

 INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'MdAutoGenDocumentsStatusCREATED', N'CREATED', N'Đã tạo', NULL, N'MdAutoGenDocumentsStatus', '1');

 INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'MdAutoGenDocumentsStatusRETRYING', N'RETRYING', N'Đang thử lại', NULL, N'MdAutoGenDocumentsStatus', '1');

 INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'MdAutoGenDocumentsStatusDISCARDED', N'DISCARDED', N'Thất bại', NULL, N'MdAutoGenDocumentsStatus', '1');

 DELETE FROM ADConfigValues where ADConfigKeyGroup = 'MdAutoSignDocumentsStatus'

INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'MdAutoSignDocumentsStatusSCHEDULED', N'SCHEDULED', N'Chờ thực hiện', NULL, N'MdAutoSignDocumentsStatus', '1');

 INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'MdAutoSignDocumentsStatusSIGNING', N'SIGNING', N'Đang ký', NULL, N'MdAutoSignDocumentsStatus', '1');

 INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'MdAutoSignDocumentsStatusSIGNED', N'SIGNED', N'Đã ký', NULL, N'MdAutoSignDocumentsStatus', '1');

 INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'MdAutoSignDocumentsStatusRETRYING', N'RETRYING', N'Đang thử lại', NULL, N'MdAutoSignDocumentsStatus', '1');

 INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'MdAutoSignDocumentsStatusDISCARDED', N'DISCARDED', N'Thất bại', NULL, N'MdAutoSignDocumentsStatus', '1');

 -- EmrArchiveBackupStatus
  DELETE FROM ADConfigValues where ADConfigKeyGroup = 'EmrArchiveBackupStatus'
   INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'EmrArchiveBackupStatusScheduled', N'Scheduled', N'Chờ thực hiện', NULL, N'EmrArchiveBackupStatus', '1');

   INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'EmrArchiveBackupStatusUploaded', N'Uploaded', N'Đã tải lên', NULL, N'EmrArchiveBackupStatus', '1');

  INSERT INTO [dbo].[ADConfigValues] VALUES 
((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 
 'Alive', N'EmrArchiveBackupStatusFailed', N'Failed', N'Lỗi', NULL, N'EmrArchiveBackupStatus', '1');


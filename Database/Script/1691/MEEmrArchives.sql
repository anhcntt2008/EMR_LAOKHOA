ALTER TABLE MEEmrArchives ADD MEEmrArchiveBackupStatus nvarchar(50) 
GO
UPDATE MEEmrArchives SET MEEmrArchiveBackupStatus=''
GO
ALTER TABLE MEEmrArchives ADD CONSTRAINT DF_MEEmrArchives_MEEmrArchiveBackupStatus DEFAULT '' FOR MEEmrArchiveBackupStatus

GO
ALTER TABLE MEEmrArchives ADD MEEmrArchiveBackupDesc nvarchar(4000) 
GO
UPDATE  MEEmrArchives SET MEEmrArchiveBackupDesc=''
GO
ALTER TABLE MEEmrArchives ADD CONSTRAINT DF_MEEmrArchives_MEEmrArchiveBackupDesc DEFAULT '' FOR MEEmrArchiveBackupDesc

GO
ALTER TABLE MEEmrArchives ADD MEEmrArchiveBackupDate datetime NULL
GO
UPDATE  MEEmrArchives SET MEEmrArchiveBackupDate='9999-12-31 23:59:59.997'
GO
ALTER TABLE MEEmrArchives ALTER COLUMN MEEmrArchiveBackupDate datetime NOT NULL
GO
ALTER TABLE MEEmrArchives ADD  CONSTRAINT MEEmrArchives_DF_MEEmrArchiveBackupDate  DEFAULT ('9999-12-31 23:59:59.997') FOR MEEmrArchiveBackupDate
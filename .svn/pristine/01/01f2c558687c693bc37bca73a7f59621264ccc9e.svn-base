UPDATE MEEmrArchives SET MEEmrArchiveBackupStatus = 'Uploaded', 
MEEmrArchiveBackupDate= GETDATE(), 
MEEmrArchiveBackupDesc= N'Dữ liệu trước 2 ngày lưu trữ thủ công.'
WHERE AAStatus = 'Alive' and MEEmrArchiveDate < DATEADD(day, -2, CAST(GETDATE() AS date))

--SELECT * FROM MEEmrArchives WHERE AAStatus = 'Alive' and MEEmrArchiveDate < DATEADD(day, -2, CAST(GETDATE() AS date)) order by MEEmrArchiveID desc
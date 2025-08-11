
DELETE FROM [dbo].[AbpJobStates] where [JobType] = 'DocumentBackupAllFilesQuartzJob' 
INSERT INTO [dbo].[AbpJobStates]
           ([JobType]
           ,[JobDesc]
           ,[JobArgs]
           ,[TryCount]
           ,[NextFireTime]
           ,[LastFireTime]
           ,[LastEndTime]
           ,[LastState]
           ,[LastMsg]
           ,[Priority]
           ,[CreationTime]
           ,[CreatorUserId]
           ,[TenantId])
     VALUES
           ('DocumentBackupAllFilesQuartzJob'
           ,N'Tác vụ ngầm tự động backup dữ liệu các files bệnh án đến vùng nhớ khác'
           ,''
           ,1
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,''
           ,''
           ,1
           ,GETDATE()
           ,1
           ,1)

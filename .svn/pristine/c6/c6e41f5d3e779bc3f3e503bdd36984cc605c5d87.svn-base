
DELETE FROM [dbo].[AbpJobStates] where [JobType] = 'EmrBackupArchivesQuartzJob' 
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
           ('EmrBackupArchivesQuartzJob'
           ,N'Tác vụ ngầm tự động sao lưu dự phòng bệnh án đã lưu trữ'
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

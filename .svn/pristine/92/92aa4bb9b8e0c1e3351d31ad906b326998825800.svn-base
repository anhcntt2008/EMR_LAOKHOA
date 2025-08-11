
DELETE FROM [dbo].[AbpJobStates] where [JobType] = 'MongoDBIncrementalBackupQuartzJob' 
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
           ('MongoDBIncrementalBackupQuartzJob'
           ,N'Tác vụ ngầm tự động [backup incremental] dữ liệu MongoDB'
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

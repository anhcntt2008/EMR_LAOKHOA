
DELETE FROM [dbo].[AbpJobStates] where [JobType] = 'MongoDBFullBackupQuartzJob' 
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
           ('MongoDBFullBackupQuartzJob'
           ,N'Tác vụ ngầm tự động [backup full] dữ liệu MongoDB'
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

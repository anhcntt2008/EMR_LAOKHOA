IF NOT EXISTS (SELECT * FROM sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[MEParamLookupDatas]') AND name = 'MEParamLookupDataEmrType')
BEGIN
	ALTER TABLE [dbo].[MEParamLookupDatas] ADD MEParamLookupDataEmrType nvarchar(50) NULL
END
GO

update MEParamLookupDatas
set MEParamLookupDataEmrType = ''
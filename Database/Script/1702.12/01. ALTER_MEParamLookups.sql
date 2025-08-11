IF NOT EXISTS (SELECT * FROM sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[MEParamLookups]') AND name = 'MEParamLookupMaximumSelect')
BEGIN
	ALTER TABLE [dbo].[MEParamLookups] ADD MEParamLookupMaximumSelect int NULL
END
GO

update MEParamLookups
set MEParamLookupMaximumSelect = 0
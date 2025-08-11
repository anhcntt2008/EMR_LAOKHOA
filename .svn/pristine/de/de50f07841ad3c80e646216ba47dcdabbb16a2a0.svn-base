IF NOT EXISTS (SELECT * FROM sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[MEParams]') AND name = 'MEParamExtend')
BEGIN
	ALTER TABLE [dbo].[MEParams] ADD MEParamExtend bit NULL
END
GO
UPDATE [dbo].[MEParams] SET MEParamExtend=0
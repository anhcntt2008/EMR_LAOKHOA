IF NOT EXISTS (SELECT * FROM sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[MEParams]') AND name = 'MEParamMaxLength')
BEGIN
	ALTER TABLE [dbo].[MEParams] ADD MEParamMaxLength int NULL
END
GO
UPDATE [dbo].[MEParams] SET MEParamMaxLength=0
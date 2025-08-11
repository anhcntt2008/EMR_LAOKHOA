IF NOT EXISTS (SELECT * FROM sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[MEEmrs]') AND name = 'MEEmrHasNote')
BEGIN
	ALTER TABLE [dbo].[MEEmrs] ADD MEEmrHasNote bit NOT NULL default 0
END
GO
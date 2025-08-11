GO
IF NOT EXISTS (SELECT * FROM   sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[MEEmrTypes]') AND name = 'MEEmrTypeFilterTemplate')
BEGIN
	ALTER TABLE [dbo].[MEEmrTypes] ADD  MEEmrTypeFilterTemplate bit NULL
	UPDATE [dbo].[MEEmrTypes] SET MEEmrTypeFilterTemplate=0
	ALTER TABLE [dbo].[MEEmrTypes] ADD  CONSTRAINT [DF_MEEmrTypes_MEEmrTypeFilterTemplate]  DEFAULT ((0)) FOR [MEEmrTypeFilterTemplate]
END
GO

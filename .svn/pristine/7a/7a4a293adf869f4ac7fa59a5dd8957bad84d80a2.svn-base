GO
IF NOT EXISTS (SELECT * FROM   sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[MEEmrTypes]') AND name = 'MEEmrTypeOneEmrOnePhase')
BEGIN
	ALTER TABLE [dbo].[MEEmrTypes] ADD  MEEmrTypeOneEmrOnePhase bit NULL
	ALTER TABLE [dbo].[MEEmrTypes] ADD  CONSTRAINT [DF_MEEmrTypes_MEEmrTypeOneEmrOnePhase]  DEFAULT ((0)) FOR [MEEmrTypeOneEmrOnePhase]
END
GO
UPDATE [dbo].[MEEmrTypes] SET MEEmrTypeOneEmrOnePhase = 0
	

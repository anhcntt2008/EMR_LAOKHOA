-- CHAY TUNG LINE
----
ALTER TABLE MEEmrTypes ADD MEEmrTypeMaxCountPerPatient int

----
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'MEEmrTypeMaxCountPerPatient', N'Số hồ sơ tối đa/bệnh nhân', 'MEEmrTypes');

----
UPDATE MEEmrTypes set MEEmrTypeMaxCountPerPatient = 0

----
ALTER TABLE dbo.MEEmrTypes
  ADD CONSTRAINT MEEmrTypes_DF_MEEmrTypeMaxCountPerPatient
  DEFAULT 0 FOR [MEEmrTypeMaxCountPerPatient];
GO

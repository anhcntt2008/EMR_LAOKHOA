ALTER TABLE MEEmrTypes ADD MEEmrTypeIsPatientProfile bit
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'MEEmrTypeIsPatientProfile', N'Hồ sơ bệnh nhân', 'MEEmrTypes');

UPDATE MEEmrTypes set MEEmrTypeIsPatientProfile = 0
-- Chay tung dong
ALTER TABLE MEEmrTypes ADD MEEmrTypeProfile varchar(100)

INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'MEEmrTypeProfile', N'Loại hồ sơ', 'MEEmrTypes');

UPDATE MEEmrTypes set MEEmrTypeProfile = 'Patient' WHERE [MEEmrTypeIsPatientProfile] = 1
UPDATE MEEmrTypes set MEEmrTypeProfile = 'In' WHERE  [MEEmrTypeIsPatientProfile] = 0

ALTER TABLE MEEmrTypes DROP COLUMN MEEmrTypeIsPatientProfile


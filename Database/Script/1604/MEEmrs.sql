-- Chay tung dong
ALTER TABLE MEEmrs ADD MEEmrTypeProfile varchar(100)

INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'MEEmrTypeProfile', N'Loại hồ sơ', 'MEEmrs');

UPDATE MEEmrs set MEEmrTypeProfile = 'Patient' WHERE MEEmrIsPatientProfile = 1
UPDATE MEEmrs set MEEmrTypeProfile = 'In' WHERE MEEmrIsPatientProfile = 0

ALTER TABLE MEEmrs DROP COLUMN MEEmrIsPatientProfile
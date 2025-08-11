-- chạy từng dòng
ALTER TABLE MEEmrs ADD MEEmrIsPatientProfile bit


INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '',
 'Alive', 'MEEmrIsPatientProfile', N'HSBN', 'MEEmrs');


UPDATE MEEmrs set MEEmrIsPatientProfile = 0
ALTER TABLE MEEmrs ADD MEEmrPatientGroup nvarchar(100) 
GO
UPDATE  MEEmrs SET MEEmrPatientGroup=''
GO
ALTER TABLE MEEmrs ADD CONSTRAINT DF_MEEmrs_MEEmrPatientGroup DEFAULT '' FOR MEEmrPatientGroup
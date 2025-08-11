--chay tung dong
ALTER TABLE MEPatients ADD MEPatientBirthdayOnlyYear bit

UPDATE MEPatients set MEPatientBirthdayOnlyYear = 0

ALTER TABLE MEPatients ALTER COLUMN MEPatientBirthdayOnlyYear bit NOT NULL
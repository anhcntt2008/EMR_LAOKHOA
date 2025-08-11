DELETE
FROM ADConfigValues
WHERE ADConfigKeyGroup = 'EmrTypeProfile'

INSERT INTO [dbo].[ADConfigValues]
VALUES (
	(
		SELECT MAX(ADConfigValueID) + 1
		FROM [ADConfigValues]
		)
	,'Alive'
	,N'EmrTypeProfilePatientProfile'
	,N'Patient'
	,N'Hồ sơ bệnh nhân'
	,N'Hồ sơ bệnh nhân'
	,N'EmrTypeProfile'
	,'1'
	);

INSERT INTO [dbo].[ADConfigValues]
VALUES (
	(
		SELECT MAX(ADConfigValueID) + 1
		FROM [ADConfigValues]
		)
	,'Alive'
	,N'EmrTypeProfileIn'
	,N'In'
	,N'Nội trú'
	,N'Nội trú'
	,N'EmrTypeProfile'
	,'1'
	);
INSERT INTO [dbo].[ADConfigValues]
VALUES (
	(
		SELECT MAX(ADConfigValueID) + 1
		FROM [ADConfigValues]
		)
	,'Alive'
	,N'EmrTypeProfileOut'
	,N'Out'
	,N'Ngoại trú'
	,N'Ngoại trú'
	,N'EmrTypeProfile'
	,'1'
	);
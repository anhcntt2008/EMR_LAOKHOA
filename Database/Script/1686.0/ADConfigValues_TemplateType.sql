-- LUU Y CAN THAN NEU METemplate CO SU DUNG DEN CAC LOAI KHAC ProgressNote va Sub THI KHONG XOA DUOC
DELETE
FROM ADConfigValues
WHERE ADConfigKeyGroup = 'TemplateType'
	AND ADConfigKey <> 'TemplateTypeProgressNote'
	AND ADConfigKey <> 'TemplateTypeSub'

INSERT INTO [dbo].[ADConfigValues]
VALUES (
	(
		SELECT MAX(ADConfigValueID) + 1
		FROM [ADConfigValues]
		)
	,'Alive'
	,N'TemplateTypePrimaryHeader'
	,N'PrimaryHeader'
	,N'Header'
	,NULL
	,N'TemplateType'
	,'1'
	);
	-- select * from ADConfigValues where ADConfigKeyGroup =  'TemplateType'

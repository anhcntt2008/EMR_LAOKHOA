INSERT INTO GELookupTables
VALUES (
	(
		SELECT MAX(GELookupTableID) + 1
		FROM GELookupTables
		)
	,'Alive'
	,'METemplateIndexs'
	,'METemplateIndexs'
	,'METemplateIndexName'
	)

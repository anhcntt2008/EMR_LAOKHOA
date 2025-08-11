--CHAY TUNG DONG
----
INSERT INTO METemplateIndexs VALUES (0, 1, 0, 'Dummy', 0, 'Dummy', 'Dummy', GETDATE(), 'Dummy',  GETDATE())
----
UPDATE MEEmrTypeTemplates SET FK_METemplateIndexID = 0
---
ALTER TABLE MEEmrTypeTemplates ALTER COLUMN FK_METemplateIndexID INT NOT NULL;
----
DELETE
FROM [METemplateIndexs]
WHERE METemplateIndexID>0
GO
---
INSERT INTO [METemplateIndexs]
SELECT ROW_NUMBER() OVER (
		ORDER BY FK_MEEmrTypeID ASC
		) AS METemplateIndexID
	, idx.*
FROM (
	SELECT DISTINCT FK_MEEmrTypeID
		,MEEmrTypeTemplateOrder AS METemplateIndexOrder
		,MEEmrTypeTemplateGroup AS METemplateIndexName
		,0 AS METemplateIndexDesc
		,AAStatus
		,'admin' as AACreatedUser
		,GETDATE() as AACreatedDate
		,'admin' as AAUpdatedUser
		,GETDATE() as AAUpdatedDate
	FROM MEEmrTypeTemplates
	WHERE AAStatus = 'Alive'
	) AS idx
GO
----
UPDATE MEEmrTypeTemplates
SET FK_METemplateIndexID = ISNULL((
		SELECT TOP 1 METemplateIndexID
		FROM [METemplateIndexs] as idx
		WHERE idx.FK_MEEmrTypeID = MEEmrTypeTemplates.FK_MEEmrTypeID
			AND idx.METemplateIndexName = MEEmrTypeTemplates.MEEmrTypeTemplateGroup
		),0)

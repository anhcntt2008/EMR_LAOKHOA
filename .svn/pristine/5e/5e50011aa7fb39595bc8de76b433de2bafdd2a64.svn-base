DELETE  [dbo].[STFieldColumns] where [STFieldColumnIDString] LIKE 'GridSearchResults-Mod-%'

INSERT INTO [dbo].[STFieldColumns]
SELECT (
		(
			SELECT MAX(STFieldColumnID)
			FROM [dbo].[STFieldColumns]
			) + (
			ROW_NUMBER() OVER (
				ORDER BY [STGridResultColumnDisplayID] ASC
				)
			)
		) AS [STFieldColumnID]
	,CONCAT (
		'GridSearchResults-Mod-'
		,m.STModuleName
		) AS [STFieldColumnIDString]
	,0 AS [STFieldID]
	,[STGridResultColumnName] AS [STFieldColumnName]
	,[STGridResultColumnFieldName] AS [STFieldColumnFieldName]
	,[STGridResultColumnCaption] AS [STFieldColumnCaption]
	,'' AS [STFieldColumnFormatString]
	,'' AS [STFieldColumnFormatType]
	,[STGridResultColumnWidth] AS [STFieldColumnWidth]
	,[STGridResultSortOrder] AS [STFieldColumnVisibleIndex]
	,0 as FK_ADUserGroupID
	,0 as FK_ADUserID
FROM [dbo].[STGridResultColumnDisplays] c INNER JOIN [STModules] m ON c.STModuleID = m.STModuleID
WHERE  m.AAStatus = 'Alive'

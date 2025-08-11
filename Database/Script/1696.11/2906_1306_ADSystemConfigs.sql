DELETE
FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'EMR_PROCESS'
	AND [ADSystemConfigKey] = 'MODE_SHARE_EMR_VIEW_ALL'

INSERT INTO [dbo].[ADSystemConfigs] (
	[ADSystemConfigID]
	,[AAStatus]
	,[IsActive]
	,[ADSystemConfigGroup]
	,[ADSystemConfigKey]
	,[ADSystemConfigValue]
	,[ADSystemConfigText]
	,[ADSystemConfigDesc]
	)
VALUES (
	(
		SELECT ISNULL(MAX([ADSystemConfigID]), 0) + 1
		FROM [dbo].[ADSystemConfigs]
		)
	,'Alive'
	,'1'
	,'EMR_PROCESS'
	,'MODE_SHARE_EMR_VIEW_ALL'
	,N'FALSE'
	,N'Thấy tất cả bệnh án bao gồm cả bệnh án chia sẽ.'
	,N'TRUE/FALSE. PSHN = TRUE (Khi check "tất cả khoa" thì thấy tất cả bệnh án bao gồm cả bệnh án chia sẽ), LK = FALSE ngược lại, muốn thấy các bệnh án chia sẽ thì check " chỉ khoa chia sẽ" để tìm kiếm.'
	);

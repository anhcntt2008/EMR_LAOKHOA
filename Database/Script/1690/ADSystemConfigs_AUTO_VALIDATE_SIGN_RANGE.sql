DELETE
FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'DOCUMENT_PROCESS'
	AND [ADSystemConfigKey] = 'AUTO_VALIDATE_SIGN_RANGE'

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
	,'DOCUMENT_PROCESS'
	,'AUTO_VALIDATE_SIGN_RANGE'
	,N'TRUE'
	,N'Kiểm tra vùng quét chọn ký có hợp lệ hay không'
	,N'Thông báo quét thiếu thẻ, quét sót thẻ'
	);

DELETE
FROM [dbo].[ADSystemConfigs]
WHERE [ADSystemConfigGroup] = 'EMR_PROCESS'
	AND [ADSystemConfigKey] = 'EMR_SP_CUSTOM_RULE_FOR_NEW'

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
	,'EMR_SP_CUSTOM_RULE_FOR_NEW'
	,N'MEEmrs_GetAllOpeningEmrByTypeCustom'
	,N'SP ràng buộc số lượng bệnh án được tạo / một bệnh nhân'
	,N'SP này trả về danh sách bệnh án ĐANG MỞ của bệnh nhân theo nghiệp vụ của từng Viện. Nếu số lượng dòng này > số lượng ràng buộc theo Loại bệnh án thì sẽ không được phép tạo. Tham khảo MEEmrs_GetAllOpeningEmrByTypeCustom'
	);


-- Cấp quyền cho các group có thể ghi bệnh án
-- Chạy đoạn script này, sau đó copy kết quả được sinh ra và CHẠY CÁC SCRIPT ĐÓ
SELECT CONCAT (
		'INSERT INTO [dbo].[METemplateUserGroups] VALUES ( ( SELECT MAX(METemplateUserGroupID) + 1 FROM METemplateUserGroups) ,''Alive'','
		,g.ADUserGroupID
		,','
		,METemplateID
		,',N''emr'',GETDATE(),N''emr'',GETDATE());'
		)
FROM METemplates t
	,ADUserGroups g
WHERE t.METemplateType = 'ProgressNote'
	AND t.AAStatus = 'Alive'
	AND g.AAStatus = 'Alive'
	AND g.ADUserGroupID IN (1000, 1001, 1002) -- THÊM CÁC GROUP CẦN THIẾT VÀO ĐÂY VD: BS, ĐIỀU DƯỠNG, Admin...
	AND (
		SELECT COUNT(*)
		FROM METemplateUserGroups
		WHERE FK_METemplateID = t.METemplateID
			AND FK_ADUserGroupID = g.ADUserGroupID
			AND AAStatus = 'Alive'
		) = 0

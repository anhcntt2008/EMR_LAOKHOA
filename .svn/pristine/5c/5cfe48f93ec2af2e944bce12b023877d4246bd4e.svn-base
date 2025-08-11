--CHỈNH SỬA [10.0.1.26].[middle_ut] sang môi trường của LK trước khi chạy script
CREATE
	OR

ALTER PROCEDURE [dbo].[AAA_TuDongSinhCDVaKyTenNgam] @patientNo NVARCHAR(50)
	,@emrNo NVARCHAR(50)
	,@documentNo NVARCHAR(256)
	,@documentDate NVARCHAR(50)
	,@gid NVARCHAR(50)
	,@tid NVARCHAR(50)
	,@caseNo NVARCHAR(50)
	-- them 3 param bat buoc rieng cho chuc nang sinh to
	,@departmentNo VARCHAR(50)
	,@createdUser VARCHAR(50)
	,@templateNo VARCHAR(50)
	-- cac param nay la di theo theo chuc nang
	,@report_emr VARCHAR(50)
	,@sophieu VARCHAR(50)
	,@chuky_nguoidung VARCHAR(50)
AS
BEGIN
	DECLARE @msgCreate NVARCHAR(100)
	DECLARE @msgSign NVARCHAR(100)
	DECLARE @stateCreate VARCHAR(50)
	DECLARE @stateSign VARCHAR(50)
	SET @stateCreate = (
			SELECT [STATE]
			FROM [10.0.1.26].[middle_ut].[dbo].[MD_AUTO_GEN_DOCUMENT_INTERNALS]
			WHERE VENDOR_DOC_NO = @sophieu
				AND [STATE] IN (
					'CREATED'
					,'SCHEDULED'
					,'CREATING'
					,'RETRYING'
					)
				AND emr_no = @emrNo
			)

	IF @stateCreate IS NULL
	BEGIN
		--insert vào bảng gen
		INSERT INTO [10.0.1.26].[middle_ut].[dbo].[MD_AUTO_GEN_DOCUMENT_INTERNALS] (
			[state]
			,[document_id]
			,[emr_no]
			,[template_no]
			,[document_no]
			,[department_no]
			,[document_desc]
			,[document_json_data]
			,[vendor_doc_no]
			,[vendor_doc_old_no]
			,[created_user]
			,[created_time]
			)
		VALUES (
			'SCHEDULED'
			,0
			,@emrNo
			,@templateNo
			,''
			,@departmentNo
			,N'Thêm tờ tự động - tác vụ ngầm'
			,'{"sophieu":"' + @sophieu + '"}'
			,@sophieu
			,''
			,@createdUser
			,GETDATE()
			)

		SET @msgCreate = N'TẠO NGẦM'
	END
	ELSE
	BEGIN
		SET @msgCreate = CASE @stateCreate
				WHEN 'CREATED'
					THEN N'ĐÃ TẠO'
				ELSE N'ĐANG TẠO'
				END
	END

	IF ISNULL(@chuky_nguoidung, '') <> ''
	BEGIN
		SET @stateSign = (
				SELECT [STATE]
				FROM [10.0.1.26].[middle_ut].[dbo].[MD_AUTO_SIGN_DOCUMENT_INTERNALS]
				WHERE VENDOR_DOC_NO = @sophieu
					AND [STATE] IN (
						'SIGNED'
						,'SCHEDULED'
						,'SIGNING'
						,'RETRYING'
						)
					-- cho phep ky de, nhieu nguoi cung ky
					AND [signer] = @chuky_nguoidung
				)

		IF @stateSign IS NULL
		BEGIN
			INSERT INTO [10.0.1.26].[middle_ut].[dbo].[MD_AUTO_SIGN_DOCUMENT_INTERNALS] (
				[state]
				,[vendor_doc_no]
				,[signer]
				,[signer_pw]
				,[pw_encryted]
				,[signer_role]
				,[signed_time]
				,[DOCUMENT_ID]
				)
			VALUES (
				'SCHEDULED'
				,@sophieu
				,@chuky_nguoidung
				,''
				,''
				,''
				,GETDATE()
				,0
				)

			SET @msgSign = N'KÝ NGẦM'
		END
		ELSE
		BEGIN
			SET @msgSign = (
					CASE @stateSign
						WHEN 'SIGNED'
							THEN N'ĐÃ KÝ'
						ELSE N'ĐANG KÝ'
						END
					)
		END
	END

	SELECT 1 AS pkey
		,'item' AS 'type'
		,@msgCreate + '+'+ @msgSign AS 'message'
END

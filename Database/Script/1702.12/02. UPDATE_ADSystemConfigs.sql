update ADSystemConfigs
set ADSystemConfigText = N'Kiểm tra thiếu dữ liệu.Giá trị ToWaitClose|Closed. Không kiểm tra dữ liệu khi để trống.'
where ADSystemConfigKey = 'EMR_DOCUMENT_STATUS_VERIFY'
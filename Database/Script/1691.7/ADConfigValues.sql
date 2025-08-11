DELETE FROM ADConfigValues where AAStatus='Alive' and ADConfigKeyGroup like 'EmrTypeAction%' and ADConfigKey like 'EmrTypeAction%'

INSERT INTO ADConfigValues VALUES ((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 'Alive', N'EmrTypeActionWhenInit', N'Init', N'Khởi tạo', N'Khởi tạo bệnh án', N'EmrTypeActionWhen', '1');
INSERT INTO ADConfigValues VALUES ((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 'Alive', N'EmrTypeActionWhenOpen', N'Open', N'Mở', N'Mở bệnh án', N'EmrTypeActionWhen', '1');
INSERT INTO ADConfigValues VALUES ((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 'Alive', N'EmrTypeActionWhenSave', N'Save', N'Lưu', N'Lưu bệnh án', N'EmrTypeActionWhen', '1');
INSERT INTO ADConfigValues VALUES ((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 'Alive', N'EmrTypeActionWhenHisUpdated', N'HisUpdated', N'Thay đổi trên HIS', N'Thay đổi trên HIS', N'EmrTypeActionWhen', '1');
INSERT INTO ADConfigValues VALUES ((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 'Alive', N'EmrTypeActionWhenHisInit', N'HisInit', N'Khởi tạo từ HIS', N'Khởi tạo tờ từ HIS', N'EmrTypeActionWhen', '1');
INSERT INTO ADConfigValues VALUES ((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 'Alive', N'EmrTypeActionWhenCheckup', N'Checkup', N'Kiểm duyệt', N'Kiểm duyệt bệnh án', N'EmrTypeActionWhen', '1');

INSERT INTO ADConfigValues VALUES ((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 'Alive', N'EmrTypeActionDoUpdateDoc', N'UpdateDoc', N'Cập nhật tờ bệnh án', N'Cập nhật tờ bệnh án', N'EmrTypeActionDo', '1');
INSERT INTO ADConfigValues VALUES ((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 'Alive', N'EmrTypeActionDoAskUpdateDoc', N'AskUpdateDoc', N'Hỏi và cập nhật tờ bệnh án', N'Hỏi và cập nhật tờ bệnh án', N'EmrTypeActionDo', '1');
INSERT INTO ADConfigValues VALUES ((SELECT MAX(ADConfigValueID)+1 FROM [ADConfigValues]), 'Alive', N'EmrTypeActionDoNotify', N'Notify', N'Chỉ thông báo', N'Chỉ thông báo', N'EmrTypeActionDo', '1');

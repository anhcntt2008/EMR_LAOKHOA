--select * from STModuleDescriptions where STModuleDescriptionID = 162
update STModuleDescriptions set STModuleDescriptionDescription = N'Phát thuốc' where STModuleDescriptionID = 162

--
select * from STToolbars where STModuleID = 2202
select * from STToolbars where sttoolbarcaption like N'%sau hoàn tất%'
select * from STToolbarFunctions where STToolbarID = 3809
select * from ADConfigValues where ADConfigKeyGroup = 'ShipmentStatus'

--Ẩn nút In & Xoa
update STToolbars set AAStatus = 'Delete' where STToolbarID = 3808
update STToolbars set AAStatus = 'Delete' where STToolbarID = 3806

--Thêm nút Hoàn trả
insert into STToolbars values(3890, 'Alive', 2202, 1, 'fld_barbtnEditAfterCompleting', N'Hoàn trả', 
'EditAfterCompleting', 'Default', N'Hoàn trả', 'Utility', 2, 1, '', 0, '')

insert into STToolbarFunctions values(3869, 0, 3890, 'ActionEditAfterCompleting',
'Void ActionEditAfterCompleting()', 'BOSERP.Modules.ShipmentMedical.ShipmentMedicalModule', 1)

insert into ADConfigValues values(1391, 'Alive', 'ShipmentStatusReturn', 'Return', N'Hoàn trả', NULL, 'ShipmentStatus', 1)

--delete from ADConfigValues where ADConfigValueID = 1391
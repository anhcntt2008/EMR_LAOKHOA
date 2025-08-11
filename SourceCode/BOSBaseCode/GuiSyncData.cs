using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using BOSCommon;
using BOSERP;
using BOSLib;
using Clas.Business.Doctor24x7;
using Clas.CHBase;
using Clas.Model.Doctor24x7;
using DevExpress.Utils;

namespace BOSBase
{
    public partial class GuiSyncData : Form
    {
        private readonly BackgroundWorker _backgroundWorker;
        private readonly int _branchId;
        private readonly UserLoginHttpModel _currentUser;
        private readonly string _hospitalId;
        private readonly string _hospitalName;
        private readonly string _passWord;
        private readonly string _userFullName;
        private readonly UserManager _userManager;
        private readonly string _userName;
        private BRBranchsController _branchsController;
        private CheckupTypeManager _checkupTypeManager;
        private ARCustomersController _customersController;
        private BOSDbUtil _dbUtil;
        private DoctorManager _doctorManager;
        private GENumberingController _geNumberingController;
        private ListPatient _listPatient;
        private STModuleToUserGroupSectionsController _moduleToUserGroupSectionsController;
        private MEPatientsController _patientsController;
        private MESpecialismsController _specialismsController;
        private ADUserGroupsController _userGroupsController;
        private ADUserGroupSectionsController _userGroupSectionsController;
        private ADUsersController _usersController;
        private MECHBasesController _chBasesController;
        private CHBaseFunctions _chBaseFunctions;
        private string _branchNo;
        private string[,] _allowModules;

        public GuiSyncData(string hospitalId, string hospitalName, string userName, string passWord, int branchId,
            string fullName, string branchNo, bool isSync = false)
        {
            InitializeComponent();
            _backgroundWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            _branchNo = branchNo;
            _hospitalId = hospitalId;
            _currentUser = BOSApp.CurrentBacSi24X7;
            _userManager = new UserManager();
            _userFullName = fullName;
            lblHospitalName.Text = hospitalName;
            lblHospitalName.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            _userName = userName;
            _branchId = branchId;
            _passWord = passWord;
            _hospitalName = hospitalName;
            if (!isSync)
            {
                _backgroundWorker.DoWork += _backgroundWorker_DoWork;
                _backgroundWorker.ProgressChanged += _backgroundWorker_ProgressChanged;
                _backgroundWorker.RunWorkerCompleted += _backgroundWorker_RunWorkerCompleted;
            }
            else
            {
                _backgroundWorker.DoWork += _backgroundWorker_DoWorkSync;
                _backgroundWorker.ProgressChanged += _backgroundWorker_ProgressChanged;
                _backgroundWorker.RunWorkerCompleted += _backgroundWorker_RunWorkerCompleted;
            }

            //UtHV 28/04/2017 hard code module Hue FMC
            //HolywoodHospitalCode just for testing
            _allowModules = (_branchNo == Constant.HueFMCHospitalCode || _branchNo == Constant.HolywoodHospitalCode) ? Constant.ListModuleHueFMC : Constant.ListModuleFree;

        }

        #region Sync data

        private void _backgroundWorker_DoWorkSync(object sender, DoWorkEventArgs e)
        {
            try
            {
                _branchsController = new BRBranchsController();
                var branch = _branchsController.GetObjectByID(_branchId) as BRBranchsInfo;
                if (branch == null)
                    return;
                var dataUpdate = _userManager.GetDataSycnByDate(_hospitalId, branch.BRBranchLatestSync,
                    _currentUser.userId,
                    _currentUser.sessionId);
                if (dataUpdate == null)
                    return;

                #region Import Patients
                _patientsController = new MEPatientsController();
                _customersController = new ARCustomersController();
                _chBasesController = new MECHBasesController();
                _chBaseFunctions = new CHBaseFunctions();
                _dbUtil = new BOSDbUtil();
                string[] info;
                var customerNumber = GetCustomerNo();
                var customerNumStart = int.Parse(customerNumber[1]);
                var patientNumber = GetPatientNo();
                var patientNumberStart = int.Parse(patientNumber[1]);
                var i = 0;
                foreach (var patient in dataUpdate.patients)
                {
                    i++;
                    var fullName = patient.lastName + " " + patient.firstName; // UtHV theo tên VN
                    info = new[]
                    {
                        $"Đang thêm bệnh nhân:  {(!string.IsNullOrEmpty(fullName) ? fullName : "..........")}",
                        $"Đang cập nhật {i} trên tổng số {dataUpdate.patients.Length} bệnh nhân"
                    };
                    _backgroundWorker.ReportProgress(i * 100 / dataUpdate.patients.Length, info);
                    byte[] bImage = null;
                    //Get image patient
                    if (!string.IsNullOrEmpty(patient.photo))
                        try
                        {
                            using (var wc = new WebClient())
                            {
                                bImage = wc.DownloadData(patient.photo);
                            }
                        }
                        catch (Exception)
                        {
                            //
                        }
                    var oldPatient = _patientsController.GetPatientByBs24x7ID(patient.code);
                    if (oldPatient == null)
                    {
                        //Init info patient
                        var patientInfo = new MEPatientsInfo
                        {
                            MEPatientFirstName = patient.firstName,
                            MEPatientLastName = patient.lastName,
                            MEPatientTitle = patient.title,
                            MEPatientBirthday = BOSApp.UnixTimeStampToDateTime(patient.birthDay, BOSApp.GetTimeZone()) ?? DateTime.MaxValue,
                            MEPatientContactEmail = patient.email,
                            MEPatientType = "Person",
                            MEGender = patient.gender == "F" ? "Female" : "Male",
                            MEMarital =
                                patient.maritalStatus == null
                                    ? null
                                    : (patient.maritalStatus == true ? "Married" : "Single"),
                            MEPatientContactCellPhone = patient.phone,
                            MEPatientBs24x7ID = patient.code,
                            MEPatientIDCard = patient.idNo,
                            MEPatientContactAddress = patient.address,
                            MEPatientContactAddressCity = patient.city?.name,
                            MEPatientContactAddressDistrict = patient.district?.name,
                            AACreatedUser = _userName,
                            MEPatientName = fullName.ToUpper(), //UtHV Edit 21032017
                            MEPatientNo = patientNumber[0] + patientNumberStart + "99",
                            MEPatientPicture = bImage
                        };

                        var customerInfo = new ARCustomersInfo
                        {
                            AACreatedUser = _userName,
                            FK_BRBranchID = _branchId,
                            ARCustomerName = fullName,
                            ARCustomerActiveCheck = true,
                            ARCustomerTypeCombo = "Patient",
                            ARCustomerContactBirthday =
                                BOSApp.UnixTimeStampToDateTime(patient.birthDay, BOSApp.GetTimeZone()) ?? DateTime.MaxValue,
                            ARCustomerContactEmail1 = patient.email,
                            ARCustomerContactCellPhone = patient.phone,
                            ARCustomerContactAddressLine1 = patient.address,
                            ARCustomerContactTitle = patient.title,
                            MEPatientIDCard = patient.idNo,
                            ARCustomerContactAddressCity = patient.city?.name,
                            ARCustomerContactFirstName = patient.firstName,
                            ARCustomerContactLastName = patient.lastName,
                            ARCustomerContactName = fullName,
                            ARCustomerName1 = fullName,
                            ARCustomerNo = patientInfo.MEPatientNo
                        };
                        var patientId = SavePatientObject(patientInfo, customerInfo);
                        patientNumberStart++;
                        customerNumStart++;
                        if (patient.chBaseInfo == null) continue;
                        CreateChBase(patient.chBaseInfo, patientId);
                    }
                    else
                    {
                        //Exist patient. Update data
                        oldPatient.MEPatientFirstName = patient.firstName;
                        oldPatient.MEPatientLastName = patient.lastName;
                        oldPatient.MEPatientTitle = patient.title;
                        oldPatient.MEPatientBirthday = BOSApp.UnixTimeStampToDateTime(patient.birthDay, BOSApp.GetTimeZone()) ??
                                                       DateTime.MaxValue;
                        oldPatient.MEPatientContactEmail = patient.email;
                        oldPatient.MEPatientType = "Person";
                        oldPatient.MEGender = patient.gender == "F" ? "Female" : "Male";
                        oldPatient.MEMarital =
                            patient.maritalStatus == null
                                ? null
                                : (patient.maritalStatus == true ? "Married" : "Single");
                        oldPatient.MEPatientContactCellPhone = patient.phone;
                        oldPatient.MEPatientBs24x7ID = patient.code;
                        oldPatient.MEPatientIDCard = patient.idNo;
                        oldPatient.MEPatientContactAddress = patient.address;
                        oldPatient.MEPatientContactAddressCity = patient.city?.name;
                        oldPatient.MEPatientContactAddressDistrict = patient.district?.name;
                        oldPatient.AACreatedUser = _userName;
                        oldPatient.MEPatientName = fullName.ToUpper();
                        oldPatient.MEPatientPicture = bImage;
                        _patientsController.UpdateObject(oldPatient);
                        var customer = _customersController.GetObjectByNo(oldPatient.MEPatientNo) as ARCustomersInfo;
                        if (customer == null) continue;
                        customer.ARCustomerContactBirthday =
                            BOSApp.UnixTimeStampToDateTime(patient.birthDay, BOSApp.GetTimeZone()) ?? DateTime.MaxValue;
                        customer.ARCustomerContactEmail1 = patient.email;
                        customer.ARCustomerContactCellPhone = patient.phone;
                        customer.ARCustomerContactAddressLine1 = patient.address;
                        customer.ARCustomerContactTitle = patient.title;
                        customer.MEPatientIDCard = patient.idNo;
                        customer.ARCustomerContactAddressCity = patient.city?.name;
                        customer.ARCustomerContactFirstName = patient.firstName;
                        customer.ARCustomerContactLastName = patient.lastName;
                        customer.ARCustomerContactName = fullName;
                        customer.ARCustomerName1 = fullName;
                        _customersController.UpdateObject(customer);
                        if (patient.chBaseInfo == null) continue;
                        var oldChbase = _chBasesController.GetAccountByPatientId(oldPatient.MEPatientID);
                        if (oldChbase != null) continue;
                        CreateChBase(patient.chBaseInfo, oldPatient.MEPatientID);
                    }
                }
                var numberPatientInfo = (GENumberingInfo)_geNumberingController.GetObjectByName(ModuleName.MEPatient);
                var nuberingList = _geNumberingController.GetNumberingListByName(ModuleName.Customer);
                var objGeNumberingInfo = nuberingList.Count == 1
                    ? nuberingList[0]
                    : (nuberingList.FirstOrDefault(x => x.FK_BRBranchID == BOSApp.CurrentCompanyInfo.FK_BRBranchID) ??
                       nuberingList[0]);
                numberPatientInfo.GENumberingStart = patientNumberStart;
                objGeNumberingInfo.GENumberingStart = customerNumStart;
                _geNumberingController.UpdateObject(numberPatientInfo);
                _geNumberingController.UpdateObject(objGeNumberingInfo);

                #endregion

                #region Import CheckupTypes

                _specialismsController = new MESpecialismsController();
                i = 0;
                var specialisms = _specialismsController.GetListBusinessObjects().Cast<MESpecialismsInfo>().ToList();
                foreach (var checkupType in dataUpdate.checkupTypes)
                {
                    i++;
                    info = new[]
                    {
                        "Đang thêm chuyên khoa: " + checkupType.name,
                        $"Đang xử lý {i} trên tổng {dataUpdate.checkupTypes.Length} chuyên khoa.",
                        string.Empty
                    };
                    _backgroundWorker.ReportProgress(i * 100 / dataUpdate.checkupTypes.Length, info);
                    var oldSpecial = specialisms.FirstOrDefault(x => x.MESpecialismBacSi24x7 == checkupType.id);
                    if (oldSpecial == null)
                    {
                        _specialismsController.CreateObject(new MESpecialismsInfo
                        {
                            MESpecialismName = checkupType.name,
                            MESpecialismDesc = checkupType.name,
                            MESpecialismBacSi24x7 = checkupType.id
                        });
                    }
                    else
                    {
                        oldSpecial.MESpecialismName = checkupType.name;
                        oldSpecial.MESpecialismDesc = checkupType.name;
                        _specialismsController.UpdateObject(oldSpecial);
                    }
                }

                #endregion

                #region Import Doctors

                var listSpecial = _specialismsController.GetListBusinessObjects().Cast<MESpecialismsInfo>().ToList();
                var employeesController = new HREmployeesController();
                i = 0;
                foreach (var doctor in dataUpdate.doctors)
                {
                    i++;
                    info = new[]
                    {
                        "Đang xử lý bác sĩ: " + doctor.fullName,
                        $"Đang xử lý {i} trên tổng {dataUpdate.doctors.Length} bác sĩ.",
                        string.Empty
                    };
                    _backgroundWorker.ReportProgress(i * 100 / dataUpdate.doctors.Length, info);

                    var oldEmployeesInfo = employeesController.GetEmployeesInfoByBs24x7(doctor.id, _branchId);
                    if (oldEmployeesInfo == null)
                    {
                        var empNo = BOSApp.GetMainObjectNo("Bs24x7Doctor");
                        var dtInfo = doctor.doctorInfos?.FirstOrDefault(x => x.hospitalId == _hospitalId);
                        var specialId = 0;
                        if (dtInfo != null)
                        {
                            var special =
                                listSpecial.FirstOrDefault(x => x.MESpecialismBacSi24x7 == dtInfo.checkupTypeId);
                            specialId = special?.MESpecialismID ?? 0;
                        }
                        employeesController.CreateEmployeeAndUserFromBs24X7(empNo, _branchId, 0, null, null,
                            doctor.fullName, doctor.id,
                            specialId, false);
                        BOSApp.UpdateObjectNumbering("Bs24x7Doctor");
                    }
                    else
                    {
                        var dtInfo = doctor.doctorInfos?.FirstOrDefault(x => x.hospitalId == _hospitalId);
                        var specialId = 0;
                        if (dtInfo != null)
                        {
                            var special =
                                listSpecial.FirstOrDefault(x => x.MESpecialismBacSi24x7 == dtInfo.checkupTypeId);
                            specialId = special?.MESpecialismID ?? 0;
                        }
                        oldEmployeesInfo.HREmployeeName = doctor.fullName;
                        oldEmployeesInfo.FK_MESpecialismID = specialId;
                        oldEmployeesInfo.FK_BRBranchID = _branchId;
                        employeesController.UpdateObject(oldEmployeesInfo);
                    }
                }

                #endregion

                #region Refresh Data

                info = new[] { "Đang làm mới dữ liệu", string.Empty, string.Empty };
                _backgroundWorker.ReportProgress(0, info);
                BOSApp.InitLookupTables();

                #endregion
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        #endregion

        #region Sync by first login

        private void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var idGroup = 0;
            try
            {
                _patientsController = new MEPatientsController();
                _customersController = new ARCustomersController();
                _dbUtil = new BOSDbUtil();
                _chBasesController = new MECHBasesController();
                _chBaseFunctions = new CHBaseFunctions();
                var isWhile = true;

                #region  Import Patients

                var count = 0;
                var customerNumber = GetCustomerNo();
                var customerNumStart = int.Parse(customerNumber[1]);
                var patientNumber = GetPatientNo();
                var patientNumberStart = int.Parse(patientNumber[1]);

                string[] info;
                while (isWhile)
                {
                    info = new[]
                    {
                        $"Đang lấy dữ liệu từ server.",
                        string.Empty,
                        string.Empty
                    };
                    _backgroundWorker.ReportProgress(0, info);
                    _listPatient = _userManager.GetListPatientByHospital(_hospitalId, _currentUser.userId,
                        _currentUser.sessionId, count, 100);
                    if (!_listPatient.successful || _listPatient.data == null) break;
                    var i = 0;
                    foreach (var patient in _listPatient.data.patients)
                    {
                        i++;
                        var fullName = patient.lastName + " " + patient.firstName; // UtHV theo tên VN
                        info = new[]
                        {
                            $"Đang thêm bệnh nhân:  {(!string.IsNullOrEmpty(fullName) ? fullName : "..........")}",
                            $"Đang cập nhật {count + i} trên tổng số {_listPatient.data.total} bệnh nhân"
                        };
                        _backgroundWorker.ReportProgress(i, info);
                        byte[] bImage = null;
                        //Get image patient
                        if (!string.IsNullOrEmpty(patient.photo))
                            try
                            {
                                using (var wc = new WebClient())
                                {
                                    bImage = wc.DownloadData(patient.photo);
                                }
                            }
                            catch (Exception)
                            {
                                //
                            }
                        //Init info patient
                        var patientInfo = new MEPatientsInfo
                        {
                            MEPatientFirstName = patient.firstName,
                            MEPatientLastName = patient.lastName,
                            MEPatientTitle = patient.title,
                            MEPatientBirthday = BOSApp.UnixTimeStampToDateTime(patient.birthDay, BOSApp.GetTimeZone()) ?? DateTime.MaxValue,
                            MEPatientContactEmail = patient.email,
                            MEPatientType = "Person",
                            MEGender = patient.gender == "F" ? "Female" : "Male",
                            MEMarital =
                                patient.maritalStatus == null
                                    ? null
                                    : (patient.maritalStatus == true ? "Married" : "Single"),
                            MEPatientContactCellPhone = patient.phone,
                            MEPatientBs24x7ID = patient.code,
                            MEPatientIDCard = patient.idNo,
                            MEPatientContactAddress = patient.address,
                            MEPatientContactAddressCity = patient.city?.name,
                            MEPatientContactAddressDistrict = patient.district?.name,
                            AACreatedUser = _userName,
                            MEPatientName = fullName.ToUpper(), //UtHV Edit 21032017
                            MEPatientNo = patientNumber[0] + patientNumberStart + "99",
                            MEPatientPicture = bImage
                        };

                        var customerInfo = new ARCustomersInfo
                        {
                            AACreatedUser = _userName,
                            FK_BRBranchID = _branchId,
                            ARCustomerName = fullName,
                            ARCustomerActiveCheck = true,
                            ARCustomerTypeCombo = "Patient",
                            ARCustomerContactBirthday =
                                BOSApp.UnixTimeStampToDateTime(patient.birthDay, BOSApp.GetTimeZone()) ?? DateTime.MaxValue,
                            ARCustomerContactEmail1 = patient.email,
                            ARCustomerContactCellPhone = patient.phone,
                            ARCustomerContactAddressLine1 = patient.address,
                            ARCustomerContactTitle = patient.title,
                            MEPatientIDCard = patient.idNo,
                            ARCustomerContactAddressCity = patient.city?.name,
                            ARCustomerContactFirstName = patient.firstName,
                            ARCustomerContactLastName = patient.lastName,
                            ARCustomerContactName = fullName,
                            ARCustomerName1 = fullName,
                            // UtHV Patient and Customer must the same NO
                            ARCustomerNo = patientInfo.MEPatientNo //customerNumber[0] + customerNumStart,
                        };
                        var patientId = SavePatientObject(patientInfo, customerInfo);
                        customerNumStart++;
                        patientNumberStart++;

                        if (patient.chBaseInfo == null) continue;
                        CreateChBase(patient.chBaseInfo, patientId);
                    }
                    if ((count = count + 100) > _listPatient.data.total)
                        isWhile = false;
                }
                var numberPatientInfo = (GENumberingInfo)_geNumberingController.GetObjectByName(ModuleName.MEPatient);
                var nuberingList = _geNumberingController.GetNumberingListByName(ModuleName.Customer);
                var objGeNumberingInfo = nuberingList.Count == 1
                    ? nuberingList[0]
                    : (nuberingList.FirstOrDefault(i => i.FK_BRBranchID == BOSApp.CurrentCompanyInfo.FK_BRBranchID) ??
                       nuberingList[0]);

                numberPatientInfo.GENumberingStart = patientNumberStart;
                objGeNumberingInfo.GENumberingStart = customerNumStart;
                _geNumberingController.UpdateObject(numberPatientInfo);
                _geNumberingController.UpdateObject(objGeNumberingInfo);

                #endregion

                #region Import CheckupType

                _specialismsController = new MESpecialismsController();
                _checkupTypeManager = new CheckupTypeManager();
                info = new[]
                {
                    $"Đang lấy dữ liệu chuyên khoa.",
                    string.Empty,
                    string.Empty
                };
                _backgroundWorker.ReportProgress(0, info);
                var listCheckupTypes = _checkupTypeManager.GetCheckupTypesByHospital(_hospitalId, _currentUser.userId,
                    _currentUser.sessionId);
                var c = 0;
                if (listCheckupTypes != null && listCheckupTypes.Count > 0)
                {
                    c++;
                    foreach (var checkupType in listCheckupTypes)
                    {
                        info = new[]
                        {
                            $"Đang thêm chuyên khoa: " + checkupType.name,
                            $"Đang thêm {c} trên tổng {listCheckupTypes.Count} chuyên khoa.",
                            string.Empty
                        };
                        _backgroundWorker.ReportProgress(c * 100 / listCheckupTypes.Count, info);
                        _specialismsController.CreateObject(new MESpecialismsInfo
                        {
                            MESpecialismName = checkupType.name,
                            MESpecialismDesc = checkupType.name,
                            MESpecialismBacSi24x7 = checkupType.id
                        });
                    }
                }

                #endregion

                var info2 = new[]
                {
                    $"Đang cập nhật tài khoản người dùng.",
                    string.Empty,
                    string.Empty
                };
                _backgroundWorker.ReportProgress(0, info2);
                _userGroupsController = new ADUserGroupsController();
                _userGroupSectionsController = new ADUserGroupSectionsController();
                _usersController = new ADUsersController();
                _moduleToUserGroupSectionsController = new STModuleToUserGroupSectionsController();
                //Create user for new group permission

                //Create UserGroup
                idGroup = CreateUserGroup(_hospitalName);
                CreateFunctions(idGroup);

                #region Import Doctors

                info = new[]
                {
                    $"Đang lấy dữ liệu bác sĩ từ server.",
                    string.Empty,
                    string.Empty
                };
                _backgroundWorker.ReportProgress(0, info);
                var listSpecial = _specialismsController.GetListBusinessObjects().Cast<MESpecialismsInfo>().ToList();
                c = 0;
                var empCtrl = new HREmployeesController();

                _doctorManager = new DoctorManager();
                var doctorResult = _doctorManager.GetListDoctors(_currentUser.userId,
                    _currentUser.sessionId, _hospitalId, null, 0, int.MaxValue, null, "firstName", "ASC", null);
                var empNo = BOSApp.GetMainObjectNo("Bs24x7Doctor");

                if (doctorResult.successful && doctorResult.data != null && doctorResult.data.total > 0)
                {
                    var current = doctorResult.data.doctors.FirstOrDefault(x => x.id == _currentUser.userId);
                    if (current != null)
                    {
                        var dtInfo = current.doctorInfos.FirstOrDefault(x => x.hospitalId == _hospitalId);
                        var specialId = 0;
                        if (dtInfo != null)
                        {
                            var special =
                                listSpecial.FirstOrDefault(x => x.MESpecialismBacSi24x7 == dtInfo.checkupTypeId);
                            specialId = special?.MESpecialismID ?? 0;
                        }
                        empCtrl.CreateEmployeeAndUserFromBs24X7(empNo, _branchId, idGroup, _userName, _passWord,
                            _userFullName, current.id, specialId);
                    }
                    else
                    {
                        empCtrl.CreateEmployeeAndUserFromBs24X7(empNo, _branchId, idGroup, _userName, _passWord,
                            _userFullName);
                    }

                    BOSApp.UpdateObjectNumbering("Bs24x7Doctor");
                    empCtrl = new HREmployeesController();

                    foreach (var doctor in doctorResult.data.doctors)
                    {
                        if (doctor.id == _currentUser.userId) continue;
                        c++;
                        info = new[]
                        {
                            "Đang thêm bác sĩ: " + doctor.fullName,
                            $"Đang thên {c} trên tổng {doctorResult.data.total} bác sĩ.",
                            string.Empty
                        };
                        _backgroundWorker.ReportProgress(c * 100 / doctorResult.data.total, info);
                        empNo = BOSApp.GetMainObjectNo("Bs24x7Doctor");
                        var dtInfo = doctor.doctorInfos.FirstOrDefault(x => x.hospitalId == _hospitalId);
                        var specialId = 0;
                        if (dtInfo != null)
                        {
                            var special =
                                listSpecial.FirstOrDefault(x => x.MESpecialismBacSi24x7 == dtInfo.checkupTypeId);
                            specialId = special?.MESpecialismID ?? 0;
                        }
                        empCtrl.CreateEmployeeAndUserFromBs24X7(empNo, _branchId, idGroup, null, null, doctor.fullName,
                            doctor.id, specialId, false);
                        BOSApp.UpdateObjectNumbering("Bs24x7Doctor");
                    }
                }
                else
                {
                    empNo = BOSApp.GetMainObjectNo("Bs24x7Doctor");
                    empCtrl.CreateEmployeeAndUserFromBs24X7(empNo, _branchId, idGroup, _userName, _passWord,
                        _userFullName, BOSApp.CurrentBacSi24X7.userId);
                    BOSApp.UpdateObjectNumbering("Bs24x7Doctor");
                }

                #endregion

                #region Update Permission

                var listUser = _usersController.GetListBusinessObjects().Cast<ADUsersInfo>();
                info = new[]
                {
                    string.Empty,
                    $"Phân quyền dữ liệu",
                    string.Empty
                };
                _backgroundWorker.ReportProgress(0, info);
                var dataViewPermissionsController = new ADDataViewPermissionsController();
                var moduleList = new List<int>();
                for (var i = 0; i < this._allowModules.GetLength(0); i++)
                {
                    var modules = this._allowModules[i, 1];
                    moduleList.AddRange(modules.Split(',').Select(int.Parse));
                }
                c = 1;
                foreach (var usersInfo in listUser)
                {
                    if (usersInfo.ADUserID == 1)
                        continue;
                    dataViewPermissionsController.PermissionViewData(usersInfo.ADUserID, _branchId, moduleList);
                    info = new[]
                {
                    string.Empty,
                    $"Phân quyền cho người dùng: "+usersInfo.ADUserName,
                    string.Empty
                }; _backgroundWorker.ReportProgress(c * 100 / listUser.Count(), info);
                    c++;
                }

                #endregion

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                _branchsController = new BRBranchsController();
                _branchsController.DeleteObject(_branchId);
                if (idGroup != 0)
                    _userGroupsController?.DeleteObject(idGroup);
                DialogResult = DialogResult.Cancel;
            }
        }
        #endregion

        private void _backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Close();
        }

        private void _backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.EditValue = e.ProgressPercentage;
            var info = e.UserState as string[];
            if (info != null)
            {
                lblProgress.Text = info[0];
                lblRemaing.Text = info[1];
            }
            Application.DoEvents();
        }

        private int CreateUserGroup(string name)
        {
            //Create group user for new Account
            var objAdUserGroupsInfo = new ADUserGroupsInfo
            {
                ADUserGroupName = name,
                ADLanguageIDCombo = 1,
                ADUserGroupDesc = name
            };
            return _userGroupsController.CreateObject(objAdUserGroupsInfo);
        }

        private void CreateFunctions(int idGroup)
        {
            for (var i = 0; i < this._allowModules.GetLength(0); i++)
            {
                var section = this._allowModules[i, 0];
                var groupSection = new ADUserGroupSectionsInfo
                {
                    ADUserGroupID = idGroup,
                    ADUserGroupSectionName = section,
                    ADUserGroupSectionDesc = section,
                    ADUserGroupSectionSortOrder = i + 1
                };
                var sectionId = _userGroupSectionsController.CreateObject(groupSection);
                var modules = this._allowModules[i, 1];
                var listModule = modules.Split(',');
                var sort = 1;
                foreach (var s in listModule)
                {
                    var module = new STModuleToUserGroupSectionsInfo
                    {
                        STUserGroupSectionID = sectionId,
                        STModuleID = int.Parse(s),
                        STModuleToUserGroupSectionSortOrder = sort++
                    };
                    _moduleToUserGroupSectionsController.CreateObject(module);
                }
            }
        }

        private void GuiSyncData_Load(object sender, EventArgs e)
        {
            _backgroundWorker.RunWorkerAsync();
        }

        private int SavePatientObject(MEPatientsInfo patientInfo, ARCustomersInfo customerInfo)
        {
            patientInfo.MEPatientContactAddressLine2 = BOSUtil.GenerateFullAddress(patientInfo,
                AddressType.Contact.ToString());
            patientInfo.MEPatientContactAddressLine2 = patientInfo.MEPatientContactAddressLine1 + ", " +
                                                       patientInfo.GELocationName;
            patientInfo.MEPatientContactAddressLine2 = patientInfo.MEPatientContactAddressLine1 + ", " +
                                                       patientInfo.GELocationName;
            patientInfo.MEPatientContactAddressLine3 = patientInfo.MEPatientContactAddressLine2;
            _customersController.CreateObject(customerInfo);
            patientInfo.MEPatientID = customerInfo.ARCustomerID;
            return _patientsController.CreateObject(patientInfo);
        }

        public string[] GetCustomerNo()
        {
            _geNumberingController = new GENumberingController();
            var nuberingList = _geNumberingController.GetNumberingListByName(ModuleName.Customer);
            var objGeNumberingInfo = nuberingList.Count == 1
                ? nuberingList[0]
                : nuberingList.FirstOrDefault(i => i.FK_BRBranchID == BOSApp.CurrentCompanyInfo.FK_BRBranchID);
            var currentDate = _dbUtil.GetCurrentServerDate();
            var prefixYear = currentDate.Year.ToString().Substring(2, 2) + ".";
            if (objGeNumberingInfo == null)
            {
                var start = "100000";
                return new[] { "KH" + prefixYear, start.PadLeft(start.Length, '0') };
            }
            var numberStart = objGeNumberingInfo.GENumberingStart;

            if (objGeNumberingInfo.GENumberingPrefixHaveYear)
                if (objGeNumberingInfo.AAUpdatedDate.Year < currentDate.Year)
                    numberStart = Convert.ToInt32(Math.Pow(10, objGeNumberingInfo.GENumberingLength - 1)) + 1;

            var strMainObjectNo =
                $"{objGeNumberingInfo.GENumberingPrefix}{prefixYear}{numberStart.ToString().PadLeft(objGeNumberingInfo.GENumberingLength, '0')}";

            while (_customersController.IsExist(strMainObjectNo))
            {
                numberStart++;
                strMainObjectNo =
                    $"{objGeNumberingInfo.GENumberingPrefix}{prefixYear}{numberStart.ToString().PadLeft(objGeNumberingInfo.GENumberingLength, '0')}";
            }
            return new[]
            {
                objGeNumberingInfo.GENumberingPrefix + prefixYear,
                numberStart.ToString().PadLeft(objGeNumberingInfo.GENumberingLength, '0')
            };
        }

        public string[] GetPatientNo()
        {
            var currentYear = DateTime.Now.ToString("yy");
            var objGeNumberingInfo = (GENumberingInfo)_geNumberingController.GetObjectByName(ModuleName.MEPatient);
            if (objGeNumberingInfo == null)
            {
                const string start = "100000";
                return new[] { "KH" + currentYear, start.PadLeft(start.Length, '0') };
            }
            var strMainObjectNo =
                $"{objGeNumberingInfo.GENumberingPrefix}{currentYear}-{objGeNumberingInfo.GENumberingStart}";
            var numberingStart = objGeNumberingInfo.GENumberingStart;
            while (_patientsController.IsExist(strMainObjectNo))
            {
                numberingStart++;
                strMainObjectNo = $"{objGeNumberingInfo.GENumberingPrefix}{currentYear}-{numberingStart}";
            }
            return new[] { $"{objGeNumberingInfo.GENumberingPrefix}{currentYear}-", numberingStart.ToString() };
        }

        private void CreateChBase(ChbaseInfoModel model, int patientId)
        {
            try
            {
                var mechBasesInfo = new MECHBasesInfo
                {
                    MECHBaseParticipantName = model.userEmail,
                    MECHBaseSecurityQuestion = "Vui lòng nhập email đăng nhập của bạn?",
                    MECHBaseSecurityAnswer = model.userEmail,
                    MECHBaseParticipantId = Guid.NewGuid().ToString(),
                    MECHBaseDateTokenGenerated = DateTime.Now,
                    MECHBaseHasAuthorized = false
                };
                var participantCode = _chBaseFunctions.CreateParticipantIdentityCode(mechBasesInfo.MECHBaseParticipantName, mechBasesInfo.MECHBaseSecurityQuestion, mechBasesInfo.MECHBaseSecurityAnswer, mechBasesInfo.MECHBaseParticipantId);
                mechBasesInfo.MECHBaseParticipantCode = participantCode;
                mechBasesInfo.FK_MEPatientID = patientId;
                _chBasesController.CreateObject(mechBasesInfo);
            }
            catch (Exception)
            {
                //Ignore
            }

        }
    }
}
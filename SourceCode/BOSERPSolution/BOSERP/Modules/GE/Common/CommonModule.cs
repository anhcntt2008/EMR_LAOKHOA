using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using BOSCommon;
using BOSComponent;
using BOSERP.Modules.ME.MEPatient.Localization;
using BOSLib;
using Clas.Business.Doctor24x7;
using Clas.Model.Doctor24x7;
using DevExpress.XtraScheduler;
using Localization;

namespace BOSERP.Modules.Common
{
    public class CommonModule : BaseModuleERP
    {
        public const string PatientAppointmentSchedulerName = "fld_schedulerControlMEPatientAppointment";
        public const string DateFromDateEditName = "fld_dteDateFrom";
        public const string DateToDateEditName = "fld_dteDateTo";
        // The main control for communicating through the RS-232 port
        private readonly SerialPort comport = new SerialPort();
        private BOSDateEdit DateFromDateEdit;
        private BOSDateEdit DateToDateEdit;
        private SchedulerControl PatientAppointmentScheduler;

        public CommonModule()
        {
            Name = "Common";
            CurrentModuleEntity = new CommonEntities();
            CurrentModuleEntity.Module = this;
            CurrentModuleEntity.InitModuleEntity();
            //InitializeModule();
            PatientAppointmentScheduler = (SchedulerControl)Controls[PatientAppointmentSchedulerName];
            DateFromDateEdit = (BOSDateEdit)Controls[DateFromDateEditName];
            DateToDateEdit = (BOSDateEdit)Controls[DateToDateEditName];
        }

        public override void Invalidate(int iObjectId)
        {
            base.Invalidate(iObjectId);
        }

        public MEPatientsInfo SearchPatientByEmai(string email)
        {
            var objMePatientController = new MEPatientsController();
            var objMePatient = objMePatientController.GetListPatientsByEmail(email).FirstOrDefault();
            if (objMePatient != null)
                return objMePatient;
            return null;
        }

        public void InitAppoinmentScheduler()
        {
            PatientAppointmentScheduler = (SchedulerControl)Controls[PatientAppointmentSchedulerName];
            DateFromDateEdit = (BOSDateEdit)Controls[DateFromDateEditName];
            DateToDateEdit = (BOSDateEdit)Controls[DateToDateEditName];
            //CommonEntities entity = (CommonEntities)CurrentModuleEntity;
            //BindingSource bds = new BindingSource();
            //bds.DataSource = entity.MEPatientAppointmentsList;
            //PatientAppointmentScheduler.Storage.Appointments.DataSource = bds;
            PatientAppointmentScheduler.Storage.Appointments.Mappings.Label = "MEPatientAppointmentID";
            PatientAppointmentScheduler.Storage.Appointments.Mappings.Subject = "FK_HREmployeeID";
            PatientAppointmentScheduler.Storage.Appointments.Mappings.Start = "MEPatientAppointmentTime";
            PatientAppointmentScheduler.Storage.Appointments.Mappings.End = "MEPatientAppointmentEndTime";
            PatientAppointmentScheduler.Storage.Appointments.Mappings.Description = "FK_METimeFrameID";
            PatientAppointmentScheduler.Storage.Appointments.Mappings.Status = "MEPatientAppointmentReason";
            PatientAppointmentScheduler.Storage.Appointments.Mappings.Location = "FK_MEPatientID";
            PatientAppointmentScheduler.Storage.Appointments.CustomFieldMappings.Add(new
                AppointmentCustomFieldMapping("MEPatientAppointmentReason", "MEPatientAppointmentReason"));
        }

        public void GetCheckUps()
        {
            Cursor.Current = Cursors.WaitCursor;
            var entity = (CommonEntities)CurrentModuleEntity;

            if (BOSApp.CurrentBacSi24X7 != null)
            {
                var startDate = BOSApp.ConvertToTimestamp((DateTime)DateFromDateEdit.EditValue);
                var endDate = BOSApp.ConvertToTimestamp((DateTime)DateToDateEdit.EditValue);
                var cm = new CheckupManager();
                var resultListCheckup = cm.GetListCheckupOfHospital(BOSApp.CurrentBacSi24X7.userId,
                    BOSApp.CurrentBacSi24X7.sessionId,
                    BOSApp.CurrentBacSi24X7.hospitals[BOSApp.CurrentBacSi24X7.hospitalSelectedIndex].hospitalId,
                    startDate, endDate);
                var listCheckup = resultListCheckup.data.checkups;
                var listAi = new List<MEPatientAppointmentsInfo>();
                for (var i = 0; i < listCheckup.Count; i++)
                {
                    var unixTimeStampToDateTime = BOSApp.UnixTimeStampToDateTime(listCheckup[i].appointmentDate);
                    if (unixTimeStampToDateTime != null)
                    {
                        var timeStampToDateTime = BOSApp.UnixTimeStampToDateTime(listCheckup[i].endAppointmentDate);
                        if (timeStampToDateTime != null)
                        {
                            var dataUser = listCheckup[i].dataUser;
                            if (dataUser != null)
                            {
                                var ai = new MEPatientAppointmentsInfo
                                {
                                    MEPatientAppointmentID = i,
                                    MEPatientAppointmentTime =
                                        (DateTime)unixTimeStampToDateTime,
                                    MEPatientAppointmentEndTime =
                                        (DateTime)timeStampToDateTime,
                                    MEPatientAppointmentReason = listCheckup[i].symptom,
                                    MEPatientName = listCheckup[i].doctor == null ? "" : listCheckup[i].doctor.fullName,
                                    MEPatientAppointmentRemark =
                                        dataUser.fullName,
                                    MEPatientEmail = dataUser.email
                                };
                                listAi.Add(ai);
                            }
                        }
                    }
                }
                PatientAppointmentScheduler.Storage.Appointments.Mappings.Subject = "MEPatientName";
                PatientAppointmentScheduler.Storage.Appointments.Mappings.Location = "MEPatientAppointmentRemark";
                PatientAppointmentScheduler.Storage.Appointments.DataSource = listAi;
                entity.MEPatientAppointmentsList.Invalidate(listAi);
                PatientAppointmentScheduler.RefreshData();
                //entity.UpdatedAppointments.Clear();
                //entity.DeletedAppointments.Clear();
            }
        }

        /// <summary>
        ///     Logout from the current user
        /// </summary>
        public void Logout()
        {
            BOSApp.LogOff();
        }

        /// <summary>
        ///     Called when the user changes their password
        /// </summary>
        public void ChangePassword()
        {
            var guiChangePassword = new guiChangePassword();
            guiChangePassword.Module = this;
            guiChangePassword.ShowDialog();
        }

        public bool CheckPassword(string pass)
        {
            var passwordBytes = SHA1.Create().ComputeHash(Encoding.ASCII.GetBytes(pass));
            var p = Convert.ToBase64String(passwordBytes);
            if (p == BOSApp.CurrentUsersInfo.ADPassword)
                return true;
            return false;
        }

        public void UpdateHistory(string desc)
        {
            var objUsingCashDrawerHistorysInfo = new GEUsingCashDrawerHistorysInfo();
            //objUsingCashDrawerHistorysInfo.GEUsingCashDrawerHistoryID = Guid.NewGuid().ToString();
            objUsingCashDrawerHistorysInfo.AAStatus = Status.Alive.ToString();
            objUsingCashDrawerHistorysInfo.FK_ADUserID = BOSApp.CurrentUsersInfo.ADUserID;
            objUsingCashDrawerHistorysInfo.FK_BRBranchID = BOSApp.CurrentCompanyInfo.FK_BRBranchID;
            objUsingCashDrawerHistorysInfo.GEUsingCashDrawerHistoryDate = DateTime.Now;
            objUsingCashDrawerHistorysInfo.GEUsingCashDrawerHistoryRemark = desc;
            objUsingCashDrawerHistorysInfo.IsTransferred = false;
            var objUsingCashDrawerHistorysController = new GEUsingCashDrawerHistorysController();
            objUsingCashDrawerHistorysController.CreateObject(objUsingCashDrawerHistorysInfo);
        }

        public void OpenCashDrawer()
        {
            var gui = new guiOpenCashDrawer();
            gui.Module = this;
            gui.ShowDialog();
            if (gui.DialogResult == DialogResult.Yes)
            {
                var error = false;
                // If the port is open, close it.
                if (comport.IsOpen)
                {
                    comport.Close();
                }
                else
                {
                    var config = ConfigurationManager.AppSettings["CashDrawerConfig"];
                    if (config == null || config.Split('|').Length < 5)
                    {
                        // Set the port's settings
                        comport.BaudRate = int.Parse("9600");
                        comport.DataBits = int.Parse("8");
                        comport.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
                        comport.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
                        comport.PortName = "COM1";
                    }
                    else
                    {
                        var str = config.Split('|'); //COM1|9600|None|8|One
                        comport.BaudRate = int.Parse(str[1]);
                        comport.DataBits = int.Parse(str[3]);
                        comport.StopBits = (StopBits)Enum.Parse(typeof(StopBits), str[4]);
                        comport.Parity = (Parity)Enum.Parse(typeof(Parity), str[2]);
                        comport.PortName = str[0];
                    }
                    try
                    {
                        // Open the port
                        comport.Open();
                    }
                    catch (UnauthorizedAccessException)
                    {
                        error = true;
                    }
                    catch (IOException)
                    {
                        error = true;
                    }
                    catch (ArgumentException)
                    {
                        error = true;
                    }

                    if (error)
                        MessageBox.Show(
                            @"Could not open the COM port.  Most likely it is already in use, has been removed, or is unavailable.",
                            @"COM Port Unavalible", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    // If the port is open, send focus to the send data box
                    if (comport.IsOpen)
                    {
                        comport.Write("COM1");
                        comport.Close();
                    }
                }
            }
        }

        /// <summary>
        ///     Change the user's password
        /// </summary>
        /// <param name="password">New password</param>
        /// <param name="confirmedPassword">Confirmed password</param>
        /// <returns>True if change successfully, otherwise false</returns>
        public bool ChangePassword(string password, string confirmedPassword)
        {
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show(CommonLocalizedResources.PasswordIsRequiredMessage,
                    CommonLocalizedResources.MessageBoxDefaultCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            if (password != confirmedPassword)
            {
                MessageBox.Show(CommonLocalizedResources.ConfirmedPasswordNotMatchMessage,
                    CommonLocalizedResources.MessageBoxDefaultCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var objUsersController = new ADUsersController();
            var passwordBytes = SHA1.Create().ComputeHash(Encoding.ASCII.GetBytes(password));
            BOSApp.CurrentUsersInfo.ADPassword = Convert.ToBase64String(passwordBytes);
            objUsersController.UpdateObject(BOSApp.CurrentUsersInfo);
            MessageBox.Show(CommonLocalizedResources.ChangePasswordSuccessfullyMessage,
                CommonLocalizedResources.MessageBoxDefaultCaption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            return true;
        }

        /// <summary>
        ///     UtHV
        ///     Get all checkup from Bs24x7 in this month
        /// </summary>
        /// <returns></returns>
        public void InitGetAllCheckUps(DateTime start, DateTime end)
        {
            if (BOSApp.CurrentBacSi24X7 != null)
            {
                var startDate = BOSApp.ConvertToTimestamp(start);
                var endDate = BOSApp.ConvertToTimestamp(end);

                var cm = new CheckupManager();
                var resultListCheckup = cm.GetListCheckupOfHospital(BOSApp.CurrentBacSi24X7.userId,
                    BOSApp.CurrentBacSi24X7.sessionId,
                    BOSApp.CurrentBacSi24X7.hospitals[BOSApp.CurrentBacSi24X7.hospitalSelectedIndex].hospitalId,
                    startDate, endDate);
                if (resultListCheckup.data == null)
                    return;
                var listCheckup = resultListCheckup.data.checkups;

                var patientContr = new MEPatientVisitsController();
                var zone = TimeZone.CurrentTimeZone;
                for (var i = 0; i < listCheckup.Count; i++)
                {
                    // mot so thuoc tinh can tinh truoc khi thuc hien binding len calendar
                    listCheckup[i].AppoitmentDateTime =
                        zone.ToLocalTime((DateTime)BOSApp.UnixTimeStampToDateTime(listCheckup[i].appointmentDate, 0));
                    listCheckup[i].AppointmentEndTime =
                        zone.ToLocalTime((DateTime)BOSApp.UnixTimeStampToDateTime(listCheckup[i].endAppointmentDate, 0));
                    listCheckup[i].PatientName = listCheckup[i].dataUser == null ? "" : listCheckup[i].dataUser.fullName;

                    // Check if it is register before
                    var visit = patientContr.GetPatientVisitByBs24x7CheckupId(listCheckup[i].id);
                    if (visit != null)
                    {
                        listCheckup[i].IsLocalRegister = true;
                        listCheckup[i].LocalRegisterStatus = "Đã tiếp nhận";
                    }
                }
                // UtHV Get all checkup when init
                (CurrentModuleEntity as CommonEntities).CheckupBs24x7 = listCheckup;
            }
        }

        #region View Patient's Template

        public void SearchPatient(string query, string email, string phoneNumber)
        {
            var listData = new List<MEPatientsInfo>();
            var entity = (CommonEntities)CurrentModuleEntity;

            #region Search from Database local

            var objPatientsController = new MEPatientsController();
            var listLocal = objPatientsController.GetListPatientBySearchQuery(query);
            if (listLocal != null && listLocal.Count > 0)
                listData.AddRange(listLocal);

            #endregion

            #region Search from Bs24x7

            if (!string.IsNullOrEmpty(phoneNumber) || !string.IsNullOrEmpty(email))
            {
                var userManager = new UserManager();
                if (!string.IsNullOrEmpty(phoneNumber) && phoneNumber.StartsWith("0"))
                    phoneNumber = "+84" + phoneNumber.Remove(0, 1);
                var objPatientPostRequest = new PatientPostRequest
                {
                    email = email, //objPatientsInfo.MEPatientContactEmail,
                    phone = phoneNumber
                };
                try
                {
                    var resultPatient = userManager.CheckOverlapPatient(objPatientPostRequest,
                        BOSApp.CurrentBacSi24X7.userId, BOSApp.CurrentBacSi24X7.sessionId);
                    if (resultPatient.successful && resultPatient.data.patients.Count > 0)
                    {
                        var listBs24X7 = new List<MEPatientsInfo>();
                        foreach (var dataPatient in resultPatient.data.patients)
                        {
                            if (listLocal?.FirstOrDefault(x => x.MEPatientBs24x7ID == dataPatient.code) != null)
                                continue;
                            // Overlap patient, get patient info
                            var objPatientsInfo = new MEPatientsInfo
                            {
                                MEPatientName = dataPatient.fullName.ToUpper(),
                                MEPatientFirstName = dataPatient.firstName,
                                MEPatientLastName = dataPatient.lastName,
                                MEPatientType = "Person",
                                MEPatientContactEmail = dataPatient.email,
                                MEPatientContactCellPhone = dataPatient.phone,
                                MEPatientContactCellPhone2 = dataPatient.phone,
                                MEPatientContactPhone = dataPatient.phone,
                                MEPatientBs24x7ID = dataPatient.code,
                                MEPatientBs24x7GuiId = dataPatient.id,
                                // MEGender = dataPatient.gender != null ? dataPatient.gender.Contains("F") ? "Female" : "Male" : string.Empty,
                                MEPatientIDCard = dataPatient.idNo
                            };

                            if (!string.IsNullOrEmpty(dataPatient.gender))
                                objPatientsInfo.MEGender = dataPatient.gender == "M" ? "Male" : "Female";
                            if (dataPatient.birthDay != null)
                            {
                                var unixTimeStampToDateTime = BOSApp.UnixTimeStampToDateTime(dataPatient.birthDay);
                                if (unixTimeStampToDateTime != null)
                                    objPatientsInfo.MEPatientBirthday = (DateTime)unixTimeStampToDateTime;
                            }
                            objPatientsInfo.MEPatientIDCard = dataPatient.idNo;
                            if (objPatientsInfo.MEMarital != null)
                                objPatientsInfo.MEMarital = dataPatient.maritalStatus == true ? "Married" : "Single";
                            objPatientsInfo.MEPatientContactAddress =
                                $"{dataPatient.address}, {dataPatient.district}, {dataPatient.city}";
                            objPatientsInfo.MEPatientContactAddressDistrict = dataPatient.districtId;
                            objPatientsInfo.MEPatientContactAddressCity = dataPatient.cityId;

                            // Mapping Bs24x7 Id to local to sync after
                            objPatientsInfo.MEPatientBs24x7ID = dataPatient.code;
                            // Set phòng khám id để phân quyền view
                            objPatientsInfo.FK_ADUserGroupID = BOSApp.CurrentUserGroupInfo.ADUserGroupID;
                            objPatientsInfo.MEPatientContactAddress = dataPatient.address;
                            objPatientsInfo.MEPatientContactAddressCity = dataPatient.city?.name;
                            objPatientsInfo.MEPatientContactAddressDistrict = dataPatient.district?.name;

                            objPatientsInfo.MEPatientContactAddressLine2 = BOSUtil.GenerateFullAddress(objPatientsInfo,
                                AddressType.Contact.ToString());
                            objPatientsInfo.MEPatientContactAddressLine2 =
                                objPatientsInfo.MEPatientContactAddressLine1 + ", " +
                                objPatientsInfo.GELocationName;
                            objPatientsInfo.MEPatientContactAddressLine2 =
                                objPatientsInfo.MEPatientContactAddressLine1 + ", " +
                                objPatientsInfo.GELocationName;
                            objPatientsInfo.MEPatientContactAddressLine3 = objPatientsInfo.MEPatientContactAddressLine2;
                            objPatientsInfo.AACreatedUser = BOSApp.CurrentUsersInfo.ADUserName;

                            if (!string.IsNullOrEmpty(dataPatient.photo))
                                using (var webClient = new WebClient())
                                {
                                    var imageBytesPhoto = webClient.DownloadData(dataPatient.photo);
                                    objPatientsInfo.MEPatientPicture = imageBytesPhoto;
                                }
                            listBs24X7.Add(objPatientsInfo);
                        }
                        listData.AddRange(listBs24X7);
                    }
                }
                catch (ApplicationException ex)
                {
                    // network error, show error message and create patient without bs24x7 code
                    if (ex.InnerException is WebException)
                        MessageBox.Show(PatientLocalizedResources.NetworkDisconnect,
                            PatientLocalizedResources.ThongBao);
                    else
                        MessageBox.Show(
                            @"Phát sinh lỗi khi kiểm tra thông tin bệnh nhân trên Bacsi24x7: \n" + ex.Message,
                            PatientLocalizedResources.ThongBao);
                }
            }

            #endregion

            if (listData.Count == 0)
            {
                MessageBox.Show(
                    @"Không tìm thấy dữ liệu trùng khớp với điều kiện tìm kiếm.",
                    PatientLocalizedResources.ThongBao);
                return;
            }
            entity.MEPatientList.Invalidate(listData);
            entity.MEPatientList.GridControl.RefreshDataSource();
        }

        public void ShowPatientSearchForm()
        {
            var guiSearchPatient = new guiSearchPatient();
            guiSearchPatient.Module = this;
            guiSearchPatient.Show();
            //InitAppoinmentScheduler();
            //GetCheckUps();
        }

        public void ShowPatientVisitModule(MEPatientVisitsInfo objPatientVisitsInfo)
        {
            //var patientVisitModuleName = "MEPatientVisit";
            //MEPatientVisitModule patientVisitModule = null;
            //if (BOSApp.IsOpenedModule(patientVisitModuleName))
            //{
            //    patientVisitModule = (MEPatientVisitModule)BOSApp.OpenModules[patientVisitModuleName];
            //    patientVisitModule.ParentScreen.Close();
            //}
            //patientVisitModule = new MEPatientVisitModule(objPatientVisitsInfo);
            //patientVisitModule.PatientVisit = objPatientVisitsInfo;
            //BOSApp.ShowNewModule(patientVisitModule);
        }

        /// <summary>
        ///     Init an appointment display text
        /// </summary>
        /// <param name="e"></param>
        public void InitAppointmentDisplayText(AppointmentDisplayTextEventArgs e)
        {
            var objEmployeesController = new HREmployeesController();
            var objPatientsController = new MEPatientsController();

            var startTime = string.Format("{0:HH:mm}", e.Appointment.Start);
            var endTime = string.Format("{0:HH:mm}", e.Appointment.End);
            //
            var employeeID = 0;
            var patientID = 0;
            if (BOSApp.CurrentBacSi24X7 != null)
            {
            }
            else
            {
                patientID = Convert.ToInt32(e.Appointment.Location);
                employeeID = Convert.ToInt32(e.Appointment.Subject);
            }

            var appointmentReason = e.Appointment.CustomFields["MEPatientAppointmentReason"].ToString();

            var employeeName = objEmployeesController.GetObjectNameByID(employeeID);
            var patientName = objPatientsController.GetObjectNameByID(patientID);
            if (BOSApp.CurrentBacSi24X7 != null)
                e.Text = string.Format("{0}: {1}{2}{3}: {4}{5}{6}: {7}{8}{9}: {10}",
                    PatientLocalizedResources.StartTime,
                    string.Format("{0} - {1}", startTime, endTime),
                    Environment.NewLine,
                    PatientLocalizedResources.HREmployeeName,
                    e.Appointment.Subject,
                    Environment.NewLine,
                    PatientLocalizedResources.MEPatientName,
                    e.Appointment.Location,
                    Environment.NewLine,
                    PatientLocalizedResources.AppointmentReason,
                    appointmentReason);
            else
                e.Text = string.Format("{0}: {1}{2}{3}: {4}{5}{6}: {7}{8}{9}: {10}",
                    PatientLocalizedResources.StartTime,
                    string.Format("{0} - {1}", startTime, endTime),
                    Environment.NewLine,
                    PatientLocalizedResources.HREmployeeName,
                    employeeName,
                    Environment.NewLine,
                    PatientLocalizedResources.MEPatientName,
                    patientName,
                    Environment.NewLine,
                    PatientLocalizedResources.AppointmentReason,
                    appointmentReason);
        }

        #endregion
    }
}
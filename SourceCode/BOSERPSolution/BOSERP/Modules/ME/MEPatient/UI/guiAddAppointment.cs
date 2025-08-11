using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BOSCommon;
using BOSComponent;
using Localization;
using BOSLib;
using DevExpress.XtraScheduler;
using System.Linq;
using BOSERP.Modules.ME.MEPatient.Localization;
using Clas.Business.Doctor24x7;
using Clas.Model.Doctor24x7;

namespace BOSERP.Modules.MEPatient
{
    public partial class guiAddAppointment : BOSERPScreen
    {
        #region Public Properties
        /// <summary>
        /// Gets or sets appointment date
        /// </summary>
        public DateTime PatientAppointmentDate { get; set; }

        /// <summary>
        /// Variable to know appointment is new or is edited
        /// </summary>
        public bool IsNew { get; set; }

        /// <summary>
        /// Gets or sets Patient Appointment
        /// Variable to save appointment that is chosen on scheduler control
        /// </summary>
        public MEPatientAppointmentsInfo PatientAppointment { get; set; }
        #endregion
        private int NumOfDay;
        public int Interval;
        public int EndTimeDefault;
        public string ScheduleSelectedID;
        private DateTime StartDate;
        private DateTime EndDate;
        private List<HREmployeesInfo> listEmployee = new List<HREmployeesInfo>();

        public guiAddAppointment()
        {
            InitializeComponent();
            IsNew = false;
        }

        private void fld_btnSave_Click(object sender, EventArgs e)
        {
            MEPatientEntities entity = (MEPatientEntities)((BaseModuleERP)Module).CurrentModuleEntity;
            MEPatientAppointmentsInfo objPatientAppointmentsInfo = (MEPatientAppointmentsInfo)entity.ModuleObjects[TableName.MEPatientAppointmentsTableName];
            if (objPatientAppointmentsInfo.FK_HREmployeeID == 0)
            {
                MessageBox.Show(PatientLocalizedResources.EmployeeIsRequiredMessage, "#Message#", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (objPatientAppointmentsInfo.FK_METimeFrameID == 0)
            {
                MessageBox.Show(PatientLocalizedResources.AppointmentTimeIsRequiredMessage, "#Message#", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CheckExistingAppointment(IsNew))
                return;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void guiAddAppointment_Load(object sender, EventArgs e)
        {
            //Initialize controls
            InitializeControls(Controls);

            MEPatientEntities entity = (MEPatientEntities)((BaseModuleERP)Module).CurrentModuleEntity;
            MEPatientsInfo objPatientsInfo = (MEPatientsInfo)entity.MainObject;
            MEPatientAppointmentsInfo objPatientAppointmentsInfo = (MEPatientAppointmentsInfo)entity.ModuleObjects[TableName.MEPatientAppointmentsTableName];
            if (objPatientAppointmentsInfo.MEPatientAppointmentID == 0 && IsNew == true)
            {
                objPatientAppointmentsInfo.FK_HREmployeeID = 0;
                objPatientAppointmentsInfo.FK_METimeFrameID = 0;
                objPatientAppointmentsInfo.FK_MEPatientID = objPatientsInfo.MEPatientID;
                objPatientAppointmentsInfo.MEPatientName = objPatientsInfo.MEPatientName;
                objPatientAppointmentsInfo.MEPatientAppointmentDate = PatientAppointmentDate;
                objPatientAppointmentsInfo.MEPatientAppointmentTime = PatientAppointmentDate;
                objPatientAppointmentsInfo.MEPatientAppointmentReason = string.Empty;
                IsNew = true;
            }
            else
            {
                PatientAppointment = objPatientAppointmentsInfo;
                IsNew = false;
            }
            entity.UpdateModuleObjectBindingSource(TableName.MEPatientAppointmentsTableName);

            //entity.EmployeeVisitList.GridControl = fld_dgcEmployeeVisits;
            //entity.EmployeeVisitList.SetDefaultListAndRefreshGridControl();

            fld_dteMEPatientAppointmentDate.DateTime = DateTime.Now;
            fld_cmbInterval.SelectedIndex = 0;
            NumOfDay = 1;
            StartDate = new DateTime();
            EndDate = new DateTime();
            string[] startTime = AppointmentScheduler.StartTime.Split(':');
            string[] endTime = AppointmentScheduler.EndTime.Split(':');
            fld_tedStart.Time = new DateTime(1990, 1, 1, Convert.ToInt32(startTime[0]), Convert.ToInt32(startTime[1]), 0);
            fld_tedEnd.Time = new DateTime(1990, 1, 1, Convert.ToInt32(endTime[0]), Convert.ToInt32(endTime[1]), 0);

            if (BOSApp.CurrentBacSi24X7 != null)
            {
                DoctorManager man = new DoctorManager();
                var result = man.GetListDoctors(BOSApp.CurrentBacSi24X7.userId, BOSApp.CurrentBacSi24X7.sessionId,
                        BOSApp.CurrentBacSi24X7.hospitals[BOSApp.CurrentBacSi24X7.hospitalSelectedIndex].hospitalId, null, Int16.MinValue, Int16.MaxValue, "", "firstName", "DESC", "");
                List<Doctor> list = result.data.doctors.ToList();


                listEmployee.Clear();
                for (int i = 0; i < list.Count; i++)
                {

                    HREmployeesInfo ei = new HREmployeesInfo()
                    {
                        HREmployeeID = i,
                        HREmployeeNo = list[i].id,
                        HREmployeeName = list[i].fullName,
                        FK_HRDepartmentID = i,
                        FK_HRDepartmentRoomID = i,
                        FK_BRBranchID = i
                    };
                    listEmployee.Add(ei);
                }
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(guiAddAppointment));
                resources.ApplyResources(this.fld_lkeFK_HREmployeeID, "fld_lkeFK_HREmployeeID");
                fld_lkeFK_HREmployeeID.Properties.DataSource = listEmployee;
                fld_lkeFK_HREmployeeID.Properties.Columns.Clear();
                fld_lkeFK_HREmployeeID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
                    new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("fld_lkeFK_HREmployeeID.Properties.Columns2"), resources.GetString("fld_lkeFK_HREmployeeID.Properties.Columns3"))});

            }

            InitPatientVisitScheduler();

            ADUsersController objUsersController = new ADUsersController();
            ADUsersInfo objUsersInfo = (ADUsersInfo)objUsersController.GetObjectByName(BOSApp.CurrentUser);
            if (objUsersInfo != null)
            {
                EndTimeDefault = objUsersInfo.ADUserEndTimeDefault;
            }
            if (EndTimeDefault == 0)
            {
                EndTimeDefault = 1;
            }
        }

        public override void InitializeControls(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                InitializeControl(ctrl);
                if (ctrl.Controls.Count > 0)
                {
                    InitializeControls(ctrl.Controls);
                }
            }
        }

        private void fld_lkeFK_HREmployeeID_Validated(object sender, EventArgs e)
        {
            //MEPatientEntities entity = (MEPatientEntities)((BaseModuleERP)Module).CurrentModuleEntity;
            //MEPatientAppointmentsInfo objPatientAppointmentsInfo = (MEPatientAppointmentsInfo)entity.ModuleObjects[TableName.MEPatientAppointmentsTableName];
            //if (objPatientAppointmentsInfo.FK_HREmployeeID > 0)
            //{
            //    objPatientAppointmentsInfo.HREmployeeName = fld_lkeFK_HREmployeeID.GetColumnValue("HREmployeeName").ToString();
            //    ((MEPatientModule)Module).ShowAppointmentSchedule();
            //}
        }

        private void fld_dteMEPatientAppointmentDate_Validated(object sender, EventArgs e)
        {
            ((MEPatientModule)Module).ShowAppointmentSchedule();
        }

        /// <summary>
        /// Check appointment is existing in appointment list or not
        /// </summary>
        /// <param name="isNew">To know new appointment or edited appointment</param>
        /// <returns>True or false</returns>
        private bool CheckExistingAppointment(bool isNew)
        {
            MEPatientEntities entity = (MEPatientEntities)((BaseModuleERP)Module).CurrentModuleEntity;
            MEPatientAppointmentsInfo objPatientAppointmentsInfo = (MEPatientAppointmentsInfo)entity.ModuleObjects[TableName.MEPatientAppointmentsTableName];
            if (IsNew == true)
            {
                return CheckExisting(objPatientAppointmentsInfo, -1);
            }
            else
            {
                if (PatientAppointment != null)
                {
                    if (PatientAppointment.MEPatientAppointmentID > 0)
                    {
                        int index = entity.MEPatientAppointmentsList.PosOf("MEPatientAppointmentID", PatientAppointment.MEPatientAppointmentID);
                        if (index >= 0)
                        {
                            return CheckExisting(objPatientAppointmentsInfo, index);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < entity.MEPatientAppointmentsList.Count; i++)
                        {
                            MEPatientAppointmentsInfo appointment = entity.MEPatientAppointmentsList[i];
                            if (appointment.FK_HREmployeeID == PatientAppointment.FK_HREmployeeID &&
                                 appointment.MEPatientAppointmentTime.Date == PatientAppointment.MEPatientAppointmentTime.Date &&
                                 Math.Floor(appointment.MEPatientAppointmentTime.TimeOfDay.TotalMinutes) == Math.Floor(PatientAppointment.MEPatientAppointmentTime.TimeOfDay.TotalMinutes))
                            {
                                return CheckExisting(objPatientAppointmentsInfo, i);
                            }
                        }
                    }
                }
            }
            return false;

        }

        /// <summary>
        /// Check an appointment is exisiting in appointment list
        /// </summary>
        /// <param name="objPatientAppointmentsInfo">Patient appointment information</param>
        /// <param name="index">Index of appointment in appointment list</param>
        /// <returns>True or false</returns>
        public bool CheckExisting(MEPatientAppointmentsInfo objPatientAppointmentsInfo, int index)
        {
            MEPatientEntities entity = (MEPatientEntities)((BaseModuleERP)Module).CurrentModuleEntity;
            //Check to ensure the appointment is available at the specified time

            for (int i = 0; i < entity.MEPatientAppointmentsList.Count; i++)
            {
                MEPatientAppointmentsInfo objExistingPatientAppointmentsInfo = entity.MEPatientAppointmentsList[i];
                if (!i.Equals(index))
                {
                    if (objExistingPatientAppointmentsInfo.FK_HREmployeeID == objPatientAppointmentsInfo.FK_HREmployeeID &&
                         objExistingPatientAppointmentsInfo.MEPatientAppointmentDate.Date == objPatientAppointmentsInfo.MEPatientAppointmentDate.Date &&
                        objExistingPatientAppointmentsInfo.FK_METimeFrameID == objPatientAppointmentsInfo.FK_METimeFrameID)
                    {
                        MessageBox.Show(PatientLocalizedResources.AppointmentHasBeenReservedMessage, "#Message#", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return true;
                    }
                }
            }
            MEPatientVisitsController objPatientVisitsController = new MEPatientVisitsController();
            MEPatientVisitsInfo objPatientVisitsInfo = objPatientVisitsController.GetPatientVisitByEmployeeIDAndDateAndTimeFrameID(
                                                                                                                        objPatientAppointmentsInfo.FK_HREmployeeID,
                                                                                                                        objPatientAppointmentsInfo.MEPatientAppointmentDate,
                                                                                                                        objPatientAppointmentsInfo.FK_METimeFrameID);
            if (objPatientVisitsInfo != null)
            {
                if (!objPatientVisitsInfo.FK_MEPatientID.Equals(objPatientAppointmentsInfo.FK_MEPatientID))
                {
                    MessageBox.Show(PatientLocalizedResources.AppointmentHasBeenReservedMessage, "#Message#", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }
            return false;
        }

        private void fld_btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fld_btnShow_Click(object sender, EventArgs e)
        {
            InitPatientVisitScheduler();
        }

        private void fld_btn1Day_Click(object sender, EventArgs e)
        {
            fld_btn1Day.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            fld_btn5Week.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            fld_btn7Week.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            fld_btn31Month.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            NumOfDay = 1;
        }

        private void fld_btn5Week_Click(object sender, EventArgs e)
        {
            fld_btn1Day.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            fld_btn5Week.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            fld_btn7Week.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            fld_btn31Month.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            NumOfDay = 5;
        }

        private void fld_btn7Week_Click(object sender, EventArgs e)
        {
            fld_btn1Day.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            fld_btn5Week.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            fld_btn7Week.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            fld_btn31Month.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            NumOfDay = 7;
        }

        private void fld_btn31Month_Click(object sender, EventArgs e)
        {
            fld_btn1Day.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            fld_btn5Week.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            fld_btn7Week.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            fld_btn31Month.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            NumOfDay = 31;
        }

        private void fld_cmbInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fld_cmbInterval.SelectedIndex == 0)
            {
                Interval = 5;
            }
            else if (fld_cmbInterval.SelectedIndex == 1)
            {
                Interval = 6;
            }
            else if (fld_cmbInterval.SelectedIndex == 2)
            {
                Interval = 10;
            }
            else if (fld_cmbInterval.SelectedIndex == 3)
            {
                Interval = 15;
            }
            else if (fld_cmbInterval.SelectedIndex == 4)
            {
                Interval = 30;
            }
            else
            {
                Interval = 60;
            }
        }

        public void InitPatientVisitScheduler()
        {
            //View of scheduler
            switch (NumOfDay)
            {
                case 1:
                    fld_schedulerControlMEPatientVisit.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.Day;
                    fld_schedulerControlMEPatientVisit.DayView.WorkTime.Start = new TimeSpan(fld_tedStart.Time.Hour, fld_tedStart.Time.Minute, 0);
                    fld_schedulerControlMEPatientVisit.DayView.WorkTime.End = new TimeSpan(fld_tedEnd.Time.Hour, fld_tedEnd.Time.Minute, 0);
                    fld_schedulerControlMEPatientVisit.DayView.ShowWorkTimeOnly = true;
                    fld_schedulerControlMEPatientVisit.DayView.TimeScale = new TimeSpan(0, Interval, 0);
                    StartDate = Convert.ToDateTime(fld_dteMEPatientAppointmentDate.EditValue);
                    EndDate = Convert.ToDateTime(fld_dteMEPatientAppointmentDate.EditValue);
                    break;
                case 5:
                    fld_schedulerControlMEPatientVisit.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.WorkWeek;
                    fld_schedulerControlMEPatientVisit.Views.WorkWeekView.ShowFullWeek = false;
                    fld_schedulerControlMEPatientVisit.WorkWeekView.WorkTime.Start = new TimeSpan(fld_tedStart.Time.Hour, fld_tedStart.Time.Minute, 0);
                    fld_schedulerControlMEPatientVisit.WorkWeekView.WorkTime.End = new TimeSpan(fld_tedEnd.Time.Hour, fld_tedEnd.Time.Minute, 0);
                    fld_schedulerControlMEPatientVisit.WorkWeekView.ShowWorkTimeOnly = true;
                    fld_schedulerControlMEPatientVisit.WorkWeekView.TimeScale = new TimeSpan(0, Interval, 0);
                    StartDate = GetWeekBeginDate();
                    EndDate = GetWeekBeginDate().AddDays(4);
                    break;
                case 7:
                    fld_schedulerControlMEPatientVisit.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.WorkWeek;
                    fld_schedulerControlMEPatientVisit.Views.WorkWeekView.ShowFullWeek = true;
                    fld_schedulerControlMEPatientVisit.WorkWeekView.WorkTime.Start = new TimeSpan(fld_tedStart.Time.Hour, fld_tedStart.Time.Minute, 0);
                    fld_schedulerControlMEPatientVisit.WorkWeekView.WorkTime.End = new TimeSpan(fld_tedEnd.Time.Hour, fld_tedEnd.Time.Minute, 0);
                    fld_schedulerControlMEPatientVisit.WorkWeekView.ShowWorkTimeOnly = true;
                    fld_schedulerControlMEPatientVisit.WorkWeekView.TimeScale = new TimeSpan(0, Interval, 0);
                    StartDate = GetWeekBeginDate();
                    EndDate = GetWeekBeginDate().AddDays(6);
                    break;
                case 31:
                    fld_schedulerControlMEPatientVisit.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.Month;
                    StartDate = BOSUtil.GetMonthBeginDate();
                    EndDate = BOSUtil.GetMonthEndDate();
                    break;
                default:
                    break;
            }
            IList<MEPatientVisitsInfo> patientVisits = new List<MEPatientVisitsInfo>();
            patientVisits.Clear();
            MEPatientEntities entity = (MEPatientEntities)((BaseModuleERP)Module).CurrentModuleEntity;
            MEPatientVisitsController objPatientVisitsController = new MEPatientVisitsController();
            
            if (BOSApp.CurrentBacSi24X7 != null)
            {
                
                var bsId = listEmployee[Convert.ToInt32(fld_lkeFK_HREmployeeID.EditValue)].HREmployeeNo; // ID bác sĩ
                UserManager man = new UserManager();
                long StartDateTimeStamp = BOSApp.ConvertToTimestamp(StartDate);
                long EndDateTimeStamp = BOSApp.ConvertToTimestamp(EndDate);
                var result = man.GetAvailableScheduleOfDoctor(bsId, BOSApp.CurrentBacSi24X7.hospitals[BOSApp.CurrentBacSi24X7.hospitalSelectedIndex].hospitalId, StartDateTimeStamp, EndDateTimeStamp, BOSApp.CurrentBacSi24X7.userId, BOSApp.CurrentBacSi24X7.sessionId);
                List<Schedule> list = result.data.schedules.ToList();

                for (int i = 0; i < list.Count; i++)
                {
                    MEPatientVisitsInfo p = new MEPatientVisitsInfo()
                    {
                        MEPatientVisitRemark = i.ToString(),
                        MEPatientName = list[i].doctor.fullName,
                        MEPatientVisitNo = list[i].id,
                        METimeFrameStartTime = new DateTime(list[i].StartTimeLocal.Year, list[i].StartTimeLocal.Month, list[i].StartTimeLocal.Day, list[i].StartTimeLocal.Hour, list[i].StartTimeLocal.Minute, list[i].StartTimeLocal.Second),
                        METimeFrameEndTime = new DateTime(list[i].EndTimeLocal.Year, list[i].EndTimeLocal.Month, list[i].EndTimeLocal.Day, list[i].EndTimeLocal.Hour, list[i].EndTimeLocal.Minute, list[i].EndTimeLocal.Second)
                    };
                    patientVisits.Add(p);
                }

            }
            else
            {
                patientVisits = objPatientVisitsController.GetPatientVisitList(Convert.ToInt32(fld_lkeFK_HREmployeeID.EditValue), StartDate, EndDate);
                patientVisits = patientVisits.Where(p => p.FK_MEPatientID > 0).ToList();

                for (int i = 0; i < patientVisits.Count; i++)
                {
                    patientVisits[i].METimeFrameStartTime = new DateTime(patientVisits[i].MEPatientVisitDate.Year, patientVisits[i].MEPatientVisitDate.Month, patientVisits[i].MEPatientVisitDate.Day,
                                                                            patientVisits[i].METimeFrameStartTime.Hour, patientVisits[i].METimeFrameStartTime.Minute, patientVisits[i].METimeFrameStartTime.Second);
                    patientVisits[i].METimeFrameEndTime = new DateTime(patientVisits[i].MEPatientVisitDate.Year, patientVisits[i].MEPatientVisitDate.Month, patientVisits[i].MEPatientVisitDate.Day,
                                                                            patientVisits[i].METimeFrameEndTime.Hour, patientVisits[i].METimeFrameEndTime.Minute, patientVisits[i].METimeFrameEndTime.Second);

                }
            }

            entity.EmployeeVisitList.Invalidate(patientVisits);
            
            fld_schedulerControlMEPatientVisit.Storage.Appointments.DataSource = entity.EmployeeVisitList;
            fld_schedulerControlMEPatientVisit.Storage.Appointments.Mappings.Subject = "MEPatientName";
            fld_schedulerControlMEPatientVisit.Storage.Appointments.Mappings.Start = "METimeFrameStartTime";
            fld_schedulerControlMEPatientVisit.Storage.Appointments.Mappings.End = "METimeFrameEndTime";
            fld_schedulerControlMEPatientVisit.Storage.Appointments.Mappings.Description = "MEPatientVisitRemark";
            //fld_schedulerControlMEPatientVisit.Storage.Appointments.CustomFieldMappings.Add(new AppointmentCustomFieldMapping("MEPatientName", "MEPatientName"));
            //fld_schedulerControlMEPatientVisit.Storage.Appointments.CustomFieldMappings.Add(new AppointmentCustomFieldMapping("FK_HREmployeeID", "FK_HREmployeeID"));
            //fld_schedulerControlMEPatientVisit.Storage.Appointments.CustomFieldMappings.Add(new AppointmentCustomFieldMapping("MEPatientVisitRemark", "MEPatientVisitRemark"));
            //fld_schedulerControlMEPatientVisit.Storage.Appointments.CustomFieldMappings.Add(new AppointmentCustomFieldMapping("MEPatientVisitID", "MEPatientVisitID"));
            //fld_schedulerControlMEPatientVisit.Storage.Appointments.CustomFieldMappings.Add(new AppointmentCustomFieldMapping("MEPatientVisitStatus", "MEPatientVisitStatus"));
            fld_schedulerControlMEPatientVisit.Start = Convert.ToDateTime(fld_dteMEPatientAppointmentDate.EditValue);

            fld_schedulerControlMEPatientVisit.RefreshData();
        }

        private void fld_schedulerControlMEPatientVisit_SelectionChanged(object sender, EventArgs e)
        {
            Appointment selectedApt;
            if (this.fld_schedulerControlMEPatientVisit.SelectedAppointments.Count == 1)
            {
                selectedApt = this.fld_schedulerControlMEPatientVisit.SelectedAppointments[0];
                MEPatientVisitsInfo row = (MEPatientVisitsInfo)selectedApt.GetSourceObject(this.schedulerStorage1);
                ScheduleSelectedID = row.MEPatientVisitNo;

            }
        }

        private void fld_schedulerControlMEPatientVisit_InitAppointmentDisplayText(object sender, AppointmentDisplayTextEventArgs e)
        {
            HREmployeesController objEmployeesController = new HREmployeesController();
            MEPatientsController objPatientsController = new MEPatientsController();

            string startTime = String.Format("{0:HH:mm}", e.Appointment.Start);
            string endTime = String.Format("{0:HH:mm}", e.Appointment.End);
            //
            int employeeID = 0;
            int patientID = 0;
            if (BOSApp.CurrentBacSi24X7 != null)
            {

            }
            else
            {
                patientID = Convert.ToInt32(e.Appointment.Location);
                employeeID = Convert.ToInt32(e.Appointment.Subject);
            }

            //string appointmentReason = e.Appointment.CustomFields["MEPatientAppointmentReason"].ToString();

            string employeeName = objEmployeesController.GetObjectNameByID(employeeID);
            string patientName = objPatientsController.GetObjectNameByID(patientID);
            if (BOSApp.CurrentBacSi24X7 != null)
            {
                e.Text = String.Format("{0}: {1}{2}{3}: {4}{5}{6}: {7}{8}{9}",
                    PatientLocalizedResources.StartTime,
                    String.Format("{0} - {1}", startTime, endTime),
                    Environment.NewLine,
                    PatientLocalizedResources.HREmployeeName,
                    e.Appointment.Subject,
                    Environment.NewLine,
                    PatientLocalizedResources.MEPatientName,
                    e.Appointment.Location,
                    Environment.NewLine,
                    PatientLocalizedResources.AppointmentReason);
            }
        }

        /// <summary>
        /// Get begin date of week
        /// </summary>
        /// <returns></returns>
        public DateTime GetWeekBeginDate()
        {
            DayOfWeek day = DateTime.Now.DayOfWeek;
            int days = day - DayOfWeek.Monday;
            return DateTime.Now.AddDays(-days);
        }

        private void fld_lkeFK_METimeFrameID1_TextChanged(object sender, EventArgs e)
        {
            METimeFramesController objMETimeFramesController = new METimeFramesController();
            List<METimeFramesInfo> listTimeFrames = objMETimeFramesController.GetListAllTimeFrames();

            if (Convert.ToInt16(fld_lkeFK_METimeFrameID.EditValue) != 0 && Convert.ToInt16(fld_lkeFK_METimeFrameID.EditValue) >= Convert.ToInt16(fld_lkeFK_METimeFrameID1.EditValue))
            {
                fld_lkeFK_METimeFrameID.EditValue = Convert.ToInt16(fld_lkeFK_METimeFrameID1.EditValue) - EndTimeDefault;
            }

            if (Convert.ToInt16(fld_lkeFK_METimeFrameID1.EditValue) > listTimeFrames.Count)
            {
                fld_lkeFK_METimeFrameID1.EditValue = listTimeFrames.Count;
            }
        }

        private void fld_lkeFK_METimeFrameID_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt16(fld_lkeFK_METimeFrameID.EditValue) == 0 || fld_lkeFK_METimeFrameID.OldEditValue == null)
            {
                return;
            }
            else
            {
                fld_lkeFK_METimeFrameID1.EditValue = Convert.ToInt16(fld_lkeFK_METimeFrameID.EditValue) + EndTimeDefault;
            }
        }

    }
}

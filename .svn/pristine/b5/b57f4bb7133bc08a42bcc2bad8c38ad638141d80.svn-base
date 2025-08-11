using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BOSCommon;
using BOSLib;
using BOSERP.Modules.MEPatient;
using Clas.Business.Doctor24x7;
using Clas.Model.Doctor24x7;
using DevExpress.XtraScheduler;
using DevExpress.Utils;
using System.Linq;

namespace BOSERP.Modules.Common
{
    public partial class guiSearchPatient : BOSERPScreen
    {
        public guiSearchPatient()
        {
            InitializeComponent();
            fld_schedulerControlMEPatientAppointment.ToolTipController = fld_ToolTipController;
            fld_schedulerControlMEPatientAppointment.OptionsView.ToolTipVisibility = ToolTipVisibility.Always;

            fld_dteDateFrom.DateTime = BOSUtil.GetMonthBeginDate();
            fld_dteDateTo.DateTime = BOSUtil.GetMonthEndDate();
        }

        private void guiSearchPatient_Load(object sender, EventArgs e)
        {
            //Initialize controls
            InitializeControls(Controls);

            CommonEntities entity = (CommonEntities)((BaseModuleERP)Module).CurrentModuleEntity;
            entity.MEPatientList.InitBOSListGridControl(fld_dgcMEPatients);

            //Set default values to module objects
            MEPatientVisitsInfo objPatientVisitsInfo = (MEPatientVisitsInfo)entity.MainObject;
            entity.SetDefaultModuleObject(TableName.MEPatientsTableName);
            entity.MEPatientList.SetDefaultListAndRefreshGridControl();

            ((CommonModule)Module).InitGetAllCheckUps(BOSUtil.GetMonthBeginDate(), BOSUtil.GetMonthEndDate());
            InitAppoinmentScheduler();
        }

        private void fld_ToolTipController_BeforeShow(object sender, ToolTipControllerShowEventArgs e)
        {
            // Get the ToolTipController.
            //ToolTipController Controller = sender as ToolTipController;
            //((MEPatientModule)Module).ShowInformationTooltip(Controller, e);
        }

        public void InitAppoinmentScheduler()
        {
            CommonEntities entity = (CommonEntities)((BaseModuleERP)Module).CurrentModuleEntity;
            fld_schedulerControlMEPatientAppointment.Storage.Appointments.Mappings.Label = "PatientName";
            fld_schedulerControlMEPatientAppointment.Storage.Appointments.Mappings.Subject = "PatientName";
            fld_schedulerControlMEPatientAppointment.Storage.Appointments.Mappings.Start = "AppoitmentDateTime";
            fld_schedulerControlMEPatientAppointment.Storage.Appointments.Mappings.End = "AppointmentEndTime";
            fld_schedulerControlMEPatientAppointment.Storage.Appointments.Mappings.Location = "LocalRegisterStatus";
            fld_schedulerControlMEPatientAppointment.Storage.Appointments.Mappings.Description = "symptom";
            fld_schedulerControlMEPatientAppointment.Start = DateTime.Today;
            fld_schedulerControlMEPatientAppointment.Storage.Appointments.DataSource = entity.CheckupBs24x7;
            fld_schedulerControlMEPatientAppointment.RefreshData();

        }
        private void fld_schedulerControlMEPatientAppointment_InitAppointmentDisplayText(object sender, AppointmentDisplayTextEventArgs e)
        {
            TimeZone zone = TimeZone.CurrentTimeZone;
            string startTime = String.Format("{0:HH:mm}", zone.ToLocalTime(e.Appointment.Start));
            string endTime = String.Format("{0:HH:mm}", zone.ToLocalTime(e.Appointment.End));
            e.Text = String.Format("{0} - {1}{2}{3}",
                 e.Appointment.Subject,
                 e.Appointment.Description,
                 Environment.NewLine,
                String.Format("{0} - {1} - {2}", startTime, endTime, e.Appointment.Location));

        }

        public override void InitializeControls(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                InitializeControl(ctrl);
                if (ctrl.Controls.Count > 0)
                {
                    InitializeControls(ctrl.Controls);
                    fld_dteDateFrom.DateTime = BOSUtil.GetMonthBeginDate();
                    fld_dteDateTo.DateTime = BOSUtil.GetMonthEndDate();
                }
            }
        }


        private void fld_btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void fld_btnSearch_Click(object sender, EventArgs e)
        {
            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.Append(GenerateSearchQuery(TableName.MEPatientsTableName));
            string email = fld_txtMEPatientContactEmail.EditValue.ToString();
            string phoneNumer = fld_txtMEPatientContactCellPhone.EditValue.ToString();
            ((CommonModule)Module).SearchPatient(queryBuilder.ToString(), email, phoneNumer);
        }


        private void fld_schedulerControlMEPatientAppointment_DoubleClick(object sender, EventArgs e)
        {
            NewAndRegister();
        }

        private void fld_btnShow_Click(object sender, EventArgs e)
        {
            var module = ((CommonModule)Module);
            module.InitGetAllCheckUps((DateTime)fld_dteDateFrom.EditValue, (DateTime)fld_dteDateTo.EditValue);

            var entity = (CommonEntities)((BaseModuleERP)Module).CurrentModuleEntity;

            InitPatientVisitScheduler(7);

            fld_schedulerControlMEPatientAppointment.Start = DateTime.Today;
            fld_schedulerControlMEPatientAppointment.Storage.Appointments.DataSource = entity.CheckupBs24x7;
            fld_schedulerControlMEPatientAppointment.RefreshData();
        }

        private void fld_btnRegister_Click(object sender, EventArgs e)
        {
            NewAndRegister();
        }
        public void NewAndRegister()
        {
            var module = ((CommonModule)Module);
            var patientContr = new MEPatientsController();
            var patientVisitContr = new MEPatientVisitsController();
            Appointment selectedApt;
            if (this.fld_schedulerControlMEPatientAppointment.SelectedAppointments.Count == 1)
            {
                selectedApt = this.fld_schedulerControlMEPatientAppointment.SelectedAppointments[0];
                var appointment = (Checkup)selectedApt.GetSourceObject(this.schedulerStorage1);

                String email = appointment.dataUser.email;
                MEPatientsInfo objMEPatient = patientContr.GetPatientByBs24x7ID(appointment.dataUser.code);

                if (objMEPatient == null)
                {
                    var patientModule = new MEPatientModule(true);
                    objMEPatient = patientModule.CreatePatientAndCustomerFromBs24x7(appointment.dataUser);

                    MessageBox.Show(string.Format("Bệnh nhân: {0} - {1} đã được tạo. \n Tiếp tục tiếp nhận bệnh nhân.", objMEPatient.MEPatientNo, objMEPatient.MEPatientName));
                }

                MEPatientVisitsController objPatientVisitsController = new MEPatientVisitsController();
                MEPatientVisitsInfo objPatientVisitsInfo = objPatientVisitsController.GetLastPatientVisitByPatientID(objMEPatient.MEPatientID);
                if (objPatientVisitsInfo != null)
                {
                    if (objPatientVisitsInfo.MEPatientVisitStatus != "Finished")
                    {
                        if (objPatientVisitsInfo.MEPatientVisitBs24x7CheckupID != appointment.id)
                        {
                            MessageBox.Show("Tồn tại đợt khám chưa kết thúc có mã lịch Bacsi24x7 không phải là mã lịch hiện tại. Vui lòng kết thúc và tạo đợt khám mới.");
                        }
                        //tiep tuc kham
                        this.Close();
                        ((CommonModule)this.Module).ShowPatientVisitModule(objPatientVisitsInfo);
                        return;
                    }
                    else
                    {
                        //will Tự động tạo đợt khám mới.
                    }
                }

                var confirm = MessageBox.Show("Bạn muốn tạo đợt khám mới cho bệnh nhân này?", "Xác nhận", MessageBoxButtons.YesNoCancel);
                if (DialogResult.Cancel == confirm)
                    return;
                if (DialogResult.No == confirm && objPatientVisitsInfo == null)
                {
                    return;
                }

                // Tiep nhan benh nhan, tao dot kham moi
                objPatientVisitsInfo = CreateMEPatientVisitsInfo(objMEPatient, appointment);
                // Kham benh
                //lich kham nay da dc tiep nhan truoc do tiep tuc kham
                this.Close();
                ((CommonModule)this.Module).ShowPatientVisitModule(objPatientVisitsInfo);

            }
        }
        public MEPatientVisitsInfo CreateMEPatientVisitsInfo(MEPatientsInfo patient, Checkup appoitment)
        {
            HREmployeesController objEmployeesController = new HREmployeesController();
            HREmployeesInfo objEmployeesInfo = objEmployeesController.GetEmployeeByID(BOSApp.CurrentUsersInfo.FK_HREmployeeID);
            var patientVisit = new MEPatientVisitsInfo()
            {
                MEPatientVisitBs24x7CheckupID = appoitment != null ? appoitment.id : null,
                MEPatientVisitNo = BOSApp.GetMainObjectNo("MEPatientRegistration"),
                FK_MEPatientID = patient.MEPatientID,

                MEPatientVisitRemark = appoitment != null ? appoitment.symptom : "",
                MEPatientVisitDate = appoitment != null ? appoitment.AppoitmentDateTime : DateTime.Now,
                MEPatientVisitCheckInTime = appoitment != null ? appoitment.AppoitmentDateTime : DateTime.Now,

                FK_MESpecialismID = objEmployeesInfo != null ? objEmployeesInfo.FK_MESpecialismID : 0, // 3, //TODO
                FK_HREmployeeID = BOSApp.CurrentUsersInfo.FK_HREmployeeID,
                FK_BRBranchID = BOSApp.CurrentBranchInfo.BRBranchID,
                FK_HRStartDepartmentID = objEmployeesInfo != null ? objEmployeesInfo.FK_HRDepartmentID : 0, //3, //TODO
                MEPatientVisitStatus = "In",
            };
            MEPatientVisitsController objPatientVisitsController = new MEPatientVisitsController();
            objPatientVisitsController.CreateObject(patientVisit);
            BOSApp.UpdateObjectNumbering("MEPatientRegistration");
            return patientVisit;

        }

        private void fld_btnNewAndRegister_Click(object sender, EventArgs e)
        {
            NewAndRegister();
        }

        private void fld_schedulerControlMEPatientAppointment_SelectionChanged(object sender, EventArgs e)
        {
            fld_btnRegister.Visible = false;
            Appointment selectedApt;
            if (this.fld_schedulerControlMEPatientAppointment.SelectedAppointments.Count == 1)
            {
                selectedApt = this.fld_schedulerControlMEPatientAppointment.SelectedAppointments[0];
                var row = (Checkup)selectedApt.GetSourceObject(this.schedulerStorage1);
                var patientVisitContr = new MEPatientVisitsController();
                var visit = patientVisitContr.GetPatientVisitByBs24x7CheckupId(row.id);
                if (visit == null)
                {
                    //Benh nhan nay chua dc tiep nhan dot kham nay
                    fld_btnRegister.Visible = true;
                }
            }
        }

        private void fld_btn1Day_Click(object sender, EventArgs e)
        {

            InitPatientVisitScheduler(1);
        }

        private void fld_btn5Week_Click(object sender, EventArgs e)
        {

            InitPatientVisitScheduler(5);
        }

        private void fld_btn7Week_Click(object sender, EventArgs e)
        {

            InitPatientVisitScheduler(7);

        }

        private void fld_btn31Month_Click(object sender, EventArgs e)
        {
            InitPatientVisitScheduler(31);
        }

        public void InitPatientVisitScheduler(int NumOfDay)
        {
            fld_schedulerControlMEPatientAppointment.Start = DateTime.Today;
            //View of scheduler
            switch (NumOfDay)
            {
                case 1:
                    fld_btn1Day.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
                    fld_btn5Week.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
                    fld_btn7Week.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
                    fld_btn31Month.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;

                    fld_schedulerControlMEPatientAppointment.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.Day;
                    fld_schedulerControlMEPatientAppointment.DayView.ShowWorkTimeOnly = false;
                    fld_schedulerControlMEPatientAppointment.DayView.TimeScale = new TimeSpan(0, 15, 0);
                    fld_schedulerControlMEPatientAppointment.RefreshData();
                    break;
                case 5:
                    fld_btn1Day.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
                    fld_btn5Week.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
                    fld_btn7Week.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
                    fld_btn31Month.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;

                    fld_schedulerControlMEPatientAppointment.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.WorkWeek;
                    fld_schedulerControlMEPatientAppointment.Views.WorkWeekView.ShowFullWeek = false;
                    fld_schedulerControlMEPatientAppointment.Views.WorkWeekView.ShowWorkTimeOnly = false;
                    fld_schedulerControlMEPatientAppointment.Views.WorkWeekView.TimeScale = new TimeSpan(0, 15, 0);
                    fld_schedulerControlMEPatientAppointment.OptionsView.FirstDayOfWeek = (FirstDayOfWeek)DateTime.Today.DayOfWeek;
                    fld_schedulerControlMEPatientAppointment.RefreshData();
                    break;
                case 7:
                    fld_btn1Day.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
                    fld_btn5Week.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
                    fld_btn7Week.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
                    fld_btn31Month.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;

                    fld_schedulerControlMEPatientAppointment.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.WorkWeek;
                    fld_schedulerControlMEPatientAppointment.Views.WorkWeekView.ShowFullWeek = true;
                    fld_schedulerControlMEPatientAppointment.Views.WorkWeekView.ShowWorkTimeOnly = false;
                    fld_schedulerControlMEPatientAppointment.Views.WorkWeekView.TimeScale = new TimeSpan(0, 15, 0);
                    //DateTime.Today.DayOfWeek
                    fld_schedulerControlMEPatientAppointment.OptionsView.FirstDayOfWeek = (FirstDayOfWeek)DateTime.Today.DayOfWeek;
                    fld_schedulerControlMEPatientAppointment.RefreshData();
                    break;
                case 31:

                    fld_btn1Day.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
                    fld_btn5Week.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
                    fld_btn7Week.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
                    fld_btn31Month.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;

                    fld_schedulerControlMEPatientAppointment.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.Month;
                    fld_schedulerControlMEPatientAppointment.OptionsView.FirstDayOfWeek = FirstDayOfWeek.Monday;
                    fld_schedulerControlMEPatientAppointment.RefreshData();
                    break;
                default:
                    break;
            }
        }

    }
}

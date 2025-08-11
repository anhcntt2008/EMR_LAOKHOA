using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraScheduler;
using System.Drawing.Drawing2D;
using DevExpress.XtraScheduler.Drawing;
using DevExpress.XtraScheduler.Localization;
using DevExpress.Utils;
using Localization;
using Clas.Business.Doctor24x7;
using Clas.Model.Doctor24x7;
using System.Collections.Generic;
using System.Linq;
using BOSERP.Modules.ME.MEPatient.Localization;

namespace BOSERP.Modules.MEPatient.UI
{
	/// <summary>
	/// Summary description for DMMAPA102
	/// </summary>
	public partial class DMMEPA102 : BOSERPScreen
	{
        
		public DMMEPA102()
		{
			//
			// Required designer variable
			//
           

			InitializeComponent();
            fld_schedulerControlMEPatientAppointment.ToolTipController = fld_ToolTipController;
            fld_schedulerControlMEPatientAppointment.OptionsView.ToolTipVisibility = ToolTipVisibility.Always;
            fld_ToolTipController.ToolTipType = ToolTipType.Standard;

            
        }

        private void fld_btnAdd_Click(object sender, EventArgs e)
        {
            ((MEPatientModule)Module).AddAppointment();
        }

        private void fld_btnDelete_Click(object sender, EventArgs e)
        {
            ((MEPatientModule)Module).RemoveItemFromAppointmentList();
                        
        }

        private void fld_ToolTipController_BeforeShow(object sender, ToolTipControllerShowEventArgs e)
        {
            // Get the ToolTipController.
            ToolTipController Controller = sender as ToolTipController;
            ((MEPatientModule)Module).ShowInformationTooltip(Controller, e);
        }

        private void fld_dteDateFrom_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = (fld_dteDateFrom.DateTime > fld_dteDateTo.DateTime);
        }

        private void fld_dteDateFrom_InvalidValue(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.ErrorText = PatientLocalizedResources.FromDateLargerToDateErrorMessage;
        }

        private void fld_dteDateTo_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = (fld_dteDateFrom.DateTime > fld_dteDateTo.DateTime);
        }

        private void fld_dteDateTo_InvalidValue(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.ErrorText = PatientLocalizedResources.ToDateLessFromDateErrorMessage;
        }

        private void fld_schedulerControlMEPatientAppointment_InitAppointmentDisplayText(object sender, AppointmentDisplayTextEventArgs e)
        {
            ((MEPatientModule)Module).InitAppointmentDisplayText(e);
        }

        private void fld_btnEdit_Click(object sender, EventArgs e)
        {
            ((MEPatientModule)Module).EditAppointment();
        }

        private void fld_btnShow_Click(object sender, EventArgs e)
        {
            ((MEPatientModule)Module).InitAppoinmentScheduler();
            ((MEPatientModule)Module).InvalidateAppointmentList();
        }

        private void fld_schedulerControlMEPatientAppointment_DoubleClick(object sender, EventArgs e)
        {
            if (BOSApp.CurrentBacSi24X7 != null)
            {
                ((MEPatientModule)Module).ActivePatientRegistration();
            } else
            {
                ((MEPatientModule)Module).EditAppointment();
            }
        }
	}
}

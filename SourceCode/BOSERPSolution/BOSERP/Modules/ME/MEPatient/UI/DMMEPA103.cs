using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using BOSERP.Modules.ME.MEPatient.Localization;
using Localization;

namespace BOSERP.Modules.MEPatient.UI
{
	/// <summary>
	/// Summary description for DMMEPA103
	/// </summary>
	public partial class DMMEPA103 : BOSERPScreen
	{

		public DMMEPA103()
		{
			//
			// Required designer variable
			//
			InitializeComponent();
		}

        private void fld_btnAdd103_Click(object sender, EventArgs e)
        {
            ((MEPatientModule)Module).AddItemToPatientInssList();
        }

        private void fld_btnDelete103_Click(object sender, EventArgs e)
        {
            ((MEPatientModule)Module).DeleteItemFromPatientInssList();
        }

        private void fld_btnEdit103_Click(object sender, EventArgs e)
        {
            ((MEPatientModule)Module).ChangeItemFromPatientInssList();
        }

        private void fld_lkeFK_MECompanyID_EditValueChanged(object sender, EventArgs e)
        {
            //((MEPatientModule)Module).InvalidateInsLevel();
        }

        private void fld_dteMEPatientInsRegisteredDate_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = (fld_dteMEPatientInsRegisteredDate.DateTime > fld_dteMEPatientInsExpiryDate.DateTime);
        }

        private void fld_dteMEPatientInsRegisteredDate_InvalidValue(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.ErrorText = PatientLocalizedResources.RegisteredDateLargerExpiryDateErrorMessage;
        }

        private void fld_dteMEPatientInsExpiryDate_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = (fld_dteMEPatientInsRegisteredDate.DateTime > fld_dteMEPatientInsExpiryDate.DateTime);
        }

        private void fld_dteMEPatientInsExpiryDate_InvalidValue(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
            e.ErrorText = PatientLocalizedResources.ExpiryDateLessRegisteredDateErrorMessage;
        }

        private void fld_txtMEPatientInsRegisteredPlaceNo_TextChanged(object sender, EventArgs e)
        {
            //((MEPatientModule)Module).InvalidateHospitalRank(fld_txtMEPatientInsRegisteredPlaceNo.Text);
            //BOSComponent.BOSTextBox tb = (BOSComponent.BOSTextBox)sender;
            //if (tb.Text.Length > 0)
            //{
            //    ((MEPatientModule)Module).InvalidateHospitalRank(tb.EditValue.ToString());
            //    String a = fld_txtMEPatientInsRegisteredPlaceNo.Text;
            //}
        }

        private void fld_txtMEPatientInsRegisteredPlaceNo_KeyUp(object sender, KeyEventArgs e)
        {
            ((MEPatientModule)Module).InvalidateHospitalRank(fld_txtMEPatientInsRegisteredPlaceNo.Text);
        }
	}
}

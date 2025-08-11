using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Localization;

namespace BOSERP.Modules.MEPatient.UI
{
	/// <summary>
	/// Summary description for DMMAPA100
	/// </summary>
	public partial class DMMAPA100 : BOSERPScreen
	{

		public DMMAPA100()
		{
			//
			// Required designer variable
			//
			InitializeComponent();
		}

        private void fld_lkeFK_MEOccupationID_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int occupationID = Convert.ToInt32(fld_lkeFK_MEOccupationID.EditValue);
                if (occupationID == -1)
                {
                    ((MEPatientModule)Module).CreateNewOccupation();
                }
            }
        }

        private void fld_bedGELocationName_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ((MEPatientModule)Module).ChooseLocation();
        }

        private void fld_txtMEPatientName1_EditValueChanged(object sender, EventArgs e)
        {
            ((MEPatientModule)Module).SearchPatientByName();
        }

        private void fld_dteMEPatientBirthday_EditValueChanged(object sender, EventArgs e)
        {
            //Duoc thay the boi event fld_dteMEPatientBirthday_Validated
            //Vi event nay duoc goi trong module Quan ly nguoi dung
            //Module quan ly nguoi dung khong remote duoc event cua devexpress
            //((MEPatientModule)Module).SearchPatientByNameAndBirthdayAndGender();
        }

        private void fld_dteMEPatientBirthday_Validated(object sender, EventArgs e)
        {
            ((MEPatientModule)Module).SearchPatientByNameAndBirthdayAndGender();
        }

        private void fld_lkeMEGender_EditValueChanged(object sender, EventArgs e)
        {
            ((MEPatientModule)Module).SearchPatientByNameAndBirthdayAndGender();
        }

        private void fld_lkeFK_MEEthnicID_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int ethnicID = Convert.ToInt32(fld_lkeFK_MEEthnicID.EditValue);
                if (ethnicID == -1)
                {
                    ((MEPatientModule)Module).CreateNewEthnic();
                }
            }
        }
	}
}

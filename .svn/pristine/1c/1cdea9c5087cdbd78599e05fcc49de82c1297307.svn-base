using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using BOSLib;
using BOSCommon;

namespace BOSERP.Modules.CompanyConstant.UI
{
	/// <summary>
	/// Summary description for DMCS105
	/// </summary>
	public partial class DMCS105 : BOSERPScreen
	{

		public DMCS105()
		{
			//
			// Required designer variable
			//
			InitializeComponent();
            // Load working time config
            ADConfigValuesController objConfigValuesController = new ADConfigValuesController();
            fld_txtDaysPerMonth.EditValue = objConfigValuesController.GetObjectByConfigKey(ConfigValueKey.DaysPerMonth.ToString()).ADConfigKeyValue;
            fld_txtHoursPerDay.EditValue = objConfigValuesController.GetObjectByConfigKey(ConfigValueKey.HoursPerDay.ToString()).ADConfigKeyValue;
            // Load leave days config
            fld_txtAnnualLeaveDays.EditValue = objConfigValuesController.GetObjectByConfigKey(ConfigValueKey.AnnualLeaveDays.ToString()).ADConfigKeyValue;
            fld_txtSickLeaveDays.EditValue = objConfigValuesController.GetObjectByConfigKey(ConfigValueKey.SickLeaveDays.ToString()).ADConfigKeyValue;
            fld_txtBirthLeaveDays.EditValue = objConfigValuesController.GetObjectByConfigKey(ConfigValueKey.BirthLeaveDays.ToString()).ADConfigKeyValue;
            fld_txtOTLeaveDays.EditValue = objConfigValuesController.GetObjectByConfigKey(ConfigValueKey.OTLeaveDays.ToString()).ADConfigKeyValue;
            fld_txtNormalLeaveDays.EditValue = objConfigValuesController.GetObjectByConfigKey(ConfigValueKey.NormalLeaveDays.ToString()).ADConfigKeyValue;
            fld_txtTaxableWage.EditValue = objConfigValuesController.GetObjectByConfigKey(ConfigValueKey.TaxableWage.ToString()).ADConfigKeyValue;
		}

        private void fld_btnButton2_Click(object sender, EventArgs e)
        {
            ((Modules.CompanyConstant.CompanyConstantModule)this.Module).SaveStaffConfig();
        }
	}
}

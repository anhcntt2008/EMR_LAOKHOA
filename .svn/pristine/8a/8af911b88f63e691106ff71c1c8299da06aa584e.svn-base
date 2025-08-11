using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BOSERP.Modules.SellStaff.UI
{
	/// <summary>
	/// Summary description for DMMEEM101
	/// </summary>
	public partial class DMSS100 : BOSERPScreen
	{

		public DMSS100()
		{
			//
			// Required designer variable
			//
			InitializeComponent();
		}

        private void fld_txtHREmployeeContractSlrAmt_Validated(object sender, EventArgs e)
        {
            ((SellStaffModule)Module).ChangeContractSalary();
        }

        private void fld_txtHREmployeeSalaryFactor_Validated(object sender, EventArgs e)
        {
            ((SellStaffModule)Module).ChangeContractSalaryFactor();
        }

        private void fld_txtHREmployeeWorkingSlrAmt_Validated(object sender, EventArgs e)
        {
            ((SellStaffModule)Module).ChangeWorkingSalary();
        }

        private void fld_txtHREmployeeDaysPerMonth_Validated(object sender, EventArgs e)
        {
            ((SellStaffModule)Module).ChangeDaysPerMonth();
        }

        private void fld_txtHREmployeeHoursPerDay_Validated(object sender, EventArgs e)
        {
            ((SellStaffModule)Module).ChangeHoursPerDay();
        }

        

        private void fld_txtHREmployeeContractSlrAmt_Leave(object sender, EventArgs e)
        {
            ((SellStaffModule)Module).UpdateSalary();
        }

        private void fld_txtHREmployeeSalaryFactor_Leave(object sender, EventArgs e)
        {
            ((SellStaffModule)Module).UpdateSalary();
        }

        private void fld_txtHREmployeeExtraSalary1_Leave(object sender, EventArgs e)
        {
            ((SellStaffModule)Module).UpdateSalary();
        }

        private void fld_txtHREmployeeExtraHarmfullSubsidies_Leave(object sender, EventArgs e)
        {
            ((SellStaffModule)Module).UpdateSalary();
        }

        private void fld_txtHREmployeeExtraGasolineVehicle_Leave(object sender, EventArgs e)
        {
            ((SellStaffModule)Module).UpdateSalary();
        }

        private void fld_txtHREmployeeExtraLunch_Leave(object sender, EventArgs e)
        {
            ((SellStaffModule)Module).UpdateSalary();
        }

        private void fld_txtHREmployeeExtraResponsibility_Leave(object sender, EventArgs e)
        {
            ((SellStaffModule)Module).UpdateSalary();
        }
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BOSERP
{
    public partial class guiOPDCentreWizard : BOSERPScreen
    {
        /// <summary>
        /// Value indicates whether the application should be started
        /// after this wizard is closed
        /// </summary>
        private bool StartApplication = false;

        public guiOPDCentreWizard()
        {
            InitializeComponent();
        }

        private void fld_btnClose_Click(object sender, EventArgs e)
        {
            StartApplication = true;
            Dispose();
        }

        private void fld_pte24HourClinic_Click(object sender, EventArgs e)
        {
            StartApplication = true;
            Dispose();
        }

        private void guiOPDCentreWizard_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (StartApplication)
            {
                BOSApp.StartApplication();
            }
        }

        private void fld_btnBack_Click(object sender, EventArgs e)
        {
            StartApplication = false;
            Dispose();

            guiDepartmentWizard guiDepartmentWizard = new guiDepartmentWizard();
            guiDepartmentWizard.ShowDialog();
        }
    }
}

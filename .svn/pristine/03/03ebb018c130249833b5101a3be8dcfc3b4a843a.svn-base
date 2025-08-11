using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using BOSERP.UI;

namespace BOSERP.Modules.MEEmr.UI
{
    /// <summary>
    /// Summary description for SMMEEMR100
    /// </summary>
    public partial class SMMEEMR100 : BOSERPScreen
    {

        public SMMEEMR100()
        {
            //
            // Required designer variable
            //
            InitializeComponent();
        }

        private void chkDepartmentShared_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDepartmentShared.Checked)
            {
                var dt = fld_ccbeFK_HRDepartmentID1.DataSource as DataTable;
                var shares = new List<int>();
                foreach (DataRow row in dt.Rows)
                {
                    if (row["HRDepartmentEmrShared"].ToString() == "True")
                    {
                        shares.Add(int.Parse(row["HRDepartmentID"].ToString()));
                    }
                }
                fld_ccbeFK_HRDepartmentID1.EditValue = (string.Join(", ", shares));
            }
            else
                fld_ccbeFK_HRDepartmentID1.EditValue = (BOSApp.CurrentEmployeesInfo.FK_HRDepartmentID.ToString());
        }

        private void chkEmrCurrentShared_CheckedChanged(object sender, EventArgs e)
        {
            fld_ccbeFK_HRDepartmentID1.Enabled = !chkEmrCurrentShared.Checked;
            chkDepartmentShared.Enabled = !chkEmrCurrentShared.Checked;
            fld_txtMEEmrNo.Enabled = !chkEmrCurrentShared.Checked;
            fld_dteMEEmrCreatedDateSearchFrom.Enabled = !chkEmrCurrentShared.Checked;
            fld_dteMEEmrCreatedDateSearchTo.Enabled = !chkEmrCurrentShared.Checked;
            fld_lkeFK_MEEmrTypeID.Enabled = !chkEmrCurrentShared.Checked;
            fld_lkeMEEmrStatus.Enabled = !chkEmrCurrentShared.Checked;
            fld_lkeFK_MEPatientID.Enabled = !chkEmrCurrentShared.Checked;
        }

        private void SearchPatient(string text)
        {
            var gui = new guiSearchPatient(text);
            gui.Module = this.Module;
            gui.StartPosition = FormStartPosition.CenterParent;
            if (gui.ShowDialog() == DialogResult.OK)
            {
                fld_lkeFK_MEPatientID.EditValue = gui.Patient.MEPatientID;
                fld_txtMEPatientNo.Text = gui.Patient.MEPatientNo;
                fld_txtMEPatientName.Text = gui.Patient.MEPatientName;
            }
        }
        private void btnSearchPatient_Click(object sender, EventArgs e)
        {
            SearchPatient(fld_txtMEPatientNo.Text);
        }
    }
}
